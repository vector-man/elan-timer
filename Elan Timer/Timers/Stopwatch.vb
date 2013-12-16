Namespace CodeIsle.Timers
    Public Class Stopwatch
        Private startTimeStamp As Long
        Private _elapsed As Long
        Private _isRunning As Boolean
        Private _isReset As Boolean
        Sub New()
            Reset()
        End Sub
        Public ReadOnly Property Elapsed As TimeSpan
            Get
                Return New TimeSpan(Me.GetElapsedDateTimeTicks())
            End Get
        End Property

        Public ReadOnly Property ElapsedMilliseconds As Long
            Get
                Return Me.GetElapsedDateTimeTicks() / 10000L
            End Get
        End Property

        Public ReadOnly Property ElapsedTicks As Long
            Get
                Return GetRawElapsedTicks()
            End Get
        End Property
        Public ReadOnly Property IsRunning As Boolean
            Get
                Return _isRunning
            End Get
        End Property

        Public Function GetTimeStamp() As Long
            Return DateTime.UtcNow.Ticks
        End Function
        Public Sub Reset()
            _isRunning = False
            _isReset = True
            _elapsed = New TimeSpan(0)
        End Sub
        Public Sub Restart()
            [Stop]()
            Reset()
            Start()
        End Sub
        Public Sub Start()
            _isRunning = True
            _initial = DateTime.UtcNow
        End Sub
        Public Sub StartNew()
            Restart()
        End Sub
        Public Sub [Stop]()
            _isRunning = False
            _isReset = False
        End Sub
        Private Function GetRawElapsedTicks() As Long
            Dim num1 As Long = _elapsed
            If Me.IsRunning Then
                Dim num2 As Long = Me.GetTimeStamp() - Me.startTimeStamp
                num1 += num2
            End If
            Return num1
        End Function
        Private Function GetElapsedDateTimeTicks() As Long

        End Function
    End Class
End Namespace
