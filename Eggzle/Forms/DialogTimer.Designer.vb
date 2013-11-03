<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogTimer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogTimer))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageTimer = New System.Windows.Forms.TabPage()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PanelRenderPreview = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxRenderer = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ColorComboBoxForegrounColor = New ColorComboTestApp.ColorComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ColorComboBoxBackgroundColor = New ColorComboTestApp.ColorComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.FontPickerFont = New Com.Windows.Forms.FontPicker()
        Me.CheckBoxSizeToFit = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.NumericUpDownOpacityLevel = New System.Windows.Forms.NumericUpDown()
        Me.TabPageActions = New System.Windows.Forms.TabPage()
        Me.DataListViewActions = New BrightIdeasSoftware.DataListView()
        Me.OlvColumnName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnEvent = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnCommand = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnArguments = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.TableLayoutPanelActions = New System.Windows.Forms.TableLayoutPanel()
        Me.ComboBoxScript = New System.Windows.Forms.ComboBox()
        Me.CheckBoxUseScript = New System.Windows.Forms.CheckBox()
        Me.TextBoxArguments = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxCommand = New System.Windows.Forms.TextBox()
        Me.TextBoxName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxEvent = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LabelActionsDescription = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBoxUseMemo = New System.Windows.Forms.CheckBox()
        Me.TextBoxMemo = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckBoxAlarmSet = New System.Windows.Forms.CheckBox()
        Me.ComboBoxAlarm = New System.Windows.Forms.ComboBox()
        Me.CheckBoxLoop = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NumericUpDownVolume = New System.Windows.Forms.NumericUpDown()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxTime = New System.Windows.Forms.TextBox()
        Me.CheckBoxCountUp = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NumericUpDownRestarts = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ButtonOpenScript = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.ButtonAdd = New System.Windows.Forms.Button()
        Me.ButtonRemove = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPageTimer.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        CType(Me.NumericUpDownOpacityLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageActions.SuspendLayout()
        CType(Me.DataListViewActions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanelActions.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.NumericUpDownVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.NumericUpDownRestarts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageTimer)
        Me.TabControl1.Controls.Add(Me.TabPageActions)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(491, 317)
        Me.TabControl1.TabIndex = 4
        '
        'TabPageTimer
        '
        Me.TabPageTimer.Controls.Add(Me.FlowLayoutPanel1)
        Me.TabPageTimer.Location = New System.Drawing.Point(4, 22)
        Me.TabPageTimer.Name = "TabPageTimer"
        Me.TabPageTimer.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageTimer.Size = New System.Drawing.Size(513, 291)
        Me.TabPageTimer.TabIndex = 0
        Me.TabPageTimer.Text = "General"
        Me.TabPageTimer.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox2)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox1)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(507, 285)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox1.Controls.Add(Me.PanelRenderPreview)
        Me.GroupBox1.Controls.Add(Me.FlowLayoutPanel4)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 131)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(495, 147)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Appearance"
        '
        'PanelRenderPreview
        '
        Me.PanelRenderPreview.BackColor = System.Drawing.Color.Black
        Me.PanelRenderPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelRenderPreview.Location = New System.Drawing.Point(299, 19)
        Me.PanelRenderPreview.Name = "PanelRenderPreview"
        Me.PanelRenderPreview.Size = New System.Drawing.Size(190, 79)
        Me.PanelRenderPreview.TabIndex = 36
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.AutoSize = True
        Me.FlowLayoutPanel4.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel4.Controls.Add(Me.ComboBoxRenderer)
        Me.FlowLayoutPanel4.Controls.Add(Me.Label11)
        Me.FlowLayoutPanel4.Controls.Add(Me.ColorComboBoxForegrounColor)
        Me.FlowLayoutPanel4.Controls.Add(Me.Label12)
        Me.FlowLayoutPanel4.Controls.Add(Me.ColorComboBoxBackgroundColor)
        Me.FlowLayoutPanel4.Controls.Add(Me.Label9)
        Me.FlowLayoutPanel4.Controls.Add(Me.FontPickerFont)
        Me.FlowLayoutPanel4.Controls.Add(Me.CheckBoxSizeToFit)
        Me.FlowLayoutPanel4.Controls.Add(Me.Label13)
        Me.FlowLayoutPanel4.Controls.Add(Me.NumericUpDownOpacityLevel)
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(9, 19)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(284, 109)
        Me.FlowLayoutPanel4.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 6)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Renderer: "
        '
        'ComboBoxRenderer
        '
        Me.ComboBoxRenderer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FlowLayoutPanel4.SetFlowBreak(Me.ComboBoxRenderer, True)
        Me.ComboBoxRenderer.FormattingEnabled = True
        Me.ComboBoxRenderer.Location = New System.Drawing.Point(66, 3)
        Me.ComboBoxRenderer.Name = "ComboBoxRenderer"
        Me.ComboBoxRenderer.Size = New System.Drawing.Size(136, 21)
        Me.ComboBoxRenderer.TabIndex = 17
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 33)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 13)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "Foreground Color:"
        '
        'ColorComboBoxForegrounColor
        '
        Me.ColorComboBoxForegrounColor.Extended = False
        Me.ColorComboBoxForegrounColor.Location = New System.Drawing.Point(100, 30)
        Me.ColorComboBoxForegrounColor.Name = "ColorComboBoxForegrounColor"
        Me.ColorComboBoxForegrounColor.SelectedColor = System.Drawing.Color.Black
        Me.ColorComboBoxForegrounColor.Size = New System.Drawing.Size(36, 21)
        Me.ColorComboBoxForegrounColor.TabIndex = 44
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(142, 33)
        Me.Label12.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 13)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "Background Color:"
        '
        'ColorComboBoxBackgroundColor
        '
        Me.ColorComboBoxBackgroundColor.Extended = False
        Me.FlowLayoutPanel4.SetFlowBreak(Me.ColorComboBoxBackgroundColor, True)
        Me.ColorComboBoxBackgroundColor.Location = New System.Drawing.Point(243, 30)
        Me.ColorComboBoxBackgroundColor.Name = "ColorComboBoxBackgroundColor"
        Me.ColorComboBoxBackgroundColor.SelectedColor = System.Drawing.Color.Black
        Me.ColorComboBoxBackgroundColor.Size = New System.Drawing.Size(36, 21)
        Me.ColorComboBoxBackgroundColor.TabIndex = 46
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 60)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Font: "
        '
        'FontPickerFont
        '
        Me.FontPickerFont.BackColor = System.Drawing.SystemColors.Window
        Me.FontPickerFont.Context = Nothing
        Me.FontPickerFont.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FontPickerFont.Location = New System.Drawing.Point(43, 57)
        Me.FontPickerFont.Name = "FontPickerFont"
        Me.FontPickerFont.ReadOnly = False
        Me.FontPickerFont.Size = New System.Drawing.Size(159, 20)
        Me.FontPickerFont.TabIndex = 48
        Me.FontPickerFont.Text = "Microsoft Sans Serif, 8.25pt"
        Me.FontPickerFont.Value = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        '
        'CheckBoxSizeToFit
        '
        Me.FlowLayoutPanel4.SetFlowBreak(Me.CheckBoxSizeToFit, True)
        Me.CheckBoxSizeToFit.Location = New System.Drawing.Point(208, 60)
        Me.CheckBoxSizeToFit.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.CheckBoxSizeToFit.Name = "CheckBoxSizeToFit"
        Me.CheckBoxSizeToFit.Size = New System.Drawing.Size(69, 17)
        Me.CheckBoxSizeToFit.TabIndex = 0
        Me.CheckBoxSizeToFit.Text = "Size to fit"
        Me.CheckBoxSizeToFit.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 89)
        Me.Label13.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 13)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Opacity Level:"
        '
        'NumericUpDownOpacityLevel
        '
        Me.NumericUpDownOpacityLevel.AutoSize = True
        Me.NumericUpDownOpacityLevel.Location = New System.Drawing.Point(84, 86)
        Me.NumericUpDownOpacityLevel.Minimum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.NumericUpDownOpacityLevel.Name = "NumericUpDownOpacityLevel"
        Me.NumericUpDownOpacityLevel.Size = New System.Drawing.Size(41, 20)
        Me.NumericUpDownOpacityLevel.TabIndex = 41
        Me.NumericUpDownOpacityLevel.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'TabPageActions
        '
        Me.TabPageActions.Controls.Add(Me.DataListViewActions)
        Me.TabPageActions.Controls.Add(Me.TableLayoutPanelActions)
        Me.TabPageActions.Controls.Add(Me.LabelActionsDescription)
        Me.TabPageActions.Controls.Add(Me.ButtonAdd)
        Me.TabPageActions.Controls.Add(Me.ButtonRemove)
        Me.TabPageActions.Location = New System.Drawing.Point(4, 22)
        Me.TabPageActions.Name = "TabPageActions"
        Me.TabPageActions.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageActions.Size = New System.Drawing.Size(483, 291)
        Me.TabPageActions.TabIndex = 1
        Me.TabPageActions.Text = "Actions"
        Me.TabPageActions.UseVisualStyleBackColor = True
        '
        'DataListViewActions
        '
        Me.DataListViewActions.AllColumns.Add(Me.OlvColumnName)
        Me.DataListViewActions.AllColumns.Add(Me.OlvColumnEvent)
        Me.DataListViewActions.AllColumns.Add(Me.OlvColumnCommand)
        Me.DataListViewActions.AllColumns.Add(Me.OlvColumnArguments)
        Me.DataListViewActions.AutoGenerateColumns = False
        Me.DataListViewActions.CheckBoxes = True
        Me.DataListViewActions.CheckedAspectName = "Enabled"
        Me.DataListViewActions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumnName, Me.OlvColumnEvent, Me.OlvColumnCommand, Me.OlvColumnArguments})
        Me.DataListViewActions.DataSource = Nothing
        Me.DataListViewActions.FullRowSelect = True
        Me.DataListViewActions.HideSelection = False
        Me.DataListViewActions.Location = New System.Drawing.Point(8, 38)
        Me.DataListViewActions.Name = "DataListViewActions"
        Me.DataListViewActions.OwnerDraw = True
        Me.DataListViewActions.ShowGroups = False
        Me.DataListViewActions.Size = New System.Drawing.Size(470, 102)
        Me.DataListViewActions.TabIndex = 35
        Me.DataListViewActions.UseCompatibleStateImageBehavior = False
        Me.DataListViewActions.UseExplorerTheme = True
        Me.DataListViewActions.View = System.Windows.Forms.View.Details
        '
        'OlvColumnName
        '
        Me.OlvColumnName.AspectName = "Name"
        Me.OlvColumnName.CellPadding = Nothing
        Me.OlvColumnName.Text = "Name"
        Me.OlvColumnName.Width = 160
        '
        'OlvColumnEvent
        '
        Me.OlvColumnEvent.AspectName = "Event"
        Me.OlvColumnEvent.CellPadding = Nothing
        Me.OlvColumnEvent.Text = "Event"
        '
        'OlvColumnCommand
        '
        Me.OlvColumnCommand.AspectName = "Command"
        Me.OlvColumnCommand.CellPadding = Nothing
        Me.OlvColumnCommand.Text = "Command"
        Me.OlvColumnCommand.Width = 170
        '
        'OlvColumnArguments
        '
        Me.OlvColumnArguments.AspectName = "Arguments"
        Me.OlvColumnArguments.CellPadding = Nothing
        Me.OlvColumnArguments.Text = "Arguments"
        Me.OlvColumnArguments.Width = 90
        '
        'TableLayoutPanelActions
        '
        Me.TableLayoutPanelActions.AutoSize = True
        Me.TableLayoutPanelActions.ColumnCount = 3
        Me.TableLayoutPanelActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelActions.Controls.Add(Me.ButtonOpenScript, 2, 4)
        Me.TableLayoutPanelActions.Controls.Add(Me.Button15, 2, 2)
        Me.TableLayoutPanelActions.Controls.Add(Me.ComboBoxScript, 1, 4)
        Me.TableLayoutPanelActions.Controls.Add(Me.CheckBoxUseScript, 0, 4)
        Me.TableLayoutPanelActions.Controls.Add(Me.TextBoxArguments, 1, 3)
        Me.TableLayoutPanelActions.Controls.Add(Me.Label6, 0, 3)
        Me.TableLayoutPanelActions.Controls.Add(Me.TextBoxCommand, 1, 2)
        Me.TableLayoutPanelActions.Controls.Add(Me.TextBoxName, 1, 1)
        Me.TableLayoutPanelActions.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanelActions.Controls.Add(Me.ComboBoxEvent, 1, 0)
        Me.TableLayoutPanelActions.Controls.Add(Me.Label5, 0, 2)
        Me.TableLayoutPanelActions.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanelActions.Location = New System.Drawing.Point(8, 146)
        Me.TableLayoutPanelActions.Name = "TableLayoutPanelActions"
        Me.TableLayoutPanelActions.RowCount = 5
        Me.TableLayoutPanelActions.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelActions.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelActions.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelActions.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelActions.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelActions.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelActions.Size = New System.Drawing.Size(501, 136)
        Me.TableLayoutPanelActions.TabIndex = 34
        '
        'ComboBoxScript
        '
        Me.ComboBoxScript.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxScript.FormattingEnabled = True
        Me.ComboBoxScript.Location = New System.Drawing.Point(88, 110)
        Me.ComboBoxScript.Name = "ComboBoxScript"
        Me.ComboBoxScript.Size = New System.Drawing.Size(382, 21)
        Me.ComboBoxScript.TabIndex = 41
        '
        'CheckBoxUseScript
        '
        Me.CheckBoxUseScript.AutoSize = True
        Me.CheckBoxUseScript.Location = New System.Drawing.Point(3, 113)
        Me.CheckBoxUseScript.Margin = New System.Windows.Forms.Padding(3, 6, 6, 6)
        Me.CheckBoxUseScript.Name = "CheckBoxUseScript"
        Me.CheckBoxUseScript.Size = New System.Drawing.Size(76, 17)
        Me.CheckBoxUseScript.TabIndex = 42
        Me.CheckBoxUseScript.Text = "Use script:"
        Me.CheckBoxUseScript.UseVisualStyleBackColor = True
        '
        'TextBoxArguments
        '
        Me.TextBoxArguments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxArguments.Location = New System.Drawing.Point(88, 84)
        Me.TextBoxArguments.Name = "TextBoxArguments"
        Me.TextBoxArguments.Size = New System.Drawing.Size(382, 20)
        Me.TextBoxArguments.TabIndex = 33
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(0, 87)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 6, 6, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "Arguments:"
        '
        'TextBoxCommand
        '
        Me.TextBoxCommand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCommand.Location = New System.Drawing.Point(88, 56)
        Me.TextBoxCommand.Name = "TextBoxCommand"
        Me.TextBoxCommand.Size = New System.Drawing.Size(382, 20)
        Me.TextBoxCommand.TabIndex = 34
        '
        'TextBoxName
        '
        Me.TextBoxName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxName.Location = New System.Drawing.Point(88, 30)
        Me.TextBoxName.Name = "TextBoxName"
        Me.TextBoxName.Size = New System.Drawing.Size(382, 20)
        Me.TextBoxName.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 33)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 6, 6, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Name:"
        '
        'ComboBoxEvent
        '
        Me.ComboBoxEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEvent.FormattingEnabled = True
        Me.ComboBoxEvent.Location = New System.Drawing.Point(88, 3)
        Me.ComboBoxEvent.Name = "ComboBoxEvent"
        Me.ComboBoxEvent.Size = New System.Drawing.Size(92, 21)
        Me.ComboBoxEvent.TabIndex = 32
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(0, 59)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 6, 6, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Command:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(0, 6)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 6, 6, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Event:"
        '
        'LabelActionsDescription
        '
        Me.LabelActionsDescription.AutoSize = True
        Me.LabelActionsDescription.Location = New System.Drawing.Point(5, 9)
        Me.LabelActionsDescription.Margin = New System.Windows.Forms.Padding(6)
        Me.LabelActionsDescription.Name = "LabelActionsDescription"
        Me.LabelActionsDescription.Size = New System.Drawing.Size(266, 13)
        Me.LabelActionsDescription.TabIndex = 31
        Me.LabelActionsDescription.Text = "Actions can be created to to fire at various timer states."
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.AutoScroll = True
        Me.FlowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel3.Controls.Add(Me.TableLayoutPanel2)
        Me.FlowLayoutPanel3.Controls.Add(Me.TableLayoutPanel3)
        Me.FlowLayoutPanel3.Controls.Add(Me.TableLayoutPanel4)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(6, 18)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(489, 91)
        Me.FlowLayoutPanel3.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoSize = True
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.Controls.Add(Me.TextBoxMemo, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.CheckBoxUseMemo, 0, 0)
        Me.FlowLayoutPanel3.SetFlowBreak(Me.TableLayoutPanel4, True)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 58)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(286, 29)
        Me.TableLayoutPanel4.TabIndex = 41
        '
        'CheckBoxUseMemo
        '
        Me.CheckBoxUseMemo.AutoSize = True
        Me.CheckBoxUseMemo.Location = New System.Drawing.Point(3, 3)
        Me.CheckBoxUseMemo.Name = "CheckBoxUseMemo"
        Me.CheckBoxUseMemo.Padding = New System.Windows.Forms.Padding(3)
        Me.CheckBoxUseMemo.Size = New System.Drawing.Size(85, 23)
        Me.CheckBoxUseMemo.TabIndex = 37
        Me.CheckBoxUseMemo.Text = "Use memo:"
        Me.CheckBoxUseMemo.UseVisualStyleBackColor = True
        '
        'TextBoxMemo
        '
        Me.TextBoxMemo.Location = New System.Drawing.Point(94, 3)
        Me.TextBoxMemo.Multiline = True
        Me.TextBoxMemo.Name = "TextBoxMemo"
        Me.TextBoxMemo.Size = New System.Drawing.Size(189, 22)
        Me.TextBoxMemo.TabIndex = 36
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.ColumnCount = 7
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.Button5, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.NumericUpDownVolume, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label7, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.CheckBoxLoop, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ComboBoxAlarm, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.CheckBoxAlarmSet, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Button3, 3, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 29)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(484, 29)
        Me.TableLayoutPanel3.TabIndex = 40
        '
        'CheckBoxAlarmSet
        '
        Me.CheckBoxAlarmSet.AutoSize = True
        Me.CheckBoxAlarmSet.Location = New System.Drawing.Point(3, 3)
        Me.CheckBoxAlarmSet.Name = "CheckBoxAlarmSet"
        Me.CheckBoxAlarmSet.Padding = New System.Windows.Forms.Padding(3)
        Me.CheckBoxAlarmSet.Size = New System.Drawing.Size(78, 23)
        Me.CheckBoxAlarmSet.TabIndex = 39
        Me.CheckBoxAlarmSet.Text = "Alarm set:"
        Me.CheckBoxAlarmSet.UseVisualStyleBackColor = True
        '
        'ComboBoxAlarm
        '
        Me.ComboBoxAlarm.FormattingEnabled = True
        Me.ComboBoxAlarm.Location = New System.Drawing.Point(87, 3)
        Me.ComboBoxAlarm.Name = "ComboBoxAlarm"
        Me.ComboBoxAlarm.Size = New System.Drawing.Size(172, 21)
        Me.ComboBoxAlarm.TabIndex = 40
        '
        'CheckBoxLoop
        '
        Me.CheckBoxLoop.AutoSize = True
        Me.CheckBoxLoop.Location = New System.Drawing.Point(321, 3)
        Me.CheckBoxLoop.Name = "CheckBoxLoop"
        Me.CheckBoxLoop.Padding = New System.Windows.Forms.Padding(3)
        Me.CheckBoxLoop.Size = New System.Drawing.Size(56, 23)
        Me.CheckBoxLoop.TabIndex = 41
        Me.CheckBoxLoop.Text = "Loop"
        Me.CheckBoxLoop.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(383, 3)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(3)
        Me.Label7.Size = New System.Drawing.Size(51, 19)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Volume:"
        '
        'NumericUpDownVolume
        '
        Me.NumericUpDownVolume.AutoSize = True
        Me.NumericUpDownVolume.Location = New System.Drawing.Point(440, 3)
        Me.NumericUpDownVolume.Name = "NumericUpDownVolume"
        Me.NumericUpDownVolume.Size = New System.Drawing.Size(41, 20)
        Me.NumericUpDownVolume.TabIndex = 43
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.NumericUpDownRestarts, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBox3, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxCountUp, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxTime, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 0)
        Me.FlowLayoutPanel3.SetFlowBreak(Me.TableLayoutPanel2, True)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(489, 29)
        Me.TableLayoutPanel2.TabIndex = 39
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.Label3.Size = New System.Drawing.Size(36, 19)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Time:"
        '
        'TextBoxTime
        '
        Me.TextBoxTime.Location = New System.Drawing.Point(45, 3)
        Me.TextBoxTime.Name = "TextBoxTime"
        Me.TextBoxTime.Size = New System.Drawing.Size(164, 20)
        Me.TextBoxTime.TabIndex = 34
        '
        'CheckBoxCountUp
        '
        Me.CheckBoxCountUp.AutoSize = True
        Me.CheckBoxCountUp.Location = New System.Drawing.Point(215, 3)
        Me.CheckBoxCountUp.Name = "CheckBoxCountUp"
        Me.CheckBoxCountUp.Padding = New System.Windows.Forms.Padding(3)
        Me.CheckBoxCountUp.Size = New System.Drawing.Size(75, 23)
        Me.CheckBoxCountUp.TabIndex = 35
        Me.CheckBoxCountUp.Text = "Count up"
        Me.CheckBoxCountUp.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(296, 3)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Padding = New System.Windows.Forms.Padding(3)
        Me.CheckBox3.Size = New System.Drawing.Size(77, 23)
        Me.CheckBox3.TabIndex = 38
        Me.CheckBox3.Text = "Auto start"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(379, 3)
        Me.Label8.Margin = New System.Windows.Forms.Padding(3)
        Me.Label8.Name = "Label8"
        Me.Label8.Padding = New System.Windows.Forms.Padding(3)
        Me.Label8.Size = New System.Drawing.Size(55, 19)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Restarts:"
        '
        'NumericUpDownRestarts
        '
        Me.NumericUpDownRestarts.AutoSize = True
        Me.NumericUpDownRestarts.Location = New System.Drawing.Point(440, 3)
        Me.NumericUpDownRestarts.Name = "NumericUpDownRestarts"
        Me.NumericUpDownRestarts.Size = New System.Drawing.Size(41, 20)
        Me.NumericUpDownRestarts.TabIndex = 45
        '
        'GroupBox2
        '
        Me.GroupBox2.AutoSize = True
        Me.GroupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox2.Controls.Add(Me.FlowLayoutPanel3)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(501, 128)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Timer"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(9, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Load..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(90, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Save As..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOK.Location = New System.Drawing.Point(326, 9)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOK.TabIndex = 2
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button4.Location = New System.Drawing.Point(407, 9)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Cancel"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Button4, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonOK, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 317)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(6)
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(491, 41)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Button5
        '
        Me.Button5.AutoSize = True
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(265, 3)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(22, 22)
        Me.Button5.TabIndex = 45
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.AutoSize = True
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(293, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(22, 22)
        Me.Button3.TabIndex = 44
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ButtonOpenScript
        '
        Me.ButtonOpenScript.AutoSize = True
        Me.ButtonOpenScript.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ButtonOpenScript.Image = CType(resources.GetObject("ButtonOpenScript.Image"), System.Drawing.Image)
        Me.ButtonOpenScript.Location = New System.Drawing.Point(476, 110)
        Me.ButtonOpenScript.Name = "ButtonOpenScript"
        Me.ButtonOpenScript.Size = New System.Drawing.Size(22, 22)
        Me.ButtonOpenScript.TabIndex = 43
        Me.ButtonOpenScript.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.AutoSize = True
        Me.Button15.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Button15.Image = CType(resources.GetObject("Button15.Image"), System.Drawing.Image)
        Me.Button15.Location = New System.Drawing.Point(476, 56)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(22, 22)
        Me.Button15.TabIndex = 23
        Me.Button15.UseVisualStyleBackColor = True
        '
        'ButtonAdd
        '
        Me.ButtonAdd.AutoSize = True
        Me.ButtonAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ButtonAdd.Image = CType(resources.GetObject("ButtonAdd.Image"), System.Drawing.Image)
        Me.ButtonAdd.Location = New System.Drawing.Point(333, 9)
        Me.ButtonAdd.Name = "ButtonAdd"
        Me.ButtonAdd.Size = New System.Drawing.Size(52, 23)
        Me.ButtonAdd.TabIndex = 33
        Me.ButtonAdd.Text = "Add"
        Me.ButtonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonAdd.UseVisualStyleBackColor = True
        '
        'ButtonRemove
        '
        Me.ButtonRemove.AutoSize = True
        Me.ButtonRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ButtonRemove.Image = CType(resources.GetObject("ButtonRemove.Image"), System.Drawing.Image)
        Me.ButtonRemove.Location = New System.Drawing.Point(391, 9)
        Me.ButtonRemove.Name = "ButtonRemove"
        Me.ButtonRemove.Size = New System.Drawing.Size(118, 23)
        Me.ButtonRemove.TabIndex = 32
        Me.ButtonRemove.Text = "Remove Selected"
        Me.ButtonRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonRemove.UseVisualStyleBackColor = True
        '
        'DialogTimer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(491, 358)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogTimer"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Timer Settings - Eggzle"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageTimer.ResumeLayout(False)
        Me.TabPageTimer.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel4.PerformLayout()
        CType(Me.NumericUpDownOpacityLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageActions.ResumeLayout(False)
        Me.TabPageActions.PerformLayout()
        CType(Me.DataListViewActions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanelActions.ResumeLayout(False)
        Me.TableLayoutPanelActions.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.NumericUpDownVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.NumericUpDownRestarts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPageTimer As System.Windows.Forms.TabPage
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TabPageActions As System.Windows.Forms.TabPage
    Friend WithEvents DataListViewActions As BrightIdeasSoftware.DataListView
    Friend WithEvents OlvColumnName As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnEvent As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnCommand As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnArguments As BrightIdeasSoftware.OLVColumn
    Friend WithEvents TableLayoutPanelActions As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonOpenScript As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents ComboBoxScript As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxUseScript As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxArguments As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBoxCommand As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxEvent As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ButtonAdd As System.Windows.Forms.Button
    Friend WithEvents ButtonRemove As System.Windows.Forms.Button
    Friend WithEvents LabelActionsDescription As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PanelRenderPreview As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel4 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxRenderer As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ColorComboBoxForegrounColor As ColorComboTestApp.ColorComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ColorComboBoxBackgroundColor As ColorComboTestApp.ColorComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownOpacityLevel As System.Windows.Forms.NumericUpDown
    Friend WithEvents FontPickerFont As Com.Windows.Forms.FontPicker
    Friend WithEvents CheckBoxSizeToFit As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents NumericUpDownRestarts As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxCountUp As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxTime As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents NumericUpDownVolume As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxLoop As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBoxAlarm As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxAlarmSet As System.Windows.Forms.CheckBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBoxMemo As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxUseMemo As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class
