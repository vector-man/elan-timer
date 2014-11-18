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
    Private timerObject As TextRenderable
    ' The note object to render.
    Private noteObject As TextRenderable
    ' String format for rendering text.
    Private stringFormat As New StringFormat
    ' Prefix to display on timer when counting up.
    Private Const CountUpPrefix As String = "+"
    ' Used for importing or exporting data (in JSON format.)
    Private importerExporter As IImporterExporter = New JsonNetImporterExporter()
    ' Settings object for timer.
    Private timeSettings As TimeSettings = New TimeSettings(importerExporter)
    ' Settings object for tasks.
    Private taskSettings As TaskSettings = New TaskSettings(importerExporter)
    ' Settings object for styles.
    Private styleSettings As StyleSettings = New StyleSettings(importerExporter)
    Dim alertsSettings As AlertsSettings = New AlertsSettings(importerExporter)
    ' Main alarm.
    Private ReadOnly alarm As New Sound()
    ' Main timer.
    Public ReadOnly timer As New AlarmTimer(TimeSpan.Zero)
    ' Reports progress to update UI when timer is running.
    Private reporter As IProgress(Of Integer)

    ' Escape key character (used for exiting full screen mode.)
    Private ReadOnly EscapeKeyChar = Convert.ToChar(27)

    ' Forces window to close.
    Private forceExit As Boolean = False

    Dim maximized As Boolean = False

    Dim fullScreen As Boolean = False

    Private noteEnabled As Boolean

    Private timeFormat As New TimeFormat()

    Private lastTextRenderedTime As String = String.Empty

    Private Mapper As New Mapper()

    Private presetsMenu As New ContextMenuStrip()

    Private bundler As New Bundler()

    Private selectedTabIndex As Integer = 0

    ' Logging.
    Private Shared logger As Logger = LogManager.GetCurrentClassLogger()

    ' Used for benchmark and testing.
#If DEBUG Then
    Private sw As New Stopwatch
#End If


#Region "Timer Event Handlers"

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
        ' Prints the elapsed time in milliseconds (to check timer accuracy.)
