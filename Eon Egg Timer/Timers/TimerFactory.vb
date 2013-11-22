Public Class TimerFactory
    Public Shared Function CreateInstance(duration As TimeSpan, countUp As Boolean, restarts As Integer, alarm As Alarm, alarmEnabled As Boolean)
        If countUp Then
            Return New CodeIsle.Timers.CountUpAlarmTimer(duration, alarm, alarmEnabled, restarts)
        Else
            Return New CodeIsle.Timers.CountDownAlarmTimer(duration, alarm, alarmEnabled, restarts)
        End If
    End Function
End Class
