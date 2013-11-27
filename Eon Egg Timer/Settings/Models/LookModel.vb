Namespace Settings.Models
    Public Class LookModel
        Sub New()

        End Sub
        Sub New(font As Font, growToFit As Boolean, backgroundColor As Color, foregroundColor As Color, opacity As Integer, renderer As String, displayFormat As String)
            MyClass.Font = font
            MyClass.GrowToFit = growToFit
            MyClass.BackgroundColor = backgroundColor
            MyClass.ForegroundColor = foregroundColor
            MyClass.Opacity = opacity
            MyClass.Renderer = renderer
            MyClass.DisplayFormat = displayFormat
        End Sub
        Public Property Font As Font
        Public Property GrowToFit As Boolean
        Public Property BackgroundColor As Color
        Public Property ForegroundColor As Color
        Public Property Opacity As Integer
        Public Property Renderer As String
        Public Property DisplayFormat
    End Class
End Namespace
