Public Class TaskImportingEventArgs
    Inherits EventArgs
    Sub New(input As String, tasks As List(Of TaskModel))
        MyBase.New()
        Me.Tasks = tasks
        Me.Input = input
    End Sub
    Public Property Input As String
    Public Property Tasks As List(Of TaskModel)
End Class

