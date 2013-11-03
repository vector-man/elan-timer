Imports System.Text
Public Class TimeFormatter
    Public Shared Function Format(ts As TimeSpan) As String
        Dim sb = New StringBuilder()
        If Math.Floor(ts.Days) > 0 Then
            sb.Append(ts.Days)
            sb.Append(".")
        End If
        sb.Append(ts.ToString("hh\:mm\:ss"))
        Return sb.ToString()
    End Function
End Class
