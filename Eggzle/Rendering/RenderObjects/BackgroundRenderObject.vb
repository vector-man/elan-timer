Public Class BackgroundRenderObject
    Implements IRenderObject
    Sub New(color As Color, visible As Boolean)
        Me.Visible = visible
        Me.Color = color
    End Sub
    Public Sub Draw(args As IRenderArgs) Implements IRenderObject.Draw
        If (Visible) Then
            Using colorBrush As New SolidBrush(Me.Color)
                args.Graphics.FillRectangle(colorBrush, args.Rectangle)
            End Using

        End If
    End Sub
    Public Property Visible As Boolean Implements IRenderObject.Visible
    Public Property Color As Color
End Class
