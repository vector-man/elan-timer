Imports Salar.Bois
Public Class BoisTransporter
    Implements ITransporter


    Public Sub Export(Of T)(ByRef obj As Object, stream As IO.Stream) Implements ITransporter.Export
        Try
            Dim serializer As New BoisSerializer()
            serializer.Serialize(obj, stream)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function Import(Of T)(stream As IO.Stream) Implements ITransporter.Import
        Dim serializer As New BoisSerializer()
        Return serializer.Deserialize(Of T)(stream)
    End Function
End Class
