Imports Microsoft.WindowsAPICodePack.Taskbar
Imports System.Threading
Imports System.Text
Imports System.IO

Imports ElanTimer.Prefs
Imports ElanTimer.Settings
Imports ElanTimer.Rendering
Imports Microsoft

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
    Private timeSettings As TimeSettings = New TimeSettings(transporter)
    Private taskSettings As TaskSettings = New TaskSettings(transporter)
    Private styleSettings As StyleSettings = New StyleSettings(transporter)

    Private alarm As Alarm

    Private reporter As IProgress(Of Integer)
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
        StopRendering()
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
            If (My.Application.CommandLineArgs.Count = 1) Then
                LoadSettings(My.Application.CommandLineArgs(0))
            End If

            Try
                timeSettings.AlarmName = If(String.IsNullOrEmpty(timeSettings.AlarmName) OrElse Not File.Exists(Utils.GetAlarmFullPath(timeSettings.AlarmName)), Utils.GetDefaultAlarm(), timeSettings.AlarmName)
            Catch ex As Exception

            End Try

            If (TaskbarManager.IsPlatformSupported) Then
                reporter = New Progress(Of Integer)(Sub(progress)
                                                        TaskbarManager.Instance.SetProgressValue(progress, 1000, Me.Handle)
                                                    End Sub)
            Else
                reporter = New Progress(Of Integer)()
            End If

            InitializeAlarm()

            InitializeTimer()

            ' Start rendering.
            StartRendering()

            ToolStripMain.Select()

            ' Add handler for UpdateUI
            AddHandler Application.Idle, AddressOf UpdateUI
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Sub InitializeAlarm()
        ' Try to assign alarm to a new Alarm object.
        Try
            If (alarm IsNot Nothing) Then
                alarm.Dispose()
            End If
            alarm = New Alarm(Utils.GetAlarmFullPath(timeSettings.AlarmName), timeSettings.AlarmVolume, timeSettings.AlarmLoop)
        Catch ex As FileNotFoundException

        End Try
    End Sub
    Sub InitializeTimer()
        If (timer IsNot Nothing) Then
            RemoveTimerHandlers()
            timer.Dispose()
        End If
        ' Create a new timer object.
        timer = TimerFactory.CreateInstance(timeSettings.Duration, timeSettings.CountUp, timeSettings.Restarts, alarm, timeSettings.AlarmEnabled)
        ' Add event handlers for the timer.
        AddTimerHandlers()
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
        EnterFullscreen(My.Settings.WindowFullScreen)
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
            EnterFullscreen(My.Settings.WindowFullScreen)
            Me.Focus()
        End If
    End Sub
#End Region



