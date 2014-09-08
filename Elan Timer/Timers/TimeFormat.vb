Imports System.Text
Imports System.Globalization
Imports System.Resources

Public Class TimeFormat : Implements IFormatProvider, ICustomFormatter
    Private hoursFormat As String
    Private hoursSecondsFormat As String
    Private minutesFormat As String
    Private secondsFormat As String
    Private countUpFormat As String
    Sub New()
        Dim res As ResourceHelper = New ResourceHelper("ElanTimer.Strings", Me.GetType.Assembly)

        hoursFormat = res.GetResourceValue("HoursFormat")
        hoursSecondsFormat = res.GetResourceValue("HoursSecondsFormat")
        minutesFormat = res.GetResourceValue("MinutesFormat")
        secondsFormat = res.GetResourceValue("SecondsFormat")
        countUpFormat = res.GetResourceValue("CountUpFormat")
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
                Dim totalHours As Integer = Math.Floor(ts.TotalHours)
                ' Show text (verbal) - format: d days format h hours m minutes s seconds.
                If (totalHours > 0 And (Not ts.Minutes > 0)) Then
                    Return String.Format(hoursSecondsFormat, totalHours, ts.Seconds)
                ElseIf (totalHours > 0) Then
                    Return String.Format(hoursFormat, totalHours, ts.Minutes, ts.Seconds)
                ElseIf (ts.Minutes > 0) Then
                    Return String.Format(minutesFormat, ts.Minutes, ts.Seconds)
                Else
                    Return String.Format(secondsFormat, ts.Seconds)
                End If
        End Select
        Return sb.ToString.Trim
    End Function

    Public Function GetFormat(formatType As Type) As Object Implements IFormatProvider.GetFormat
        Return Me
    End Function
End Class
