Namespace CleanCode.Data
    ' Code from http://cleancode.sourceforge.net/
    ' License: http://cleancode.sourceforge.net/wwwdoc/courtesy.txt
    Public Structure RoundedTimeSpan

        Private Const TIMESPAN_SIZE As Integer = 7
        ' it always has seven digits
        Private roundedTimeSpan As TimeSpan
        Private precision As Integer

        Public Sub New(ticks As Long, precision As Integer)
            If precision < 0 Then
                Throw New ArgumentException("precision must be non-negative")
            End If
            Me.precision = precision
            Dim factor As Integer = CInt(Math.Truncate(System.Math.Pow(10, (TIMESPAN_SIZE - precision))))

            ' This is only valid for rounding milliseconds-will *not* work on secs/mins/hrs!
            roundedTimeSpan = New TimeSpan((CLng(Math.Truncate(System.Math.Round((1.0 * ticks / factor)))) * factor))
        End Sub

        Public ReadOnly Property TimeSpan() As TimeSpan
            Get
                Return roundedTimeSpan
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return ToString(precision)
        End Function

        Public Overloads Function ToString(length As Integer) As String
            ' this method revised 2010.01.31
            Dim digitsToStrip As Integer = TIMESPAN_SIZE - length
            Dim s As String = roundedTimeSpan.ToString()
            If Not s.Contains(".") AndAlso length = 0 Then
                Return s
            End If
            If Not s.Contains(".") Then
                s += "." & New String("0"c, TIMESPAN_SIZE)
            End If
            Dim subLength As Integer = s.Length - digitsToStrip
            Return If(subLength < 0, "", If(subLength > s.Length, s, s.Substring(0, subLength)))
        End Function
    End Structure
End Namespace