Imports System.Configuration
Imports System.IO
Imports System.Linq
Imports System.Xml.Linq
Imports System.Xml.XPath
Namespace Settings

    Public Class StyleSettings
        Inherits ApplicationSettingsBase

        <UserScopedSetting>
        <DefaultSettingValue("Calibri, 24pt, style=Bold")>
        Public Property DisplayFont As Font
            Get
                Return Me("DisplayFont")
            End Get
            Set(value As Font)
                Me("DisplayFont") = value
            End Set
        End Property

        <UserScopedSetting>
        <DefaultSettingValue("true")>
        Public Property GrowToFit As Boolean
            Get
                Return Me("GrowToFit")
            End Get
            Set(value As Boolean)
                Me("GrowToFit") = value
            End Set
        End Property

        <UserScopedSetting>
        <DefaultSettingValue("white")>
        Public Property BackgroundColor As Color
            Get
                Return Me("BackgroundColor")
            End Get
            Set(value As Color)
                Me("BackgroundColor") = value
            End Set
        End Property

        <UserScopedSetting>
        <DefaultSettingValue("silver")>
        Public Property ForegroundColor As Color
            Get
                Return Me("ForegroundColor")
            End Get
            Set(value As Color)
                Me("ForegroundColor") = value
            End Set
        End Property

        <UserScopedSetting>
        <DefaultSettingValue("100")>
        Public Property Opacity As Integer
            Get
                Return Me("Opacity")
            End Get
            Set(value As Integer)
                Me("Opacity") = value
            End Set
        End Property

        <UserScopedSetting>
        <DefaultSettingValue("d")>
        Public Property DisplayFormat As String
            Get
                Return Me("DisplayFormat")
            End Get
            Set(value As String)
                Me("DisplayFormat") = value
            End Set
        End Property
    End Class
End Namespace
