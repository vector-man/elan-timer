'Namespace CodeIsle.Data
'    Public Class SettingsData
'        Inherits DALBase

'        Public Function GetActions() As List(Of ActionModel)
'            Dim result = Connection.QueryAndExecute(Of ActionModel)()
'            Return result
'        End Function
'        Public Function NewActions() As List(Of ActionModel)
'            Return New List(Of ActionModel)
'        End Function
'        Public Function UpdateActions(settings As List(Of ActionModel)) As NDatabase.Odb.OID
'            Dim result = Connection.Store(settings)
'            Connection.Commit()
'            Return result
'        End Function
'        Public Function NewApplication() As ApplicationModel
'            Return New ApplicationModel
'        End Function
'        Public Function UpdateApplication(settings As ApplicationModel) As NDatabase.Odb.OID
'            Dim result = Connection.Store(settings)
'            Connection.Commit()
'            Return result
'        End Function
'        Public Function GetApplication() As ApplicationModel
'            Dim result = Connection.QueryAndExecute(Of ApplicationModel)().GetFirst
'            Debug.Print(Connection.QueryAndExecute(Of ApplicationModel)().Count)
'            Return result
'        End Function
'        Public Function DeleteObject(settings As Object)
'            Dim result = Connection.Delete(settings)
'            Return result
'        End Function
'    End Class
'End Namespace
