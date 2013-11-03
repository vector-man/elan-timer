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
        Me.CheckBoxAlarmSet = New System.Windows.Forms.CheckBox()
        Me.ComboBoxAlarmPath = New System.Windows.Forms.ComboBox()
        Me.CheckBoxLoop = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NumericUpDownVolume = New System.Windows.Forms.NumericUpDown()
        Me.ButtonAlarmPlay = New System.Windows.Forms.Button()
        Me.ButtonOpenAlarm = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonExport = New System.Windows.Forms.Button()
        Me.ButtonImport = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBoxTime = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBoxCountUp = New System.Windows.Forms.CheckBox()
        Me.LabelRestarts = New System.Windows.Forms.Label()
        Me.NumericUpDownRestarts = New System.Windows.Forms.NumericUpDown()
        Me.CheckBoxAutoStart = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBoxMemo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.NumericUpDownVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.NumericUpDownRestarts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckBoxAlarmSet
        '
        resources.ApplyResources(Me.CheckBoxAlarmSet, "CheckBoxAlarmSet")
        Me.CheckBoxAlarmSet.Name = "CheckBoxAlarmSet"
        Me.CheckBoxAlarmSet.UseVisualStyleBackColor = True
        '
        'ComboBoxAlarmPath
        '
        resources.ApplyResources(Me.ComboBoxAlarmPath, "ComboBoxAlarmPath")
        Me.ComboBoxAlarmPath.FormattingEnabled = True
        Me.ComboBoxAlarmPath.Name = "ComboBoxAlarmPath"
        '
        'CheckBoxLoop
        '
        resources.ApplyResources(Me.CheckBoxLoop, "CheckBoxLoop")
        Me.CheckBoxLoop.Name = "CheckBoxLoop"
        Me.CheckBoxLoop.UseVisualStyleBackColor = True
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'NumericUpDownVolume
        '
        resources.ApplyResources(Me.NumericUpDownVolume, "NumericUpDownVolume")
        Me.NumericUpDownVolume.Name = "NumericUpDownVolume"
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
        'TableLayoutPanel3
        '
        resources.ApplyResources(Me.TableLayoutPanel3, "TableLayoutPanel3")
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel5, 0, 2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
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
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxTime, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxCountUp, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelRestarts, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownRestarts, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxAutoStart, 2, 1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'TextBoxTime
        '
        Me.TextBoxTime.AcceptsReturn = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxTime, 3)
        resources.ApplyResources(Me.TextBoxTime, "TextBoxTime")
        Me.TextBoxTime.Name = "TextBoxTime"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'CheckBoxCountUp
        '
        resources.ApplyResources(Me.CheckBoxCountUp, "CheckBoxCountUp")
        Me.CheckBoxCountUp.Name = "CheckBoxCountUp"
        Me.CheckBoxCountUp.UseVisualStyleBackColor = True
        '
        'LabelRestarts
        '
        resources.ApplyResources(Me.LabelRestarts, "LabelRestarts")
        Me.LabelRestarts.Name = "LabelRestarts"
        '
        'NumericUpDownRestarts
        '
        resources.ApplyResources(Me.NumericUpDownRestarts, "NumericUpDownRestarts")
        Me.NumericUpDownRestarts.Name = "NumericUpDownRestarts"
        '
        'CheckBoxAutoStart
        '
        resources.ApplyResources(Me.CheckBoxAutoStart, "CheckBoxAutoStart")
        Me.CheckBoxAutoStart.Name = "CheckBoxAutoStart"
        Me.CheckBoxAutoStart.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        resources.ApplyResources(Me.TableLayoutPanel4, "TableLayoutPanel4")
        Me.TableLayoutPanel4.Controls.Add(Me.CheckBoxAlarmSet, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.ComboBoxAlarmPath, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.ButtonAlarmPlay, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.ButtonOpenAlarm, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.CheckBoxLoop, 1, 1)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        '
        'TableLayoutPanel5
        '
        resources.ApplyResources(Me.TableLayoutPanel5, "TableLayoutPanel5")
        Me.TableLayoutPanel5.Controls.Add(Me.TextBoxMemo, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        '
        'TextBoxMemo
        '
        resources.ApplyResources(Me.TextBoxMemo, "TextBoxMemo")
        Me.TextBoxMemo.Name = "TextBoxMemo"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'DialogTimerSettings
        '
        Me.AcceptButton = Me.ButtonOK
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.NumericUpDownVolume)
        Me.Controls.Add(Me.Label7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogTimerSettings"
        Me.ShowInTaskbar = False
        CType(Me.NumericUpDownVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.NumericUpDownRestarts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonOpenAlarm As System.Windows.Forms.Button
    Friend WithEvents CheckBoxAlarmSet As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBoxAlarmPath As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxLoop As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownVolume As System.Windows.Forms.NumericUpDown
    Friend WithEvents ButtonAlarmPlay As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBoxTime As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxCountUp As System.Windows.Forms.CheckBox
    Friend WithEvents LabelRestarts As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownRestarts As System.Windows.Forms.NumericUpDown
    Friend WithEvents CheckBoxAutoStart As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents ButtonExport As System.Windows.Forms.Button
    Friend WithEvents ButtonImport As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBoxMemo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
