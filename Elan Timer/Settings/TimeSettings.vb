Imports System.Configuration
Namespace Settings
    Public Class TimeSettings
        Inherits ApplicationSettingsBase
        Implements IImportable, IExportable
        Sub New()
            MyClass.New(Nothing)
        End Sub
        Sub New(importerExporter As IImporterExporter)
            MyBase.New()
            Me.ImporterExporter = importerExporter
        End Sub
        <UserScopedSetting>
        <DefaultSettingValue("0:5:0")>
        Public Property Duration As TimeSpan
            Get
                Return Me("Duration")
            End Get
            Set(value As TimeSpan)
                Me("Duration") = value
            End Set
        End Property

        <UserScopedSetting>
        <DefaultSettingValue("False")>
        Public Property CountUpwards As Boolean
            Get
                Return Me("CountUpwards")
            End Get
            Set(value As Boolean)
                Me("CountUpwards") = value
            End Set
        End Property

        <UserScopedSetting>
        <DefaultSettingValue("0")>
        Public Property Restarts As Integer
            Get
                Return Me("Restarts")
            End Get
            Set(value As Integer)
                Me("Restarts") = value
            End Set
        End Property

        <UserScopedSetting>
        Public Property Note As String
            Get
                Return Me("Note")
            End Get
            Set(value As String)
                Me("Note") = value
            End Set
        End Property
        <UserScopedSetting>
        <DefaultSettingValue("False")>
        Public Property Synchronize As Boolean
            Get
                Return Me("Synchronize")
            End Get
            Set(value As Boolean)
                Me("Synchronize") = value
            End Set
        End Property


        Public Property ImporterExporter As IImporterExporter

        Public Sub Import(stream As IO.Stream) Implements IImportable.Import
            Dim model As TimeModel
            model = ImporterExporter.Import(Of TimeModel)(stream)
            Me.Note = model.Note
            Me.Duration = model.Duration
            Me.CountUpwards = model.CountUpwards
            Me.Restarts = model.Restarts
            Me.Synchronize = model.Synchronize
        End Sub

        Public Sub Export(stream As IO.Stream) Implements IExportable.Export
            Dim model As New TimeModel()
            model.CountUpwards = Me.CountUpwards
            model.Duration = Me.Duration
            model.Note = Me.Note
            model.Restarts = Me.Restarts
            model.Synchronize = Me.Synchronize

            ImporterExporter.Export(Of TimeModel)(model, stream)
        End Sub
    End Class
End Namespace
