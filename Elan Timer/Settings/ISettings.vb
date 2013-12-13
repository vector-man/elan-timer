Namespace Settings
    Public Interface ISettings
        Sub Load()
        Sub Save()
        Sub ExportTo(path As String)
        Sub ImportFrom(path As String)
        Sub BeginEdit()
        Sub EndEdit()
        Sub CancelEdit()
    End Interface
End Namespace
