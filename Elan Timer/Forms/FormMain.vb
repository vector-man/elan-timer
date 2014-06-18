Imports Microsoft.WindowsAPICodePack.Taskbar
Imports System.Threading
Imports System.Text
Imports System.IO

Imports ElanTimer.Prefs
Imports ElanTimer.Settings
Imports ElanTimer.Rendering
Public Class FormMain
    Public updateCancellationTokenSource As System.Threading.CancellationTokenSource
    Public timerSurface As Surface

    Private ReadOnly EscapeKeyChar = Convert.ToChar(27)

    Private timerObject As TimerTextRenderable
    Private noteObject As TextRenderable
    Private stringFormat As New StringFormat
    Private renderer As Renderer
    Private forceClose As Boolean = False

    Private transporter As ITransporter = New JsonNetTransporter()
    Private timeSettings As TimeSettings = New TimeSettings()
    Private taskSettings As TaskSettings = New TaskSettings()
    Private styleSettings As StyleSettings = New StyleSettings()

#If DEBUG Then
    Private sw As New Stopwatch ' Used for benchmark and testing.
#End If

    Public timer As CodeIsle.Timers.AlarmTimer

#Region "Timer Event Handelers"
    Public Sub Timer_Started(sender As Object, e As TimerEventArgs)
        ' sw.Start()
        ExecuteActions(TimerEvent.Started)
    End Sub
    Public Sub Timer_Paused(sender As Object, e As TimerEventArgs)
        ExecuteActions(TimerEvent.Paused)
    End Sub
    Public Sub Timer_Restarted(sender As Object, e As TimerEventArgs)
        ExecuteActions(TimerEvent.Restarted)
        HideNote()
    End Sub
    Public Sub Timer_Expired(sender As Object, e As TimerEventArgs)
        '#If DEBUG Then
        '        sw.Stop()
        '        MessageBox.Show(sw.Elapsed.TotalMilliseconds)
        '#End If

        ExecuteActions(TimerEvent.Expired)
        ShowNote()
        TryShowNoteAlert()
    End Sub
    Public Sub ExecuteActions(e As TimerEvent)
        TaskEx.Run(Sub()

                       Dim actions = From action In taskSettings.Tasks
                                     Where action.Enabled.Equals(True) And action.Event.Equals(e)
                                     Select action
                       For Each action In actions
                           Try
                               Process.Start(action.Command, action.Arguments)
                           Catch ex As Exception

                           End Try
                       Next
                   End Sub)
    End Sub
