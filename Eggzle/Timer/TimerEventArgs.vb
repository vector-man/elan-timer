Public Class TimerEventArgs
    Inherits EventArgs
    Private _currentTime As TimeSpan
    Private _totalTime As TimeSpan
    Sub New(currentTime As TimeSpan, totalTime As TimeSpan)

    End Sub
    Public ReadOnly Property CurrentTime As TimeSpan
        Get
            Return _currentTime
        End Get
    End Property
    Public ReadOnly Property TotalTime As TimeSpan
        Get
            Return _totalTime
        End Get
    End Property
End Class
