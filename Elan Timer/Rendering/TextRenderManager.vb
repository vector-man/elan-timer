Namespace Rendering
    Public Class TextRenderManager : Inherits RenderManager
        Private _textRenderable As TextRenderable
        Sub New()
            MyBase.New()
            Initalize()
        End Sub

        Private Sub Initalize()
            Dim format = New StringFormat(System.Drawing.StringFormat.GenericTypographic)
            format.Alignment = StringAlignment.Center
            format.LineAlignment = StringAlignment.Center

            _textRenderable = New TextRenderable() With {.StringFormat = format}

            Renderer.Renderables.Add(_textRenderable)

            Surface.Dock = DockStyle.Fill
        End Sub

        Public ReadOnly Property TextRenderable As TextRenderable
            Get
                Return _textRenderable
            End Get
        End Property
        Protected Overrides Sub Dispose(disposing As Boolean)
            MyBase.Dispose(disposing)
            _textRenderable.Dispose()
        End Sub
    End Class
End Namespace
