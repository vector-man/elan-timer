Namespace CodeIsle.Timers
    Public Class Stopwatch
        Private m_elapsed As Long
        Private startTimeStamp As Long
        Private m_isRunning As Boolean
        Public Shared ReadOnly Frequency As Long
        Public Shared ReadOnly IsHighResolution As Boolean
        Private Shared ReadOnly tickFrequency As Double
        Private Const TicksPerMillisecond As Long = 10000L
        Private Const TicksPerSecond As Long = 10000000L

        Public ReadOnly Property IsRunning() As Boolean
            Get
                Return Me.m_isRunning
            End Get
        End Property


        Public ReadOnly Property Elapsed() As TimeSpan
            Get
                Return New TimeSpan(Me.GetElapsedDateTimeTicks())
            End Get
        End Property


        Public ReadOnly Property ElapsedMilliseconds() As Long
            Get
                Return Me.GetElapsedDateTimeTicks() \ 10000L
            End Get
        End Property


        Public ReadOnly Property ElapsedTicks() As Long
            Get
                Return Me.GetRawElapsedTicks()
            End Get
        End Property

        Shared Sub New()
            Stopwatch.IsHighResolution = False
            Stopwatch.Frequency = 10000000L
            Stopwatch.tickFrequency = 1.0
        End Sub


        Public Sub New()
            Me.Reset()
        End Sub


        Public Sub Start()
            If Me.m_isRunning Then
                Return
            End If
            Me.startTimeStamp = Stopwatch.GetTimestamp()
            Me.m_isRunning = True
        End Sub


        Public Shared Function StartNew() As Stopwatch
            Dim stopwatch As New Stopwatch()
            stopwatch.Start()
            Return stopwatch
        End Function

        Public Sub [Stop]()
            If Not Me.m_isRunning Then
                Return
            End If
            Me.m_elapsed += Stopwatch.GetTimestamp() - Me.startTimeStamp
            Me.m_isRunning = False
            If Me.m_elapsed >= 0L Then
                Return
            End If
            Me.m_elapsed = 0L
        End Sub


        Public Sub Reset()
            Me.m_elapsed = 0L
            Me.m_isRunning = False
            Me.startTimeStamp = 0L
        End Sub


        Public Sub Restart()
            Me.m_elapsed = 0L
            Me.startTimeStamp = Stopwatch.GetTimestamp()
            Me.m_isRunning = True
        End Sub


        Public Shared Function GetTimestamp() As Long
            Return DateTime.UtcNow.Ticks
        End Function

        Private Function GetRawElapsedTicks() As Long
            Dim num1 As Long = Me.m_elapsed
            If Me.m_isRunning Then
                Dim num2 As Long = Stopwatch.GetTimestamp() - Me.startTimeStamp
                num1 += num2
            End If
            Return num1
        End Function

        Private Function GetElapsedDateTimeTicks() As Long
            Dim rawElapsedTicks As Long = Me.GetRawElapsedTicks()
            Return rawElapsedTicks
        End Function
    End Class
End Namespace
