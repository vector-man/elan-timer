Imports System.Configuration
Imports System.IO
Imports System.Linq
Imports System.Xml.Linq
Imports System.Xml.XPath
Imports Salar.Bois
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
        '<UserScopedSetting>
        '<DefaultSettingValue("Calibri")>
        '<BoisMember>
        'Public Property FontFamily As String
        '    Get
        '        Return Me("FontFamily")
        '    End Get
        '    Set(value As String)
        '        Me("FontFamily") = value
        '    End Set
        'End Property
        '<UserScopedSetting>
        '<DefaultSettingValue("1")>
        'Public Property FontStyle As Integer
        '    Get
        '        Return Me("FontStyle")
        '    End Get
        '    Set(value As Integer)
        '        Me("FontStyle") = value
        '    End Set
        'End Property
        '<UserScopedSetting>
        '<DefaultSettingValue("24")>
        'Public Property FontSize As Single
        '    Get
        '        Return Me("FontSize")
        '    End Get
        '    Set(value As Single)
        '        Me("FontSize") = value
        '    End Set
        'End Property


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
        'Sub Import(fileName As String)
        '    ' Dim appSettings = My.MySettings.Default
        '    Try
        '        Dim config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal)

        '        Dim appSettingsXmlName As String = "ElanTimer.Settings.StyleSettings" ' Me.SettingsKey '"ElanTimer.Settings.StyleSettings" '= My.MySettings.Default.Context("GroupName").ToString()
        '        ' returns "MyApplication.Properties.Settings";

        '        ' Open settings file as XML
        '        ' Dim import__1 = XDocument.Load(fileName)
        '        ' Get the whole XML inside the settings node
        '        'Dim settings = import__1.Element("configuration").Element("userSettings").Element(appSettingsXmlName)
        '        Dim settings As String = XDocument.Load(fileName).ToString()
        '        config.GetSectionGroup("userSettings").Sections(appSettingsXmlName).SectionInformation().SetRawXml(settings.ToString())
        '        ' config.Save(ConfigurationSaveMode.Modified)
        '        ConfigurationManager.
        '        ' ConfigurationManager.RefreshSection("userSettings")
        '        ' appSettings.Reload()
        '    Catch generatedExceptionName As Exception
        '        ' Should make this more specific
        '        ' Could not import settings.
        '        ' from last set saved, not defaults
        '        ' appSettings.Reload()
        '    End Try
        'End Sub
        'Public Sub Export(fileName As String)
        '    ' Properties.Settings.[Default].Save()
        '    Try
        '        Dim config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal)
        '        Using output As FileStream = File.OpenWrite(fileName)
        '            output.SetLength(0)
        '            Using sw As New StreamWriter(output)
        '                sw.Write(config.GetSectionGroup("userSettings").Sections("ElanTimer.Settings.StyleSettings").SectionInformation().GetRawXml())
        '            End Using
        '        End Using


        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString())
        '    End Try
        'End Sub


        'Public Sub Import(stream As IO.Stream) Implements IImportable.Import
        '    Dim settings As StyleSettings
        '    _transporter.Import(Of StyleSettings)(settings, stream)

        '    Me.BackgroundColor = settings.BackgroundColor
        '    Me.DisplayFormat = settings.DisplayFormat
        '    Me.FontFamily = settings.FontFamily
        '    Me.FontSize = settings.FontSize
        '    Me.FontStyle = settings.FontStyle
        '    Me.ForegroundColor = settings.ForegroundColor
        '    Me.GrowToFit = settings.GrowToFit
        '    Me.Opacity = settings.Opacity
        'End Sub


        'Public Sub Export(stream As IO.Stream) Implements IExportable.Export
        '    _transporter.Export(Of StyleSettings)(Me, stream)
        'End Sub
    End Class
End Namespace
