<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogTimerSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogTimerSettings))
        Me.CheckBoxShowNoteAlertWhenTimerExpires = New System.Windows.Forms.CheckBox()
        Me.TextBoxNote = New System.Windows.Forms.TextBox()
        Me.CheckBoxAlarmSet = New System.Windows.Forms.CheckBox()
        Me.CheckBoxNote = New System.Windows.Forms.CheckBox()
        Me.ComboBoxAlarmPath = New System.Windows.Forms.ComboBox()
        Me.ButtonAlarmPlay = New System.Windows.Forms.Button()
        Me.ButtonOpenAlarm = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDownVolume = New System.Windows.Forms.NumericUpDown()
        Me.CheckBoxLoop = New System.Windows.Forms.CheckBox()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonSaveAs = New System.Windows.Forms.Button()
        Me.ButtonLoad = New System.Windows.Forms.Button()
        Me.LabelHours = New System.Windows.Forms.Label()
        Me.NumericUpDownHours = New System.Windows.Forms.NumericUpDown()
        Me.LabelMinutes = New System.Windows.Forms.Label()
        Me.NumericUpDownMinutes = New System.Windows.Forms.NumericUpDown()
        Me.LabelSeconds = New System.Windows.Forms.Label()
        Me.NumericUpDownSeconds = New System.Windows.Forms.NumericUpDown()
        Me.LabelRestarts = New System.Windows.Forms.Label()
        Me.NumericUpDownRestarts = New System.Windows.Forms.NumericUpDown()
        Me.CheckBoxCountUp = New System.Windows.Forms.CheckBox()
        Me.CheckBoxStartImmediately = New System.Windows.Forms.CheckBox()
        Me.GroupBoxDuration = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.NumericUpDownVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownMinutes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownSeconds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownRestarts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxDuration.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckBoxShowNoteAlertWhenTimerExpires
        '
        resources.ApplyResources(Me.CheckBoxShowNoteAlertWhenTimerExpires, "CheckBoxShowNoteAlertWhenTimerExpires")
        Me.TableLayoutPanel2.SetColumnSpan(Me.CheckBoxShowNoteAlertWhenTimerExpires, 4)
        Me.CheckBoxShowNoteAlertWhenTimerExpires.Name = "CheckBoxShowNoteAlertWhenTimerExpires"
        Me.CheckBoxShowNoteAlertWhenTimerExpires.UseVisualStyleBackColor = True
        '
        'TextBoxNote
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.TextBoxNote, 5)
        resources.ApplyResources(Me.TextBoxNote, "TextBoxNote")
        Me.TextBoxNote.Name = "TextBoxNote"
        '
        'CheckBoxAlarmSet
        '
        resources.ApplyResources(Me.CheckBoxAlarmSet, "CheckBoxAlarmSet")
        Me.CheckBoxAlarmSet.Name = "CheckBoxAlarmSet"
        Me.CheckBoxAlarmSet.UseVisualStyleBackColor = True
        '
        'CheckBoxNote
        '
        resources.ApplyResources(Me.CheckBoxNote, "CheckBoxNote")
        Me.CheckBoxNote.Name = "CheckBoxNote"
        Me.CheckBoxNote.UseVisualStyleBackColor = True
        '
        'ComboBoxAlarmPath
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.ComboBoxAlarmPath, 3)
        resources.ApplyResources(Me.ComboBoxAlarmPath, "ComboBoxAlarmPath")
        Me.ComboBoxAlarmPath.FormattingEnabled = True
        Me.ComboBoxAlarmPath.Name = "ComboBoxAlarmPath"
        '
        'ButtonAlarmPlay
        '
        resources.ApplyResources(Me.ButtonAlarmPlay, "ButtonAlarmPlay")
        Me.ButtonAlarmPlay.Name = "ButtonAlarmPlay"
        Me.ButtonAlarmPlay.UseVisualStyleBackColor = True
        '
        'ButtonOpenAlarm
        '
        resources.ApplyResources(Me.ButtonOpenAlarm, "ButtonOpenAlarm")
        Me.ButtonOpenAlarm.Name = "ButtonOpenAlarm"
        Me.ButtonOpenAlarm.UseVisualStyleBackColor = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'NumericUpDownVolume
        '
        resources.ApplyResources(Me.NumericUpDownVolume, "NumericUpDownVolume")
        Me.NumericUpDownVolume.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownVolume.Name = "NumericUpDownVolume"
        Me.NumericUpDownVolume.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'CheckBoxLoop
        '
        resources.ApplyResources(Me.CheckBoxLoop, "CheckBoxLoop")
        Me.CheckBoxLoop.Name = "CheckBoxLoop"
        Me.CheckBoxLoop.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        resources.ApplyResources(Me.ButtonCancel, "ButtonCancel")
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        resources.ApplyResources(Me.ButtonOK, "ButtonOK")
        Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonSaveAs
        '
        resources.ApplyResources(Me.ButtonSaveAs, "ButtonSaveAs")
        Me.ButtonSaveAs.Name = "ButtonSaveAs"
        Me.ButtonSaveAs.UseVisualStyleBackColor = True
        '
        'ButtonLoad
        '
        resources.ApplyResources(Me.ButtonLoad, "ButtonLoad")
        Me.ButtonLoad.Name = "ButtonLoad"
        Me.ButtonLoad.UseVisualStyleBackColor = True
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
        'CheckBoxStartImmediately
        '
        resources.ApplyResources(Me.CheckBoxStartImmediately, "CheckBoxStartImmediately")
        Me.TableLayoutPanel2.SetColumnSpan(Me.CheckBoxStartImmediately, 6)
        Me.CheckBoxStartImmediately.Name = "CheckBoxStartImmediately"
        Me.CheckBoxStartImmediately.UseVisualStyleBackColor = True
        '
        'GroupBoxDuration
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.GroupBoxDuration, 6)
        Me.GroupBoxDuration.Controls.Add(Me.TableLayoutPanel1)
        resources.ApplyResources(Me.GroupBoxDuration, "GroupBoxDuration")
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
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxStartImmediately, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxAlarmSet, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBoxDuration, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBoxAlarmPath, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxShowNoteAlertWhenTimerExpires, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.NumericUpDownVolume, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxLoop, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxNote, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxNote, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonOpenAlarm, 5, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonAlarmPlay, 4, 1)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'TableLayoutPanel3
        '
        resources.ApplyResources(Me.TableLayoutPanel3, "TableLayoutPanel3")
        Me.TableLayoutPanel2.SetColumnSpan(Me.TableLayoutPanel3, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonLoad, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonSaveAs, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonCancel, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonOK, 4, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        '
        'DialogTimerSettings
        '
        Me.AcceptButton = Me.ButtonOK
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogTimerSettings"
        Me.ShowInTaskbar = False
        CType(Me.NumericUpDownVolume, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownMinutes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownSeconds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownRestarts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxDuration.ResumeLayout(False)
        Me.GroupBoxDuration.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents CheckBoxAlarmSet As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBoxAlarmPath As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonAlarmPlay As System.Windows.Forms.Button
    Friend WithEvents ButtonOpenAlarm As System.Windows.Forms.Button
    Friend WithEvents CheckBoxLoop As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveAs As System.Windows.Forms.Button
    Friend WithEvents ButtonLoad As System.Windows.Forms.Button
    Friend WithEvents LabelHours As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownHours As System.Windows.Forms.NumericUpDown
    Friend WithEvents LabelMinutes As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownMinutes As System.Windows.Forms.NumericUpDown
    Friend WithEvents LabelSeconds As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownSeconds As System.Windows.Forms.NumericUpDown
    Friend WithEvents LabelRestarts As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownRestarts As System.Windows.Forms.NumericUpDown
    Friend WithEvents CheckBoxCountUp As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxStartImmediately As System.Windows.Forms.CheckBox
    Friend WithEvents NumericUpDownVolume As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxShowNoteAlertWhenTimerExpires As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxNote As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxNote As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBoxDuration As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel

End Class
