Imports NLog
Namespace CodeIsle.Timers
    Public Class AlarmTimer
        Inherits TimerBase
        Implements IDisposable

        Private _enabled As Boolean
        Private _alarm As Sound
        Private _alarmEnabled As Boolean

        ' Logging.
        Private logger As Logger = LogManager.GetCurrentClassLogger()
        ''' <summary>
        ''' Provieds a set of methods and properties that you can use to accurately measure elapsed time with an alarm.
        ''' </summary>
        ''' <param name="duration"></param>
        ''' <remarks></remarks>
        Sub New(duration As TimeSpan)
            Me.New(duration, TimeSpan.Zero, Nothing, False)
        End Sub
        ''' <summary>
        ''' Provieds a set of methods and properties that you can use to accurately measure elapsed time with an alarm.
        ''' </summary>
        ''' <param name="duration"></param>
        ''' <param name="elapsed"></param>
        ''' <remarks></remarks>
        Sub New(duration As TimeSpan, elapsed As TimeSpan)
            Me.New(duration, elapsed, Nothing, False)
        End Sub
        ''' <summary>
        ''' Provieds a set of methods and properties that you can use to accurately measure elapsed time with an alarm.
        ''' </summary>
        ''' <param name="duration">The duration.</param>
        ''' <param name="elapsed">The elapsed time.</param>
        ''' <param name="alarm">The alarm.</param>
        ''' <remarks></remarks>
        Sub New(duration As TimeSpan, elapsed As TimeSpan, alarm As Sound)
            Me.New(duration, elapsed, alarm, True)
        End Sub
        ''' <summary>
        ''' Provieds a set of methods and properties that you can use to accurately measure elapsed time with an alarm.
        ''' </summary>
        ''' <param name="duration">The duration.</param>
        ''' <param name="elapsed">The elapsed time.</param>
        ''' <param name="alarm">The alarm.</param>
        ''' <param name="alarmEnabled">The value indication whether the alarm is enabled.</param>
        ''' <remarks></remarks>
        Sub New(duration As TimeSpan, elapsed As TimeSpan, alarm As Sound, alarmEnabled As Boolean)
            Me.New(duration, elapsed, alarm, alarmEnabled, 0)
        End Sub
        ''' <summary>
        ''' Provieds a set of methods and properties that you can use to accurately measure elapsed time with an alarm.
        ''' </summary>
        ''' <param name="duration">The duration.</param>
        ''' <param name="elapsed">The elapsed time.</param>
        ''' <param name="alarm">The alarm.</param>
        ''' <param name="alarmEnabled">The value indication whether the alarm is enabled.</param>
        ''' <param name="restarts">The number of restarts.</param>
        ''' <remarks></remarks>
        Sub New(duration As TimeSpan, elapsed As TimeSpan, alarm As Sound, alarmEnabled As Boolean, restarts As Integer)
            MyBase.New(duration, elapsed, restarts)
            Me.Alarm = alarm
            Me.AlarmEnabled = alarmEnabled
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub AlarmTimer_Expired(sender As Object, e As TimerEventArgs)
            PlayAlarm()
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub StopAlarm(sender As Object, e As EventArgs)
            If (_alarm IsNot Nothing) Then
                Try
                    _alarm.Stop()
                Catch ex As Exception
                    logger.Warn(ex)
                End Try
            End If
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub PlayAlarm()
            Try
                If (_alarm IsNot Nothing) Then
                    _alarm.Play()
                End If
            Catch ex As Exception
                logger.Warn(ex)
            End Try
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AlarmEnabled() As Boolean
            Get
                Return _alarmEnabled
            End Get

            Set(value As Boolean)
                _alarmEnabled = value

                RemoveHandler MyBase.Started, AddressOf StopAlarm
                RemoveHandler MyBase.Expired, AddressOf AlarmTimer_Expired
                RemoveHandler MyBase.Paused, AddressOf StopAlarm
                RemoveHandler MyBase.Restarted, AddressOf StopAlarm

                If (_alarmEnabled) Then
                    AddHandler MyBase.Started, AddressOf StopAlarm
                    AddHandler MyBase.Expired, AddressOf AlarmTimer_Expired
                    AddHandler MyBase.Paused, AddressOf StopAlarm
                    AddHandler MyBase.Restarted, AddressOf StopAlarm
                End If
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Alarm As Sound
            Get
                Return _alarm
            End Get
            Set(value As Sound)
                If (Not Object.ReferenceEquals(_alarm, value)) Then
                    _alarm = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Reset()
            MyBase.Reset()
            StopAlarm(Me, Nothing)
        End Sub
#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If (Not Me.disposedValue) Then
                If disposing Then
                    RemoveHandler MyBase.Started, AddressOf StopAlarm
                    RemoveHandler MyBase.Expired, AddressOf AlarmTimer_Expired
                    RemoveHandler MyBase.Paused, AddressOf StopAlarm
                    RemoveHandler MyBase.Restarted, AddressOf StopAlarm
                End If
            End If
            Me.disposedValue = True
        End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
End Namespace
