Imports PropertyChanged
<ImplementPropertyChanged>
Public Class StyleModel
    Implements IImportable, IExportable

    Private _transporter As ITransporter

    Public Property DisplayFont As Font

    Public Property GrowToFit As Boolean

    Public Property BackgroundColor As Color

    Public Property ForegroundColor As Color

    Public Property Transparency As Integer

    Public Property DisplayFormat As String
    Sub New()
    End Sub
    Sub New(transporter As ITransporter)
        _transporter = transporter
    End Sub

    Public Sub Export(stream As IO.Stream) Implements IExportable.Export
        _transporter.Export(Of StyleModel)(Me, stream)
    End Sub

    Public Sub Import(stream As IO.Stream) Implements IImportable.Import
        Dim model As StyleModel
        model = _transporter.Import(Of StyleModel)(stream)

        DisplayFont = model.DisplayFont

        GrowToFit = model.GrowToFit

        BackgroundColor = model.BackgroundColor

        ForegroundColor = model.ForegroundColor

        Transparency = model.Transparency

        DisplayFormat = model.DisplayFormat
    End Sub
End Class
