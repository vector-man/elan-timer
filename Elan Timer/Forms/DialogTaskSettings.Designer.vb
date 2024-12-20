﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogTaskSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogTaskSettings))
        Me.DataListViewActions = New BrightIdeasSoftware.DataListView()
        Me.OlvColumnName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnEvent = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnCommand = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumnArguments = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ButtonAdd = New System.Windows.Forms.Button()
        Me.ButtonRemove = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonExport = New System.Windows.Forms.Button()
        Me.ButtonImport = New System.Windows.Forms.Button()
        Me.TableLayoutPanelActions = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonBrowseForFolder = New System.Windows.Forms.Button()
        Me.TextBoxArguments = New System.Windows.Forms.TextBox()
        Me.LabelArguments = New System.Windows.Forms.Label()
        Me.TextBoxCommand = New System.Windows.Forms.TextBox()
        Me.TextBoxName = New System.Windows.Forms.TextBox()
        Me.LabelName = New System.Windows.Forms.Label()
        Me.ComboBoxEvent = New System.Windows.Forms.ComboBox()
        Me.LabelCommand = New System.Windows.Forms.Label()
        Me.LabelEvent = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.ContextMenuExport = New System.Windows.Forms.ContextMenu()
        Me.MenuItemExportSelected = New System.Windows.Forms.MenuItem()
        Me.MenuItemExportAll = New System.Windows.Forms.MenuItem()
        CType(Me.DataListViewActions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanelActions.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
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
        resources.ApplyResources(Me.DataListViewActions, "DataListViewActions")
        Me.DataListViewActions.FullRowSelect = True
        Me.DataListViewActions.HideSelection = False
        Me.DataListViewActions.Name = "DataListViewActions"
        Me.DataListViewActions.OwnerDraw = True
        Me.DataListViewActions.ShowGroups = False
        Me.DataListViewActions.ShowItemToolTips = True
        Me.DataListViewActions.UseCompatibleStateImageBehavior = False
        Me.DataListViewActions.UseExplorerTheme = True
        Me.DataListViewActions.View = System.Windows.Forms.View.Details
        '
        'OlvColumnName
        '
        Me.OlvColumnName.AspectName = "Name"
        Me.OlvColumnName.CellPadding = Nothing
        resources.ApplyResources(Me.OlvColumnName, "OlvColumnName")
        '
        'OlvColumnEvent
        '
        Me.OlvColumnEvent.AspectName = "Event"
        Me.OlvColumnEvent.CellPadding = Nothing
        resources.ApplyResources(Me.OlvColumnEvent, "OlvColumnEvent")
        '
        'OlvColumnCommand
        '
        Me.OlvColumnCommand.AspectName = "Command"
        Me.OlvColumnCommand.CellPadding = Nothing
        resources.ApplyResources(Me.OlvColumnCommand, "OlvColumnCommand")
        '
        'OlvColumnArguments
        '
        Me.OlvColumnArguments.AspectName = "Arguments"
        Me.OlvColumnArguments.CellPadding = Nothing
        resources.ApplyResources(Me.OlvColumnArguments, "OlvColumnArguments")
        '
        'ButtonAdd
        '
        resources.ApplyResources(Me.ButtonAdd, "ButtonAdd")
        Me.ButtonAdd.Name = "ButtonAdd"
        Me.ButtonAdd.UseVisualStyleBackColor = True
        '
        'ButtonRemove
        '
        resources.ApplyResources(Me.ButtonRemove, "ButtonRemove")
        Me.ButtonRemove.Name = "ButtonRemove"
        Me.ButtonRemove.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanelActions, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.DataListViewActions, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
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
        'TableLayoutPanelActions
        '
        resources.ApplyResources(Me.TableLayoutPanelActions, "TableLayoutPanelActions")
        Me.TableLayoutPanelActions.Controls.Add(Me.ButtonBrowseForFolder, 2, 2)
        Me.TableLayoutPanelActions.Controls.Add(Me.TextBoxArguments, 1, 3)
        Me.TableLayoutPanelActions.Controls.Add(Me.LabelArguments, 0, 3)
        Me.TableLayoutPanelActions.Controls.Add(Me.TextBoxCommand, 1, 2)
        Me.TableLayoutPanelActions.Controls.Add(Me.TextBoxName, 1, 1)
        Me.TableLayoutPanelActions.Controls.Add(Me.LabelName, 0, 1)
        Me.TableLayoutPanelActions.Controls.Add(Me.ComboBoxEvent, 1, 0)
        Me.TableLayoutPanelActions.Controls.Add(Me.LabelCommand, 0, 2)
        Me.TableLayoutPanelActions.Controls.Add(Me.LabelEvent, 0, 0)
        Me.TableLayoutPanelActions.Name = "TableLayoutPanelActions"
        '
        'ButtonBrowseForFolder
        '
        resources.ApplyResources(Me.ButtonBrowseForFolder, "ButtonBrowseForFolder")
        Me.ButtonBrowseForFolder.Name = "ButtonBrowseForFolder"
        Me.ButtonBrowseForFolder.UseVisualStyleBackColor = True
        '
        'TextBoxArguments
        '
        resources.ApplyResources(Me.TextBoxArguments, "TextBoxArguments")
        Me.TextBoxArguments.Name = "TextBoxArguments"
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
        'TextBoxName
        '
        resources.ApplyResources(Me.TextBoxName, "TextBoxName")
        Me.TextBoxName.Name = "TextBoxName"
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
        'TableLayoutPanel3
        '
        resources.ApplyResources(Me.TableLayoutPanel3, "TableLayoutPanel3")
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonAdd, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonRemove, 2, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        '
        'ContextMenuExport
        '
        Me.ContextMenuExport.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemExportSelected, Me.MenuItemExportAll})
        '
        'MenuItemExportSelected
        '
        Me.MenuItemExportSelected.Index = 0
        resources.ApplyResources(Me.MenuItemExportSelected, "MenuItemExportSelected")
        '
        'MenuItemExportAll
        '
        Me.MenuItemExportAll.Index = 1
        resources.ApplyResources(Me.MenuItemExportAll, "MenuItemExportAll")
        '
        'DialogTaskSettings
        '
        Me.AcceptButton = Me.ButtonOK
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogTaskSettings"
        Me.ShowInTaskbar = False
        CType(Me.DataListViewActions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanelActions.ResumeLayout(False)
        Me.TableLayoutPanelActions.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataListViewActions As BrightIdeasSoftware.DataListView
    Friend WithEvents OlvColumnName As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnEvent As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnCommand As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumnArguments As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ButtonAdd As System.Windows.Forms.Button
    Friend WithEvents ButtonRemove As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents ButtonExport As System.Windows.Forms.Button
    Friend WithEvents ButtonImport As System.Windows.Forms.Button
    Friend WithEvents ContextMenuExport As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemExportSelected As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemExportAll As System.Windows.Forms.MenuItem
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanelActions As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonBrowseForFolder As System.Windows.Forms.Button
    Friend WithEvents TextBoxArguments As System.Windows.Forms.TextBox
    Friend WithEvents LabelArguments As System.Windows.Forms.Label
    Friend WithEvents TextBoxCommand As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxName As System.Windows.Forms.TextBox
    Friend WithEvents LabelName As System.Windows.Forms.Label
    Friend WithEvents ComboBoxEvent As System.Windows.Forms.ComboBox
    Friend WithEvents LabelCommand As System.Windows.Forms.Label
    Friend WithEvents LabelEvent As System.Windows.Forms.Label

End Class