#End Region
#Region "Form Event Handelers"
    Private Sub ToolStripButtonReset_Click(sender As Object, e As EventArgs) Handles ToolStripButtonReset.Click
        ' Reset the timer.
        ResetTimer()
    End Sub

    Private Sub AlwaysOnTopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAlwaysOnTop.Click
        Me.TopMost = CType(sender, ToolStripMenuItem).Checked
        My.Settings.AlwaysOnTop = Me.ToolStripMenuItemAlwaysOnTop.Checked
    End Sub

    Private Sub FormMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ((Not forceClose) And My.Settings.CloseToSystemTray And My.Settings.ShowInSystemTray) Then
            e.Cancel = True
            CloseToSystemTray()
            Return
        End If
        ShutDownRendering()
        If Not My.Settings.WindowFullScreen Then
            My.Settings.WindowMaximized = (Me.WindowState = FormWindowState.Maximized)
            Me.WindowState = FormWindowState.Normal
            My.Settings.WindowSize = Me.Size
        End If
        SaveSettings()
    End Sub

    Private Sub ConfigureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SettingsDialog.ShowDialog()
    End Sub

    Private Sub ToolStrip1_MouseEnter(sender As Object, e As EventArgs) Handles ToolStripMain.MouseEnter
        Me.Focus()
    End Sub

    Private Sub FormMain_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = EscapeKeyChar Then
            ExitFullScreen()
        End If
    End Sub
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Load the localization language.
            LoadLanguage()

            ' Load settings.
            LoadSettings()

            ' Create a new alarm initialized to Nothing.
            Dim alarm As Alarm = Nothing

            timeSettings.AlarmName = If(String.IsNullOrEmpty(timeSettings.AlarmName) OrElse Not File.Exists(Path.Combine(Common.AlarmsPath, timeSettings.AlarmName)), Utils.GetDefaultAlarm(Common.AlarmsPath), timeSettings.AlarmName)

            ' Try to assign alarm to a new Alarm object.
            Try
                alarm = New Alarm(Path.Combine(Common.AlarmsPath, timeSettings.AlarmName), timeSettings.AlarmVolume, timeSettings.AlarmLoop)
            Catch ex As Exception

            End Try

            ' Create a new timer object.
            timer = TimerFactory.CreateInstance(timeSettings.Duration, timeSettings.CountUp, timeSettings.Restarts, alarm, timeSettings.AlarmEnabled)

            ' Start rendering.
            StartUpRendering(timer)
            ' Add event handlers for the timer.
            AddTimerHandlers()
            ' Add handler for UpdateUI
            AddHandler Application.Idle, AddressOf UpdateUI
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub ToolStripMenuItemSettings_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemMisc.Click
        ' Show the Settings dialog.
        ShowSettingsDialog(Me)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemExit.Click
        ' Exit the application, forcing it to close.
        ExitApplication()
    End Sub

    Private Sub ToolStripMenuItemStyle_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemStyle.Click
        ' Show the Look Dialog.
        ShowLookDialog(Me)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemTasks.Click
        ' Show the task dialog with current form as parent.
        ContextMenuStripMain.Enabled = False
        ShowTaskDialog(Me)
        ContextMenuStripMain.Enabled = True
    End Sub

    Private Sub DefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDefault.Click
        ' Set timer form to default size.
        My.Settings.WindowFullScreen = False
        My.Settings.WindowMaximized = False
        GoFullscreen(My.Settings.WindowFullScreen)
        Me.Size = My.Settings.DefaultWindowSize
    End Sub

    Private Sub CompactToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCompact.Click
        ' Set timer form to 'compact' size.
        Me.Size = New Size(My.Settings.DefaultCompactWindowWidth, Me.Height - Me.ClientSize.Height + Me.ToolStripMain.Height)
    End Sub

    Private Sub TimerSurface_DoubleClick(sender As Object, e As EventArgs)
        ' Show timer dialog without editing ('New Timer' mode).
        ShowTimerDialog(Me, False)
    End Sub
    Private Sub TimerSurface_Click(sender As Object, e As EventArgs)
        ' Exit fullscreen mode (when the timer display area is clicked).
        ExitFullScreen()
    End Sub
    ' Toggle timer between paused/not paused.
    Private Sub ToolStripButtonStartPause_Click(sender As Object, e As EventArgs) Handles ToolStripButtonStartPause.Click
        ' Set timer state to the opposite of its current state (toggle start/pause). 
        SetTimerState(Not timer.Enabled)
    End Sub
    ' Set timer form to fullscreen.
    Private Sub FullScreenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemFullScreen.Click
        If My.Settings.WindowFullScreen Then
            ExitFullScreen()
        Else
            My.Settings.WindowFullScreen = True
            My.Settings.WindowMaximized = False
            GoFullscreen(My.Settings.WindowFullScreen)
            Me.Focus()
        End If
    End Sub
#End Region



