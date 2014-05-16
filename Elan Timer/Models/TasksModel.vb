Imports PropertyChanged
<ImplementPropertyChanged>
Public Class TasksModel
    Implements IImportable, IExportable
    Private _transporter As ITransporter
    Sub New(transporter As ITransporter)
        _transporter = transporter
    End Sub
    Public Sub Export(stream As IO.Stream) Implements IExportable.Export
        _transporter.Export(Of TasksModel)(Me, stream)
    End Sub

    Public Sub Import(stream As IO.Stream) Implements IImportable.Import
        Dim model As TasksModel
        model = _transporter.Import(Of TasksModel)(stream)

        Me.Tasks.AddRange(model.Tasks)
    End Sub
    Public Property Tasks As List(Of TaskModel)
End Class
