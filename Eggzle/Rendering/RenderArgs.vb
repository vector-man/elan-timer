Public Class RenderArgs : Implements IRenderArgs
    Public Sub New(clientRectangle As System.Drawing.Rectangle, graphics As System.Drawing.Graphics, font As System.Drawing.Font, backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color, sizeToFit As Boolean, data As Object, formatProvider As IFormatProvider, format As String, note As String)
        MyClass.ClientRectangle = clientRectangle
        MyClass.Graphics = graphics
        MyClass.Font = font
        MyClass.BackgroundColor = backgroundColor
        MyClass.ForegroundColor = foregroundColor
        MyClass.SizeToFit = sizeToFit
        MyClass.Data = data
        MyClass.FormatProvider = formatProvider
        MyClass.Format = format
        MyClass.Note = note
    End Sub
    Public Property BackgroundColor As Color Implements IRenderArgs.BackgroundColor

    Public Property ClientRectangle As Rectangle Implements IRenderArgs.ClientRectangle

    Public Property Data As Object Implements IRenderArgs.Data

    Public Property Font As Font Implements IRenderArgs.Font

    Public Property ForegroundColor As Color Implements IRenderArgs.ForegroundColor

    Public Property Graphics As Graphics Implements IRenderArgs.Graphics

    Public Property SizeToFit As Boolean Implements IRenderArgs.SizeToFit

    Public Property FormatProvider As IFormatProvider Implements IRenderArgs.FormatProvider

    Public Property Format As String Implements IRenderArgs.Format

    Public Property Note As String Implements IRenderArgs.Note
End Class
