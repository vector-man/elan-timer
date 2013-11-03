Public Class RendererManager
    Implements IDisposable
    Private _surface As PictureBox
    Private _context As Object
    Private _renderer As CodeIsle.Plugins.Renderers.IRenderPlugin
    Private _previewMode As Boolean
    Private Const DefaultRenderRate As Integer = 1000 / 60
    Private _renderRate As Integer
    Private surfaceInvalidatorCancellationTokenSource As System.Threading.CancellationTokenSource
    Sub New(ByRef renderer As CodeIsle.Plugins.Renderers.IRenderPlugin, ByRef context As Object, ByRef surface As PictureBox, previewMode As Boolean)
        MyClass.New(renderer, context, surface, previewMode, DefaultRenderRate)
    End Sub
    Sub New(ByRef renderer As CodeIsle.Plugins.Renderers.IRenderPlugin, ByRef context As Object, ByRef surface As PictureBox, previewMode As Boolean, renderRate As Integer)
        _surface = surface
        _context = context
        _renderer = renderer
        _previewMode = previewMode
        _renderRate = renderRate
        AddHandler _surface.Paint, AddressOf Surface_Paint
        surfaceInvalidatorCancellationTokenSource = New System.Threading.CancellationTokenSource
        Task.Run(Sub() SurfaceInvalidatorAsync(surfaceInvalidatorCancellationTokenSource.Token), surfaceInvalidatorCancellationTokenSource.Token)
    End Sub

    Private Sub Surface_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)

        _renderer.Render(e, _context, _surface.DisplayRectangle.Size)
        If _previewMode Then
            e.Graphics.FillRectangle(New System.Drawing.Drawing2D.HatchBrush(Drawing2D.HatchStyle.LargeCheckerBoard, System.Drawing.Color.FromArgb(255 - (_context.PreviewOpacity / 100) * 255, Color.LightGray), System.Drawing.Color.FromArgb(255 - (_context.PreviewOpacity / 100) * 255, Color.White)), _surface.DisplayRectangle)
        End If
    End Sub
    Private Async Sub SurfaceInvalidatorAsync(token As System.Threading.CancellationToken)
        While Not token.IsCancellationRequested
            Await Task.Delay(_renderRate)
            _surface.Invalidate()
        End While
    End Sub
#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                surfaceInvalidatorCancellationTokenSource.Cancel()
                Task.WaitAll()
                RemoveHandler _surface.Paint, AddressOf Surface_Paint
                _surface = Nothing
                '_renderer = Nothing
                '_context = Nothing
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
