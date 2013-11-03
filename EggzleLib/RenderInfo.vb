Imports System.Drawing
Namespace Information
    Public Class RenderInfo

        Private _foregroundColor As Color
        Private _backgroundColor As Color
        Private _font As Font
        Private _sizeToFit As Boolean
        Private _canvasSize As Size
        Sub New(ByRef canvasSize As Size, foregroundColor As Color, backgroundColor As Color, font As Font, sizeToFit As Boolean)
            _foregroundColor = foregroundColor
            _backgroundColor = backgroundColor
            _font = font
            _sizeToFit = sizeToFit
            _canvasSize = canvasSize
            ' _canvasSize = canvasSize
        End Sub
        Public Property ForegroundColor As Color
            Get
                Return _foregroundColor
            End Get
            Protected Set(value As Color)
                _foregroundColor = value
            End Set
        End Property
        Public Property BackgroundColor As Color
            Get
                Return _backgroundColor
            End Get
            Protected Set(value As Color)
                _backgroundColor = value
            End Set
        End Property
        Public Property Font As Font
            Get
                Return _font
            End Get
            Protected Set(value As Font)
                _font = value
            End Set
        End Property
        Public Property SizeToFit As Boolean
            Get
                Return _sizeToFit
            End Get
            Protected Set(value As Boolean)
                _sizeToFit = value
            End Set
        End Property
        Public Property CanvasSize As Size
            Get
                Return _canvasSize
            End Get
            Protected Set(value As Size)
                _canvasSize = value
            End Set
        End Property
    End Class

End Namespace