#Region "Helper Methods"
    ' Hide the timer note and show the time.
    Private Sub HideNote()
        ' Hide the note.
        noteObject.Visible = False
        ' Show the timer.
        timerObject.Visible = True
    End Sub
    ' Show the timer note and hide the time.
    Private Sub ShowNote()
        ' If the note text is empty, set it to "Expired."
        If noteObject.Text = String.Empty Then
            noteObject.Text = My.Resources.Strings.TimerHasExpired
        End If
        ' Show the note.
        noteObject.Visible = True
        ' Hide the timer.
        timerObject.Visible = False
    End Sub
    Private Function LimitTextLength(text As String, maximumLength As Long)
        If (text.Length > maximumLength) Then
            Return text.Substring(0, (maximumLength - 3)) & "..."
        Else
            Return text
        End If
    End Function
    Private Sub TryShowNoteAlert()
        Me.Invoke(New Action(Sub()
                                 If (timeSettings.NoteEnabled And timeSettings.AlertEnabled) Then
                                     MessageBox.Show(If(noteObject.Text = String.Empty, My.Resources.Strings.TimerHasExpired, noteObject.Text), My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                 End If
                             End Sub))

    End Sub
    ' Load the language settings.
    Private Sub LoadLanguage()
        Try
            ' Try to set UI culture to the language fronm settings.
            Common.Languages.SetUICulture(My.Settings.Language)
        Catch ex As Exception
            ' On failure, revert to the default language.
            My.Settings.Language = My.Settings.DefaultLanguage
        End Try
        ' Set localization text.
        Common.SetStrings()
    End Sub
    ' Exits fullscreen mode.
    Private Sub ExitFullScreen()
        '  If in fullscreen mode...
        If My.Settings.WindowFullScreen Then
            ' Exit fullscreen mode.
            My.Settings.WindowFullScreen = False
            My.Settings.WindowMaximized = False
            GoFullscreen(My.Settings.WindowFullScreen)
        End If
    End Sub
    ' Removes the event handlers for the timer.
    Private Sub RemoveTimerHandlers()
        RemoveHandler timer.Started, AddressOf Timer_Started
        RemoveHandler timer.Paused, AddressOf Timer_Paused
        RemoveHandler timer.Expired, AddressOf Timer_Expired
        RemoveHandler timer.Restarted, AddressOf Timer_Restarted
    End Sub
    ' Adds the event handlers for the timer.
    Private Sub AddTimerHandlers()
        AddHandler timer.Started, AddressOf Timer_Started
        AddHandler timer.Paused, AddressOf Timer_Paused
        AddHandler timer.Expired, AddressOf Timer_Expired
        AddHandler timer.Restarted, AddressOf Timer_Restarted
    End Sub
    ' Shuts down rendering of the timer.
    Private Sub ShutDownRendering()
        updateCancellationTokenSource.Cancel()
        Task.WaitAll()
        PanelTimer.Controls.Clear()

        timerSurface.Dispose()

        Task.WaitAll()
    End Sub
    ' Starts up rendering of the timer.
    Private Async Sub StartUpRendering(timer As ElanTimer.CodeIsle.Timers.AlarmTimer)
        updateCancellationTokenSource = New System.Threading.CancellationTokenSource

        stringFormat = New StringFormat(System.Drawing.StringFormat.GenericTypographic)
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        timerObject = New TimerTextRenderable(timer, styleSettings.DisplayFont, styleSettings.DisplayFormat, New TimeFormat(), styleSettings.GrowToFit, styleSettings.ForegroundColor, stringFormat, True)
        noteObject = New TextRenderable(timeSettings.Note, styleSettings.DisplayFont, styleSettings.GrowToFit, styleSettings.ForegroundColor, stringFormat, False)


        timerSurface = New Surface()
        timerSurface.BackColor = styleSettings.BackgroundColor
        AddHandler timerSurface.DoubleClick, AddressOf TimerSurface_DoubleClick
        AddHandler timerSurface.Click, AddressOf TimerSurface_Click

        renderer = New Renderer(timerSurface)
        renderer.Renderables.Add(timerObject)
        renderer.Renderables.Add(noteObject)


        timerSurface.Dock = DockStyle.Fill
        PanelTimer.Controls.Add(timerSurface)

        timerObject.Rectangle = timerSurface.ClientRectangle
        noteObject.Rectangle = timerSurface.ClientRectangle


        renderer.Enabled = True

        Await FormMainProgressUpdateAsync(updateCancellationTokenSource.Token)
    End Sub


    Private Sub Started(sender As Object, e As TimerEventArgs)
#If DEBUG Then
        sw.Start()
#End If
    End Sub
    Private Sub Stopped(sender As Object, e As TimerEventArgs)
#If DEBUG Then
        sw.Stop()
#End If
    End Sub

    Private Async Function FormMainProgressUpdateAsync(token As System.Threading.CancellationToken) As Task(Of TaskModel)
        Try
            Dim assemblyName As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name
            Await Task.Factory.StartNew(Async Function()
                                            While (Not token.IsCancellationRequested)
                                                Dim currentProgressValue As Long
                                                currentProgressValue = (timer.Elapsed.TotalMilliseconds / timer.Duration.TotalMilliseconds) * 1000
                                                If TaskbarManager.IsPlatformSupported Then
                                                    TaskbarManager.Instance.SetProgressValue(currentProgressValue, 1000, Me.Handle)
                                                End If
                                                ProgressBarMain.Value = currentProgressValue

                                                Dim sb = New StringBuilder

                                                If (Not timer.IsExpired) Then
                                                    sb.Append(timerObject.Text)
                                                    If (Not timeSettings.Note = String.Empty) Then
                                                        sb.Append(" - ")
                                                    End If
                                                End If
                                                If (timeSettings.NoteEnabled) Then
                                                    sb.Append(timeSettings.Note)
                                                End If

                                                If (sb.Length = 0) Then
                                                    sb.Append(assemblyName)
                                                End If

                                                Me.Text = sb.ToString
                                                NotifyIconMain.Text = LimitTextLength(Me.Text, 63)

                                                Await TaskEx.Delay(Common.Framerate)
                                            End While
                                        End Function, token, TaskCreationOptions.LongRunning, TaskScheduler.FromCurrentSynchronizationContext)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    ' Update the button icons for paused/not paused.
    Private Sub UpdateIcons()
        ToolStripButtonStartPause.Image = If(timer.IsPaused, My.Resources.play_green, My.Resources.pause_green)
    End Sub
    ' Update the form user interface.
    Private Sub UpdateUI()
        Try
            ToolStripButtonStartPause.Enabled = Not timer.IsExpired
            NotifyIconToolStripMenuItemStartTimer.Enabled = ToolStripButtonStartPause.Enabled
            ToolStripButtonStartPause.Text = If(timer.IsPaused, My.Resources.Strings.Start, My.Resources.Strings.Pause)
            NotifyIconToolStripMenuItemStartTimer.Text = ToolStripButtonStartPause.Text
            Me.Opacity = styleSettings.Opacity / 100
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub LoadSettings()
        Try
            Dim args = My.Application.CommandLineArgs
            If args.Count > 0 Then
                Dim pref = args(0)
                If (System.IO.File.Exists(pref)) Then
                    'TODO: Fix LoadSettongs()
                    Using stream As FileStream = File.OpenRead(pref)
                        Select Case System.IO.Path.GetExtension(pref)

                            Case My.Settings.StyleFileExtension
                                Dim model = New StyleModel(transporter)
                                model.Import(stream)

                                styleSettings.BackgroundColor = model.BackgroundColor
                                styleSettings.ForegroundColor = model.ForegroundColor
                                styleSettings.DisplayFont = model.DisplayFont
                                styleSettings.DisplayFormat = model.DisplayFormat
                                styleSettings.GrowToFit = model.GrowToFit
                                styleSettings.Opacity = 100 - model.Transparency
                            Case My.Settings.TaskFileExtension
                                Dim model = New TasksModel(transporter)
                                model.Import(stream)
                                taskSettings.Tasks = model.Tasks
                            Case My.Settings.TimeFileExtension
                                Dim model = New TimeModel(transporter)
                                model.Import(stream)
                                timeSettings.AlarmName = model.AlarmName
                                timeSettings.AlarmEnabled = model.AlarmEnabled
                                timeSettings.AlarmLoop = model.AlarmLoop
                                timeSettings.AlarmVolume = model.AlarmVolume
                                timeSettings.AlertEnabled = model.AlertEnabled
                                timeSettings.CountUp = model.CountUp
                                timeSettings.Duration = model.Duration
                                timeSettings.Note = model.Note
                                timeSettings.NoteEnabled = model.NoteEnabled
                                timeSettings.Restarts = model.Restarts
                        End Select
                    End Using

                End If
            End If
        Catch ex As Exception

        End Try


        ' Fixes taskbar showing issue.
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = True


        Me.ToolStripMenuItemAlwaysOnTop.Checked = My.Settings.AlwaysOnTop
        Me.TopMost = Me.ToolStripMenuItemAlwaysOnTop.Checked
        ' Me.Opacity = ElanTimer.Settings.Settings.Look.Opacity / 100.

        Me.Size = My.Settings.WindowSize
        If My.Settings.WindowMaximized Then
            Me.WindowState = FormWindowState.Maximized
        End If
        If My.Settings.WindowFullScreen Then
            GoFullscreen(True)
        End If

        Me.ToolStripButtonReset.Text = My.Resources.Strings.Reset

        NotifyIconMain.Visible = My.Settings.ShowInSystemTray
        ' Get rid of selection on toolstrip.
        Me.Focus()
    End Sub

    Private Sub ResetTimer()
        timer.Reset()
        HideNote()
        UpdateIcons()
    End Sub

    ' Shows the 'New Timer' or 'Edit Timer' dialogs.
    Public Sub ShowTimerDialog(owner As System.Windows.Forms.IWin32Window, editing As Boolean)
        ContextMenuStripMain.Enabled = False
        Using dialog = New TimerSettingsDialog()
            If (owner IsNot Nothing) Then
                dialog.StartPosition = FormStartPosition.CenterParent
            Else
                dialog.StartPosition = FormStartPosition.CenterScreen
            End If
            dialog.AlarmsPath = Common.AlarmsPath
            dialog.SelectedAlarm = timeSettings.AlarmName
            dialog.AlarmEnabled = timeSettings.AlarmEnabled
            dialog.AlarmLoop = timeSettings.AlarmLoop
            dialog.AlarmVolume = timeSettings.AlarmVolume

            dialog.Duration = timeSettings.Duration
            dialog.CountUp = timeSettings.CountUp
            dialog.Restarts = timeSettings.Restarts
            dialog.Note = timeSettings.Note
            dialog.NoteEnabled = timeSettings.NoteEnabled
            dialog.ShowAlertBoxOnTimerExpiration = timeSettings.AlertEnabled
            dialog.Editing = editing
            Dim result As DialogResult = dialog.ShowDialog(owner)
            If (Not result = Windows.Forms.DialogResult.Cancel) Then
                timeSettings.Duration = dialog.Duration
                timeSettings.CountUp = dialog.CountUp
                timeSettings.Restarts = dialog.Restarts
                timeSettings.AlarmEnabled = dialog.AlarmEnabled
                timeSettings.AlarmName = dialog.SelectedAlarm
                timeSettings.AlarmLoop = dialog.AlarmLoop
                timeSettings.AlarmVolume = dialog.AlarmVolume
                timeSettings.Note = dialog.Note
                timeSettings.NoteEnabled = dialog.NoteEnabled
                timeSettings.AlertEnabled = dialog.ShowAlertBoxOnTimerExpiration
                RemoveTimerHandlers()
                Dim alarm As Alarm = Nothing
                Try
                    alarm = New Alarm(Path.Combine(Common.AlarmsPath, timeSettings.AlarmName), timeSettings.AlarmVolume, timeSettings.AlarmLoop)
                Catch ex As Exception

                End Try
                If (Not editing) Then
                    timer.Dispose()
                    timer = TimerFactory.CreateInstance(timeSettings.Duration, timeSettings.CountUp, timeSettings.Restarts, alarm, timeSettings.AlarmEnabled)
                Else
                    timer.Alarm = alarm
                    timer.AlarmEnabled = timeSettings.AlarmEnabled
                End If
                timerObject.Timer = timer
                noteObject.Text = timeSettings.Note
                HideNote()
                AddTimerHandlers()
                If result = Windows.Forms.DialogResult.Yes Then
                    SetTimerState(True)
                End If
                Me.UpdateIcons()
            End If
            ContextMenuStripMain.Enabled = True
        End Using
    End Sub

    Private Sub ShowLookDialog(owner As Form)
        ContextMenuStripMain.Enabled = False

        Using dialog As New StyleSettingsDialog
            'dialog.SaveAction = Sub(path As String)
            '                        Using output = File.OpenWrite(path)
            '                            styleSettings.Export(output)
            '                        End Using
            '                    End Sub
            'dialog.LoadAction = Sub(path As String)
            '                        Using input = File.OpenRead(path)
            '                            styleSettings.Import(input)
            '                        End Using
            '                    End Sub
            If (owner IsNot Nothing) Then
                dialog.StartPosition = FormStartPosition.CenterParent
            Else
                dialog.StartPosition = FormStartPosition.CenterScreen
            End If
            dialog.TopMost = (owner Is Nothing)
            dialog.BackgroundColor = styleSettings.BackgroundColor
            dialog.DisplayFont = styleSettings.DisplayFont
            dialog.DisplayFormats = Common.DisplayFormats
            dialog.DisplayFormat = styleSettings.DisplayFormat
            dialog.ForegroundColor = styleSettings.ForegroundColor
            dialog.Timer = timer
            dialog.GrowToFit = styleSettings.GrowToFit
            dialog.Transparency = 100 - styleSettings.Opacity
            If (dialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
                Dim timeVisible = timerObject.Visible
                timerObject.Visible = False

                Dim noteVisible = noteObject.Visible
                noteObject.Visible = False

                styleSettings.BackgroundColor = dialog.BackgroundColor
                styleSettings.DisplayFormat = dialog.DisplayFormat
                styleSettings.DisplayFont = dialog.DisplayFont
                styleSettings.ForegroundColor = dialog.ForegroundColor
                styleSettings.GrowToFit = dialog.GrowToFit
                styleSettings.Opacity = 100 - dialog.Transparency


                timerSurface.BackColor = styleSettings.BackgroundColor
                timerObject.Color = styleSettings.ForegroundColor
                timerObject.Font = styleSettings.DisplayFont
                timerObject.Format = styleSettings.DisplayFormat
                timerObject.SizeToFit = styleSettings.GrowToFit


                noteObject.Color = styleSettings.ForegroundColor
                noteObject.Font = styleSettings.DisplayFont
                noteObject.SizeToFit = styleSettings.GrowToFit

                timerObject.Visible = timeVisible
                noteObject.Visible = noteVisible

                Me.Opacity = styleSettings.Opacity / 100
            End If

        End Using
        ContextMenuStripMain.Enabled = True
    End Sub

    Private Sub ShowSettingsDialog(owner As Form)
        If (owner IsNot Nothing) Then
            SettingsDialog.StartPosition = FormStartPosition.CenterParent
        Else
            SettingsDialog.StartPosition = FormStartPosition.CenterScreen
        End If
        SettingsDialog.TopMost = (owner Is Nothing)

        ContextMenuStripMain.Enabled = False
        Try
            SettingsDialog.ShowDialog(owner)
        Catch ex As Exception
            MessageBox.Show(ex.InnerException.ToString)
        End Try
        NotifyIconMain.Visible = My.Settings.ShowInSystemTray
        ContextMenuStripMain.Enabled = True
    End Sub

    Private Sub ShowTaskDialog(owner As Form)
        Using tasksDialog As New TaskSettingsDialog
            If (owner IsNot Nothing) Then
                tasksDialog.StartPosition = FormStartPosition.CenterParent
            Else
                tasksDialog.StartPosition = FormStartPosition.CenterScreen
            End If

            ' DialogTaskSettings.TopMost = True
            tasksDialog.Tasks = taskSettings.Tasks
            If (Not tasksDialog.ShowDialog(owner) = Windows.Forms.DialogResult.OK) Then
                taskSettings.Reload()
            End If
        End Using
    End Sub
    Private Sub ExitApplication()
        forceClose = True
        Me.Close()
    End Sub

    Private Sub SaveSettings()
        ' Save setting files
        Try
            styleSettings.Save()
            timeSettings.Save()
            taskSettings.Save()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
            If MessageBox.Show("Elan Timer failed to save one or more settings files. Would you like to try again? If you select ""No,"" Some changes since you last ran Elan Timer will be lost.", My.Application.Info.AssemblyName, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                SaveSettings()
            End If
        End Try
    End Sub
    ' Toggles timer between paused and not paused.
    Private Sub SetTimerState(enabled As Boolean)
        Try
            If enabled Then
                timer.Start()
            Else
                timer.Pause()
            End If
            If (TaskbarManager.IsPlatformSupported) Then
                Dim progressState = If(timer.IsPaused, TaskbarProgressBarState.Paused, TaskbarProgressBarState.Normal)
                TaskbarManager.Instance.SetProgressState(progressState, Me.Handle)
            End If
        Catch ex As Exception
            Throw ex
        End Try
        UpdateIcons()
    End Sub
    ' Enter or exit fullscreen.
    Private Sub GoFullscreen(fullscreen As Boolean)
        If fullscreen Then
            Me.TopMost = True
            Me.WindowState = FormWindowState.Normal
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
            Me.WindowState = FormWindowState.Normal
            Me.TopMost = My.Settings.AlwaysOnTop
            Me.CenterToScreen()
        End If
    End Sub
    Private Sub CloseToSystemTray()
        Me.Hide()
        ' timerSurface.Enabled = False
        NotifyIconMain.Visible = True
    End Sub
#End Region

    Private Sub ToolStripMenuItemAboutElanTimer_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAboutElanTimer.Click
        ' Show 'About' dialog with current form as parent.
        AboutDialog.ShowDialog(Me)
    End Sub

    Private Sub ToolStripMenuItemNewTimer_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemNewTimer.Click
        ' Show 'New Timer' dialog.
        ShowTimerDialog(Me, False)
    End Sub

    Private Sub ToolStripButtonNewTimer_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNewTimer.Click
        ' Show 'New Timer' dialog.
        ShowTimerDialog(Me, False)
    End Sub

    Private Sub ToolStripMenuItemEditTimer_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEditTimer.Click
        ' Show 'Edit Timer' dialog.
        ShowTimerDialog(Me, True)
    End Sub

    Private Sub NotifyIconMain_Click(sender As Object, e As EventArgs) Handles NotifyIconMain.Click
        ' If the icon is shown in the system tray and clicking the icon should turn the alarm off...
        If (My.Settings.ShowInSystemTray And My.Settings.ClickingTrayIconStopsAlarm And timerObject.Timer.IsExpired) Then
            Try
                ' Try to stop the alarm. 
                CType(timerObject.Timer, CodeIsle.Timers.AlarmTimer).Alarm.Stop()
            Catch ex As Exception
                ' If the alarm is null, catch the error and ignore.
            End Try
        End If
    End Sub


    Private Sub NotifyIconMain_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIconMain.MouseDoubleClick
        Me.Show()
    End Sub

    Private Sub NotifyIconToolStripMenuItemNewTimer_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemNewTimer.Click
        ' Show 'New Timer' dialog.
        ShowTimerDialog(Nothing, False)
    End Sub

    Private Sub NotifyIconToolStripMenuItemEditTimer_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemEditTimer.Click
        ' Show 'Edit Timer' dialog.
        ShowTimerDialog(Nothing, True)
    End Sub

    Private Sub NotifyIconToolStripMenuItemStartTimer_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemStartTimer.Click
        ' Set timer state to the opposite of its current state (toggle start/pause). 
        SetTimerState(Not timer.Enabled)
    End Sub


    Private Sub NotifyIconToolStripMenuItemTasks_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemTasks.Click
        ' Show the task dialog with current form as parent.
        ContextMenuStripMain.Enabled = False
        ShowTaskDialog(Nothing)
        ContextMenuStripMain.Enabled = True
    End Sub

    Private Sub NotifyIconToolStripMenuItemStyle_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemStyle.Click
        ' Show the Look Dialog.
        ShowLookDialog(Nothing)
    End Sub

    Private Sub NotifyIconToolStripMenuItemExit_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemExit.Click
        ' Exit the application, forcing it to close.
        ExitApplication()
    End Sub

    Private Sub ToolNotifyIconStripMenuItemResetTimer_Click(sender As Object, e As EventArgs) Handles ToolNotifyIconStripMenuItemResetTimer.Click
        ' Reset the timer.
        ResetTimer()
    End Sub

    Private Sub NotifyIconToolStripMenuItemShow_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemShow.Click
        Me.Show()
    End Sub

    Private Sub NotifyIconToolStripMenuItemSettings_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemSettings.Click
        ' Show the Settings dialog.
        ShowSettingsDialog(Nothing)
    End Sub

    Private Sub FormMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If (timerObject IsNot Nothing) Then timerObject.Rectangle = timerSurface.ClientRectangle
        If (noteObject IsNot Nothing) Then noteObject.Rectangle = timerSurface.ClientRectangle
    End Sub
End Class