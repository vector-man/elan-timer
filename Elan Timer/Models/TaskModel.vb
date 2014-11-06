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
End Class
<TypeConverter(GetType(LocalizedEnumConverter))>
Public Enum TimerEvent
    Expired
    Paused ' Same as Enabled = False, or calling Stop()
    Restarted
    Started
End Enum
