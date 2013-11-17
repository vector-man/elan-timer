Public Class TextRenderObject
    Implements IRenderObject
    Const MaximumFontSize = 1000
    Sub New(text As String, font As Font, sizeToFit As Boolean, color As Color, stringFormat As StringFormat, visible As Boolean)
        MyClass.Text = text
        MyClass.Font = font
        MyClass.Color = color
        MyClass.SizeToFit = sizeToFit
        MyClass.Visible = visible
        MyClass.StringFormat = stringFormat
    End Sub

    Public Property Visible As Boolean Implements IRenderObject.Visible
    Public Property SizeToFit As Boolean
    Public Property Text As String
    Public Property Font As Font
    Public Property Color As Color
    Public Property StringFormat As StringFormat

    Public Overridable Sub Draw(args As IRenderArgs) Implements IRenderObject.Draw
        If (Visible) Then
            Dim largestFontSize As Long

            If (SizeToFit) Then
                largestFontSize = MaximumFontSize
            Else
                largestFontSize = Font.Size
            End If

            Using textFont = AppropriateFont(args.Graphics, Font.Size, largestFontSize, args.Rectangle.Size, Text, Font)
                Using textBrush As New SolidBrush(Color)
                    args.Graphics.DrawString(Text, textFont, textBrush, args.Rectangle, StringFormat)
                End Using
            End Using
        End If
    End Sub

    Private Function AppropriateFont(ByVal g As System.Drawing.Graphics, ByVal minFontSize As Integer, ByVal maxFontSize As Integer, ByVal layoutSize As Size, ByVal s As String, ByVal f As Font) As Font
        If maxFontSize = minFontSize Then
            f = New Font(f.FontFamily, minFontSize, f.Style)
        End If
        Dim extent As SizeF
        extent = g.MeasureString(s, f)

        If maxFontSize <= minFontSize Then
            Return f
        End If

        Dim hRatio As Single = layoutSize.Height / extent.Height
        Dim wRatio As Single = layoutSize.Width / extent.Width

        Dim ratio As Single = If((hRatio < wRatio), hRatio, wRatio)

        Dim newSize As Single = f.Size * ratio

        If newSize < minFontSize Then
            newSize = minFontSize
        ElseIf newSize > maxFontSize Then
            newSize = maxFontSize
        End If

        f = New Font(f.FontFamily, newSize, f.Style)

        Return f
    End Function
End Class
