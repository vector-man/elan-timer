Imports PropertyChanged
<ImplementPropertyChanged>
Public Class TasksModel
    Implements ICloneable
    Public Property Tasks As List(Of TaskModel)
    Sub New()

    End Sub
    Public Sub New(tasks As List(Of TaskModel))
        Me.Tasks = tasks
    End Sub

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Tasks.ConvertAll(Of TaskModel)(Function(t)
                                                  Return New TaskModel() With {.Name = t.Name,
                                                                               .Event = t.Event,
                                                                               .Command = t.Command,
                                                                               .Arguments = t.Arguments,
                                                                               .Enabled = t.Enabled}
                                              End Function)
    End Function
End Class
