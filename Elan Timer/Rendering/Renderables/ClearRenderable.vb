Namespace Rendering
    Public Class ClearRenderable
        Implements IRenderable
        Sub New(color As Color, visible As Boolean)
            MyClass.Color = color
            MyClass.Visible = visible
        End Sub

        Public Property Visible As Boolean Implements IRenderable.Visible
        Public Property Color As Color Implements IRenderable.Color

        Public Property Rectangle As Rectangle Implements IRenderable.Rectangle

        Public Sub Render(e As PaintEventArgs) Implements IRenderable.Render
            If (Visible) Then
                e.Graphics.Clear(Color)
            End If
        End Sub
    End Class
End Namespace
