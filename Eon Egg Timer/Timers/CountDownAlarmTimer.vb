Namespace CodeIsle.Timers
    Public Class CountDownAlarmTimer
        Inherits AlarmTimer

        Sub New(duration As TimeSpan)
            MyBase.New(duration, Nothing, False)
        End Sub
        Sub New(duration As TimeSpan, alarm As Alarm)
            MyBase.New(duration, alarm, True)
        End Sub
        Sub New(duration As TimeSpan, alarm As Alarm, alarmEnabled As Boolean)
            MyBase.New(duration, alarm, alarmEnabled, 0)
        End Sub
        Sub New(duration As TimeSpan, alarm As Alarm, alarmEnabled As Boolean, restarts As Integer)
            MyBase.New(duration, alarm, alarmEnabled, restarts)
        End Sub
        Sub New(duration As TimeSpan, alarm As Alarm, alarmEnabled As Boolean, restarts As Integer, expirationPollRate As Integer)
            MyBase.New(duration, alarm, alarmEnabled, restarts, expirationPollRate)
        End Sub
        Public Overrides ReadOnly Property Current As TimeSpan
            Get
                Return MyBase.Remaining
            End Get
        End Property
        Protected Overrides Sub Dispose(disposing As Boolean)
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace