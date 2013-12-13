Imports Newtonsoft
Public Class JsonDatabase
    Private Const MaximumAttempts As Integer = 5
    Public Function Load(path As String, type As System.Type) As Object
        Dim data As Object = Nothing
        Dim attempts As Integer
        While (True)
            Try
                Using file As New System.IO.StreamReader(New System.IO.FileStream(path, IO.FileMode.OpenOrCreate, IO.FileAccess.Read, IO.FileShare.None))
                    data = Json.JsonConvert.DeserializeObject(file.ReadToEnd, type)
                End Using
                Exit While
            Catch ex As Exception
                If attempts < MaximumAttempts Then
                    Threading.Thread.Sleep(1000)
                    attempts += 1
                Else
                    Throw ex
                End If
            End Try
        End While
        Return data
    End Function
    Public Sub Save(path As String, data As Object)
        Dim attempts As Integer
        While (True)
            Try
                Using file As New System.IO.StreamWriter(New System.IO.FileStream(path, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None))
                    file.Write(Json.JsonConvert.SerializeObject(data))
                End Using
                Exit While
            Catch ex As System.IO.IOException
                If attempts < MaximumAttempts Then
                    Threading.Thread.Sleep(1000)
                    attempts += 1
                Else
                    Throw ex
                End If
            End Try
        End While
    End Sub
End Class
