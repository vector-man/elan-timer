Imports PropertyChanged
Namespace Rendering
    <ImplementPropertyChanged>
    Public Class TextRenderable
        Implements IRenderable, IDisposable, IBindableComponent

        Const MaximumFontSize = 1000
        Private colorBrush As SolidBrush
        Sub New()
            Me.New(Nothing, System.Drawing.SystemFonts.DefaultFont, False, System.Drawing.Color.Black, New StringFormat(), True)
        End Sub
        Sub New(textRenderFormat As Func(Of String), font As Font, sizeToFit As Boolean, color As Color, stringFormat As StringFormat, visible As Boolean)
            MyClass.TextRenderFormat = textRenderFormat
            MyClass.Font = font
            colorBrush = New SolidBrush(color)
            MyClass.SizeToFit = sizeToFit
            MyClass.Visible = visible
            MyClass.StringFormat = stringFormat
        End Sub

        Public Property Visible As Boolean Implements IRenderable.Visible
        Public Property SizeToFit As Boolean
        Public Property Font As Font
        Public Property Color As Color Implements IRenderable.Color
            Get
                Return colorBrush.Color
            End Get
            Set(value As Color)
                colorBrush.Color = value
            End Set
        End Property
        Public Property StringFormat As StringFormat

        Private Function AppropriateFont(ByVal g As System.Drawing.Graphics, ByVal minFontSize As Integer, ByVal maxFontSize As Integer, ByVal layoutSize As Size, ByVal s As String, ByVal f As Font) As Font
            If maxFontSize = minFontSize Then
                f = New Font(f.FontFamily, minFontSize, f.Style)
            End If
            Dim extent As SizeF
            extent = g.MeasureString(s, f)

            If maxFontSize <= minFontSize Then
                Return f
            End If

            Dim hRatio As Single = layoutSize.Height / extent.Height
            Dim wRatio As Single = layoutSize.Width / extent.Width

            Dim ratio As Single = If((hRatio < wRatio), hRatio, wRatio)

            Dim newSize As Single = f.Size * ratio

            If newSize < minFontSize Then
                newSize = minFontSize
            ElseIf newSize > maxFontSize Then
                newSize = maxFontSize
            End If

            f = New Font(f.FontFamily, newSize, f.Style)

            Return f
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    colorBrush.Dispose()
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

        Public Property Rectangle As Rectangle Implements IRenderable.Rectangle
        Public Property Size As System.Drawing.Size
            Get
                Return Rectangle.Size
            End Get
            Set(value As System.Drawing.Size)
                Rectangle = New Rectangle(0, 0, value.Width, value.Height)
            End Set
        End Property
        Public Property TextRenderFormat As Func(Of String)
        Public Sub Render(e As PaintEventArgs) Implements IRenderable.Render
            e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            If (Visible) Then
                Dim largestFontSize As Long

                If (SizeToFit) Then
                    largestFontSize = MaximumFontSize
                Else
                    largestFontSize = Font.Size
                End If
                Dim text As String
                text = Me.TextRenderFormat().Invoke()
                Using textFont = AppropriateFont(e.Graphics, Font.Size, largestFontSize, Rectangle.Size, text, Font)
                    e.Graphics.DrawString(text, textFont, colorBrush, Rectangle, StringFormat)
                End Using
            End If
        End Sub

        Private _bindings As ControlBindingsCollection

        Public Event Disposed(sender As Object, e As EventArgs) Implements System.ComponentModel.IComponent.Disposed

        Public Property Site As System.ComponentModel.ISite Implements System.ComponentModel.IComponent.Site

        Public Property BindingContext As New BindingContext Implements IBindableComponent.BindingContext

        Public ReadOnly Property DataBindings As ControlBindingsCollection Implements IBindableComponent.DataBindings
            Get
                If (_bindings Is Nothing) Then
                    _bindings = New ControlBindingsCollection(Me)
                End If
                Return _bindings
            End Get
        End Property
    End Class
End Namespace