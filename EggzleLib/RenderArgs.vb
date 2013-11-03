Public NotInheritable Class RenderArgs
    Private _args As IRenderArgs

    Sub New(args As IRenderArgs)
        _args = args
    End Sub
    Public ReadOnly Property ClipRectangle As System.Drawing.Rectangle
        Get
            Return _args.ClipRectangle
        End Get
    End Property
    Public ReadOnly Property Graphics As System.Drawing.Graphics
        Get
            Return _args.Graphics
        End Get
    End Property
    Public ReadOnly Property Font As System.Drawing.Font
        Get
            Return _args.Font
        End Get
    End Property
    Public ReadOnly Property BackgroundColor As System.Drawing.Color
        Get
            Return _args.BackgroundColor
        End Get
    End Property
    Public ReadOnly Property ForegroundColor As System.Drawing.Color
        Get
            Return _args.ForegroundColor
        End Get
    End Property
    Public ReadOnly Property SizeToFit As Boolean
        Get
            Return _args.SizeToFit
        End Get
    End Property
    Public ReadOnly Property Data As Object
        Get
            Return _args.Data
        End Get
    End Property
    Public ReadOnly Property FormatProvider As IFormatProvider
        Get
            Return _args.FormatProvider
        End Get
    End Property
    Public ReadOnly Property Format As String
        Get
            Return _args.Format
        End Get
    End Property
End Class
