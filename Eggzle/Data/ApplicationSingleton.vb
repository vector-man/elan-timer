Namespace Settings
    Public Class ApplicationSingleton
        Private Shared ReadOnly lazy As Lazy(Of Application) = New Lazy(Of Application)(Function() New Application)
        Sub New()

        End Sub
        Public Shared ReadOnly Property Instance As Application
            Get
                Return lazy.Value
            End Get
        End Property
    End Class
End Namespace