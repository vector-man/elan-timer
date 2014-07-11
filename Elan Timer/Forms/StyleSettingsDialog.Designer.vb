<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StyleSettingsDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StyleSettingsDialog))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelForegroundColor = New System.Windows.Forms.Label()
        Me.ColorComboBoxForegrounColor = New ColorComboTestApp.ColorComboBox()
        Me.LabelBackgroundColor = New System.Windows.Forms.Label()
        Me.ColorComboBoxBackgroundColor = New ColorComboTestApp.ColorComboBox()
        Me.LabelFont = New System.Windows.Forms.Label()
        Me.FontPickerFont = New Com.Windows.Forms.FontPicker()
        Me.CheckBoxGrowToFit = New System.Windows.Forms.CheckBox()
        Me.LabelTransparency = New System.Windows.Forms.Label()
        Me.ComboBoxDisplayFormat = New System.Windows.Forms.ComboBox()
        Me.LabelRenderer = New System.Windows.Forms.Label()
        Me.PanelRenderPreview = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TrackBarTransparency = New System.Windows.Forms.TrackBar()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOptions = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ContextMenuOptions = New System.Windows.Forms.ContextMenu()
        Me.MenuItemLoadStyle = New System.Windows.Forms.MenuItem()
        Me.MenuItemSaveStyleAs = New System.Windows.Forms.MenuItem()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.TrackBarTransparency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'LabelForegroundColor
        '
        resources.ApplyResources(Me.LabelForegroundColor, "LabelForegroundColor")
        Me.LabelForegroundColor.Name = "LabelForegroundColor"
        '
        'ColorComboBoxForegrounColor
        '
        Me.ColorComboBoxForegrounColor.CustomColors = Nothing
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
        Me.ColorComboBoxBackgroundColor.CustomColors = Nothing
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
        'ComboBoxDisplayFormat
        '
        resources.ApplyResources(Me.ComboBoxDisplayFormat, "ComboBoxDisplayFormat")
        Me.ComboBoxDisplayFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDisplayFormat.FormattingEnabled = True
        Me.ComboBoxDisplayFormat.Name = "ComboBoxDisplayFormat"
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
        Me.TableLayoutPanel1.SetColumnSpan(Me.PanelRenderPreview, 2)
        resources.ApplyResources(Me.PanelRenderPreview, "PanelRenderPreview")
        Me.PanelRenderPreview.Name = "PanelRenderPreview"
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.TrackBarTransparency, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelRenderer, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PanelRenderPreview, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxDisplayFormat, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelFont, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.FontPickerFont, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxGrowToFit, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelTransparency, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelForegroundColor, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelBackgroundColor, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ColorComboBoxForegrounColor, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.ColorComboBoxBackgroundColor, 1, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'TrackBarTransparency
        '
        resources.ApplyResources(Me.TrackBarTransparency, "TrackBarTransparency")
        Me.TrackBarTransparency.LargeChange = 25
        Me.TrackBarTransparency.Maximum = 75
        Me.TrackBarTransparency.Name = "TrackBarTransparency"
        Me.TrackBarTransparency.TickFrequency = 10
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonCancel, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonOptions, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonOK, 3, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'ButtonCancel
        '
        resources.ApplyResources(Me.ButtonCancel, "ButtonCancel")
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOptions
        '
        resources.ApplyResources(Me.ButtonOptions, "ButtonOptions")
        Me.ButtonOptions.Name = "ButtonOptions"
        Me.ButtonOptions.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        resources.ApplyResources(Me.ButtonOK, "ButtonOK")
        Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ContextMenuOptions
        '
        Me.ContextMenuOptions.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemLoadStyle, Me.MenuItemSaveStyleAs})
        '
        'MenuItemLoadStyle
        '
        Me.MenuItemLoadStyle.Index = 0
        resources.ApplyResources(Me.MenuItemLoadStyle, "MenuItemLoadStyle")
        '
        'MenuItemSaveStyleAs
        '
        Me.MenuItemSaveStyleAs.Index = 1
        resources.ApplyResources(Me.MenuItemSaveStyleAs, "MenuItemSaveStyleAs")
        '
        'StyleSettingsDialog
        '
        Me.AcceptButton = Me.ButtonOK
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StyleSettingsDialog"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.TrackBarTransparency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabelForegroundColor As System.Windows.Forms.Label
    Friend WithEvents ColorComboBoxForegrounColor As ColorComboTestApp.ColorComboBox
    Friend WithEvents LabelBackgroundColor As System.Windows.Forms.Label
    Friend WithEvents ColorComboBoxBackgroundColor As ColorComboTestApp.ColorComboBox
    Friend WithEvents LabelFont As System.Windows.Forms.Label
    Friend WithEvents FontPickerFont As Com.Windows.Forms.FontPicker
    Friend WithEvents CheckBoxGrowToFit As System.Windows.Forms.CheckBox
    Friend WithEvents LabelTransparency As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDisplayFormat As System.Windows.Forms.ComboBox
    Friend WithEvents LabelRenderer As System.Windows.Forms.Label
    Friend WithEvents PanelRenderPreview As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonOptions As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents ContextMenuOptions As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemLoadStyle As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSaveStyleAs As System.Windows.Forms.MenuItem
    Friend WithEvents TrackBarTransparency As System.Windows.Forms.TrackBar

End Class