#If DEBUG Then
        sw.Stop()
        Debug.Print("Elapsed time (MS): {0}. Timer time (MS): {1}", sw.Elapsed.TotalMilliseconds, timer.Duration.TotalMilliseconds)
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
#Region "Form Event Handlers"
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

    Private Sub NotifyIconMain_Click(sender As Object, e As EventArgs) Handles NotifyIconMain.Click
        ' If the icon is shown in the system tray and clicking the icon should turn the alarm off.
        If (Not My.Settings.ShowInSystemTray) Then Return
        If (Not My.Settings.ClickingTrayIconStopsAlarm) Then Return
        If (Not timer.IsExpired) Then Return

        Try
            ' Try to stop the alarm. 
            Dim alarm As Sound = CType(timer, CodeIsle.Timers.AlarmTimer).Alarm
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

    Private Sub NotifyIconToolStripMenuItemExit_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemExit.Click
        ' Exit the application, forcing it to exit.
        forceExit = True
        ExitApplication()
    End Sub

    Private Sub ToolNotifyIconStripMenuItemResetTimer_Click(sender As Object, e As EventArgs) Handles ToolNotifyIconStripMenuItemResetTimer.Click
        ResetTimer()
    End Sub

    Private Sub NotifyIconToolStripMenuItemShow_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemShow.Click
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub NotifyIconToolStripMenuItemSettings_Click(sender As Object, e As EventArgs) Handles NotifyIconToolStripMenuItemSettings.Click
        ShowSettingsDialog(Me)
    End Sub

    Private Sub FormMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If (timerObject IsNot Nothing) Then timerObject.Rectangle = timerSurface.ClientRectangle
        If (noteObject IsNot Nothing) Then noteObject.Rectangle = timerSurface.ClientRectangle

        If (fullScreen) Then Return
        maximized = (Me.WindowState = FormWindowState.Maximized)
    End Sub

    Private Sub TaskSettingsDialog_Importing(sender As Object, e As TaskImportingEventArgs)
        Try
            Dim dialog As TaskSettingsDialog = sender
            Dim settings As New TaskSettings(importerExporter)

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
            Dim settings As New TaskSettings(importerExporter)
            Using output As Stream = File.OpenWrite(e.Output)
                settings.Tasks = e.Tasks
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
                                          LoadPresets(value)
                                      End Sub, Action(Of String)), New Object() {file})
            Me.Activate()

        Catch ex As Exception
            logger.Error(ex)
        End Try
    End Sub

    Private Sub ToolStripButtonReset_Click(sender As Object, e As EventArgs) Handles ToolStripButtonReset.Click
        ResetTimer()
    End Sub

    Private Sub ToolStripMenuItemAlwaysOnTop_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAlwaysOnTop.Click
        ' Toggle form to or from top most position.
        Me.TopMost = CType(sender, ToolStripMenuItem).Checked
        ' Enable or disable the "AlwaysOnTop" seting.
        My.Settings.AlwaysOnTop = Me.ToolStripMenuItemAlwaysOnTop.Checked
    End Sub

    Private Sub FormMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' If closing to system tray is enabled, then only close the window (don't exit the application).
        If (Not forceExit And (My.Settings.ShowInSystemTray And My.Settings.CloseToSystemTray)) Then
            e.Cancel = True
            CloseToSystemTray()
        Else
            StopRendering()
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
        ' If escape key is pressed, then exit full screen mode.
        If (e.KeyChar = EscapeKeyChar) Then
            SetWindowFullScreen(False)
        End If
    End Sub
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set localized strings for this form.
        SetStrings()

        ' Try to set the alarm name. If it is not present on the system, sets the default alarm or nothing instead.
        Try
            alertsSettings.AlarmName = Utils.GetAlarmNameOrDefault(alertsSettings.AlarmName)
        Catch ex As Exception
            logger.Warn("No alarms could be found.", ex)
        End Try

        ' If task bar progress bar is supported, enable it.
        ' Else, set reporter to an empty progress reporter instead (nothing will be reported.)
        If (TaskbarManager.IsPlatformSupported) Then
            reporter = New Progress(Of Integer) _
                (Sub(progress)
                     TaskbarManager.Instance.SetProgressValue(progress, 1000, Me.Handle)
                 End Sub)
        Else
            reporter = New Progress(Of Integer)()
        End If

        ' If a single argument is in command line (assumed to be a file), then load settings file.
        If (My.Application.CommandLineArgs.Count = 1) Then
            LoadPresets(My.Application.CommandLineArgs(0))
            My.Settings.Running = False
        End If

        InitializeAlarm()

        InitializeRendering()

        AddTimerHandlers()

        If (My.Settings.Running And timeSettings.Synchronize) Then
            Dim elapsed As TimeSpan = DateTime.Now - My.Settings.Timestamp

            ResetTimer(elapsed)

            RemoveHandler timer.Started, AddressOf Timer_Started

            SetTimerState(True)

            AddHandler timer.Started, AddressOf Timer_Started
        Else
            ResetTimer()
        End If

        StartRendering()

        InitializeFormMain()
        ' Get rid of the toolstrip highlight bug that occurs for some reason.
        ToolStripMain.Select()

        Mapper.Create(Of TimeSettings, TimerSettingsDialog)()
        Mapper.Create(Of StyleSettings, StyleSettingsDialog)()
        Mapper.Create(Of AlertsSettings, AlertsSettingsDialog)()

        bundler.SettingsInfos.Add(New SettingsInfo() With {
                                  .Description = "Styles",
                                  .FileExtension = ".look",
                                  .Settings = styleSettings})
        bundler.SettingsInfos.Add(New SettingsInfo() With {
                          .Description = "Time",
                          .FileExtension = ".time",
                          .Settings = timeSettings})

        'If (My.Settings.SettingsInfos Is Nothing) Then
        '    My.Settings.SettingsInfos = New OrderedDictionary()

        'For Each info As SettingsInfo In bundler.SettingsInfos
        '    My.Settings.SettingsInfos.Add(True, info)
        'Next
        'End If

        ' Add handler for UpdateUI.
        AddHandler Application.Idle, AddressOf UpdateUI
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

    Private Sub DefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDefault.Click
        SetWindowDefault()
    End Sub

    Private Sub CompactToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCompact.Click
        ' Set timer form to 'compact' size.
        SetWindowCompact()
    End Sub

    Private Sub TimerSurface_DoubleClick(sender As Object, e As EventArgs)
        ' Show timer dialog without editing ('New Timer' mode).
        ShowNewEditDialog(Me, False)
    End Sub
    Private Sub TimerSurface_Click(sender As Object, e As EventArgs)
        ' Exit fullscreen mode (when the timer display area is clicked).
        If (Not fullScreen) Then Return
        SetWindowFullScreen(False)
    End Sub
    ' Toggle timer between paused/not paused.
    Private Sub ToolStripButtonStartPause_Click(sender As Object, e As EventArgs) Handles ToolStripButtonStartPause.Click
        ' Set timer state to the opposite of its current state (toggle start/pause). 
        SetTimerState(Not timer.Enabled)
    End Sub
    ' Set timer form to or from fullscreen.
    Private Sub FullScreenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemFullScreen.Click
        If (fullScreen) Then Return
        SetWindowFullScreen(True)
    End Sub

    Private Sub ToolStripMenuItemNewTimer_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemNewTimer.Click
        ShowNewEditDialog(Me, False)
    End Sub

    Private Sub ToolStripMenuItemEditTimer_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEditTimer.Click
        ShowNewEditDialog(Me, True)
    End Sub
