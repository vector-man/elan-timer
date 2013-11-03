Public Class DatabaseSingleton
    Private Shared _instance As NDatabase.Odb.IOdb
    Private Shared lock As Object = New Object
    Private Shared ReadOnly databasePath As String = My.Application.Info.DirectoryPath & "\database.odb"
    Public Shared ReadOnly Property Instance As NDatabase.Odb.IOdb
        Get
            If (_instance Is Nothing) Then
                SyncLock lock
                    If (_instance Is Nothing) Then
                        _instance = NDatabase.Odb.OdbFactory.Open(databasePath)
                    End If
                End SyncLock
            End If
            Return _instance
        End Get
    End Property



End Class
