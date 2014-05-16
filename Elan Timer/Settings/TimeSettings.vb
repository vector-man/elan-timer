Imports System.Configuration
Namespace Settings
    Public Class TimeSettings
        Inherits ApplicationSettingsBase
        ' Implements IImportable, IExportable

        ' Private _transporter As ITransporter

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
        <DefaultSettingValue("False")>
        Public Property NoteEnabled As Boolean
            Get
                Return Me("NoteEnabled")
            End Get
            Set(value As Boolean)
                Me("NoteEnabled") = value
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
        'Sub New(transporter As ITransporter)
        '    _transporter = transporter
        'End Sub
        'Public Sub Import(stream As IO.Stream) Implements IImportable.Import
        '    _transporter.Import(Of TimeSettings)(Me, stream)

        '    'Dim settings As TimeSettings = _transporter.Import(Of TimeSettings)(Me, stream)
        '    'Me.AlarmEnabled = settings.AlarmEnabled
        '    'Me.AlarmLoop = settings.AlarmLoop
        '    'Me.AlarmPath = settings.AlarmPath
        '    'Me.AlarmVolume = settings.AlarmVolume
        '    'Me.AlertEnabled = settings.AlertEnabled
        '    'Me.CountUp = settings.CountUp
        '    'Me.Duration = settings.Duration
        '    'Me.Note = settings.Note
        '    'Me.NoteEnabled = settings.NoteEnabled
        '    'Me.Restarts = settings.Restarts
        'End Sub

        'Public Sub Export(stream As IO.Stream) Implements IExportable.Export
        '    _transporter.Export(Of TimeSettings)(Me, stream)
        'End Sub
    End Class
End Namespace
