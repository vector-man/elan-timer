Imports Microsoft.WindowsAPICodePack.Taskbar
Imports System.Threading
Imports System.Text

Public Class FormMain
    'Private renderer As RendererManager
    Public updateCancellationTokenSource As System.Threading.CancellationTokenSource
    Public timerSurface As Rendering.Surface
    Private uiScheduler As TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext()

    Private ReadOnly EscapeKeyChar = Convert.ToChar(27)

    Private backgroundObject As ClearRenderObject
    Private timerObject As TimerTextRenderObject
    Private noteObject As TextRenderObject
    Private stringFormat As New StringFormat
    Private renderer As Rendering.IRenderer
#If DEBUG Then
    Private sw As New Stopwatch ' Used for benchmark and testing.
#End If

    Public timer As CodeIsle.Timers.AlarmTimer

#Region "Timer Event Handelers"
    Public Sub Timer_Started(sender As Object, e As TimerEventArgs)
        ExecuteActions(Settings.Models.TimerEvent.Started)
    End Sub
    Public Sub Timer_Paused(sender As Object, e As TimerEventArgs)
        ExecuteActions(Settings.Models.TimerEvent.Paused)
        ' TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Paused)
    End Sub
    Public Sub Timer_Restarted(sender As Object, e As TimerEventArgs)
        ExecuteActions(Settings.Models.TimerEvent.Restarted)
        HideNote()
    End Sub
    Public Sub Timer_Expired(sender As Object, e As TimerEventArgs)
        ExecuteActions(Settings.Models.TimerEvent.Expired)
        ShowNote()
    End Sub
    Public Sub ExecuteActions(e As Settings.Models.TimerEvent)
        TaskEx.Run(Sub()

                       Dim actions = From action In Common.Tasks.Tasks
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
        timer.Reset()
        HideNote()
        UpdateIcons()
    End Sub

    Private Sub AlwaysOnTopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAlwaysOnTop.Click
        Me.TopMost = CType(sender, ToolStripMenuItem).Checked
        My.Settings.AlwaysOnTop = Me.ToolStripMenuItemAlwaysOnTop.Checked
    End Sub

    Private Sub FormMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ShutDownRendering()
        If Not My.Settings.WindowFullScreen Then
            My.Settings.WindowMaximized = (Me.WindowState = FormWindowState.Maximized)
            Me.WindowState = FormWindowState.Normal
            My.Settings.WindowSize = Me.Size
        End If
        SaveSettings()
    End Sub

    Private Sub ConfigureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormConfiguration.ShowDialog()
    End Sub

    Private Sub ToolStrip1_MouseEnter(sender As Object, e As EventArgs) Handles ToolStrip1.MouseEnter
        Me.Focus()
    End Sub

    Private Sub FormMain_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = EscapeKeyChar Then
            If My.Settings.WindowFullScreen Then
                ExitFullScreen()
            End If
        End If
    End Sub
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLanguage()

        ' TaskbarManager.Instance.SetProgressValue(0, 100)

        LoadSettings()

        Dim alarm As Alarm = Nothing

        Try
            alarm = New Alarm(Common.GetAlarmPath(Common.Time.AlarmPath), Common.Time.AlarmVolume, Common.Time.AlarmLoop)
        Catch ex As Exception

        End Try

        timer = TimerFactory.CreateInstance(Common.Time.Duration, Common.Time.CountUp, Common.Time.Restarts, alarm, Common.Time.AlarmEnabled)
        StartUpRendering(timer)
        AddTimerHandlers()

        AddHandler Application.Idle, AddressOf UpdateUI
    End Sub
    Private Sub GlobalSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemConfiguration.Click
        Try
            FormConfiguration.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show(ex.InnerException.ToString)
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemExit.Click
        Me.Close()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemLook.Click
        Try
            DialogLookSettings.ShowDialog(Me)
            Dim timeVisible = timerObject.Visible
            timerObject.Visible = False

            Dim noteVisible = noteObject.Visible
            noteObject.Visible = False

            backgroundObject.Color = Common.Look.BackgroundColor
            timerObject.Color = Common.Look.ForegroundColor
            timerObject.Font = Common.Look.Font
            timerObject.Format = Common.Look.DisplayFormat
            timerObject.SizeToFit = Common.Look.SizeToFit


            noteObject.Color = Common.Look.ForegroundColor
            noteObject.Font = Common.Look.Font


            timerObject.Visible = timeVisible
            noteObject.Visible = noteVisible

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemTasks.Click
        DialogTaskSettings.ShowDialog(Me)
    End Sub

    Private Sub DefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDefault.Click
        My.Settings.WindowFullScreen = False
        My.Settings.WindowMaximized = False
        GoFullscreen(My.Settings.WindowFullScreen)
        Me.Size = My.Settings.DefaultWindowSize
    End Sub

    Private Sub CompactToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCompact.Click
        Me.Size = New Size(My.Settings.DefaultCompactWindowWidth, Me.Height - Me.ClientSize.Height + Me.ToolStrip1.Height)
    End Sub

    Private Sub TimerSurface_DoubleClick(sender As Object, e As EventArgs)
        ShowTimerDialog(False)
    End Sub
    Private Sub TimerSurface_Click(sender As Object, e As EventArgs)
        If My.Settings.WindowFullScreen Then
            ExitFullScreen()
        End If
    End Sub

    Private Sub ToolStripButtonStartPause_Click(sender As Object, e As EventArgs) Handles ToolStripButtonStartPause.Click
        SetTimerState(Not timer.Enabled)
    End Sub
    Private Sub FullScreenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemFullScreen.Click
        My.Settings.WindowFullScreen = True
        My.Settings.WindowMaximized = False
        GoFullscreen(My.Settings.WindowFullScreen)
        Me.Focus()
    End Sub
#End Region



#Region "Helper Methods"
    Private Sub HideNote()
        noteObject.Visible = False
        timerObject.Visible = True
    End Sub

    Private Sub ShowNote()
        noteObject.Visible = True
        timerObject.Visible = False
    End Sub
    Private Sub LoadLanguage()
        Try
            Common.Languages.SetUICulture(My.Settings.Language)
        Catch ex As Exception
            My.Settings.Language = My.Settings.DefaultLanguage
        End Try
        Common.SetStrings()
    End Sub
    Private Sub ExitFullScreen()
        My.Settings.WindowFullScreen = False
        My.Settings.WindowMaximized = False
        GoFullscreen(My.Settings.WindowFullScreen)
    End Sub
    Private Sub RemoveTimerHandlers()
        RemoveHandler timer.Started, AddressOf Timer_Started
        RemoveHandler timer.Paused, AddressOf Timer_Paused
        RemoveHandler timer.Expired, AddressOf Timer_Expired
        RemoveHandler timer.Restarted, AddressOf Timer_Restarted
    End Sub
    Private Sub AddTimerHandlers()
        AddHandler timer.Started, AddressOf Timer_Started
        AddHandler timer.Paused, AddressOf Timer_Paused
        AddHandler timer.Expired, AddressOf Timer_Expired
        AddHandler timer.Restarted, AddressOf Timer_Restarted
    End Sub
    Private Sub ShutDownRendering()
        updateCancellationTokenSource.Cancel()
        Task.WaitAll()
        PanelTimer.Controls.Clear()

        timerSurface.Dispose()

        Task.WaitAll()
    End Sub
    Private Sub StartUpRendering(ByRef timer As Eggzle.CodeIsle.Timers.AlarmTimer)
        updateCancellationTokenSource = New System.Threading.CancellationTokenSource

        backgroundObject = New ClearRenderObject(Common.Look.BackgroundColor, True)

        stringFormat = New StringFormat(System.Drawing.StringFormat.GenericTypographic)
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        timerObject = New TimerTextRenderObject(timer, Common.Look.Font, Common.Look.DisplayFormat, New TimeFormat, Common.Look.SizeToFit, Common.Look.ForegroundColor, stringFormat, True)
        noteObject = New TextRenderObject(Common.Time.Note, Common.Look.Font, Common.Look.SizeToFit, Common.Look.ForegroundColor, stringFormat, False)

        Dim objects As New List(Of IRenderObject)

        objects.Add(backgroundObject)
        objects.Add(timerObject)
        objects.Add(noteObject)
        renderer = New Renderer(objects)
        timerSurface = Rendering.SurfaceFactory.CreateInstance(renderer, Common.Framerate)

        AddHandler timerSurface.DoubleClick, AddressOf TimerSurface_DoubleClick
        AddHandler timerSurface.Click, AddressOf TimerSurface_Click
        timerSurface.Dock = DockStyle.Fill
        PanelTimer.Controls.Add(timerSurface)

        'renderer = New RendererManager(rendererInstance, context, timerSurface, False)
        Task.Factory.StartNew(Sub() FormMainProgressUpdateAsync(updateCancellationTokenSource.Token), updateCancellationTokenSource.Token, TaskCreationOptions.LongRunning)
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

    Private Async Sub FormMainProgressUpdateAsync(token As System.Threading.CancellationToken)
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
                                            End If
                                            If (Not Common.Time.Note = String.Empty) Then
                                                If (Not timer.IsExpired) Then
                                                    sb.Append(" - ")
                                                End If
                                                sb.Append(Common.Time.Note)
                                            End If
                                            Me.Text = sb.ToString
                                            Await TaskEx.Delay(Common.Framerate)
                                        End While
                                    End Function, token, TaskCreationOptions.None, uiScheduler)
    End Sub

    Private Sub UpdateIcons()
        ToolStripButtonStartPause.Image = If(timer.IsPaused, My.Resources.play_green, My.Resources.pause_green)
    End Sub
    Private Sub UpdateUI()
        ToolStripButtonStartPause.Enabled = Not timer.IsExpired
        ToolStripButtonStartPause.Text = If(timer.IsPaused, My.Resources.Strings.Start, My.Resources.Strings.Pause)
        Me.Opacity = Common.Look.Opacity / 100
    End Sub

    Private Sub LoadSettings()
        ' Load setting files
        Try
            Common.Look.Load()
            Common.Time.Load()
            Common.Tasks.Load()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
            Environment.FailFast(ex.Message, ex)
        End Try

        ' Fixes taskbar showing issue
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = True


        Me.ToolStripMenuItemAlwaysOnTop.Checked = My.Settings.AlwaysOnTop
        Me.TopMost = Me.ToolStripMenuItemAlwaysOnTop.Checked
        ' Me.Opacity = Common.Look.Opacity / 100

        Me.Size = My.Settings.WindowSize
        If My.Settings.WindowMaximized Then
            Me.WindowState = FormWindowState.Maximized
        End If
        If My.Settings.WindowFullScreen Then
            GoFullscreen(True)
        End If

        Me.ToolStripButtonReset.Text = My.Resources.Strings.Reset

        ' Get rid of selection on toolstrip.
        Me.Focus()
    End Sub

    Public Sub ShowTimerDialog(editing As Boolean)
        DialogTimerSettings.Editing = editing
        If (DialogTimerSettings.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
            RemoveTimerHandlers()
            Dim alarm As Alarm = Nothing
            Try
                alarm = New Alarm(Common.GetAlarmPath(Common.Time.AlarmPath), Common.Time.AlarmVolume, Common.Time.AlarmLoop)
            Catch ex As Exception

            End Try
            If (Not editing) Then
                timer.Dispose()
                timer = TimerFactory.CreateInstance(Common.Time.Duration, Common.Time.CountUp, Common.Time.Restarts, alarm, Common.Time.AlarmEnabled)
            Else
                timer.Alarm = alarm
                timer.AlarmEnabled = Common.Time.AlarmEnabled
            End If
            timerObject.Timer = timer
            noteObject.Text = Common.Time.Note
            AddTimerHandlers()
            HideNote()
            If Common.Time.AutoStart Then
                SetTimerState(True)
            End If
            Me.UpdateIcons()
        End If
    End Sub

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
#End Region

    Private Sub AboutEggzeyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAboutEggzle.Click
        DialogAbout.ShowDialog(Me)
    End Sub

    Private Sub ToolStripMenuItemNewTimer_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemNewTimer.Click
        ShowTimerDialog(False)
    End Sub

    Private Sub ToolStripButtonNewTimer_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNewTimer.Click
        ShowTimerDialog(False)
    End Sub

    Private Sub ToolStripMenuItemEditTimer_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEditTimer.Click
        ShowTimerDialog(True)
    End Sub

    Private Sub SaveSettings()
        ' Save setting files
        Try
            Common.Look.Save()
            Common.Time.Save()
            Common.Tasks.Save()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
            If MessageBox.Show("Eggzle failed to save one or more settings files. Would you like to try again? If you select ""No,"" Some changes since you last ran Eggzle will be lost.", My.Application.Info.AssemblyName, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                SaveSettings()
            End If
        End Try
    End Sub

End Class