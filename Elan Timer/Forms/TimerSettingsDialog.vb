Imports System.Windows.Forms
Imports ElanTimer.Prefs
Imports System.IO
Imports PropertyChanged

<ImplementPropertyChanged>
Public Class TimerSettingsDialog

    Dim _alarmsPath As String

    Public Property Editing As Boolean = False
    Dim alarmPlayer As Alarm
    Private transporter As New JsonNetTransporter()
    Private time As New TimeModel(transporter)

    '  Dim alarpPath As String
    '  Dim formLoaded As Boolean = False

    ' TODO: Remove commented code.
    ' Private Sub LoadSettings()
    'NumericUpDownHours.Value = Math.Floor(Duration.TotalHours)
    'NumericUpDownMinutes.Value = Duration.Minutes
    'NumericUpDownSeconds.Value = Duration.Seconds


    'Me.CheckBoxCountUp.Checked = Preferences.Time.CountUp
    ''  Me.CheckBoxStartImmediately.Checked = Preferences.Time.StartImmediately
    'Me.NumericUpDownRestarts.Value = Preferences.Time.Restarts
    'Me.CheckBoxAlarmSet.Checked = Preferences.Time.AlarmEnabled
    'Me.CheckBoxLoop.Checked = Preferences.Time.AlarmLoop
    'Me.NumericUpDownVolume.Value = Preferences.Time.AlarmVolume
    'Me.CheckBoxNote.Checked = Preferences.Time.HasNote
    'Me.CheckBoxShowNoteAlertWhenTimerExpires.Checked = Preferences.Time.HasNoteAlert
    'If (Not Editing) Then
    '    Preferences.Time.Note = String.Empty
    'End If
    'Me.TextBoxNote.DataBindings.Clear()
    'Me.TextBoxNote.DataBindings.Add("Text", Preferences.Time, "Note", True, DataSourceUpdateMode.OnPropertyChanged)

    'Me.ComboBoxAlarmPath.ValueMember = "FileName"
    'Me.ComboBoxAlarmPath.DisplayMember = "Name"

    'Dim alarms As List(Of AlarmModel) = Common.GetAlarms

    'Me.ComboBoxAlarmPath.DataSource = alarms

    'If alarms.Contains(New AlarmModel(System.IO.Path.GetFileNameWithoutExtension(Preferences.Time.AlarmPath), Preferences.Time.AlarmPath)) Then
    '    Me.ComboBoxAlarmPath.SelectedValue = Preferences.Time.AlarmPath
    'ElseIf My.Computer.FileSystem.FileExists(Preferences.Time.AlarmPath) Then
    '    ComboBoxAlarmPath.SelectedIndex = -1
    '    Me.ComboBoxAlarmPath.Text = Preferences.Time.AlarmPath
    'Else
    '    Try
    '        ComboBoxAlarmPath.SelectedIndex = 0
    '    Catch ex As Exception

    '    End Try
    'End If

    ' End Sub
    'Private Sub SaveSettings()
    '    Preferences.Time.Duration = New TimeSpan(0, NumericUpDownHours.Value, NumericUpDownMinutes.Value, NumericUpDownSeconds.Value)
    '    Preferences.Time.CountUp = Me.CheckBoxCountUp.Checked
    '    '  Preferences.Time.StartImmediately = Me.CheckBoxStartImmediately.Checked
    '    Preferences.Time.Restarts = Me.NumericUpDownRestarts.Value
    '    Preferences.Time.AlarmEnabled = Me.CheckBoxAlarmSet.Checked
    '    Preferences.Time.AlarmPath = Me.ComboBoxAlarmPath.Text
    '    Preferences.Time.AlarmLoop = Me.CheckBoxLoop.Checked
    '    Preferences.Time.AlarmVolume = Me.NumericUpDownVolume.Value
    '    Preferences.Time.Note = Me.TextBoxNote.Text.Trim
    '    Preferences.Time.HasNote = Me.CheckBoxNote.Checked
    '    Preferences.Time.HasNoteAlert = CheckBoxShowNoteAlertWhenTimerExpires.Checked
    '    UpdateAlarmPath()
    'End Sub

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
            time.AlarmLoop = True
        End Set
    End Property
    Public Property AlarmFilter As String

    ' TODO: Delete this.
    'Private Sub DialogTimerSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '    If Not alarmPlayer Is Nothing Then
    '        alarmPlayer.Dispose()
    '        alarmPlayer = Nothing
    '    End If
    '    If Not (Me.DialogResult = Windows.Forms.DialogResult.OK Or Me.DialogResult = Windows.Forms.DialogResult.Retry) Then
    '        Preferences.Time.CancelEdit()
    '    End If
    '    Preferences.Time.EndEdit()
    'End Sub

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
        NumericUpDownVolume.DataBindings.Add("Value", time, "AlarmVolume")
        CheckBoxLoop.DataBindings.Add("Checked", time, "AlarmLoop")
        ' ContextMenuStripSettings.DataBindings.Add("Visible", CheckBoxSettings, "Checked")
        ' ComboBoxAlarmPath.SelectedItem = alarms.Where(Function(i) i.Value = AlarmName)
        'Dim hoursBinding As New Binding("Value", time, "Duration")
        'AddHandler hoursBinding.Format, Sub(s, e)
        '                                    e.Value = CType(e.Value, TimeSpan).Hours
        '                                End Sub
        'NumericUpDownHours.DataBindings.Add("Value", hoursBinding, "Duration")

        'Dim minutesBinding As New Binding("Value", time, "Duration")
        'AddHandler minutesBinding.Format, Sub(s, e)
        '                                      e.Value = CType(e.Value, TimeSpan).Minutes
        '                                  End Sub
        'NumericUpDownMinutes.DataBindings.Add("Value", minutesBinding, "Duration")

        'Dim secondsBinding As New Binding("Value", time, "Duration")
        'AddHandler secondsBinding.Format, Sub(s, e)
        '                                      e.Value = CType(e.Value, TimeSpan).Seconds
        '                                  End Sub
        'NumericUpDownMinutes.DataBindings.Add("Value", minutesBinding, "Duration")
    End Sub

    Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
        DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub ButtonAlarmPlay_Click(sender As Object, e As EventArgs) Handles ButtonAlarmPlay.Click
        Try
            If Not alarmPlayer Is Nothing Then
                alarmPlayer.Dispose()
            End If
            alarmPlayer = New Alarm(Path.Combine(AlarmsPath, SelectedAlarm), AlarmVolume, False)
            alarmPlayer.Play()
        Catch ex As Exception

        End Try
    End Sub
    ' TODO: Remove commented code.
    'Private Sub ButtonOpenAlarm_Click(sender As Object, e As EventArgs) Handles ButtonOpenAlarm.Click
    '    Try
    '        Using openDialog As New OpenFileDialog
    '            openDialog.Filter = My.Settings.AlarmDialogFilter
    '            openDialog.CheckFileExists = True
    '            If openDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
    '                ComboBoxAlarmPath.SelectedIndex = -1
    '                AlarmPath = openDialog.FileName
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
    '    End Try
    'End Sub
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
        Me.ButtonOpenAlarm.Enabled = Me.ButtonAlarmPlay.Enabled
        Me.ButtonSet.Enabled = (Me.NumericUpDownHours.Value Or Me.NumericUpDownMinutes.Value Or Me.NumericUpDownSeconds.Value)
        Me.ButtonStart.Enabled = Me.ButtonSet.Enabled

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub NumericUpDownVolume_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownVolume.ValueChanged
        Try
            alarmPlayer.Volume = NumericUpDownVolume.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonSet_Click(sender As Object, e As EventArgs) Handles ButtonSet.Click

    End Sub

    'Private Sub TimerSettingsDialog_Click(sender As Object, e As EventArgs) Handles Me.Click

    'End Sub

    'Private Sub TimerSettingsDialog_Enter(sender As Object, e As EventArgs) Handles Me.Enter
    '    CheckBoxSettings.Checked = False
    'End Sub

    Private Sub DialogTimerSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RemoveHandler Application.Idle, AddressOf UpdateUI
    End Sub

    Private Sub TimerSettingsDialog_Invalidated(sender As Object, e As InvalidateEventArgs) Handles Me.Invalidated

    End Sub

    Private Sub DialogTimerSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Initialize()
        AddHandler Application.Idle, AddressOf UpdateUI
    End Sub

    'Private Sub CheckBoxSettings_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBoxSettings.CheckStateChanged


    'End Sub

    'Private Sub ContextMenuStripSettings_Closed(sender As Object, e As ToolStripDropDownClosedEventArgs) Handles ContextMenuStripSettings.Closed
    '    If mouseOver Then Return
    '    If cancel Then Return
    '    cancel = True
    '    CheckBoxSettings.Checked = False
    '    cancel = False
    'End Sub
    'Private Sub ContextMenuStripSettings_Closed(sender As Object, e As ToolStripDropDownClosedEventArgs) Handles ContextMenuStripSettings.Closed
    '    CheckBoxSettings.Invalidate()
    'End Sub

    'Private mouseOver As Boolean
    'Private cancel As Boolean

    'Private Sub CheckBoxSettings_MouseEnter(sender As Object, e As EventArgs) Handles CheckBoxSettings.MouseEnter
    '    mouseOver = True
    'End Sub

    'Private Sub CheckBoxSettings_MouseLeave(sender As Object, e As EventArgs) Handles CheckBoxSettings.MouseLeave
    '    mouseOver = False
    'End Sub

    'Private Sub CheckBoxSettings_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSettings.CheckedChanged

    'End Sub

    'Private Sub ContextMenuStripSettings_VisibleChanged(sender As Object, e As EventArgs) Handles ContextMenuStripSettings.VisibleChanged

    'End Sub

    'Private mouseOver As Boolean
    'Private cancel As Boolean
    'Private forceClose As Boolean
    'Private Sub CheckBoxSettings_MouseEnter(sender As Object, e As EventArgs) Handles CheckBoxSettings.MouseEnter
    '    mouseOver = True
    'End Sub

    'Private Sub CheckBoxSettings_MouseLeave(sender As Object, e As EventArgs) Handles CheckBoxSettings.MouseLeave
    '    mouseOver = False
    'End Sub
    'Private mouseOver As Boolean
    'Private cancel As Boolean
    'Private Sub CheckBoxSettings_MouseEnter(sender As Object, e As EventArgs) Handles CheckBoxSettings.MouseEnter
    '    mouseOver = True
    'End Sub

    'Private Sub CheckBoxSettings_MouseLeave(sender As Object, e As EventArgs) Handles CheckBoxSettings.MouseLeave
    '    mouseOver = False
    'End Sub


    'Private Sub CheckBoxSettings_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSettings.CheckedChanged
    '    If cancel Then Return
    '    If (CheckBoxSettings.Checked) Then
    '        ContextMenuStripSettings.Visible = True
    '        Utils.ShowContextMenuStrip(sender, ContextMenuStripSettings)
    '    Else
    '        If (ContextMenuStripSettings.Visible) Then
    '            ContextMenuStripSettings.Close()
    '        End If
    '    End If
    'End Sub

    'Private buttonPressed As Boolean
    'Private Sub CheckBoxSettings_Paint(sender As Object, e As PaintEventArgs) Handles CheckBoxSettings.Paint
    '    If (ContextMenuStripSettings.Visible) Then
    '        ButtonRenderer.DrawButton(e.Graphics, CheckBoxSettings.Bounds, VisualStyles.PushButtonState.Pressed)
    '    Else
    '        ButtonRenderer.DrawButton(e.Graphics, CheckBoxSettings.Bounds, VisualStyles.PushButtonState.Normal)
    '    End If
    'End Sub

    'Private Sub CheckBoxSettings_Click(sender As Object, e As EventArgs) Handles CheckBoxSettings.Click
    '    If (buttonPressed AndAlso Not ContextMenuStripSettings.Visible) Then
    '        Utils.ShowContextMenuStrip(sender, ContextMenuStripSettings)
    '        buttonPressed = True
    '    End If

    '    CheckBoxSettings.Invalidate()
    'End Sub

    'Private Sub CheckBoxSettings_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBoxSettings.MouseUp

    'End Sub

    'Private Sub CheckBoxSettings_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSettings.CheckedChanged
    '    If (CheckBoxSettings.Checked) Then
    '        Utils.ShowContextMenuStrip(sender, ContextMenuStripSettings)
    '    Else
    '        If cancel Then Return
    '        ContextMenuStripSettings.Hide()
    '    End If
    'End Sub

    'Private Sub ContextMenuStripSettings_Closing(sender As Object, e As ToolStripDropDownClosingEventArgs) Handles ContextMenuStripSettings.Closing
    '    e.Cancel = CheckBoxSettings.Checked And mouseOver
    '    cancel = Not mouseOver
    '    CheckBoxSettings.Checked = False
    '    cancel = False
    'End Sub

    Private Sub ButtonOptions_Click(sender As Object, e As EventArgs) Handles ButtonOptions.Click
        ContextMenuOptions.Show(ButtonOptions, New Point(0, ButtonOptions.Height))
    End Sub

    Private Sub MenuItemLoadPreset_Click(sender As Object, e As EventArgs) Handles MenuItem1.Click
        Try
            Using openDialog As New OpenFileDialog
                openDialog.InitialDirectory = ""
                openDialog.Filter = AlarmFilter
                openDialog.CheckFileExists = True
                If (openDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
                    Using input As Stream = File.OpenRead(openDialog.FileName)
                        time.Import(input)
                        Me.AlarmEnabled = time.AlarmEnabled
                        Me.time.AlarmLoop = time.AlarmLoop
                        Me.SelectedAlarm = time.AlarmName
                        Me.AlarmVolume = time.AlarmVolume
                        Me.ShowAlertBoxOnTimerExpiration = time.AlertEnabled
                        Me.CountUp = time.CountUp
                        Me.NumericUpDownHours.Value = time.Duration.Hours
                        Me.NumericUpDownMinutes.Value = time.Duration.Minutes
                        Me.NumericUpDownSeconds.Value = time.Duration.Seconds
                        Me.Note = time.Note
                        Me.NoteEnabled = time.NoteEnabled
                        Me.Restarts = time.Restarts
                    End Using
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
        End Try
    End Sub

    Private Sub MenuItemSavePresetAs_Click(sender As Object, e As EventArgs) Handles MenuItemSavePresetAs.Click
        Try
            Using saveDialog As New SaveFileDialog
                saveDialog.InitialDirectory = ""
                saveDialog.Filter = My.Settings.TimeDialogFilter
                saveDialog.OverwritePrompt = True
                If saveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Using output As Stream = File.OpenWrite(saveDialog.FileName)
                        time.Export(output)
                    End Using
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
        End Try
    End Sub
End Class
