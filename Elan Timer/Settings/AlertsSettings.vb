Imports System.Configuration
Imports PropertyChanged

Namespace Settings
    <ImplementPropertyChanged>
    Public Class AlertsSettings
        Inherits ApplicationSettingsBase
        Implements ISettings

        Sub New()
            MyClass.New(Nothing)
        End Sub
        Sub New(importerExporter As IImporterExporter)
            MyBase.New()
            Me.ImporterExporter = importerExporter
        End Sub

        <UserScopedSetting>
        <DefaultSettingValue("False")>
        Public Property AlarmPerRestart As Boolean
            Get
                Return Me("AlarmPerRestart")
            End Get
            Set(value As Boolean)
                Me("AlarmPerRestart") = value
            End Set
        End Property

        <UserScopedSetting>
        <DefaultSettingValue("True")>
        Public Property AlarmEnabled As Boolean
            Get
                Return Me("AlarmEnabled")
            End Get
            Set(value As Boolean)
                Me("AlarmEnabled") = value
            End Set
        End Property

        <UserScopedSetting>
        <DefaultSettingValue("True")>
        Public Property FlashTaskbar As Boolean
            Get
                Return Me("FlashTaskbar")
            End Get
            Set(value As Boolean)
                Me("FlashTaskbar") = value
            End Set
        End Property

        <UserScopedSetting>
        <DefaultSettingValue("False")>
        Public Property DisplayNoteEnabled As Boolean
            Get
                Return Me("DisplayNoteEnabled")
            End Get
            Set(value As Boolean)
                Me("DisplayNoteEnabled") = value
            End Set
        End Property

        <UserScopedSetting>
        Public Property AlarmName As String
            Get
                Return Me("AlarmName")
            End Get
            Set(value As String)
                Me("AlarmName") = value
            End Set
        End Property

        <UserScopedSetting>
        <DefaultSettingValue("False")>
        Public Property AlarmLoop As Boolean
            Get
                Return Me("AlarmLoop")
            End Get
            Set(value As Boolean)
                Me("AlarmLoop") = value
            End Set
        End Property

        <UserScopedSetting>
        <DefaultSettingValue("100")>
        Public Property AlarmVolume As Integer
            Get
                Return Me("AlarmVolume")
            End Get
            Set(value As Integer)
                Me("AlarmVolume") = value
            End Set
        End Property

        <UserScopedSetting>
        <DefaultSettingValue("False")>
        Public Property AlertEnabled As Boolean
            Get
                Return Me("AlertEnabled")
            End Get
            Set(value As Boolean)
                Me("AlertEnabled") = value
            End Set
        End Property

        Private Property ImporterExporter As IImporterExporter

        Public Sub Export(stream As IO.Stream) Implements IExportable.Export
            Dim model As New AlertsModel()
            model.AlarmEnabled = Me.AlarmEnabled
            model.AlarmLoop = Me.AlarmLoop
            model.AlarmName = Me.AlarmName
            model.AlarmVolume = Me.AlarmVolume
            model.AlertEnabled = Me.AlertEnabled
            model.AlarmPerRestart = Me.AlarmPerRestart
            model.FlashTaskbar = Me.FlashTaskbar
            ImporterExporter.Export(Of AlertsModel)(model, stream)
        End Sub

        Public Sub Import(stream As IO.Stream) Implements IImportable.Import
            Dim model As AlertsModel
            model = ImporterExporter.Import(Of AlertsModel)(stream)
            Me.AlarmEnabled = model.AlarmEnabled
            Me.AlarmName = model.AlarmName
            Me.AlarmLoop = model.AlarmLoop
            Me.AlarmVolume = model.AlarmVolume
            Me.AlertEnabled = model.AlertEnabled
            Me.DisplayNoteEnabled = model.DisplayNoteEnabled
            Me.AlarmPerRestart = model.AlarmPerRestart
            Me.FlashTaskbar = model.FlashTaskbar
        End Sub
    End Class

End Namespace