Public Class AlarmTimerInfo
    Private _timer As EggzleLib.CodeIsle.Timers.AlarmTimer
    Public Sub New(timer As EggzleLib.CodeIsle.Timers.AlarmTimer)
        _timer = timer
    End Sub
    Public ReadOnly Property Enabled As Boolean
        Get
            Return _timer.Enabled
        End Get
    End Property
    Public ReadOnly Property Duration As TimeSpan
        Get
            Return _timer.Duration
        End Get
    End Property
    Public ReadOnly Property Elapsed As TimeSpan
        Get
            Return _timer.Elapsed
        End Get
    End Property

    Public ReadOnly Property Remaining As TimeSpan
        Get
            Return _timer.Remaining
        End Get
    End Property
    Public ReadOnly Property Current As TimeSpan
        Get
            Return _timer.Current
        End Get
    End Property
    Public ReadOnly Property IsPaused As Boolean
        Get
            Return _timer.IsPaused
        End Get
    End Property
    Public ReadOnly Property IsExpired As Boolean
        Get
            Return _timer.IsExpired
        End Get
    End Property
End Class
