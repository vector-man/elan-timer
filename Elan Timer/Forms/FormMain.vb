Imports Microsoft.WindowsAPICodePack.Taskbar
Imports System.Threading
Imports System.Text
Imports System.IO
Imports ElanTimer.CodeIsle.Timers
Imports ElanTimer.Settings
Imports ElanTimer.Rendering
Imports Microsoft
Imports NLog
Imports System.Collections.Specialized
Imports PSTaskDialog
Public Class FormMain
    ' Token source for cancelling rendering.
    Public updateCancellationTokenSource As System.Threading.CancellationTokenSource
    ' Rendering surface for timer.
    Public timerSurface As Surface
    ' Renderer for timer.
    Private renderer As Renderer
    ' The timer object to render.
    Private timerObject As TimerTextRenderable
    ' The note object to render.
    Private noteObject As TextRenderable
    ' String format for rendering text.
    Private stringFormat As New StringFormat
    ' Prefix to display on timer when counting up.
    Private Const CountUpPrefix As String = "+"
    ' Used for importing or exporting data (in JSON format.)
    Private transporter As ITransporter = New JsonNetTransporter()
    ' Settings object for timer.
    Private timeSettings As TimeSettings = New TimeSettings(transporter)
    ' Settings object for tasks.
    Private taskSettings As TaskSettings = New TaskSettings(transporter)
    ' Settings object for styles.
    Private styleSettings As StyleSettings = New StyleSettings(transporter)
    ' Main alarm.
    Private ReadOnly alarm As New Sound()
    ' Main timer.
    Public timer As AlarmTimer
    ' Reports progress to update UI when timer is running.
    Private reporter As IProgress(Of Integer)

    Private formInitialized As Boolean = False

    ' Eascape key character (used for exiting full screen mode.)
    Private ReadOnly EscapeKeyChar = Convert.ToChar(27)

    ' Forces window to close.
    Private forceExit As Boolean = False

    Dim maximized As Boolean = False

    Dim fullScreen As Boolean = False

    Private noteEnabled As Boolean

    ' Logging.
    Private Shared logger As Logger = LogManager.GetCurrentClassLogger()

    ' Used for benchmark and testing.
#If DEBUG Then
    Private sw As New Stopwatch
#End If


#Region "Timer Event Handelers"
    Public Sub Timer_Started(sender As Object, e As TimerEventArgs)
#If DEBUG Then
        sw.Start()
        Debug.Print("Timer started.")
#End If
        ExecuteTasks(TimerEvent.Started)
    End Sub
    Public Sub Timer_Paused(sender As Object, e As TimerEventArgs)
        ExecuteTasks(TimerEvent.Paused)
    End Sub
    Public Sub Timer_Restarted(sender As Object, e As TimerEventArgs)
#If DEBUG Then
        sw.Restart()
        Debug.Print("Timer restarted.")
#End If
        ExecuteTasks(TimerEvent.Restarted)
        HideNote()
    End Sub
    Public Sub Timer_Expired(sender As Object, e As TimerEventArgs)
        ' Prints the ellapsed time in milliseconds (to check timer accuracy.)
#If DEBUG Then
        sw.Stop()
        Debug.Print("Ellapsed time (MS): {0}. Timer time (MS): {1}", sw.Elapsed.TotalMilliseconds, timer.Duration.TotalMilliseconds)
        sw.Reset()
#End If
        ' Execute tasks for the "Expired" timer event.
        ExecuteTasks(TimerEvent.Expired)
        Task.Factory.StartNew(Sub()
                                  TryShowNoteAndAlert()
                              End Sub)
    End Sub
    ' Executes tasks for a given timer event.
    Private Sub ExecuteTasks(e As TimerEvent)
        TaskEx.Run(Sub()
                       ' Get enabled tasks for the specified timer event.
                       Dim tasks = From task In taskSettings.Tasks
                                     Where task.Enabled.Equals(True) And task.Event.Equals(e)
                                     Select task
                       ' Iterate through each task sequentially, from top to bottom. 
                       For Each action In tasks
                           ' Try to start the task or silently fail.
                           Try
                               Process.Start(action.Command, action.Arguments)
                           Catch ex As Exception
                               logger.Warn(ex)
                           End Try
                       Next
                   End Sub)
    End Sub
