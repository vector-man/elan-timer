Imports System.Windows.Forms
Imports ElanTimer.Prefs
Imports ElanTimer.CodeIsle.Timers
Imports System.IO

Imports ElanTimer.Rendering
Imports System.Drawing.Drawing2D

Public Class StyleSettingsDialog
    ' Preview time is 1 hour 33 minutes and 7 seconds (5587 seconds total), or 1337. Add a second, so it can be seen.
    Private Const PreviewTime As Long = 5588

    Private timerObject As TimerTextRenderable
    Private _previewTimer As AlarmTimer
    Private checkerBoardObject As BackgroundRenderable
    Private renderer As Renderer
    Private stringFormat As New StringFormat(System.Drawing.StringFormat.GenericTypographic)
    Private timerSurface As Rendering.Surface
    Private loaded As Boolean = False
    Private style As New StyleModel()
    Private toolTip As New ToolTip()
    Private Const CountUpPrefix As String = "+"
    Dim _customStyleColors As Integer()

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        Initialize()
    End Sub
    Public Property DisplayFormats As List(Of KeyValuePair(Of String, String))
        Get
            Return ComboBoxDisplayFormat.DataSource
        End Get
        Set(value As List(Of KeyValuePair(Of String, String)))
            ComboBoxDisplayFormat.DataSource = value
        End Set
    End Property

    Public Property DisplayFormat As String
        Get
            Return style.DisplayFormat
        End Get
        Set(value As String)
            style.DisplayFormat = value
        End Set
    End Property

    Public Property ForegroundColor As Color
        Get
            Return style.ForegroundColor
        End Get
        Set(value As Color)
            style.ForegroundColor = value
        End Set
    End Property

    Public Property BackgroundColor As Color
        Get
            Return style.BackgroundColor
        End Get
        Set(value As Color)
            style.BackgroundColor = value
        End Set
    End Property

    Public Property DisplayFont As Font
        Get
            Return style.DisplayFont
        End Get
        Set(value As Font)
            style.DisplayFont = value
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

    Public Property GrowToFit As Boolean
        Get
            Return style.GrowToFit
        End Get
        Set(value As Boolean)
            style.GrowToFit = value
        End Set
    End Property

    Public Property Transparency As Integer
        Get
            Return style.Transparency
        End Get
        Set(value As Integer)
            style.Transparency = value
        End Set
    End Property
    Public Property Timer As AlarmTimer
    Public Property InitialDirectory As String
    Public Property FileFilter As String

    Sub Initialize()
        ComboBoxDisplayFormat.DataBindings.Add("SelectedValue", style, "DisplayFormat", False, DataSourceUpdateMode.OnPropertyChanged)
        ColorComboBoxForegrounColor.DataBindings.Add("SelectedColor", style, "ForegroundColor", False, DataSourceUpdateMode.OnPropertyChanged)
        ColorComboBoxBackgroundColor.DataBindings.Add("SelectedColor", style, "BackgroundColor", False, DataSourceUpdateMode.OnPropertyChanged)
        FontPickerFont.DataBindings.Add("Value", style, "DisplayFont", False, DataSourceUpdateMode.OnPropertyChanged)
        CheckBoxGrowToFit.DataBindings.Add("Checked", style, "GrowToFit", False, DataSourceUpdateMode.OnPropertyChanged)
        TrackBarTransparency.DataBindings.Add("Value", style, "Transparency", False, DataSourceUpdateMode.OnPropertyChanged)

        ComboBoxDisplayFormat.DisplayMember = "Key"
        ComboBoxDisplayFormat.ValueMember = "Value"

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

        Try
            stringFormat = New StringFormat(System.Drawing.StringFormat.GenericTypographic)
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center
            timerObject = New TimerTextRenderable(_previewTimer, New Font(DisplayFont.FontFamily.Name, 1, DisplayFont.Style), DisplayFormat, New TimeFormat(), True, ForegroundColor, stringFormat, True)
            timerObject.Prefix = If(TypeOf _previewTimer Is CountUpAlarmTimer, CountUpPrefix, String.Empty)
            checkerBoardObject = New BackgroundRenderable(Nothing, True)

            timerSurface = New Surface()
            timerSurface.BackColor = BackgroundColor
            timerSurface.Dock = DockStyle.Fill
            PanelRenderPreview.Controls.Add(timerSurface)

            timerObject.Rectangle = timerSurface.ClientRectangle
            checkerBoardObject.Rectangle = timerSurface.ClientRectangle

            renderer = New Renderer(timerSurface)
            renderer.FramesPerSecond = Utils.Framerate

            renderer.Renderables.Add(timerObject)
            renderer.Renderables.Add(checkerBoardObject)

            UpdateOpacity()
            renderer.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub ShutDownRendering()
        PanelRenderPreview.Controls.Clear()
    End Sub

    Private Sub ColorComboBoxForegrounColor_ColorChanged(sender As Object, e As ColorComboTestApp.ColorChangeArgs) Handles ColorComboBoxForegrounColor.ColorChanged
        Try
            timerObject.Color = e.color
            ColorComboBoxBackgroundColor.CustomColors = ColorComboBoxForegrounColor.CustomColors
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ColorComboBoxBackgroundColor_ColorChanged(sender As Object, e As ColorComboTestApp.ColorChangeArgs) Handles ColorComboBoxBackgroundColor.ColorChanged
        Try
            timerSurface.BackColor = e.color
            ColorComboBoxForegrounColor.CustomColors = ColorComboBoxBackgroundColor.CustomColors
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FontPickerFont_ValueChanged(sender As Object, e As EventArgs) Handles FontPickerFont.ValueChanged
        Try
            Dim fnt = FontPickerFont.Value
            timerObject.Font = New Font(fnt.FontFamily.Name, 1, fnt.Style)
        Catch ex As Exception

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
            timerObject.Format = ComboBoxDisplayFormat.SelectedValue
        Catch ex As Exception

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
            If dialogOpen.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
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
            If dialogSave.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
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

        End Try
    End Sub
    Private Sub UpdateOpacity()
        Dim transparency As Integer = 255 - (((100 - TrackBarTransparency.Value) / 100) * 255)
        checkerBoardObject.Brush = New HatchBrush(Drawing2D.HatchStyle.LargeCheckerBoard, Color.FromArgb(transparency, Color.Gray), Color.FromArgb(transparency, Color.White))
    End Sub
    Public Event Loading As EventHandler(Of LoadingEventArgs)
    Public Event Saving As EventHandler(Of SavingEventArgs)

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
