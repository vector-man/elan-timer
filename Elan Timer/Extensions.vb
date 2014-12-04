Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Module Extensions
    <System.Runtime.CompilerServices.Extension>
    Public Function ToBase64(obj As Object) As String
        Using ms As New MemoryStream()
            Dim bf As New BinaryFormatter()
            bf.Serialize(ms, obj)
            ms.Position = 0
            Dim buffer As Byte() = New Byte(CInt(ms.Length) - 1) {}
            ms.Read(buffer, 0, buffer.Length)
            Return Convert.ToBase64String(buffer)
        End Using
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function FromBase64(Of T)(obj As Object) As T
        Using ms As New MemoryStream(Convert.FromBase64String(obj))
            Dim bf As New BinaryFormatter()
            Return DirectCast(bf.Deserialize(ms), T)
        End Using
    End Function
End Module