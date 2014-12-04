﻿Public Class SettingsDialog

    Private applicationBindingSource As BindingSource

    Public Property SettingsInfos As New List(Of MutableKeyValuePair(Of SettingsInfo, Boolean))

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        My.Settings.CloseToSystemTray = CheckBoxCloseToSystemTray.Checked
        My.Settings.ShowInSystemTray = CheckedGroupBoxShowInSystemTray.Checked
        My.Settings.ClickingTrayIconStopsAlarm = CheckBoxClickingTrayIconStopsAlarm.Checked
        My.Settings.UseToolbarStyling = CheckBoxEnableToolbarStyling.Checked
        My.Settings.Save()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        SetStrings()

        ' Add any initialization after the InitializeComponent() call.
        applicationBindingSource = New BindingSource

        applicationBindingSource.DataSource = My.Settings
    End Sub

    Private Sub FormConfiguration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckBoxCloseToSystemTray.Checked = My.Settings.CloseToSystemTray
        CheckedGroupBoxShowInSystemTray.Checked = My.Settings.ShowInSystemTray
        CheckBoxClickingTrayIconStopsAlarm.Checked = My.Settings.ClickingTrayIconStopsAlarm
        CheckBoxEnableToolbarStyling.Checked = My.Settings.UseToolbarStyling

        OlvColumnSetting.AspectGetter = Function(obj)
                                            Dim row As MutableKeyValuePair(Of SettingsInfo, Boolean) = obj
                                            Return row.Key.Description
                                        End Function

        FastObjectListView1.SetObjects(SettingsInfos)
        FastObjectListView1.HeaderStyle = ColumnHeaderStyle.None
        'For Each info As KeyValuePair(Of SettingsInfo, Boolean) In SettingsInfos
        '    CheckedListBox1.Items.Add(info.Key, info.Value)
        'Next
    End Sub

    Private Sub CheckBoxShowInSystemTray_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub SetStrings()
        Me.SuspendLayout()

        Me.CheckedGroupBoxShowInSystemTray.Text = My.Resources.Strings.ShowInSystemTray
        Me.CheckBoxCloseToSystemTray.Text = My.Resources.Strings.CloseToSystemTray
        Me.CheckBoxClickingTrayIconStopsAlarm.Text = My.Resources.Strings.ClickingTrayIconStopsAlarm
        Me.CheckBoxEnableToolbarStyling.Text = My.Resources.Strings.EnableToolbarStyling

        Me.ButtonOK.Text = My.Resources.Strings.Ok
        Me.ButtonCancel.Text = My.Resources.Strings.Cancel

        Me.ResumeLayout()

    End Sub
    Protected Overrides Sub OnLoad(e As EventArgs)
        Me.StartPosition = If(Owner Is Nothing, FormStartPosition.CenterScreen, FormStartPosition.CenterParent)
        Me.TopMost = True
        MyBase.OnLoad(e)
    End Sub

    Private Sub FastObjectListView1_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles FastObjectListView1.ItemCheck
        If (Me.SettingsInfos.Where(Function(i) i.Value = False).Count >= Me.SettingsInfos.Count - 1) Then
            e.NewValue = CheckState.Checked
        End If
    End Sub
End Class