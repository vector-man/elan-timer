Imports Eggzle.CodeIsle.Timers

Public Class TimerTextRenderObject
    Inherits TextRenderObject

    Sub New(timer As TimerBase, font As Font, format As String, formatProvider As IFormatProvider, sizeToFit As Boolean, color As Color, stringFormat As StringFormat, visible As Boolean)
        MyBase.New(String.Empty, font, sizeToFit, color, stringFormat, visible)
        Me.Format = format
        Me.FormatProvider = formatProvider
        Me.Timer = timer
    End Sub
    Public Property Format As String
    Public Property FormatProvider As IFormatProvider
    Public Property Timer As TimerBase
    Overrides Sub Draw(args As IRenderArgs)
        MyBase.Text = String.Format(FormatProvider, String.Concat("{0:", Me.Format, "}"), Me.Timer.Current)
        MyBase.Draw(args)
    End Sub
End Class
