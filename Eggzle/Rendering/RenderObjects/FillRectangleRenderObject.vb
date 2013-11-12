Public Class FillRectangleRenderObject
    Implements IRenderObject
    Sub New(brush As Brush, rect As Rectangle, visible As Boolean)
        MyClass.Visible = visible
        MyClass.Brush = brush
    End Sub
    Public Sub Draw(args As IRenderArgs) Implements IRenderObject.Draw
        If (Visible) Then
            ' args.Graphics
        End If
    End Sub

    Public Property Visible As Boolean Implements IRenderObject.Visible
    Public Property Brush As Brush

End Class
