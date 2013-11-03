﻿Namespace Settings.Models
    Public Class LookModel
        Sub New()

        End Sub
        Sub New(font As Font, sizeToFit As Boolean, backgroundColor As Color, foregroundColor As Color, opacity As Integer, renderer As String)
            MyClass.Font = font
            MyClass.SizeToFit = sizeToFit
            MyClass.BackgroundColor = backgroundColor
            MyClass.ForegroundColor = foregroundColor
            MyClass.Opacity = opacity
            MyClass.Renderer = renderer
        End Sub
        Public Property Font As Font
        Public Property SizeToFit As Boolean
        Public Property BackgroundColor As Color
        Public Property ForegroundColor As Color
        Public Property Opacity As Integer
        Public Property Renderer As String
    End Class
End Namespace
