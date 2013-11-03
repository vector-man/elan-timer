Namespace Settings
    Public Class Application
        Inherits CodeIsle.Data.DALBase
        Private _application As ApplicationModel
        Sub New()
            MyBase.New()
            'AddHandler MyBase.Load, AddressOf Application_Load
            'AddHandler MyBase.Save, AddressOf Application_Save
        End Sub
        Public Property AlwaysOnTop As Boolean
            Set(value As Boolean)
                _application.AlwaysOnTop = value
            End Set
            Get
                Return _application.AlwaysOnTop
            End Get
        End Property
        Public Property EnableAutomaticUpdateChecking As Boolean
            Set(value As Boolean)
                _application.EnableAutomaticUpdateChecking = value
            End Set
            Get
                Return _application.EnableAutomaticUpdateChecking
            End Get
        End Property
        Public Property NumberOfDaysBetweenUpdateChecks As Integer
            Set(value As Integer)
                _application.NumberOfDaysBetweenUpdateChecks = value
            End Set
            Get
                Return _application.NumberOfDaysBetweenUpdateChecks
            End Get
        End Property
        Public Property OpacityLevel As Integer
            Set(value As Integer)
                _application.OpacityLevel = value
            End Set
            Get
                Return _application.OpacityLevel
            End Get
        End Property
        Protected Overrides Sub Load()
            _application = Connection.QueryAndExecute(Of ApplicationModel)().GetFirst
            If _application Is Nothing Then
                _application = New ApplicationModel
            End If
        End Sub
        Protected Overrides Sub Save()
            Connection.Store(_application)
        End Sub

    End Class
End Namespace
