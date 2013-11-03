Namespace CodeIsle.Timers
    Public Class CountUpAlarmTimer
        Inherits AlarmTimer

        Sub New(duration As TimeSpan)
            MyBase.New(duration, Nothing, Nothing)
        End Sub
        Sub New(duration As TimeSpan, alarmFile As String)
            MyBase.New(duration, alarmFile, True)
        End Sub
        Sub New(duration As TimeSpan, alarmFile As String, alarmSet As Boolean)
            MyBase.New(duration, alarmFile, alarmSet)
        End Sub
        Public Overrides ReadOnly Property Current As TimeSpan
            Get
                Return MyBase.Elapsed
            End Get
        End Property

    End Class
End Namespace