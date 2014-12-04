Namespace Rendering
    Public Class RenderManager : Implements IDisposable
        Private _renderer As Renderer
        Private _surface As Rendering.Surface

        Sub New()
            _surface = New Surface()
            _renderer = New Renderer(_surface)
        End Sub

        Public Sub Start()
            If (Not Renderer.Enabled) Then
                Renderer.Enabled = True
            End If
        End Sub

        Public Sub [Stop]()
            If (Renderer.Enabled) Then
                Renderer.Enabled = False
            End If
        End Sub

        Public Function Running()
            Return Renderer.Enabled
        End Function

        Public ReadOnly Property Surface As Surface
            Get
                Return _surface
            End Get
        End Property

        Public ReadOnly Property Renderer As Renderer
            Get
                Return _renderer
            End Get
        End Property

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    Me.Stop()
                    Surface.Dispose()
                    Renderer.Dispose()
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
End Namespace