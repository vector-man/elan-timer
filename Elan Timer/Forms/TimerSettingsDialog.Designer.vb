<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimerSettingsDialog
    Inherits TransparentForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimerSettingsDialog))
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBoxNote = New System.Windows.Forms.TextBox()
        Me.CheckBoxCountUp = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSynchronize = New System.Windows.Forms.CheckBox()
        Me.LabelNote = New System.Windows.Forms.Label()
        Me.GroupBoxDuration = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelHours = New System.Windows.Forms.Label()
        Me.LabelMinutes = New System.Windows.Forms.Label()
        Me.LabelSeconds = New System.Windows.Forms.Label()
        Me.LabelRestarts = New System.Windows.Forms.Label()
        Me.NumericUpDownHours = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownMinutes = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownSeconds = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownRestarts = New System.Windows.Forms.NumericUpDown()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBoxDuration.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.NumericUpDownHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownMinutes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownSeconds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownRestarts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxNote, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxCountUp, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxSynchronize, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelNote, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBoxDuration, 0, 1)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'TextBoxNote
        '
        resources.ApplyResources(Me.TextBoxNote, "TextBoxNote")
        Me.TextBoxNote.Name = "TextBoxNote"
        '
        'CheckBoxCountUp
        '
        resources.ApplyResources(Me.CheckBoxCountUp, "CheckBoxCountUp")
        Me.TableLayoutPanel2.SetColumnSpan(Me.CheckBoxCountUp, 2)
        Me.CheckBoxCountUp.Name = "CheckBoxCountUp"
        Me.CheckBoxCountUp.UseVisualStyleBackColor = True
        '
        'CheckBoxSynchronize
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.CheckBoxSynchronize, 2)
        resources.ApplyResources(Me.CheckBoxSynchronize, "CheckBoxSynchronize")
        Me.CheckBoxSynchronize.Name = "CheckBoxSynchronize"
        Me.CheckBoxSynchronize.UseVisualStyleBackColor = True
        '
        'LabelNote
        '
        resources.ApplyResources(Me.LabelNote, "LabelNote")
        Me.LabelNote.Name = "LabelNote"
        '
        'GroupBoxDuration
        '
        resources.ApplyResources(Me.GroupBoxDuration, "GroupBoxDuration")
        Me.TableLayoutPanel2.SetColumnSpan(Me.GroupBoxDuration, 2)
        Me.GroupBoxDuration.Controls.Add(Me.TableLayoutPanel6)
        Me.GroupBoxDuration.Name = "GroupBoxDuration"
        Me.GroupBoxDuration.TabStop = False
        '
        'TableLayoutPanel6
        '
        resources.ApplyResources(Me.TableLayoutPanel6, "TableLayoutPanel6")
        Me.TableLayoutPanel6.Controls.Add(Me.LabelHours, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.LabelMinutes, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.LabelSeconds, 0, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.LabelRestarts, 0, 3)
        Me.TableLayoutPanel6.Controls.Add(Me.NumericUpDownHours, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.NumericUpDownMinutes, 1, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.NumericUpDownSeconds, 1, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.NumericUpDownRestarts, 1, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        '
        'LabelHours
        '
        resources.ApplyResources(Me.LabelHours, "LabelHours")
        Me.LabelHours.Name = "LabelHours"
        '
        'LabelMinutes
        '
        resources.ApplyResources(Me.LabelMinutes, "LabelMinutes")
        Me.LabelMinutes.Name = "LabelMinutes"
        '
        'LabelSeconds
        '
        resources.ApplyResources(Me.LabelSeconds, "LabelSeconds")
        Me.LabelSeconds.Name = "LabelSeconds"
        '
        'LabelRestarts
        '
        resources.ApplyResources(Me.LabelRestarts, "LabelRestarts")
        Me.LabelRestarts.Name = "LabelRestarts"
        '
        'NumericUpDownHours
        '
        resources.ApplyResources(Me.NumericUpDownHours, "NumericUpDownHours")
        Me.NumericUpDownHours.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.NumericUpDownHours.Name = "NumericUpDownHours"
        '
        'NumericUpDownMinutes
        '
        resources.ApplyResources(Me.NumericUpDownMinutes, "NumericUpDownMinutes")
        Me.NumericUpDownMinutes.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.NumericUpDownMinutes.Name = "NumericUpDownMinutes"
        '
        'NumericUpDownSeconds
        '
        resources.ApplyResources(Me.NumericUpDownSeconds, "NumericUpDownSeconds")
        Me.NumericUpDownSeconds.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.NumericUpDownSeconds.Name = "NumericUpDownSeconds"
        '
        'NumericUpDownRestarts
        '
        resources.ApplyResources(Me.NumericUpDownRestarts, "NumericUpDownRestarts")
        Me.NumericUpDownRestarts.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.NumericUpDownRestarts.Name = "NumericUpDownRestarts"
        '
        'TimerSettingsDialog
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TimerSettingsDialog"
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.GroupBoxDuration.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        CType(Me.NumericUpDownHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownMinutes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownSeconds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownRestarts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBoxNote As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxCountUp As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxSynchronize As System.Windows.Forms.CheckBox
    Friend WithEvents LabelNote As System.Windows.Forms.Label
    Friend WithEvents GroupBoxDuration As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelHours As System.Windows.Forms.Label
    Friend WithEvents LabelMinutes As System.Windows.Forms.Label
    Friend WithEvents LabelSeconds As System.Windows.Forms.Label
    Friend WithEvents LabelRestarts As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownHours As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownMinutes As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownSeconds As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownRestarts As System.Windows.Forms.NumericUpDown

End Class
