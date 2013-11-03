Imports System.Drawing
Namespace Information
    Public Interface IRenderInfo
        ReadOnly Property ForegroundColor As Color

        ReadOnly Property BackgroundColor As Color

        ReadOnly Property Font As Font

        ReadOnly Property SizeToFit As Boolean

        ReadOnly Property CanvasSize As Size
    End Interface
End Namespace