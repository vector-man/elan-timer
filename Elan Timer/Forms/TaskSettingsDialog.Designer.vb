﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TaskSettingsDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TaskSettingsDialog))
        Me.TableLayoutPanelActions = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataListViewTasks = New BrightIdeasSoftware.DataListView()
        Me.OlvColumnEnabled = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnEvent = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ButtonRemove = New System.Windows.Forms.Button()
        Me.ButtonBrowseForFile = New System.Windows.Forms.Button()
        Me.LabelArguments = New System.Windows.Forms.Label()
        Me.TextBoxCommand = New System.Windows.Forms.TextBox()
        Me.LabelName = New System.Windows.Forms.Label()
        Me.ComboBoxEvent = New System.Windows.Forms.ComboBox()
        Me.LabelCommand = New System.Windows.Forms.Label()
        Me.LabelEvent = New System.Windows.Forms.Label()
        Me.ButtonAdd = New System.Windows.Forms.Button()
        Me.ButtonMoveDown = New System.Windows.Forms.Button()
        Me.ButtonMoveUp = New System.Windows.Forms.Button()
        Me.TextBoxArguments = New System.Windows.Forms.TextBox()
        Me.TextBoxName = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanelActions.SuspendLayout()
        CType(Me.DataListViewTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanelActions
        '
        resources.ApplyResources(Me.TableLayoutPanelActions, "TableLayoutPanelActions")
        Me.TableLayoutPanelActions.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanelActions.Controls.Add(Me.TableLayoutPanel7, 0, 9)
        Me.TableLayoutPanelActions.Controls.Add(Me.DataListViewTasks, 0, 0)
        Me.TableLayoutPanelActions.Controls.Add(Me.ButtonRemove, 2, 1)
        Me.TableLayoutPanelActions.Controls.Add(Me.ButtonBrowseForFile, 2, 7)
        Me.TableLayoutPanelActions.Controls.Add(Me.LabelArguments, 0, 8)
        Me.TableLayoutPanelActions.Controls.Add(Me.TextBoxCommand, 1, 7)
        Me.TableLayoutPanelActions.Controls.Add(Me.LabelName, 0, 6)
        Me.TableLayoutPanelActions.Controls.Add(Me.ComboBoxEvent, 1, 5)
        Me.TableLayoutPanelActions.Controls.Add(Me.LabelCommand, 0, 7)
        Me.TableLayoutPanelActions.Controls.Add(Me.LabelEvent, 0, 5)
        Me.TableLayoutPanelActions.Controls.Add(Me.ButtonAdd, 2, 0)
        Me.TableLayoutPanelActions.Controls.Add(Me.ButtonMoveDown, 2, 4)
        Me.TableLayoutPanelActions.Controls.Add(Me.ButtonMoveUp, 2, 3)
        Me.TableLayoutPanelActions.Controls.Add(Me.TextBoxArguments, 1, 8)
        Me.TableLayoutPanelActions.Controls.Add(Me.TextBoxName, 1, 6)
        Me.TableLayoutPanelActions.Name = "TableLayoutPanelActions"
        '
        'TableLayoutPanel7
        '
        resources.ApplyResources(Me.TableLayoutPanel7, "TableLayoutPanel7")
        Me.TableLayoutPanelActions.SetColumnSpan(Me.TableLayoutPanel7, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        '
        'DataListViewTasks
        '
        Me.DataListViewTasks.AllColumns.Add(Me.OlvColumnEnabled)
        Me.DataListViewTasks.AllColumns.Add(Me.OlvColumnName)
        Me.DataListViewTasks.AllColumns.Add(Me.OlvColumnEvent)
        Me.DataListViewTasks.AutoGenerateColumns = False
        Me.DataListViewTasks.CheckBoxes = True
        Me.DataListViewTasks.CheckedAspectName = "Enabled"
        Me.DataListViewTasks.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumnEnabled, Me.OlvColumnName, Me.OlvColumnEvent})
        Me.TableLayoutPanelActions.SetColumnSpan(Me.DataListViewTasks, 2)
        Me.DataListViewTasks.DataSource = Nothing
        resources.ApplyResources(Me.DataListViewTasks, "DataListViewTasks")
        Me.DataListViewTasks.FullRowSelect = True
        Me.DataListViewTasks.HideSelection = False
        Me.DataListViewTasks.Name = "DataListViewTasks"
        Me.DataListViewTasks.OwnerDraw = True
        Me.TableLayoutPanelActions.SetRowSpan(Me.DataListViewTasks, 5)
        Me.DataListViewTasks.ShowGroups = False
        Me.DataListViewTasks.ShowItemToolTips = True
        Me.DataListViewTasks.UseCompatibleStateImageBehavior = False
        Me.DataListViewTasks.UseExplorerTheme = True
        Me.DataListViewTasks.View = System.Windows.Forms.View.Details
        '
        'OlvColumnEnabled
        '
        Me.OlvColumnEnabled.AspectName = "Enabled"
        Me.OlvColumnEnabled.CellPadding = Nothing
        Me.OlvColumnEnabled.CheckBoxes = True
        Me.OlvColumnEnabled.MaximumWidth = 16
        Me.OlvColumnEnabled.MinimumWidth = 16
        Me.OlvColumnEnabled.ShowTextInHeader = False
        Me.OlvColumnEnabled.Sortable = False
        resources.ApplyResources(Me.OlvColumnEnabled, "OlvColumnEnabled")
        '
        'OlvColumnName
        '
        Me.OlvColumnName.AspectName = "Name"
        Me.OlvColumnName.CellPadding = Nothing
        Me.OlvColumnName.Sortable = False
        resources.ApplyResources(Me.OlvColumnName, "OlvColumnName")
        '
        'OlvColumnEvent
        '
        Me.OlvColumnEvent.AspectName = "Event"
        Me.OlvColumnEvent.CellPadding = Nothing
        Me.OlvColumnEvent.Sortable = False
        resources.ApplyResources(Me.OlvColumnEvent, "OlvColumnEvent")
        '
        'ButtonRemove
        '
        resources.ApplyResources(Me.ButtonRemove, "ButtonRemove")
        Me.ButtonRemove.Name = "ButtonRemove"
        Me.ButtonRemove.UseVisualStyleBackColor = True
        '
        'ButtonBrowseForFile
        '
        resources.ApplyResources(Me.ButtonBrowseForFile, "ButtonBrowseForFile")
        Me.ButtonBrowseForFile.Name = "ButtonBrowseForFile"
        Me.ButtonBrowseForFile.UseVisualStyleBackColor = True
        '
        'LabelArguments
        '
        resources.ApplyResources(Me.LabelArguments, "LabelArguments")
        Me.LabelArguments.Name = "LabelArguments"
        '
        'TextBoxCommand
        '
        resources.ApplyResources(Me.TextBoxCommand, "TextBoxCommand")
        Me.TextBoxCommand.Name = "TextBoxCommand"
        '
        'LabelName
        '
        resources.ApplyResources(Me.LabelName, "LabelName")
        Me.LabelName.Name = "LabelName"
        '
        'ComboBoxEvent
        '
        Me.ComboBoxEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEvent.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBoxEvent, "ComboBoxEvent")
        Me.ComboBoxEvent.Name = "ComboBoxEvent"
        '
        'LabelCommand
        '
        resources.ApplyResources(Me.LabelCommand, "LabelCommand")
        Me.LabelCommand.Name = "LabelCommand"
        '
        'LabelEvent
        '
        resources.ApplyResources(Me.LabelEvent, "LabelEvent")
        Me.LabelEvent.Name = "LabelEvent"
        '
        'ButtonAdd
        '
        resources.ApplyResources(Me.ButtonAdd, "ButtonAdd")
        Me.ButtonAdd.Name = "ButtonAdd"
        Me.ButtonAdd.UseVisualStyleBackColor = True
        '
        'ButtonMoveDown
        '
        resources.ApplyResources(Me.ButtonMoveDown, "ButtonMoveDown")
        Me.ButtonMoveDown.Name = "ButtonMoveDown"
        Me.ButtonMoveDown.UseVisualStyleBackColor = True
        '
        'ButtonMoveUp
        '
        resources.ApplyResources(Me.ButtonMoveUp, "ButtonMoveUp")
        Me.ButtonMoveUp.Name = "ButtonMoveUp"
        Me.ButtonMoveUp.UseVisualStyleBackColor = True
        '
        'TextBoxArguments
        '
        resources.ApplyResources(Me.TextBoxArguments, "TextBoxArguments")
        Me.TextBoxArguments.Name = "TextBoxArguments"
        '
        'TextBoxName
        '
        resources.ApplyResources(Me.TextBoxName, "TextBoxName")
        Me.TextBoxName.Name = "TextBoxName"
        '
        'TaskSettingsDialog
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanelActions)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TaskSettingsDialog"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanelActions.ResumeLayout(False)
        Me.TableLayoutPanelActions.PerformLayout()
        CType(Me.DataListViewTasks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanelActions As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DataListViewTasks As BrightIdeasSoftware.DataListView
    Friend WithEvents OlvColumnName As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnEvent As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ButtonRemove As System.Windows.Forms.Button
    Friend WithEvents ButtonBrowseForFile As System.Windows.Forms.Button
    Friend WithEvents LabelArguments As System.Windows.Forms.Label
    Friend WithEvents TextBoxCommand As System.Windows.Forms.TextBox
    Friend WithEvents LabelName As System.Windows.Forms.Label
    Friend WithEvents ComboBoxEvent As System.Windows.Forms.ComboBox
    Friend WithEvents LabelCommand As System.Windows.Forms.Label
    Friend WithEvents LabelEvent As System.Windows.Forms.Label
    Friend WithEvents ButtonAdd As System.Windows.Forms.Button
    Friend WithEvents ButtonMoveDown As System.Windows.Forms.Button
    Friend WithEvents ButtonMoveUp As System.Windows.Forms.Button
    Friend WithEvents TextBoxArguments As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxName As System.Windows.Forms.TextBox
    Friend WithEvents OlvColumnEnabled As BrightIdeasSoftware.OLVColumn

End Class
