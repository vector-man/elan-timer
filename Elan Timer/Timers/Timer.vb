Namespace CodeIsle.Timers
    Public MustInherit Class TimerBase
        ' Holds duration (total time).
        Private _duration As TimeSpan
        ' Holds value telling if the timer is enabled.
        Private _enabled As Boolean
        ' Holds vale telling if the timer has expired.
        Private _isExpired As Boolean
        ''' <summary>
        ''' Cancels ExpilredPollAsync loop.
        ''' </summary>
        ''' <remarks></remarks>
        Private expiredCancellationTokenSource As System.Threading.CancellationTokenSource
        ''' <summary>
        ''' Stopwatch that keeops track of the elapsed time.
        ''' </summary>
        ''' <remarks></remarks>
        Private timerStopwatch As Stopwatch
        ''' <summary>
        ''' Value of remaining time.
        ''' </summary>
        ''' <remarks></remarks>
        Private _remaining As TimeSpan
        ''' <summary>
        ''' Number of remaining restarts before timer expiration.
        ''' </summary>
        ''' <remarks></remarks>
        Private _remainingRestarts As Integer
        ''' <summary>
        ''' Total restarts before timer expiration.
        ''' </summary>
        ''' <remarks></remarks>
        Private _restarts As Integer
#Region "Events"
        Dim _elapsed As TimeSpan

        ''' <summary>
        ''' Event fires when the timer is started.
        ''' </summary>
        ''' <remarks></remarks>
        Public Event Started As EventHandler(Of TimerEventArgs)
        ''' <summary>
        ''' Event fires when the timer is paused.
        ''' </summary>
        ''' <remarks></remarks>
        Public Event Paused As EventHandler(Of TimerEventArgs)
        ''' <summary>
        ''' Event fires when the timer is restarted.
        ''' </summary>
        ''' <remarks></remarks>
        Public Event Restarted As EventHandler(Of TimerEventArgs)
        ''' <summary>
        ''' Event fires when the timer is expired.
        ''' </summary>
        ''' <remarks></remarks>
        Public Event Expired As EventHandler(Of TimerEventArgs)
        ''' <summary>
        ''' Raises started event.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub OnStarted(sender As Object, e As TimerEventArgs)
            _isExpired = False
            RaiseEvent Started(sender, e)
        End Sub
        ''' <summary>
        ''' Raises paused event.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub OnPaused(sender As Object, e As TimerEventArgs)
            RaiseEvent Paused(sender, e)
        End Sub
        ''' <summary>
        ''' Raises expired event.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub OnExpired(sender As Object, e As TimerEventArgs)
            _isExpired = True
            _enabled = False
            RaiseEvent Expired(sender, e)
        End Sub
        ''' <summary>
        ''' Raises restarted event.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub OnRestarted(sender As Object, e As TimerEventArgs)
            _isExpired = False
            _enabled = True
            RaiseEvent Restarted(sender, e)
        End Sub
