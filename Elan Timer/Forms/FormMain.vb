Imports Microsoft.WindowsAPICodePack.Taskbar
Imports System.Threading
Imports System.Text
Imports ElanTimer.Prefs
Public Class FormMain
    Public updateCancellationTokenSource As System.Threading.CancellationTokenSource
    Public timerSurface As Rendering.Surface

    Private ReadOnly EscapeKeyChar = Convert.ToChar(27)

    Private timerObject As TimerTextRenderObject
    Private noteObject As TextRenderObject
    Private stringFormat As New StringFormat
    Private renderer As Rendering.IRenderer
    Private forceClose As Boolean = False
#If DEBUG Then
    Private sw As New Stopwatch ' Used for benchmark and testing.
#End If

    Public timer As CodeIsle.Timers.AlarmTimer

#Region "Timer Event Handelers"
    Public Sub Timer_Started(sender As Object, e As TimerEventArgs)
        ' sw.Start()
        ExecuteActions(Prefs.Models.TimerEvent.Started)
    End Sub
    Public Sub Timer_Paused(sender As Object, e As TimerEventArgs)
        ExecuteActions(Prefs.Models.TimerEvent.Paused)
    End Sub
    Public Sub Timer_Restarted(sender As Object, e As TimerEventArgs)
        ExecuteActions(Prefs.Models.TimerEvent.Restarted)
        HideNote()
    End Sub
    Public Sub Timer_Expired(sender As Object, e As TimerEventArgs)
        ' sw.Stop()
        ' MessageBox.Show(sw.Elapsed.TotalMilliseconds)
        ExecuteActions(Prefs.Models.TimerEvent.Expired)
        ShowNote()
        TryShowNoteAlert()
    End Sub
    Public Sub ExecuteActions(e As Prefs.Models.TimerEvent)
        TaskEx.Run(Sub()

                       Dim actions = From action In Preferences.Tasks.Tasks
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
        ' Dispose of the application mutex.
        Common.ApplicationMutex.Dispose()
    End Sub

    Private Sub ConfigureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DialogSettings.ShowDialog()
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
        ' Load the localization language.
        LoadLanguage()

        ' Load settings.
        LoadSettings()

        ' Create a new alarm initialized to Nothing.
        Dim alarm As Alarm = Nothing

        ' Try to assign alarm to a new Alarm object.
        Try
            alarm = New Alarm(Common.GetAlarmPath(Preferences.Time.AlarmPath), Preferences.Time.AlarmVolume, Preferences.Time.AlarmLoop)
        Catch ex As Exception

        End Try

        ' Create a new timer object.
        timer = TimerFactory.CreateInstance(Preferences.Time.Duration, Preferences.Time.CountUp, Preferences.Time.Restarts, alarm, Preferences.Time.AlarmEnabled)

        ' Start rendering.
        StartUpRendering(timer)
        ' Add event handlers for the timer.
        AddTimerHandlers()
        ' Add handler for UpdateUI
        AddHandler Application.Idle, AddressOf UpdateUI
    End Sub
    Private Sub ToolStripMenuItemSettings_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSettings.Click
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
                                 If (Preferences.Time.HasNote And Preferences.Time.HasNoteAlert) Then
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

        timerObject = New TimerTextRenderObject(timer, Preferences.Style.Font, Preferences.Style.DisplayFormat, New TimeFormat, Preferences.Style.GrowToFit, Preferences.Style.ForegroundColor, stringFormat, True)
        noteObject = New TextRenderObject(Preferences.Time.Note, Preferences.Style.Font, Preferences.Style.GrowToFit, Preferences.Style.ForegroundColor, stringFormat, False)
        Dim objects As New List(Of IRenderObject)

        objects.Add(timerObject)
        objects.Add(noteObject)

        renderer = New Renderer(objects)
        timerSurface = Rendering.SurfaceFactory.CreateInstance(renderer, Common.Framerate)
        timerSurface.BackColor = Color.Transparent
        AddHandler timerSurface.DoubleClick, AddressOf TimerSurface_DoubleClick
        AddHandler timerSurface.Click, AddressOf TimerSurface_Click

        timerSurface.BackColor = Preferences.Style.BackgroundColor

        timerSurface.Dock = DockStyle.Fill
        PanelTimer.Controls.Add(timerSurface)

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

    Private Async Function FormMainProgressUpdateAsync(token As System.Threading.CancellationToken) As Task
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
                                                If (Not Preferences.Time.Note = String.Empty) Then
                                                    sb.Append(" - ")
                                                End If
                                            End If
                                            If (Preferences.Time.HasNote) Then
                                                sb.Append(Preferences.Time.Note)
                                            End If

                                            If (sb.Length = 0) Then
                                                sb.Append(assemblyName)
                                            End If

                                            Me.Text = sb.ToString
                                            NotifyIconMain.Text = LimitTextLength(Me.Text, 63)

                                            Await TaskEx.Delay(Common.Framerate)
                                        End While
                                    End Function, token, TaskCreationOptions.LongRunning, TaskScheduler.FromCurrentSynchronizationContext)
    End Function
    ' Update the button icons for paused/not paused.
    Private Sub UpdateIcons()
        ToolStripButtonStartPause.Image = If(timer.IsPaused, My.Resources.play_green, My.Resources.pause_green)
    End Sub
    ' Update the form user interface.
    Private Sub UpdateUI()
        ToolStripButtonStartPause.Enabled = Not timer.IsExpired
        NotifyIconToolStripMenuItemStartTimer.Enabled = ToolStripButtonStartPause.Enabled
        ToolStripButtonStartPause.Text = If(timer.IsPaused, My.Resources.Strings.Start, My.Resources.Strings.Pause)
        NotifyIconToolStripMenuItemStartTimer.Text = ToolStripButtonStartPause.Text
        Me.Opacity = Preferences.Style.Opacity / 100
    End Sub

    Private Sub LoadSettings()

        Try
            Dim args = My.Application.CommandLineArgs
            If args.Count > 0 Then
                Dim pref = args(0)
                If (System.IO.File.Exists(pref)) Then

                    Select Case System.IO.Path.GetExtension(pref)

                        Case My.Settings.StyleFileExtension
                            Preferences.Style.ImportFrom(pref)
                        Case My.Settings.TaskFileExtension
                            Preferences.Tasks.ImportFrom(pref)
                        Case My.Settings.TimeFileExtension
                            Preferences.Time.ImportFrom(pref)
                    End Select

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
        If (owner IsNot Nothing) Then
            DialogTimerSettings.StartPosition = FormStartPosition.CenterParent
        Else
            DialogTimerSettings.StartPosition = FormStartPosition.CenterScreen
        End If
        ContextMenuStripMain.Enabled = False
        DialogTimerSettings.Editing = editing
        If (DialogTimerSettings.ShowDialog(owner) = Windows.Forms.DialogResult.OK) Then
            RemoveTimerHandlers()
            Dim alarm As Alarm = Nothing
            Try
                alarm = New Alarm(Common.GetAlarmPath(Preferences.Time.AlarmPath), Preferences.Time.AlarmVolume, Preferences.Time.AlarmLoop)
            Catch ex As Exception

            End Try
            If (Not editing) Then
                timer.Dispose()
                timer = TimerFactory.CreateInstance(Preferences.Time.Duration, Preferences.Time.CountUp, Preferences.Time.Restarts, alarm, Preferences.Time.AlarmEnabled)
            Else
                timer.Alarm = alarm
                timer.AlarmEnabled = Preferences.Time.AlarmEnabled
            End If
            timerObject.Timer = timer
            noteObject.Text = Preferences.Time.Note
            HideNote()
            AddTimerHandlers()
            If Preferences.Time.StartImmediately Then
                SetTimerState(True)
            End If
            Me.UpdateIcons()
        End If
        ContextMenuStripMain.Enabled = True
    End Sub

    Private Sub ShowLookDialog(owner As Form)
        If (owner IsNot Nothing) Then
            DialogStyleSettings.StartPosition = FormStartPosition.CenterParent
        Else
            DialogStyleSettings.StartPosition = FormStartPosition.CenterScreen
        End If
        DialogStyleSettings.TopMost = (owner Is Nothing)

        ContextMenuStripMain.Enabled = False
        Try
            DialogStyleSettings.ShowDialog(Me)

            ' Reassign various style values for the timer rendering.
            Dim timeVisible = timerObject.Visible
            timerObject.Visible = False

            Dim noteVisible = noteObject.Visible
            noteObject.Visible = False

            timerSurface.BackColor = Preferences.Style.BackgroundColor
            timerObject.Color = Preferences.Style.ForegroundColor
            timerObject.Font = Preferences.Style.Font
            timerObject.Format = Preferences.Style.DisplayFormat
            timerObject.SizeToFit = Preferences.Style.GrowToFit


            noteObject.Color = Preferences.Style.ForegroundColor
            noteObject.Font = Preferences.Style.Font
            noteObject.SizeToFit = Preferences.Style.GrowToFit

            timerObject.Visible = timeVisible
            noteObject.Visible = noteVisible

        Catch ex As Exception

        End Try
        ContextMenuStripMain.Enabled = True
    End Sub

    Private Sub ShowSettingsDialog(owner As Form)
        If (owner IsNot Nothing) Then
            DialogSettings.StartPosition = FormStartPosition.CenterParent
        Else
            DialogSettings.StartPosition = FormStartPosition.CenterScreen
        End If
        DialogSettings.TopMost = (owner Is Nothing)

        ContextMenuStripMain.Enabled = False
        Try
            DialogSettings.ShowDialog(owner)
        Catch ex As Exception
            MessageBox.Show(ex.InnerException.ToString)
        End Try
        NotifyIconMain.Visible = My.Settings.ShowInSystemTray
        ContextMenuStripMain.Enabled = True
    End Sub

    Private Sub ShowTaskDialog(owner As Form)
        If (owner IsNot Nothing) Then
            DialogTaskSettings.StartPosition = FormStartPosition.CenterParent
        Else
            DialogTaskSettings.StartPosition = FormStartPosition.CenterScreen
        End If
        DialogTaskSettings.TopMost = (owner Is Nothing)
        DialogTaskSettings.ShowDialog(owner)
    End Sub
    Private Sub ExitApplication()
        forceClose = True
        Me.Close()
    End Sub

    Private Sub SaveSettings()
        ' Save setting files
        Try
            Preferences.Style.Save()
            Preferences.Time.Save()
            Preferences.Tasks.Save()
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
        DialogAbout.ShowDialog(Me)
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
End Class