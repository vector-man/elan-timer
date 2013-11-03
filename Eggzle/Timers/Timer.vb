Namespace CodeIsle.Timers
    Public MustInherit Class Timer
        Private _duration As TimeSpan
        Private _enabled As Boolean
        Private enabledTask As task
        Private expiredCancellationTokenSource As System.Threading.CancellationTokenSource
        Private timerStopwatch As Stopwatch
#Region "Events"
        Public Event Started As EventHandler(Of TimerEventArgs)
        Public Event Stopped As EventHandler(Of TimerEventArgs)
        Public Event Expired As EventHandler(Of TimerEventArgs)

        Protected Sub OnStarted(sender As Object, e As TimerEventArgs)
            RaiseEvent Started(sender, e)
        End Sub
        Protected Sub OnStopped(sender As Object, e As TimerEventArgs)
            RaiseEvent Started(sender, e)
        End Sub
        Protected Sub OnExpired(sender As Object, e As TimerEventArgs)
            RaiseEvent Started(sender, e)
        End Sub
#End Region

        Private Sub StartEnabledTest()
            expiredCancellationTokenSource = New Threading.CancellationTokenSource
            Task.Run(Sub() ExpiredTestAsync(expiredCancellationTokenSource.Token), expiredCancellationTokenSource.Token)
        End Sub
        Private Sub StopEnabledTest()
            expiredCancellationTokenSource.Cancel()
        End Sub
        Sub New(duration As TimeSpan)
            _duration = duration
            expiredCancellationTokenSource = New Threading.CancellationTokenSource
        End Sub


        Public Overridable Sub Start()
            Enabled = True
            timerStopwatch.Start()
            RaiseEvent Started(Me, New TimerEventArgs(Current, _duration))
            StartEnabledTest()
        End Sub


        Public Overridable Sub [Stop]()
            _enabled = False
            StopEnabledTest()
            timerStopwatch.Stop()
            RaiseEvent Stopped(Me, New TimerEventArgs(Current, _duration))
        End Sub

        Public Overridable Sub Reset()
            StopEnabledTest()
            timerStopwatch.Reset()
        End Sub

        Public Overridable Sub Restart()
            _enabled = True
            StopEnabledTest()
            StartEnabledTest()
            timerStopwatch.Restart()
            RaiseEvent Stopped(Me, New TimerEventArgs(Current, _duration))
            RaiseEvent Started(Me, New TimerEventArgs(Current, _duration))
        End Sub


        Public Property Enabled As Boolean
            Get
                Return _enabled
            End Get
            Set(value As Boolean)
                _enabled = value
            End Set
        End Property


        Public Overridable ReadOnly Property Duration
            Get
                Return _duration
            End Get
        End Property

        Public MustOverride ReadOnly Property Elapsed

        Public MustOverride ReadOnly Property Remaining

        Public MustOverride ReadOnly Property Current As TimeSpan

        Private Async Sub ExpiredTestAsync(token As Threading.CancellationToken)
            While Enabled
                Await Task.Delay(10)
                If Remaining.TotalMilliseconds <= 0 Then
                    Me.Stop()
                    Enabled = False
                End If
                If token.IsCancellationRequested Then
                    Exit While
                End If
            End While
            RaiseEvent Expired(Me, New TimerEventArgs(Current, Duration))
        End Sub
    End Class
End Namespace
