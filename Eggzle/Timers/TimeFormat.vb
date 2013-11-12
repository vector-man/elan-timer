Imports System.Text
Public Class TimeFormat : Implements IFormatProvider, ICustomFormatter
    Private daysText As String = "Days"
    Private hoursText As String = "Hours"
    Private minutesText As String = "Minutes"
    Private secondsText As String = "Seconds"
    Sub New()

    End Sub
    Sub New(daysText As String, hoursText As String, minutesText As String, secondsText As String)
        MyClass.daysText = daysText
        MyClass.hoursText = hoursText
        MyClass.minutesText = minutesText
        MyClass.secondsText = secondsText
    End Sub
    Public Function Format(fmt As String, arg As Object, formatProvider As IFormatProvider) As String Implements ICustomFormatter.Format
        Dim sb = New StringBuilder()
        Dim ts = CType(arg, TimeSpan)
        Select Case fmt
            Case "s", Nothing
                ' Show seconds - format: hours:mm:ss
                sb.Append(Math.Floor(ts.TotalHours))
                sb.Append(ts.ToString("\:mm\:ss"))
            Case "S"
                ' Show only seconds - format: s
                sb.Append(Math.Floor(ts.TotalSeconds))
            Case "m"
                ' Show microseconds - format: hours:mm:ss.ff
                sb.Append(Math.Floor(ts.TotalHours))
                sb.Append(ts.ToString("\:mm\:ss\.ff"))
            Case "d"
                ' Show deciseconds - format: hours:mm:ss.f
                sb.Append(Math.Floor(ts.TotalHours))
                sb.Append(ts.ToString("\:mm\:ss\.f"))
            Case "v"
                ' Show text (verbal) - format: d days format h hours m minutes s seconds.
                If ts.Hours > 0 Then
                    sb.Append(ts.Hours)
                    sb.Append(String.Format(" {0} ", hoursText))
                End If

                If ts.Minutes > 0 Then
                    sb.Append(ts.Minutes)
                    sb.Append(String.Format(" {0} ", minutesText))
                End If


                If ts.Milliseconds > 0 Or ts.Seconds > 0 Then
                    sb.Append(ts.Seconds)
                    sb.Append(String.Format(" {0} ", secondsText))
                End If
        End Select
        Return sb.ToString
    End Function

    Public Function GetFormat(formatType As Type) As Object Implements IFormatProvider.GetFormat
        Return Me
    End Function
End Class
