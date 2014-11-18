Imports System.Configuration
Imports System.IO

Namespace Settings
    Public Class TaskSettings
        Inherits ApplicationSettingsBase
        Implements ISettings
        Sub New()
            MyClass.New(Nothing)
        End Sub
        Sub New(transporter As IImporterExporter)
            MyBase.New()
            Me.Transporter = transporter
        End Sub
        <UserScopedSetting>
        <DefaultSettingValue("")>
        Public Property Tasks As List(Of TaskModel)
            Get
                Return Me("Tasks")
            End Get
            Set(value As List(Of TaskModel))
                Me("Tasks") = value
            End Set
        End Property
        Public Property Transporter As IImporterExporter
        Public Sub Export(stream As IO.Stream) Implements IExportable.Export
            Dim model As New TasksModel()

            model.Tasks = Me.Tasks

            Transporter.Export(Of TasksModel)(model, stream)
        End Sub

        Public Sub Import(stream As IO.Stream) Implements IImportable.Import
            Dim model As TasksModel
            model = Transporter.Import(Of TasksModel)(stream)
            If model.Tasks.Where(Function(t) Not [Enum].IsDefined(GetType(TimerEvent), t.Event)).Count > 0 Then
                Throw New FileFormatException()
            End If
            Me.Tasks = model.Tasks
        End Sub
    End Class
End Namespace
