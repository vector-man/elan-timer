Imports System.Windows.Forms
Imports System.IO
Imports PropertyChanged
Imports NLog
<ImplementPropertyChanged>
Public Class TimerSettingsDialog

    Private _alarmsPath As String

    Private alarmPlayer As Sound

    Private toolTip As New ToolTip()

    Private _time As New TimeModel() With {.Duration = TimeSpan.Zero}

    ' Logging
    Private Shared logger As Logger = LogManager.GetCurrentClassLogger()
#Region "Properties"
    Public Property Time As TimeModel
        Get
            Return _time
        End Get
        Set(value As TimeModel)
            _time = value
        End Set
    End Property
    Public Property Hours As Integer
        Get
            Return Math.Floor(Duration.TotalHours)
        End Get
        Set(value As Integer)
            _time.Duration = New TimeSpan(value, Minutes, Seconds)
        End Set
    End Property

    Public Property Minutes As Integer
        Get
            Return Duration.Minutes
        End Get
        Set(value As Integer)
            _time.Duration = New TimeSpan(Hours, value, Seconds)
        End Set
    End Property
    Public Property Seconds As Integer
        Get
            Return Duration.Seconds
        End Get
        Set(value As Integer)
            _time.Duration = New TimeSpan(Hours, Minutes, value)
        End Set
    End Property
    Public Property Duration As TimeSpan
        Get
            Return _time.Duration
        End Get
        Set(value As TimeSpan)
            _time.Duration = value
            Hours = Hours
            Minutes = Minutes
            Seconds = Seconds
        End Set
    End Property

    Public Property Restarts As Integer
        Get
            Return _time.Restarts
        End Get
        Set(value As Integer)
            _time.Restarts = value
        End Set
    End Property

    Public Property CountUpwards As Boolean
        Get
            Return _time.CountUpwards
        End Get
        Set(value As Boolean)
            _time.CountUpwards = value
        End Set
    End Property

    Public Property Synchronize As Boolean
        Get
            Return _time.Synchronize
        End Get
        Set(value As Boolean)
            _time.Synchronize = value
        End Set
    End Property

    Public Property Note As String
        Get
            Return _time.Note
        End Get
        Set(value As String)
            _time.Note = value
        End Set
    End Property

    Public Property Editing As Boolean

    Public Event Saving As EventHandler(Of SavingEventArgs)

    Public Event Loading As EventHandler(Of LoadingEventArgs)
#End Region

    Public Sub Initialize()
        NumericUpDownHours.DataBindings.Clear()
        NumericUpDownHours.DataBindings.Add("Value", Me, "Hours")

        NumericUpDownMinutes.DataBindings.Clear()
        NumericUpDownMinutes.DataBindings.Add("Value", Me, "Minutes")

        NumericUpDownSeconds.DataBindings.Clear()
        NumericUpDownSeconds.DataBindings.Add("Value", Me, "Seconds")

        NumericUpDownRestarts.DataBindings.Clear()
        NumericUpDownRestarts.DataBindings.Add("Value", Me, "Restarts")

        CheckBoxCountUp.DataBindings.Clear()
        CheckBoxCountUp.DataBindings.Add("Checked", Me, "CountUpwards")

        CheckBoxSynchronize.DataBindings.Clear()
        CheckBoxSynchronize.DataBindings.Add("Checked", Me, "Synchronize")

        TextBoxNote.DataBindings.Clear()
        TextBoxNote.DataBindings.Add("Text", Me, "Note")

        SetStrings()
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
        'TODO: Fix.
        ' Me.ButtonSet.Enabled = (Me.NumericUpDownHours.Value Or Me.NumericUpDownMinutes.Value Or Me.NumericUpDownSeconds.Value)
        'Me.ButtonStart.Enabled = (Me.ButtonSet.Enabled And Not Editing)
        'Me.MenuItemLoadPreset.Enabled = (Not Editing)
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DialogTimerSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RemoveHandler Application.Idle, AddressOf UpdateUI
    End Sub

    Private Sub DialogTimerSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Initialize()
        AddHandler Application.Idle, AddressOf UpdateUI
    End Sub
    'TODO: Remove.
    'Private Sub ButtonOptions_Click(sender As Object, e As EventArgs)
    '    ContextMenuOptions.Show(ButtonOptions, New Point(0, ButtonOptions.Height))
    'End Sub

    'TODO: Fix/remove.
    'Private Sub MenuItemLoadPreset_Click(sender As Object, e As EventArgs)
    '    Using openDialog As New OpenFileDialog
    '        openDialog.InitialDirectory = InitialDirectory
    '        openDialog.Filter = FileFilter
    '        openDialog.CheckFileExists = True
    '        If (openDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
    '            RaiseEvent Loading(Me, New LoadingEventArgs(openDialog.FileName))
    '        End If
    '    End Using
    'End Sub

    'TODO: Fix/remove.
    'Private Sub MenuItemSavePresetAs_Click(sender As Object, e As EventArgs)
    '    Using saveDialog As New SaveFileDialog
    '        saveDialog.InitialDirectory = InitialDirectory
    '        saveDialog.Filter = My.Settings.TimeDialogFilter
    '        saveDialog.OverwritePrompt = True
    '        If saveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
    '            RaiseEvent Saving(Me, New SavingEventArgs(saveDialog.FileName))
    '        End If
    '    End Using
    'End Sub

    Private Sub SetStrings()
        Me.SuspendLayout()
        'TODO: Move to Alerts.
        'Me.CheckBoxShowNoteAlertWhenTimerExpires.Text = My.Resources.Strings.ShowAlertBoxWhenTimerExpires

        Me.GroupBoxDuration.Text = My.Resources.Strings.Duration
        Me.LabelHours.Text = My.Resources.Strings.Hours
        Me.LabelMinutes.Text = My.Resources.Strings.Minutes
        Me.LabelSeconds.Text = My.Resources.Strings.Seconds
        Me.LabelRestarts.Text = My.Resources.Strings.Restarts
        Me.CheckBoxCountUp.Text = My.Resources.Strings.CountUp
        'TODO: Move to Alerts.
        'Me.CheckedGroupBox1.Text = My.Resources.Strings.Alarm
        'Me.Label2.Text = My.Resources.Strings.Sound
        'Me.Label1.Text = My.Resources.Strings.Volume
        'Me.CheckBoxLoop.Text = My.Resources.Strings.LoopAlarm
        'Me.ButtonOptions.Text = My.Resources.Strings.Options
        'Me.MenuItemLoadPreset.Text = My.Resources.Strings.LoadPreset
        'Me.MenuItemSavePresetAs.Text = My.Resources.Strings.SavePresetAs

        'Me.ButtonStart.Text = My.Resources.Strings.Start
        'Me.ButtonSet.Text = My.Resources.Strings.SetTimer
        'Me.ButtonCancel.Text = My.Resources.Strings.Cancel

        Me.ResumeLayout()
    End Sub



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub TimerSettingsDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TextBoxNote.Focus()
        TextBoxNote.SelectAll()
    End Sub
End Class
