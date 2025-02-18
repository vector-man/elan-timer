﻿Namespace Prefs
    Public Class TaskPreferences : Implements IPreferences

        Private _tasks As List(Of Models.TaskModel)
        Private backupTasks As List(Of Models.TaskModel)
        Private jsonDatabase As JsonDatabase
        Private _path As String
        Sub New()
            jsonDatabase = New JsonDatabase
        End Sub
        Sub New(path As String, defaultModel As List(Of Models.TaskModel), load As Boolean, disable As Boolean)
            MyClass.New()
            _path = path
            If load Then
                MyClass.Load()
            End If
            If (_tasks Is Nothing) Then
                _tasks = defaultModel
            End If
            If (disable) Then
                For Each item In _tasks
                    item.Enabled = False
                Next
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

        Public Sub ExportTo(path As String) Implements IPreferences.ExportTo
            jsonDatabase.Save(path, _tasks)
        End Sub

        Public Sub ImportFrom(path As String) Implements IPreferences.ImportFrom
            Dim data As List(Of Models.TaskModel) = jsonDatabase.Load(path, GetType(List(Of Models.TaskModel)))
            If data IsNot Nothing Then
                If _tasks Is Nothing Then
                    _tasks = New List(Of Models.TaskModel)
                End If
                _tasks.AddRange(data)
            End If
        End Sub

        Public Sub Load() Implements IPreferences.Load
            Dim data As List(Of Models.TaskModel) = jsonDatabase.Load(_path, GetType(List(Of Models.TaskModel)))
            If data IsNot Nothing Then
                If _tasks Is Nothing Then
                    _tasks = New List(Of Models.TaskModel)
                End If
                _tasks.Clear()
                _tasks.AddRange(data)
            End If
        End Sub

        Public Sub Save() Implements IPreferences.Save
            ExportTo(_path)
        End Sub

        Private Function Clone(tasks As List(Of Models.TaskModel))
            Return tasks.ConvertAll(Function(item) New Models.TaskModel(item.Event, item.Name, item.Command, item.Arguments, item.UseScript, item.Script, item.Enabled))
        End Function

        Public Sub BeginEdit() Implements IPreferences.BeginEdit
            backupTasks = Clone(_tasks)
        End Sub

        Public Sub CancelEdit() Implements IPreferences.CancelEdit
            _tasks = Clone(backupTasks)
        End Sub

        Public Sub EndEdit() Implements IPreferences.EndEdit
            backupTasks = Nothing
        End Sub
    End Class


End Namespace
