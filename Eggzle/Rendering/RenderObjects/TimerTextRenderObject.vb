Imports Eggzle.CodeIsle.Timers

Public Class TimerTextRenderObject
    Inherits TextRenderObject

    Sub New(timer As TimerBase, font As Font, format As String, formatProvider As IFormatProvider, sizeToFit As Boolean, color As Color, stringFormat As StringFormat, visible As Boolean)
        MyBase.New(String.Empty, font, sizeToFit, color, stringFormat, visible)
        MyClass.Format = format
        MyClass.FormatProvider = formatProvider
        MyClass.Timer = timer
    End Sub
    Public Property Format As String
    Public Property FormatProvider As IFormatProvider
    Public Property Timer As TimerBase
    Overrides Sub Draw(args As IRenderArgs)
        MyBase.Text = String.Format(MyClass.FormatProvider, String.Concat("{0:", MyClass.Format, "}"), MyClass.Timer.Current)
        MyBase.Draw(args)
    End Sub
End Class
