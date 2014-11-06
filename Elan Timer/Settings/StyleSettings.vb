Imports System.Configuration
Imports System.IO
Imports System.Linq
Imports System.Xml.Linq
Imports System.Xml.XPath
Namespace Settings

    Public Class StyleSettings
        Inherits ApplicationSettingsBase
        Implements IImportable, IExportable '
        Sub New()
            MyClass.New(Nothing)
        End Sub
        Sub New(transporter As IImporterExporter)
            MyBase.New()
            Me.Transporter = transporter
        End Sub
        <UserScopedSetting>
        <DefaultSettingValue("monoMMM_5, 12pt, style=Bold")>
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
        <DefaultSettingValue("255, 128, 0")>
        Public Property BackgroundColor As Color
            Get
                Return Me("BackgroundColor")
            End Get
            Set(value As Color)
                Me("BackgroundColor") = value
            End Set
        End Property

        <UserScopedSetting>
        <DefaultSettingValue("White")>
        Public Property ForegroundColor As Color
            Get
                Return Me("ForegroundColor")
            End Get
            Set(value As Color)
                Me("ForegroundColor") = value
            End Set
        End Property

        <UserScopedSetting>
        <DefaultSettingValue("0")>
        Public Property Transparency As Integer
            Get
                Return Me("Transparency")
            End Get
            Set(value As Integer)
                Me("Transparency") = value
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
        Public Property Transporter As IImporterExporter
        Public Sub Export(stream As IO.Stream) Implements IExportable.Export
            Dim model As New StyleModel
            model.BackgroundColor = Me.BackgroundColor
            model.DisplayFont = Me.DisplayFont
            model.DisplayFormat = Me.DisplayFormat
            model.ForegroundColor = Me.ForegroundColor
            model.GrowToFit = Me.GrowToFit
            model.Transparency = 100 - Me.Transparency
            Transporter.Export(Of StyleModel)(model, stream)
        End Sub

        Public Sub Import(stream As IO.Stream) Implements IImportable.Import
            Dim model As StyleModel
            model = Transporter.Import(Of StyleModel)(stream)

            If (model.DisplayFont Is Nothing) Then
                Throw New FileFormatException("DisplayFont cannot be null.")
            End If

            DisplayFont = model.DisplayFont

            GrowToFit = model.GrowToFit

            BackgroundColor = model.BackgroundColor

            ForegroundColor = model.ForegroundColor

            Transparency = model.Transparency

            DisplayFormat = model.DisplayFormat
        End Sub
    End Class
End Namespace
