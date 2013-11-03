Namespace Extend.Rendering
    Public Class Surface
        Inherits PictureBox
        Private _renderer As EggzleLib.Extend.Rendering.IRenderer
        Private Const DefaultRenderRate As Integer = 1000 / 60
        Private _renderRate As Integer
        Private _args As RenderArgs
        Private surfaceInvalidatorCancellationTokenSource As System.Threading.CancellationTokenSource

        Sub New(renderer As EggzleLib.Extend.Rendering.IRenderer, args As RenderArgs)
            MyClass.New(renderer, args, DefaultRenderRate)
        End Sub
        Sub New(renderer As EggzleLib.Extend.Rendering.IRenderer, args As Object, renderRate As Integer)
            MyBase.New()
            _renderer = renderer
            _renderRate = renderRate
            _args = args
            AddHandler Me.Paint, AddressOf Surface_Paint

            surfaceInvalidatorCancellationTokenSource = New System.Threading.CancellationTokenSource
            Task.Run(Sub() SurfaceInvalidatorAsync(surfaceInvalidatorCancellationTokenSource.Token), surfaceInvalidatorCancellationTokenSource.Token)
        End Sub

        Private Sub Surface_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            _args.ClipRectangle = e.ClipRectangle
            _args.Graphics = e.Graphics
            _renderer.Render(New EggzleLib.RenderArgs(_args))
        End Sub
        Private Async Sub SurfaceInvalidatorAsync(token As System.Threading.CancellationToken)
            While Not token.IsCancellationRequested
                Await Task.Delay(_renderRate)
                Me.Invalidate()
            End While
        End Sub

        Public Overloads Sub Dispose()
            RemoveHandler Me.Paint, AddressOf Surface_Paint
            surfaceInvalidatorCancellationTokenSource.Cancel()
            Task.WaitAll()
            MyBase.Dispose()
        End Sub
    End Class
End Namespace