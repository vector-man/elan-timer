Namespace CodeIsle.Plugins
    Public Interface IPlugin
        Sub Load()
        Sub Save()
        Sub Install()
        Sub Uninstall()
        Sub ShowSettigs()

        ReadOnly Property Id As System.Guid
        ReadOnly Property Name As String
        ReadOnly Property Description As String
        ReadOnly Property Version As Version
        ReadOnly Property AuthorName As String
        ReadOnly Property AuthorWebsite As String
        ReadOnly Property AuthorEmail As String
    End Interface
End Namespace