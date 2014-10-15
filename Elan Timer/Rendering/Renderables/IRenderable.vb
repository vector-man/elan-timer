Namespace Rendering
    Public Interface IRenderable
        Property Visible As Boolean
        Property Color As Color
        Property Rectangle As Rectangle
        Sub Render(e As PaintEventArgs)
    End Interface
End Namespace
