Namespace Information
    Public Interface ITimerInfo

        ReadOnly Property Enabled As Boolean

        ReadOnly Property Duration As TimeSpan

        ReadOnly Property Elapsed As TimeSpan

        ReadOnly Property Remaining As TimeSpan

        ReadOnly Property Current As TimeSpan

        ReadOnly Property IsPaused As Boolean

        ReadOnly Property IsExpired As Boolean
    End Interface
End Namespace
