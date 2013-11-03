Namespace Information
    Public Class TimerInfo
        Implements EggzleLib.Information.ITimerInfo
        Private _timer As CodeIsle.Timers.TimerBase
        Public Sub New(timer As CodeIsle.Timers.TimerBase)
            _timer = timer
        End Sub
        Public ReadOnly Property Enabled As Boolean Implements EggzleLib.Information.ITimerInfo.Enabled
            Get
                Return _timer.Enabled
            End Get
        End Property
        Public ReadOnly Property Duration As TimeSpan Implements EggzleLib.Information.ITimerInfo.Duration
            Get
                Return _timer.Duration
            End Get
        End Property
        Public ReadOnly Property Elapsed As TimeSpan Implements EggzleLib.Information.ITimerInfo.Elapsed
            Get
                Return _timer.Elapsed
            End Get
        End Property

        Public ReadOnly Property Remaining As TimeSpan Implements EggzleLib.Information.ITimerInfo.Remaining
            Get
                Return _timer.Remaining
            End Get
        End Property
        Public ReadOnly Property Current As TimeSpan Implements EggzleLib.Information.ITimerInfo.Current
            Get
                Return _timer.Current
            End Get
        End Property
        Public ReadOnly Property IsPaused As Boolean Implements EggzleLib.Information.ITimerInfo.IsPaused
            Get
                Return _timer.IsPaused
            End Get
        End Property
        Public ReadOnly Property IsExpired As Boolean Implements EggzleLib.Information.ITimerInfo.IsExpired
            Get
                Return _timer.IsExpired
            End Get
        End Property
    End Class
End Namespace