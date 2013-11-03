Imports System.Text.RegularExpressions

Public Class TimeParser
    Private Shared verbalPattern As String = "^(?=\d)((?<days>\d+)\s?(d|day|days))?\s*((?<hours>\d+)\s?(h|hour|hours))?\s*((?<minutes>\d+)\s?(m|minute|minutes?))?\s*((?<seconds>\d+)\s?(s|second|seconds?))?$"

    Private Shared daysPattern As String = "^(?<days>\d+?)(\s+|[:|.])(?<hours>\d+)(\s+|[:|.]?)(?<minutes>\d+)(\s+|[:|.]?)(?<seconds>\d+)(\s+|[:|.]?)$"
    Private Shared hoursPattern As String = "^(?<hours>\d+)(\s+|[:|.]?)(?<minutes>\d+)(\s+|[:|.]?)(?<seconds>\d+)(\s+|[:|.]?)$"
    Private Shared minutesPattern As String = "^(?<minutes>\d+)(\s+|[:|.]?)(?<seconds>\d+)(\s+|[:|.]?)$"

    Private Shared formats() As String = {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt",
                             "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss",
                             "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt",
                             "M/d/yyyy h:mm", "M/d/yyyy h:mm",
                             "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm",
                             "M/d/yyyy", "M/d/yyyy"}
    Public Shared Function Parse(arg As String) As TimeSpan
        Dim result As String = arg.Trim

        Dim num As Double
        Dim ts As TimeSpan

        Double.TryParse(result, num)

        If num > 0 Then
            Try
                Return TimeSpan.FromMinutes(num)
            Catch ex As Exception
                Return Nothing
            End Try
        End If

        Try

            Dim match As System.Text.RegularExpressions.Match

            Dim days As Integer
            Dim hours As Integer
            Dim minutes As Integer
            Dim seconds As Integer

            match = Regex.Match(result, minutesPattern)
            If Not match.Success Then
                match = Regex.Match(result, hoursPattern)
                If Not match.Success Then
                    match = Regex.Match(result, daysPattern)
                    If Not match.Success Then
                        match = Regex.Match(result, verbalPattern)
                    End If
                End If
            End If

            If match.Success Then
                Integer.TryParse(match.Groups("days").Value, days)

                Integer.TryParse(match.Groups("hours").Value, hours)

                Integer.TryParse(match.Groups("minutes").Value, minutes)


                Integer.TryParse(match.Groups("seconds").Value, seconds)

                ts = New TimeSpan(days, hours, minutes, seconds)
            End If


            If Not ts = Nothing Then
                If Not ts.CompareTo(TimeSpan.Zero) <= 0 Then
                    Return ts
                End If
            End If

            Dim now = Date.Now
            Dim time = Date.ParseExact(result, formats, System.Globalization.CultureInfo.CurrentUICulture, Globalization.DateTimeStyles.None)
            If time > now Then
                ts = TimeSpan.FromTicks((time - now).Ticks)
            Else
            End If
        Catch ex As Exception

        End Try
        Return ts

        'If False Then
        'Else
        '    Dim num As Double
        '    Dim ts As TimeSpan
        '    Try
        '        Double.TryParse(result, num)
        '        If num < 0 Then
        '            Return Nothing
        '        ElseIf num = 0 Then
        '            Dim segments As String() = result.Split(":")
        '            Dim days = segments(0).Split(".")
        '            If segments.Count = 1 Then
        '                segments = result.Split(" ")
        '            End If
        '            If segments.Count = 2 Then
        '                ts = ts.Add(TimeSpan.FromMinutes(segments(0)))
        '                ts = ts.Add(TimeSpan.FromSeconds(segments(1)))
        '            ElseIf segments.Count = 3 Then

        '                If days.Count = 2 Then
        '                    ts = ts.Add(TimeSpan.FromDays(days(0)))
        '                    ts = ts.Add(TimeSpan.FromHours(days(1)))
        '                Else
        '                    ts = ts.Add(TimeSpan.FromHours(segments(0)))
        '                End If
        '                ts = ts.Add(TimeSpan.FromMinutes(segments(1)))
        '                ts = ts.Add(TimeSpan.FromSeconds(segments(2)))
        '            ElseIf segments.Count = 4 Then
        '                If days.Count > 2 Then
        '                    Return Nothing
        '                End If
        '                ts = ts.Add(TimeSpan.FromDays(segments(0)))
        '                ts = ts.Add(TimeSpan.FromHours(segments(1)))
        '                ts = ts.Add(TimeSpan.FromMinutes(segments(2)))
        '                ts = ts.Add(TimeSpan.FromSeconds(segments(3)))
        '            End If
        '            If Not ts = Nothing Then
        '                Return ts
        '            End If
        '        End If
        '    Catch ex As Exception

        '    End Try

        'Try
        '    Dim now = Date.Now
        '    Dim time = Date.ParseExact(result, formats, System.Globalization.CultureInfo.CurrentUICulture, Globalization.DateTimeStyles.None)
        '    If time > now Then
        '        Return TimeSpan.FromTicks((time - now).Ticks)
        '    Else
        '    End If
        'Catch ex As Exception

        'End Try

        'Try
        '    ts = TimeSpan.FromMinutes(num)
        '    If ts.CompareTo(TimeSpan.Zero) <= 0 Then
        '        Return Nothing
        '    End If
        '    Return ts
        'Catch ex As Exception

        'End Try
        'End If


    End Function


End Class
