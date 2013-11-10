Public Interface IRenderArgs

    Property ClientRectangle As System.Drawing.Rectangle

    Property Graphics As System.Drawing.Graphics

    Property Font As System.Drawing.Font

    Property BackgroundColor As System.Drawing.Color

    Property ForegroundColor As System.Drawing.Color

    Property SizeToFit As Boolean

    Property Data As Object

    Property FormatProvider As IFormatProvider

    Property Format As String

    Property Note As String
End Interface
