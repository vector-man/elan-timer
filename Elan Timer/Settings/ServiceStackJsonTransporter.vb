Imports ServiceStack.Text
Public Class ServiceStackJsonTransporter
    Implements ITransporter


    Public Sub Export(Of T)(ByRef obj As Object, stream As IO.Stream) Implements ITransporter.Export
        JsonSerializer.SerializeToStream(obj, stream)
    End Sub

    Public Function Import(Of T)(stream As IO.Stream) Implements ITransporter.Import
        Try
            Return JsonSerializer.DeserializeFromStream(Of T)(stream)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Function
End Class