#Region "Helper Methods"
    ' Shuts down rendering of the timer.
    Private Sub StopRendering()
        updateCancellationTokenSource.Cancel()
        Task.WaitAll()
        PanelTimer.Controls.Clear()

        timerSurface.Dispose()

        Task.WaitAll()
    End Sub
    ' Starts up rendering of the timer.
    Private Async Sub StartRendering()
        updateCancellationTokenSource = New System.Threading.CancellationTokenSource

        stringFormat = New StringFormat(System.Drawing.StringFormat.GenericTypographic)
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        timerObject = New TimerTextRenderable(timer, styleSettings.DisplayFont, styleSettings.DisplayFormat, New TimeFormat(), styleSettings.GrowToFit, styleSettings.ForegroundColor, stringFormat, True)
        noteObject = New TextRenderable(timeSettings.Note, styleSettings.DisplayFont, styleSettings.GrowToFit, styleSettings.ForegroundColor, stringFormat, False)


        timerSurface = New Surface()
        timerSurface.BackColor = styleSettings.BackgroundColor

        SetColoredToolStrip(My.Settings.BlendToolbarColorWithBackground)



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
    Sub RestartRendering()
        StopRendering()
        StartRendering()
    End Sub

    Private Sub SetColoredToolStrip(enabled As Boolean)
        If (enabled) Then
            ToolStripMain.BackColor = styleSettings.BackgroundColor
            ToolStripMain.Renderer = New BorderlessToolStripSystemRenderer()
        Else
            ToolStripMain.BackColor = ToolStrip.DefaultBackColor
            ToolStripMain.Renderer = New ToolStripProfessionalRenderer()
        End If
    End Sub
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
    Private Sub TryShowNoteAlert()
        Me.Invoke(New Action(Sub()
                                 If (timeSettings.NoteEnabled And timeSettings.AlertEnabled) Then
                                     MessageBox.Show(Me, If(noteObject.Text = String.Empty, My.Resources.Strings.TimerHasExpired, noteObject.Text), My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                 End If
                             End Sub))

    End Sub
    ' Load the language settings.
    Private Sub LoadLanguage()
        Try
            ' Try to set UI culture to the language fronm settings.
            Utils.Languages.SetLanguage(My.Settings.Language)
        Catch ex As Exception
            ' On failure, revert to the default language.
            My.Settings.Language = My.Settings.DefaultLanguage
        End Try
        ' Set localization text.
        Utils.SetStrings()
    End Sub
    ' Exits fullscreen mode.
    Private Sub ExitFullScreen()
        '  If in fullscreen mode...
        If My.Settings.WindowFullScreen Then
            ' Exit fullscreen mode.
            My.Settings.WindowFullScreen = False
            My.Settings.WindowMaximized = False
            EnterFullscreen(My.Settings.WindowFullScreen)
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
#If DEBUG Then
    Private Sub Started(sender As Object, e As TimerEventArgs)
        sw.Start()
    End Sub
#End If
#If DEBUG Then
    Private Sub Stopped(sender As Object, e As TimerEventArgs)
        sw.Stop()
    End Sub
#End If


    Private Async Function FormMainProgressUpdateAsync(token As System.Threading.CancellationToken) As Task(Of TaskModel)
        Try
            Await Task.Factory.StartNew(Async Function()
                                            While (Not token.IsCancellationRequested)
                                                Dim currentProgressValue As Long
                                                currentProgressValue = (timer.Elapsed.TotalMilliseconds / timer.Duration.TotalMilliseconds) * 1000

                                                reporter.Report(currentProgressValue)

                                                ProgressBarMain.Invoke(New Action(Sub()
                                                                                      ProgressBarMain.Value = currentProgressValue
                                                                                  End Sub)
                                                )
                                                Me.Invoke(New Action(Sub()
                                                                         UpdateWindowText()
                                                                         NotifyIconMain.Text = Utils.LimitTextLength(Me.Text, 63)
                                                                     End Sub))
                                                Await TaskEx.Delay(renderer.FramesPerSecond)
                                            End While
                                        End Function, token, TaskCreationOptions.LongRunning, TaskScheduler.FromCurrentSynchronizationContext)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    Private Sub UpdateWindowText()
        Dim time As String = If(Not timer.IsExpired, timerObject.Text, String.Empty)
        Dim separator As String = If(Not timer.IsExpired AndAlso timeSettings.NoteEnabled, " - ", String.Empty)
        Dim note As String = If(timeSettings.NoteEnabled, timeSettings.Note, String.Empty)
        Dim title As String = If(time.Length = 0 And separator.Length = 0 And note.Length = 0, My.Application.Info.AssemblyName, String.Empty)

        Me.Text = String.Join("", time, separator, note, title)
    End Sub
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

    Private Sub LoadSettings(fileName As String)
        Try
            If (System.IO.File.Exists(fileName)) Then
                Using stream As FileStream = File.OpenRead(fileName)
                    Select Case System.IO.Path.GetExtension(fileName)
                        Case My.Settings.StyleFileExtension
                            styleSettings.Import(stream)
                        Case My.Settings.TaskFileExtension
                            Dim settings As New TaskSettings(transporter)
                            settings.Import(stream)
                            settings.Tasks.ForEach(Sub(i) i.Enabled = False)
                            taskSettings.Tasks.AddRange(settings.Tasks)
                            MessageBox.Show("Tasks were imported, but were disabled for safety.", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Case My.Settings.TimeFileExtension
                            timeSettings.Import(stream)
                            RemoveTimerHandlers()
                            Dim alarm As Alarm = Nothing
                            Try
                                alarm = New Alarm(Utils.GetAlarmFullPath(timeSettings.AlarmName), timeSettings.AlarmVolume, timeSettings.AlarmLoop)
                            Catch ex As Exception

                            End Try
                            InitializeAlarm()
                            InitializeTimer()
                    End Select
                    RestartRendering()
                End Using

            End If
        Catch ex As Exception

        End Try


        ' Fixes taskbar showing issue.
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = True


        Me.ToolStripMenuItemAlwaysOnTop.Checked = My.Settings.AlwaysOnTop
        Me.TopMost = Me.ToolStripMenuItemAlwaysOnTop.Checked

        Me.Size = My.Settings.WindowSize
        If My.Settings.WindowMaximized Then
            Me.WindowState = FormWindowState.Maximized
        End If
        If My.Settings.WindowFullScreen Then
            EnterFullscreen(True)
        End If

        Me.ToolStripButtonReset.Text = My.Resources.Strings.Reset

        NotifyIconMain.Visible = My.Settings.ShowInSystemTray
        ' Get rid of selection on toolstrip.
        Me.Focus()
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
    Private Sub ResetTimer()
        timer.Reset()
        HideNote()
        UpdateIcons()
    End Sub
    ' Enter or exit fullscreen.
    Private Sub EnterFullscreen(fullscreen As Boolean)
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
#Region "Dialogs"
    ' Shows the 'New Timer' or 'Edit Timer' dialogs.
    Public Sub ShowTimerDialog(owner As System.Windows.Forms.IWin32Window, editing As Boolean)
        ContextMenuStripMain.Enabled = False
        Using dialog = New TimerSettingsDialog()
            AddHandler dialog.Loading, AddressOf TimerSettingsDialog_Loading
            AddHandler dialog.Saving, AddressOf TimerSettingsDialog_Saving
            If (owner IsNot Nothing) Then
                dialog.StartPosition = FormStartPosition.CenterParent
            Else
                dialog.StartPosition = FormStartPosition.CenterScreen
            End If
            dialog.FileFilter = My.Settings.TimeDialogFilter
            Try
                dialog.InitialDirectory = Utils.GetTimersPath()
                dialog.AlarmsPath = Utils.GetAlarmsPath()
            Catch ex As DirectoryNotFoundException

            End Try
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

                InitializeAlarm()

                If (Not editing) Then
                    InitializeTimer()
                    RestartRendering()
                End If

                If result = Windows.Forms.DialogResult.Yes Then
                    SetTimerState(True)
                End If
                Me.UpdateIcons()
            End If
            ContextMenuStripMain.Enabled = True

            RemoveHandler dialog.Loading, AddressOf TimerSettingsDialog_Loading
            RemoveHandler dialog.Saving, AddressOf TimerSettingsDialog_Saving
        End Using
    End Sub

    Private Sub ShowLookDialog(owner As Form)
        ContextMenuStripMain.Enabled = False

        Using dialog As New StyleSettingsDialog
            AddHandler dialog.Loading, AddressOf StyleSettingsDialog_Loading
            AddHandler dialog.Saving, AddressOf StyleSettingsDialog_Saving
            If (owner IsNot Nothing) Then
                dialog.StartPosition = FormStartPosition.CenterParent
            Else
                dialog.StartPosition = FormStartPosition.CenterScreen
            End If
            dialog.TopMost = (owner Is Nothing)
            dialog.BackgroundColor = styleSettings.BackgroundColor
            dialog.DisplayFont = styleSettings.DisplayFont
            dialog.DisplayFormats = Utils.DisplayFormats
            dialog.DisplayFormat = styleSettings.DisplayFormat
            dialog.ForegroundColor = styleSettings.ForegroundColor
            dialog.Timer = timer
            dialog.GrowToFit = styleSettings.GrowToFit
            dialog.Transparency = 100 - styleSettings.Opacity
            dialog.InitialDirectory = Utils.GetStylesPath()
            dialog.FileFilter = My.Settings.StyleDialogFilter
            dialog.CustomForegroundColors = If(My.Settings.CustomForegroundColors IsNot Nothing, My.Settings.CustomForegroundColors.Cast(Of String)().ToList().ConvertAll(Function(c)
                                                                                                                                                                              Return Convert.ToInt32(c)
                                                                                                                                                                          End Function).ToArray(), Nothing)
            dialog.CustomBackgroundColors = If(My.Settings.CustomBackgroundColors IsNot Nothing, My.Settings.CustomBackgroundColors.Cast(Of String)().ToList().ConvertAll(Function(c)
                                                                                                                                                                              Return Convert.ToInt32(c)
                                                                                                                                                                          End Function).ToArray(), Nothing)
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


                Dim customColors = New System.Collections.Specialized.StringCollection()
                customColors.AddRange(dialog.CustomForegroundColors.ToList().ConvertAll(Function(c)
                                                                                            Return c.ToString()
                                                                                        End Function).ToArray())
                My.Settings.CustomForegroundColors = customColors

                customColors = New System.Collections.Specialized.StringCollection()
                customColors.AddRange(dialog.CustomBackgroundColors.ToList().ConvertAll(Function(c)
                                                                                            Return c.ToString()
                                                                                        End Function).ToArray())
                My.Settings.CustomBackgroundColors = customColors


                timerSurface.BackColor = styleSettings.BackgroundColor

                SetColoredToolStrip(My.Settings.BlendToolbarColorWithBackground)

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

            RemoveHandler dialog.Loading, AddressOf StyleSettingsDialog_Loading
            RemoveHandler dialog.Saving, AddressOf StyleSettingsDialog_Saving
        End Using
        ContextMenuStripMain.Enabled = True
    End Sub

    Private Sub ShowSettingsDialog(owner As Form)
        If (owner IsNot Nothing) Then
            SettingsDialog.StartPosition = FormStartPosition.CenterParent
        Else
            SettingsDialog.StartPosition = FormStartPosition.CenterScreen
        End If
        SettingsDialog.TopMost = (owner Is Nothing Or owner.TopLevel)

        ContextMenuStripMain.Enabled = False
        Try
            SettingsDialog.ShowDialog(owner)
        Catch ex As Exception
            MessageBox.Show(ex.InnerException.ToString)
        End Try
        NotifyIconMain.Visible = My.Settings.ShowInSystemTray
        ContextMenuStripMain.Enabled = True

        SetColoredToolStrip(My.Settings.BlendToolbarColorWithBackground)
    End Sub

    Private Sub ShowTaskDialog(owner As Form)
        Using dialog As New TaskSettingsDialog
            AddHandler dialog.Importing, AddressOf TaskSettingsDialog_Importing
            AddHandler dialog.Exporting, AddressOf TaskSettingsDialog_Exporting
            If (owner IsNot Nothing) Then
                dialog.StartPosition = FormStartPosition.CenterParent
            Else
                dialog.StartPosition = FormStartPosition.CenterScreen
            End If

            dialog.InitialDirectory = Utils.GetDataPath()
            dialog.FileFilter = My.Settings.TaskDialogFilter
            dialog.Tasks = taskSettings.Tasks.ConvertAll(Of TaskModel)(Function(t)
                                                                           Return New TaskModel(t.Event, t.Name, t.Command, t.Arguments, t.UseScript, t.Script, t.Enabled)
                                                                       End Function)
            If (dialog.ShowDialog(owner) = Windows.Forms.DialogResult.OK) Then
                taskSettings.Tasks = dialog.Tasks
            End If
            RemoveHandler dialog.Importing, AddressOf TaskSettingsDialog_Importing
            RemoveHandler dialog.Exporting, AddressOf TaskSettingsDialog_Exporting
        End Using
    End Sub
    Private Sub ExitApplication()
        forceClose = True
        Me.Close()
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

    Private Sub TimerSettingsDialog_Saving(sender As Object, e As SavingEventArgs)
        Try
            Dim dialog As TimerSettingsDialog = sender
            Dim settings As New TimeSettings(transporter)
            Using output As Stream = File.OpenWrite(e.Output)
                settings.Duration = dialog.Duration
                settings.CountUp = dialog.CountUp
                settings.Restarts = dialog.Restarts
                settings.AlarmEnabled = dialog.AlarmEnabled
                settings.AlarmName = dialog.SelectedAlarm
                settings.AlarmLoop = dialog.AlarmLoop
                settings.AlarmVolume = dialog.AlarmVolume
                settings.Note = dialog.Note
                settings.NoteEnabled = dialog.NoteEnabled
                settings.AlertEnabled = dialog.ShowAlertBoxOnTimerExpiration

                settings.Export(output)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TimerSettingsDialog_Loading(sender As Object, e As LoadingEventArgs)
        Try
            Dim dialog As TimerSettingsDialog = sender
            Dim settings As New TimeSettings(transporter)
            Using input As Stream = File.OpenRead(e.Input)
                settings.Import(input)

                dialog.AlarmsPath = Utils.GetAlarmsPath
                dialog.SelectedAlarm = settings.AlarmName
                dialog.AlarmEnabled = settings.AlarmEnabled
                dialog.AlarmLoop = settings.AlarmLoop
                dialog.AlarmVolume = settings.AlarmVolume

                dialog.Duration = settings.Duration
                dialog.CountUp = settings.CountUp
                dialog.Restarts = settings.Restarts
                dialog.Note = settings.Note
                dialog.NoteEnabled = settings.NoteEnabled
                dialog.ShowAlertBoxOnTimerExpiration = settings.AlertEnabled

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StyleSettingsDialog_Loading(sender As Object, e As LoadingEventArgs)
        Try
            Dim dialog As StyleSettingsDialog = sender
            Dim settings As New StyleSettings(transporter)
            Using input As Stream = File.OpenRead(e.Input)
                settings.Import(input)

                dialog.BackgroundColor = settings.BackgroundColor
                dialog.DisplayFont = settings.DisplayFont
                dialog.DisplayFormats = Utils.DisplayFormats
                dialog.DisplayFormat = settings.DisplayFormat
                dialog.ForegroundColor = settings.ForegroundColor
                dialog.Timer = timer
                dialog.GrowToFit = settings.GrowToFit
                dialog.Transparency = 100 - settings.Opacity
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StyleSettingsDialog_Saving(sender As Object, e As SavingEventArgs)
        Try
            Dim dialog As StyleSettingsDialog = sender
            Dim settings As New StyleSettings(transporter)
            Using output As Stream = File.OpenWrite(e.Output)
                settings.BackgroundColor = dialog.BackgroundColor
                settings.DisplayFormat = dialog.DisplayFormat
                settings.DisplayFont = dialog.DisplayFont
                settings.ForegroundColor = dialog.ForegroundColor
                settings.GrowToFit = dialog.GrowToFit
                settings.Opacity = 100 - dialog.Transparency

                settings.Export(output)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TaskSettingsDialog_Importing(sender As Object, e As TaskImportingEventArgs)
        Try
            Dim dialog As TaskSettingsDialog = sender
            Dim settings As New TaskSettings(transporter)

            Using input As Stream = File.OpenRead(e.Input)
                settings.Import(input)
                dialog.Tasks.AddRange(settings.Tasks)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TaskSettingsDialog_Exporting(sender As Object, e As TaskExportingEventArgs)
        Try
            Dim dialog As TaskSettingsDialog = sender
            Dim settings As New TaskSettings(transporter)
            Using output As Stream = File.OpenWrite(e.Output)
                settings.Tasks = e.Tasks.Tasks
                settings.Export(output)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FormMain_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop

        Try
            Dim data As Array = DirectCast(e.Data.GetData(DataFormats.FileDrop), Array)
            If (data IsNot Nothing) Then
                Dim file = data.GetValue(0).ToString()

                Me.BeginInvoke(DirectCast(Function(value As String)
                                              LoadSettings(value)
                                          End Function, Action(Of String)), New Object() {file})

                Me.Activate()

            End If
        Catch generatedExceptionName As Exception
        End Try
    End Sub

    Private Sub FormMain_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
End Class