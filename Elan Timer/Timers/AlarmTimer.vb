Namespace CodeIsle.Timers
    Public MustInherit Class AlarmTimer
        Inherits TimerBase
        Implements IDisposable

        Private _enabled As Boolean
        Private _alarm As Alarm
        Private _alarmEnabled As Boolean
        Sub New(duration As TimeSpan)
            Me.New(duration, Nothing, False)
        End Sub
        Sub New(duration As TimeSpan, alarm As Alarm)
            Me.New(duration, alarm, True)
        End Sub
        Sub New(duration As TimeSpan, alarm As Alarm, alarmEnabled As Boolean)
            Me.New(duration, alarm, alarmEnabled, 0)
        End Sub
        Sub New(duration As TimeSpan, alarm As Alarm, alarmEnabled As Boolean, restarts As Integer)
            Me.New(duration, alarm, alarmEnabled, restarts, 1)
        End Sub
        Sub New(duration As TimeSpan, alarm As Alarm, alarmEnabled As Boolean, restarts As Integer, expirationPollRate As Integer)
            MyBase.New(duration, restarts, expirationPollRate)
            Me.Alarm = alarm
            Me.AlarmEnabled = alarmEnabled
        End Sub
        Private Sub AlarmTimer_Expired(sender As Object, e As TimerEventArgs)
            If (_alarm IsNot Nothing) Then
                _alarm.Play()
            End If
        End Sub

        Private Sub StopAlarm(sender As Object, e As EventArgs)
            If (_alarm IsNot Nothing) Then
                _alarm.Stop()
            End If
        End Sub

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
        Public Property Alarm As Alarm
            Get
                Return _alarm
            End Get
            Set(value As Alarm)
                If (_alarm IsNot Nothing) Then
                    _alarm.Dispose()
                    _alarm = Nothing
                End If
                _alarm = value
            End Set
        End Property

        Public Overrides Sub Reset()
            MyBase.Reset()
            StopAlarm(Me, Nothing)
        End Sub

        Public Overrides ReadOnly Property Current As TimeSpan
            Get
                Return Nothing
            End Get
        End Property

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If (Not Me.disposedValue) Then
                If disposing Then
                    If (_alarm IsNot Nothing) Then
                        _alarm.Dispose()
                    End If
                    _alarm = Nothing

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
