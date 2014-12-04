<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsDialog))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBoxEnableToolbarStyling = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.FastObjectListView1 = New BrightIdeasSoftware.FastObjectListView()
        Me.OlvColumnEnabled = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnSetting = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckedGroupBoxShowInSystemTray = New ElanTimer.CheckedGroupBox()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBoxCloseToSystemTray = New System.Windows.Forms.CheckBox()
        Me.CheckBoxClickingTrayIconStopsAlarm = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.FastObjectListView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.CheckedGroupBoxShowInSystemTray.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
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
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonOK, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCancel, 2, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'CheckBoxEnableToolbarStyling
        '
        resources.ApplyResources(Me.CheckBoxEnableToolbarStyling, "CheckBoxEnableToolbarStyling")
        Me.CheckBoxEnableToolbarStyling.Name = "CheckBoxEnableToolbarStyling"
        Me.CheckBoxEnableToolbarStyling.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.FastObjectListView1)
        Me.GroupBox1.Controls.Add(Me.CheckBox4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'FastObjectListView1
        '
        Me.FastObjectListView1.AllColumns.Add(Me.OlvColumnEnabled)
        Me.FastObjectListView1.AllColumns.Add(Me.OlvColumnSetting)
        Me.FastObjectListView1.CheckBoxes = True
        Me.FastObjectListView1.CheckedAspectName = "Value"
        Me.FastObjectListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumnEnabled, Me.OlvColumnSetting})
        resources.ApplyResources(Me.FastObjectListView1, "FastObjectListView1")
        Me.FastObjectListView1.Name = "FastObjectListView1"
        Me.FastObjectListView1.ShowGroups = False
        Me.FastObjectListView1.ShowImagesOnSubItems = True
        Me.FastObjectListView1.UseCompatibleStateImageBehavior = False
        Me.FastObjectListView1.View = System.Windows.Forms.View.Details
        Me.FastObjectListView1.VirtualMode = True
        '
        'OlvColumnEnabled
        '
        Me.OlvColumnEnabled.AspectName = "Value"
        resources.ApplyResources(Me.OlvColumnEnabled, "OlvColumnEnabled")
        '
        'CheckBox4
        '
        resources.ApplyResources(Me.CheckBox4, "CheckBox4")
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'TableLayoutPanel4
        '
        resources.ApplyResources(Me.TableLayoutPanel4, "TableLayoutPanel4")
        Me.TableLayoutPanel4.Controls.Add(Me.CheckedGroupBoxShowInSystemTray, 0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        '
        'CheckedGroupBoxShowInSystemTray
        '
        resources.ApplyResources(Me.CheckedGroupBoxShowInSystemTray, "CheckedGroupBoxShowInSystemTray")
        Me.CheckedGroupBoxShowInSystemTray.Checked = False
        Me.TableLayoutPanel4.SetColumnSpan(Me.CheckedGroupBoxShowInSystemTray, 3)
        Me.CheckedGroupBoxShowInSystemTray.Controls.Add(Me.TableLayoutPanel9)
        Me.CheckedGroupBoxShowInSystemTray.Name = "CheckedGroupBoxShowInSystemTray"
        Me.CheckedGroupBoxShowInSystemTray.TabStop = False
        '
        'TableLayoutPanel9
        '
        resources.ApplyResources(Me.TableLayoutPanel9, "TableLayoutPanel9")
        Me.TableLayoutPanel9.Controls.Add(Me.CheckBoxCloseToSystemTray, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.CheckBoxClickingTrayIconStopsAlarm, 0, 1)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        '
        'CheckBoxCloseToSystemTray
        '
        resources.ApplyResources(Me.CheckBoxCloseToSystemTray, "CheckBoxCloseToSystemTray")
        Me.CheckBoxCloseToSystemTray.Name = "CheckBoxCloseToSystemTray"
        Me.CheckBoxCloseToSystemTray.UseVisualStyleBackColor = True
        '
        'CheckBoxClickingTrayIconStopsAlarm
        '
        resources.ApplyResources(Me.CheckBoxClickingTrayIconStopsAlarm, "CheckBoxClickingTrayIconStopsAlarm")
        Me.CheckBoxClickingTrayIconStopsAlarm.Name = "CheckBoxClickingTrayIconStopsAlarm"
        Me.CheckBoxClickingTrayIconStopsAlarm.UseVisualStyleBackColor = True
        '
        'SettingsDialog
        '
        Me.AcceptButton = Me.ButtonOK
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.Controls.Add(Me.CheckBoxEnableToolbarStyling)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel4)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SettingsDialog"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.FastObjectListView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.CheckedGroupBoxShowInSystemTray.ResumeLayout(False)
        Me.CheckedGroupBoxShowInSystemTray.PerformLayout()
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel9.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBoxEnableToolbarStyling As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckedGroupBoxShowInSystemTray As ElanTimer.CheckedGroupBox
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBoxCloseToSystemTray As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxClickingTrayIconStopsAlarm As System.Windows.Forms.CheckBox
    Friend WithEvents FastObjectListView1 As BrightIdeasSoftware.FastObjectListView
    Friend WithEvents OlvColumnSetting As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnEnabled As BrightIdeasSoftware.OLVColumn
End Class
