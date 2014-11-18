Imports System.IO
Imports SharpCompress
Imports System.Text

Public Class Bundler

    Private _settingsInfos As New List(Of SettingsInfo)()

    Public ReadOnly Property SettingsInfos As List(Of SettingsInfo)
        Get
            Return _settingsInfos
        End Get
    End Property

    Public Property Description As String = "Bundle"
    Public Property FileFilter As String
    Public Property FileExtension As String = ".box"
    Sub New()
        FileFilter = String.Format("{0} (*{1})|*{1}", Description, FileExtension)
    End Sub
    Public Sub Bundle(fileName As String)
        Using fs As FileStream = File.Open(fileName, FileMode.Create)
            Bundle(fs)
        End Using
    End Sub
    Public Sub Bundle(s As Stream)
        Using zip = Archive.Zip.ZipArchive.Create()
            For Each info As SettingsInfo In SettingsInfos
                Dim ms As MemoryStream = New MemoryStream()
                info.Settings.Export(ms)
                zip.AddEntry("bundle" + info.FileExtension, ms, True)
            Next

            zip.SaveTo(s, New Common.CompressionInfo() With {.Type = Common.CompressionType.BZip2})
        End Using
    End Sub
    Public Sub Unbundle(fileName As String)
        Using s As FileStream = File.OpenRead(fileName)
            Unbundle(s, Nothing)
        End Using
    End Sub
    Public Sub Unbundle(fileName As String, ByRef containedFiles() As String)
        Using s As FileStream = File.OpenRead(fileName)
            Unbundle(s, containedFiles)
        End Using
    End Sub
    Public Sub Unbundle(s As Stream, ByRef containedFiles() As String)
        Dim files As New List(Of String)
        Using bundle = Archive.ArchiveFactory.Open(s)
            For Each entry In bundle.Entries
                Dim fileName As String = entry.Key
                Dim ext As String = Path.GetExtension(fileName)

                Dim setting As SettingsInfo = SettingsInfos.Where(Function(f) f.FileExtension = ext).FirstOrDefault()

                If (setting Is Nothing) Then Return

                files.Add(entry.Key)
                Using entryStream = entry.OpenEntryStream()
                    setting.Settings.Import(entryStream)
                End Using

                'For Each info As SettingsInfo In SettingsInfos
                '    Dim ms As MemoryStream = New MemoryStream()
                '    info.Settings.Import(ms)
                '    zip.AddEntry("bundle" + info.FileExtension, s, True)
                'Next
            Next

            containedFiles = files.ToArray()
        End Using
    End Sub
    Public Function GetFilter(index As Integer)
        'Dim info As SettingsInfo = SettingsInfos(index)
        'Return String.Format("{0} (*{1})|*{1}", info.Description, info.FileExtension, info.FileExtension)
    End Function

    Public Function GetExtensions() As String()
        Dim extensions = SettingsInfos.Select(Function(s) s.FileExtension).ToList()
        extensions.Insert(0, FileExtension)
        Return extensions.ToArray()
    End Function
    Public Function GetFilters() As String()
        Dim filter As New List(Of String)
        Dim sb As New StringBuilder()

        For Each extension In GetExtensions()
            sb.Append("*")
            sb.Append(extension)
            sb.Append(", ")
        Next

        sb.Remove(sb.Length - 2, 2)

        Dim allExtensions As String = sb.ToString()

        filter.Add(FileFilter)
        For Each info As SettingsInfo In SettingsInfos
            filter.Add(String.Format("{0} (*{1})|*{1}", info.Description, info.FileExtension, info.FileExtension))
        Next
        Return filter.ToArray()
    End Function
End Class
