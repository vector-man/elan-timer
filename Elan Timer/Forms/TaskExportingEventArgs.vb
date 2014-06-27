Public Class TaskExportingEventArgs
    Inherits EventArgs
    Private _tasks As TasksModel
    Sub New(output As String, tasks As TasksModel)
        MyBase.New()
        _tasks = tasks
        Me.Output = output
    End Sub
    Public Property Output As String
    Public ReadOnly Property Tasks As TasksModel
        Get
            Return _tasks
        End Get
    End Property
End Class