#End Region
#Region "Form Event Handelers"
    Private Sub FormMain_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

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
        If (Not My.Settings.ShowInSystemTray) Then Return
        If (Not My.Settings.ClickingTrayIconStopsAlarm) Then Return
        If (Not timerObject.Timer.IsExpired) Then Return

        Try
            ' Try to stop the alarm. 
            Dim alarm As Sound = CType(timerObject.Timer, CodeIsle.Timers.AlarmTimer).Alarm
            If (alarm IsNot Nothing) Then
                alarm.Stop()
            End If
        Catch ex As Exception
            logger.Warn(ex)
        End Try
    End Sub


    Private Sub NotifyIconMain_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIconMain.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub NotifyIconToolStripMenuItemNewTimer_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemNewTimer.Click
        ' Show 'New Timer' dialog.
        ShowTimerDialog(Me, False)
    End Sub

    Private Sub NotifyIconToolStripMenuItemEditTimer_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemEditTimer.Click
        ' Show 'Edit Timer' dialog.
        ShowTimerDialog(Me, True)
    End Sub

    Private Sub NotifyIconToolStripMenuItemStartTimer_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemStartTimer.Click
        ' Set timer state to the opposite of its current state (toggle start/pause). 
        SetTimerState(Not timer.Enabled)
    End Sub


    Private Sub NotifyIconToolStripMenuItemTasks_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemTasks.Click
        ' Show the task dialog with current form as parent.
        ShowTaskDialog(Me)
    End Sub

    Private Sub NotifyIconToolStripMenuItemStyle_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemStyle.Click
        ' Show the Style Dialog.
        ShowStyleDialog(Me)
    End Sub

    Private Sub NotifyIconToolStripMenuItemExit_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemExit.Click
        ' Exit the application, forcing it to exit.
        forceExit = True
        ExitApplication()
    End Sub

    Private Sub ToolNotifyIconStripMenuItemResetTimer_Click(sender As Object, e As EventArgs) Handles ToolNotifyIconStripMenuItemResetTimer.Click
        ' Reset the timer.
        ResetTimer()
    End Sub

    Private Sub NotifyIconToolStripMenuItemShow_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemShow.Click
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub NotifyIconToolStripMenuItemSettings_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemSettings.Click
        ' Show the Settings dialog.
        ShowSettingsDialog(Me)
    End Sub

    Private Sub FormMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If (timerObject IsNot Nothing) Then timerObject.Rectangle = timerSurface.ClientRectangle
        If (noteObject IsNot Nothing) Then noteObject.Rectangle = timerSurface.ClientRectangle

        If (Not fullScreen) Then
            maximized = (Me.WindowState = FormWindowState.Maximized)
        End If
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
                settings.AlertEnabled = dialog.ShowAlertBoxOnTimerExpiration

                settings.Export(output)
            End Using
        Catch ex As Exception
            logger.Error(ex)
            ShowErrorMessage(String.Format("Preset could not be saved to file: ""{0}""", e.Output))
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
                dialog.ShowAlertBoxOnTimerExpiration = settings.AlertEnabled

            End Using
        Catch ex As Exception
            logger.Error(ex)
            ShowErrorMessage(String.Format("Preset could not be loaded from file: ""{0}""", e.Input))
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
            logger.Error(ex)
            ShowErrorMessage(String.Format("Style could not be loaded from file: ""{0}""", e.Input))
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
            logger.Error(ex)
            ShowErrorMessage(String.Format("Style could not be saved to file: ""{0}""", e.Output))
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
            logger.Error(ex)
            ShowErrorMessage(String.Format("Tasks could not be imported from file: ""{0}""", e.Input))
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
            logger.Error(ex)
            ShowErrorMessage(String.Format("Tasks could not be exported to file: ""{0}""", e.Output))
        End Try
    End Sub

    Private Sub FormMain_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        Try
            Dim data As Array = TryCast(e.Data.GetData(DataFormats.FileDrop), Array)
            If (data Is Nothing) Then Return

            Dim file = data.GetValue(0).ToString()

            Me.BeginInvoke(DirectCast(Sub(value As String)
                                          LoadSettings(value)
                                      End Sub, Action(Of String)), New Object() {file})
            Me.Activate()

        Catch ex As Exception
            logger.Error(ex)
        End Try
    End Sub

    Private Sub ToolStripButtonReset_Click(sender As Object, e As EventArgs) Handles ToolStripButtonReset.Click
        ' Reset the timer.
        ResetTimer()
    End Sub

    Private Sub ToolStripMenuItemAlwaysOnTop_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAlwaysOnTop.Click
        ' Toggle form to or from top most position.
        Me.TopMost = CType(sender, ToolStripMenuItem).Checked
        ' Enable or disable the "AlwaysOnTop" seting.
        My.Settings.AlwaysOnTop = Me.ToolStripMenuItemAlwaysOnTop.Checked
    End Sub

    Private Sub FormMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' If closing to system tray is enabled.
        If (Not forceExit And (My.Settings.ShowInSystemTray And My.Settings.CloseToSystemTray)) Then
            ' Cancel exiting the application.
            e.Cancel = True
            ' Close to the system tray instead.
            CloseToSystemTray()
            ' Else, close the application
        Else
            ' Stop rendering the timer display.
            StopRendering()

            ' Save application settings.
            SaveSettings()
        End If
    End Sub

    Private Sub ConfigureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Show Misc dialog.
        SettingsDialog.ShowDialog()
    End Sub

    Private Sub ToolStripMain_MouseEnter(sender As Object, e As EventArgs) Handles ToolStripMain.MouseEnter
        ' Focus the form, when mouse goes over toolstrip (used when form is always on top to regain focus.)
        Me.Focus()
    End Sub

    Private Sub FormMain_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        ' If escape key is pressed...
        If (e.KeyChar = EscapeKeyChar) Then
            ' Exit full screen mode.
            SetWindowFullScreen(False)
        End If
    End Sub
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set localized strings for this form.
        SetStrings()

        ' Try to set the alarm name. If it is not present on the system, sets the default alarm or nothing instead.
        Try
            timeSettings.AlarmName = Utils.GetAlarmNameOrDefault(timeSettings.AlarmName)
        Catch ex As Exception
            logger.Warn("No alarms could be found.", ex)
        End Try

        ' If task bar progress bar is supported, enable it.
        If (TaskbarManager.IsPlatformSupported) Then
            reporter = New Progress(Of Integer) _
                (Sub(progress)
                     TaskbarManager.Instance.SetProgressValue(progress, 1000, Me.Handle)
                 End Sub)
            ' Else, set reporter to an empty progress reporter instead (nothing will be reported.)
        Else
            reporter = New Progress(Of Integer)()
        End If

        ' If a single argument is in command line (assumed to be a file), then load settings file.
        If (My.Application.CommandLineArgs.Count = 1) Then
            LoadSettings(My.Application.CommandLineArgs(0))
        End If

        ' Initialize the alarm.
        InitializeAlarm()

        ' Initialize the timer.
        InitializeTimer()

        ' Restart rendering.
        StartRendering()
        ' Initialize the main form.
        InitializeFormMain()
        ' Get rid of the toolstrip highlight bug that occurs for some reason.
        ToolStripMain.Select()

        ' Add handler for UpdateUI.
        AddHandler Application.Idle, AddressOf UpdateUI

        formInitialized = True
    End Sub

    Private Sub ToolStripMenuItemSettings_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemMisc.Click
        ' Show the Settings dialog.
        ShowSettingsDialog(Me)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemExit.Click
        ' Exit the application, forcing it to close.
        forceExit = True
        ExitApplication()
    End Sub

    Private Sub ToolStripMenuItemStyle_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemStyle.Click
        ' Show the Look Dialog.
        ShowStyleDialog(Me)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemTasks.Click
        ' Show the task dialog with current form as parent.
        ContextMenuStripMain.Enabled = False
        ShowTaskDialog(Me)
        ContextMenuStripMain.Enabled = True
    End Sub

    Private Sub DefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDefault.Click
        SetWindowDefault()
    End Sub

    Private Sub CompactToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCompact.Click
        ' Set timer form to 'compact' size.
        SetWindowCompact()
    End Sub

    Private Sub TimerSurface_DoubleClick(sender As Object, e As EventArgs)
        ' Show timer dialog without editing ('New Timer' mode).
        ShowTimerDialog(Me, False)
    End Sub
    Private Sub TimerSurface_Click(sender As Object, e As EventArgs)
        ' Exit fullscreen mode (when the timer display area is clicked).
        If (fullScreen) Then
            SetWindowFullScreen(False)
        End If
    End Sub
    ' Toggle timer between paused/not paused.
    Private Sub ToolStripButtonStartPause_Click(sender As Object, e As EventArgs) Handles ToolStripButtonStartPause.Click
        ' Set timer state to the opposite of its current state (toggle start/pause). 
        SetTimerState(Not timer.Enabled)
    End Sub
    ' Set timer form to or from fullscreen.
    Private Sub FullScreenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemFullScreen.Click
        If (Not fullScreen) Then
            SetWindowFullScreen(True)
        End If
    End Sub
