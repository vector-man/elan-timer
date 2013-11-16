Imports System.Windows.Forms
Public Class DialogLookSettings
    Private lookBindingSource As BindingSource
    Private argsBindingSource As BindingSource

    Private timerObject As TimerTextRenderObject
    Private backgroundObject As ClearRenderObject
    Private renderer As Rendering.IRenderer
    Private stringFormat As New StringFormat(System.Drawing.StringFormat.GenericTypographic)
    Private timer As CodeIsle.Timers.AlarmTimer
    Private timerSurface As Rendering.Surface
    Sub LoadSettings()
        Dim rendererList As New List(Of Settings.Models.RendererModel)

        ComboBoxDisplayFormat.DisplayMember = "Key"
        ComboBoxDisplayFormat.ValueMember = "Value"
        ComboBoxDisplayFormat.DataSource = Common.DisplayFormats
        Try
            Me.ComboBoxDisplayFormat.SelectedIndex = 0
            Me.ComboBoxDisplayFormat.SelectedValue = Common.Look.DisplayFormat
        Catch ex As Exception

        End Try
        Me.ColorComboBoxForegrounColor.SelectedColor = Common.Look.ForegroundColor
        Me.ColorComboBoxBackgroundColor.SelectedColor = Common.Look.BackgroundColor
        Me.FontPickerFont.Value = Common.Look.Font
        Me.CheckBoxSizeToFit.Checked = Common.Look.SizeToFit
        Me.NumericUpDownOpacityLevel.Value = Common.Look.Opacity

    End Sub
    Sub SaveSettings()
        Common.Look.Renderer = Me.ComboBoxDisplayFormat.SelectedValue
        Common.Look.ForegroundColor = Me.ColorComboBoxForegrounColor.SelectedColor
        Common.Look.BackgroundColor = Me.ColorComboBoxBackgroundColor.SelectedColor
        Common.Look.Font = Me.FontPickerFont.Value
        Common.Look.SizeToFit = Me.CheckBoxSizeToFit.Checked
        Common.Look.Opacity = Me.NumericUpDownOpacityLevel.Value
        Common.Look.DisplayFormat = Me.ComboBoxDisplayFormat.SelectedValue
        UpdateUI()
    End Sub
    Sub UpdateUI()
        Try
            FormMain.Opacity = Me.NumericUpDownOpacityLevel.Value / 100
            Me.ColorComboBoxBackgroundColor.Refresh()
            Me.ColorComboBoxForegrounColor.Refresh()

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
            Common.Look.CancelEdit()
            FormMain.Opacity = Common.Look.Opacity / 100
        End If
        Common.Look.EndEdit()
        ShutDownRendering()
    End Sub

    Private Sub DialogLookSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Common.Look.BeginEdit()
        Dim rand As New Random
        timer = TimerFactory.CreateInstance(New TimeSpan(0, 0, 30), Common.Time.CountUp, Integer.MaxValue, Nothing, False)
        StartUpRendering(timer)
        LoadSettings()
        timer.Start()
    End Sub

    Private Sub StartUpRendering(ByRef timer As Eggzle.CodeIsle.Timers.AlarmTimer)
        Try
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center
            backgroundObject = New ClearRenderObject(Common.Look.BackgroundColor, True)
            timerObject = New TimerTextRenderObject(timer, Common.Look.Font, Common.Look.DisplayFormat, New TimeFormat, Common.Look.SizeToFit, Common.Look.ForegroundColor, stringFormat, True)
            Dim objects As New List(Of IRenderObject)
            objects.Add(backgroundObject)
            objects.Add(timerObject)
            renderer = New Renderer(objects)
            timerSurface = New PreviewSurface(renderer, NumericUpDownOpacityLevel.Value / 100, Common.Framerate)
            timerSurface.Dock = DockStyle.Fill
            PanelRenderPreview.Controls.Add(timerSurface)
            CType(timerSurface, PreviewSurface).Opacity = NumericUpDownOpacityLevel.Value / 100
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
            backgroundObject.Color = e.color
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FontPickerFont_ValueChanged(sender As Object, e As EventArgs) Handles FontPickerFont.ValueChanged
        Try
            timerObject.Font = FontPickerFont.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBoxSizeToFit_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSizeToFit.CheckedChanged
        Try
            timerObject.SizeToFit = CheckBoxSizeToFit.Checked
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NumericUpDownOpacityLevel_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownOpacityLevel.ValueChanged
        Try
            CType(timerSurface, PreviewSurface).Opacity = NumericUpDownOpacityLevel.Value / 100
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonImport_Click(sender As Object, e As EventArgs) Handles ButtonImport.Click
        Using dialogOpen As New OpenFileDialog
            dialogOpen.InitialDirectory = Common.LookPath
            dialogOpen.CheckFileExists = True
            dialogOpen.Filter = My.Settings.LookDialogFilter
            If dialogOpen.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Try
                    Common.Look.ImportFrom(dialogOpen.FileName)
                    LoadSettings()
                    UpdateUI()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
                End Try
            End If
        End Using
    End Sub

    Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles ButtonExport.Click
        Using dialogSave As New SaveFileDialog
            dialogSave.InitialDirectory = Common.LookPath
            dialogSave.CheckPathExists = True
            dialogSave.Filter = My.Settings.LookDialogFilter
            If dialogSave.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Try
                    SaveSettings()
                    Common.Look.ExportTo(dialogSave.FileName)
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
