Imports System.Windows.Forms
Imports ElanTimer.Prefs
Imports System.IO
Imports PropertyChanged

<ImplementPropertyChanged>
Public Class TimerSettingsDialog

    Dim _alarmsPath As String

    Public Property Editing As Boolean = False
    Dim alarmPlayer As Alarm
    Private time As New TimeModel()
    Private toolTip As New ToolTip()

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
            Return Duration.Hours
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
    Public Property NoteEnabled As Boolean
        Get
            Return time.NoteEnabled
        End Get
        Set(value As Boolean)
            time.NoteEnabled = value
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
            ComboBoxAlarmPath.DataSource = Utils.GetAlarms(AlarmsPath)
        End Set
    End Property
    Public Property SelectedAlarm As String
        Get
            Return time.AlarmName
        End Get
        Set(value As String)
            time.AlarmName = value
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
    Public Property AlarmFilter As String

    Public Sub Initialize()

        NumericUpDownHours.DataBindings.Add("Value", Me, "Hours")
        NumericUpDownMinutes.DataBindings.Add("Value", Me, "Minutes")
        NumericUpDownSeconds.DataBindings.Add("Value", Me, "Seconds")
        NumericUpDownRestarts.DataBindings.Add("Value", time, "Restarts")
        CheckBoxCountUp.DataBindings.Add("Checked", time, "CountUp")

        CheckBoxNote.DataBindings.Add("Checked", time, "NoteEnabled")
        TextBoxNote.DataBindings.Add("Text", time, "Note")
        CheckBoxShowNoteAlertWhenTimerExpires.DataBindings.Add("Checked", time, "AlertEnabled")

        CheckedGroupBox1.DataBindings.Add("Checked", time, "AlarmEnabled")
        ComboBoxAlarmPath.DataBindings.Add("SelectedValue", time, "AlarmName")
        TrackBarVolume.DataBindings.Add("Value", time, "AlarmVolume")
        CheckBoxLoop.DataBindings.Add("Checked", time, "AlarmLoop")
    End Sub

    Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
        DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub ButtonAlarmPlay_Click(sender As Object, e As EventArgs) Handles ButtonAlarmPlay.Click
        Try
            If (alarmPlayer IsNot Nothing AndAlso alarmPlayer.Playing) Then
                alarmPlayer.Stop()
            Else
                If alarmPlayer IsNot Nothing Then
                    RemoveHandler alarmPlayer.PlaybackStopped, AddressOf AlarmPlayer_PlaybackStopped
                    alarmPlayer.Dispose()
                    alarmPlayer = Nothing
                End If
                alarmPlayer = New Alarm(Path.Combine(AlarmsPath, SelectedAlarm), AlarmVolume, False)
                AddHandler alarmPlayer.PlaybackStopped, AddressOf AlarmPlayer_PlaybackStopped
                alarmPlayer.Play()
                ButtonAlarmPlay.Image = My.Resources.stop_red
            End If
        Catch ex As Exception

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
        Me.TextBoxNote.Enabled = Me.CheckBoxNote.Checked
        Me.CheckBoxShowNoteAlertWhenTimerExpires.Enabled = Me.CheckBoxNote.Checked
        Me.Text = If(Editing, "Edit", "New")
        Me.GroupBoxDuration.Enabled = Not Editing


        Me.ComboBoxAlarmPath.Enabled = Me.CheckedGroupBox1.Checked
        Me.CheckBoxLoop.Enabled = Me.ComboBoxAlarmPath.Enabled
        Me.ButtonAlarmPlay.Enabled = Me.CheckBoxLoop.Enabled
        Me.ButtonSet.Enabled = (Me.NumericUpDownHours.Value Or Me.NumericUpDownMinutes.Value Or Me.NumericUpDownSeconds.Value)
        Me.ButtonStart.Enabled = (Me.ButtonSet.Enabled And Not Editing)

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub NumericUpDownVolume_ValueChanged(sender As Object, e As EventArgs)
        Try
            alarmPlayer.Volume = TrackBarVolume.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonSet_Click(sender As Object, e As EventArgs) Handles ButtonSet.Click

    End Sub

    Private Sub DialogTimerSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RemoveHandler Application.Idle, AddressOf UpdateUI
    End Sub

    Private Sub TimerSettingsDialog_Invalidated(sender As Object, e As InvalidateEventArgs) Handles Me.Invalidated

    End Sub

    Private Sub DialogTimerSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Initialize()
        AddHandler Application.Idle, AddressOf UpdateUI
    End Sub

    Private Sub ButtonOptions_Click(sender As Object, e As EventArgs) Handles ButtonOptions.Click
        ContextMenuOptions.Show(ButtonOptions, New Point(0, ButtonOptions.Height))
    End Sub

    Private Sub MenuItemLoadPreset_Click(sender As Object, e As EventArgs) Handles MenuItem1.Click
        Using openDialog As New OpenFileDialog
            openDialog.InitialDirectory = ""
            openDialog.Filter = AlarmFilter
            openDialog.CheckFileExists = True
            If (openDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
                RaiseEvent Loading(Me, New LoadingEventArgs(openDialog.FileName))
            End If
        End Using

        ' TODO: Move code out of class.
        'Try
        '    Using openDialog As New OpenFileDialog
        '        openDialog.InitialDirectory = ""
        '        openDialog.Filter = AlarmFilter
        '        openDialog.CheckFileExists = True
        '        If (openDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
        '            Using input As Stream = File.OpenRead(openDialog.FileName)
        '                time.Import(input)
        '                Me.AlarmEnabled = time.AlarmEnabled
        '                Me.time.AlarmLoop = time.AlarmLoop
        '                Me.SelectedAlarm = time.AlarmName
        '                Me.AlarmVolume = time.AlarmVolume
        '                Me.ShowAlertBoxOnTimerExpiration = time.AlertEnabled
        '                Me.CountUp = time.CountUp
        '                Me.NumericUpDownHours.Value = time.Duration.Hours
        '                Me.NumericUpDownMinutes.Value = time.Duration.Minutes
        '                Me.NumericUpDownSeconds.Value = time.Duration.Seconds
        '                Me.Note = time.Note
        '                Me.NoteEnabled = time.NoteEnabled
        '                Me.Restarts = time.Restarts
        '            End Using
        '        End If
        '    End Using
        'Catch ex As Exception
        '    MessageBox.Show("Failed to load preset.", My.Application.Info.AssemblyName)
        'End Try
    End Sub

    Private Sub MenuItemSavePresetAs_Click(sender As Object, e As EventArgs) Handles MenuItemSavePresetAs.Click
        Using saveDialog As New SaveFileDialog
            saveDialog.InitialDirectory = ""
            saveDialog.Filter = My.Settings.TimeDialogFilter
            saveDialog.OverwritePrompt = True
            If saveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                RaiseEvent Saving(Me, New SavingEventArgs(saveDialog.FileName))
            End If
        End Using

        ' TODO: Move code out of class.
        'Try
        '    Using saveDialog As New SaveFileDialog
        '        saveDialog.InitialDirectory = ""
        '        saveDialog.Filter = My.Settings.TimeDialogFilter
        '        saveDialog.OverwritePrompt = True
        '        If saveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        '            Using output As Stream = File.OpenWrite(saveDialog.FileName)
        '                time.Export(output)
        '            End Using
        '        End If
        '    End Using
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
        'End Try
    End Sub

    Private Sub TrackBarVolume_Scroll(sender As Object, e As EventArgs) Handles TrackBarVolume.Scroll
        toolTip.SetToolTip(TrackBarVolume, TrackBarVolume.Value.ToString())
    End Sub

    Private Sub TrackBarVolume_ValueChanged(sender As Object, e As EventArgs) Handles TrackBarVolume.ValueChanged
        Try
            alarmPlayer.Volume = TrackBarVolume.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AlarmPlayer_PlaybackStopped(sender As Object, e As NAudio.Wave.StoppedEventArgs)
        alarmPlayer.Stop()
        ButtonAlarmPlay.Image = My.Resources.play_blue
    End Sub

    Public Event Saving As EventHandler(Of SavingEventArgs)
    Public Event Loading As EventHandler(Of LoadingEventArgs)
End Class