#End Region
        ''' <summary>
        ''' Used to start polling if the timer should be disabled.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub StartEnabledPoll()
            If (expiredCancellationTokenSource IsNot Nothing) Then
                expiredCancellationTokenSource.Dispose()
            End If
            expiredCancellationTokenSource = New Threading.CancellationTokenSource
            Task.Factory.StartNew(Sub() ExpiredPoll(expiredCancellationTokenSource.Token), expiredCancellationTokenSource.Token, TaskCreationOptions.LongRunning)
        End Sub
        ''' <summary>
        ''' Used to stop polling if the timer should be enabled.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub StopEnabledPoll()
            If (expiredCancellationTokenSource IsNot Nothing) Then
                expiredCancellationTokenSource.Cancel()
            End If
            Task.WaitAll()
        End Sub
        ''' <summary>
        ''' Provieds a set of methods and properties that you can use to accurately measure elapsed time.
        ''' </summary>
        ''' <param name="duration">The duration.</param>
        ''' <remarks></remarks>
        Sub New(duration As TimeSpan)
            Me.New(duration, TimeSpan.Zero)
        End Sub
        ''' <summary>
        ''' Provieds a set of methods and properties that you can use to accurately measure elapsed time.
        ''' </summary>
        ''' <param name="duration">The duration.</param>
        ''' <param name="elapsed">The elapsed time.</param>
        ''' <param name="restarts">The number of restarts.</param>
        ''' <remarks></remarks>
        Sub New(duration As TimeSpan, elapsed As TimeSpan)
            Me.New(duration, elapsed, 0)
        End Sub
        ''' <summary>
        ''' Provieds a set of methods and properties that you can use to accurately measure elapsed time.
        ''' </summary>
        ''' <param name="duration">The duration.</param>
        ''' <param name="elapsed">The elapsed time.</param>
        ''' <param name="restarts">The number of restarts.</param>
        ''' <remarks></remarks>
        Sub New(duration As TimeSpan, elapsed As TimeSpan, restarts As Integer)
            timerStopwatch = New Stopwatch()
            Reset(duration, elapsed, restarts)
        End Sub
        ''' <summary>
        ''' Controls the poll rate for timer expiration in milliseconds.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property ExpirationPollRate As Integer = 10
        ''' <summary>
        ''' Starts or resumes measuring elapsed time for an interval.
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Sub Start()
            If (Not Enabled) Then
                Enabled = True
                timerStopwatch.Start()
                OnStarted(Me, New TimerEventArgs(Elapsed, Duration))
                StartEnabledPoll()
            End If
        End Sub
        ''' <summary>
        ''' Expires the timer.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Expire()
            _enabled = False
            StopEnabledPoll()
            timerStopwatch.Stop()
            OnExpired(Me, New TimerEventArgs(Elapsed, Duration))
        End Sub
        ''' <summary>
        ''' Stops measuring elapsed time for an interval.
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Sub Pause()
            _enabled = False
            StopEnabledPoll()
            timerStopwatch.Stop()
            OnPaused(Me, New TimerEventArgs(Elapsed, Duration))
        End Sub
        ''' <summary>
        ''' Gets a value indicating whether the timer is paused.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable ReadOnly Property IsPaused
            Get
                Return Not Enabled
            End Get
        End Property
        ''' <summary>
        ''' Gets a value indicating whether the timer is expired.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable ReadOnly Property IsExpired As Boolean
            Get
                Return _isExpired
            End Get
        End Property
        ''' <summary>
        ''' Stops the timer and resets the elapsed time to zero.
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Sub Reset()
            Me.Reset(_duration)
        End Sub
        ''' <summary>
        ''' Stops the timer, resets the elapsed time to zero, and sets duration.
        ''' </summary>
        ''' <param name="duration"></param>
        ''' <remarks></remarks>
        Public Overridable Sub Reset(duration As TimeSpan)
            Me.Reset(duration, TimeSpan.Zero)
        End Sub
        ''' <summary>
        ''' Stops the timer, then sets the duration and elapsed time.
        ''' </summary>
        ''' <param name="duration">The duration.</param>
        ''' <param name="elapsed">The elapsed time.</param>
        ''' <remarks></remarks>
        Public Overridable Sub Reset(duration As TimeSpan, elapsed As TimeSpan)
            Me.Reset(duration, elapsed, 0)
        End Sub

        Public Overridable Sub Reset(duration As TimeSpan, elapsed As TimeSpan, restarts As Integer)
            _duration = duration
            _elapsed = elapsed
            _restarts = restarts
            _remainingRestarts = _restarts

            If (_elapsed > _duration AndAlso _restarts > 0) Then
                _remainingRestarts -= Math.Floor(_elapsed.Ticks / _duration.Ticks)
                If (_remainingRestarts < 0) Then
                    _remainingRestarts = 0
                    _elapsed = _duration
                Else
                    _elapsed = TimeSpan.FromTicks(_elapsed.Ticks Mod _duration.Ticks)
                End If
            End If

            StopEnabledPoll()
            timerStopwatch.Reset()
            _enabled = False
            _isExpired = False
        End Sub

        ''' <summary>
        ''' Stops the timer, resets the elapsed time to zero, and starts the timer.
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Sub Restart()
            Me.timerStopwatch.Reset()
            _elapsed = TimeSpan.Zero
            StartEnabledPoll()
            timerStopwatch.Start()

            OnRestarted(Me, New TimerEventArgs(Elapsed, Duration))
        End Sub

        ''' <summary>
        ''' Gets a value indicating whether the timer is enabled.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
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
        ''' <summary>
        ''' Gets the duration measured by the current instance.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable ReadOnly Property Duration As TimeSpan
            Get
                Return _duration
            End Get
        End Property
        ''' <summary>
        ''' Gets the total elapsed time measured by the current instance.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable ReadOnly Property Elapsed As TimeSpan
            Get
                Dim current As TimeSpan = timerStopwatch.Elapsed + _elapsed

                If (current > Duration) Then
                    Return Duration
                Else
                    Return current
                End If
            End Get
        End Property
        ''' <summary>
        ''' Gets the remaining time measured by the current instance.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable ReadOnly Property Remaining As TimeSpan
            Get
                If (Duration < Elapsed) Then
                    Return New TimeSpan()
                End If
                Return Duration - Elapsed
            End Get
        End Property
        ''' <summary>
        ''' Total restarts before timer expiration.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Restarts
            Get
                Return _restarts
            End Get
        End Property
        Public ReadOnly Property ElapsedRestarts As Integer
            Get
                If (Restarts > 0) Then
                    Return Restarts - RemainingRestarts
                Else
                    Return 0
                End If
            End Get
        End Property
        ''' <summary>
        ''' Number of remaining restarts before timer expiration.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property RemainingRestarts As Integer
            Get
                Return _remainingRestarts
            End Get
        End Property
        ''' <summary>
        ''' Polls whether the timer has expired.
        ''' </summary>
        ''' <param name="token">The cancellation token.</param>
        ''' <remarks></remarks>
        Private Sub ExpiredPoll(token As Threading.CancellationToken)
            While Not token.IsCancellationRequested Or Enabled
                Threading.Thread.Sleep(_expirationPollRate)
                If (Remaining.TotalMilliseconds <= 0) Then
                    If (_remainingRestarts > 0) Then
                        _remainingRestarts -= 1
                        Restart()
                        Exit Sub
                    Else
                        Me.Expire()
                    End If
                End If
            End While
        End Sub
    End Class
End Namespace
