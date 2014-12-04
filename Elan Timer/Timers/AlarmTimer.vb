Imports NLog
Namespace CodeIsle.Timers
    Public Class AlarmTimer
        Inherits TimerBase
        Implements IDisposable

        Private _enabled As Boolean
        Private _alarm As Sound
        Private _alarmEnabled As Boolean
        Private singleAlarm As Sound

        ' Logging.
        Private logger As Logger = LogManager.GetCurrentClassLogger()

        Public Property AlarmPerRestart As Boolean

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
            singleAlarm = New Sound()
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub AlarmTimer_Expired(sender As Object, e As TimerEventArgs)
            StopAlarm(singleAlarm)
            PlayAlarm(Alarm)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub StopAlarm(sender As Object, e As EventArgs)
            StopAlarm(singleAlarm)
            StopAlarm(Alarm)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub PlayAlarm(sound As Sound)
            Try
                If (sound IsNot Nothing) Then
                    sound.Play()
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
                RemoveHandler MyBase.Restarted, AddressOf AlarmTimer_Restarted

                If (_alarmEnabled) Then
                    AddHandler MyBase.Started, AddressOf StopAlarm
                    AddHandler MyBase.Expired, AddressOf AlarmTimer_Expired
                    AddHandler MyBase.Paused, AddressOf StopAlarm
                    AddHandler MyBase.Restarted, AddressOf AlarmTimer_Restarted
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
        Public Overrides Sub Reset(duration As TimeSpan, elapsed As TimeSpan, restarts As Integer)
            MyBase.Reset(duration, elapsed, restarts)
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

        Private Sub AlarmTimer_Restarted(sender As Object, e As TimerEventArgs)
            If (Alarm Is Nothing) Then Return

            StopAlarm(Me, New EventArgs())

            If (AlarmPerRestart AndAlso
                AlarmEnabled AndAlso
                Restarts > 0) Then

                Try
                    singleAlarm.Load(Me.Alarm.Sound)
                    singleAlarm.Loop = False
                    singleAlarm.Volume = Alarm.Volume
                Catch ex As Exception
                    logger.Warn(ex)
                End Try


                PlayAlarm(singleAlarm)
            End If
        End Sub

        Private Sub StopAlarm(sound As Sound)
            If (sound Is Nothing) Then Return
            Try
                sound.Stop()
            Catch ex As Exception
                logger.Warn(ex)
            End Try
        End Sub
    End Class
End Namespace
