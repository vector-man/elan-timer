Namespace Settings
    Public Class Actions
        Inherits SettingsBase
        Private Shared _connection As NDatabase.Odb.IOdb
        Private Shared _actions As List(Of ActionModel)

        Public Shared Function GetActions() As List(Of ActionModel)
            Return _actions
        End Function
#Region "Loading and Saving"
        Shared Sub New()
            Load()
            If _actions Is Nothing Then
                _actions = New List(Of ActionModel)
            End If
        End Sub
        Public Overloads Shared Sub Load()
            Using _connection = NDatabase.Odb.OdbFactory.Open(FileName)
                _actions = _connection.QueryAndExecute(Of ActionModel)()
            End Using
        End Sub

        Public Overloads Shared Sub Save()
            Using _connection = NDatabase.Odb.OdbFactory.Open(FileName)
                Dim acts = From actions In _connection.QueryAndExecute(Of ActionModel)()
                       Where Not _actions.Contains(actions)
                       Select actions

                For Each act In acts
                    _connection.Delete(act)
                Next
                For Each act In _actions
                    _connection.Store(act)
                Next
            End Using
        End Sub
#End Region
    End Class
End Namespace
