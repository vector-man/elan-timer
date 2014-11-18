Public Class AlertsModel
    Implements ICloneable, IImportable, IExportable

    Public Property AlarmEnabled As Boolean

    Public Property AlarmName As String

    Public Property AlarmLoop As Boolean

    Public Property AlarmVolume As Integer

    Public Property AlertEnabled As Boolean

    Public Property DisplayNoteEnabled As Boolean

    Public Property AlarmPerRestart As Boolean

    Public Function Clone() As Object Implements ICloneable.Clone
        Return New AlertsModel() With {.AlarmEnabled = Me.AlarmEnabled,
                                      .AlarmLoop = Me.AlarmLoop,
                                      .AlarmName = Me.AlarmName,
                                      .AlarmVolume = Me.AlarmVolume,
                                      .AlertEnabled = Me.AlertEnabled,
                                      .DisplayNoteEnabled = Me.DisplayNoteEnabled,
                                      .AlarmPerRestart = Me.AlarmPerRestart}
    End Function

    Public Sub Export(stream As IO.Stream) Implements IExportable.Export

    End Sub

    Public Sub Import(stream As IO.Stream) Implements IImportable.Import

    End Sub
End Class
