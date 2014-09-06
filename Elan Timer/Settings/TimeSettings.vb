Imports System.Configuration
Namespace Settings
    Public Class TimeSettings
        Inherits ApplicationSettingsBase
        Implements IImportable, IExportable
        Sub New()
            MyClass.New(Nothing)
        End Sub
        Sub New(transporter As ITransporter)
            MyBase.New()
            Me.Transporter = transporter
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
        Public Property CountUp As Boolean
            Get
                Return Me("CountUp")
            End Get
            Set(value As Boolean)
                Me("CountUp") = value
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
        Public Property AlertEnabled As Boolean
            Get
                Return Me("AlertEnabled")
            End Get
            Set(value As Boolean)
                Me("AlertEnabled") = value
            End Set
        End Property

        Public Property Transporter As ITransporter

        Public Sub Import(stream As IO.Stream) Implements IImportable.Import
            Dim model As TimeModel
            model = Transporter.Import(Of TimeModel)(stream)
            Me.Duration = model.Duration
            Me.CountUp = model.CountUp
            Me.Restarts = model.Restarts
            Me.AlarmEnabled = model.AlarmEnabled
            Me.AlarmName = model.AlarmName
            Me.AlarmLoop = model.AlarmLoop
            Me.AlarmVolume = model.AlarmVolume
            Me.Note = model.Note
            Me.AlertEnabled = model.AlertEnabled
        End Sub

        Public Sub Export(stream As IO.Stream) Implements IExportable.Export
            Dim model As New TimeModel()
            model.AlarmEnabled = Me.AlarmEnabled
            model.AlarmLoop = Me.AlarmLoop
            model.AlarmName = Me.AlarmName
            model.AlarmVolume = Me.AlarmVolume
            model.AlertEnabled = Me.AlertEnabled
            model.CountUp = Me.CountUp
            model.Duration = Me.Duration
            model.Note = Me.Note
            model.Restarts = Me.Restarts
            Transporter.Export(Of TimeModel)(model, stream)
        End Sub
    End Class
End Namespace
