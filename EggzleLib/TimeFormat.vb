Imports System.Text
Public Class TimeFormat : Implements IFormatProvider, ICustomFormatter
    Public Function Format(fmt As String, arg As Object, formatProvider As IFormatProvider) As String Implements ICustomFormatter.Format
        Dim sb = New StringBuilder()
        Dim ts = CType(arg, TimeSpan)
        If Math.Floor(ts.Days) > 0 Then
            sb.Append(ts.Days)
            sb.Append(".")
        End If
        sb.Append(ts.ToString("hh\:mm\:ss"))
        Return sb.ToString()
    End Function

    Public Function GetFormat(formatType As Type) As Object Implements IFormatProvider.GetFormat
        Return Me
    End Function
End Class
