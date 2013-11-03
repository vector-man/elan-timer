Namespace Extend.Rendering
    Public Class SurfaceFactory
        Public Shared Function CreateInstance(renderer As EggzleLib.Extend.Rendering.IRenderer, args As RenderArgs)
            Return CreateInstance(renderer, args, False)
        End Function
        Public Shared Function CreateInstance(renderer As EggzleLib.Extend.Rendering.IRenderer, args As RenderArgs, preview As Boolean)
            If preview Then
                Return New PreviewSurface(renderer, args, 1)
            Else
                Return New Surface(renderer, args)
            End If
        End Function
    End Class
End Namespace
