Imports System.IO
Public Class Utils
    Private Shared toolTipMain As New ToolTip
    ' Framerate constant. This is equal to 10 frames per second.
    Public Const Framerate As Integer = 1000 / 10
    ' The object for language settings, set with the default language.
    Public Shared ReadOnly Languages As New Languages(My.Application.Info.DirectoryPath, My.Settings.DefaultLanguage)
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

    ''' <summary>
    ''' Sets strings for localization.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub SetStrings()
        ' FormMain.
        FormMain.SuspendLayout()

        FormMain.ToolStripMenuItemNewTimer.Text = My.Resources.Strings.MenuNewTimer
        FormMain.ToolStripMenuItemEditTimer.Text = My.Resources.Strings.MenuEditTimer
        FormMain.ToolStripMenuItemTasks.Text = My.Resources.Strings.MenuTasks
        FormMain.ToolStripMenuItemStyle.Text = My.Resources.Strings.MenuStyle
        FormMain.ToolStripMenuItemMisc.Text = My.Resources.Strings.MenuMisc
        FormMain.ToolStripMenuItemAlwaysOnTop.Text = My.Resources.Strings.MenuAlwaysOnTop
        FormMain.ToolStripMenuItemHelp.Text = My.Resources.Strings.MenuHelp
        FormMain.ToolStripMenuItemCompact.Text = My.Resources.Strings.MenuCompact
        FormMain.ToolStripMenuItemFullScreen.Text = My.Resources.Strings.MenuFullSreen
        FormMain.ToolStripMenuItemHelp.Text = My.Resources.Strings.MenuHelp
        FormMain.ToolStripMenuItemHelpOnline.Text = My.Resources.Strings.MenuHelpOnline
        FormMain.ToolStripMenuItemAboutElanTimer.Text = My.Resources.Strings.About
        FormMain.ToolStripMenuItemCheckForUpdates.Text = My.Resources.Strings.MenuCheckForUpdates
        FormMain.ToolStripMenuItemExit.Text = My.Resources.Strings.MenuExit

        FormMain.ToolStripButtonNewTimer.Text = My.Resources.Strings.MenuNewTimer
        FormMain.ToolStripButtonReset.Text = My.Resources.Strings.Reset

        FormMain.ResumeLayout()

        ' DialogAbout.
        AboutDialog.SuspendLayout()

        AboutDialog.Text = My.Resources.Strings.About
        AboutDialog.LinkLabelLicense.Text = My.Resources.Strings.License
        AboutDialog.ButtonOk.Text = My.Resources.Strings.Ok

        AboutDialog.ResumeLayout()

        ' DialogLookSettings.
        StyleSettingsDialog.SuspendLayout()

        StyleSettingsDialog.Text = My.Resources.Strings.Style
        StyleSettingsDialog.LabelRenderer.Text = My.Resources.Strings.DisplayFormat
        StyleSettingsDialog.LabelForegroundColor.Text = My.Resources.Strings.ForegroundColor
        StyleSettingsDialog.LabelBackgroundColor.Text = My.Resources.Strings.BackgroundColor
        StyleSettingsDialog.LabelFont.Text = My.Resources.Strings.Font
        StyleSettingsDialog.CheckBoxGrowToFit.Text = My.Resources.Strings.GrowToFit
        StyleSettingsDialog.LabelTransparency.Text = My.Resources.Strings.Transparency
        StyleSettingsDialog.ButtonOptions.Text = My.Resources.Strings.Load
        StyleSettingsDialog.ButtonOK.Text = My.Resources.Strings.Ok
        StyleSettingsDialog.ButtonCancel.Text = My.Resources.Strings.Cancel

        StyleSettingsDialog.ResumeLayout()

        ' DialogTaskSettings.
        TaskSettingsDialog.SuspendLayout()

        toolTipMain.SetToolTip(TaskSettingsDialog.ButtonAdd, My.Resources.Strings.Add)
        toolTipMain.SetToolTip(TaskSettingsDialog.ButtonRemove, My.Resources.Strings.Remove)
        toolTipMain.SetToolTip(TaskSettingsDialog.ButtonMoveUp, My.Resources.Strings.MoveUp)
        toolTipMain.SetToolTip(TaskSettingsDialog.ButtonMoveDown, My.Resources.Strings.MoveDown)
        TaskSettingsDialog.MenuItemExportAll.Text = My.Resources.Strings.ExportAll
        TaskSettingsDialog.MenuItemExportSelected.Text = My.Resources.Strings.ExportSelected
        TaskSettingsDialog.OlvColumnName.Text = My.Resources.Strings.HeaderName
        TaskSettingsDialog.OlvColumnEvent.Text = My.Resources.Strings.HeaderEvent
        TaskSettingsDialog.OlvColumnCommand.Text = My.Resources.Strings.HeaderCommand
        TaskSettingsDialog.OlvColumnArguments.Text = My.Resources.Strings.HeaderArguments

        TaskSettingsDialog.OlvColumnName.Text = My.Resources.Strings.HeaderName
        TaskSettingsDialog.OlvColumnEvent.Text = My.Resources.Strings.HeaderEvent
        TaskSettingsDialog.OlvColumnCommand.Text = My.Resources.Strings.HeaderCommand
        TaskSettingsDialog.OlvColumnArguments.Text = My.Resources.Strings.HeaderArguments

        TaskSettingsDialog.ResumeLayout()

        TimerSettingsDialog.SuspendLayout()

        TimerSettingsDialog.GroupBoxDuration.Text = My.Resources.Strings.Duration
        TimerSettingsDialog.LabelRestarts.Text = My.Resources.Strings.Restarts
        TimerSettingsDialog.CheckBoxCountUp.Text = My.Resources.Strings.CountUp

        TimerSettingsDialog.CheckBoxAlarmSet.Text = My.Resources.Strings.Alarm
        TimerSettingsDialog.CheckBoxLoop.Text = My.Resources.Strings.LoopAlarm
        TimerSettingsDialog.CheckBoxNote.Text = My.Resources.Strings.Note


        TimerSettingsDialog.ButtonSet.Text = My.Resources.Strings.Start
        TimerSettingsDialog.ButtonStart.Text = My.Resources.Strings.SetTimer
        TimerSettingsDialog.ButtonCancel.Text = My.Resources.Strings.Cancel

        TimerSettingsDialog.ResumeLayout()

    End Sub

    Public Shared Function GetStylesPath() As String
        Return Path.Combine(GetDataPath, My.Settings.StyleFolder)
    End Function

End Class
