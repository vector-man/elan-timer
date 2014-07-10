Imports System.IO
Public Class Utils
    ' Framerate constant. This is equal to 10 frames per second.
    Public Const Framerate As Integer = 1000 / 10
    ' The object for all of the supported display formats for the timer (these appear in the 'Look' settings dialog).
    Public Shared ReadOnly DisplayFormats As New List(Of KeyValuePair(Of String, String)) From {
        {New KeyValuePair(Of String, String)("Standard", "d")},
        {New KeyValuePair(Of String, String)("No Deciseconds", "s")},
        {New KeyValuePair(Of String, String)("Total Seconds", "S")},
        {New KeyValuePair(Of String, String)("Verbal", "v")}
        }
    ''' <summary>
    ''' Gets all alarms from the Alarms folder.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAlarms() As List(Of KeyValuePair(Of String, String))
        Dim dict As New List(Of KeyValuePair(Of String, String))
        For Each alarm As String In My.Computer.FileSystem.GetFiles(Utils.GetAlarmsPath)
            dict.Add(New KeyValuePair(Of String, String)(Path.GetFileNameWithoutExtension(alarm), Path.GetFileName(alarm)))
        Next
        Return dict
    End Function
    Public Shared Function GetAlarmFullPath(name As String) As String
        Return Path.Combine(GetAlarmsPath(), name)
    End Function
    Public Shared Function GetDefaultAlarm()
        Return GetAlarms()(0).Value
    End Function
    Public Shared Sub ShowContextMenuStrip(control As Control, contextMenuStrip As ContextMenuStrip)
        Dim lowerLeftPoint As Point = New Point(0, control.Height)
        lowerLeftPoint = control.PointToScreen(lowerLeftPoint)
        contextMenuStrip.Show(lowerLeftPoint)
    End Sub
    Public Shared Function LimitTextLength(text As String, maximumLength As Long)
        If (text.Length > maximumLength) Then
            Return text.Substring(0, (maximumLength - 3)) & "..."
        Else
            Return text
        End If
    End Function
    Public Shared Function GetTimersPath() As String
        Return Path.Combine(GetDataPath, My.Settings.TimeFolder)
    End Function
    Public Shared Function GetAlarmsPath()
        Return Path.Combine(GetDataPath, My.Settings.AlarmFolder)
    End Function
    Public Shared Function GetDataPath() As String
        Dim root As String
        If (My.Settings.UseDocumentsDataFolder) Then
            root = Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, My.Application.Info.ProductName)
        Else
            root = Path.Combine(My.Application.Info.DirectoryPath, My.Settings.DataFolder)
        End If
        Return root
    End Function

    Public Shared Function GetStylesPath() As String
        Return Path.Combine(GetDataPath, My.Settings.StyleFolder)
    End Function

End Class
