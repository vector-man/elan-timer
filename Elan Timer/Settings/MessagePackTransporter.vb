Imports MsgPack
Imports System.IO
Imports System.Reflection

Public Class MessagePackTransporter
    Implements ITransporter

    Public Function Import(Of T)(stream As IO.Stream) Implements ITransporter.Import
        'Try

        '    stream.Seek(0, SeekOrigin.Begin)

        '    Dim packer = New ObjectPacker()
        '    Dim dict As Dictionary(Of String, Object)
        '    dict = packer.Unpack(GetType(Dictionary(Of String, Object)), stream)

        '    For Each prop In GetType(T).GetProperties(BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.Instance)
        '        prop.SetValue(obj, dict(prop.Name), Nothing)
        '    Next
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString())
        'End Try

        Try

            Dim packer = New ObjectPacker()

            Return packer.Unpack(GetType(T), stream)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

        'Return obj

        'Dim serializer = MessagePackSerializer.Create(GetType(T))


        'Dim count As Long = stream.Length - 1
        'Dim data(count) As Byte

        'stream.Seek(0, SeekOrigin.Begin)

        'stream.Read(data, 0, count)

        'Return serializer.UnpackSingleObject(data)
    End Function

    Public Sub Export(Of T)(ByRef obj As Object, stream As IO.Stream) Implements ITransporter.Export
        'Try
        '    Dim packer = New ObjectPacker()
        '    Dim dict As New Dictionary(Of String, Object)

        '    For Each prop In GetType(T).GetProperties(BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.Instance)
        '        dict.Add(prop.Name, prop.GetValue(obj, Nothing))
        '    Next
        '    stream.Seek(0, SeekOrigin.Begin)
        '    packer.Pack(stream, dict)
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString())
        'End Try
        Dim packer = New ObjectPacker()
        packer.Pack(stream, obj)
        'Dim serializer = MessagePackSerializer.Create(obj.GetType())
        'Dim data As Byte() = serializer.PackSingleObject(obj)
        'stream.SetLength(0)
        'stream.Write(data, 0, data.Count())
    End Sub
End Class
