<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StyleSettingsDialog
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
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StyleSettingsDialog))
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.TrackBarTransparency = New System.Windows.Forms.TrackBar()
        Me.LabelRenderer = New System.Windows.Forms.Label()
        Me.PanelRenderPreview = New System.Windows.Forms.Panel()
        Me.ComboBoxDisplayFormat = New System.Windows.Forms.ComboBox()
        Me.LabelFont = New System.Windows.Forms.Label()
        Me.FontPickerFont = New Com.Windows.Forms.FontPicker()
        Me.CheckBoxGrowToFit = New System.Windows.Forms.CheckBox()
        Me.LabelTransparency = New System.Windows.Forms.Label()
        Me.LabelForegroundColor = New System.Windows.Forms.Label()
        Me.LabelBackgroundColor = New System.Windows.Forms.Label()
        Me.ColorComboBoxForegrounColor = New ColorComboTestApp.ColorComboBox()
        Me.ColorComboBoxBackgroundColor = New ColorComboTestApp.ColorComboBox()
        Me.TableLayoutPanel8.SuspendLayout()
        CType(Me.TrackBarTransparency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel8
        '
        resources.ApplyResources(Me.TableLayoutPanel8, "TableLayoutPanel8")
        Me.TableLayoutPanel8.Controls.Add(Me.TrackBarTransparency, 1, 6)
        Me.TableLayoutPanel8.Controls.Add(Me.LabelRenderer, 0, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.PanelRenderPreview, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.ComboBoxDisplayFormat, 1, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.LabelFont, 0, 2)
        Me.TableLayoutPanel8.Controls.Add(Me.FontPickerFont, 1, 2)
        Me.TableLayoutPanel8.Controls.Add(Me.CheckBoxGrowToFit, 1, 3)
        Me.TableLayoutPanel8.Controls.Add(Me.LabelTransparency, 0, 6)
        Me.TableLayoutPanel8.Controls.Add(Me.LabelForegroundColor, 0, 5)
        Me.TableLayoutPanel8.Controls.Add(Me.LabelBackgroundColor, 0, 4)
        Me.TableLayoutPanel8.Controls.Add(Me.ColorComboBoxForegrounColor, 1, 5)
        Me.TableLayoutPanel8.Controls.Add(Me.ColorComboBoxBackgroundColor, 1, 4)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        '
        'TrackBarTransparency
        '
        resources.ApplyResources(Me.TrackBarTransparency, "TrackBarTransparency")
        Me.TrackBarTransparency.LargeChange = 25
        Me.TrackBarTransparency.Maximum = 75
        Me.TrackBarTransparency.Name = "TrackBarTransparency"
        Me.TrackBarTransparency.TickFrequency = 15
        '
        'LabelRenderer
        '
        resources.ApplyResources(Me.LabelRenderer, "LabelRenderer")
        Me.LabelRenderer.Name = "LabelRenderer"
        '
        'PanelRenderPreview
        '
        Me.PanelRenderPreview.BackColor = System.Drawing.Color.Black
        Me.PanelRenderPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel8.SetColumnSpan(Me.PanelRenderPreview, 2)
        resources.ApplyResources(Me.PanelRenderPreview, "PanelRenderPreview")
        Me.PanelRenderPreview.Name = "PanelRenderPreview"
        '
        'ComboBoxDisplayFormat
        '
        resources.ApplyResources(Me.ComboBoxDisplayFormat, "ComboBoxDisplayFormat")
        Me.ComboBoxDisplayFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDisplayFormat.FormattingEnabled = True
        Me.ComboBoxDisplayFormat.Name = "ComboBoxDisplayFormat"
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
        resources.ApplyResources(Me.FontPickerFont, "FontPickerFont")
        Me.FontPickerFont.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FontPickerFont.Name = "FontPickerFont"
        Me.FontPickerFont.ReadOnly = False
        Me.FontPickerFont.Value = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        '
        'CheckBoxGrowToFit
        '
        resources.ApplyResources(Me.CheckBoxGrowToFit, "CheckBoxGrowToFit")
        Me.CheckBoxGrowToFit.Name = "CheckBoxGrowToFit"
        Me.CheckBoxGrowToFit.UseVisualStyleBackColor = True
        '
        'LabelTransparency
        '
        resources.ApplyResources(Me.LabelTransparency, "LabelTransparency")
        Me.LabelTransparency.Name = "LabelTransparency"
        '
        'LabelForegroundColor
        '
        resources.ApplyResources(Me.LabelForegroundColor, "LabelForegroundColor")
        Me.LabelForegroundColor.Name = "LabelForegroundColor"
        '
        'LabelBackgroundColor
        '
        resources.ApplyResources(Me.LabelBackgroundColor, "LabelBackgroundColor")
        Me.LabelBackgroundColor.Name = "LabelBackgroundColor"
        '
        'ColorComboBoxForegrounColor
        '
        Me.ColorComboBoxForegrounColor.CustomColors = Nothing
        Me.ColorComboBoxForegrounColor.Extended = False
        resources.ApplyResources(Me.ColorComboBoxForegrounColor, "ColorComboBoxForegrounColor")
        Me.ColorComboBoxForegrounColor.Name = "ColorComboBoxForegrounColor"
        Me.ColorComboBoxForegrounColor.SelectedColor = System.Drawing.Color.Black
        '
        'ColorComboBoxBackgroundColor
        '
        Me.ColorComboBoxBackgroundColor.CustomColors = Nothing
        Me.ColorComboBoxBackgroundColor.Extended = False
        resources.ApplyResources(Me.ColorComboBoxBackgroundColor, "ColorComboBoxBackgroundColor")
        Me.ColorComboBoxBackgroundColor.Name = "ColorComboBoxBackgroundColor"
        Me.ColorComboBoxBackgroundColor.SelectedColor = System.Drawing.Color.Black
        '
        'StyleSettingsDialog
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StyleSettingsDialog"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        CType(Me.TrackBarTransparency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TrackBarTransparency As System.Windows.Forms.TrackBar
    Friend WithEvents LabelRenderer As System.Windows.Forms.Label
    Friend WithEvents PanelRenderPreview As System.Windows.Forms.Panel
    Friend WithEvents ComboBoxDisplayFormat As System.Windows.Forms.ComboBox
    Friend WithEvents LabelFont As System.Windows.Forms.Label
    Friend WithEvents FontPickerFont As Com.Windows.Forms.FontPicker
    Friend WithEvents CheckBoxGrowToFit As System.Windows.Forms.CheckBox
    Friend WithEvents LabelTransparency As System.Windows.Forms.Label
    Friend WithEvents LabelForegroundColor As System.Windows.Forms.Label
    Friend WithEvents LabelBackgroundColor As System.Windows.Forms.Label
    Friend WithEvents ColorComboBoxForegrounColor As ColorComboTestApp.ColorComboBox
    Friend WithEvents ColorComboBoxBackgroundColor As ColorComboTestApp.ColorComboBox

End Class
