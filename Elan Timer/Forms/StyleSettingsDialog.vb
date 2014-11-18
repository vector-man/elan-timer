Imports System.Windows.Forms
Imports ElanTimer.CodeIsle.Timers
Imports System.IO
Imports ElanTimer.Rendering
Imports System.Drawing.Drawing2D
Imports NLog
Imports PropertyChanged
Imports System.ComponentModel

<ImplementPropertyChanged>
Public Class StyleSettingsDialog
    Private timerObject As New TextRenderable
    Private _previewTimer As New AlarmTimer(TimeSpan.Zero)
    Private checkerBoardObject As BackgroundRenderable
    Private renderer As Renderer
    Private stringFormat As New StringFormat(System.Drawing.StringFormat.GenericTypographic)
    Private timerSurface As Rendering.Surface
    Private loaded As Boolean = False
    Private toolTip As New ToolTip()
    Private Const CountUpPrefix As String = "+"
    Dim _customStyleColors As Integer()
    Private timeFormat As New TimeFormat()

    ' Logging.
    Private Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

#Region "Properties"
    Public Property Style As New StyleModel()

    Public Property BackgroundColor As Color
        Get
            Return Style.BackgroundColor
        End Get
        Set(value As Color)
            Style.BackgroundColor = value
        End Set
    End Property

    Public Property ForegroundColor As Color
        Get
            Return Style.ForegroundColor
        End Get
        Set(value As Color)
            Style.ForegroundColor = value
        End Set
    End Property

    Public Property DisplayFont As Font
        Get
            Return Style.DisplayFont
        End Get
        Set(value As Font)
            Style.DisplayFont = value
        End Set
    End Property

    Public Property DisplayFormat As String
        Get
            Return Style.DisplayFormat
        End Get
        Set(value As String)
            Style.DisplayFormat = value
        End Set
    End Property

    Public Property GrowToFit As Boolean
        Get
            Return Style.GrowToFit
        End Get
        Set(value As Boolean)
            Style.GrowToFit = value
        End Set
    End Property

    Public Property Transparency As Integer
        Get
            Return Style.Transparency
        End Get
        Set(value As Integer)
            Style.Transparency = value
        End Set
    End Property

    Public Property DisplayFormats As List(Of KeyValuePair(Of String, String))
        Get
            Return ComboBoxDisplayFormat.DataSource
        End Get
        Set(value As List(Of KeyValuePair(Of String, String)))
            ComboBoxDisplayFormat.DataSource = value
        End Set
    End Property

    Public Property CustomStyleColors As Integer()
        Get
            Return ColorComboBoxForegrounColor.CustomColors
        End Get
        Set(value As Integer())
            ColorComboBoxForegrounColor.CustomColors = value
            ColorComboBoxBackgroundColor.CustomColors = value
        End Set
    End Property

    Public Property Time As New TimeModel()
#End Region
#Region "Events"
    Public Event Loading As EventHandler(Of LoadingEventArgs)
    Public Event Saving As EventHandler(Of SavingEventArgs)
