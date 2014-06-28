Public Class SettingsDialog

    Private applicationBindingSource As BindingSource

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        My.Settings.Language = ComboBoxLanguage.SelectedValue
        My.Settings.CloseToSystemTray = CheckBoxCloseToSystemTray.Checked
        My.Settings.ShowInSystemTray = CheckBoxShowInSystemTray.Checked
        My.Settings.ClickingTrayIconStopsAlarm = CheckBoxClickingTrayIconStopsAlarm.Checked
        My.Settings.BlendToolbarColorWithBackground = CheckBoxBlendToolbarColorWithBackground.Checked
        My.Settings.Save()
        Utils.Languages.SetLanguage(My.Settings.Language)
        Utils.SetStrings()
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
        ComboBoxLanguage.DataSource = Utils.Languages.GetLanguages.ToList()
    End Sub

    Private Sub FormConfiguration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CheckBoxCloseToSystemTray.Checked = My.Settings.CloseToSystemTray
            CheckBoxShowInSystemTray.Checked = My.Settings.ShowInSystemTray
            CheckBoxClickingTrayIconStopsAlarm.Checked = My.Settings.ClickingTrayIconStopsAlarm
            ComboBoxLanguage.SelectedItem = Utils.Languages.GetLanguages.ToList().Where(Function(item) item.Key = My.Settings.Language).First
            CheckBoxCloseToSystemTray.Enabled = CheckBoxShowInSystemTray.Checked
            CheckBoxClickingTrayIconStopsAlarm.Enabled = CheckBoxShowInSystemTray.Checked
            CheckBoxBlendToolbarColorWithBackground.Checked = My.Settings.BlendToolbarColorWithBackground
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBoxShowInSystemTray_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowInSystemTray.CheckedChanged
        CheckBoxCloseToSystemTray.Enabled = CheckBoxShowInSystemTray.Checked
        CheckBoxClickingTrayIconStopsAlarm.Enabled = CheckBoxShowInSystemTray.Checked
    End Sub
End Class