Imports System.Windows.Forms
Imports System.IO
Imports PropertyChanged
Imports NLog
<ImplementPropertyChanged>
Public Class TimerSettingsDialog

    Dim _alarmsPath As String

    Public Property Editing As Boolean = False
    Dim alarmPlayer As Alarm
    Private time As New TimeModel()
    Private toolTip As New ToolTip()

    ' Logging
    Private Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Public Property Duration As TimeSpan
        Get
            Return time.Duration
        End Get
        Set(value As TimeSpan)
            time.Duration = value
        End Set
    End Property
    Public Property Hours As Integer
        Get
            Return Math.Floor(Duration.TotalHours)
        End Get
        Set(value As Integer)
            Duration = New TimeSpan(value, Minutes, Seconds)
        End Set
    End Property
    Public Property Minutes As Integer
        Get
            Return Duration.Minutes
        End Get
        Set(value As Integer)
            Duration = New TimeSpan(Hours, value, Seconds)
        End Set
    End Property
    Public Property Seconds As Integer
        Get
            Return Duration.Seconds
        End Get
        Set(value As Integer)
            Duration = New TimeSpan(Hours, Minutes, value)
        End Set
    End Property



    Public Property Restarts As Integer
        Get
            Return time.Restarts
        End Get
        Set(value As Integer)
            time.Restarts = value
        End Set
    End Property
    Public Property CountUp As Boolean
        Get
            Return time.CountUp
        End Get
        Set(value As Boolean)
            time.CountUp = value
        End Set
    End Property
    Public Property Note As String
        Get
            Return time.Note
        End Get
        Set(value As String)
            time.Note = value
        End Set
    End Property
    Public Property ShowAlertBoxOnTimerExpiration As Boolean
        Get
            Return time.AlertEnabled
        End Get
        Set(value As Boolean)
            time.AlertEnabled = value
        End Set
    End Property
    Public Property AlarmEnabled As Boolean
        Get
            Return time.AlarmEnabled
        End Get
        Set(value As Boolean)
            time.AlarmEnabled = value
        End Set
    End Property
    Public Property AlarmsPath As String
        Get
            Return _alarmsPath
        End Get
        Set(value As String)
            _alarmsPath = value
            ComboBoxAlarmPath.DisplayMember = "Key"
            ComboBoxAlarmPath.ValueMember = "Value"
            ComboBoxAlarmPath.DataSource = GetAlarmsByPath(AlarmsPath)

        End Set
    End Property
    Public Property SelectedAlarm As String
        Get
            Return time.AlarmName
        End Get
        Set(value As String)
            time.AlarmName = value
            UpdateAlarmPlayer(TryCast(ComboBoxAlarmPath.SelectedValue, String))
        End Set
    End Property
    Public Property AlarmVolume As Integer
        Get
            Return time.AlarmVolume
        End Get
        Set(value As Integer)
            time.AlarmVolume = value
        End Set
    End Property
    Public Property AlarmLoop As Boolean
        Get
            Return time.AlarmLoop
        End Get
        Set(value As Boolean)
            time.AlarmLoop = value
        End Set
    End Property
    Public Property FileFilter As String
    Public Property InitialDirectory

    Public Sub Initialize()

        NumericUpDownHours.DataBindings.Add("Value", Me, "Hours")
        NumericUpDownMinutes.DataBindings.Add("Value", Me, "Minutes")
        NumericUpDownSeconds.DataBindings.Add("Value", Me, "Seconds")
        NumericUpDownRestarts.DataBindings.Add("Value", time, "Restarts")
        CheckBoxCountUp.DataBindings.Add("Checked", time, "CountUp")

        TextBoxNote.DataBindings.Add("Text", time, "Note")
        CheckBoxShowNoteAlertWhenTimerExpires.DataBindings.Add("Checked", time, "AlertEnabled")

        CheckedGroupBox1.DataBindings.Add("Checked", time, "AlarmEnabled")
        ComboBoxAlarmPath.DataBindings.Add("SelectedValue", time, "AlarmName")
        TrackBarVolume.DataBindings.Add("Value", time, "AlarmVolume")
        CheckBoxLoop.DataBindings.Add("Checked", time, "AlarmLoop")

        SetStrings()
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        Me.StartPosition = If(Owner Is Nothing, FormStartPosition.CenterScreen, FormStartPosition.CenterParent)
        Me.TopMost = True
        MyBase.OnLoad(e)
    End Sub

    Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
        DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub ButtonAlarmPlay_Click(sender As Object, e As EventArgs) Handles ButtonAlarmPlay.Click
        Try
            If (alarmPlayer IsNot Nothing) Then
                If (alarmPlayer.Playing) Then
                    alarmPlayer.Stop()
                Else
                    ButtonAlarmPlay.Image = My.Resources.stop_red
                    alarmPlayer.Play()
                End If
            End If
        Catch ex As Exception
            logger.Error(ex)
        End Try
    End Sub

    Private Sub UpdateUI(sender As Object, e As EventArgs)
        Me.LabelHours.Enabled = (Not Editing)
        Me.NumericUpDownHours.Enabled = (Not Editing)
        Me.LabelMinutes.Enabled = (Not Editing)
        Me.NumericUpDownMinutes.Enabled = (Not Editing)
        Me.LabelSeconds.Enabled = (Not Editing)
        Me.NumericUpDownSeconds.Enabled = (Not Editing)
        Me.LabelRestarts.Enabled = (Not Editing)
        Me.NumericUpDownRestarts.Enabled = (Not Editing)
        Me.Text = If(Editing, My.Resources.Strings.EditTimer, My.Resources.Strings.NewTimer)

        Me.GroupBoxDuration.Enabled = Not Editing


        Me.ComboBoxAlarmPath.Enabled = Me.CheckedGroupBox1.Checked
        Me.CheckBoxLoop.Enabled = Me.ComboBoxAlarmPath.Enabled
        Me.ButtonAlarmPlay.Enabled = Me.CheckBoxLoop.Enabled
        Me.ButtonSet.Enabled = (Me.NumericUpDownHours.Value Or Me.NumericUpDownMinutes.Value Or Me.NumericUpDownSeconds.Value)
        Me.ButtonStart.Enabled = (Me.ButtonSet.Enabled And Not Editing)
        Me.MenuItemLoadPreset.Enabled = (Not Editing)

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DialogTimerSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RemoveHandler Application.Idle, AddressOf UpdateUI
        UpdateAlarmPlayer(Nothing)
    End Sub

    Private Sub DialogTimerSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Initialize()
        AddHandler Application.Idle, AddressOf UpdateUI
    End Sub

    Private Sub ButtonOptions_Click(sender As Object, e As EventArgs) Handles ButtonOptions.Click
        ContextMenuOptions.Show(ButtonOptions, New Point(0, ButtonOptions.Height))
    End Sub

    Private Sub MenuItemLoadPreset_Click(sender As Object, e As EventArgs) Handles MenuItemLoadPreset.Click
        Using openDialog As New OpenFileDialog
            openDialog.InitialDirectory = InitialDirectory
            openDialog.Filter = FileFilter
            openDialog.CheckFileExists = True
            If (openDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
                RaiseEvent Loading(Me, New LoadingEventArgs(openDialog.FileName))
            End If
        End Using
    End Sub

    Private Sub MenuItemSavePresetAs_Click(sender As Object, e As EventArgs) Handles MenuItemSavePresetAs.Click
        Using saveDialog As New SaveFileDialog
            saveDialog.InitialDirectory = InitialDirectory
            saveDialog.Filter = My.Settings.TimeDialogFilter
            saveDialog.OverwritePrompt = True
            If saveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                RaiseEvent Saving(Me, New SavingEventArgs(saveDialog.FileName))
            End If
        End Using
    End Sub

    Private Sub TrackBarVolume_Scroll(sender As Object, e As EventArgs) Handles TrackBarVolume.Scroll
        toolTip.SetToolTip(TrackBarVolume, TrackBarVolume.Value.ToString())
    End Sub

    Private Sub TrackBarVolume_ValueChanged(sender As Object, e As EventArgs) Handles TrackBarVolume.ValueChanged
        Try
            If (alarmPlayer IsNot Nothing) Then
                alarmPlayer.Volume = TrackBarVolume.Value
            End If
        Catch ex As Exception
            logger.Error(ex)
        End Try
    End Sub

    Private Sub AlarmPlayer_PlaybackStopped(sender As Object, e As NAudio.Wave.StoppedEventArgs)
        ButtonAlarmPlay.Image = My.Resources.play_green
    End Sub

    Private Function GetAlarmsByPath(alarmPath As String) As List(Of KeyValuePair(Of String, String))
        Dim dict As New List(Of KeyValuePair(Of String, String))
        For Each alarm As String In My.Computer.FileSystem.GetFiles(AlarmsPath)
            dict.Add(New KeyValuePair(Of String, String)(Path.GetFileNameWithoutExtension(alarm), Path.GetFileName(alarm)))
        Next
        Return dict
    End Function

    Public Event Saving As EventHandler(Of SavingEventArgs)
    Public Event Loading As EventHandler(Of LoadingEventArgs)

    Private Sub SetStrings()
        Me.SuspendLayout()

        Me.CheckBoxShowNoteAlertWhenTimerExpires.Text = My.Resources.Strings.ShowAlertBoxWhenTimerExpires

        Me.GroupBoxDuration.Text = My.Resources.Strings.Duration
        Me.LabelHours.Text = My.Resources.Strings.Hours
        Me.LabelMinutes.Text = My.Resources.Strings.Minutes
        Me.LabelSeconds.Text = My.Resources.Strings.Seconds
        Me.LabelRestarts.Text = My.Resources.Strings.Restarts
        Me.CheckBoxCountUp.Text = My.Resources.Strings.CountUp

        Me.CheckedGroupBox1.Text = My.Resources.Strings.Alarm
        Me.Label2.Text = My.Resources.Strings.Sound
        Me.Label1.Text = My.Resources.Strings.Volume
        Me.CheckBoxLoop.Text = My.Resources.Strings.LoopAlarm
        Me.ButtonOptions.Text = My.Resources.Strings.Options
        Me.MenuItemLoadPreset.Text = My.Resources.Strings.LoadPreset
        Me.MenuItemSavePresetAs.Text = My.Resources.Strings.SavePresetAs

        Me.ButtonStart.Text = My.Resources.Strings.Start
        Me.ButtonSet.Text = My.Resources.Strings.SetTimer
        Me.ButtonCancel.Text = My.Resources.Strings.Cancel

        Me.ResumeLayout()
    End Sub

    Private Sub UpdateAlarmPlayer(alarmName As String)
        If (alarmPlayer IsNot Nothing) Then
            ButtonAlarmPlay.Image = My.Resources.play_green

            RemoveHandler alarmPlayer.PlaybackStopped, AddressOf AlarmPlayer_PlaybackStopped
            alarmPlayer.Dispose()
        End If

        If (alarmName IsNot Nothing) Then
            alarmPlayer = New Alarm(Path.Combine(AlarmsPath, alarmName), AlarmVolume, False)
            AddHandler alarmPlayer.PlaybackStopped, AddressOf AlarmPlayer_PlaybackStopped
        End If
    End Sub

    Private Sub ComboBoxAlarmPath_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAlarmPath.SelectedValueChanged
        Try
            UpdateAlarmPlayer(TryCast(ComboBoxAlarmPath.SelectedValue, String))
        Catch ex As Exception
            logger.Error(ex)
        End Try
    End Sub
End Class
