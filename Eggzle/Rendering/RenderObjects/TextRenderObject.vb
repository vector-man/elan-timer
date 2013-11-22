Public Class TextRenderObject
    Implements IRenderObject, IDisposable
    Const MaximumFontSize = 1000
    Private colorBrush As SolidBrush
    Sub New(text As String, font As Font, sizeToFit As Boolean, color As Color, stringFormat As StringFormat, visible As Boolean)
        MyClass.Text = text
        MyClass.Font = font
        colorBrush = New SolidBrush(color)
        MyClass.SizeToFit = sizeToFit
        MyClass.Visible = visible
        MyClass.StringFormat = stringFormat
    End Sub

    Public Property Visible As Boolean Implements IRenderObject.Visible
    Public Property SizeToFit As Boolean
    Public Overridable Property Text As String
    Public Property Font As Font
    Public Property Color As Color
        Get
            Return colorBrush.Color
        End Get
        Set(value As Color)
            colorBrush.Color = value
        End Set
    End Property
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
                args.Graphics.DrawString(Text, textFont, colorBrush, args.Rectangle, StringFormat)
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

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                colorBrush.Dispose()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
