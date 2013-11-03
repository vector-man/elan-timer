Namespace CodeIsle
    Public Class Graphics
        Function DrawText(ByVal ImageWidth As Integer, ByVal ImageHeight As Integer, ByVal Text As String, ByVal [Font] As Font, ByVal FGColor As Brush, ByVal Position As PointF) As Bitmap
            If Not ImageWidth * ImageHeight <= 0 Then
                Dim tmpBitMap As New Bitmap(ImageWidth, ImageHeight)
                Dim myGR As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(tmpBitMap)
                myGR.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
                Dim strFormat As StringFormat = New StringFormat()
                strFormat.Alignment = StringAlignment.Center
                strFormat.LineAlignment = StringAlignment.Center
                ' Draw string to screen.
                strFormat.Alignment = StringAlignment.Center
                myGR.DrawString(Text, [Font], FGColor, New RectangleF(0, 0, ImageWidth, ImageHeight), strFormat)
                Return tmpBitMap
            End If
        End Function
    End Class

End Namespace