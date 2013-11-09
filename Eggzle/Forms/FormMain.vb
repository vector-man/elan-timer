Imports Microsoft.WindowsAPICodePack.Taskbar
Imports System.Threading

Public Class FormMain
    'Private renderer As RendererManager
    Public context As Information.TimerInfo
    Public updateCancellationTokenSource As System.Threading.CancellationTokenSource
    Public timerSurface As Rendering.Surface
    Private Const RenderRate As Integer = 1000 / 30
    Private uiScheduler As TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext()

    Private ReadOnly EscapeKeyChar = Convert.ToChar(27)
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
    End Sub
    Public Sub Timer_Expired(sender As Object, e As TimerEventArgs)
        ExecuteActions(Settings.Models.TimerEvent.Expired)
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

        AddHandler Application.Idle, AddressOf UpdateUI
    End Sub
    Private Sub GlobalSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemConfiguration.Click
        Common.Settings_Click()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemExit.Click
        Me.Close()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemLook.Click
        Try
            DialogLookSettings.ShowDialog(Me)
            ShutDownRendering()
            StartUpRendering(timer)
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
    Private Sub ShutDownRendering()
        updateCancellationTokenSource.Cancel()
        Task.WaitAll()
        context = Nothing
        PanelTimer.Controls.Clear()
        RemoveHandler timerSurface.DoubleClick, AddressOf TimerSurface_DoubleClick
        timerSurface.Dispose()
        RemoveHandler timer.Started, AddressOf Timer_Started
        RemoveHandler timer.Paused, AddressOf Timer_Paused
        RemoveHandler timer.Expired, AddressOf Timer_Expired
        RemoveHandler timer.Restarted, AddressOf Timer_Restarted
        Task.WaitAll()
    End Sub
    Private Sub StartUpRendering(ByRef timer As Eggzle.CodeIsle.Timers.AlarmTimer)
        context = New Information.TimerInfo(timer)
        updateCancellationTokenSource = New System.Threading.CancellationTokenSource

        timerSurface = Rendering.SurfaceFactory.CreateInstance(New EggzleRenderer, New RenderArgs(
                                                                          Nothing,
                                                                          Nothing,
                                                                          Common.Look.Font,
                                                                          Common.Look.BackgroundColor,
                                                                          Common.Look.ForegroundColor,
                                                                          Common.Look.SizeToFit,
                                                                          New Information.TimerInfo(timer),
                                                                          New TimeFormat,
                                                                          "v"
                                                                          ))
                                                                          "d",

        AddHandler timerSurface.DoubleClick, AddressOf TimerSurface_DoubleClick
        AddHandler timerSurface.Click, AddressOf TimerSurface_Click
        timerSurface.Dock = DockStyle.Fill
        PanelTimer.Controls.Add(timerSurface)

        'renderer = New RendererManager(rendererInstance, context, timerSurface, False)
        Task.Factory.StartNew(Sub() FormMainTextUpdaterAsync(updateCancellationTokenSource.Token), updateCancellationTokenSource.Token, TaskCreationOptions.LongRunning)
        Task.Factory.StartNew(Sub() FormMainProgressUpdateAsync(updateCancellationTokenSource.Token), updateCancellationTokenSource.Token, TaskCreationOptions.LongRunning)
        AddHandler timer.Started, AddressOf Timer_Started
        AddHandler timer.Paused, AddressOf Timer_Paused
        AddHandler timer.Expired, AddressOf Timer_Expired
        AddHandler timer.Restarted, AddressOf Timer_Restarted
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
        Dim currentProgressValue As Long
        While Not token.IsCancellationRequested
            Await TaskEx.Delay(500)
            Await Task.Factory.StartNew(Sub()
                                            currentProgressValue = (timer.Elapsed.TotalMilliseconds / timer.Duration.TotalMilliseconds) * 100
                                            If TaskbarManager.IsPlatformSupported Then
                                                TaskbarManager.Instance.SetProgressValue(currentProgressValue, 100, Me.Handle)
                                            End If
                                            ProgressBarMain.Value = currentProgressValue
                                        End Sub, System.Threading.CancellationToken.None, TaskCreationOptions.None, uiScheduler)

        End While

    End Sub

    Private Async Sub FormMainTextUpdaterAsync(token As System.Threading.CancellationToken)
        While Not token.IsCancellationRequested
            Await TaskEx.Delay(RenderRate)
            Await Task.Factory.StartNew(Sub()
                                            If Not token.IsCancellationRequested Then
                                                'Me.Text = String.Format("[{0}] - {1} - {2}", EggzleLib.TimeFormatter.Format(timer.Current), If((Common.Time.Memo = 0), String.Empty, String.Concat("""", Common.Time.Memo, """")), My.Application.Info.AssemblyName) ' String.Concat(New String() {"(", EggzleLib.TimeFormatter.Format(timer.Current), ") """, """", " - ", My.Application.Info.AssemblyName})
                                                Me.Text = String.Concat("[", String.Format(New TimeFormat, "{0}", timer.Current), "] - ", If((Common.Time.Memo = String.Empty), String.Empty, String.Concat("""", Common.Time.Memo, """ - ")), My.Application.Info.AssemblyName)
                                            End If
                                        End Sub, System.Threading.CancellationToken.None, TaskCreationOptions.None, uiScheduler)

        End While

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
            ShutDownRendering()
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
            If Common.Time.AutoStart Then
                SetTimerState(True)
            End If
            Me.UpdateIcons()
            StartUpRendering(timer)
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