#End Region



#Region "Helper Methods"
    ' Shuts down rendering of the timer.
    Private Sub StopRendering()
        updateCancellationTokenSource.Cancel()
        Task.WaitAll()

        renderer.Dispose()

        stringFormat.Dispose()

        timerObject.Dispose()
        noteObject.Dispose()

        RemoveHandler timerSurface.DoubleClick, AddressOf TimerSurface_DoubleClick
        RemoveHandler timerSurface.Click, AddressOf TimerSurface_Click
        timerSurface.Dispose()
    End Sub
    ' Starts up rendering of the timer.
    Private Async Sub StartRendering()
        stringFormat = New StringFormat(System.Drawing.StringFormat.GenericTypographic)
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        timerObject = New TimerTextRenderable(timer, styleSettings.DisplayFont, styleSettings.DisplayFormat, New TimeFormat(), styleSettings.GrowToFit, styleSettings.ForegroundColor, stringFormat, True)
        timerObject.Prefix = If(TypeOf timer Is CountUpAlarmTimer, CountUpPrefix, String.Empty)

        noteObject = New TextRenderable(timeSettings.Note, styleSettings.DisplayFont, styleSettings.GrowToFit, styleSettings.ForegroundColor, stringFormat, False)

        ToolStripLabelNote.Text = timeSettings.Note

        timerSurface = New Surface()
        timerSurface.BackColor = styleSettings.BackgroundColor
        timerSurface.Dock = DockStyle.Fill

        AddHandler timerSurface.DoubleClick, AddressOf TimerSurface_DoubleClick
        AddHandler timerSurface.Click, AddressOf TimerSurface_Click

        PanelTimer.Controls.Add(timerSurface)

        timerObject.Rectangle = timerSurface.ClientRectangle
        noteObject.Rectangle = timerSurface.ClientRectangle

        SetToolStripStyling(My.Settings.UseToolbarStyling)

        renderer = New Renderer(timerSurface)
        renderer.Renderables.Add(timerObject)
        renderer.Renderables.Add(noteObject)
        renderer.Enabled = True

        UpdateToolbar()

        updateCancellationTokenSource = New System.Threading.CancellationTokenSource

        noteEnabled = Not String.IsNullOrWhiteSpace(timeSettings.Note)

        Await FormMainProgressUpdateAsync(updateCancellationTokenSource.Token)
    End Sub
    Sub RestartRendering()
        StopRendering()
        StartRendering()
    End Sub
    ' Enable or disable tool strip styling.
    Private Sub SetToolStripStyling(enabled As Boolean)
        If (enabled) Then
            ' Set tool strip back color.
            ToolStripMain.BackColor = styleSettings.BackgroundColor
            ' Create a new custom tool strip renderer object.
            Dim renderer = New BorderlessToolStripSystemRenderer()
            ' Set separator back color.
            renderer.SeparatorBackColor = styleSettings.ForegroundColor
            ' Set separator fore color.
            renderer.SeparatorForeColor = styleSettings.ForegroundColor
            ' Set tool strip to custom renderer.
            ToolStripMain.Renderer = renderer
            ' Else, disable tool strip styling.
        Else
            ' Set tool strip back color to default.
            ToolStripMain.BackColor = ToolStrip.DefaultBackColor
            ' Set tool strip renderer to professional.
            ToolStripMain.Renderer = New ToolStripProfessionalRenderer()
        End If
    End Sub
    ' Hide the timer note and show the time.
    Private Sub HideNote()
        ' Hide the note.
        noteObject.Visible = False
        ' Show the timer.
        timerObject.Visible = True
        ' Show note if in full screen mode.
        SetFullScreenNoteVisibility()
    End Sub
    ' Show the timer note and hide the time.
    Private Sub ShowNote()
        ' If the note text is empty, set it to "Expired."
        If (noteObject.Text = String.Empty) Then
            noteObject.Text = My.Resources.Strings.TimerHasExpired
        End If
        ' Show the note.
        noteObject.Visible = True
        ' Hide the timer.
        timerObject.Visible = False
        ' Show note if in full screen mode.
        SetFullScreenNoteVisibility()
    End Sub
    ' Attempts to show note alert (if note setting is enabled.)
    Private Sub TryShowNoteAndAlert()
        Me.Invoke(New Action(Sub()
                                 ' If note is enabled, then show it.
                                 If (noteEnabled) Then
                                     ShowNote()
                                     ' If messabe box alert is enabled, show it.
                                     If (timeSettings.AlertEnabled) Then
                                         ' If message is empty, show a default message. Else, show the note message.
                                         Dim message As String = If(noteObject.Text = String.Empty, My.Resources.Strings.TimerHasExpired, noteObject.Text)
                                         cTaskDialog.MessageBox(Me, My.Application.Info.ProductName, message, String.Format("The timer has expired at: {0}", Date.Now().ToString()), eTaskDialogButtons.OK, eSysIcons.Information)
                                     End If
                                 End If
                             End Sub))
    End Sub
    ' Sets visibility of full screen note.
    Private Sub SetFullScreenNoteVisibility()
        ' Full screen note is shown only if the timer is not expired, "Note" is enabled, and the window is full screen.
        ToolStripLabelNote.Visible = (Not timer.IsExpired AndAlso noteEnabled AndAlso fullScreen)
    End Sub
    ' Adds the event handlers for the timer.
    Private Sub AddTimerHandlers()
        AddHandler timer.Started, AddressOf Timer_Started
        AddHandler timer.Paused, AddressOf Timer_Paused
        AddHandler timer.Expired, AddressOf Timer_Expired
        AddHandler timer.Restarted, AddressOf Timer_Restarted
    End Sub
    ' Removes the event handlers for the timer.
    Private Sub RemoveTimerHandlers()
        RemoveHandler timer.Started, AddressOf Timer_Started
        RemoveHandler timer.Paused, AddressOf Timer_Paused
        RemoveHandler timer.Expired, AddressOf Timer_Expired
        RemoveHandler timer.Restarted, AddressOf Timer_Restarted
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
    ' Updates progress in various areas of the form.
    Private Async Function FormMainProgressUpdateAsync(token As System.Threading.CancellationToken) As Task(Of Object)
        Try
            ' Runs while not canceled.
            While (Not token.IsCancellationRequested)
                ' Calculate current progress value (based on current/total time left.)
                Dim currentProgressValue As Long
                currentProgressValue = (timer.Elapsed.TotalMilliseconds / timer.Duration.TotalMilliseconds) * 1000
                ' Report the progress (for task bar progress bar.)
                reporter.Report(currentProgressValue)

                ' Update form progress bar on UI thread.

                ProgressBarMain.Value = currentProgressValue

                UpdateWindowText()
                NotifyIconMain.Text = Utils.LimitTextLength(Me.Text, 63)

                ' Wait until next frame update.
                Await TaskEx.Delay(renderer.FramesPerSecond)
            End While
        Catch ex As TaskCanceledException
            logger.Info(ex)
        End Try
        Return New Object
    End Function
    Private Sub UpdateWindowText()
        ' Assign time string if the timer is running.
        Dim time As String = If(Not timer.IsExpired, timerObject.Text, String.Empty)
        ' Assign separator string if the timer is running and note is enabled.
        Dim separator As String = If(Not timer.IsExpired AndAlso noteEnabled, " - ", String.Empty)
        ' Assign note string if the note is enabled.
        Dim note As String = If(noteEnabled, timeSettings.Note, String.Empty)
        ' Assign title string if nothing is in previous variables (expiration with no note.)
        Dim title As String = If(time.Length = 0 And separator.Length = 0 And note.Length = 0, My.Application.Info.AssemblyName, String.Empty)
        ' Set Form text using the localized window text format.
        Me.Text = String.Format(My.Resources.Strings.WindowTextFormat, timerObject.Prefix, time, separator, note, title)
    End Sub

    Private Sub UpdateToolbar()
        SetFullScreenNoteVisibility()
        If (Not My.Settings.UseToolbarStyling) Then
            ToolStripSplitButtonSettings.Image = My.Resources.menu
            ToolStripButtonReset.Image = My.Resources.repeat
            ToolStripButtonStartPause.Image = If(timer.IsPaused, My.Resources.play, My.Resources.pause)
            ToolStripLabelNote.ForeColor = Label.DefaultForeColor
            ToolStripLabelNote.BackColor = Label.DefaultBackColor
        Else
            Dim transparentColor As Color = If(styleSettings.ForegroundColor = Color.Fuchsia, Color.AliceBlue, Color.Fuchsia)
            ToolStripButtonReset.ImageTransparentColor = transparentColor
            ToolStripButtonStartPause.ImageTransparentColor = transparentColor
            ToolStripSplitButtonSettings.ImageTransparentColor = transparentColor

            ToolStripSplitButtonSettings.Image = Utils.GetColoredImage(My.Resources.menu, styleSettings.ForegroundColor)
            ToolStripButtonReset.Image = Utils.GetColoredImage(My.Resources.repeat, styleSettings.ForegroundColor)
            ToolStripButtonStartPause.Image = If(timer.IsPaused, Utils.GetColoredImage(My.Resources.play, styleSettings.ForegroundColor), Utils.GetColoredImage(My.Resources.pause, styleSettings.ForegroundColor))
            ToolStripLabelNote.ForeColor = styleSettings.ForegroundColor
            ToolStripLabelNote.BackColor = styleSettings.BackgroundColor
        End If
    End Sub
    ' Update the form user interface.
    Private Sub UpdateUI()
        ToolStripButtonStartPause.Enabled = Not timer.IsExpired
        NotifyIconToolStripMenuItemStartTimer.Enabled = ToolStripButtonStartPause.Enabled
        ToolStripButtonStartPause.Text = If(timer.IsPaused, My.Resources.Strings.Start, My.Resources.Strings.Pause)
        NotifyIconToolStripMenuItemStartTimer.Text = ToolStripButtonStartPause.Text
        Me.Opacity = styleSettings.Opacity / 100
    End Sub

    Private Sub LoadSettings(fileName As String)
        If (Not System.IO.File.Exists(fileName)) Then Return

        Using stream As FileStream = File.OpenRead(fileName)
            Select Case System.IO.Path.GetExtension(fileName)
                Case My.Settings.StyleFileExtension
                    styleSettings.Import(stream)
                Case My.Settings.TaskFileExtension
                    Dim settings As New TaskSettings(transporter)
                    settings.Import(stream)
                    settings.Tasks.ForEach(Sub(i) i.Enabled = False)
                    taskSettings.Tasks.AddRange(settings.Tasks)
                    MessageBox.Show(My.Resources.Strings.MessageTasksWereImported, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case My.Settings.TimeFileExtension
                    timeSettings.Import(stream)
            End Select
            RestartRendering()
        End Using
    End Sub
    Sub InitializeAlarm()
        Try
            alarm.Load(Utils.GetAlarmFullPath(timeSettings.AlarmName))
            alarm.Volume = timeSettings.AlarmVolume
            alarm.Loop = timeSettings.AlarmLoop
        Catch ex As Exception
            logger.Error(ex)
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
    Private Sub InitializeFormMain()
        Me.Size = My.Settings.WindowSize

        Me.ToolStripMenuItemAlwaysOnTop.Checked = My.Settings.AlwaysOnTop
        Me.TopMost = Me.ToolStripMenuItemAlwaysOnTop.Checked

        Me.WindowState = If(My.Settings.WindowMaximized, FormWindowState.Maximized, FormWindowState.Normal)

        SetWindowFullScreen(My.Settings.WindowFullScreen)

        Me.ToolStripButtonReset.Text = My.Resources.Strings.Reset

        NotifyIconMain.Visible = My.Settings.ShowInSystemTray

        Me.Location = My.Settings.WindowPosition
        ' Get rid of selection on toolstrip.
        Me.Focus()
    End Sub
    Private Sub SaveSettings()
        My.Settings.WindowMaximized = maximized
        My.Settings.WindowFullScreen = fullScreen
        Me.WindowState = FormWindowState.Normal

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        My.Settings.WindowSize = Me.Size
        My.Settings.WindowPosition = Me.Location

        ' Save setting files
        styleSettings.Save()
        timeSettings.Save()
        taskSettings.Save()
    End Sub
    ' Toggles timer between paused and not paused.
    Private Sub SetTimerState(enabled As Boolean)
        If (enabled) Then
            timer.Start()
        Else
            timer.Pause()
        End If
        If (TaskbarManager.IsPlatformSupported) Then
            Dim progressState = If(timer.IsPaused,
                                   TaskbarProgressBarState.Paused,
                                   TaskbarProgressBarState.Normal)
            TaskbarManager.Instance.SetProgressState(progressState, Me.Handle)
        End If
        UpdateToolbar()
    End Sub
    Private Sub ResetTimer()
        timer.Reset()
        UpdateToolbar()
        HideNote()
    End Sub

    Private Sub CloseToSystemTray()
        Me.Hide()
        NotifyIconMain.Visible = True
    End Sub

    Private Sub SetStrings()
        Me.SuspendLayout()

        Me.ToolStripMenuItemNewTimer.Text = My.Resources.Strings.MenuNewTimer
        Me.ToolStripMenuItemEditTimer.Text = My.Resources.Strings.MenuEditTimer
        Me.ToolStripMenuItemTasks.Text = My.Resources.Strings.MenuTasks
        Me.ToolStripMenuItemStyle.Text = My.Resources.Strings.MenuStyle
        Me.ToolStripMenuItemMisc.Text = My.Resources.Strings.MenuMisc
        Me.ToolStripMenuItemAlwaysOnTop.Text = My.Resources.Strings.MenuAlwaysOnTop
        Me.ToolStripMenuItemHelp.Text = My.Resources.Strings.MenuHelp

        Me.ToolStripMenuItemWindow.Text = My.Resources.Strings.MenuWindow
        Me.ToolStripMenuItemCompact.Text = My.Resources.Strings.MenuCompact
        Me.ToolStripMenuItemFullScreen.Text = My.Resources.Strings.MenuFullSreen
        Me.ToolStripMenuItemDefault.Text = My.Resources.Strings.MenuDefault

        Me.ToolStripMenuItemHelp.Text = My.Resources.Strings.MenuHelp
        Me.ToolStripMenuItemHelpOnline.Text = My.Resources.Strings.MenuHelpOnline
        Me.ToolStripMenuItemAboutElanTimer.Text = My.Resources.Strings.About
        Me.ToolStripMenuItemCheckForUpdates.Text = My.Resources.Strings.MenuCheckForUpdates
        Me.ToolStripMenuItemExit.Text = My.Resources.Strings.MenuExit

        Me.ToolStripButtonNewTimer.Text = My.Resources.Strings.MenuNewTimer
        Me.ToolStripButtonReset.Text = My.Resources.Strings.Reset

        ' NotifyIconMain
        Me.NotifyIconToolStripMenuItemNewTimer.Text = My.Resources.Strings.MenuNewTimer
        Me.NotifyIconToolStripMenuItemEditTimer.Text = My.Resources.Strings.MenuEditTimer
        Me.NotifyIconToolStripMenuItemStartTimer.Text = My.Resources.Strings.Start
        Me.ToolNotifyIconStripMenuItemResetTimer.Text = My.Resources.Strings.Reset
        Me.NotifyIconToolStripMenuItemTasks.Text = My.Resources.Strings.MenuTasks
        Me.NotifyIconToolStripMenuItemStyle.Text = My.Resources.Strings.MenuStyle
        Me.NotifyIconToolStripMenuItemSettings.Text = My.Resources.Strings.MenuMisc
        Me.NotifyIconToolStripMenuItemExit.Text = My.Resources.Strings.MenuExit

        Me.ResumeLayout()
    End Sub

    Private Function WindowVisible(owner As Form) As Boolean
        Return (owner.Visible AndAlso (Not owner.WindowState = FormWindowState.Minimized))
    End Function

    Private Sub SetWindowDefault()
        ' Set timer form setting to default size.
        Me.WindowState = FormWindowState.Normal
        Me.TopMost = My.Settings.AlwaysOnTop
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        ' Set default window size.
        fullScreen = False

        Me.Size = My.Settings.DefaultWindowSize

        SetFullScreenNoteVisibility()
    End Sub

    Private Sub SetWindowCompact()
        Me.WindowState = FormWindowState.Normal
        Me.TopMost = My.Settings.AlwaysOnTop
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        fullScreen = False
        ' Set default window size.
        Me.Size = New Size(My.Settings.DefaultCompactWindowWidth, Me.Height - Me.ClientSize.Height + Me.ToolStripMain.Height)
        SetFullScreenNoteVisibility()
    End Sub

    Private Sub SetWindowFullScreen(enabled As Boolean)
        fullScreen = enabled
        If (enabled) Then
            Me.TopMost = True
            Me.WindowState = FormWindowState.Normal
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = If(My.Settings.WindowMaximized, FormWindowState.Maximized, FormWindowState.Normal)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
            Me.TopMost = My.Settings.AlwaysOnTop
        End If
        SetFullScreenNoteVisibility()
    End Sub
    Private Function GetColorsAsIntegerArray(colors As StringCollection) As Integer()
        If (colors Is Nothing) Then Return Nothing

        Return colors.Cast(Of String)() _
        .ToList() _
        .ConvertAll(Function(c)
                        Return Convert.ToInt32(c)
                    End Function) _
        .ToArray()
    End Function

    Private Function GetColorsAsStringCollection(colors As Integer()) As StringCollection
        If (colors Is Nothing) Then Return Nothing
        If (colors.Length = 0) Then Return Nothing

        Dim colorsCollection As StringCollection = New StringCollection()
        colorsCollection.AddRange(colors.ToList() _
                                  .ConvertAll(Function(c)
                                                  Return c.ToString()
                                              End Function) _
                                          .ToArray())
        Return colorsCollection

    End Function

    Private Function CloneTasks(tasks As List(Of TaskModel)) As List(Of TaskModel)
        Return tasks.ConvertAll(Of TaskModel)(Function(t)
                                                  Return New TaskModel(t.Event, t.Name, t.Command, t.Arguments, t.UseScript, t.Script, t.Enabled)
                                              End Function)
    End Function
#End Region
#Region "Dialogs"
    ' Shows the 'New Timer' or 'Edit Timer' dialogs.
    Public Sub ShowTimerDialog(owner As Form, editing As Boolean)
        ContextMenuStripMain.Enabled = False

        Using dialog = New TimerSettingsDialog()

            If (Not WindowVisible(owner)) Then
                owner = Nothing
            End If

            dialog.TopMost = (owner Is Nothing)

            AddHandler dialog.Loading, AddressOf TimerSettingsDialog_Loading
            AddHandler dialog.Saving, AddressOf TimerSettingsDialog_Saving

            dialog.FileFilter = My.Settings.TimeDialogFilter

            dialog.InitialDirectory = Utils.GetTimersPath()
            dialog.AlarmsPath = Utils.GetAlarmsPath()

            dialog.SelectedAlarm = timeSettings.AlarmName
            dialog.AlarmEnabled = timeSettings.AlarmEnabled
            dialog.AlarmLoop = timeSettings.AlarmLoop
            dialog.AlarmVolume = timeSettings.AlarmVolume

            dialog.Duration = timeSettings.Duration
            dialog.CountUp = timeSettings.CountUp
            dialog.Restarts = timeSettings.Restarts
            dialog.Note = timeSettings.Note
            dialog.ShowAlertBoxOnTimerExpiration = timeSettings.AlertEnabled
            dialog.Editing = editing

            Dim result As DialogResult = dialog.ShowDialog(owner)

            If (Not result = Windows.Forms.DialogResult.Cancel) Then
                timeSettings.Duration = dialog.Duration
                timeSettings.CountUp = dialog.CountUp
                timeSettings.Restarts = dialog.Restarts
                timeSettings.AlarmEnabled = dialog.AlarmEnabled
                timeSettings.AlarmName = If(dialog.SelectedAlarm, String.Empty)
                timeSettings.AlarmLoop = dialog.AlarmLoop
                timeSettings.AlarmVolume = dialog.AlarmVolume
                timeSettings.Note = If(Not String.IsNullOrEmpty(dialog.Note),
                                       dialog.Note.Replace(Environment.NewLine, String.Empty),
                                       String.Empty)
                timeSettings.AlertEnabled = dialog.ShowAlertBoxOnTimerExpiration

                InitializeAlarm()

                If (Not editing) Then
                    InitializeTimer()
                    RestartRendering()
                End If
                timer.AlarmEnabled = timeSettings.AlarmEnabled

                If (result = Windows.Forms.DialogResult.Yes) Then
                    SetTimerState(True)
                End If

                Me.UpdateToolbar()
            End If

            RemoveHandler dialog.Loading, AddressOf TimerSettingsDialog_Loading
            RemoveHandler dialog.Saving, AddressOf TimerSettingsDialog_Saving
        End Using

        ContextMenuStripMain.Enabled = True
    End Sub

    Private Sub ShowStyleDialog(owner As Form)
        ContextMenuStripMain.Enabled = False

        Using dialog As New StyleSettingsDialog()
            AddHandler dialog.Loading, AddressOf StyleSettingsDialog_Loading
            AddHandler dialog.Saving, AddressOf StyleSettingsDialog_Saving

            If (Not WindowVisible(owner)) Then
                owner = Nothing
                dialog.TopMost = True
            End If

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
            dialog.CustomStyleColors = GetColorsAsIntegerArray(My.Settings.CustomStyleColors)

            If (dialog.ShowDialog(owner) = Windows.Forms.DialogResult.OK) Then
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
                My.Settings.CustomStyleColors = If(dialog.CustomStyleColors IsNot Nothing,
                                                   GetColorsAsStringCollection(dialog.CustomStyleColors),
                                                   New StringCollection())

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

                SetToolStripStyling(My.Settings.UseToolbarStyling)
                UpdateToolbar()
            End If

            RemoveHandler dialog.Loading, AddressOf StyleSettingsDialog_Loading
            RemoveHandler dialog.Saving, AddressOf StyleSettingsDialog_Saving
        End Using

        ContextMenuStripMain.Enabled = True
    End Sub

    Private Sub ShowSettingsDialog(owner As Form)
        ContextMenuStripMain.Enabled = False

        Using dialog As New SettingsDialog()
            If (Not WindowVisible(owner)) Then
                owner = Nothing
                dialog.TopMost = True
            End If

            dialog.ShowDialog(owner)
        End Using

        NotifyIconMain.Visible = My.Settings.ShowInSystemTray

        SetToolStripStyling(My.Settings.UseToolbarStyling)
        UpdateToolbar()

        ContextMenuStripMain.Enabled = True
    End Sub

    Private Sub ShowTaskDialog(owner As Form)
        ContextMenuStripMain.Enabled = False

        Using dialog As New TaskSettingsDialog()
            AddHandler dialog.Importing, AddressOf TaskSettingsDialog_Importing
            AddHandler dialog.Exporting, AddressOf TaskSettingsDialog_Exporting

            If (Not WindowVisible(owner)) Then
                owner = Nothing
                dialog.TopMost = True
            End If

            dialog.InitialDirectory = Utils.GetDataPath()
            dialog.FileFilter = My.Settings.TaskDialogFilter
            dialog.Tasks = CloneTasks(taskSettings.Tasks)
            If (dialog.ShowDialog(owner) = Windows.Forms.DialogResult.OK) Then
                taskSettings.Tasks = dialog.Tasks
            End If
            RemoveHandler dialog.Importing, AddressOf TaskSettingsDialog_Importing
            RemoveHandler dialog.Exporting, AddressOf TaskSettingsDialog_Exporting
        End Using

        ContextMenuStripMain.Enabled = True
    End Sub

    Private Sub ExitApplication()
        Me.Close()
    End Sub

    Private Sub ShowErrorMessage(msg As String)
        MessageBox.Show(msg, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
#End Region
    Public Sub New()
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf UnhandledException
        AddHandler Application.ThreadException, AddressOf UnhandledThreadException
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub UnhandledThreadException(sender As Object, e As ThreadExceptionEventArgs)
        logger.Fatal(e.Exception)
        ' MessageBox.Show("Elan Timer has encountered a problem and needs to close. We are sorry for the inconvenience.", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Environment.FailFast(e.Exception.Message, e.Exception)
    End Sub

    Private Sub UnhandledException(sender As Object, e As UnhandledExceptionEventArgs)
        Dim ex As Exception = TryCast(e.ExceptionObject, Exception)
        If (ex IsNot Nothing) Then
            logger.Fatal(ex)
        End If
        ' MessageBox.Show("Elan Timer has encountered a problem and needs to close. We are sorry for the inconvenience.", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Environment.FailFast(ex.Message, ex)
    End Sub
End Class