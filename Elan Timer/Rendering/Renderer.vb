Imports System.Drawing
Imports System.Text
Imports System.Collections.Generic
Namespace Rendering
    Public Class Renderer : Implements IDisposable

        Private stringAlignment As StringFormat
        Private Const MaximumFontSize = Int16.MaxValue
        Dim _enabled As Boolean
        Private surfaceInvalidatorCancellationTokenSource As System.Threading.CancellationTokenSource

        Sub New(owner As Control)
            Me.Owner = owner
            AddHandler Me.Owner.Paint, AddressOf Surface_Paint
        End Sub

        Public Owner As Control

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If (Not Me.disposedValue) Then
                If (disposing) Then
                    surfaceInvalidatorCancellationTokenSource.Cancel()
                    RemoveHandler Owner.Paint, AddressOf Surface_Paint
                    Task.WaitAll()
                    Owner.Dispose()
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

        Public Property Renderables As New List(Of IRenderable)
        Public Property FramesPerSecond As Integer = 10
        Private Async Sub SurfaceInvalidatorAsync(token As System.Threading.CancellationToken)
            While Not token.IsCancellationRequested
                Await TaskEx.Delay(1000 / FramesPerSecond)
                Owner.Invalidate()
            End While
        End Sub


        Public Property Enabled As Boolean
            Get
                Return _enabled
            End Get
            Set(value As Boolean)
                _enabled = value
                If (Not _enabled) Then
                    surfaceInvalidatorCancellationTokenSource.Cancel()
                Else
                    surfaceInvalidatorCancellationTokenSource = New System.Threading.CancellationTokenSource
                    TaskEx.Run(Sub() SurfaceInvalidatorAsync(surfaceInvalidatorCancellationTokenSource.Token), surfaceInvalidatorCancellationTokenSource.Token)
                End If
            End Set
        End Property

        Private Sub Surface_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            For Each renderable As IRenderable In Renderables
                renderable.Render(e)
            Next
        End Sub
    End Class

End Namespace


