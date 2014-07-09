Imports ElanTimer.CodeIsle.Timers

Namespace Rendering
    Public Class TimerTextRenderable
        Inherits TextRenderable

        Sub New(timer As TimerBase, font As Font, format As String, formatProvider As IFormatProvider, sizeToFit As Boolean, color As Color, stringFormat As StringFormat, visible As Boolean)
            MyBase.New(String.Empty, font, sizeToFit, color, stringFormat, visible)
            Me.Format = format
            Me.FormatProvider = formatProvider
            Me.Timer = timer
        End Sub
        Public Property Format As String
        Public Property FormatProvider As IFormatProvider
        Public Property ShowCountUpPlusSymbol As Boolean
        Public Property Timer As TimerBase
        Private Const CountUpPlusSymbol As String = "+"
        Public Overrides Property Text As String
            Get
                Dim prefix As String = String.Empty
                Dim suffix As String = String.Empty
                If (ShowCountUpPlusSymbol) Then
                    If (My.Application.Culture.TextInfo.IsRightToLeft) Then
                        suffix = CountUpPlusSymbol
                    Else
                        prefix = CountUpPlusSymbol
                    End If
                End If

                Return String.Format(FormatProvider, String.Concat(prefix, "{0:", Me.Format, "}", suffix), Me.Timer.Current)
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property
    End Class
End Namespace
