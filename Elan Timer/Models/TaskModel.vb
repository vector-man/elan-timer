Imports PropertyChanged
Imports System.ComponentModel

<ImplementPropertyChanged>
<Serializable>
Public Class TaskModel
    Public Property [Event] As TimerEvent
    Public Property Name As String
    Public Property Command As String
    Public Property Arguments As String
    Public Property UseScript As Boolean
    Public Property Script As String
    Public Property Enabled As Boolean
    Sub New()

    End Sub
    Sub New([event] As TimerEvent, name As String, command As String, arguments As String, useScript As String, script As String, enabled As Boolean)
        Me.Event = [event]
        Me.Name = name
        Me.Command = command
        Me.Arguments = arguments
        Me.UseScript = useScript
        Me.Script = script
        Me.Enabled = enabled
    End Sub
End Class
<TypeConverter(GetType(LocalizedEnumConverter))>
Public Enum TimerEvent
    Expired
    Paused ' Same as Enabled = False, or calling Stop()
    Restarted
    Started
End Enum
