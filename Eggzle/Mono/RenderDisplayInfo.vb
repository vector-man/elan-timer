Imports Mono.Addins
Imports System
Imports System.Drawing
Namespace Information
    Public Class RenderInfo
        Implements EggzleLib.Information.IRenderInfo
        Private _foregroundColor As Color
        Private _backgroundColor As Color
        Private _font As Font
        Private _sizeToFit As Boolean
        Sub New(foregroundColor As Color, backgroundColor As Color, font As Font, sizeToFit As Boolean)
            _foregroundColor = foregroundColor
            _backgroundColor = backgroundColor
            _font = font
            _sizeToFit = sizeToFit
        End Sub
        Public ReadOnly Property ForegroundColor As Color Implements EggzleLib.Information.IRenderInfo.ForegroundColor
            Get
                Return _foregroundColor
            End Get
        End Property
        Public ReadOnly Property BackgroundColor As Color Implements EggzleLib.Information.IRenderInfo.BackgroundColor
            Get
                Return _backgroundColor
            End Get
        End Property
        Public ReadOnly Property Font As Font Implements EggzleLib.Information.IRenderInfo.Font
            Get
                Return _font
            End Get
        End Property
        Private ReadOnly Property SizeToFit As Boolean Implements EggzleLib.Information.IRenderInfo.SizeToFit
            Get
                Return _sizeToFit
            End Get
        End Property
    End Class

End Namespace