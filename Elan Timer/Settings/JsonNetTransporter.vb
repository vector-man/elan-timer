Imports Newtonsoft.Json
Imports System.IO
Imports System.Reflection
Public Class JsonNetTransporter
    Implements ITransporter

    Public Function Import(Of T)(stream As IO.Stream) Implements ITransporter.Import
        stream.Seek(0, SeekOrigin.Begin)
        Using sr As New StreamReader(stream)
            Dim text As String = sr.ReadToEnd()
            Dim settings As New JsonSerializerSettings()
            settings.Error = AddressOf JsonError
            settings.TypeNameAssemblyFormat = Runtime.Serialization.Formatters.FormatterAssemblyStyle.Full
            settings.TypeNameHandling = TypeNameHandling.All
            Return JsonConvert.DeserializeObject(text, GetType(T), settings)
        End Using
    End Function

    Public Sub Export(Of T)(ByRef obj As Object, stream As IO.Stream) Implements ITransporter.Export
        stream.SetLength(0)

        Try
            Using sw As New StreamWriter(stream)
                Dim text As String = JsonConvert.SerializeObject(obj)
                sw.Write(text)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub JsonError(sender As Object, e As Newtonsoft.Json.Serialization.ErrorEventArgs)
        Throw New JsonSerializationException()
    End Sub
End Class
