Namespace Rendering
    Public Class Surface
        Inherits Label
        Private _renderer As IRenderer
        Private framerate As Integer
        Private surfaceInvalidatorCancellationTokenSource As System.Threading.CancellationTokenSource
        Private renderArgs As RenderArgs
        Private _enabled As Boolean = True
        Sub New(renderer As IRenderer, framerate As Integer)
            MyBase.New()
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.SetStyle(ControlStyles.ResizeRedraw, True)
            Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
            _renderer = renderer
            MyClass.framerate = framerate
            renderArgs = New RenderArgs
            AddHandler Me.Paint, AddressOf Surface_Paint
            Me.Enabled = True
        End Sub

        Private Sub Surface_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            renderArgs.Graphics = e.Graphics
            renderArgs.Rectangle = ClientRectangle
            _renderer.Render(renderArgs)
        End Sub
        Private Async Sub SurfaceInvalidatorAsync(token As System.Threading.CancellationToken)
            While Not token.IsCancellationRequested
                Await TaskEx.Delay(MyClass.framerate)
                Me.Invalidate()
            End While
        End Sub

        Public Overloads Sub Dispose()
            RemoveHandler Me.Paint, AddressOf Surface_Paint
            surfaceInvalidatorCancellationTokenSource.Cancel()
            Task.WaitAll()
            MyBase.Dispose()
        End Sub
        Public Overloads Property Enabled
            Get
                Return _enabled
            End Get
            Set(value)
                _enabled = value
                If _enabled = False Then
                    surfaceInvalidatorCancellationTokenSource.Cancel()
                Else
                    surfaceInvalidatorCancellationTokenSource = New System.Threading.CancellationTokenSource
                    TaskEx.Run(Sub() SurfaceInvalidatorAsync(surfaceInvalidatorCancellationTokenSource.Token), surfaceInvalidatorCancellationTokenSource.Token)
                End If
            End Set
        End Property

    End Class
End Namespace