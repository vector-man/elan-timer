Public Enum TimerEvent
    Expired
    Paused ' Same as Enabled = False, or calling Stop()
    Restarted
    Started
End Enum
Public Class ActionSettings

    Public Property [Event] As TimerEvent
    Public Property Name As String
    Public Property Command As String
    Public Property Arguments As String
    Public Property UseScript As Boolean
    Public Property Script As String
    Public Property Enabled As Boolean
    Sub New([event] As TimerEvent, name As String, command As String, arguments As String, useScript As Boolean, script As String, enabled As Boolean)
        MyClass.Event = [event]
        MyClass.Name = name
        MyClass.Command = command
        MyClass.Arguments = arguments
        MyClass.UseScript = useScript
        MyClass.Script = script
        MyClass.Enabled = enabled
    End Sub
    Sub New()

    End Sub

End Class
