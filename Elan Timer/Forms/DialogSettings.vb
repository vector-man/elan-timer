﻿Public Class DialogSettings

    Private applicationBindingSource As BindingSource
    'Public odb As NDatabase.Odb.IOdb
    'Private Sub TrackBarOpacity_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim Value As SByte = TrackBarOpacity.Value
    '    If Value > 0 Then
    '        FormMain.Opacity = Value / 100
    '    Else
    '        FormMain.Opacity = 0
    '    End If
    '    LabelOpacityLevel.Text = Value & "%"
    'End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Me.Close()
    End Sub


    Private Sub PictureBoxPreview_Paint(sender As Object, e As PaintEventArgs)
        'previewRenderSettiings.Size = PictureBoxPreview.ClientRectangle.Size

        'previewRenderer.Render(e, previewRenderSettiings, PictureBoxPreview.ClientRectangle.Size)

        'Using hbrush As New System.Drawing.Drawing2D.HatchBrush(Drawing2D.HatchStyle.LargeCheckerBoard, Color.FromArgb(255 - (previewRenderSettiings.PreviewOpacity / 100) * 255, Color.LightGray), Color.FromArgb(255 - (previewRenderSettiings.PreviewOpacity / 100) * 255, Color.White))
        '    e.Graphics.FillRectangle(hbrush, 0, 0, PictureBoxPreview.ClientRectangle.Size.Width, PictureBoxPreview.ClientRectangle.Size.Height)
        'End Using

    End Sub

    Private Sub FormSettings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub FormSettings_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'previewRenderSettiings = New CodeIsle.Plugins.TimerContext(New CodeIsle.Timers.CountUpAlarmTimer(New TimeSpan()), PictureBoxPreview.ClientRectangle.Size)
        'previewRenderer = New CodeIsle.Plugins.Renderers.DefaultRenderer
    End Sub
    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        My.Settings.Language = CType(ComboBoxLanguage.SelectedItem, System.Globalization.CultureInfo).Name
        My.Settings.CloseToSystemTray = CheckBoxCloseToSystemTray.Checked
        My.Settings.ShowInSystemTray = CheckBoxShowInSystemTray.Checked
        My.Settings.ClickingTrayIconStopsAlarm = CheckBoxClickingTrayIconStopsAlarm.Checked
        My.Settings.Save()
        Common.Languages.SetUICulture(ComboBoxLanguage.SelectedItem)
        Common.SetStrings()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        applicationBindingSource = New BindingSource

        applicationBindingSource.DataSource = My.Settings
        'End Using


        ComboBoxLanguage.DisplayMember = "NativeName"
        'ComboBoxLanguage.ValueMember = "Key"
        ComboBoxLanguage.DataSource = Common.Languages.Cultures
    End Sub

    Private Sub FormConfiguration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CheckBoxCloseToSystemTray.Checked = My.Settings.CloseToSystemTray
            CheckBoxShowInSystemTray.Checked = My.Settings.ShowInSystemTray
            CheckBoxClickingTrayIconStopsAlarm.Checked = My.Settings.ClickingTrayIconStopsAlarm
            ComboBoxLanguage.SelectedItem = Common.Languages.Cultures.Where(Function(item) item.Name = My.Settings.Language).First
            CheckBoxCloseToSystemTray.Enabled = CheckBoxShowInSystemTray.Checked
            CheckBoxClickingTrayIconStopsAlarm.Enabled = CheckBoxShowInSystemTray.Checked
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBoxShowInSystemTray_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowInSystemTray.CheckedChanged
        CheckBoxCloseToSystemTray.Enabled = CheckBoxShowInSystemTray.Checked
        CheckBoxClickingTrayIconStopsAlarm.Enabled = CheckBoxShowInSystemTray.Checked
    End Sub
End Class