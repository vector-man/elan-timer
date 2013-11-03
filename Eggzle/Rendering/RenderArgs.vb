Public Class RenderArgs : Implements EggzleLib.IRenderArgs
    Public Sub New(clipRectangle As System.Drawing.Rectangle, graphics As System.Drawing.Graphics, font As System.Drawing.Font, backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color, sizeToFit As Boolean, data As Object, formatProvider As IFormatProvider, format As String)
        MyClass.ClipRectangle = clipRectangle
        MyClass.Graphics = graphics
        MyClass.Font = font
        MyClass.BackgroundColor = backgroundColor
        MyClass.ForegroundColor = foregroundColor
        MyClass.SizeToFit = sizeToFit
        MyClass.Data = data
        MyClass.FormatProvider = formatProvider
        MyClass.Format = format
    End Sub
    Public Property BackgroundColor As Color Implements EggzleLib.IRenderArgs.BackgroundColor

    Public Property ClipRectangle As Rectangle Implements EggzleLib.IRenderArgs.ClipRectangle

    Public Property Data As Object Implements EggzleLib.IRenderArgs.Data

    Public Property Font As Font Implements EggzleLib.IRenderArgs.Font

    Public Property ForegroundColor As Color Implements EggzleLib.IRenderArgs.ForegroundColor

    Public Property Graphics As Graphics Implements EggzleLib.IRenderArgs.Graphics

    Public Property SizeToFit As Boolean Implements EggzleLib.IRenderArgs.SizeToFit

    Public Property FormatProvider As IFormatProvider Implements EggzleLib.IRenderArgs.FormatProvider

    Public Property Format As String Implements EggzleLib.IRenderArgs.Format
End Class
