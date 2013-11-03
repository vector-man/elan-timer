<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConfiguration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConfiguration))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBoxLanguage = New System.Windows.Forms.ComboBox()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LabelUpdateDescription = New System.Windows.Forms.Label()
        Me.CheckBoxEnableAutomaticUpdateChecking = New System.Windows.Forms.CheckBox()
        Me.LabelNumberOfDaysBetweenUpdateChecks = New System.Windows.Forms.Label()
        Me.NumericUpDownNumberOfDaysBetweenUpdateChecks = New System.Windows.Forms.NumericUpDown()
        Me.ButtonCheckForUpdatesNow = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonApply = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel3.SuspendLayout()
        CType(Me.NumericUpDownNumberOfDaysBetweenUpdateChecks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.Name = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        resources.ApplyResources(Me.Button3, "Button3")
        Me.Button3.Name = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        resources.ApplyResources(Me.Button4, "Button4")
        Me.Button4.Name = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        resources.ApplyResources(Me.Button5, "Button5")
        Me.Button5.Name = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        resources.ApplyResources(Me.Button6, "Button6")
        Me.Button6.Name = "Button6"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'ComboBoxLanguage
        '
        resources.ApplyResources(Me.ComboBoxLanguage, "ComboBoxLanguage")
        Me.ComboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxLanguage.FormattingEnabled = True
        Me.ComboBoxLanguage.Name = "ComboBoxLanguage"
        '
        'FlowLayoutPanel3
        '
        resources.ApplyResources(Me.FlowLayoutPanel3, "FlowLayoutPanel3")
        Me.FlowLayoutPanel3.Controls.Add(Me.LabelUpdateDescription)
        Me.FlowLayoutPanel3.Controls.Add(Me.CheckBoxEnableAutomaticUpdateChecking)
        Me.FlowLayoutPanel3.Controls.Add(Me.LabelNumberOfDaysBetweenUpdateChecks)
        Me.FlowLayoutPanel3.Controls.Add(Me.NumericUpDownNumberOfDaysBetweenUpdateChecks)
        Me.FlowLayoutPanel3.Controls.Add(Me.ButtonCheckForUpdatesNow)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        '
        'LabelUpdateDescription
        '
        resources.ApplyResources(Me.LabelUpdateDescription, "LabelUpdateDescription")
        Me.FlowLayoutPanel3.SetFlowBreak(Me.LabelUpdateDescription, True)
        Me.LabelUpdateDescription.Name = "LabelUpdateDescription"
        '
        'CheckBoxEnableAutomaticUpdateChecking
        '
        resources.ApplyResources(Me.CheckBoxEnableAutomaticUpdateChecking, "CheckBoxEnableAutomaticUpdateChecking")
        Me.FlowLayoutPanel3.SetFlowBreak(Me.CheckBoxEnableAutomaticUpdateChecking, True)
        Me.CheckBoxEnableAutomaticUpdateChecking.Name = "CheckBoxEnableAutomaticUpdateChecking"
        Me.CheckBoxEnableAutomaticUpdateChecking.UseVisualStyleBackColor = True
        '
        'LabelNumberOfDaysBetweenUpdateChecks
        '
        resources.ApplyResources(Me.LabelNumberOfDaysBetweenUpdateChecks, "LabelNumberOfDaysBetweenUpdateChecks")
        Me.LabelNumberOfDaysBetweenUpdateChecks.Name = "LabelNumberOfDaysBetweenUpdateChecks"
        '
        'NumericUpDownNumberOfDaysBetweenUpdateChecks
        '
        resources.ApplyResources(Me.NumericUpDownNumberOfDaysBetweenUpdateChecks, "NumericUpDownNumberOfDaysBetweenUpdateChecks")
        Me.FlowLayoutPanel3.SetFlowBreak(Me.NumericUpDownNumberOfDaysBetweenUpdateChecks, True)
        Me.NumericUpDownNumberOfDaysBetweenUpdateChecks.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.NumericUpDownNumberOfDaysBetweenUpdateChecks.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownNumberOfDaysBetweenUpdateChecks.Name = "NumericUpDownNumberOfDaysBetweenUpdateChecks"
        Me.NumericUpDownNumberOfDaysBetweenUpdateChecks.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'ButtonCheckForUpdatesNow
        '
        resources.ApplyResources(Me.ButtonCheckForUpdatesNow, "ButtonCheckForUpdatesNow")
        Me.ButtonCheckForUpdatesNow.Name = "ButtonCheckForUpdatesNow"
        Me.ButtonCheckForUpdatesNow.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxLanguage, 1, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel3, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'TableLayoutPanel3
        '
        resources.ApplyResources(Me.TableLayoutPanel3, "TableLayoutPanel3")
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonApply, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonOK, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonCancel, 4, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        '
        'ButtonApply
        '
        resources.ApplyResources(Me.ButtonApply, "ButtonApply")
        Me.ButtonApply.Name = "ButtonApply"
        Me.ButtonApply.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        resources.ApplyResources(Me.ButtonOK, "ButtonOK")
        Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        resources.ApplyResources(Me.ButtonCancel, "ButtonCancel")
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'FormConfiguration
        '
        Me.AcceptButton = Me.ButtonOK
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormConfiguration"
        Me.ShowInTaskbar = False
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        CType(Me.NumericUpDownNumberOfDaysBetweenUpdateChecks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents LabelUpdateDescription As System.Windows.Forms.Label
    Friend WithEvents LabelNumberOfDaysBetweenUpdateChecks As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownNumberOfDaysBetweenUpdateChecks As System.Windows.Forms.NumericUpDown
    Friend WithEvents CheckBoxEnableAutomaticUpdateChecking As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonCheckForUpdatesNow As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonApply As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
End Class
