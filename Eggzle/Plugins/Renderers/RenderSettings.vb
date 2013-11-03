Namespace CodeIsle.Plugins
    Public Class RenderSettings


        Public Property Time As TimeSpan
        Public Property ForegroundColor As Color
        Public Property BackgroundColor As Color
        Public Property TimeStopped As Boolean
        Public Property Size As Size
        Public Property PreviewOpacity As Double = 100

        Sub New(time As TimeSpan, foregroundColor As Color, backgroundColor As Color, timeStopped As Boolean, size As Size)
            MyClass.Time = time
            MyClass.ForegroundColor = foregroundColor
            MyClass.BackgroundColor = backgroundColor
            MyClass.TimeStopped = timeStopped
            MyClass.Size = size
        End Sub


    End Class
End Namespace
