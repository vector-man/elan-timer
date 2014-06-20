Public Class SettingsDialog

    Private applicationBindingSource As BindingSource

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        My.Settings.Language = ComboBoxLanguage.SelectedValue
        My.Settings.CloseToSystemTray = CheckBoxCloseToSystemTray.Checked
        My.Settings.ShowInSystemTray = CheckBoxShowInSystemTray.Checked
        My.Settings.ClickingTrayIconStopsAlarm = CheckBoxClickingTrayIconStopsAlarm.Checked
        My.Settings.Save()
        Common.Languages.SetLanguage(My.Settings.Language)
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


        ComboBoxLanguage.DisplayMember = "Value"
        ComboBoxLanguage.ValueMember = "Key"
        ComboBoxLanguage.DataSource = Common.Languages.GetLanguages.ToList()
    End Sub

    Private Sub FormConfiguration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CheckBoxCloseToSystemTray.Checked = My.Settings.CloseToSystemTray
            CheckBoxShowInSystemTray.Checked = My.Settings.ShowInSystemTray
            CheckBoxClickingTrayIconStopsAlarm.Checked = My.Settings.ClickingTrayIconStopsAlarm
            ComboBoxLanguage.SelectedItem = Common.Languages.GetLanguages.ToList().Where(Function(item) item.Key = My.Settings.Language).First
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