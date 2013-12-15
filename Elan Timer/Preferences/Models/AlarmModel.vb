Public Class AlarmModel
    Implements IEquatable(Of AlarmModel)
    Sub New(name As String, fileName As String)
        MyClass.Name = name
        MyClass.FileName = fileName
    End Sub
    Public Property Name As String
    Public Property FileName As String

    Public Overloads Function Equals(other As AlarmModel) As Boolean Implements IEquatable(Of AlarmModel).Equals
        If Me.Name = other.Name And Me.FileName = other.FileName Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
