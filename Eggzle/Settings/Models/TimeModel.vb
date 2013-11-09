Namespace Settings.Models
    Public Class TimeModel
        Sub New(duration As TimeSpan, countUp As Boolean, autoStart As Boolean, restarts As Integer, alarmEnabled As Boolean, alarmPath As String, alarmLoop As Boolean, alarmVolume As Integer, memo As String)
            MyClass.Duration = duration
            MyClass.CountUp = countUp
            MyClass.AutoStart = autoStart
            MyClass.Restarts = restarts
            MyClass.AlarmEnabled = alarmEnabled
            MyClass.AlarmPath = alarmPath
            MyClass.AlarmLoop = alarmLoop
            MyClass.AlarmVolume = alarmVolume
            MyClass.Note = memo
        End Sub
        Sub New()

        End Sub
        Public Property Duration As TimeSpan
        Public Property CountUp As Boolean
        Public Property AutoStart As Boolean
        Public Property Restarts As Integer
        Public Property AlarmEnabled As Boolean
        Public Property AlarmPath As String
        Public Property AlarmLoop As Boolean
        Public Property AlarmVolume As Integer
        Public Property Note As String
    End Class
End Namespace
