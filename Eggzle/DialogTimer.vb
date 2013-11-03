Imports Eggzle.Settings.Models
Imports Mono.Addins
Public Class DialogTimer
    Private nodeBinding As Binding
    Private context As CodeIsle.Timers.AlarmTimerContext
    Private renderer As RendererManager
    Private uiScheduler As TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext()
    Private Const RenderRate As Integer = 1000 / 60
    Public timerSurface As PictureBox
    Public invalidatorCancellationTokenSource As System.Threading.CancellationTokenSource
    Private fontPickerTimerTextToolTip As New ToolTip
    Private profileData As ProfileModel
    Private actionsBindingSource As BindingSource
    Public Sub UpdateStates(sender As Object, e As EventArgs)
        TableLayoutPanelActions.Enabled = (DataListViewActions.SelectedObjects.Count = 1)
        ButtonRemove.Enabled = (DataListViewActions.SelectedObjects.Count > 0)
        'BetterListView1.DataSource = bs
    End Sub
    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        actionsBindingSource.Add(New ActionModel(TimerEvent.Started, "New Action", "", "", False, "", True))
    End Sub

    Private Sub ButtonRemove_Click(sender As Object, e As EventArgs) Handles ButtonRemove.Click
        Dim selectedObjects = DataListViewActions.SelectedObjects

        For Each obj In selectedObjects
            actionsBindingSource.Remove(obj)
        Next
    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        LoadDatabase()
        timerSurface = New PictureBox
        PanelRenderPreview.Controls.Add(timerSurface)
        timerSurface.Dock = DockStyle.Fill

        AddHandler Application.Idle, AddressOf UpdateStates

        context = New CodeIsle.Timers.AlarmTimerContext(New CodeIsle.Timers.CountDownAlarmTimer(New TimeSpan(0)))
    End Sub
    Private Sub LoadDatabase()
        profileData = New ProfileModel(Common.Settings.Time, Common.Settings.Font, Common.Settings.SizeToFit, Common.Settings.BackgroundColor, Common.Settings.ForegroundColor, New List(Of ActionModel)(Common.Settings.Actions))

        actionsBindingSource = New BindingSource()
        actionsBindingSource.DataSource = profileData
        actionsBindingSource.DataMember = "Actions"

        ComboBoxEvent.DataBindings.Clear()
        TextBoxName.DataBindings.Clear()
        TextBoxCommand.DataBindings.Clear()
        TextBoxArguments.DataBindings.Clear()
        CheckBoxUseScript.DataBindings.Clear()
        ComboBoxScript.DataBindings.Clear()

        ButtonOpenScript.DataBindings.Clear()


        ComboBoxEvent.DataSource = [Enum].GetValues(GetType(TimerEvent))
        ComboBoxEvent.DataBindings.Add("Text", actionsBindingSource, "Event", True, DataSourceUpdateMode.OnPropertyChanged)
        TextBoxName.DataBindings.Add("Text", actionsBindingSource, "Name", True, DataSourceUpdateMode.OnPropertyChanged)
        TextBoxCommand.DataBindings.Add("Text", actionsBindingSource, "Command", True, DataSourceUpdateMode.OnPropertyChanged)
        TextBoxArguments.DataBindings.Add("Text", actionsBindingSource, "Arguments", True, DataSourceUpdateMode.OnPropertyChanged)
        CheckBoxUseScript.DataBindings.Add("Checked", actionsBindingSource, "UseScript", True, DataSourceUpdateMode.OnPropertyChanged)
        ComboBoxScript.DataBindings.Add("Text", actionsBindingSource, "Script", True, DataSourceUpdateMode.OnPropertyChanged)

        ' FontPickerFont.DataBindings.Add("Value", Common.Settings, "Font", True, DataSourceUpdateMode.OnPropertyChanged)

        ComboBoxScript.DataBindings.Add(New Binding("Enabled", CheckBoxUseScript, "Checked", True, DataSourceUpdateMode.OnPropertyChanged, False))
        ButtonOpenScript.DataBindings.Add(New Binding("Enabled", ComboBoxScript, "Enabled", True, DataSourceUpdateMode.OnPropertyChanged, False))

        DataListViewActions.DataSource = actionsBindingSource

        Dim rendererList As New List(Of Settings.Models.RendererModel)

        For Each node As TypeExtensionNode(Of EggzleLib.RendererAttribute) In AddinManager.AddinEngine.GetExtensionNodes(GetType(EggzleLib.Extend.Rendering.IRenderer))
            rendererList.Add(New Settings.Models.RendererModel(node.Data.Id, node.Data.Name))
        Next

        ComboBoxRenderer.DisplayMember = "Name"
        ComboBoxRenderer.ValueMember = "Id"
        ComboBoxRenderer.DataSource = rendererList

    End Sub
    Private Sub SaveDialogData()

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        'Common.Settings.Actions.Clear()
        'Common.Settings.Actions.AddRange(actionsBindingSource.List)
        'Common.RenderInfo.BackgroundColor = ColorComboBoxBackgroundColor.SelectedColor
        'Common.RenderInfo.ForegroundColor = ColorComboBoxForegrounColor.SelectedColor
        'Common.RenderInfo.Font = FontPickerFont.Value
        'Common.RenderInfo.SizeToFit = CheckBoxSizeToFit.Checked
        Common.Settings.Actions.Clear()
        Common.Settings.Actions.AddRange(profileData.Actions)

        Common.Settings.BackgroundColor = profileData.BackgroundColor
        Common.Settings.Font = profileData.Font
        Common.Settings.ForegroundColor = profileData.ForegroundColor
        Common.Settings.SizeToFit = profileData.SizeToFit
        Common.Settings.Time = profileData.Time
    End Sub

    Private Sub NumericUpDown4_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownOpacityLevel.ValueChanged
        If Me.Visible Then
            context.PreviewOpacity = CType(sender, NumericUpDown).Value
            Dim formOpacity = context.PreviewOpacity / 100
            FormMain.Opacity = formOpacity

        End If
    End Sub

    Private Sub StartUpRendering(ByRef timer As CodeIsle.Timers.AlarmTimer)
        'TODO: Fix below
        'renderer = New RendererManager(New Eggzle.Extend.Renderers.i, context, timerSurface, True)
    End Sub

    Private Sub DialogTimer_Load(sender As Object, e As EventArgs) Handles Me.Load
        StartUpRendering(New CodeIsle.Timers.CountDownAlarmTimer(New TimeSpan(0)))

        LoadDatabase()
    End Sub



    'Public Function FontStyleExist(fontFamilyName As String, fontStyle As FontStyle) As Boolean
    '    Dim result As Boolean

    '    Try
    '        Using family As New FontFamily(fontFamilyName)
    '            result = family.IsStyleAvailable(fontStyle)
    '        End Using
    '    Catch generatedExceptionName As ArgumentException
    '        result = False
    '    End Try

    '    Return result
    'End Function

    'Protected Overridable Function GetFont(fontFamilyName As String, fontSize As Single) As Font
    '    Dim font As Font

    '    Using family As New FontFamily(fontFamilyName)
    '        If family.IsStyleAvailable(FontStyle.Regular) Then
    '            font = Me.GetFont(fontFamilyName, fontSize, FontStyle.Regular)
    '        ElseIf family.IsStyleAvailable(FontStyle.Bold) Then
    '            font = Me.GetFont(fontFamilyName, fontSize, FontStyle.Bold)
    '        ElseIf family.IsStyleAvailable(FontStyle.Italic) Then
    '            font = Me.GetFont(fontFamilyName, fontSize, FontStyle.Italic)
    '        ElseIf family.IsStyleAvailable(FontStyle.Bold Or FontStyle.Italic) Then
    '            font = Me.GetFont(fontFamilyName, fontSize, FontStyle.Bold Or FontStyle.Italic)
    '        Else
    '            font = Nothing
    '        End If
    '    End Using

    '    Return font
    'End Function

    'Protected Overridable Function GetFont(fontFamilyName As String, fontSize As Single, fontStyle As FontStyle) As Font
    '    Return New Font(fontFamilyName, fontSize, fontStyle)
    'End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub
End Class