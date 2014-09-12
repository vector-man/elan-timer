﻿Imports System.Windows.Forms
Imports System.IO
Imports ElanTimer.Infralution.Localization
Imports NLog

Public Class TaskSettingsDialog

    Private actionsData As List(Of TaskModel)
    Private actionsBindingSource As BindingSource
    Private model As New TasksModel()
    Private taskToolTip As ToolTip

    ' Logging
    Private Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub
    Public Property InitialDirectory As String
    Public Property FileFilter As String
    Public Property Tasks As List(Of TaskModel)
        Get
            Return model.Tasks
        End Get
        Set(value As List(Of TaskModel))
            model.Tasks = value
        End Set
    End Property

    Public Sub UpdateStates(sender As Object, e As EventArgs)
        Dim enabled As Boolean = (DataListViewTasks.SelectedObjects.Count = 1)
        LabelEvent.Enabled = enabled
        ComboBoxEvent.Enabled = enabled
        LabelName.Enabled = enabled
        TextBoxName.Enabled = enabled
        LabelCommand.Enabled = enabled
        TextBoxCommand.Enabled = enabled
        ButtonBrowseForFile.Enabled = enabled
        LabelArguments.Enabled = enabled
        TextBoxArguments.Enabled = enabled
        ButtonMoveUp.Enabled = enabled
        ButtonMoveDown.Enabled = enabled

        ButtonRemove.Enabled = (DataListViewTasks.SelectedObjects.Count > 0)

        MenuItemExportSelected.Enabled = (Not DataListViewTasks.SelectedIndices.Count = 0)
        MenuItemExportAll.Enabled = (DataListViewTasks.GetItemCount() > 0)
    End Sub
    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        actionsBindingSource.Add(New TaskModel(TimerEvent.Started, My.Resources.Strings.NewTask, "", "", False, "", True))
    End Sub

    Private Sub ButtonRemove_Click(sender As Object, e As EventArgs) Handles ButtonRemove.Click
        Try
            Dim selectedObjects = DataListViewTasks.SelectedObjects

            For Each obj In selectedObjects
                actionsBindingSource.Remove(obj)
            Next
        Catch ex As Exception
            logger.Error(ex)
        End Try
    End Sub

    Private Function CloneTasks(tasks As List(Of TaskModel))
        Return tasks.ConvertAll(Function(task) New TaskModel(task.Event, task.Name, task.Command, task.Arguments, task.UseScript, task.Script, task.Enabled))
    End Function
    Private Sub Initialize()
        taskToolTip = New ToolTip()
        AddHandler Application.Idle, AddressOf UpdateStates

        model.Tasks = If(model.Tasks, New List(Of TaskModel))
        actionsBindingSource = New BindingSource()
        actionsBindingSource.DataSource = model.Tasks
        DataListViewTasks.DataSource = actionsBindingSource

        ComboBoxEvent.DataSource = [Enum].GetValues(GetType(TimerEvent))
        ComboBoxEvent.DataBindings.Add("Text", actionsBindingSource, "Event", True, DataSourceUpdateMode.OnPropertyChanged)
        TextBoxName.DataBindings.Add("Text", actionsBindingSource, "Name", True, DataSourceUpdateMode.OnPropertyChanged)
        TextBoxCommand.DataBindings.Add("Text", actionsBindingSource, "Command", True, DataSourceUpdateMode.OnPropertyChanged)
        TextBoxArguments.DataBindings.Add("Text", actionsBindingSource, "Arguments", True, DataSourceUpdateMode.OnPropertyChanged)

        ' Used to fix localization issue for "Event" column.
        OlvColumnEvent.AspectGetter = Function(obj)
                                          ' Convert the event in task (obj) to the localized string.
                                          Return ResourceEnumConverter.ConvertToString(DirectCast(obj, TaskModel).Event)
                                      End Function

        SetStrings()
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        Me.StartPosition = If(Owner Is Nothing, FormStartPosition.CenterScreen, FormStartPosition.CenterParent)
        Me.TopMost = True
        MyBase.OnLoad(e)
    End Sub

    Private Sub ExportTasks(Optional exportSelected As Boolean = False)
        Using saveDialog As New SaveFileDialog
            saveDialog.InitialDirectory = InitialDirectory
            saveDialog.Filter = FileFilter
            saveDialog.OverwritePrompt = True
            If (saveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
                Dim tasksToExport As New List(Of TaskModel)

                Dim objects = If(exportSelected,
                                 DataListViewTasks.SelectedObjects,
                                 DataListViewTasks.Objects)

                For Each obj In objects
                    tasksToExport.Add(obj)
                Next
                Dim task As New TasksModel()
                task.Tasks = tasksToExport

                RaiseEvent Exporting(Me, New TaskExportingEventArgs(saveDialog.FileName, task))
            End If
        End Using
    End Sub

    Private Sub MenuItemExportSelected_Click(sender As Object, e As EventArgs) Handles MenuItemExportSelected.Click
        ExportTasks(True)
    End Sub

    Private Sub MenuItemExportAll_Click(sender As Object, e As EventArgs) Handles MenuItemExportAll.Click
        ExportTasks(False)
    End Sub

    Private Sub ButtonMoveUp_Click(sender As Object, e As EventArgs) Handles ButtonMoveUp.Click
        Dim position = actionsBindingSource.Position
        If (Not position = 0) Then
            Dim item = actionsBindingSource.Current
            actionsBindingSource.Remove(item)
            actionsBindingSource.Insert(position - 1, item)
            actionsBindingSource.Position = position - 1
        End If
    End Sub

    Private Sub ButtonMoveDown_Click(sender As Object, e As EventArgs) Handles ButtonMoveDown.Click
        Dim position = actionsBindingSource.Position
        If (position < actionsBindingSource.Count - 1) Then
            Dim item = actionsBindingSource.Current
            actionsBindingSource.Remove(item)
            actionsBindingSource.Insert(position + 1, item)
            actionsBindingSource.Position = position + 1
        End If
    End Sub

    Private Sub ButtonBrowseForFile_Click(sender As Object, e As EventArgs) Handles ButtonBrowseForFile.Click
        Using dialog As New OpenFileDialog
            If (dialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
                TextBoxCommand.Text = dialog.FileName
            End If
        End Using
    End Sub

    Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles ButtonOptions.Click
        ContextMenuExport.Show(ButtonOptions, New Point(0, ButtonOptions.Height))
    End Sub

    Private Sub TaskSettingsDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        taskToolTip.Dispose()
    End Sub

    Private Sub DialogTaskSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Initialize()
    End Sub

    Private Sub MenuItem1_Click(sender As Object, e As EventArgs) Handles MenuItemImport.Click
        Using openDialog As New OpenFileDialog
            openDialog.InitialDirectory = InitialDirectory
            openDialog.Filter = FileFilter
            openDialog.CheckFileExists = True
            If (openDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
                RaiseEvent Importing(Me, New TaskImportingEventArgs(openDialog.FileName, model))
                actionsBindingSource.ResetBindings(True)
            End If
        End Using
    End Sub
    Public Event Exporting As EventHandler(Of TaskExportingEventArgs)
    Public Event Importing As EventHandler(Of TaskImportingEventArgs)

    Private Sub SetStrings()
        Me.SuspendLayout()

        Me.OlvColumnName.Text = My.Resources.Strings.HeaderName
        Me.OlvColumnEvent.Text = My.Resources.Strings.HeaderEvent
        Me.OlvColumnCommand.Text = My.Resources.Strings.HeaderCommand
        Me.OlvColumnArguments.Text = My.Resources.Strings.HeaderArguments

        Me.OlvColumnName.Text = My.Resources.Strings.HeaderName
        Me.OlvColumnEvent.Text = My.Resources.Strings.HeaderEvent
        Me.OlvColumnCommand.Text = My.Resources.Strings.HeaderCommand
        Me.OlvColumnArguments.Text = My.Resources.Strings.HeaderArguments

        Me.MenuItemExportAll.Text = My.Resources.Strings.ExportAll
        Me.MenuItemExportSelected.Text = My.Resources.Strings.ExportSelected

        Me.LabelEvent.Text = My.Resources.Strings.LabelEvent
        Me.LabelName.Text = My.Resources.Strings.LabelName
        Me.LabelCommand.Text = My.Resources.Strings.LabelCommand
        Me.LabelArguments.Text = My.Resources.Strings.LabelArguments

        Me.ButtonOptions.Text = My.Resources.Strings.Options
        Me.MenuItemExportAll.Text = My.Resources.Strings.ExportAll
        Me.MenuItemExportSelected.Text = My.Resources.Strings.ExportSelected
        Me.MenuItemImport.Text = My.Resources.Strings.Import

        taskToolTip.SetToolTip(Me.ButtonAdd, My.Resources.Strings.Add)
        taskToolTip.SetToolTip(Me.ButtonRemove, My.Resources.Strings.Remove)
        taskToolTip.SetToolTip(Me.ButtonMoveUp, My.Resources.Strings.MoveUp)
        taskToolTip.SetToolTip(Me.ButtonMoveDown, My.Resources.Strings.MoveDown)
        taskToolTip.SetToolTip(Me.ButtonBrowseForFile, My.Resources.Strings.BrowseForFile)

        Me.ResumeLayout()
    End Sub

End Class
