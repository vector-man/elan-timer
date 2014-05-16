Imports System.Configuration
Namespace Settings
    Public Class TaskSettings
        Inherits ApplicationSettingsBase
        <UserScopedSetting>
        <DefaultSettingValue("")>
        Public Property Tasks As List(Of TaskModel)
            Get
                Return Me("Tasks")
            End Get
            Set(value As List(Of TaskModel))
                Me("Tasks") = value
            End Set
        End Property
    End Class
End Namespace
