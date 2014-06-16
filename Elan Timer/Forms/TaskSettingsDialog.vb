Imports System.Windows.Forms
Imports System.IO

Public Class TaskSettingsDialog

    Private actionsData As List(Of TaskModel)
    Private actionsBindingSource As BindingSource
    Private _transporter As ITransporter = New JsonNetTransporter()
    Private _model As New TasksModel(_transporter)
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
    End Sub
    Private Property TasksPath As String
    Private Property TasksFilter As String
    Public Property Tasks As List(Of TaskModel)
        Get
            Return _model.Tasks
        End Get
        Set(value As List(Of TaskModel))
            _model.Tasks = value
        End Set
    End Property

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
    Private Sub Initialize()
        AddHandler Application.Idle, AddressOf UpdateStates
        If _model.Tasks Is Nothing Then
            _model.Tasks = New List(Of TaskModel)
        End If
        actionsBindingSource = New BindingSource()
        actionsBindingSource.DataSource = _model.Tasks

        ComboBoxEvent.DataSource = [Enum].GetValues(GetType(TimerEvent))
        ComboBoxEvent.DataBindings.Add("Text", actionsBindingSource, "Event", True, DataSourceUpdateMode.OnPropertyChanged)
        TextBoxName.DataBindings.Add("Text", actionsBindingSource, "Name", True, DataSourceUpdateMode.OnPropertyChanged)
        TextBoxCommand.DataBindings.Add("Text", actionsBindingSource, "Command", True, DataSourceUpdateMode.OnPropertyChanged)
        TextBoxArguments.DataBindings.Add("Text", actionsBindingSource, "Arguments", True, DataSourceUpdateMode.OnPropertyChanged)

        DataListViewActions.DataSource = actionsBindingSource
    End Sub

    Private Sub ExportTasks(Optional exportSelected As Boolean = False)
        Try
            Using saveDialog As New SaveFileDialog
                saveDialog.InitialDirectory = TasksPath
                saveDialog.Filter = TasksFilter
                saveDialog.OverwritePrompt = True
                If saveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Dim tasksToExport As New List(Of TaskModel)
                    Dim objects
                    If exportSelected Then
                        objects = DataListViewActions.SelectedObjects
                    Else
                        objects = DataListViewActions.Objects
                    End If

                    For Each obj In objects
                        tasksToExport.Add(obj)
                    Next
                    Dim tsk As New TasksModel(_transporter)
                    tsk.Tasks = tasksToExport
                    Using output As FileStream = File.Create(saveDialog.FileName)
                        tsk.Export(output)
                    End Using
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

    Private Sub ButtonImport_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles ButtonExport.Click
        ContextMenuExport.Show(ButtonExport, New Point(0, ButtonExport.Height))
    End Sub

    Private Sub DialogTaskSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Add any initialization after the InitializeComponent() call
        Initialize()
    End Sub

    Private Sub MenuItem1_Click(sender As Object, e As EventArgs) Handles MenuItem1.Click
        Try
            Using openDialog As New OpenFileDialog
                openDialog.InitialDirectory = TasksPath
                openDialog.Filter = TasksFilter
                openDialog.CheckFileExists = True
                If (openDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
                    Using input As FileStream = File.OpenRead(openDialog.FileName)
                        _model.Import(input)
                    End Using
                    'actionsBindingSource.Clear()
                    actionsBindingSource.ResetBindings(True)
                    'For Each t In _model.Tasks
                    '    actionsBindingSource.Add(t)
                    'Next
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName)
        End Try
    End Sub
End Class
