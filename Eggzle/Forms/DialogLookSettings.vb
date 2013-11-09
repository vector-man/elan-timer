Imports System.Windows.Forms
Public Class DialogLookSettings
    Private lookBindingSource As BindingSource
    Private argsBindingSource As BindingSource
    Private args As RenderArgs
    Private timer As CodeIsle.Timers.AlarmTimer
    Private timerInfo As Information.TimerInfo
    Private timerSurface As Rendering.Surface
    Private Const renderRate As Integer = 1000 / 10
    Sub LoadSettings()
        args = New RenderArgs(
                              Nothing,
                              Nothing,
                              Common.Look.Font,
                              Common.Look.BackgroundColor,
                              Common.Look.ForegroundColor,
                              Common.Look.SizeToFit, New Information.TimerInfo(timer),
                              New TimeFormat,
                              String.Empty,
                              Common.Time.Note
                              )
        Dim rendererList As New List(Of Settings.Models.RendererModel)

        ComboBoxDisplayFormat.DisplayMember = "Key"
        ComboBoxDisplayFormat.ValueMember = "Value"
        ComboBoxDisplayFormat.DataSource = Common.DisplayFormats
        Try
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
        ShutDownRendering()
        timer.Dispose()
        If (Not Me.DialogResult = Windows.Forms.DialogResult.OK) Then
            Common.Look.CancelEdit()
            FormMain.Opacity = Common.Look.Opacity / 100
        End If
        Common.Look.EndEdit()
    End Sub

    Private Sub DialogLookSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Common.Look.BeginEdit()
        Dim rand As New Random
        timer = TimerFactory.CreateInstance(New TimeSpan(0, 0, 30), Common.Time.CountUp, Integer.MaxValue, Nothing, False)
        LoadSettings()

        ShutDownRendering()
        StartUpRendering(timer, ComboBoxStyle.SelectedValue)
        timer.Start()
    End Sub

    Private Sub StartUpRendering(ByRef timer As Eggzle.CodeIsle.Timers.AlarmTimer, rendererId As String)
        Try
            timerInfo = New Information.TimerInfo(timer)

            timerSurface = Rendering.SurfaceFactory.CreateInstance(New EggzleRenderer, args, True, renderRate)
            timerSurface.Dock = DockStyle.Fill
            PanelRenderPreview.Controls.Add(timerSurface)
            CType(timerSurface, PreviewSurface).Opacity = NumericUpDownOpacityLevel.Value / 100
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ShutDownRendering()
        Try
            timerInfo = Nothing
            PanelRenderPreview.Controls.Clear()
            timerSurface.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ColorComboBoxForegrounColor_ColorChanged(sender As Object, e As ColorComboTestApp.ColorChangeArgs) Handles ColorComboBoxForegrounColor.ColorChanged
        Try
            args.ForegroundColor = e.color
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBoxDisplayFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDisplayFormat.SelectedIndexChanged
        args.Format = ComboBoxDisplayFormat.SelectedValue
    End Sub

    Private Sub ColorComboBoxBackgroundColor_ColorChanged(sender As Object, e As ColorComboTestApp.ColorChangeArgs) Handles ColorComboBoxBackgroundColor.ColorChanged
        Try
            args.BackgroundColor = e.color
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FontPickerFont_ValueChanged(sender As Object, e As EventArgs) Handles FontPickerFont.ValueChanged
        Try
            args.Font = FontPickerFont.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBoxSizeToFit_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSizeToFit.CheckedChanged
        Try
            args.SizeToFit = CheckBoxSizeToFit.Checked
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
    'Private Sub SetDialogValues(look As Settings.LookSettings)
    '    Me.ComboBoxRenderer.SelectedValue = look.Renderer
    '    Me.ColorComboBoxForegrounColor.SelectedColor = look.ForegroundColor
    '    Me.ColorComboBoxBackgroundColor.SelectedColor = look.BackgroundColor
    '    Me.FontPickerFont.Value = look.Font
    '    Me.CheckBoxSizeToFit.Checked = look.SizeToFit
    '    Me.NumericUpDownOpacityLevel.Value = look.Opacity

    '    args.ForegroundColor = look.ForegroundColor
    '    args.BackgroundColor = look.BackgroundColor
    '    args.Font = look.Font
    '    args.SizeToFit = look.SizeToFit
    'End Sub

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
End Class
