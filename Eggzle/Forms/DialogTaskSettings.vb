Imports System.Windows.Forms
Imports Eggzle.Settings.Models
Imports Mono.Addins
Public Class DialogTaskSettings

    Private actionsData As List(Of TaskModel)
    Private actionsBindingSource As BindingSource
    Public Sub UpdateStates(sender As Object, e As EventArgs)
        TableLayoutPanelActions.Enabled = (DataListViewActions.SelectedObjects.Count = 1)
        ButtonRemove.Enabled = (DataListViewActions.SelectedObjects.Count > 0)
    End Sub
    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        actionsBindingSource.Add(New TaskModel(TimerEvent.Started, "New Action", "", "", False, "", True))
    End Sub

    Private Sub ButtonRemove_Click(sender As Object, e As EventArgs) Handles ButtonRemove.Click
        Dim selectedObjects = DataListViewActions.SelectedObjects

        For Each obj In selectedObjects
            actionsBindingSource.Remove(obj)
        Next
    End Sub

    Private Function CloneActions(actions As List(Of TaskModel))
        Return actions.ConvertAll(Function(action) New TaskModel(action.Event, action.Name, action.Command, action.Arguments, action.UseScript, action.Script, action.Enabled))
    End Function
    Private Sub LoadSettings()
        actionsData = CloneActions(Common.Tasks.Tasks)

        actionsBindingSource = New BindingSource()
        actionsBindingSource.DataSource = actionsData

        ComboBoxEvent.DataBindings.Clear()
        TextBoxName.DataBindings.Clear()
        TextBoxCommand.DataBindings.Clear()
        TextBoxArguments.DataBindings.Clear()


        ComboBoxEvent.DataSource = [Enum].GetValues(GetType(TimerEvent))
        ComboBoxEvent.DataBindings.Add("Text", actionsBindingSource, "Event", True, DataSourceUpdateMode.OnPropertyChanged)
        TextBoxName.DataBindings.Add("Text", actionsBindingSource, "Name", True, DataSourceUpdateMode.OnPropertyChanged)
        TextBoxCommand.DataBindings.Add("Text", actionsBindingSource, "Command", True, DataSourceUpdateMode.OnPropertyChanged)
        TextBoxArguments.DataBindings.Add("Text", actionsBindingSource, "Arguments", True, DataSourceUpdateMode.OnPropertyChanged)


        DataListViewActions.DataSource = actionsBindingSource


    End Sub
    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        Common.Tasks.Tasks.Clear()
        Common.Tasks.Tasks.AddRange(actionsData)
        actionsData = Nothing
        actionsBindingSource.Dispose()

    End Sub

    Private Sub DialogTaskSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler Application.Idle, AddressOf UpdateStates
        LoadSettings()
    End Sub

 
    Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles ButtonExport.Click
        ContextMenuExport.Show(ButtonExport, New Point(0, ButtonExport.Height))
    End Sub

    Private Sub ExportTasks(Optional exportSelected As Boolean = False)
        Try
            Using saveDialog As New SaveFileDialog
                saveDialog.InitialDirectory = Common.TasksPath
                saveDialog.Filter = My.Settings.TaskDialogFilter
                saveDialog.OverwritePrompt = True
                If saveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Dim taskSetings As New Settings.TaskSettings()
                    Dim tasksToExport As New List(Of Settings.Models.TaskModel)
                    Dim objects As Object = Nothing
                    If exportSelected Then
                        objects = DataListViewActions.SelectedObjects
                    Else
                        objects = DataListViewActions.Objects
                    End If

                    For Each task In objects
                        tasksToExport.Add(task)
                    Next
                    taskSetings.Tasks = tasksToExport
                    taskSetings.ExportTo(saveDialog.FileName)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
        End Try
    End Sub
    Private Sub ButtonImport_Click(sender As Object, e As EventArgs) Handles ButtonImport.Click
        Try
            Using openDialog As New OpenFileDialog
                openDialog.InitialDirectory = Common.TasksPath
                openDialog.Filter = My.Settings.TaskDialogFilter
                openDialog.CheckFileExists = True
                If openDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Dim taskSetings As New Settings.TaskSettings()
                    taskSetings.ImportFrom(openDialog.FileName)
                    For Each item In taskSetings.Tasks
                        actionsBindingSource.Add(item)
                    Next
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
        End Try
    End Sub

    Private Sub MenuItemExportSelected_Click(sender As Object, e As EventArgs) Handles MenuItemExportSelected.Click
        ExportTasks(True)
    End Sub

    Private Sub MenuItemExportAll_Click(sender As Object, e As EventArgs) Handles MenuItemExportAll.Click
        ExportTasks(False)
    End Sub
End Class
