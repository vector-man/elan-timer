'Imports NLog
'Imports System.IO
'Imports ElanTimer.Infralution.Localization
'Imports PropertyChanged
'Imports ElanTimer.Rendering
'Imports ElanTimer.CodeIsle.Timers
'Imports System.Drawing.Drawing2D

'<ImplementPropertyChanged>
Public Class NewEditDialog
    Private imageList As New ImageList()
    Public Property Editing As Boolean
        Get
            Return Not ButtonStart.Enabled
        End Get
        Set(value As Boolean)
            ButtonStart.Enabled = Not value
        End Set
    End Property
    ' TODO: Remove commented code.
    'Private _styleDialog As New StyleSettingsDialog()
    'Private _timerDialog As New TimerSettingsDialog()
    'Private _alertsDialog As New AlertsSettingsDialog()
    'Private _tasksDialog As New TaskSettingsDialog()
    'Private _editing As Boolean
    'Public Property Editing As Boolean
    '    Get
    '        Return _editing
    '    End Get
    '    Set(value As Boolean)
    '        _editing = value
    '        UpdateStates()
    '    End Set
    'End Property
    'Public Property SoundsPath As String
    '    Get
    '        Return _alertsDialog.SoundsPath
    '    End Get
    '    Set(value As String)
    '        _alertsDialog.SoundsPath = value
    '    End Set
    'End Property
    'Public Property DisplayFormats As List(Of KeyValuePair(Of String, String))
    '    Get
    '        Return _styleDialog.DisplayFormats
    '    End Get
    '    Set(value As List(Of KeyValuePair(Of String, String)))
    '        _styleDialog.DisplayFormats = value
    '    End Set
    'End Property

    'Public Property Tasks As List(Of TaskModel)
    '    Get
    '        Return _tasksDialog.Tasks
    '    End Get
    '    Set(value As List(Of TaskModel))
    '        _tasksDialog.Tasks = value
    '    End Set
    'End Property
    'Public Property Style As StyleModel
    '    Get
    '        Return _styleDialog.Style
    '    End Get
    '    Set(value As StyleModel)
    '        _styleDialog.Style = value
    '    End Set
    'End Property
    'Public Property Time As TimeModel
    '    Get
    '        Return _timerDialog.Time
    '    End Get
    '    Set(value As TimeModel)
    '        _timerDialog.Time = value
    '        _styleDialog.Time = value
    '    End Set
    'End Property
    'Public Property Alerts As AlertsModel
    '    Get
    '        Return _alertsDialog.Alerts
    '    End Get
    '    Set(value As AlertsModel)
    '        _alertsDialog.Alerts = value
    '    End Set
    'End Property

    'Public Property CountUpwards As Boolean



    '    Private alarmPlayer As Sound

    '    Private toolTip As New ToolTip()


    '    Private actionsData As List(Of TaskModel)
    '    Private actionsBindingSource As BindingSource

    '    Private timerObject As New TextRenderable
    '    Private _previewTimer As New AlarmTimer(TimeSpan.Zero)
    '    Private checkerBoardObject As BackgroundRenderable
    '    Private renderer As Renderer
    '    Private stringFormat As New StringFormat(System.Drawing.StringFormat.GenericTypographic)
    '    Private timerSurface As Rendering.Surface
    '    Private loaded As Boolean = False
    '    Private Const CountUpPrefix As String = "+"
    '    Dim _customStyleColors As Integer()
    '    Private timeFormat As New TimeFormat()

    '    ' Logging
    '    Private Shared logger As Logger = LogManager.GetCurrentClassLogger()
    '#Region "Properties"
    '    Public Property Time As New TimeModel()
    '    Public Property TimeDirectory As String
    '    Public Property TimeFileFilter As String

    '    Public Property Hours As Integer
    '        Get
    '            Return Math.Floor(Time.Duration.TotalHours)
    '        End Get
    '        Set(value As Integer)
    '            Time.Duration = New TimeSpan(value, Minutes, Seconds)
    '        End Set
    '    End Property

    '    Public Property Minutes As Integer
    '        Get
    '            Return Time.Duration.Minutes
    '        End Get
    '        Set(value As Integer)
    '            Time.Duration = New TimeSpan(Hours, value, Seconds)
    '        End Set
    '    End Property
    '    Public Property Seconds As Integer
    '        Get
    '            Return Time.Duration.Seconds
    '        End Get
    '        Set(value As Integer)
    '            Time.Duration = New TimeSpan(Hours, Minutes, value)
    '        End Set
    '    End Property

    '    Public Property Alerts As New Object()

    '    Public Property Style As New StyleModel()

    '    Public Property Tasks As New List(Of TaskModel)

    '    Public Property Editing As Boolean

    '    Public Property DisplayFormats As List(Of KeyValuePair(Of String, String))
    '        Get
    '            Return ComboBoxDisplayFormat.DataSource
    '        End Get
    '        Set(value As List(Of KeyValuePair(Of String, String)))
    '            ComboBoxDisplayFormat.DataSource = value
    '        End Set
    '    End Property

    '    Public Property CustomStyleColors As Integer()
    '        Get
    '            Return ColorComboBoxForegrounColor.CustomColors
    '        End Get
    '        Set(value As Integer())
    '            ColorComboBoxForegrounColor.CustomColors = value
    '            ColorComboBoxBackgroundColor.CustomColors = value
    '        End Set
    '    End Property
    '#End Region

    '    Public Sub Initialize()
    '        'Time
    '        NumericUpDownHours.DataBindings.Add("Value", Me, "Hours")
    '        NumericUpDownMinutes.DataBindings.Add("Value", Me, "Minutes")
    '        NumericUpDownSeconds.DataBindings.Add("Value", Me, "Seconds")
    '        NumericUpDownRestarts.DataBindings.Add("Value", Time, "Restarts")
    '        CheckBoxCountUp.DataBindings.Add("Checked", Time, "CountUp")
    '        TextBoxNote.DataBindings.Add("Text", Time, "Note")
    '        CheckBoxShowNoteAlertWhenTimerExpires.DataBindings.Add("Checked", Time.AlertEnabled, "AlertEnabled")
    '        CheckedGroupBox1.DataBindings.Add("Checked", Time, "AlarmEnabled")
    '        TrackBarVolume.DataBindings.Add("Value", Time, "AlarmVolume")
    '        CheckBoxLoop.DataBindings.Add("Checked", Time, "AlarmLoop")

    '        'Tasks
    '        Tasks = If(Tasks, New List(Of TaskModel))

    '        If (actionsBindingSource IsNot Nothing) Then
    '            actionsBindingSource.Dispose()
    '        End If
    '        actionsBindingSource = New BindingSource()

    '        actionsBindingSource.DataSource = Tasks

    '        DataListViewTasks.DataSource = actionsBindingSource

    '        ComboBoxEvent.DataBindings.Clear()
    '        ComboBoxEvent.DataSource = [Enum].GetValues(GetType(TimerEvent))
    '        ComboBoxEvent.DataBindings.Add("Text", actionsBindingSource, "Event", True, DataSourceUpdateMode.OnPropertyChanged)

    '        TextBoxName.DataBindings.Clear()
    '        TextBoxName.DataBindings.Add("Text", actionsBindingSource, "Name", True, DataSourceUpdateMode.OnPropertyChanged)

    '        TextBoxCommand.Clear()
    '        TextBoxCommand.DataBindings.Add("Text", actionsBindingSource, "Command", True, DataSourceUpdateMode.OnPropertyChanged)

    '        TextBoxArguments.Clear()
    '        TextBoxArguments.DataBindings.Add("Text", actionsBindingSource, "Arguments", True, DataSourceUpdateMode.OnPropertyChanged)

    '        ' Used to fix localization issue for "Event" column.
    '        OlvColumnEvent.AspectGetter = Function(obj)
    '                                          ' Convert the event in task (obj) to the localized string.
    '                                          Return ResourceEnumConverter.ConvertToString(DirectCast(obj, TaskModel).Event)
    '                                      End Function

    '        'Style.
    '        ComboBoxDisplayFormat.DataBindings.Clear()
    '        ComboBoxDisplayFormat.DataBindings.Add("SelectedValue", Style, "DisplayFormat", False, DataSourceUpdateMode.OnPropertyChanged)
    '        ComboBoxDisplayFormat.DisplayMember = "Key"
    '        ComboBoxDisplayFormat.ValueMember = "Value"

    '        ColorComboBoxForegrounColor.DataBindings.Clear()
    '        ColorComboBoxForegrounColor.DataBindings.Add("SelectedColor", Style, "ForegroundColor", False, DataSourceUpdateMode.OnPropertyChanged)

    '        ColorComboBoxBackgroundColor.DataBindings.Clear()
    '        ColorComboBoxBackgroundColor.DataBindings.Add("SelectedColor", Style, "BackgroundColor", False, DataSourceUpdateMode.OnPropertyChanged)

    '        FontPickerFont.DataBindings.Clear()
    '        FontPickerFont.DataBindings.Add("Value", Style, "DisplayFont", False, DataSourceUpdateMode.OnPropertyChanged)

    '        CheckBoxGrowToFit.DataBindings.Clear()
    '        CheckBoxGrowToFit.DataBindings.Add("Checked", Style, "GrowToFit", False, DataSourceUpdateMode.OnPropertyChanged)

    '        TrackBarTransparency.DataBindings.Clear()
    '        TrackBarTransparency.DataBindings.Add("Value", Style, "Transparency", False, DataSourceUpdateMode.OnPropertyChanged)

    '        SetStrings()
    '    End Sub

    '    Private Sub SetStrings()
    '        Me.SuspendLayout()

    '        Me.CheckBoxShowNoteAlertWhenTimerExpires.Text = My.Resources.Strings.ShowAlertBoxWhenTimerExpires

    '        Me.GroupBoxDuration.Text = My.Resources.Strings.Duration
    '        Me.LabelHours.Text = My.Resources.Strings.Hours
    '        Me.LabelMinutes.Text = My.Resources.Strings.Minutes
    '        Me.LabelSeconds.Text = My.Resources.Strings.Seconds
    '        Me.LabelRestarts.Text = My.Resources.Strings.Restarts
    '        Me.CheckBoxCountUp.Text = My.Resources.Strings.CountUp

    '        Me.CheckedGroupBox1.Text = My.Resources.Strings.Alarm
    '        Me.Label2.Text = My.Resources.Strings.Sound
    '        Me.Label1.Text = My.Resources.Strings.Volume
    '        Me.CheckBoxLoop.Text = My.Resources.Strings.LoopAlarm
    '        'Me.ButtonOptions.Text = My.Resources.Strings.Options
    '        'Me.MenuItemLoadPreset.Text = My.Resources.Strings.LoadPreset
    '        'Me.MenuItemSavePresetAs.Text = My.Resources.Strings.SavePresetAs

    '        Me.ButtonStart.Text = My.Resources.Strings.Start
    '        Me.ButtonSet.Text = My.Resources.Strings.SetTimer
    '        Me.ButtonCancel.Text = My.Resources.Strings.Cancel

    '        'Tasks
    '        Me.OlvColumnName.Text = My.Resources.Strings.HeaderName
    '        Me.OlvColumnEvent.Text = My.Resources.Strings.HeaderEvent

    '        Me.OlvColumnName.Text = My.Resources.Strings.HeaderName
    '        Me.OlvColumnEvent.Text = My.Resources.Strings.HeaderEvent

    '        Me.LabelEvent.Text = My.Resources.Strings.LabelEvent
    '        Me.LabelName.Text = My.Resources.Strings.LabelName
    '        Me.LabelCommand.Text = My.Resources.Strings.LabelCommand
    '        Me.LabelArguments.Text = My.Resources.Strings.LabelArguments


    '        toolTip.SetToolTip(Me.ButtonAdd, My.Resources.Strings.Add)
    '        toolTip.SetToolTip(Me.ButtonRemove, My.Resources.Strings.Remove)
    '        toolTip.SetToolTip(Me.ButtonMoveUp, My.Resources.Strings.MoveUp)
    '        toolTip.SetToolTip(Me.ButtonMoveDown, My.Resources.Strings.MoveDown)
    '        toolTip.SetToolTip(Me.ButtonBrowseForFile, My.Resources.Strings.BrowseForFile)

    '        'Style.

    '        Me.Text = My.Resources.Strings.Style
    '        Me.LabelRenderer.Text = My.Resources.Strings.DisplayFormat
    '        Me.LabelFont.Text = My.Resources.Strings.Font
    '        Me.CheckBoxGrowToFit.Text = My.Resources.Strings.GrowToFit
    '        Me.LabelBackgroundColor.Text = My.Resources.Strings.BackgroundColor
    '        Me.LabelForegroundColor.Text = My.Resources.Strings.ForegroundColor
    '        Me.LabelTransparency.Text = My.Resources.Strings.Transparency
    '        Me.ButtonCancel.Text = My.Resources.Strings.Cancel

    '        Me.ResumeLayout()
    '    End Sub
    '    'TODO: Fix this.
    '    'Private Sub MenuItemSavePresetAs_Click(sender As Object, e As EventArgs) Handles MenuItemSavePresetAs.Click
    '    '    Using saveDialog As New SaveFileDialog
    '    '        saveDialog.InitialDirectory = InitialDirectory
    '    '        saveDialog.Filter = My.Settings.TimeDialogFilter
    '    '        saveDialog.OverwritePrompt = True
    '    '        If saveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
    '    '            RaiseEvent Saving(Me, New SavingEventArgs(saveDialog.FileName))
    '    '        End If
    '    '    End Using
    '    'End Sub

    '    Private Sub TrackBarVolume_Scroll(sender As Object, e As EventArgs) Handles TrackBarVolume.Scroll
    '        toolTip.SetToolTip(TrackBarVolume, TrackBarVolume.Value.ToString())
    '    End Sub

    '    Private Sub TrackBarVolume_ValueChanged(sender As Object, e As EventArgs) Handles TrackBarVolume.ValueChanged
    '        Try
    '            If (alarmPlayer IsNot Nothing) Then
    '                alarmPlayer.Volume = TrackBarVolume.Value
    '            End If
    '        Catch ex As Exception
    '            logger.Error(ex)
    '        End Try
    '    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        Me.StartPosition = If(Owner Is Nothing, FormStartPosition.CenterScreen, FormStartPosition.CenterParent)
        Me.TopMost = True
        MyBase.OnLoad(e)
    End Sub

    '    Private Sub AlarmPlayer_PlaybackStopped(sender As Object, e As NAudio.Wave.StoppedEventArgs)
    '        ButtonAlarmPlay.Image = My.Resources.play_green
    '    End Sub

    '    Private Function GetAlarmsByPath(alarmPath As String) As List(Of KeyValuePair(Of String, String))
    '        Dim dict As New List(Of KeyValuePair(Of String, String))
    '        'TODO: Fix path.
    '        If (Directory.Exists("")) Then
    '            For Each alarm As String In My.Computer.FileSystem.GetFiles("")
    '                dict.Add(New KeyValuePair(Of String, String)(Path.GetFileNameWithoutExtension(alarm), Path.GetFileName(alarm)))
    '            Next
    '        End If

    '        Return dict
    '    End Function

    '    Private Sub UpdateAlarmPlayer(alarmName As String)
    '        If (alarmPlayer IsNot Nothing) Then
    '            ButtonAlarmPlay.Image = My.Resources.play_green

    '            RemoveHandler alarmPlayer.PlaybackStopped, AddressOf AlarmPlayer_PlaybackStopped
    '            alarmPlayer.Dispose()
    '        End If
    '        'TODO Fix path.
    '        If (alarmName IsNot Nothing) Then
    '            alarmPlayer = New Sound(Path.Combine("", alarmName), Time.AlarmVolume, False)
    '            AddHandler alarmPlayer.PlaybackStopped, AddressOf AlarmPlayer_PlaybackStopped
    '        End If
    '    End Sub

    '    Private Sub ComboBoxAlarmPath_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAlarmPath.SelectedValueChanged
    '        Try
    '            UpdateAlarmPlayer(TryCast(ComboBoxAlarmPath.SelectedValue, String))
    '        Catch ex As Exception
    '            logger.Error(ex)
    '        End Try
    '    End Sub

    '    Private Sub NewEditDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '        toolTip.Dispose()
    '        _previewTimer.Dispose()
    '    End Sub

    '    Private Sub NewEditDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
    '        Initialize()
    '        '' AddHandler Application.Idle, AddressOf UpdateUI
    '    End Sub

    '    Private Sub UpdateUI(sender As Object, e As EventArgs)
    '        Me.LabelHours.Enabled = (Not Editing)
    '        Me.NumericUpDownHours.Enabled = (Not Editing)
    '        Me.LabelMinutes.Enabled = (Not Editing)
    '        Me.NumericUpDownMinutes.Enabled = (Not Editing)
    '        Me.LabelSeconds.Enabled = (Not Editing)
    '        Me.NumericUpDownSeconds.Enabled = (Not Editing)
    '        Me.LabelRestarts.Enabled = (Not Editing)
    '        Me.NumericUpDownRestarts.Enabled = (Not Editing)
    '        Me.Text = If(Editing, My.Resources.Strings.EditTimer, My.Resources.Strings.NewTimer)

    '        Me.GroupBoxDuration.Enabled = Not Editing

    '        Me.ButtonSet.Enabled = (Me.NumericUpDownHours.Value Or Me.NumericUpDownMinutes.Value Or Me.NumericUpDownSeconds.Value)
    '        Me.ButtonStart.Enabled = (Me.ButtonSet.Enabled And Not Editing)


    '        Dim enabled As Boolean = (DataListViewTasks.SelectedObjects.Count = 1)
    '        LabelEvent.Enabled = enabled
    '        ComboBoxEvent.Enabled = enabled
    '        LabelName.Enabled = enabled
    '        TextBoxName.Enabled = enabled
    '        LabelCommand.Enabled = enabled
    '        TextBoxCommand.Enabled = enabled
    '        ButtonBrowseForFile.Enabled = enabled
    '        LabelArguments.Enabled = enabled
    '        TextBoxArguments.Enabled = enabled
    '        ButtonMoveUp.Enabled = enabled
    '        ButtonMoveDown.Enabled = enabled

    '        ButtonRemove.Enabled = (DataListViewTasks.SelectedObjects.Count > 0)

    '        'Style.
    '        ComboBoxDisplayFormat.DataBindings.Clear()
    '        ComboBoxDisplayFormat.DataBindings.Add("SelectedValue", Style, "DisplayFormat", False, DataSourceUpdateMode.OnPropertyChanged)
    '        ComboBoxDisplayFormat.DisplayMember = "Key"
    '        ComboBoxDisplayFormat.ValueMember = "Value"

    '        ColorComboBoxForegrounColor.DataBindings.Clear()
    '        ColorComboBoxForegrounColor.DataBindings.Add("SelectedColor", Style, "ForegroundColor", False, DataSourceUpdateMode.OnPropertyChanged)

    '        ColorComboBoxBackgroundColor.DataBindings.Clear()
    '        ColorComboBoxBackgroundColor.DataBindings.Add("SelectedColor", Style, "BackgroundColor", False, DataSourceUpdateMode.OnPropertyChanged)

    '        FontPickerFont.DataBindings.Clear()
    '        FontPickerFont.DataBindings.Add("Value", Style, "DisplayFont", False, DataSourceUpdateMode.OnPropertyChanged)

    '        CheckBoxGrowToFit.DataBindings.Clear()
    '        CheckBoxGrowToFit.DataBindings.Add("Checked", Style, "GrowToFit", False, DataSourceUpdateMode.OnPropertyChanged)

    '        TrackBarTransparency.DataBindings.Clear()
    '        TrackBarTransparency.DataBindings.Add("Value", Style, "Transparency", False, DataSourceUpdateMode.OnPropertyChanged)

    '        timerObject.Color = Style.ForegroundColor
    '        timerSurface.BackColor = Style.BackgroundColor
    '        ColorComboBoxBackgroundColor.Refresh()
    '        ColorComboBoxForegrounColor.Refresh()

    '        'TODO: Fix this.
    '        '' MenuItemExportSelected.Enabled = (Not DataListViewTasks.SelectedIndices.Count = 0)
    '        'MenuItemExportAll.Enabled = (DataListViewTasks.GetItemCount() > 0)
    '        'Me.MenuItemLoadPreset.Enabled = (Not Editing)
    '    End Sub

    '    Private Sub ButtonMoveUp_Click(sender As Object, e As EventArgs)
    '        Dim position = actionsBindingSource.Position
    '        If (Not position = 0) Then
    '            Dim item = actionsBindingSource.Current
    '            actionsBindingSource.Remove(item)
    '            actionsBindingSource.Insert(position - 1, item)
    '            actionsBindingSource.Position = position - 1
    '        End If
    '    End Sub

    '    Private Sub ButtonMoveDown_Click(sender As Object, e As EventArgs)
    '        Dim position = actionsBindingSource.Position
    '        If (position < actionsBindingSource.Count - 1) Then
    '            Dim item = actionsBindingSource.Current
    '            actionsBindingSource.Remove(item)
    '            actionsBindingSource.Insert(position + 1, item)
    '            actionsBindingSource.Position = position + 1
    '        End If
    '    End Sub

    '    Private Sub ButtonBrowseForFile_Click(sender As Object, e As EventArgs)
    '        Using dialog As New OpenFileDialog
    '            If (dialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
    '                TextBoxCommand.Text = dialog.FileName
    '            End If
    '        End Using
    '    End Sub

    '    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs)
    '        actionsBindingSource.Add(New TaskModel(TimerEvent.Started, My.Resources.Strings.NewTask, "", "", False, "", True))
    '    End Sub

    '    Private Sub ButtonRemove_Click(sender As Object, e As EventArgs)
    '        Try
    '            Dim selectedObjects = DataListViewTasks.SelectedObjects

    '            For Each obj In selectedObjects
    '                actionsBindingSource.Remove(obj)
    '            Next
    '        Catch ex As Exception
    '            logger.Error(ex)
    '        End Try
    '    End Sub


    '    Private Sub TrackBarTransparency_Scroll(sender As Object, e As EventArgs)
    '        toolTip.SetToolTip(TrackBarTransparency, TrackBarTransparency.Value)
    '    End Sub

    '    Private Sub TrackBarTransparency_ValueChanged(sender As Object, e As EventArgs)
    '        Try
    '            UpdateOpacity()
    '        Catch ex As Exception
    '            logger.Error(ex)
    '        End Try
    '    End Sub
    '    Private Sub ComboBoxDisplayFormat_SelectedValueChanged(sender As Object, e As EventArgs)
    '        Try
    '            Dim format As String = TryCast(ComboBoxDisplayFormat.SelectedValue, String)
    '            If (format IsNot Nothing AndAlso timerObject IsNot Nothing) Then
    '                ' TODO: Remove line.
    '                ' timerObject.Format = format
    '            End If
    '        Catch ex As Exception
    '            logger.Error(ex)
    '        End Try
    '    End Sub
    '    Private Sub UpdateOpacity()
    '        Dim transparency As Integer = 255 - (((100 - Int16.Parse(TrackBarTransparency.Value)) / 100) * 255)
    '        If (checkerBoardObject IsNot Nothing) Then
    '            checkerBoardObject.Brush = New HatchBrush(Drawing2D.HatchStyle.LargeCheckerBoard, Color.FromArgb(transparency, Color.Gray), Color.FromArgb(transparency, Color.White))
    '        End If
    '    End Sub
    '    Private Sub RestartTimer()
    '        _previewTimer.Reset()
    '        _previewTimer.Start()
    '    End Sub

    '    Private Sub NewEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown
    '        RestartTimer()
    '        StartUpRendering()
    '        toolTip.SetToolTip(TrackBarTransparency, TrackBarTransparency.Value)
    '    End Sub

    '    Private Sub StartUpRendering()
    '        timerSurface = New Surface()
    '        timerSurface.BackColor = Style.BackgroundColor
    '        timerSurface.Dock = DockStyle.Fill
    '        PanelRenderPreview.Controls.Add(timerSurface)

    '        stringFormat = New StringFormat(System.Drawing.StringFormat.GenericTypographic)
    '        stringFormat.Alignment = StringAlignment.Center
    '        stringFormat.LineAlignment = StringAlignment.Center

    '        timerObject = New TextRenderable() With {
    '            .Color = Style.ForegroundColor,
    '            .Font = New Font(Style.DisplayFont.FontFamily.Name, 1, Style.DisplayFont.Style),
    '            .StringFormat = stringFormat,
    '            .SizeToFit = True,
    '            .Visible = True,
    '            .Rectangle = timerSurface.ClientRectangle}

    '        timerObject.TextRenderFormat = GetTimerTextRenderFunc(Time.CountUp)

    '        checkerBoardObject = New BackgroundRenderable(Nothing, True) With {.Rectangle = timerSurface.ClientRectangle}


    '        renderer = New Renderer(timerSurface)
    '        renderer.FramesPerSecond = Utils.Framerate

    '        renderer.Renderables.Add(timerObject)
    '        renderer.Renderables.Add(checkerBoardObject)

    '        UpdateOpacity()
    '        renderer.Enabled = True
    '    End Sub

    '    Private Function GetTimerTextRenderFunc(countUp As Boolean) As Func(Of String)
    '        If (countUp) Then
    '            Return Function() String.Format(timeFormat, String.Concat("+", "{0:", Style.DisplayFormat, "}"), _previewTimer.Elapsed)

    '        Else
    '            Return Function() String.Format(timeFormat, String.Concat("{0:", Style.DisplayFormat, "}"), _previewTimer.Remaining)
    '        End If
    '    End Function

    '    Private Sub ColorComboBoxForegrounColor_ColorChanged(sender As Object, e As ColorComboTestApp.ColorChangeArgs)
    '        Try
    '            timerObject.Color = e.color
    '            ColorComboBoxBackgroundColor.CustomColors = ColorComboBoxForegrounColor.CustomColors
    '        Catch ex As Exception
    '            logger.Error(ex)
    '        End Try
    '    End Sub

    '    Private Sub ColorComboBoxBackgroundColor_ColorChanged(sender As Object, e As ColorComboTestApp.ColorChangeArgs)
    '        Try
    '            timerSurface.BackColor = e.color
    '            ColorComboBoxForegrounColor.CustomColors = ColorComboBoxBackgroundColor.CustomColors
    '        Catch ex As Exception
    '            logger.Error(ex)
    '        End Try
    '    End Sub

    '    Private Sub FontPickerFont_ValueChanged(sender As Object, e As EventArgs)
    '        Try
    '            Dim font As Font = TryCast(FontPickerFont.Value, Font)
    '            If (font IsNot Nothing AndAlso timerObject IsNot Nothing) Then
    '                timerObject.Font = New Font(font.FontFamily.Name, 1, font.Style)
    '            End If
    '        Catch ex As Exception
    '            logger.Error(ex)
    '        End Try
    '    End Sub

    Public Event FileLoading As EventHandler(Of EventArgs)
    Public Event FileSaving As EventHandler(Of EventArgs)
    Public Property PresetsMenu As ContextMenuStrip
        Get
            Return DowpDownButtonPresets.Menu
        End Get
        Set(value As ContextMenuStrip)
            DowpDownButtonPresets.Menu = value
        End Set
    End Property
    Public Sub AddTab(text As String, icon As Image, form As Form)
        Try
            Dim tabPage As TabPage = New TabPage(text)
            tabPage.UseVisualStyleBackColor = True
            form.TopLevel = False
            form.FormBorderStyle = Windows.Forms.FormBorderStyle.None

            'tabPage.Controls.AddRange(form.Controls.Cast(Of Control).ToArray())
            tabPage.Controls.Add(form)

            TabControl1.TabPages.Add(tabPage)

            tabPage.ImageKey = Me.TabControl1.TabCount - 1
            imageList.Images.Add(tabPage.ImageKey, icon)

            form.Show()
            form.Dock = DockStyle.Top
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub
    Private Sub SetStrings()
        Me.ButtonOk.Text = My.Resources.Strings.Ok
        Me.ButtonCancel.Text = My.Resources.Strings.Cancel
        Me.ButtonStart.Text = My.Resources.Strings.Start

        Me.DowpDownButtonPresets.Text = My.Resources.Strings.Presets
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStrings()
        PresetsMenu = New ContextMenuStrip()
        TabControl1.ImageList = imageList
    End Sub
End Class