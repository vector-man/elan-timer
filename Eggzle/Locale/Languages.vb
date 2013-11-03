Imports System.Reflection
Public Class Languages
    Private _path As String
    Private _default As String
    Private _cultures As List(Of System.Globalization.CultureInfo)
    Sub New(path As String, [default] As String)
        _path = path
        _default = [default]
        Load()
    End Sub
    Public Sub Load()
        Dim dir = My.Computer.FileSystem.GetDirectories(_path)
        _cultures = New List(Of System.Globalization.CultureInfo)
        _cultures.Add(System.Globalization.CultureInfo.GetCultureInfo(_default))
        For Each d In dir
            Try
                _cultures.Add(System.Globalization.CultureInfo.GetCultureInfo(My.Computer.FileSystem.GetName(d)))
            Catch ex As Exception

            End Try
        Next
    End Sub
    Public ReadOnly Property Cultures As List(Of System.Globalization.CultureInfo)
        Get
            Return _cultures
        End Get
    End Property

    Public Function GetText(name As String) As String
        Return My.Resources.ResourceManager.GetString(name)
    End Function

    Public Sub SetUICulture(name As String)
        Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(name)
    End Sub

    Public Sub SetUICulture(culture As System.Globalization.CultureInfo)
        Threading.Thread.CurrentThread.CurrentUICulture = culture
    End Sub
End Class
