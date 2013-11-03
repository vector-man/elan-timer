Imports System.Windows.Forms
Imports Mono.Addins
Public Class DialogTimerSettings
    Public Property Editing As Boolean = False
    Dim alarmPlayer As Alarm
    Dim alarpPath As String
    Dim formLoaded As Boolean = False
    Public Sub UpdateStates(sender As Object, e As EventArgs)
        ButtonOK.Enabled = TextBoxTime.Text.Trim.Length > 0
        ComboBoxAlarmPath.Enabled = CheckBoxAlarmSet.Checked
        CheckBoxLoop.Enabled = ComboBoxAlarmPath.Enabled
        ButtonAlarmPlay.Enabled = CheckBoxLoop.Enabled
        ButtonOpenAlarm.Enabled = ButtonAlarmPlay.Enabled
    End Sub

    Private Sub LoadSettings()
        Me.TextBoxTime.Text = Common.Time.Duration.ToString
        Me.CheckBoxCountUp.Checked = Common.Time.CountUp
        Me.CheckBoxAutoStart.Checked = Common.Time.AutoStart
        Me.NumericUpDownRestarts.Value = Common.Time.Restarts
        Me.CheckBoxAlarmSet.Checked = Common.Time.AlarmEnabled
        Me.CheckBoxLoop.Checked = Common.Time.AlarmLoop
        Me.NumericUpDownVolume.Value = Common.Time.AlarmVolume

        Me.TextBoxMemo.DataBindings.Clear()
        Me.TextBoxMemo.DataBindings.Add("Text", Common.Time, "Memo", True, DataSourceUpdateMode.OnPropertyChanged)

        Me.ComboBoxAlarmPath.ValueMember = "FileName"
        Me.ComboBoxAlarmPath.DisplayMember = "Name"

        Dim alarms As List(Of AlarmModel) = Common.GetAlarms

        Me.ComboBoxAlarmPath.DataSource = alarms

        If alarms.Contains(New AlarmModel(System.IO.Path.GetFileNameWithoutExtension(Common.Time.AlarmPath), Common.Time.AlarmPath)) Then
            Me.ComboBoxAlarmPath.SelectedValue = Common.Time.AlarmPath
        ElseIf My.Computer.FileSystem.FileExists(Common.Time.AlarmPath) Then
            ComboBoxAlarmPath.SelectedIndex = -1
            Me.ComboBoxAlarmPath.Text = Common.Time.AlarmPath
        Else
            Try
                ComboBoxAlarmPath.SelectedIndex = 0
            Catch ex As Exception

            End Try
        End If


        'Me.ComboBoxAlarmPath.DataSource = alarms

        'ComboBoxAlarmPath.SelectedIndex = -1

        'If alarms.Contains(New AlarmModel(System.IO.Path.GetFileNameWithoutExtension(Common.Time.AlarmPath), Common.Time.AlarmPath)) Then
        '    Me.ComboBoxAlarmPath.SelectedValue = Common.Time.AlarmPath

        'ElseIf My.Computer.FileSystem.FileExists(Common.Time.AlarmPath) Then
        '    Me.ComboBoxAlarmPath.Text = Common.Time.AlarmPath
        'Else
        '    Try
        '        ComboBoxAlarmPath.SelectedIndex = 0
        '    Catch ex As Exception

        '    End Try
        'End If
    End Sub
    Private Sub SaveSettings()
        Common.Time.Duration = New CleanCode.Data.RoundedTimeSpan(TimeParser.Parse(TextBoxTime.Text).Ticks, 0).TimeSpan
        Common.Time.CountUp = Me.CheckBoxCountUp.Checked
        Common.Time.AutoStart = Me.CheckBoxAutoStart.Checked
        Common.Time.Restarts = Me.NumericUpDownRestarts.Value
        Common.Time.AlarmEnabled = Me.CheckBoxAlarmSet.Checked
        Common.Time.AlarmPath = Me.ComboBoxAlarmPath.Text
        Common.Time.AlarmLoop = Me.CheckBoxLoop.Checked
        Common.Time.AlarmVolume = Me.NumericUpDownVolume.Value
        Common.Time.Memo = Me.TextBoxMemo.Text.Trim
        UpdateAlarmPath()
    End Sub


    Private Sub DialogTimerSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not alarmPlayer Is Nothing Then
            alarmPlayer.Dispose()
            alarmPlayer = Nothing
        End If
        If Not Me.DialogResult = Windows.Forms.DialogResult.OK Then
            Common.Time.CancelEdit()
        End If
        Common.Time.EndEdit()
    End Sub



    Private Sub DialogTimer_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler Application.Idle, AddressOf UpdateStates
        Common.Time.BeginEdit()
        Me.TextBoxTime.Select()
        LoadSettings()
        UpdateUI()
    End Sub


    Private Sub TextBoxTime_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBoxTime.Validating
        Dim text = TextBoxTime.Text.Trim
        If TimeParser.Parse(text) = Nothing And (Not text = String.Empty) Then
            MessageBox.Show(My.Resources.Strings.MessageUnrecognizedTimerFormat, My.Application.Info.AssemblyName)
            e.Cancel = True
        End If
    End Sub

    Private Sub ButtonImport_Click(sender As Object, e As EventArgs) Handles ButtonImport.Click
        Try
            Using openDialog As New OpenFileDialog
                openDialog.InitialDirectory = Common.TimePath
                openDialog.Filter = My.Settings.TimeDialogFilter
                openDialog.CheckFileExists = True
                If openDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Common.Time.ImportFrom(openDialog.FileName)
                    LoadSettings()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
        End Try
    End Sub

    Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles ButtonExport.Click
        Try
            Using saveDialog As New SaveFileDialog
                saveDialog.InitialDirectory = Common.TimePath
                saveDialog.Filter = My.Settings.TimeDialogFilter
                saveDialog.OverwritePrompt = True
                If saveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    SaveSettings()
                    Common.Time.ExportTo(saveDialog.FileName)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
        End Try
    End Sub
    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        RemoveHandler Application.Idle, AddressOf UpdateStates
        SaveSettings()
        Common.Time.EndEdit()
    End Sub

    Private Sub ButtonAlarmPlay_Click(sender As Object, e As EventArgs) Handles ButtonAlarmPlay.Click
        UpdateAlarmPath()
        Common.Time.AlarmPath = Common.GetAlarmPath(Common.Time.AlarmPath)
        Try
            If Not alarmPlayer Is Nothing Then
                alarmPlayer.Dispose()
                alarmPlayer = Nothing
            End If
            alarmPlayer = New Alarm(Common.Time.AlarmPath, Me.NumericUpDownVolume.Value, False)
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
    Private Sub UpdateUI()
        Me.TextBoxTime.Enabled = (Not Editing)
        Me.ButtonImport.Enabled = (Not Editing)
        Me.Text = If(Editing, "Edit Timer", "New Timer")
        Me.CheckBoxCountUp.Enabled = (Not Editing)
        Me.NumericUpDownRestarts.Enabled = (Not Editing)
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub UpdateAlarmPath()
        If My.Computer.FileSystem.FileExists(Me.ComboBoxAlarmPath.Text) Then
            Common.Time.AlarmPath = Me.ComboBoxAlarmPath.Text
        ElseIf My.Computer.FileSystem.FileExists(Common.GetAlarmPath(ComboBoxAlarmPath.SelectedValue)) Then
            Common.Time.AlarmPath = Me.ComboBoxAlarmPath.SelectedValue
        Else
            Try
                Common.Time.AlarmPath = CType(Me.ComboBoxAlarmPath.Items(0), AlarmModel).FileName
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
