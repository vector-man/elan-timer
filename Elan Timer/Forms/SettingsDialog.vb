Public Class SettingsDialog

    Private applicationBindingSource As BindingSource

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        My.Settings.CloseToSystemTray = CheckBoxCloseToSystemTray.Checked
        My.Settings.ShowInSystemTray = CheckedGroupBoxShowInSystemTray.Checked
        My.Settings.ClickingTrayIconStopsAlarm = CheckBoxClickingTrayIconStopsAlarm.Checked
        My.Settings.UseToolbarStyling = CheckBoxBlendToolbarColorWithBackground.Checked
        My.Settings.Save()
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
    End Sub

    Private Sub FormConfiguration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CheckBoxCloseToSystemTray.Checked = My.Settings.CloseToSystemTray
            CheckedGroupBoxShowInSystemTray.Checked = My.Settings.ShowInSystemTray
            CheckBoxClickingTrayIconStopsAlarm.Checked = My.Settings.ClickingTrayIconStopsAlarm
            CheckBoxBlendToolbarColorWithBackground.Checked = My.Settings.UseToolbarStyling
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBoxShowInSystemTray_CheckedChanged(sender As Object, e As EventArgs)

    End Sub
End Class