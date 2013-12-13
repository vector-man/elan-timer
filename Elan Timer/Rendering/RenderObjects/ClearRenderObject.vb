Public Class ClearRenderObject
    Implements IRenderObject
    Sub New(color As Color, visible As Boolean)
        MyClass.Color = color
        MyClass.Visible = visible
    End Sub
    Public Sub Draw(args As IRenderArgs) Implements IRenderObject.Draw
        If (Visible) Then
            args.Graphics.Clear(MyClass.Color)
        End If
    End Sub

    Public Property Visible As Boolean Implements IRenderObject.Visible
    Public Property Color As Color
End Class
