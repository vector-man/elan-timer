Imports System.Text
Public Class TimeFormat : Implements IFormatProvider, ICustomFormatter
    Private daysFormat As String = "{0} Days {1} Hours {2} Minutes {3} Seconds"
    Private hoursFormat As String = "{0} Hours {1} Minutes {2} Seconds"
    Private hoursSecondsFormat As String = "{0} Hours {1} Seconds"
    Private minutesFormat As String = "{0} Minutes {1} Seconds"
    Private secondsFormat As String = "{0} Seconds"
    Sub New()

    End Sub
    Sub New(daysFormat As String, hoursFormat As String, hoursSecondsFormat As String, minutesFormat As String, secondsFormat As String)
        MyClass.daysFormat = daysFormat
        MyClass.hoursFormat = hoursFormat
        MyClass.minutesFormat = minutesFormat
        MyClass.secondsFormat = secondsFormat
        MyClass.hoursSecondsFormat = hoursSecondsFormat
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
                sb.Append(ts.Seconds)
                sb.Append(String.Format(" {0} ", secondsText))
        End Select
        Return sb.ToString.Trim
    End Function

    Public Function GetFormat(formatType As Type) As Object Implements IFormatProvider.GetFormat
        Return Me
    End Function
End Class
