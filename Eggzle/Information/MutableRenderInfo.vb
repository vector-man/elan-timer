Imports Mono.Addins
Imports System
Imports System.Drawing
Namespace Information
    Public NotInheritable Class MutableRenderInfo
        Inherits EggzleLib.Information.RenderInfo
        Sub New(canvasSize As Size, foregroundColor As System.Drawing.Color, backgroundColor As System.Drawing.Color, font As System.Drawing.Font, sizeToFit As Boolean)
            MyBase.New(canvasSize, foregroundColor, backgroundColor, font, sizeToFit)
        End Sub
        Public Overloads Property ForegroundColor As Color
            Get
                Return MyBase.ForegroundColor
            End Get
            Set(value As Color)
                MyBase.ForegroundColor = value
            End Set
        End Property
        Public Overloads Property BackgroundColor As Color
            Get
                Return MyBase.BackgroundColor
            End Get
            Set(value As Color)
                MyBase.BackgroundColor = value
            End Set
        End Property
        Public Overloads Property Font As Font
            Get
                Return MyBase.Font
            End Get
            Set(value As Font)
                MyBase.Font = value
            End Set
        End Property
        Public Overloads Property SizeToFit As Boolean
            Get
                Return MyBase.SizeToFit
            End Get
            Set(value As Boolean)
                MyBase.SizeToFit = value
            End Set
        End Property
        Public Overloads Property CanvasSize As Size
            Get
                Return MyBase.CanvasSize
            End Get
            Set(value As Size)
                MyBase.CanvasSize = value
            End Set
        End Property
    End Class
End Namespace