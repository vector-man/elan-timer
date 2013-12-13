<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogSettings))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.ComboBoxLanguage = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBoxCloseToSystemTray = New System.Windows.Forms.CheckBox()
        Me.CheckBoxShowInSystemTray = New System.Windows.Forms.CheckBox()
        Me.CheckBoxClickingTrayIconStopsAlarm = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
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
        'ComboBoxLanguage
        '
        resources.ApplyResources(Me.ComboBoxLanguage, "ComboBoxLanguage")
        Me.ComboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxLanguage.FormattingEnabled = True
        Me.ComboBoxLanguage.Name = "ComboBoxLanguage"
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxLanguage, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel4, 0, 1)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'TableLayoutPanel3
        '
        resources.ApplyResources(Me.TableLayoutPanel3, "TableLayoutPanel3")
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonOK, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonCancel, 4, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
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
        'TableLayoutPanel4
        '
        resources.ApplyResources(Me.TableLayoutPanel4, "TableLayoutPanel4")
        Me.TableLayoutPanel4.Controls.Add(Me.CheckBoxCloseToSystemTray, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.CheckBoxShowInSystemTray, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.CheckBoxClickingTrayIconStopsAlarm, 0, 2)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        '
        'CheckBoxCloseToSystemTray
        '
        resources.ApplyResources(Me.CheckBoxCloseToSystemTray, "CheckBoxCloseToSystemTray")
        Me.CheckBoxCloseToSystemTray.Name = "CheckBoxCloseToSystemTray"
        Me.CheckBoxCloseToSystemTray.UseVisualStyleBackColor = True
        '
        'CheckBoxShowInSystemTray
        '
        resources.ApplyResources(Me.CheckBoxShowInSystemTray, "CheckBoxShowInSystemTray")
        Me.CheckBoxShowInSystemTray.Name = "CheckBoxShowInSystemTray"
        Me.CheckBoxShowInSystemTray.UseVisualStyleBackColor = True
        '
        'CheckBoxClickingTrayIconStopsAlarm
        '
        resources.ApplyResources(Me.CheckBoxClickingTrayIconStopsAlarm, "CheckBoxClickingTrayIconStopsAlarm")
        Me.CheckBoxClickingTrayIconStopsAlarm.Name = "CheckBoxClickingTrayIconStopsAlarm"
        Me.CheckBoxClickingTrayIconStopsAlarm.UseVisualStyleBackColor = True
        '
        'DialogSettings
        '
        Me.AcceptButton = Me.ButtonOK
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogSettings"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents ComboBoxLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBoxCloseToSystemTray As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxShowInSystemTray As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxClickingTrayIconStopsAlarm As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
End Class
