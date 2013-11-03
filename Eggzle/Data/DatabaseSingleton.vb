Public Class DatabaseSingleton
    Private Shared _instance As CodeIsle.Data.SettingsData
    Private Shared lock As Object = New Object
    Public Shared ReadOnly Property Instance As CodeIsle.Data.SettingsData
        Get
            If (_instance Is Nothing) Then
                SyncLock lock
                    If (_instance Is Nothing) Then
                        _instance = New CodeIsle.Data.SettingsData
                    End If
                End SyncLock
            End If
            Return _instance
        End Get
    End Property



End Class
