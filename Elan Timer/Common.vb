Imports System.IO
Imports System.Threading
Imports ElanTimer.Prefs
Public Class Common
    Private Shared toolTipMain As New ToolTip
    ' Framerate constant. This is equal to 10 frames per second.
    Public Const Framerate As Integer = 1000 / 10
    ' The object for all of the supported display formats for the timer (these appear in the 'Look' settings dialog).
    Public Shared ReadOnly DisplayFormats As New List(Of KeyValuePair(Of String, String)) From {
        {New KeyValuePair(Of String, String)("Standard", "d")},
        {New KeyValuePair(Of String, String)("No Deciseconds", "s")},
        {New KeyValuePair(Of String, String)("Total Seconds", "S")},
        {New KeyValuePair(Of String, String)("Verbal", "v")}
        }
    ' The object for language settings, set with the default language.
    Public Shared ReadOnly Languages As New Languages(My.Application.Info.DirectoryPath, My.Settings.DefaultLanguage)
    Public Shared ReadOnly AlarmsPath As String = Path.Combine(My.Computer.FileSystem.CurrentDirectory, My.Settings.DataFolder, My.Settings.AlarmFolder)
    ''' <summary>
    ''' Gets the full alarm path for a specified fileName.
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAlarmPath(fileName As String) As String
        'Try
        '    Dim fullPath As String = System.IO.Path.Combine(Preferences.AlarmsPath, fileName)
        '    If My.Computer.FileSystem.FileExists(fullPath) Then
        '        Return fullPath
        '    ElseIf My.Computer.FileSystem.FileExists(fileName) Then
        '        Return fileName
        '    Else
        '        Return String.Empty
        '    End If
        'Catch ex As Exception
        '    Return String.Empty
        'End Try
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
End Class


