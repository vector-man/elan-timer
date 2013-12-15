Namespace Prefs.Models
    Public Class TimeModel
        Sub New(duration As TimeSpan, countUp As Boolean, startImmediately As Boolean, restarts As Integer, alarmEnabled As Boolean, alarmPath As String, alarmLoop As Boolean, alarmVolume As Integer, memo As String, hasNote As Boolean, hasNoteAlert As Boolean)
            MyClass.Duration = duration
            MyClass.CountUp = countUp
            MyClass.StartImmediately = startImmediately
            MyClass.Restarts = restarts
            MyClass.AlarmEnabled = alarmEnabled
            MyClass.AlarmPath = alarmPath
            MyClass.AlarmLoop = alarmLoop
            MyClass.AlarmVolume = alarmVolume
            MyClass.Note = memo
            MyClass.HasNote = hasNote
            MyClass.HasNoteAlert = hasNoteAlert
        End Sub
        Sub New()

        End Sub
        Public Property Duration As TimeSpan
        Public Property CountUp As Boolean
        Public Property StartImmediately As Boolean
        Public Property Restarts As Integer
        Public Property AlarmEnabled As Boolean
        Public Property AlarmPath As String
        Public Property AlarmLoop As Boolean
        Public Property AlarmVolume As Integer
        Public Property HasNote As Boolean
        Public Property Note As String
        Public Property HasNoteAlert As Boolean
    End Class
End Namespace
