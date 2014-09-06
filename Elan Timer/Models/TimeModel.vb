Imports PropertyChanged
<ImplementPropertyChanged>
Public Class TimeModel
    Public Property Duration As TimeSpan

    Public Property CountUp As Boolean

    Public Property Restarts As Integer

    Public Property AlarmEnabled As Boolean

    Public Property AlarmName As String

    Public Property AlarmLoop As Boolean

    Public Property AlarmVolume As Integer

    Public Property Note As String

    Public Property AlertEnabled As Boolean
    Sub New()
    End Sub
End Class
