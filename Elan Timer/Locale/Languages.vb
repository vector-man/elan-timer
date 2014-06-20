Imports System.Reflection
Public Class Languages
    Private _path As String
    Private _default As String
    Private _languages As Dictionary(Of String, String)
    Sub New(path As String, [default] As String)
        _path = path
        _default = [default]
        Load()
    End Sub
    Private Sub Load()
        Dim directory = My.Computer.FileSystem.GetDirectories(_path)
        _languages = New Dictionary(Of String, String)()
        Dim defaultCulture = System.Globalization.CultureInfo.GetCultureInfo(_default)
        _languages.Add(defaultCulture.Name, defaultCulture.NativeName)
        For Each dir In directory
            Try
                Dim culture = System.Globalization.CultureInfo.GetCultureInfo(My.Computer.FileSystem.GetName(dir))
                _languages.Add(culture.Name, culture.NativeName)
            Catch ex As Exception

            End Try
        Next
    End Sub
    Public ReadOnly Property GetLanguages As Dictionary(Of String, String)
        Get
            Return _languages
        End Get
    End Property

    Public Function GetText(name As String) As String
        Return My.Resources.ResourceManager.GetString(name)
    End Function

    Public Sub SetLanguage(name As String)
        Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(name)
    End Sub
End Class
