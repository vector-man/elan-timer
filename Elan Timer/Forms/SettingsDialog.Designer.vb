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
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.CheckBoxEnableToolbarStyling = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckedGroupBoxShowInSystemTray = New ElanTimer.CheckedGroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBoxCloseToSystemTray = New System.Windows.Forms.CheckBox()
        Me.CheckBoxClickingTrayIconStopsAlarm = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.CheckedGroupBoxShowInSystemTray.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
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
        'CheckBoxEnableToolbarStyling
        '
        resources.ApplyResources(Me.CheckBoxEnableToolbarStyling, "CheckBoxEnableToolbarStyling")
        Me.TableLayoutPanel1.SetColumnSpan(Me.CheckBoxEnableToolbarStyling, 3)
        Me.CheckBoxEnableToolbarStyling.Name = "CheckBoxEnableToolbarStyling"
        Me.CheckBoxEnableToolbarStyling.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.CheckedGroupBoxShowInSystemTray, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonOK, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxEnableToolbarStyling, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCancel, 2, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'CheckedGroupBoxShowInSystemTray
        '
        resources.ApplyResources(Me.CheckedGroupBoxShowInSystemTray, "CheckedGroupBoxShowInSystemTray")
        Me.CheckedGroupBoxShowInSystemTray.Checked = False
        Me.TableLayoutPanel1.SetColumnSpan(Me.CheckedGroupBoxShowInSystemTray, 3)
        Me.CheckedGroupBoxShowInSystemTray.Controls.Add(Me.TableLayoutPanel2)
        Me.CheckedGroupBoxShowInSystemTray.Name = "CheckedGroupBoxShowInSystemTray"
        Me.CheckedGroupBoxShowInSystemTray.TabStop = False
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxCloseToSystemTray, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxClickingTrayIconStopsAlarm, 0, 1)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
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
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SettingsDialog"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.CheckedGroupBoxShowInSystemTray.ResumeLayout(False)
        Me.CheckedGroupBoxShowInSystemTray.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents CheckBoxCloseToSystemTray As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxClickingTrayIconStopsAlarm As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents CheckBoxEnableToolbarStyling As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckedGroupBoxShowInSystemTray As ElanTimer.CheckedGroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
End Class
