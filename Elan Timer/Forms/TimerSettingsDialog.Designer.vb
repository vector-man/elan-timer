<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimerSettingsDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimerSettingsDialog))
        Me.CheckBoxShowNoteAlertWhenTimerExpires = New System.Windows.Forms.CheckBox()
        Me.LabelHours = New System.Windows.Forms.Label()
        Me.NumericUpDownHours = New System.Windows.Forms.NumericUpDown()
        Me.LabelMinutes = New System.Windows.Forms.Label()
        Me.NumericUpDownMinutes = New System.Windows.Forms.NumericUpDown()
        Me.LabelSeconds = New System.Windows.Forms.Label()
        Me.NumericUpDownSeconds = New System.Windows.Forms.NumericUpDown()
        Me.LabelRestarts = New System.Windows.Forms.Label()
        Me.NumericUpDownRestarts = New System.Windows.Forms.NumericUpDown()
        Me.CheckBoxCountUp = New System.Windows.Forms.CheckBox()
        Me.GroupBoxDuration = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.ButtonSet = New System.Windows.Forms.Button()
        Me.CheckBoxNote = New System.Windows.Forms.CheckBox()
        Me.TextBoxNote = New System.Windows.Forms.TextBox()
        Me.CheckBoxAlarmSet = New System.Windows.Forms.CheckBox()
        Me.ContextMenuOptions = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItemSavePresetAs = New System.Windows.Forms.MenuItem()
        Me.CheckedGroupBox1 = New ElanTimer.CheckedGroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBoxLoop = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxAlarmPath = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TrackBarVolume = New System.Windows.Forms.TrackBar()
        Me.ButtonOptions = New System.Windows.Forms.Button()
        Me.ButtonAlarmPlay = New System.Windows.Forms.Button()
        CType(Me.NumericUpDownHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownMinutes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownSeconds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownRestarts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxDuration.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.CheckedGroupBox1.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.TrackBarVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckBoxShowNoteAlertWhenTimerExpires
        '
        resources.ApplyResources(Me.CheckBoxShowNoteAlertWhenTimerExpires, "CheckBoxShowNoteAlertWhenTimerExpires")
        Me.TableLayoutPanel2.SetColumnSpan(Me.CheckBoxShowNoteAlertWhenTimerExpires, 4)
        Me.CheckBoxShowNoteAlertWhenTimerExpires.Name = "CheckBoxShowNoteAlertWhenTimerExpires"
        Me.CheckBoxShowNoteAlertWhenTimerExpires.UseVisualStyleBackColor = True
        '
        'LabelHours
        '
        resources.ApplyResources(Me.LabelHours, "LabelHours")
        Me.LabelHours.Name = "LabelHours"
        '
        'NumericUpDownHours
        '
        resources.ApplyResources(Me.NumericUpDownHours, "NumericUpDownHours")
        Me.NumericUpDownHours.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.NumericUpDownHours.Name = "NumericUpDownHours"
        '
        'LabelMinutes
        '
        resources.ApplyResources(Me.LabelMinutes, "LabelMinutes")
        Me.LabelMinutes.Name = "LabelMinutes"
        '
        'NumericUpDownMinutes
        '
        resources.ApplyResources(Me.NumericUpDownMinutes, "NumericUpDownMinutes")
        Me.NumericUpDownMinutes.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.NumericUpDownMinutes.Name = "NumericUpDownMinutes"
        '
        'LabelSeconds
        '
        resources.ApplyResources(Me.LabelSeconds, "LabelSeconds")
        Me.LabelSeconds.Name = "LabelSeconds"
        '
        'NumericUpDownSeconds
        '
        resources.ApplyResources(Me.NumericUpDownSeconds, "NumericUpDownSeconds")
        Me.NumericUpDownSeconds.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.NumericUpDownSeconds.Name = "NumericUpDownSeconds"
        '
        'LabelRestarts
        '
        resources.ApplyResources(Me.LabelRestarts, "LabelRestarts")
        Me.LabelRestarts.Name = "LabelRestarts"
        '
        'NumericUpDownRestarts
        '
        resources.ApplyResources(Me.NumericUpDownRestarts, "NumericUpDownRestarts")
        Me.NumericUpDownRestarts.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.NumericUpDownRestarts.Name = "NumericUpDownRestarts"
        '
        'CheckBoxCountUp
        '
        resources.ApplyResources(Me.CheckBoxCountUp, "CheckBoxCountUp")
        Me.TableLayoutPanel1.SetColumnSpan(Me.CheckBoxCountUp, 2)
        Me.CheckBoxCountUp.Name = "CheckBoxCountUp"
        Me.CheckBoxCountUp.UseVisualStyleBackColor = True
        '
        'GroupBoxDuration
        '
        resources.ApplyResources(Me.GroupBoxDuration, "GroupBoxDuration")
        Me.TableLayoutPanel2.SetColumnSpan(Me.GroupBoxDuration, 6)
        Me.GroupBoxDuration.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBoxDuration.Name = "GroupBoxDuration"
        Me.GroupBoxDuration.TabStop = False
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.LabelHours, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelMinutes, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelSeconds, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelRestarts, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownHours, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownMinutes, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownSeconds, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownRestarts, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxCountUp, 0, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBoxDuration, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxNote, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxNote, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckedGroupBox1, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxShowNoteAlertWhenTimerExpires, 0, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'TableLayoutPanel3
        '
        resources.ApplyResources(Me.TableLayoutPanel3, "TableLayoutPanel3")
        Me.TableLayoutPanel2.SetColumnSpan(Me.TableLayoutPanel3, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonOptions, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonCancel, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonStart, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonSet, 4, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        '
        'ButtonCancel
        '
        resources.ApplyResources(Me.ButtonCancel, "ButtonCancel")
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonStart
        '
        resources.ApplyResources(Me.ButtonStart, "ButtonStart")
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'ButtonSet
        '
        resources.ApplyResources(Me.ButtonSet, "ButtonSet")
        Me.ButtonSet.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonSet.Name = "ButtonSet"
        Me.ButtonSet.UseVisualStyleBackColor = True
        '
        'CheckBoxNote
        '
        resources.ApplyResources(Me.CheckBoxNote, "CheckBoxNote")
        Me.CheckBoxNote.Name = "CheckBoxNote"
        Me.CheckBoxNote.UseVisualStyleBackColor = True
        '
        'TextBoxNote
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.TextBoxNote, 4)
        resources.ApplyResources(Me.TextBoxNote, "TextBoxNote")
        Me.TextBoxNote.Name = "TextBoxNote"
        '
        'CheckBoxAlarmSet
        '
        resources.ApplyResources(Me.CheckBoxAlarmSet, "CheckBoxAlarmSet")
        Me.CheckBoxAlarmSet.Name = "CheckBoxAlarmSet"
        Me.CheckBoxAlarmSet.UseVisualStyleBackColor = True
        '
        'ContextMenuOptions
        '
        Me.ContextMenuOptions.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItemSavePresetAs})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        resources.ApplyResources(Me.MenuItem1, "MenuItem1")
        '
        'MenuItemSavePresetAs
        '
        Me.MenuItemSavePresetAs.Index = 1
        resources.ApplyResources(Me.MenuItemSavePresetAs, "MenuItemSavePresetAs")
        '
        'CheckedGroupBox1
        '
        resources.ApplyResources(Me.CheckedGroupBox1, "CheckedGroupBox1")
        Me.CheckedGroupBox1.Checked = False
        Me.TableLayoutPanel2.SetColumnSpan(Me.CheckedGroupBox1, 6)
        Me.CheckedGroupBox1.Controls.Add(Me.TableLayoutPanel4)
        Me.CheckedGroupBox1.Name = "CheckedGroupBox1"
        Me.CheckedGroupBox1.TabStop = False
        '
        'TableLayoutPanel4
        '
        resources.ApplyResources(Me.TableLayoutPanel4, "TableLayoutPanel4")
        Me.TableLayoutPanel4.Controls.Add(Me.CheckBoxLoop, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.ButtonAlarmPlay, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.ComboBoxAlarmPath, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.TrackBarVolume, 1, 2)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        '
        'CheckBoxLoop
        '
        resources.ApplyResources(Me.CheckBoxLoop, "CheckBoxLoop")
        Me.TableLayoutPanel4.SetColumnSpan(Me.CheckBoxLoop, 2)
        Me.CheckBoxLoop.Name = "CheckBoxLoop"
        Me.CheckBoxLoop.UseVisualStyleBackColor = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'ComboBoxAlarmPath
        '
        resources.ApplyResources(Me.ComboBoxAlarmPath, "ComboBoxAlarmPath")
        Me.ComboBoxAlarmPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAlarmPath.FormattingEnabled = True
        Me.ComboBoxAlarmPath.Name = "ComboBoxAlarmPath"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'TrackBarVolume
        '
        resources.ApplyResources(Me.TrackBarVolume, "TrackBarVolume")
        Me.TableLayoutPanel4.SetColumnSpan(Me.TrackBarVolume, 2)
        Me.TrackBarVolume.LargeChange = 25
        Me.TrackBarVolume.Maximum = 100
        Me.TrackBarVolume.Name = "TrackBarVolume"
        Me.TrackBarVolume.TickFrequency = 10
        '
        'ButtonOptions
        '
        resources.ApplyResources(Me.ButtonOptions, "ButtonOptions")
        Me.ButtonOptions.Name = "ButtonOptions"
        Me.ButtonOptions.UseVisualStyleBackColor = True
        '
        'ButtonAlarmPlay
        '
        resources.ApplyResources(Me.ButtonAlarmPlay, "ButtonAlarmPlay")
        Me.ButtonAlarmPlay.Image = Global.ElanTimer.My.Resources.Resources.play_green
        Me.ButtonAlarmPlay.Name = "ButtonAlarmPlay"
        Me.ButtonAlarmPlay.UseVisualStyleBackColor = True
        '
        'TimerSettingsDialog
        '
        Me.AcceptButton = Me.ButtonSet
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.Controls.Add(Me.CheckBoxAlarmSet)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "TimerSettingsDialog"
        Me.ShowInTaskbar = false
        Me.TopMost = true
        CType(Me.NumericUpDownHours,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.NumericUpDownMinutes,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.NumericUpDownSeconds,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.NumericUpDownRestarts,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBoxDuration.ResumeLayout(false)
        Me.GroupBoxDuration.PerformLayout
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.TableLayoutPanel2.ResumeLayout(false)
        Me.TableLayoutPanel2.PerformLayout
        Me.TableLayoutPanel3.ResumeLayout(false)
        Me.TableLayoutPanel3.PerformLayout
        Me.CheckedGroupBox1.ResumeLayout(false)
        Me.CheckedGroupBox1.PerformLayout
        Me.TableLayoutPanel4.ResumeLayout(false)
        Me.TableLayoutPanel4.PerformLayout
        CType(Me.TrackBarVolume,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents ComboBoxAlarmPath As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonAlarmPlay As System.Windows.Forms.Button
    Friend WithEvents CheckBoxLoop As System.Windows.Forms.CheckBox
    Friend WithEvents LabelHours As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownHours As System.Windows.Forms.NumericUpDown
    Friend WithEvents LabelMinutes As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownMinutes As System.Windows.Forms.NumericUpDown
    Friend WithEvents LabelSeconds As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownSeconds As System.Windows.Forms.NumericUpDown
    Friend WithEvents LabelRestarts As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownRestarts As System.Windows.Forms.NumericUpDown
    Friend WithEvents CheckBoxCountUp As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxShowNoteAlertWhenTimerExpires As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBoxDuration As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBoxNote As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxNote As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckedGroupBox1 As ElanTimer.CheckedGroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonSet As System.Windows.Forms.Button
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents ButtonOptions As System.Windows.Forms.Button
    Friend WithEvents CheckBoxAlarmSet As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuOptions As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSavePresetAs As System.Windows.Forms.MenuItem
    Friend WithEvents TrackBarVolume As System.Windows.Forms.TrackBar

End Class
