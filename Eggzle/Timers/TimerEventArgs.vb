Public Class TimerEventArgs
    Inherits EventArgs
    Private _currentTime As TimeSpan
    Private _duration As TimeSpan
    Sub New(currentTime As TimeSpan, duration As TimeSpan)

    End Sub
    Public ReadOnly Property CurrentTime As TimeSpan
        Get
            Return _currentTime
        End Get
    End Property
    Public ReadOnly Property Duration As TimeSpan
        Get
            Return _duration
        End Get
    End Property
End Class
