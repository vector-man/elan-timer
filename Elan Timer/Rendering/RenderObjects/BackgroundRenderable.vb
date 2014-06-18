Namespace Rendering
    Public Class BackgroundRenderable
        Implements IRenderable, IDisposable

        Private _brush As Brush

        Sub New(brush As Brush, visible As Boolean)
            Me.Visible = visible
            Me.Brush = brush
        End Sub
        Public Property Visible As Boolean Implements IRenderable.Visible
        Public Property Color As Color Implements IRenderable.Color
        Public Property Brush As Brush
            Get
                Return _brush
            End Get
            Set(value As Brush)
                If (_brush IsNot Nothing) Then
                    _brush.Dispose()
                End If
                _brush = value
            End Set
        End Property

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    _brush.Dispose()
                End If
            End If
            Me.disposedValue = True
        End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

        Public Sub Render(e As PaintEventArgs) Implements IRenderable.Render
            If (Visible) Then
                e.Graphics.FillRectangle(_brush, Rectangle)
            End If
        End Sub

        Public Property Rectangle As Rectangle Implements IRenderable.Rectangle
    End Class

End Namespace