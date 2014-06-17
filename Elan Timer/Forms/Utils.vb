Imports System.IO
Public Class Utils
    ''' <summary>
    ''' Gets all alarms from the Alarms folder.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAlarms(alarmsPath As String) As List(Of KeyValuePair(Of String, String))
        Dim dict As New List(Of KeyValuePair(Of String, String))
        For Each alarm As String In My.Computer.FileSystem.GetFiles(alarmsPath)
            dict.Add(New KeyValuePair(Of String, String)(Path.GetFileNameWithoutExtension(alarm), Path.GetFileName(alarm)))
        Next
        Return dict
    End Function
    Public Shared Function GetDefaultAlarm(alarmsPath)
        Return GetAlarms(alarmsPath)(0).Value
    End Function
    Public Shared Sub ShowContextMenuStrip(control As Control, contextMenuStrip As ContextMenuStrip)
        Dim ptLowerLeft As Point = New Point(0, control.Height)
        ptLowerLeft = control.PointToScreen(ptLowerLeft)
        contextMenuStrip.Show(ptLowerLeft)
    End Sub
End Class
