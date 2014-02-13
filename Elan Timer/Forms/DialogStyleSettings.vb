Imports System.Windows.Forms
Imports ElanTimer.Prefs
Public Class DialogStyleSettings
    Private lookBindingSource As BindingSource
    Private argsBindingSource As BindingSource

    Private timerObject As TimerTextRenderObject
    Private renderer As Rendering.IRenderer
    Private stringFormat As New StringFormat(System.Drawing.StringFormat.GenericTypographic)
    Private timer As CodeIsle.Timers.AlarmTimer
    Private timerSurface As Rendering.Surface
    ' Preview time is 1 hour 33 minutes and 7 seconds (5587 seconds total), or 1337. Add a second, so it can be seen.
    Private Const PreviewTime As Long = 5588
    Sub LoadSettings()
        Dim rendererList As New List(Of Prefs.Models.RendererModel)

        ComboBoxDisplayFormat.DisplayMember = "Key"
        ComboBoxDisplayFormat.ValueMember = "Value"
        ComboBoxDisplayFormat.DataSource = Common.DisplayFormats
        Try
            Me.ComboBoxDisplayFormat.SelectedIndex = 0
            Me.ComboBoxDisplayFormat.SelectedValue = Preferences.Style.DisplayFormat
        Catch ex As Exception

        End Try
        Me.ColorComboBoxForegrounColor.SelectedColor = Preferences.Style.ForegroundColor
        Me.ColorComboBoxBackgroundColor.SelectedColor = Preferences.Style.BackgroundColor
        Me.FontPickerFont.Value = Preferences.Style.Font
        Me.CheckBoxGrowToFit.Checked = Preferences.Style.GrowToFit
        Me.NumericUpDownTransparencyLevel.Value = (100 - Preferences.Style.Opacity)

    End Sub
    Sub SaveSettings()
        Preferences.Style.Renderer = Me.ComboBoxDisplayFormat.SelectedValue
        Preferences.Style.ForegroundColor = Me.ColorComboBoxForegrounColor.SelectedColor
        Preferences.Style.BackgroundColor = Me.ColorComboBoxBackgroundColor.SelectedColor
        Preferences.Style.Font = Me.FontPickerFont.Value
        Preferences.Style.GrowToFit = Me.CheckBoxGrowToFit.Checked
        Preferences.Style.Opacity = (100 - Me.NumericUpDownTransparencyLevel.Value)
        Preferences.Style.DisplayFormat = Me.ComboBoxDisplayFormat.SelectedValue
        UpdateUI()
    End Sub
    Sub UpdateUI()
        Try
            FormMain.Opacity = (100 - Me.NumericUpDownTransparencyLevel.Value) / 100
            Me.ColorComboBoxBackgroundColor.Refresh()
            Me.ColorComboBoxForegrounColor.Refresh()
            timerObject.Color = Preferences.Style.ForegroundColor
            timerSurface.BackColor = Preferences.Style.BackgroundColor
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        SaveSettings()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DialogLookSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        timer.Dispose()
        If (Not Me.DialogResult = Windows.Forms.DialogResult.OK) Then
            Preferences.Style.CancelEdit()
            FormMain.Opacity = Preferences.Style.Opacity / 100
        End If
        Preferences.Style.EndEdit()
        ShutDownRendering()
    End Sub

    Private Sub DialogLookSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Preferences.Style.BeginEdit()
        Dim rand As New Random
        timer = TimerFactory.CreateInstance(New TimeSpan(0, 0, PreviewTime), Preferences.Time.CountUp, Integer.MaxValue, Nothing, False)
        StartUpRendering(timer)
        LoadSettings()
        timer.Start()
    End Sub

    Private Sub StartUpRendering(ByRef timer As ElanTimer.CodeIsle.Timers.AlarmTimer)
        Try
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center
            stringFormat.FormatFlags = StringFormatFlags.NoWrap
            timerObject = New TimerTextRenderObject(timer, New Font(Preferences.Style.Font.FontFamily, 1, Preferences.Style.Font.Style), Preferences.Style.DisplayFormat, New TimeFormat, True, Preferences.Style.ForegroundColor, stringFormat, True)
            Dim objects As New List(Of IRenderObject)
            objects.Add(timerObject)
            renderer = New Renderer(objects)
            timerSurface = New PreviewSurface(renderer, (100 - NumericUpDownTransparencyLevel.Value) / 100, Common.Framerate)
            timerSurface.BackColor = Preferences.Style.BackgroundColor
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
            Dim pickedFont As Font = FontPickerFont.Value
            timerObject.Font = New Font(pickedFont.FontFamily, 1, pickedFont.Style)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NumericUpDownOpacityLevel_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownTransparencyLevel.ValueChanged
        Try
            CType(timerSurface, PreviewSurface).Opacity = (100 - NumericUpDownTransparencyLevel.Value) / 100
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonImport_Click(sender As Object, e As EventArgs) Handles ButtonLoad.Click
        Using dialogOpen As New OpenFileDialog
            dialogOpen.InitialDirectory = Preferences.StylePath
            dialogOpen.CheckFileExists = True
            dialogOpen.Filter = My.Settings.StyleDialogFilter
            If dialogOpen.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Try
                    Preferences.Style.ImportFrom(dialogOpen.FileName)
                    LoadSettings()
                    UpdateUI()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
                End Try
            End If
        End Using
    End Sub

    Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles ButtonSaveAs.Click
        Using dialogSave As New SaveFileDialog
            dialogSave.InitialDirectory = Preferences.StylePath
            dialogSave.CheckPathExists = True
            dialogSave.Filter = My.Settings.StyleDialogFilter
            If dialogSave.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Try
                    SaveSettings()
                    Preferences.Style.ExportTo(dialogSave.FileName)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
                End Try
            End If
        End Using
    End Sub

    Private Sub ComboBoxDisplayFormat_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxDisplayFormat.SelectedValueChanged
        timerObject.Format = ComboBoxDisplayFormat.SelectedValue
    End Sub
End Class
