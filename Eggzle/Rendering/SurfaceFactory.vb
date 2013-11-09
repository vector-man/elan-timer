Namespace Rendering
    Public Class SurfaceFactory
        Public Shared Function CreateInstance(renderer As Rendering.IRenderer, args As RenderArgs, renderRate As Integer)
            Return CreateInstance(renderer, args, False, renderRate)
        End Function
        Public Shared Function CreateInstance(renderer As IRenderer, args As RenderArgs, preview As Boolean, renderRate As Integer)
            If preview Then
                Return New PreviewSurface(renderer, args, 1)
            Else
                Return New Surface(renderer, args, renderRate)
            End If
        End Function
    End Class
End Namespace
