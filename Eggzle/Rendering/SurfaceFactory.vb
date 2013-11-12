Namespace Rendering
    Public Class SurfaceFactory
        Public Shared Function CreateInstance(renderer As Rendering.IRenderer, framerate As Integer)
            Return CreateInstance(renderer, framerate, False)
        End Function
        Public Shared Function CreateInstance(renderer As IRenderer, framerate As Integer, preview As Boolean)
            If preview Then
                Return New PreviewSurface(renderer, 1, framerate)
            Else
                Return New Surface(renderer, framerate)
            End If
        End Function
    End Class
End Namespace
