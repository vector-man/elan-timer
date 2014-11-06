Imports PropertyChanged
<ImplementPropertyChanged>
Public Class TimeModel
    Public Property Duration As TimeSpan

    Public Property CountUp As Boolean

    Public Property Restarts As Integer
    Implements ICloneable

    Public Property AlarmEnabled As Boolean

    Public Property AlarmName As String

    Public Property AlarmLoop As Boolean

    Public Property AlarmVolume As Integer

    Public Property Note As String

    Public Property AlertEnabled As Boolean
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
