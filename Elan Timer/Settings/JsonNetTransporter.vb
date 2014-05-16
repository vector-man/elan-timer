Imports Newtonsoft.Json
Imports System.IO
Imports System.Reflection
Public Class JsonNetTransporter
    Implements ITransporter

    Public Function Import(Of T)(stream As IO.Stream) Implements ITransporter.Import
        Try
            stream.Seek(0, SeekOrigin.Begin)
            Using sr As New StreamReader(stream)
                Dim text As String = sr.ReadToEnd()
                Return JsonConvert.DeserializeObject(text, GetType(T))
            End Using
            'stream.Seek(0, SeekOrigin.Begin)
            'Using sr As New StreamReader(stream)
            '    Dim text As String = sr.ReadToEnd()
            '    Dim dict As Dictionary(Of String, Object) = JSON.ToObject(text, GetType(Dictionary(Of String, Object)))

            '    For Each prop In GetType(T).GetProperties(BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.Instance)
            '        prop.SetValue(obj, dict(prop.Name), Nothing)
            '    Next
            'End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Function

    Public Sub Export(Of T)(ByRef obj As Object, stream As IO.Stream) Implements ITransporter.Export
        stream.SetLength(0)

        Try
            Using sw As New StreamWriter(stream)
                ' Dim params As JSONParameters = New JSONParameters()
                '    params.UsingGlobalTypes = False
                ' params.UseExtensions = False
                Dim text As String = JsonConvert.SerializeObject(obj)
                sw.Write(text)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

        'stream.SetLength(0)

        'Dim dict = New Dictionary(Of String, Object)
        'For Each prop In GetType(T).GetProperties(BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.Instance)
        '    dict.Add(prop.Name, prop.GetValue(obj, Nothing))
        'Next
        'Using sw As New StreamWriter(stream)
        '    Dim params As JSONParameters = New JSONParameters()
        '    params.UsingGlobalTypes = False
        '    params.UseExtensions = False
        '    Dim text As String = JSON.ToJSON(dict, params)
        '    sw.Write(text)
        'End Using
    End Sub
End Class
