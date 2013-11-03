Namespace Settings.Models
    Public Class TimeModel
        Sub New(time As TimeSpan, restarts As Integer, volume As Integer)
            MyClass.Time = time
            MyClass.Restarts = restarts
            MyClass.Volume = volume
        End Sub
        Sub New()

        End Sub
        Public Property Time As TimeSpan
        Public Property Restarts As Integer
        Public Property Volume As Integer

    End Class
End Namespace
