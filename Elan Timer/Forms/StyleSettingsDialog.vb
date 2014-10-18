Imports System.Windows.Forms
Imports ElanTimer.CodeIsle.Timers
Imports System.IO
Imports ElanTimer.Rendering
Imports System.Drawing.Drawing2D
Imports NLog
Imports PropertyChanged
<ImplementPropertyChanged>
Public Class StyleSettingsDialog
    Private timerObject As New TextRenderable
    Private _previewTimer As AlarmTimer
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

        Initialize()
    End Sub
#Region "Properties"
    Public Property DisplayFormats As List(Of KeyValuePair(Of String, String))
        Get
            Return ComboBoxDisplayFormat.DataSource
        End Get
        Set(value As List(Of KeyValuePair(Of String, String)))
            ComboBoxDisplayFormat.DataSource = value
        End Set
    End Property

    Public Property DisplayFormat As String

    Public Property ForegroundColor As Color

    Public Property BackgroundColor As Color

    Public Property DisplayFont As Font

    Public Property CustomStyleColors As Integer()
        Get
            Return ColorComboBoxForegrounColor.CustomColors
        End Get
        Set(value As Integer())
            ColorComboBoxForegrounColor.CustomColors = value
            ColorComboBoxBackgroundColor.CustomColors = value
        End Set
    End Property

    Public Property GrowToFit As Boolean

    Public Property Transparency As Integer

    Public Property Timer As AlarmTimer

    Public Property InitialDirectory As String

    Public Property FileFilter As String
#End Region
#Region "Events"
    Public Event Loading As EventHandler(Of LoadingEventArgs)
    Public Event Saving As EventHandler(Of SavingEventArgs)
