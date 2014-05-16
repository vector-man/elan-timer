Imports System.Windows.Forms
Imports ElanTimer.Prefs
Imports ElanTimer.CodeIsle.Timers
Imports System.IO

Public Class DialogStyleSettings
    ' Preview time is 1 hour 33 minutes and 7 seconds (5587 seconds total), or 1337. Add a second, so it can be seen.
    Private Const PreviewTime As Long = 5588

    Private timerObject As TimerTextRenderObject
    Private renderer As Rendering.IRenderer
    Private stringFormat As New StringFormat(System.Drawing.StringFormat.GenericTypographic)
    Private timerSurface As Rendering.Surface
    Private loaded As Boolean = False
    Private transporter As New JsonNetTransporter()
    Private style As New StyleModel(transporter)
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
    '  Public Property SaveAction As Action(Of String)
    '  Public Property LoadAction As Action(Of String)

    Sub Initialize()
        'Dim binding As New BindingSource()
        'binding.DataSource = style
        ComboBoxDisplayFormat.DataBindings.Add("SelectedValue", style, "DisplayFormat", False, DataSourceUpdateMode.OnPropertyChanged)
        ColorComboBoxForegrounColor.DataBindings.Add("SelectedColor", style, "ForegroundColor", False, DataSourceUpdateMode.OnPropertyChanged)
        ColorComboBoxBackgroundColor.DataBindings.Add("SelectedColor", style, "BackgroundColor", False, DataSourceUpdateMode.OnPropertyChanged)
        FontPickerFont.DataBindings.Add("Value", style, "DisplayFont", False, DataSourceUpdateMode.OnPropertyChanged)
        CheckBoxGrowToFit.DataBindings.Add("Checked", style, "GrowToFit", False, DataSourceUpdateMode.OnPropertyChanged)
        NumericUpDownTransparencyLevel.DataBindings.Add("Value", style, "Transparency", False, DataSourceUpdateMode.OnPropertyChanged)

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
            timerObject = New TimerTextRenderObject(timer, DisplayFont, DisplayFormat, New TimeFormat(), True, ForegroundColor, stringFormat, True)
            Dim objects As New List(Of IRenderObject)
            objects.Add(timerObject)
            renderer = New Renderer(objects)
            timerSurface = New PreviewSurface(renderer, (100 - NumericUpDownTransparencyLevel.Value) / 100, Common.Framerate)
            timerSurface.BackColor = BackgroundColor
            timerSurface.Dock = DockStyle.Fill
            PanelRenderPreview.Controls.Add(timerSurface)
            CType(timerSurface, PreviewSurface).Opacity = (100 - NumericUpDownTransparencyLevel.Value) / 100
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
            timerObject.Font = FontPickerFont.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NumericUpDownOpacityLevel_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownTransparencyLevel.ValueChanged
        Try
            CType(timerSurface, PreviewSurface).Opacity = (100 - Transparency) / 100
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonImport_Click(sender As Object, e As EventArgs) Handles ButtonLoad.Click
        Using dialogOpen As New OpenFileDialog()
            dialogOpen.CheckPathExists = True
            dialogOpen.Filter = My.Settings.StyleDialogFilter
            If dialogOpen.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Using stream As FileStream = File.OpenRead(dialogOpen.FileName)
                    style.Import(stream)
                    UpdateUI()
                End Using
                ' LoadAction.DynamicInvoke(dialogOpen.FileName)
            End If
        End Using
        ' TODO: Fix code. Possibly replace with Import event handled in the owner form.
        'Using dialogOpen As New OpenFileDialog
        '    dialogOpen.InitialDirectory = Preferences.StylePath
        '    dialogOpen.CheckFileExists = True
        '    dialogOpen.Filter = My.Settings.StyleDialogFilter
        '    If dialogOpen.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        '        Try
        '            Preferences.Style.ImportFrom(dialogOpen.FileName)
        '            Initialize()
        '            UpdateUI()
        '        Catch ex As Exception
        '            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
        '        End Try
        '    End If
        'End Using
    End Sub

    Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles ButtonSaveAs.Click
        ' TODO: Fix code. Possibly replace with Export event handled in the owner form.
        Using dialogSave As New SaveFileDialog()
            '    dialogSave.InitialDirectory = Preferences.StylePath
            dialogSave.CheckPathExists = True
            dialogSave.Filter = My.Settings.StyleDialogFilter
            If dialogSave.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Using stream As FileStream = File.Create(dialogSave.FileName)
                    style.Export(stream)
                End Using
                ' SaveAction.DynamicInvoke(dialogSave.FileName)
            End If
        End Using

        '        Try
        '            SaveSettings()
        '            Preferences.Style.ExportTo(dialogSave.FileName)
        '        Catch ex As Exception
        '            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
        '        End Try
        '    End If
        'End Using
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
    End Sub
End Class
