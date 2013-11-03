Imports Mono.Addins
Public Class RendererAttribute
    Inherits CustomExtensionAttribute
    Sub New()

    End Sub
    Sub New(<NodeAttribute("Name")> Name As String)
        MyClass.Name = Name
    End Sub
    <NodeAttribute>
    Public Property Name As String
End Class
