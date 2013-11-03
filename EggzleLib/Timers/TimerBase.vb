Namespace CodeIsle.Timers
    Public MustInherit Class TimerBase
        Private _duration As TimeSpan
        Private _enabled As Boolean
        Private _isExpired As Boolean
        Private expiredCancellationTokenSource As System.Threading.CancellationTokenSource
        Private timerStopwatch As Stopwatch
        Private _remaining As TimeSpan
#Region "Events"
        Public Event Started As EventHandler(Of TimerEventArgs)
        Public Event Paused As EventHandler(Of TimerEventArgs)
        Public Event Restarted As EventHandler(Of TimerEventArgs)
        Public Event Expired As EventHandler(Of TimerEventArgs)

        Protected Sub OnStarted(sender As Object, e As TimerEventArgs)
            _isExpired = False
            RaiseEvent Started(sender, e)
        End Sub
        Protected Sub OnPaused(sender As Object, e As TimerEventArgs)
            RaiseEvent Paused(sender, e)
        End Sub
        Protected Sub OnExpired(sender As Object, e As TimerEventArgs)
            _isExpired = True
            _enabled = False
            RaiseEvent Expired(sender, e)
        End Sub
        Protected Sub OnRestarted(sender As Object, e As TimerEventArgs)
            _isExpired = False
            _enabled = True
            RaiseEvent Restarted(sender, e)
        End Sub
#End Region

        Private Sub StartEnabledTest()
            expiredCancellationTokenSource = New Threading.CancellationTokenSource
            Task.Run(Sub() ExpiredTestAsync(expiredCancellationTokenSource.Token), expiredCancellationTokenSource.Token)
        End Sub
        Private Sub StopEnabledTest()
            If expiredCancellationTokenSource IsNot Nothing Then
                expiredCancellationTokenSource.Cancel()
            End If
        End Sub
        Sub New(duration As TimeSpan)
            _isExpired = False
            _duration = duration
            timerStopwatch = New Stopwatch
        End Sub


        Public Overridable Sub Start()
            If Remaining.TotalMilliseconds > 0 Then
                Enabled = True
                timerStopwatch.Start()
                OnStarted(Me, New TimerEventArgs(Current, _duration))
                StartEnabledTest()
            End If
        End Sub

        Private Sub Expire()
            _enabled = False
            StopEnabledTest()
            timerStopwatch.Stop()
        End Sub
        Public Overridable Sub Pause()
            _enabled = False
            StopEnabledTest()
            timerStopwatch.Stop()
            OnPaused(Me, New TimerEventArgs(Current, _duration))
        End Sub
        Public Overridable ReadOnly Property IsPaused
            Get
                Return Not Enabled
            End Get
        End Property
        Public Overridable ReadOnly Property IsExpired As Boolean
            Get
                Return _isExpired
            End Get
        End Property

        Public Overridable Sub Reset()
            StopEnabledTest()
            timerStopwatch.Reset()
            _enabled = False
            _isExpired = False
        End Sub

        Public Overridable Sub Restart()
            StopEnabledTest()
            StartEnabledTest()
            timerStopwatch.Restart()
            OnRestarted(Me, New TimerEventArgs(Current, _duration))
        End Sub


        Public Property Enabled As Boolean
            Get
                Return _enabled
            End Get
            Set(value As Boolean)
                _enabled = value
                If (_enabled) Then
                    If (Not timerStopwatch.IsRunning) Then
                        timerStopwatch.Start()
                    End If
                Else
                    If (timerStopwatch.IsRunning) Then
                        timerStopwatch.Stop()
                    End If
                End If
            End Set
        End Property


        Public Overridable ReadOnly Property Duration As TimeSpan
            Get
                Return _duration
            End Get
        End Property

        Public Overridable ReadOnly Property Elapsed
            Get
                If timerStopwatch.Elapsed > Duration Then
                    Return Duration
                End If
                Return timerStopwatch.Elapsed
            End Get
        End Property


        Public Overridable ReadOnly Property Remaining As TimeSpan
            Get

                If Duration < Elapsed Then
                    Return New TimeSpan()
                End If
                Return Duration - Elapsed
            End Get
        End Property

        Public MustOverride ReadOnly Property Current As TimeSpan

        Private Async Sub ExpiredTestAsync(token As Threading.CancellationToken)
            While Enabled
                Await Task.Delay(10)
                If Remaining.TotalMilliseconds <= 0 Then
                    Me.Expire()
                    OnExpired(Me, New TimerEventArgs(Current, Duration))
                End If
                If token.IsCancellationRequested Then
                    Exit While
                End If
            End While
        End Sub
    End Class
End Namespace
