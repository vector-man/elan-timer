Namespace Settings
    Public Class TaskSettings : Implements ISettings

        Private _tasks As List(Of Models.TaskModel)
        Private backupTasks As List(Of Models.TaskModel)
        Private jsonDatabase As JsonDatabase
        Private _path As String
        Sub New()
            jsonDatabase = New JsonDatabase
        End Sub
        Sub New(path As String, Optional defaultModel As List(Of Models.TaskModel) = Nothing, Optional load As Boolean = True)
            MyClass.New()
            _path = path
            If load Then
                MyClass.Load()
            End If
            If Tasks Is Nothing Then
                If defaultModel Is Nothing Then
                    Tasks = New List(Of Models.TaskModel)
                Else
                    _tasks = defaultModel
                End If
            End If
        End Sub

        Public Property Tasks As List(Of Models.TaskModel)
            Get
                Return _tasks
            End Get
            Set(value As List(Of Models.TaskModel))
                _tasks = value
            End Set
        End Property

        Public Sub ExportTo(path As String) Implements ISettings.ExportTo
            jsonDatabase.Save(path, _tasks)
        End Sub

        Public Sub ImportFrom(path As String) Implements ISettings.ImportFrom
            Dim data As List(Of Models.TaskModel) = jsonDatabase.Load(path, GetType(List(Of Models.TaskModel)))
            If data IsNot Nothing Then
                If _tasks Is Nothing Then
                    _tasks = New List(Of Models.TaskModel)
                End If
                _tasks.AddRange(data)
            End If
        End Sub

        Public Sub Load() Implements ISettings.Load
            Dim data As List(Of Models.TaskModel) = jsonDatabase.Load(_path, GetType(List(Of Models.TaskModel)))
            If data IsNot Nothing Then
                If _tasks Is Nothing Then
                    _tasks = New List(Of Models.TaskModel)
                End If
                _tasks.Clear()
                _tasks.AddRange(data)
            End If
        End Sub

        Public Sub Save() Implements ISettings.Save
            ExportTo(_path)
        End Sub

        Private Function Clone(tasks As List(Of Models.TaskModel))
            Return tasks.ConvertAll(Function(item) New Models.TaskModel(item.Event, item.Name, item.Command, item.Arguments, item.UseScript, item.Script, item.Enabled))
        End Function

        Public Sub BeginEdit() Implements ISettings.BeginEdit
            backupTasks = Clone(_tasks)
        End Sub

        Public Sub CancelEdit() Implements ISettings.CancelEdit
            _tasks = Clone(backupTasks)
        End Sub

        Public Sub EndEdit() Implements ISettings.EndEdit
            backupTasks = Nothing
        End Sub
    End Class


End Namespace
