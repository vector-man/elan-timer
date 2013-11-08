Public Class PreviewSurface : Inherits Rendering.Surface
    Sub New(renderer As Rendering.IRenderer, args As RenderArgs)
        MyClass.New(renderer, args, 1)
    End Sub
    Sub New(renderer As Rendering.IRenderer, args As RenderArgs, opacity As Double)
        MyBase.New(renderer, args)
        MyClass.Opacity = opacity
    End Sub
    Public Property Opacity As Double
    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        MyBase.OnPaint(pe)
        Using brush As New System.Drawing.Drawing2D.HatchBrush(Drawing2D.HatchStyle.LargeCheckerBoard, System.Drawing.Color.FromArgb(255 - (MyClass.Opacity) * 255, Color.LightGray), System.Drawing.Color.FromArgb(255 - (MyClass.Opacity) * 255, Color.White))
            pe.Graphics.FillRectangle(brush, Me.ClientRectangle)
        End Using
    End Sub
End Class
