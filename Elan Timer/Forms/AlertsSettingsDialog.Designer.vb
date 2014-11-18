<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlertsSettingsDialog
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
        Me.CheckBoxDisplayNoteEnabled = New System.Windows.Forms.CheckBox()
        Me.CheckBoxAlertEnabled = New System.Windows.Forms.CheckBox()
        Me.CheckedGroupBox1 = New ElanTimer.CheckedGroupBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBoxAlarmPerRestart = New System.Windows.Forms.CheckBox()
        Me.CheckBoxLoop = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonAlarmPlay = New System.Windows.Forms.Button()
        Me.ComboBoxAlarmPath = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TrackBarVolume = New System.Windows.Forms.TrackBar()
        Me.CheckedGroupBox1.SuspendLayout
        Me.TableLayoutPanel5.SuspendLayout
        CType(Me.TrackBarVolume,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'CheckBoxDisplayNoteEnabled
        '
        Me.CheckBoxDisplayNoteEnabled.AutoSize = true
        Me.CheckBoxDisplayNoteEnabled.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CheckBoxDisplayNoteEnabled.Location = New System.Drawing.Point(7, 151)
        Me.CheckBoxDisplayNoteEnabled.Margin = New System.Windows.Forms.Padding(3, 2, 0, 0)
        Me.CheckBoxDisplayNoteEnabled.Name = "CheckBoxDisplayNoteEnabled"
        Me.CheckBoxDisplayNoteEnabled.Size = New System.Drawing.Size(237, 17)
        Me.CheckBoxDisplayNoteEnabled.TabIndex = 65
        Me.CheckBoxDisplayNoteEnabled.Text = "Show note in display area when timer expires"
        Me.CheckBoxDisplayNoteEnabled.UseVisualStyleBackColor = true
        '
        'CheckBoxAlertEnabled
        '
        Me.CheckBoxAlertEnabled.AutoSize = true
        Me.CheckBoxAlertEnabled.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CheckBoxAlertEnabled.Location = New System.Drawing.Point(7, 132)
        Me.CheckBoxAlertEnabled.Margin = New System.Windows.Forms.Padding(3, 2, 0, 0)
        Me.CheckBoxAlertEnabled.Name = "CheckBoxAlertEnabled"
        Me.CheckBoxAlertEnabled.Size = New System.Drawing.Size(210, 17)
        Me.CheckBoxAlertEnabled.TabIndex = 64
        Me.CheckBoxAlertEnabled.Text = "Show note alert box when timer expires"
        Me.CheckBoxAlertEnabled.UseVisualStyleBackColor = true
        '
        'CheckedGroupBox1
        '
        Me.CheckedGroupBox1.AutoSize = true
        Me.CheckedGroupBox1.Checked = false
        Me.CheckedGroupBox1.Controls.Add(Me.TableLayoutPanel5)
        Me.CheckedGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CheckedGroupBox1.Location = New System.Drawing.Point(7, 7)
        Me.CheckedGroupBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckedGroupBox1.Name = "CheckedGroupBox1"
        Me.CheckedGroupBox1.Padding = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.CheckedGroupBox1.Size = New System.Drawing.Size(328, 116)
        Me.CheckedGroupBox1.TabIndex = 63
        Me.CheckedGroupBox1.TabStop = false
        Me.CheckedGroupBox1.Text = "Alarm"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.AutoSize = true
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.Controls.Add(Me.CheckBoxAlarmPerRestart, 0, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.CheckBoxLoop, 0, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.Label1, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.ButtonAlarmPlay, 2, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.ComboBoxAlarmPath, 1, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.TrackBarVolume, 1, 2)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(6, 20)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 5
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(316, 89)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'CheckBoxAlarmPerRestart
        '
        Me.CheckBoxAlarmPerRestart.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBoxAlarmPerRestart.AutoSize = true
        Me.TableLayoutPanel5.SetColumnSpan(Me.CheckBoxAlarmPerRestart, 2)
        Me.CheckBoxAlarmPerRestart.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CheckBoxAlarmPerRestart.Location = New System.Drawing.Point(3, 72)
        Me.CheckBoxAlarmPerRestart.Margin = New System.Windows.Forms.Padding(3, 2, 0, 0)
        Me.CheckBoxAlarmPerRestart.Name = "CheckBoxAlarmPerRestart"
        Me.CheckBoxAlarmPerRestart.Size = New System.Drawing.Size(155, 17)
        Me.CheckBoxAlarmPerRestart.TabIndex = 101
        Me.CheckBoxAlarmPerRestart.Text = "Play sound once per restart"
        Me.CheckBoxAlarmPerRestart.UseVisualStyleBackColor = true
        '
        'CheckBoxLoop
        '
        Me.CheckBoxLoop.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBoxLoop.AutoSize = true
        Me.TableLayoutPanel5.SetColumnSpan(Me.CheckBoxLoop, 2)
        Me.CheckBoxLoop.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CheckBoxLoop.Location = New System.Drawing.Point(3, 53)
        Me.CheckBoxLoop.Margin = New System.Windows.Forms.Padding(3, 2, 0, 0)
        Me.CheckBoxLoop.Name = "CheckBoxLoop"
        Me.CheckBoxLoop.Size = New System.Drawing.Size(82, 17)
        Me.CheckBoxLoop.TabIndex = 3
        Me.CheckBoxLoop.Text = "Loop sound"
        Me.CheckBoxLoop.UseVisualStyleBackColor = true
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(0, 29)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 3, 3, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Volume:"
        '
        'ButtonAlarmPlay
        '
        Me.ButtonAlarmPlay.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonAlarmPlay.AutoSize = true
        Me.ButtonAlarmPlay.Image = Global.ElanTimer.My.Resources.Resources.play_green
        Me.ButtonAlarmPlay.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonAlarmPlay.Location = New System.Drawing.Point(294, 2)
        Me.ButtonAlarmPlay.Margin = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.ButtonAlarmPlay.Name = "ButtonAlarmPlay"
        Me.ButtonAlarmPlay.Size = New System.Drawing.Size(22, 22)
        Me.ButtonAlarmPlay.TabIndex = 1
        Me.ButtonAlarmPlay.UseVisualStyleBackColor = true
        '
        'ComboBoxAlarmPath
        '
        Me.ComboBoxAlarmPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxAlarmPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAlarmPath.FormattingEnabled = true
        Me.ComboBoxAlarmPath.Location = New System.Drawing.Point(50, 3)
        Me.ComboBoxAlarmPath.Margin = New System.Windows.Forms.Padding(2, 3, 2, 2)
        Me.ComboBoxAlarmPath.Name = "ComboBoxAlarmPath"
        Me.ComboBoxAlarmPath.Size = New System.Drawing.Size(240, 21)
        Me.ComboBoxAlarmPath.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(0, 3)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 3, 2, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Sound:"
        '
        'TrackBarVolume
        '
        Me.TrackBarVolume.AutoSize = false
        Me.TrackBarVolume.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TrackBarVolume.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TrackBarVolume.LargeChange = 25
        Me.TrackBarVolume.Location = New System.Drawing.Point(51, 28)
        Me.TrackBarVolume.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TrackBarVolume.Maximum = 100
        Me.TrackBarVolume.Name = "TrackBarVolume"
        Me.TrackBarVolume.Size = New System.Drawing.Size(238, 21)
        Me.TrackBarVolume.TabIndex = 100
        Me.TrackBarVolume.TickFrequency = 10
        '
        'AlertsSettingsDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 262)
        Me.Controls.Add(Me.CheckedGroupBox1)
        Me.Controls.Add(Me.CheckBoxDisplayNoteEnabled)
        Me.Controls.Add(Me.CheckBoxAlertEnabled)
        Me.Name = "AlertsSettingsDialog"
        Me.Padding = New System.Windows.Forms.Padding(7)
        Me.Text = "AlertsSettingsDialog"
        Me.CheckedGroupBox1.ResumeLayout(false)
        Me.CheckedGroupBox1.PerformLayout
        Me.TableLayoutPanel5.ResumeLayout(false)
        Me.TableLayoutPanel5.PerformLayout
        CType(Me.TrackBarVolume,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents CheckBoxDisplayNoteEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxAlertEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents CheckedGroupBox1 As ElanTimer.CheckedGroupBox
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBoxAlarmPerRestart As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxLoop As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonAlarmPlay As System.Windows.Forms.Button
    Friend WithEvents ComboBoxAlarmPath As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TrackBarVolume As System.Windows.Forms.TrackBar
End Class
