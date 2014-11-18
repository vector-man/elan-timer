Public Class TaskExportingEventArgs
    Inherits EventArgs
    Private _tasks As List(Of TaskModel)
    Sub New(output As String, tasks As List(Of TaskModel))
        MyBase.New()
        _tasks = tasks
        Me.Output = output
    End Sub
    Public Property Output As String
    Public ReadOnly Property Tasks As List(Of TaskModel)
        Get
            Return _tasks
        End Get
    End Property
End Class