#End Region



#Region "Helper Methods"
    ' Shuts down rendering of the timer.
    Private Sub StopRendering()
        updateCancellationTokenSource.Cancel()
        Task.WaitAll()

        updateCancellationTokenSource.Dispose()

        renderer.Enabled = False

        timerObject.Visible = False
        noteObject.Visible = False
    End Sub
    Private Sub InitializeRendering()
        timerSurface = New Surface()
        timerSurface.Dock = DockStyle.Fill

        AddHandler timerSurface.DoubleClick, AddressOf TimerSurface_DoubleClick
        AddHandler timerSurface.Click, AddressOf TimerSurface_Click

        PanelTimer.Controls.Add(timerSurface)

        stringFormat = New StringFormat(System.Drawing.StringFormat.GenericTypographic)
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        timerObject = New TextRenderable()

        noteObject = New TextRenderable()

        renderer = New Renderer(timerSurface)
        renderer.Renderables.Add(timerObject)
        renderer.Renderables.Add(noteObject)
    End Sub
    Private Function GetTimerTextRenderFunc(countUp As Boolean) As Func(Of String)
        If (countUp) Then
            Return Function()

                       Dim remaining As String = If(timer.RemainingRestarts > 0, "[{0}]", String.Empty)

                       lastTextRenderedTime = String.Format(timeFormat, String.Concat(remaining, "+", "{1:", styleSettings.DisplayFormat, "}"), timer.RemainingRestarts, Me.timer.Elapsed)
                       Return lastTextRenderedTime
                   End Function
        Else
            Return Function()
                       Dim remaining As String = If(timer.RemainingRestarts > 0, "[{0}]", String.Empty)

                       lastTextRenderedTime = String.Format(timeFormat, String.Concat(remaining, "{1:", styleSettings.DisplayFormat, "}"), timer.RemainingRestarts, Me.timer.Remaining)
                       Return lastTextRenderedTime
                   End Function
        End If
    End Function
    ' Starts up rendering of the timer.
    Private Async Sub StartRendering()
        timerSurface.BackColor = styleSettings.BackgroundColor

        timerObject.Color = styleSettings.ForegroundColor
        timerObject.Font = styleSettings.DisplayFont

        SetTextRenderFunc()

        timerObject.Rectangle = timerSurface.ClientRectangle
        timerObject.SizeToFit = styleSettings.GrowToFit
        timerObject.StringFormat = stringFormat
        timerObject.Visible = True

        noteObject.Color = styleSettings.ForegroundColor
        noteObject.Font = styleSettings.DisplayFont
        noteObject.Rectangle = timerSurface.ClientRectangle
        noteObject.SizeToFit = styleSettings.GrowToFit
        noteObject.StringFormat = stringFormat
        noteObject.TextRenderFormat = Function() timeSettings.Note
        noteObject.Visible = False

        ToolStripLabelNote.Text = timeSettings.Note

        SetToolStripStyling(My.Settings.UseToolbarStyling)

        renderer.Enabled = True

        UpdateToolbar()

        updateCancellationTokenSource = New System.Threading.CancellationTokenSource

        noteEnabled = Not String.IsNullOrWhiteSpace(timeSettings.Note)

        ToolStripLabelNote.Text = timeSettings.Note

        Await FormMainProgressUpdateAsync(updateCancellationTokenSource.Token)
    End Sub
    Sub RestartRendering()
        StopRendering()
        StartRendering()
    End Sub
    ' Enable or disable tool strip styling.
    Private Sub SetToolStripStyling(enabled As Boolean)
        If (enabled) Then
            ToolStripMain.BackColor = styleSettings.BackgroundColor
            Dim renderer = New BorderlessToolStripSystemRenderer()
            renderer.SeparatorBackColor = styleSettings.ForegroundColor
            renderer.SeparatorForeColor = styleSettings.ForegroundColor
            ToolStripMain.Renderer = renderer
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
        ' Show note if in full screen mode.
        SetFullScreenNoteVisibility()
    End Sub
    ' Show the timer note and hide the time.
    Private Sub ShowNote()
        ' If the note text is empty, set it to "Expired."
        If (timeSettings.Note = String.Empty) Then
            noteObject.TextRenderFormat = Function() My.Resources.Strings.TimerHasExpired
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
                                 If (alertsSettings.DisplayNoteEnabled) Then ShowNote()

                                 ' If message box alert is enabled, show it.
                                 If (Not alertsSettings.AlertEnabled) Then Return

                                 ' If message is empty, show a default message. Else, show the note message.
                                 Dim note As String = noteObject.TextRenderFormat.Invoke()
                                 Dim message As String = If(note = String.Empty,
                                                            My.Resources.Strings.TimerHasExpired,
                                                            note)
                                 cTaskDialog.MessageBox(Me,
                                                        My.Application.Info.ProductName,
                                                        message,
                                                        String.Format("The timer has expired at: {0}",
                                                        Date.Now().ToString()),
                                                        eTaskDialogButtons.OK,
                                                        eSysIcons.Information)


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
        If (WindowState = FormWindowState.Minimized OrElse Not Visible) Then
            lastTextRenderedTime = timerObject.TextRenderFormat().Invoke()
        End If

        Dim time As String = If(Not timer.IsExpired, lastTextRenderedTime, String.Empty)

        ' Assign separator string if the timer is running and note is enabled.
        Dim separator As String = If(Not timer.IsExpired AndAlso noteEnabled, " - ", String.Empty)
        ' Assign note string if the note is enabled.
        Dim note As String = If(noteEnabled, timeSettings.Note, String.Empty)
        ' Assign title string if nothing is in previous variables (expiration with no note.)
        Dim title As String = If(time.Length = 0 AndAlso separator.Length = 0 AndAlso note.Length = 0, My.Application.Info.AssemblyName, String.Empty)
        ' Set Form text using the localized window text format.
        Me.Text = String.Format("{0}{1}{2}{3}", title, time, separator, note)
    End Sub

    Private Sub UpdateToolbar()
        SetFullScreenNoteVisibility()

        ToolStripButtonCountUpDown.Text = If(timeSettings.CountUpwards, "Change display to counting downwards", "Change display to counting upwards")

        If (Not My.Settings.UseToolbarStyling) Then
            ToolStripSplitButtonSettings.Image = My.Resources.menu
            ToolStripButtonReset.Image = My.Resources.repeat
            ToolStripButtonStartPause.Image = If(timer.IsPaused AndAlso Not (timer.IsExpired), My.Resources.play, My.Resources.pause)
            ToolStripButtonCountUpDown.Image = If(timeSettings.CountUpwards, My.Resources.arrow_up, My.Resources.arrow_down)
            ToolStripLabelNote.ForeColor = Label.DefaultForeColor
            ToolStripLabelNote.BackColor = Label.DefaultBackColor
        Else
            Dim transparentColor As Color = If(styleSettings.ForegroundColor = Color.Fuchsia,
                                               Color.AliceBlue,
                                               Color.Fuchsia)
            ToolStripButtonReset.ImageTransparentColor = transparentColor
            ToolStripButtonStartPause.ImageTransparentColor = transparentColor
            ToolStripSplitButtonSettings.ImageTransparentColor = transparentColor

            ToolStripSplitButtonSettings.Image = Utils.GetColoredImage(My.Resources.menu, styleSettings.ForegroundColor)
            ToolStripButtonReset.Image = Utils.GetColoredImage(My.Resources.repeat, styleSettings.ForegroundColor)
            ToolStripButtonStartPause.Image = If(timer.IsPaused AndAlso Not (timer.IsExpired),
                                                 Utils.GetColoredImage(My.Resources.play, styleSettings.ForegroundColor),
                                                 Utils.GetColoredImage(My.Resources.pause, styleSettings.ForegroundColor))

            ToolStripButtonCountUpDown.Image = If(timeSettings.CountUpwards,
                                                 Utils.GetColoredImage(My.Resources.arrow_up, styleSettings.ForegroundColor),
                                                  Utils.GetColoredImage(My.Resources.arrow_down, styleSettings.ForegroundColor))
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
        Me.Opacity = (100 - styleSettings.Transparency) / 100
    End Sub

    Private Sub LoadPresets(fileName As String)
        Using stream As FileStream = File.OpenRead(fileName)
            Dim ext As String = Path.GetExtension(fileName)
            Dim containedFiles() As String = New String() {}
            If (ext = bundler.FileExtension) Then
                bundler.Unbundle(fileName, containedFiles)
            Else
                Dim settings As SettingsInfo = bundler.SettingsInfos.Where(Function(s) s.FileExtension = ext).FirstOrDefault()
                If (settings Is Nothing) Then
                    Throw New FileFormatException()
                End If
                Using fs As FileStream = File.OpenRead(fileName)
                    settings.Settings.Import(fs)
                End Using
            End If

            InitializeAlarm()

            If (ext = ".time" OrElse containedFiles.Where(Function(f) Path.GetExtension(f) = ".time").Count > 0) Then
                ResetTimer()
            End If

            UpdateUI()
            RestartRendering()

            AddRecentPreset(fileName)
        End Using
    End Sub

    Public Sub SavePresets(fileName As String)
        Try
            Dim ext As String = Path.GetExtension(fileName)
            If (ext = bundler.FileExtension) Then
                bundler.Bundle(fileName)
            Else
                Dim setting As SettingsInfo = bundler.SettingsInfos().Where(Function(s) s.FileExtension = ext).First()

                Using fs As FileStream = File.OpenWrite(fileName)
                    setting.Settings.Export(fs)
                End Using
            End If

            AddRecentPreset(fileName)

        Catch ex As Exception
            Try
                File.Delete(fileName)
            Catch ex2 As Exception
                logger.Warn(ex2)
            End Try

            Throw New Exception(ex.Message, ex)
        End Try
    End Sub

    Public Function GetFilesFilter(bundler As Bundler) As String
        Dim extensions As New StringBuilder()

        For Each ext In bundler.GetExtensions()
            extensions.Append("*")
            extensions.Append(ext)
            extensions.Append("; ")
        Next

        extensions.Remove(extensions.Length - 1, 1)

        Dim supportedFilter As String = String.Format("Supported Files ({0})|{0}", extensions)

        Return String.Format("{0}|{1}", supportedFilter, String.Join("|", bundler.GetFilters()))
    End Function

    Private Function GetPresetIcon(preset As String) As Image
        Select Case Path.GetExtension(preset)
            Case ".box"
                Return My.Resources.package
            Case ".time"
                Return My.Resources.time
            Case ".task"
                Return My.Resources.sheduled_task
            Case ".look"
                Return My.Resources.smartart_change_color_gallery
        End Select
        Return Nothing
    End Function

    Sub AddRecentPreset(fileName As String)
        If (My.Settings.RecentPresets Is Nothing) Then
            My.Settings.RecentPresets = New StringCollection()
        End If
        Dim presets As List(Of String) = My.Settings.RecentPresets.Cast(Of String).ToList()
        presets.Insert(0, fileName)
        presets = presets.Take(My.Settings.MaximumRecentPresets).Distinct().ToList()

        My.Settings.RecentPresets.Clear()
        My.Settings.RecentPresets.AddRange(presets.ToArray())

        RefreshPresetsMenu()
    End Sub
    Private PresetMenuItems As New List(Of ToolStripMenuItem)
    Sub RefreshPresetsMenu()
        For Each itemToDelete In PresetMenuItems
            RemoveHandler itemToDelete.Click, AddressOf PresetMenuItem_Click
            itemToDelete.Dispose()
        Next

        PresetMenuItems = New List(Of ToolStripMenuItem)

        For Each preset In My.Settings.RecentPresets
            Dim item As New ToolStripMenuItem()
            item.Text = Path.GetFileNameWithoutExtension(preset)
            item.Tag = preset
            item.Image = GetPresetIcon(preset)
            AddHandler item.Click, AddressOf PresetMenuItem_Click
            PresetsToolStripMenuItem.DropDownItems.Add(item)
            PresetMenuItems.Add(item)
        Next
    End Sub
    Sub PresetMenuItem_Click(sender As Object, e As EventArgs)
        Dim item As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        Try
            LoadPresets(item.Tag.ToString())
        Catch ex As Exception
            RemoveHandler item.Click, AddressOf PresetMenuItem_Click
            My.Settings.RecentPresets.Remove(item.Tag)
            item.Dispose()
            ShowErrorMessage(String.Format("Failed to load preset: ""{0}."" It will be removed from the Presets list.", item.Text))
            logger.Error(ex)
        End Try
    End Sub
    Sub InitializeAlarm()
        Try
            alarm.Load(Utils.GetAlarmFullPath(alertsSettings.AlarmName))
            alarm.Volume = alertsSettings.AlarmVolume
            alarm.Loop = alertsSettings.AlarmLoop
        Catch ex As Exception
            logger.Error(ex)
        End Try
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

        RefreshPresetsMenu()
    End Sub
    Private Sub SaveSettings()
        My.Settings.WindowMaximized = maximized
        My.Settings.WindowFullScreen = fullScreen
        Me.WindowState = FormWindowState.Normal

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        My.Settings.WindowSize = Me.Size
        My.Settings.WindowPosition = Me.Location

        My.Settings.Running = (Not (timer.IsPaused Or timer.IsExpired))

        My.Settings.Timestamp = DateTime.Now - timer.Elapsed.Add(TimeSpan.FromTicks(timeSettings.Duration.Ticks * timer.ElapsedRestarts))

        My.Settings.Save()

        ' Save setting files
        styleSettings.Save()
        timeSettings.Save()
        taskSettings.Save()
        alertsSettings.Save()
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
        ResetTimer(TimeSpan.Zero)
    End Sub
    Private Sub ResetTimer(elapsed As TimeSpan)
        timer.Reset(timeSettings.Duration, elapsed, timeSettings.Restarts)
        timer.Alarm = alarm
        timer.AlarmEnabled = alertsSettings.AlarmEnabled
        timer.AlarmPerRestart = alertsSettings.AlarmPerRestart

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
        Me.ToolStripMenuItemMisc.Text = My.Resources.Strings.MenuOptions
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
        Me.NotifyIconToolStripMenuItemSettings.Text = My.Resources.Strings.Options
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
#End Region
#Region "Dialogs"

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

        If (Not My.Settings.ShowInSystemTray) Then
            Me.Show()
        End If

        SetToolStripStyling(My.Settings.UseToolbarStyling)
        UpdateToolbar()

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

    Private Sub ToolStripButtonCountUp_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCountUpDown.Click
        ToolStripButtonCountUpDown.Visible = False
        timeSettings.CountUpwards = Not timeSettings.CountUpwards
        UpdateToolbar()
        SetTextRenderFunc()
        ToolStripButtonCountUpDown.Visible = True
    End Sub

    Private Sub SetTextRenderFunc()
        timerObject.TextRenderFormat = GetTimerTextRenderFunc(timeSettings.CountUpwards)
    End Sub

    Private Sub ShowNewEditDialog(owner As IWin32Window, editing As Boolean)

        Using timeDialog As New TimerSettingsDialog(),
        alertsDialog As New AlertsSettingsDialog(),
        tasksDialog As New TaskSettingsDialog(),
        styleDialog As New StyleSettingsDialog()

            timeDialog.Text = My.Resources.Strings.Time
            timeDialog.Editing = editing

            alertsDialog.Text = My.Resources.Strings.Alerts
            alertsDialog.SoundsPath = Utils.GetAlarmsPath

            styleDialog.Text = My.Resources.Strings.Style
            styleDialog.DisplayFormats = Utils.DisplayFormats
            styleDialog.Time = timeDialog.Time

            tasksDialog.Text = My.Resources.Strings.Tasks
            tasksDialog.Tasks = New TasksModel(taskSettings.Tasks).Clone()
            AddHandler tasksDialog.Importing, AddressOf TaskSettingsDialog_Importing
            AddHandler tasksDialog.Exporting, AddressOf TaskSettingsDialog_Exporting

            Mapper.Map(timeSettings, timeDialog)
            Mapper.Map(alertsSettings, alertsDialog)
            Mapper.Map(styleSettings, styleDialog)

            Using dialog As NewEditDialog = CreateNewEditDialog(editing,
                                                                New KeyValuePair(Of Image, Form)(My.Resources.time, timeDialog),
                                                                New KeyValuePair(Of Image, Form)(My.Resources.exclamation, alertsDialog),
                                                                New KeyValuePair(Of Image, Form)(My.Resources.sheduled_task, tasksDialog),
                                                                New KeyValuePair(Of Image, Form)(My.Resources.smartart_change_color_gallery, styleDialog))

                dialog.SelectedTabIndex = If(editing, selectedTabIndex, 0)

                Dim result = dialog.ShowDialog(owner)

                If (result = Windows.Forms.DialogResult.Cancel) Then Return

                selectedTabIndex = If(editing, dialog.SelectedTabIndex, 0)

                Mapper.Map(styleDialog, styleSettings)
                Mapper.Map(alertsDialog, alertsSettings)
                Mapper.Map(timeDialog, timeSettings,
                           Function(p) (Not (editing AndAlso (p = "Restarts" OrElse p = "Duration"))))

                taskSettings.Tasks = tasksDialog.Tasks

                InitializeAlarm()

                If (Not editing) Then ResetTimer()

                If (result = Windows.Forms.DialogResult.Yes) Then SetTimerState(True)

                UpdateUI()

                RestartRendering()
            End Using

            RemoveHandler tasksDialog.Importing, AddressOf TaskSettingsDialog_Importing
            RemoveHandler tasksDialog.Exporting, AddressOf TaskSettingsDialog_Exporting
        End Using
    End Sub
    Private Function CreateNewEditDialog(editing As Boolean, ParamArray dialogs() As KeyValuePair(Of Image, Form)) As NewEditDialog
        Dim dialog As New NewEditDialog()

        dialog.Editing = editing
        dialog.Text = If(editing,
                         My.Resources.Strings.EditTimer,
                         My.Resources.Strings.NewTimer)
        For Each dlg As KeyValuePair(Of Image, Form) In dialogs
            dlg.Value.ShowIcon = True
            dialog.AddTab(dlg.Value.Text, dlg.Key, dlg.Value)
        Next

        Return dialog
    End Function

    Private Sub LoadPresetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadPresetToolStripMenuItem.Click
        Dim fileName As String = Nothing

        Try
            Using dialog As New OpenFileDialog()

                dialog.Filter = GetFilesFilter(bundler)
                If (dialog.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel) Then Return

                fileName = dialog.FileName

                LoadPresets(fileName)

                Dim ext As String = Path.GetExtension(fileName)

                If (ext = ".time") Then
                    ResetTimer()
                End If

                UpdateUI()
            End Using
        Catch ex As Exception
            ShowErrorMessage(String.Format("Failed to load preset: ""{0}""", fileName))
            logger.Error(ex)
        End Try
    End Sub

    Private Sub SavePresetAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SavePresetAsToolStripMenuItem.Click
        Dim fileName As String = Nothing

        Try
            Using dialog As New SaveFileDialog()
                dialog.Filter = String.Join("|", bundler.GetFilters())

                If (dialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
                    fileName = dialog.FileName
                    SavePresets(fileName)
                End If
            End Using
        Catch ex As Exception
            logger.Error(ex)
            ShowErrorMessage(String.Format("Failed to save file: ""{0}""", fileName))
        End Try
    End Sub
End Class