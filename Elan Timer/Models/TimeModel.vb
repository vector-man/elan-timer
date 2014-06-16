Imports PropertyChanged
<ImplementPropertyChanged>
Public Class TimeModel
    Implements IImportable, IExportable
    Private _transporter As ITransporter
    Public Property Duration As TimeSpan

    Public Property CountUp As Boolean

    Public Property Restarts As Integer

    Public Property AlarmEnabled As Boolean

    Public Property AlarmName As String

    Public Property AlarmLoop As Boolean

    Public Property AlarmVolume As Integer

    Public Property NoteEnabled As Boolean

    Public Property Note As String

    Public Property AlertEnabled As Boolean
    Sub New()
    End Sub
    Sub New(transporter As ITransporter)
        _transporter = transporter
    End Sub
    'Sub New(transporter As ITransporter, timeSettings As TimeSettings)
    '    Me.New(timeSettings.Duration, timeSettings.CountUp, timeSettings.Restarts, timeSettings.AlarmEnabled, timeSettings.AlarmPath,
    '   timeSettings.AlarmLoop, timeSettings.AlarmVolume, timeSettings.NoteEnabled, timeSettings.Note, timeSettings.AlertEnabled)

    '    _transporter = transporter
    'End Sub
    'Sub New(duration As TimeSpan, countUp As Boolean, restarts As Integer, alarmEnabled As Boolean, alarmPath As String,
    '        alarmLoop As Boolean, alarmVolume As Integer, noteEnabled As Boolean, note As String, alertEnabled As Boolean)
    '    Me.Duration = duration
    '    Me.CountUp = countUp
    '    Me.Restarts = restarts
    '    Me.AlarmEnabled = alarmEnabled
    '    Me.AlarmPath = alarmPath
    '    Me.AlarmLoop = alarmLoop
    '    Me.AlarmVolume = alarmVolume
    '    Me.NoteEnabled = noteEnabled
    '    Me.Note = note
    '    Me.AlertEnabled = alertEnabled
    'End Sub

    Public Sub Import(stream As IO.Stream) Implements IImportable.Import
        Dim model As TimeModel
        model = _transporter.Import(Of TimeModel)(stream)
        Me.Duration = model.Duration
        Me.CountUp = model.CountUp
        Me.Restarts = model.Restarts
        Me.AlarmEnabled = model.AlarmEnabled
        Me.AlarmName = model.AlarmName
        Me.AlarmLoop = model.AlarmLoop
        Me.AlarmVolume = model.AlarmVolume
        Me.NoteEnabled = model.NoteEnabled
        Me.Note = model.Note
        Me.AlertEnabled = model.AlertEnabled
    End Sub


    Public Sub Export(stream As IO.Stream) Implements IExportable.Export
        _transporter.Export(Of TimeModel)(Me, stream)
    End Sub
End Class
