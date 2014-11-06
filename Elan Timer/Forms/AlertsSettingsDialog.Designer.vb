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
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxShowNoteAlertWhenTimerExpires = New System.Windows.Forms.CheckBox()
        Me.CheckedGroupBox1 = New ElanTimer.CheckedGroupBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxLoop = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonAlarmPlay = New System.Windows.Forms.Button()
        Me.ComboBoxAlarmPath = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TrackBarVolume = New System.Windows.Forms.TrackBar()
        Me.CheckedGroupBox1.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.TrackBarVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CheckBox3.Location = New System.Drawing.Point(7, 151)
        Me.CheckBox3.Margin = New System.Windows.Forms.Padding(3, 2, 0, 0)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(237, 17)
        Me.CheckBox3.TabIndex = 65
        Me.CheckBox3.Text = "Show note in display area when timer expires"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBoxShowNoteAlertWhenTimerExpires
        '
        Me.CheckBoxShowNoteAlertWhenTimerExpires.AutoSize = True
        Me.CheckBoxShowNoteAlertWhenTimerExpires.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CheckBoxShowNoteAlertWhenTimerExpires.Location = New System.Drawing.Point(7, 132)
        Me.CheckBoxShowNoteAlertWhenTimerExpires.Margin = New System.Windows.Forms.Padding(3, 2, 0, 0)
        Me.CheckBoxShowNoteAlertWhenTimerExpires.Name = "CheckBoxShowNoteAlertWhenTimerExpires"
        Me.CheckBoxShowNoteAlertWhenTimerExpires.Size = New System.Drawing.Size(210, 17)
        Me.CheckBoxShowNoteAlertWhenTimerExpires.TabIndex = 64
        Me.CheckBoxShowNoteAlertWhenTimerExpires.Text = "Show note alert box when timer expires"
        Me.CheckBoxShowNoteAlertWhenTimerExpires.UseVisualStyleBackColor = True
        '
        'CheckedGroupBox1
        '
        Me.CheckedGroupBox1.AutoSize = True
        Me.CheckedGroupBox1.Checked = False
        Me.CheckedGroupBox1.Controls.Add(Me.TableLayoutPanel5)
        Me.CheckedGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CheckedGroupBox1.Location = New System.Drawing.Point(7, 7)
        Me.CheckedGroupBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckedGroupBox1.Name = "CheckedGroupBox1"
        Me.CheckedGroupBox1.Padding = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.CheckedGroupBox1.Size = New System.Drawing.Size(328, 116)
        Me.CheckedGroupBox1.TabIndex = 63
        Me.CheckedGroupBox1.TabStop = False
        Me.CheckedGroupBox1.Text = "Alarm"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.AutoSize = True
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.Controls.Add(Me.CheckBox1, 0, 4)
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
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(316, 89)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox1.AutoSize = True
        Me.TableLayoutPanel5.SetColumnSpan(Me.CheckBox1, 2)
        Me.CheckBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CheckBox1.Location = New System.Drawing.Point(3, 72)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(3, 2, 0, 0)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(155, 17)
        Me.CheckBox1.TabIndex = 101
        Me.CheckBox1.Text = "Play sound once per restart"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBoxLoop
        '
        Me.CheckBoxLoop.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBoxLoop.AutoSize = True
        Me.TableLayoutPanel5.SetColumnSpan(Me.CheckBoxLoop, 2)
        Me.CheckBoxLoop.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CheckBoxLoop.Location = New System.Drawing.Point(3, 53)
        Me.CheckBoxLoop.Margin = New System.Windows.Forms.Padding(3, 2, 0, 0)
        Me.CheckBoxLoop.Name = "CheckBoxLoop"
        Me.CheckBoxLoop.Size = New System.Drawing.Size(82, 17)
        Me.CheckBoxLoop.TabIndex = 3
        Me.CheckBoxLoop.Text = "Loop sound"
        Me.CheckBoxLoop.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
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
        Me.ButtonAlarmPlay.AutoSize = True
        Me.ButtonAlarmPlay.Image = Global.ElanTimer.My.Resources.Resources.play_green
        Me.ButtonAlarmPlay.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonAlarmPlay.Location = New System.Drawing.Point(294, 2)
        Me.ButtonAlarmPlay.Margin = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.ButtonAlarmPlay.Name = "ButtonAlarmPlay"
        Me.ButtonAlarmPlay.Size = New System.Drawing.Size(22, 22)
        Me.ButtonAlarmPlay.TabIndex = 1
        Me.ButtonAlarmPlay.UseVisualStyleBackColor = True
        '
        'ComboBoxAlarmPath
        '
        Me.ComboBoxAlarmPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxAlarmPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAlarmPath.FormattingEnabled = True
        Me.ComboBoxAlarmPath.Location = New System.Drawing.Point(50, 3)
        Me.ComboBoxAlarmPath.Margin = New System.Windows.Forms.Padding(2, 3, 2, 2)
        Me.ComboBoxAlarmPath.Name = "ComboBoxAlarmPath"
        Me.ComboBoxAlarmPath.Size = New System.Drawing.Size(240, 21)
        Me.ComboBoxAlarmPath.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
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
        Me.TrackBarVolume.AutoSize = False
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
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 262)
        Me.Controls.Add(Me.CheckedGroupBox1)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBoxShowNoteAlertWhenTimerExpires)
        Me.Name = "AlertsSettingsDialog"
        Me.Padding = New System.Windows.Forms.Padding(7)
        Me.Text = "AlertsSettingsDialog"
        Me.CheckedGroupBox1.ResumeLayout(False)
        Me.CheckedGroupBox1.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        CType(Me.TrackBarVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxShowNoteAlertWhenTimerExpires As System.Windows.Forms.CheckBox
    Friend WithEvents CheckedGroupBox1 As ElanTimer.CheckedGroupBox
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxLoop As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonAlarmPlay As System.Windows.Forms.Button
    Friend WithEvents ComboBoxAlarmPath As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TrackBarVolume As System.Windows.Forms.TrackBar
End Class
