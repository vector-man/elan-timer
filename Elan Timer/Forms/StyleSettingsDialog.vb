Imports System.Windows.Forms
Imports ElanTimer.Prefs
Imports ElanTimer.CodeIsle.Timers
Imports System.IO

Public Class StyleSettingsDialog
    ' Preview time is 1 hour 33 minutes and 7 seconds (5587 seconds total), or 1337. Add a second, so it can be seen.
    Private Const PreviewTime As Long = 5588

    Private timerObject As TimerTextRenderObject
    Private renderer As Rendering.IRenderer
    Private stringFormat As New StringFormat(System.Drawing.StringFormat.GenericTypographic)
    Private timerSurface As Rendering.Surface
    Private loaded As Boolean = False
    Private transporter As New JsonNetTransporter()
    Private style As New StyleModel(transporter)
    Private toolTip As New ToolTip()
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

    Sub Initialize()
        ComboBoxDisplayFormat.DataBindings.Add("SelectedValue", style, "DisplayFormat", False, DataSourceUpdateMode.OnPropertyChanged)
        ColorComboBoxForegrounColor.DataBindings.Add("SelectedColor", style, "ForegroundColor", False, DataSourceUpdateMode.OnPropertyChanged)
        ColorComboBoxBackgroundColor.DataBindings.Add("SelectedColor", style, "BackgroundColor", False, DataSourceUpdateMode.OnPropertyChanged)
        FontPickerFont.DataBindings.Add("Value", style, "DisplayFont", False, DataSourceUpdateMode.OnPropertyChanged)
        CheckBoxGrowToFit.DataBindings.Add("Checked", style, "GrowToFit", False, DataSourceUpdateMode.OnPropertyChanged)
        TrackBarTransparency.DataBindings.Add("Value", style, "Transparency", False, DataSourceUpdateMode.OnPropertyChanged)

        ComboBoxDisplayFormat.DisplayMember = "Key"
        ComboBoxDisplayFormat.ValueMember = "Value"
    End Sub

    Private Sub DialogLookSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Timer.Dispose()
    End Sub

    Private Sub StartUpRendering(ByRef timer As ElanTimer.CodeIsle.Timers.AlarmTimer)

        Try
            stringFormat = New StringFormat(System.Drawing.StringFormat.GenericTypographic)
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center
            timerObject = New TimerTextRenderObject(timer, New Font(DisplayFont.FontFamily.Name, 1, DisplayFont.Style), DisplayFormat, New TimeFormat(), True, ForegroundColor, stringFormat, True)
            Dim objects As New List(Of IRenderObject)
            objects.Add(timerObject)
            renderer = New Renderer(objects)
            timerSurface = New PreviewSurface(renderer, (100 - TrackBarTransparency.Value) / 100, Common.Framerate)
            timerSurface.BackColor = BackgroundColor
            timerSurface.Dock = DockStyle.Fill
            PanelRenderPreview.Controls.Add(timerSurface)
            CType(timerSurface, PreviewSurface).Opacity = (100 - TrackBarTransparency.Value) / 100
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ShutDownRendering()
        PanelRenderPreview.Controls.Clear()
    End Sub

    Private Sub ColorComboBoxForegrounColor_ColorChanged(sender As Object, e As ColorComboTestApp.ColorChangeArgs) Handles ColorComboBoxForegrounColor.ColorChanged
        Try
            timerObject.Color = e.color
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ColorComboBoxBackgroundColor_ColorChanged(sender As Object, e As ColorComboTestApp.ColorChangeArgs) Handles ColorComboBoxBackgroundColor.ColorChanged
        Try
            timerSurface.BackColor = e.color
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

    Private Sub ButtonExport_Click(sender As Object, e As EventArgs)
        Using dialogSave As New SaveFileDialog()
            ' TODO: Fix initial directory.
            ' dialogSave.InitialDirectory = Preferences.StylePath
            dialogSave.CheckPathExists = True
            dialogSave.Filter = My.Settings.StyleDialogFilter
            If dialogSave.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Using stream As FileStream = File.Create(dialogSave.FileName)
                    style.Export(stream)
                End Using
            End If
        End Using
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
        Timer = TimerFactory.CreateInstance(New TimeSpan(0, 0, PreviewTime), (Timer Is GetType(CountUpAlarmTimer)), Integer.MaxValue, Nothing, False)
        StartUpRendering(Timer)
        Timer.Start()

        toolTip.SetToolTip(TrackBarTransparency, TrackBarTransparency.Value)
    End Sub

    Private Sub MenuItemLoadStyle_Click(sender As Object, e As EventArgs) Handles MenuItemLoadStyle.Click
        Using dialogOpen As New OpenFileDialog()
            dialogOpen.CheckPathExists = True
            dialogOpen.Filter = My.Settings.StyleDialogFilter
            If dialogOpen.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Using stream As FileStream = File.OpenRead(dialogOpen.FileName)
                    style.Import(stream)
                    UpdateUI()
                End Using
            End If
        End Using
    End Sub

    Private Sub MenuItemSaveStyleAs_Click(sender As Object, e As EventArgs) Handles MenuItemSaveStyleAs.Click
        Using dialogSave As New SaveFileDialog()
            ' TODO: Fix initial directory.
            ' dialogSave.InitialDirectory = Preferences.StylePath
            dialogSave.CheckPathExists = True
            dialogSave.Filter = My.Settings.StyleDialogFilter
            If dialogSave.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Using stream As FileStream = File.Create(dialogSave.FileName)
                    style.Export(stream)
                End Using
            End If
        End Using
    End Sub

    Private Sub TrackBarTransparency_Scroll(sender As Object, e As EventArgs) Handles TrackBarTransparency.Scroll
        toolTip.SetToolTip(TrackBarTransparency, TrackBarTransparency.Value)
    End Sub

    Private Sub TrackBarTransparency_ValueChanged(sender As Object, e As EventArgs) Handles TrackBarTransparency.ValueChanged
        Try
            CType(timerSurface, PreviewSurface).Opacity = (100 - Transparency) / 100
        Catch ex As Exception

        End Try
    End Sub
End Class
