Imports System.Drawing
Imports System.Text
Imports System.Collections.Generic
Public Class Renderer : Implements Rendering.IRenderer, IDisposable

    Private stringAlignment As StringFormat
    Private Const MaximumFontSize = Int16.MaxValue
    Private backgroundBrush As SolidBrush
    Private foregroundBrush As SolidBrush

    Sub New(objects As List(Of IRenderObject))
        MyClass.Objects = objects
    End Sub

    Private Function BestFontSize(g As System.Drawing.Graphics, z As Size, f As Font, s As String) As Font
        Dim p As SizeF = g.MeasureString(s, f)
        Dim hRatio As Double = z.Height / p.Height
        Dim wRatio As Double = z.Width / p.Width
        Dim ratio As Double = Math.Min(hRatio, wRatio)
        Return New Font(f.FontFamily, CType(f.Size * ratio, Single), f.Style)
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                stringAlignment.Dispose()
                backgroundBrush.Dispose()
                foregroundBrush.Dispose()
                ' TODO: dispose managed state (managed objects).
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

    Public Property Objects As List(Of IRenderObject)

    Public Sub Render(args As IRenderArgs) Implements Rendering.IRenderer.Render
        For Each renderObject In Objects
            renderObject.Draw(args)
        Next
    End Sub
End Class


