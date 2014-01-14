Imports System.Windows.Forms
Imports ElanTimer.Prefs
Public Class DialogTimerSettings
    Public Property Editing As Boolean = False
    Dim alarmPlayer As Alarm
    Dim alarpPath As String
    Dim formLoaded As Boolean = False

    Private Sub LoadSettings()
        Dim duration = Preferences.Time.Duration

        NumericUpDownHours.Value = Math.Floor(duration.TotalHours)
        NumericUpDownMinutes.Value = duration.Minutes
        NumericUpDownSeconds.Value = duration.Seconds


        Me.CheckBoxCountUp.Checked = Preferences.Time.CountUp
        Me.CheckBoxStartImmediately.Checked = Preferences.Time.StartImmediately
        Me.NumericUpDownRestarts.Value = Preferences.Time.Restarts
        Me.CheckBoxAlarmSet.Checked = Preferences.Time.AlarmEnabled
        Me.CheckBoxLoop.Checked = Preferences.Time.AlarmLoop
        Me.NumericUpDownVolume.Value = Preferences.Time.AlarmVolume
        Me.CheckBoxNote.Checked = Preferences.Time.HasNote
        Me.CheckBoxShowNoteAlertWhenTimerExpires.Checked = Preferences.Time.HasNoteAlert
        If (Not Editing) Then
            Preferences.Time.Note = String.Empty
        End If
        Me.TextBoxNote.DataBindings.Clear()
        Me.TextBoxNote.DataBindings.Add("Text", Preferences.Time, "Note", True, DataSourceUpdateMode.OnPropertyChanged)

        Me.ComboBoxAlarmPath.ValueMember = "FileName"
        Me.ComboBoxAlarmPath.DisplayMember = "Name"

        Dim alarms As List(Of AlarmModel) = Common.GetAlarms

        Me.ComboBoxAlarmPath.DataSource = alarms

        If alarms.Contains(New AlarmModel(System.IO.Path.GetFileNameWithoutExtension(Preferences.Time.AlarmPath), Preferences.Time.AlarmPath)) Then
            Me.ComboBoxAlarmPath.SelectedValue = Preferences.Time.AlarmPath
        ElseIf My.Computer.FileSystem.FileExists(Preferences.Time.AlarmPath) Then
            ComboBoxAlarmPath.SelectedIndex = -1
            Me.ComboBoxAlarmPath.Text = Preferences.Time.AlarmPath
        Else
            Try
                ComboBoxAlarmPath.SelectedIndex = 0
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub SaveSettings()
        Preferences.Time.Duration = New TimeSpan(0, NumericUpDownHours.Value, NumericUpDownMinutes.Value, NumericUpDownSeconds.Value)
        Preferences.Time.CountUp = Me.CheckBoxCountUp.Checked
        Preferences.Time.StartImmediately = Me.CheckBoxStartImmediately.Checked
        Preferences.Time.Restarts = Me.NumericUpDownRestarts.Value
        Preferences.Time.AlarmEnabled = Me.CheckBoxAlarmSet.Checked
        Preferences.Time.AlarmPath = Me.ComboBoxAlarmPath.Text
        Preferences.Time.AlarmLoop = Me.CheckBoxLoop.Checked
        Preferences.Time.AlarmVolume = Me.NumericUpDownVolume.Value
        Preferences.Time.Note = Me.TextBoxNote.Text.Trim
        Preferences.Time.HasNote = Me.CheckBoxNote.Checked
        Preferences.Time.HasNoteAlert = CheckBoxShowNoteAlertWhenTimerExpires.Checked
        UpdateAlarmPath()
    End Sub


    Private Sub DialogTimerSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not alarmPlayer Is Nothing Then
            alarmPlayer.Dispose()
            alarmPlayer = Nothing
        End If
        If Not Me.DialogResult = Windows.Forms.DialogResult.OK Then
            Preferences.Time.CancelEdit()
        End If
        Preferences.Time.EndEdit()
    End Sub



    Private Sub DialogTimer_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler Application.Idle, AddressOf UpdateUI
        Preferences.Time.BeginEdit()
        LoadSettings()
    End Sub


    Private Sub ButtonImport_Click(sender As Object, e As EventArgs) Handles ButtonLoad.Click
        Try
            Using openDialog As New OpenFileDialog
                openDialog.InitialDirectory = Preferences.TimePath
                openDialog.Filter = My.Settings.TimeDialogFilter
                openDialog.CheckFileExists = True
                If openDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Preferences.Time.ImportFrom(openDialog.FileName)
                    LoadSettings()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
        End Try
    End Sub

    Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles ButtonSaveAs.Click
        Try
            Using saveDialog As New SaveFileDialog
                saveDialog.InitialDirectory = Preferences.TimePath
                saveDialog.Filter = My.Settings.TimeDialogFilter
                saveDialog.OverwritePrompt = True
                If saveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    SaveSettings()
                    Preferences.Time.ExportTo(saveDialog.FileName)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
        End Try
    End Sub
    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        RemoveHandler Application.Idle, AddressOf UpdateUI
        SaveSettings()
        Preferences.Time.EndEdit()
    End Sub

    Private Sub ButtonAlarmPlay_Click(sender As Object, e As EventArgs) Handles ButtonAlarmPlay.Click
        UpdateAlarmPath()
        Preferences.Time.AlarmPath = Common.GetAlarmPath(Preferences.Time.AlarmPath)
        Try
            If Not alarmPlayer Is Nothing Then
                alarmPlayer.Dispose()
                alarmPlayer = Nothing
            End If
            alarmPlayer = New Alarm(Preferences.Time.AlarmPath, Me.NumericUpDownVolume.Value, False)
            alarmPlayer.Play()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonOpenAlarm_Click(sender As Object, e As EventArgs) Handles ButtonOpenAlarm.Click
        Try
            Using openDialog As New OpenFileDialog
                openDialog.Filter = My.Settings.AlarmDialogFilter
                openDialog.CheckFileExists = True
                If openDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    ComboBoxAlarmPath.SelectedIndex = -1
                    Me.ComboBoxAlarmPath.Text = openDialog.FileName
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
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
        Me.ButtonLoad.Enabled = (Not Editing)
        Me.Text = If(Editing, "Edit Timer", "New Timer")
        Me.CheckBoxCountUp.Enabled = (Not Editing)

        Me.ComboBoxAlarmPath.Enabled = Me.CheckBoxAlarmSet.Checked
        Me.CheckBoxLoop.Enabled = Me.ComboBoxAlarmPath.Enabled
        Me.ButtonAlarmPlay.Enabled = Me.CheckBoxLoop.Enabled
        Me.ButtonOpenAlarm.Enabled = Me.ButtonAlarmPlay.Enabled
        Me.ButtonOK.Enabled = (Me.NumericUpDownHours.Value Or Me.NumericUpDownMinutes.Value Or Me.NumericUpDownSeconds.Value)

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub UpdateAlarmPath()
        If My.Computer.FileSystem.FileExists(Me.ComboBoxAlarmPath.Text) Then
            Preferences.Time.AlarmPath = Me.ComboBoxAlarmPath.Text
        ElseIf My.Computer.FileSystem.FileExists(Common.GetAlarmPath(ComboBoxAlarmPath.SelectedValue)) Then
            Preferences.Time.AlarmPath = Me.ComboBoxAlarmPath.SelectedValue
        Else
            Try
                Preferences.Time.AlarmPath = CType(Me.ComboBoxAlarmPath.Items(0), AlarmModel).FileName
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub NumericUpDownVolume_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownVolume.ValueChanged
        Try
            alarmPlayer.Volume = NumericUpDownVolume.Value
        Catch ex As Exception

        End Try
    End Sub
End Class
