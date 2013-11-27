<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogLookSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogLookSettings))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelRenderer = New System.Windows.Forms.Label()
        Me.ComboBoxDisplayFormat = New System.Windows.Forms.ComboBox()
        Me.LabelForegroundColor = New System.Windows.Forms.Label()
        Me.ColorComboBoxForegrounColor = New ColorComboTestApp.ColorComboBox()
        Me.LabelBackgroundColor = New System.Windows.Forms.Label()
        Me.ColorComboBoxBackgroundColor = New ColorComboTestApp.ColorComboBox()
        Me.LabelFont = New System.Windows.Forms.Label()
        Me.FontPickerFont = New Com.Windows.Forms.FontPicker()
        Me.CheckBoxSizeToFit = New System.Windows.Forms.CheckBox()
        Me.LabelTransparency = New System.Windows.Forms.Label()
        Me.NumericUpDownTransparencyLevel = New System.Windows.Forms.NumericUpDown()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonExport = New System.Windows.Forms.Button()
        Me.ButtonImport = New System.Windows.Forms.Button()
        Me.PanelRenderPreview = New System.Windows.Forms.Panel()
        CType(Me.NumericUpDownTransparencyLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'LabelRenderer
        '
        resources.ApplyResources(Me.LabelRenderer, "LabelRenderer")
        Me.LabelRenderer.Name = "LabelRenderer"
        '
        'ComboBoxDisplayFormat
        '
        resources.ApplyResources(Me.ComboBoxDisplayFormat, "ComboBoxDisplayFormat")
        Me.ComboBoxDisplayFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDisplayFormat.FormattingEnabled = True
        Me.ComboBoxDisplayFormat.Name = "ComboBoxDisplayFormat"
        '
        'LabelForegroundColor
        '
        resources.ApplyResources(Me.LabelForegroundColor, "LabelForegroundColor")
        Me.LabelForegroundColor.Name = "LabelForegroundColor"
        '
        'ColorComboBoxForegrounColor
        '
        Me.ColorComboBoxForegrounColor.Extended = False
        resources.ApplyResources(Me.ColorComboBoxForegrounColor, "ColorComboBoxForegrounColor")
        Me.ColorComboBoxForegrounColor.Name = "ColorComboBoxForegrounColor"
        Me.ColorComboBoxForegrounColor.SelectedColor = System.Drawing.Color.Black
        '
        'LabelBackgroundColor
        '
        resources.ApplyResources(Me.LabelBackgroundColor, "LabelBackgroundColor")
        Me.LabelBackgroundColor.Name = "LabelBackgroundColor"
        '
        'ColorComboBoxBackgroundColor
        '
        Me.ColorComboBoxBackgroundColor.Extended = False
        resources.ApplyResources(Me.ColorComboBoxBackgroundColor, "ColorComboBoxBackgroundColor")
        Me.ColorComboBoxBackgroundColor.Name = "ColorComboBoxBackgroundColor"
        Me.ColorComboBoxBackgroundColor.SelectedColor = System.Drawing.Color.Black
        '
        'LabelFont
        '
        resources.ApplyResources(Me.LabelFont, "LabelFont")
        Me.LabelFont.Name = "LabelFont"
        '
        'FontPickerFont
        '
        Me.FontPickerFont.BackColor = System.Drawing.SystemColors.Window
        Me.FontPickerFont.Context = Nothing
        Me.FontPickerFont.ForeColor = System.Drawing.SystemColors.WindowText
        resources.ApplyResources(Me.FontPickerFont, "FontPickerFont")
        Me.FontPickerFont.Name = "FontPickerFont"
        Me.FontPickerFont.ReadOnly = False
        Me.FontPickerFont.Value = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        '
        'CheckBoxSizeToFit
        '
        resources.ApplyResources(Me.CheckBoxSizeToFit, "CheckBoxSizeToFit")
        Me.CheckBoxSizeToFit.Name = "CheckBoxSizeToFit"
        Me.CheckBoxSizeToFit.UseVisualStyleBackColor = True
        '
        'LabelTransparency
        '
        resources.ApplyResources(Me.LabelTransparency, "LabelTransparency")
        Me.LabelTransparency.Name = "LabelTransparency"
        '
        'NumericUpDownTransparencyLevel
        '
        resources.ApplyResources(Me.NumericUpDownTransparencyLevel, "NumericUpDownTransparencyLevel")
        Me.NumericUpDownTransparencyLevel.Maximum = New Decimal(New Integer() {75, 0, 0, 0})
        Me.NumericUpDownTransparencyLevel.Name = "NumericUpDownTransparencyLevel"
        Me.NumericUpDownTransparencyLevel.Value = New Decimal(New Integer() {75, 0, 0, 0})
        '
        'TableLayoutPanel3
        '
        resources.ApplyResources(Me.TableLayoutPanel3, "TableLayoutPanel3")
        Me.TableLayoutPanel3.Controls.Add(Me.LabelRenderer, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ComboBoxDisplayFormat, 1, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        '
        'TableLayoutPanel4
        '
        resources.ApplyResources(Me.TableLayoutPanel4, "TableLayoutPanel4")
        Me.TableLayoutPanel4.Controls.Add(Me.LabelForegroundColor, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.ColorComboBoxForegrounColor, 1, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        '
        'TableLayoutPanel5
        '
        resources.ApplyResources(Me.TableLayoutPanel5, "TableLayoutPanel5")
        Me.TableLayoutPanel5.Controls.Add(Me.LabelBackgroundColor, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.ColorComboBoxBackgroundColor, 1, 0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        '
        'TableLayoutPanel6
        '
        resources.ApplyResources(Me.TableLayoutPanel6, "TableLayoutPanel6")
        Me.TableLayoutPanel6.Controls.Add(Me.LabelFont, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.FontPickerFont, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.CheckBoxSizeToFit, 1, 1)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        '
        'TableLayoutPanel7
        '
        resources.ApplyResources(Me.TableLayoutPanel7, "TableLayoutPanel7")
        Me.TableLayoutPanel7.Controls.Add(Me.LabelTransparency, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.NumericUpDownTransparencyLevel, 1, 0)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        '
        'TableLayoutPanel8
        '
        resources.ApplyResources(Me.TableLayoutPanel8, "TableLayoutPanel8")
        Me.TableLayoutPanel8.Controls.Add(Me.TableLayoutPanel2, 0, 6)
        Me.TableLayoutPanel8.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.TableLayoutPanel7, 0, 5)
        Me.TableLayoutPanel8.Controls.Add(Me.TableLayoutPanel6, 0, 4)
        Me.TableLayoutPanel8.Controls.Add(Me.TableLayoutPanel4, 0, 2)
        Me.TableLayoutPanel8.Controls.Add(Me.TableLayoutPanel5, 0, 3)
        Me.TableLayoutPanel8.Controls.Add(Me.PanelRenderPreview, 0, 0)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonCancel, 6, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonOK, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonExport, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonImport, 0, 1)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
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
        'ButtonExport
        '
        resources.ApplyResources(Me.ButtonExport, "ButtonExport")
        Me.ButtonExport.Name = "ButtonExport"
        Me.ButtonExport.UseVisualStyleBackColor = True
        '
        'ButtonImport
        '
        resources.ApplyResources(Me.ButtonImport, "ButtonImport")
        Me.ButtonImport.Name = "ButtonImport"
        Me.ButtonImport.UseVisualStyleBackColor = True
        '
        'PanelRenderPreview
        '
        Me.PanelRenderPreview.BackColor = System.Drawing.Color.Black
        Me.PanelRenderPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.PanelRenderPreview, "PanelRenderPreview")
        Me.PanelRenderPreview.Name = "PanelRenderPreview"
        '
        'DialogLookSettings
        '
        Me.AcceptButton = Me.ButtonOK
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.Controls.Add(Me.TableLayoutPanel8)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogLookSettings"
        Me.ShowInTaskbar = False
        CType(Me.NumericUpDownTransparencyLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabelRenderer As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDisplayFormat As System.Windows.Forms.ComboBox
    Friend WithEvents LabelForegroundColor As System.Windows.Forms.Label
    Friend WithEvents ColorComboBoxForegrounColor As ColorComboTestApp.ColorComboBox
    Friend WithEvents LabelBackgroundColor As System.Windows.Forms.Label
    Friend WithEvents ColorComboBoxBackgroundColor As ColorComboTestApp.ColorComboBox
    Friend WithEvents LabelFont As System.Windows.Forms.Label
    Friend WithEvents FontPickerFont As Com.Windows.Forms.FontPicker
    Friend WithEvents CheckBoxSizeToFit As System.Windows.Forms.CheckBox
    Friend WithEvents LabelTransparency As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownTransparencyLevel As System.Windows.Forms.NumericUpDown
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PanelRenderPreview As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents ButtonExport As System.Windows.Forms.Button
    Friend WithEvents ButtonImport As System.Windows.Forms.Button

End Class
