Imports System.Windows.Forms
Imports ElanTimer.Prefs.Models
Imports ElanTimer.Prefs
Public Class DialogTaskSettings

    Private actionsData As List(Of TaskModel)
    Private actionsBindingSource As BindingSource
    Public Sub UpdateStates(sender As Object, e As EventArgs)
        Dim enabled As Boolean = (DataListViewActions.SelectedObjects.Count = 1)
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

        ButtonRemove.Enabled = (DataListViewActions.SelectedObjects.Count > 0)
        ButtonExport.Enabled = (DataListViewActions.GetItemCount > 0)
        MenuItemExportSelected.Enabled = (Not DataListViewActions.SelectedIndices.Count = 0)
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
        actionsData = CloneActions(Preferences.Tasks.Tasks)

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

        Preferences.Tasks.Tasks.Clear()
        Preferences.Tasks.Tasks.AddRange(actionsData)
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
                saveDialog.InitialDirectory = Preferences.TasksPath
                saveDialog.Filter = My.Settings.TaskDialogFilter
                saveDialog.OverwritePrompt = True
                If saveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Dim taskSetings As New Prefs.TaskPreferences()
                    Dim tasksToExport As New List(Of Prefs.Models.TaskModel)
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
                openDialog.InitialDirectory = Preferences.TasksPath
                openDialog.Filter = My.Settings.TaskDialogFilter
                openDialog.CheckFileExists = True
                If openDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Dim taskSetings As New Prefs.TaskPreferences()
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
End Class
