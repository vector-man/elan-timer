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
End Class
