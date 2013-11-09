Namespace Rendering
    Public Class Surface
        Inherits PictureBox
        Private _renderer As IRenderer
        Private Const DefaultRenderRate As Integer = 1000 / 60
        Private _renderRate As Integer
        Private _args As RenderArgs
        Private surfaceInvalidatorCancellationTokenSource As System.Threading.CancellationTokenSource

        Sub New(renderer As IRenderer, args As RenderArgs)
            MyClass.New(renderer, args, DefaultRenderRate)
        End Sub
        Sub New(renderer As IRenderer, args As RenderArgs, renderRate As Integer)
            MyBase.New()
            _renderer = renderer
            _renderRate = renderRate
            _args = args
            AddHandler Me.Paint, AddressOf Surface_Paint

            surfaceInvalidatorCancellationTokenSource = New System.Threading.CancellationTokenSource
            TaskEx.Run(Sub() SurfaceInvalidatorAsync(surfaceInvalidatorCancellationTokenSource.Token), surfaceInvalidatorCancellationTokenSource.Token)
        End Sub

        Private Sub Surface_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            _args.ClipRectangle = e.ClipRectangle
            _args.Graphics = e.Graphics
            _renderer.Render(New RenderArgs(_args.ClipRectangle, _args.Graphics, _args.Font, _args.BackgroundColor, _args.ForegroundColor, _args.SizeToFit, _args.Data, _args.FormatProvider, _args.Format))
        End Sub
        Private Async Sub SurfaceInvalidatorAsync(token As System.Threading.CancellationToken)
            While Not token.IsCancellationRequested
                Await TaskEx.Delay(_renderRate)
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