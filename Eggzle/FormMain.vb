Imports Microsoft.WindowsAPICodePack.Shell.Taskbar
Imports Mono.Addins
Public Class FormMain
    Private renderer As RendererManager
    Public context As Information.TimerInfo
    Public invalidatorCancellationTokenSource As System.Threading.CancellationTokenSource
    Public timerSurface As PictureBox
    Private Const RenderRate As Integer = 1000 / 30
    Private progressBar As ProgressBarExt
    Private uiScheduler As TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext()

#If DEBUG Then
    Private sw As New Stopwatch ' Used for benchmark and testing.
#End If

    Public timer As CodeIsle.Timers.AlarmTimer

#Region "Timer Events"
    Public Sub Timer_Started(sender As Object, e As TimerEventArgs)
        ExecuteActions(Settings.Models.TimerEvent.Started)
    End Sub
    Public Sub Timer_Paused(sender As Object, e As TimerEventArgs)
        ExecuteActions(Settings.Models.TimerEvent.Paused)
        progressBar.State = TaskbarButtonProgressState.Paused
    End Sub
    Public Sub Timer_Restarted(sender As Object, e As TimerEventArgs)
        ExecuteActions(Settings.Models.TimerEvent.Restarted)
    End Sub
    Public Sub Timer_Expired(sender As Object, e As TimerEventArgs)
        ExecuteActions(Settings.Models.TimerEvent.Expired)
    End Sub

    Public Sub ExecuteActions(e As Settings.Models.TimerEvent)
        Task.Run(Sub()

                     Dim actions = From action In Common.Settings.Actions
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



    Private Sub FormMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ShutDownRendering()
        Common.Settings.Save()
    End Sub

    Private Sub ShutDownRendering()
        context = Nothing
        PanelTimer.Controls.Clear()
        timerSurface.Dispose()
        RemoveHandler timer.Started, AddressOf Timer_Started
        RemoveHandler timer.Paused, AddressOf Timer_Paused
        RemoveHandler timer.Expired, AddressOf Timer_Expired
        RemoveHandler timer.Restarted, AddressOf Timer_Restarted
        invalidatorCancellationTokenSource.Cancel()
        Task.WaitAll()
    End Sub
    Private Sub StartUpRendering(ByRef timer As Eggzle.CodeIsle.Timers.AlarmTimer)
        context = New Information.TimerInfo(timer)
        invalidatorCancellationTokenSource = New System.Threading.CancellationTokenSource

        Dim node As TypeExtensionNode(Of EggzleLib.RendererAttribute) = AddinManager.GetExtensionNodes(GetType(EggzleLib.Extend.Rendering.IRenderer))(0)
        'Dim rendererInstance As EggzleLib.Extend.Rendering.IRenderer = node.CreateInstance
        timerSurface = Extend.Rendering.SurfaceFactory.CreateInstance(node.CreateInstance, New Information.TimerInfo(timer), Common.RenderInfo)
        timerSurface.Dock = DockStyle.Fill
        PanelTimer.Controls.Add(timerSurface)

        'renderer = New RendererManager(rendererInstance, context, timerSurface, False)
        Task.Run(Sub() FormMainTextUpdaterAsync(invalidatorCancellationTokenSource.Token), invalidatorCancellationTokenSource.Token)
        Task.Run(Sub() FormMainProgressUpdateAsync(invalidatorCancellationTokenSource.Token), invalidatorCancellationTokenSource.Token)
        AddHandler timer.Started, AddressOf Timer_Started
        AddHandler timer.Paused, AddressOf Timer_Paused
        AddHandler timer.Expired, AddressOf Timer_Expired
        AddHandler timer.Restarted, AddressOf Timer_Restarted
    End Sub


    Private Sub Started(sender As Object, e As TimerEventArgs)
        sw.Start()
    End Sub
    Private Sub Stopped(sender As Object, e As TimerEventArgs)
        sw.Stop()
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonStartPause.Click

        'System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("fr-FR")
        Try
            'tmr = New codeisle.Timer(New TimeSpan(0, 0, 60), "C:\Users\Michael\Music\Sound FX\83280__corsica-s__80s-alarm_loop.wav")
            'If timer.Enabled Then
            '    timer.Stop()
            'Else
            '    timer.Start()
            'End If
            'timer.Start()
            If timer.IsPaused Then
                progressBar.State = TaskbarButtonProgressState.Normal
                timer.Start()
            Else
                progressBar.State = TaskbarButtonProgressState.Paused
                timer.Pause()
            End If
        Catch ex As Exception
            Throw ex
        End Try
        UpdateIcons()
    End Sub
    Private Sub ConfigureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormSettings.ShowDialog()
    End Sub
    Private Sub ToolStripSplitButtonSettings_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButtonSettings.ButtonClick
        Common.Settings_Click()
    End Sub

    Private Async Sub FormMainProgressUpdateAsync(token As System.Threading.CancellationToken)
        While Not token.IsCancellationRequested
            Await Task.Delay(500)
            Task.Factory.StartNew(Sub()
                                      progressBar.CurrentValue = (timer.Elapsed.TotalMilliseconds / timer.Duration.TotalMilliseconds) * 100
                                  End Sub, System.Threading.CancellationToken.None, TaskCreationOptions.None, uiScheduler)

        End While
    End Sub

    Private Async Sub FormMainTextUpdaterAsync(token As System.Threading.CancellationToken)
        While Not token.IsCancellationRequested
            Await Task.Delay(RenderRate)
            Task.Factory.StartNew(Sub()
                                      If Not token.IsCancellationRequested Then
                                          Me.Text = String.Concat(New String() {"(", timer.Current.ToString("hh\:mm\:ss"), ") """, "memo here""", " - ", My.Application.Info.AssemblyName})
                                      End If
                                  End Sub, System.Threading.CancellationToken.None, TaskCreationOptions.None, uiScheduler)

        End While

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        timer.Reset()
        UpdateIcons()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        'TODO: FIX DialogTimer.TextBoxTime.Text = timer.Duration.ToString("hh\:mm\:ss")
        DialogTimer.ShowDialog(Me)
        'Dim result = DialogTimer.ShowDialog(Me)
        'If result = Windows.Forms.DialogResult.OK Then
        '    Dim time As TimeSpan
        '    TimeSpan.TryParse(DialogTimer.TextBoxTime.Text, time)
        '    ShutDownRendering()
        '    timer.Dispose()
        '    'timer = New CodeIsle.Timers.CountDownAlarmTimer(time, "C:\Users\Michael\Music\Sound FX\83280__corsica-s__80s-alarm_loop.wav")
        '    timer = New CodeIsle.Timers.CountDownAlarmTimer(time, "C:\Users\Michael\Music\Sound FX\56229__pera__3beeps.wav")
        '    StartUpRendering(timer)
        'End If
        'UpdateIcons()
    End Sub

    Private Sub AlwaysOnTopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlwaysOnTopToolStripMenuItem.Click
        Me.TopMost = CType(sender, ToolStripMenuItem).Checked
        My.Settings.AlwaysOnTop = Me.AlwaysOnTopToolStripMenuItem.Checked
    End Sub

    Private Sub UpdateIcons()
        ToolStripButtonStartPause.Image = If(timer.IsPaused, My.Resources.play_green, My.Resources.pause_green)
    End Sub
    Private Sub UpdateUI()
        ToolStripButtonStartPause.Enabled = Not timer.IsExpired
    End Sub

    Private Sub WireDatabaseValues()
        Me.AlwaysOnTopToolStripMenuItem.Checked = My.Settings.AlwaysOnTop
        Me.TopMost = Me.AlwaysOnTopToolStripMenuItem.Checked
        Me.Opacity = My.Settings.OpacityLevel / 100
    End Sub

    Private Sub ToolStrip1_MouseEnter(sender As Object, e As EventArgs) Handles ToolStrip1.MouseEnter
        Me.Focus()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddinManager.Initialize(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), My.Application.Info.AssemblyName), System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Addins"))
        AddinManager.Registry.Update()

        progressBar = New ProgressBarExt(Me)
        progressBar.MaxValue = 100

        timer = New CodeIsle.Timers.CountDownAlarmTimer(TimeSpan.Parse(Common.Settings.Time), "C:\Users\Michael\Music\Sound FX\56229__pera__3beeps.wav")

        AddHandler Application.Idle, AddressOf UpdateUI
        StartUpRendering(timer)
        WireDatabaseValues()
    End Sub
End Class
