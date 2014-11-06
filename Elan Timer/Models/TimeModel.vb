Imports PropertyChanged
<ImplementPropertyChanged>
Public Class TimeModel
    Implements ICloneable

    Public Property Duration As TimeSpan

    Public Property CountUpwards As Boolean

    Public Property Note As String

    Public Property Restarts As Integer

    Public Property Synchronize As Boolean

    Sub New()
    End Sub

    Public Function Clone() As Object Implements ICloneable.Clone
        Return New TimeModel() With {.CountUpwards = Me.CountUpwards,
                                     .Duration = New TimeSpan(Me.Duration.Ticks),
                                     .Note = Me.Note,
                                     .Restarts = Me.Restarts,
                                     .Synchronize = Me.Synchronize}
    End Function
End Class
