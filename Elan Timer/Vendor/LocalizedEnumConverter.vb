Public Class LocalizedEnumConverter
    Inherits Infralution.Localization.ResourceEnumConverter
    Public Sub New(type As Type)
        MyBase.New(type, My.Resources.Strings.ResourceManager)
    End Sub
End Class