#End Region
    Sub Initialize()
        ComboBoxDisplayFormat.DataBindings.Clear()
        ComboBoxDisplayFormat.DataBindings.Add("SelectedValue", Me, "DisplayFormat", False, DataSourceUpdateMode.OnPropertyChanged)
        ComboBoxDisplayFormat.DisplayMember = "Key"
        ComboBoxDisplayFormat.ValueMember = "Value"

        ColorComboBoxForegrounColor.DataBindings.Clear()
        ColorComboBoxForegrounColor.DataBindings.Add("SelectedColor", Me, "ForegroundColor", False, DataSourceUpdateMode.OnPropertyChanged)

        ColorComboBoxBackgroundColor.DataBindings.Clear()
        ColorComboBoxBackgroundColor.DataBindings.Add("SelectedColor", Me, "BackgroundColor", False, DataSourceUpdateMode.OnPropertyChanged)

        FontPickerFont.DataBindings.Clear()
        FontPickerFont.DataBindings.Add("Value", Me, "DisplayFont", False, DataSourceUpdateMode.OnPropertyChanged)

        CheckBoxGrowToFit.DataBindings.Clear()
        CheckBoxGrowToFit.DataBindings.Add("Checked", Me, "GrowToFit", False, DataSourceUpdateMode.OnPropertyChanged)

        TrackBarTransparency.DataBindings.Clear()
        TrackBarTransparency.DataBindings.Add("Value", Me, "Transparency", False, DataSourceUpdateMode.OnPropertyChanged)

        SetStrings()
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        Me.StartPosition = If(Owner Is Nothing, FormStartPosition.CenterScreen, FormStartPosition.CenterParent)
        Me.TopMost = True
        MyBase.OnLoad(e)
    End Sub

    Private Sub DialogLookSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        _previewTimer.Dispose()
    End Sub

    Private Sub StartUpRendering()
        timerSurface = New Surface()
        timerSurface.BackColor = BackgroundColor
        timerSurface.Dock = DockStyle.Fill
        PanelRenderPreview.Controls.Add(timerSurface)

        stringFormat = New StringFormat(System.Drawing.StringFormat.GenericTypographic)
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        timerObject = New TextRenderable() With {
            .Color = ForegroundColor,
            .Font = New Font(DisplayFont.FontFamily.Name, 1, DisplayFont.Style),
            .StringFormat = stringFormat,
            .SizeToFit = True,
            .Visible = True,
            .Rectangle = timerSurface.ClientRectangle}

        Dim prefix As String = If(TypeOf Timer Is CountUpAlarmTimer, CountUpPrefix, String.Empty)
        timerObject.TextRenderFormat = Function() String.Format(timeFormat, String.Concat(prefix, "{0:", DisplayFormat, "}"), _previewTimer.Current)

        checkerBoardObject = New BackgroundRenderable(Nothing, True) With {.Rectangle = timerSurface.ClientRectangle}


        renderer = New Renderer(timerSurface)
        renderer.FramesPerSecond = Utils.Framerate

        renderer.Renderables.Add(timerObject)
        renderer.Renderables.Add(checkerBoardObject)

        UpdateOpacity()
        renderer.Enabled = True
    End Sub

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

    Private Sub ButtonOptions_Click(sender As Object, e As EventArgs) Handles ButtonOptions.Click
        ContextMenuOptions.Show(ButtonOptions, New Point(0, ButtonOptions.Height))
    End Sub

    Private Sub UpdateUI()
        timerObject.Color = ForegroundColor
        timerSurface.BackColor = BackgroundColor
        ColorComboBoxBackgroundColor.Refresh()
        ColorComboBoxForegrounColor.Refresh()
    End Sub
    Private Sub ComboBoxDisplayFormat_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxDisplayFormat.SelectedValueChanged
        Try
            Dim format As String = TryCast(ComboBoxDisplayFormat.SelectedValue, String)
            If (format IsNot Nothing AndAlso timerObject IsNot Nothing) Then
                ' TODO: Remove line.
                ' timerObject.Format = format
            End If
        Catch ex As Exception
            logger.Error(ex)
        End Try
    End Sub

    Private Sub DialogStyleSettings_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        _previewTimer = TimerFactory.CreateInstance(Timer.Duration, (TypeOf Timer Is CountUpAlarmTimer), Integer.MaxValue, Nothing, False)
        StartUpRendering()
        _previewTimer.Start()

        toolTip.SetToolTip(TrackBarTransparency, TrackBarTransparency.Value)
    End Sub

    Private Sub MenuItemLoadStyle_Click(sender As Object, e As EventArgs) Handles MenuItemLoadStyle.Click
        Using dialogOpen As New OpenFileDialog()
            dialogOpen.InitialDirectory = InitialDirectory
            dialogOpen.CheckPathExists = True
            dialogOpen.Filter = FileFilter
            If (dialogOpen.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
                RaiseEvent Loading(Me, New LoadingEventArgs(dialogOpen.FileName))
                UpdateUI()
            End If
        End Using
    End Sub

    Private Sub MenuItemSaveStyleAs_Click(sender As Object, e As EventArgs) Handles MenuItemSaveStyleAs.Click
        Using dialogSave As New SaveFileDialog()
            dialogSave.InitialDirectory = Utils.GetStylesPath()
            dialogSave.CheckPathExists = True
            dialogSave.Filter = My.Settings.StyleDialogFilter
            If (dialogSave.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
                RaiseEvent Saving(Me, New SavingEventArgs(dialogSave.FileName))
            End If
        End Using
    End Sub

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
        Me.ButtonOptions.Text = My.Resources.Strings.Options
        Me.MenuItemLoadStyle.Text = My.Resources.Strings.LoadStyle
        Me.MenuItemSaveStyleAs.Text = My.Resources.Strings.SaveStyleAs
        Me.ButtonOK.Text = My.Resources.Strings.Ok
        Me.ButtonCancel.Text = My.Resources.Strings.Cancel
        ' TODO: Figure out how to localize Font selection.
        Me.ResumeLayout()
    End Sub
End Class
