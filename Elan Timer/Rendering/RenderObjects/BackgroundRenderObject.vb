Public Class BackgroundRenderObject
    Implements IRenderObject, IDisposable

    Private colorBrush As SolidBrush
    Sub New(color As Color, visible As Boolean)
        Me.Visible = visible
        colorBrush = New SolidBrush(color)
    End Sub
    Public Sub Draw(args As IRenderArgs) Implements IRenderObject.Draw
        If (Visible) Then
            args.Graphics.FillRectangle(colorBrush, args.Rectangle)
        End If
    End Sub
    Public Property Visible As Boolean Implements IRenderObject.Visible
    Public Property Color As Color
        Get
            Return colorBrush.Color
        End Get
        Set(value As Color)
            colorBrush.Color = value
        End Set
    End Property

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                colorBrush.Dispose()
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

End Class