#End Region
    Sub Initialize()
        RemoveHandler _previewTimer.Expired, AddressOf PreviewTimer_Expired
        AddHandler _previewTimer.Expired, AddressOf PreviewTimer_Expired
        ComboBoxDisplayFormat.ValueMember = "Value"
        ComboBoxDisplayFormat.DataBindings.Clear()
        ComboBoxDisplayFormat.DataBindings.Add("SelectedValue", Style, "DisplayFormat", False, DataSourceUpdateMode.OnPropertyChanged)
        ComboBoxDisplayFormat.DisplayMember = "Key"
        ComboBoxDisplayFormat.ValueMember = "Value"

        ColorComboBoxForegrounColor.DataBindings.Clear()
        ColorComboBoxForegrounColor.DataBindings.Add("SelectedColor", Style, "ForegroundColor", False, DataSourceUpdateMode.OnPropertyChanged)

        ColorComboBoxBackgroundColor.DataBindings.Clear()
        ColorComboBoxBackgroundColor.DataBindings.Add("SelectedColor", Style, "BackgroundColor", False, DataSourceUpdateMode.OnPropertyChanged)

        FontPickerFont.DataBindings.Clear()
        FontPickerFont.DataBindings.Add("Value", Style, "DisplayFont", False, DataSourceUpdateMode.OnPropertyChanged)

        CheckBoxGrowToFit.DataBindings.Clear()
        CheckBoxGrowToFit.DataBindings.Add("Checked", Style, "GrowToFit", False, DataSourceUpdateMode.OnPropertyChanged)

        TrackBarTransparency.DataBindings.Clear()
        TrackBarTransparency.DataBindings.Add("Value", Style, "Transparency", False, DataSourceUpdateMode.OnPropertyChanged)


        SetStrings()
    End Sub

    Private Sub DialogLookSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        RemoveHandler _previewTimer.Expired, AddressOf PreviewTimer_Expired
        _previewTimer.Dispose()
    End Sub

    Private Sub InitializeRendering()
        timerSurface = New Surface()
        timerSurface.BackColor = Style.BackgroundColor
        timerSurface.Dock = DockStyle.Fill
        PanelRenderPreview.Controls.Add(timerSurface)

        stringFormat = New StringFormat(System.Drawing.StringFormat.GenericTypographic)
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        checkerBoardObject = New BackgroundRenderable(Nothing, True) With {.Rectangle = timerSurface.ClientRectangle}

        renderer = New Renderer(timerSurface)
        renderer.FramesPerSecond = Utils.Framerate

        timerObject = New TextRenderable() With {
            .Color = Style.ForegroundColor,
            .Font = New Font(Style.DisplayFont.FontFamily.Name, 1, Style.DisplayFont.Style),
            .StringFormat = stringFormat,
            .SizeToFit = True,
            .Visible = True,
            .Rectangle = timerSurface.ClientRectangle}

        timerObject.TextRenderFormat = GetTimerTextRenderFunc(Time.CountUpwards)

        renderer.Renderables.Add(timerObject)
        renderer.Renderables.Add(checkerBoardObject)

        UpdateOpacity()
        renderer.Enabled = True
    End Sub
    Private Sub DeinitializeRendering()
        If (renderer IsNot Nothing) Then renderer.Dispose()
        If (timerSurface IsNot Nothing) Then timerSurface.Dispose()
        If (timerObject IsNot Nothing) Then timerObject.Dispose()
    End Sub

    Private Sub RestartRendering()
        DeinitializeRendering()
        InitializeRendering()
    End Sub

    Private Function GetTimerTextRenderFunc(countUpwards As Boolean) As Func(Of String)
        If (countUpwards) Then

            Return Function()
                       Dim remaining As String = If(_previewTimer.RemainingRestarts > 0, "[{0}]", String.Empty)
                       Return String.Format(timeFormat, String.Concat(remaining, "+", "{1:", Style.DisplayFormat, "}"), _previewTimer.RemainingRestarts, _previewTimer.Elapsed)
                   End Function

        Else

            Return Function()
                       Dim remaining As String = If(_previewTimer.RemainingRestarts > 0, "[{0}]", String.Empty)
                       Return String.Format(timeFormat, String.Concat(remaining, "{1:", Style.DisplayFormat, "}"), _previewTimer.RemainingRestarts, _previewTimer.Remaining)
                   End Function
        End If
    End Function

    Private Sub ColorComboBoxForegrounColor_ColorChanged(sender As Object, e As ColorComboTestApp.ColorChangeArgs) Handles ColorComboBoxForegrounColor.ColorChanged
        Try
            timerObject.Color = e.color
            ColorComboBoxBackgroundColor.CustomColors = ColorComboBoxForegrounColor.CustomColors
        Catch ex As Exception
            logger.Error(ex)
        End Try
    End Sub

    Private Sub ColorComboBoxBackgroundColor_ColorChanged(sender As Object, e As ColorComboTestApp.ColorChangeArgs) Handles ColorComboBoxBackgroundColor.ColorChanged
        Try
            timerSurface.BackColor = e.color
            ColorComboBoxForegrounColor.CustomColors = ColorComboBoxBackgroundColor.CustomColors
        Catch ex As Exception
            logger.Error(ex)
        End Try
    End Sub

    Private Sub FontPickerFont_ValueChanged(sender As Object, e As EventArgs) Handles FontPickerFont.ValueChanged
        Try
            Dim font As Font = TryCast(FontPickerFont.Value, Font)
            If (font IsNot Nothing AndAlso timerObject IsNot Nothing) Then
                timerObject.Font = New Font(font.FontFamily.Name, 1, font.Style)
            End If
        Catch ex As Exception
            logger.Error(ex)
        End Try
    End Sub

    Private Sub UpdateUI()
        timerObject.Color = Style.ForegroundColor
        timerSurface.BackColor = Style.BackgroundColor
        ColorComboBoxBackgroundColor.Refresh()
        ColorComboBoxForegrounColor.Refresh()
    End Sub

    Private Sub RestartTimer()
        _previewTimer.Reset(Time.Duration, TimeSpan.Zero, Time.Restarts)
        _previewTimer.Start()
    End Sub

    Private Sub DialogStyleSettings_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Initialize()
        toolTip.SetToolTip(TrackBarTransparency, TrackBarTransparency.Value)
    End Sub
    'TODO: Remove.
    'Private Sub MenuItemLoadStyle_Click(sender As Object, e As EventArgs)
    '    Using dialogOpen As New OpenFileDialog()
    '        dialogOpen.InitialDirectory = InitialDirectory
    '        dialogOpen.CheckPathExists = True
    '        dialogOpen.Filter = FileFilter
    '        If (dialogOpen.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
    '            RaiseEvent Loading(Me, New LoadingEventArgs(dialogOpen.FileName))
    '            UpdateUI()
    '        End If
    '    End Using
    'End Sub
    'TODO: Remove.
    'Private Sub MenuItemSaveStyleAs_Click(sender As Object, e As EventArgs)
    '    Using dialogSave As New SaveFileDialog()
    '        dialogSave.InitialDirectory = Utils.GetStylesPath()
    '        dialogSave.CheckPathExists = True
    '        dialogSave.Filter = My.Settings.StyleDialogFilter
    '        If (dialogSave.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
    '            RaiseEvent Saving(Me, New SavingEventArgs(dialogSave.FileName))
    '        End If
    '    End Using
    'End Sub

    Private Sub TrackBarTransparency_Scroll(sender As Object, e As EventArgs) Handles TrackBarTransparency.Scroll
        toolTip.SetToolTip(TrackBarTransparency, TrackBarTransparency.Value)
    End Sub

    Private Sub TrackBarTransparency_ValueChanged(sender As Object, e As EventArgs) Handles TrackBarTransparency.ValueChanged
        Try
            UpdateOpacity()
        Catch ex As Exception
            logger.Error(ex)
        End Try
    End Sub
    Private Sub UpdateOpacity()
        Dim transparency As Integer = 255 - (((100 - Int16.Parse(TrackBarTransparency.Value)) / 100) * 255)
        If (checkerBoardObject IsNot Nothing) Then
            checkerBoardObject.Brush = New HatchBrush(Drawing2D.HatchStyle.LargeCheckerBoard, Color.FromArgb(transparency, Color.Gray), Color.FromArgb(transparency, Color.White))
        End If
    End Sub

    Private Sub SetStrings()
        Me.SuspendLayout()

        Me.Text = My.Resources.Strings.Style
        Me.LabelRenderer.Text = My.Resources.Strings.DisplayFormat
        Me.LabelFont.Text = My.Resources.Strings.Font
        Me.CheckBoxGrowToFit.Text = My.Resources.Strings.GrowToFit
        Me.LabelBackgroundColor.Text = My.Resources.Strings.BackgroundColor
        Me.LabelForegroundColor.Text = My.Resources.Strings.ForegroundColor
        Me.LabelTransparency.Text = My.Resources.Strings.Transparency
        ' TODO: Figure out how to localize Font selection.
        Me.ResumeLayout()
    End Sub

    Private Sub StyleSettingsDialog_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        RestartRendering()
        RestartTimer()
    End Sub

    Private Sub PreviewTimer_Expired(sender As Object, e As TimerEventArgs)
        RestartTimer()
    End Sub

End Class
