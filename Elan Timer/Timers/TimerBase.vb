Namespace CodeIsle.Timers
    Public MustInherit Class TimerBase
        ' Holds duration (total time).
        Private _duration As TimeSpan
        ' Holds value telling if the timer is enabled.
        Private _enabled As Boolean
        ' Holds vale telling if the timer has expired.
        Private _isExpired As Boolean
        ' Used to cancel ExpilredPollAsync's loop.
        Private expiredCancellationTokenSource As System.Threading.CancellationTokenSource
        ' Stopwatch to hold elapsed time.
        Private timerStopwatch As Stopwatch
        ' Holds value of remaining time.
        Private _remaining As TimeSpan
        ' Holds restart count. Is decremented on each restart.
        Private restartCount As Integer
        ' Holders total restarts.
        Private _restarts As Integer
        ' Holds the time in milliseconds to poll for expiration.
        Private _expirationPollRate As Integer = 1
#Region "Events"
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
            expiredCancellationTokenSource = New Threading.CancellationTokenSource
            Task.Factory.StartNew(Sub() ExpiredPollAsync(expiredCancellationTokenSource.Token), expiredCancellationTokenSource.Token, TaskCreationOptions.LongRunning)
        End Sub
        ''' <summary>
        ''' Used to stop polling if the timer should be enabled.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub StopEnabledPoll()
            If expiredCancellationTokenSource IsNot Nothing Then
                expiredCancellationTokenSource.Cancel()
            End If
            Task.WaitAll()
        End Sub
        ''' <summary>
        ''' Provieds a set of methods and properties that you can use to accurately measure elapsed time.
        ''' </summary>
        ''' <param name="duration"></param>
        ''' <remarks></remarks>
        Sub New(duration As TimeSpan)
            _isExpired = False
            _duration = duration
            timerStopwatch = New Stopwatch
        End Sub
        ''' <summary>
        ''' Provieds a set of methods and properties that you can use to accurately measure elapsed time.
        ''' </summary>
        ''' <param name="duration"></param>
        ''' <remarks></remarks>
        Sub New(duration As TimeSpan, restarts As Integer)
            _isExpired = False
            _duration = duration
            MyClass.Restarts = restarts
            timerStopwatch = New Stopwatch
        End Sub
        ''' <summary>
        ''' Provieds a set of methods and properties that you can use to accurately measure elapsed time.
        ''' </summary>
        ''' <param name="duration"></param>
        ''' <param name="restarts"></param>
        ''' <param name="expirationPollRate"></param>
        ''' <remarks></remarks>
        Sub New(duration As TimeSpan, restarts As Integer, expirationPollRate As Integer)
            _isExpired = False
            _duration = duration
            MyClass.Restarts = restarts
            timerStopwatch = New Stopwatch
            _expirationPollRate = expirationPollRate
        End Sub

        ''' <summary>
        ''' Starts, or resumes, measuring elapsed time for an interval.
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Sub Start()
            If Not Enabled Then
                If Remaining.TotalMilliseconds > 0 Then
                    Enabled = True
                    timerStopwatch.Start()
                    OnStarted(Me, New TimerEventArgs(Current, _duration))
                    StartEnabledPoll()
                End If
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
            OnExpired(Me, New TimerEventArgs(Current, Duration))
        End Sub
        ''' <summary>
        ''' Stops measuring elapsed time for an interval.
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Sub Pause()
            _enabled = False
            StopEnabledPoll()
            timerStopwatch.Stop()
            OnPaused(Me, New TimerEventArgs(Current, _duration))
        End Sub
        ''' <summary>
        ''' Gets the value indicating if the tiner is paused.
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
        ''' Gets the value indicating if the timer is expired.
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
            StopEnabledPoll()
            timerStopwatch.Reset()
            _enabled = False
            _isExpired = False
            restartCount = MyClass.Restarts
        End Sub
        ''' <summary>
        ''' Stops the timer, resets the elapsed time to zero, and sets duration.
        ''' </summary>
        ''' <param name="duration"></param>
        ''' <remarks></remarks>
        Public Overridable Sub Reset(duration As TimeSpan)
            Me.Reset()
            _duration = duration
        End Sub

        ''' <summary>
        ''' Stops the timer, resets the elapsed time to zero, and starts the timer.
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Sub Restart()
            StopEnabledPoll()
            StartEnabledPoll()
            timerStopwatch.Restart()
            OnRestarted(Me, New TimerEventArgs(Current, _duration))
        End Sub
        Public Overridable Property Restarts As Integer
            Get
                Return _restarts
            End Get
            Set(value As Integer)
                _restarts = value
                restartCount = _restarts
            End Set
        End Property
        ''' <summary>
        ''' Gets the value indicating whether the timer is running.
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
        Public Overridable ReadOnly Property Elapsed
            Get
                If timerStopwatch.Elapsed > Duration Then
                    Return Duration
                End If
                Return timerStopwatch.Elapsed
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

                If Duration < Elapsed Then
                    Return New TimeSpan()
                End If
                Return Duration - Elapsed
            End Get
        End Property
        ''' <summary>
        ''' Gets the current display time measured by the current instance.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public MustOverride ReadOnly Property Current As TimeSpan
        ''' <summary>
        ''' Polls whether the timer has expired.
        ''' </summary>
        ''' <param name="token"></param>
        ''' <remarks></remarks>
        Private Async Sub ExpiredPollAsync(token As Threading.CancellationToken)
            While Not token.IsCancellationRequested Or Enabled
                Await TaskEx.Delay(_expirationPollRate)
                If Remaining.TotalMilliseconds <= 0 Then
                    If restartCount > 0 Then
                        restartCount -= 1
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
