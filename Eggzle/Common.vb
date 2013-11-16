﻿Imports System.IO
Imports System.Threading

Public Class Common
    ' Root path can be set to application folder, or the My Documents folder, depending on the setting of 'EnableDocumentsDataFolder'.
    Private Shared ReadOnly RootPath As String = If(My.Settings.EnableDocumentsDataFolder, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), My.Application.Info.AssemblyName), My.Application.Info.DirectoryPath)
    ' The folder where all time setting files are stored.
    Public Shared ReadOnly TimePath As String = Path.Combine(Directory.CreateDirectory(Path.Combine(RootPath, My.Settings.TimeFolder)).FullName)
    ' The path to the default time data file.
    Private Shared ReadOnly DefaultTimePath As String = Path.Combine(TimePath, My.Settings.DefaultTimeFile)
    ' The settings object for Time.
    Public Shared ReadOnly Time As New Settings.TimeSettings(DefaultTimePath, New Settings.Models.TimeModel(New TimeSpan(0, 5, 0), False, False, 0, True, String.Empty, False, 100, String.Empty), False)
    ' The folder where all task setting files are stored.
    Public Shared ReadOnly TasksPath As String = Path.Combine(Directory.CreateDirectory(Path.Combine(RootPath, My.Settings.TaskFolder)).FullName)
    ' The path to the default tasks data file.
    Private Shared ReadOnly DefaultTasksPath As String = Path.Combine(TasksPath, My.Settings.DefaultTaskFile)
    ' The settings object for Tasks.
    Public Shared ReadOnly Tasks As New Settings.TaskSettings(DefaultTasksPath, Nothing, False)
    ' The folder where all look setting files are stored.
    Public Shared ReadOnly LookPath As String = Path.Combine(Directory.CreateDirectory(Path.Combine(RootPath, My.Settings.LookFolder)).FullName)
    ' The path to the default look data file.
    Private Shared ReadOnly DefaultLookPath As String = Path.Combine(LookPath, My.Settings.DefaultLookFile)
    ' The settings object for Look.
    Public Shared ReadOnly Look As New Settings.LookSettings(DefaultLookPath, New Settings.Models.LookModel(My.Settings.DefaultFont, True, Color.FromArgb(255, 255, 80, 0), Color.Black, 100, String.Empty, "s"), False)
    ' The folder where all alarm sound files are stored.
    Public Shared ReadOnly AlarmsPath As String = Directory.CreateDirectory(System.IO.Path.Combine(RootPath, My.Settings.AlarmFolder)).FullName
    ' The object for language settings, set with the default language.
    Public Shared ReadOnly Languages As New Languages(My.Application.Info.DirectoryPath, My.Settings.DefaultLanguage)
    ' Framerate constant. This is equal to 10 frames per second.
    Public Const Framerate As Integer = 1000 / 10
    ' The object for all of the supported display formats for the timer (these appear in the 'Look' settings dialog).
    Public Shared ReadOnly DisplayFormats As New List(Of KeyValuePair(Of String, String)) From {
        {New KeyValuePair(Of String, String)("Standard", "s")},
        {New KeyValuePair(Of String, String)("Deciseconds", "d")},
        {New KeyValuePair(Of String, String)("Total Seconds", "S")},
        {New KeyValuePair(Of String, String)("Verbal", "v")}
        }
    '("Standard", "h"}, {"Deciseconds", "d"}, {"Microseconds", "m"}, {"Verbal", "v"
    Public Shared Sub Settings_Click()
        Try
            FormConfiguration.ShowDialog(FormMain)
        Catch ex As Exception
            MessageBox.Show(ex.InnerException.ToString)
        End Try
    End Sub
    ''' <summary>
    ''' Gets all alarms from the Alarms folder.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAlarms() As List(Of AlarmModel)
        Dim alarms As New List(Of AlarmModel)
        For Each file In My.Computer.FileSystem.GetFiles(AlarmsPath)
            alarms.Add(New AlarmModel(System.IO.Path.GetFileNameWithoutExtension(file), System.IO.Path.GetFileName(file)))
        Next
        Return alarms
    End Function
    ''' <summary>
    ''' Gets the full alarm path for a specified fileName.
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAlarmPath(fileName As String) As String
        Try
            Dim fullPath As String = System.IO.Path.Combine(AlarmsPath, fileName)
            If My.Computer.FileSystem.FileExists(fullPath) Then
                Return fullPath
            ElseIf My.Computer.FileSystem.FileExists(fileName) Then
                Return fileName
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Return String.Empty
        End Try
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
        FormMain.ToolStripMenuItemLook.Text = My.Resources.Strings.MenuLook
        FormMain.ToolStripMenuItemConfiguration.Text = My.Resources.Strings.MenuConfiguration
        FormMain.ToolStripMenuItemAlwaysOnTop.Text = My.Resources.Strings.MenuAlwaysOnTop
        FormMain.ToolStripMenuItemHelp.Text = My.Resources.Strings.MenuHelp
        FormMain.ToolStripMenuItemCompact.Text = My.Resources.Strings.MenuCompact
        FormMain.ToolStripMenuItemFullScreen.Text = My.Resources.Strings.MenuFullSreen
        FormMain.ToolStripMenuItemHelp.Text = My.Resources.Strings.MenuHelp
        FormMain.ToolStripMenuItemHelpOnline.Text = My.Resources.Strings.MenuHelpOnline
        FormMain.ToolStripMenuItemAboutEggzle.Text = My.Resources.Strings.About
        FormMain.ToolStripMenuItemCheckForUpdates.Text = My.Resources.Strings.MenuCheckForUpdates
        FormMain.ToolStripMenuItemExit.Text = My.Resources.Strings.MenuExit

        FormMain.ToolStripButtonNewTimer.Text = My.Resources.Strings.MenuNewTimer
        FormMain.ToolStripButtonReset.Text = My.Resources.Strings.Reset

        FormMain.ResumeLayout()

        ' DialogAbout.
        DialogAbout.SuspendLayout()

        DialogAbout.Text = My.Resources.Strings.About
        DialogAbout.LinkLabelLicense.Text = My.Resources.Strings.License
        DialogAbout.ButtonOk.Text = My.Resources.Strings.Ok

        DialogAbout.ResumeLayout()

        ' DialogLookSettings.
        DialogLookSettings.SuspendLayout()

        DialogLookSettings.Text = My.Resources.Strings.Look
        DialogLookSettings.LabelRenderer.Text = My.Resources.Strings.DisplayFormat
        DialogLookSettings.LabelForegroundColor.Text = My.Resources.Strings.ForegroundColor
        DialogLookSettings.LabelBackgroundColor.Text = My.Resources.Strings.BackgroundColor
        DialogLookSettings.LabelFont.Text = My.Resources.Strings.Font
        DialogLookSettings.CheckBoxSizeToFit.Text = My.Resources.Strings.SizeToFit
        DialogLookSettings.LabelOpacityLevel.Text = My.Resources.Strings.OpacityLevel
        DialogLookSettings.ButtonImport.Text = My.Resources.Strings.Import
        DialogLookSettings.ButtonExport.Text = My.Resources.Strings.Export
        DialogLookSettings.ButtonOK.Text = My.Resources.Strings.Ok
        DialogLookSettings.ButtonCancel.Text = My.Resources.Strings.Cancel

        DialogLookSettings.ResumeLayout()

        ' DialogTaskSettings.
        DialogTaskSettings.SuspendLayout()

        DialogTaskSettings.ButtonAdd.Text = My.Resources.Strings.Add
        DialogTaskSettings.ButtonRemove.Text = My.Resources.Strings.Remove
        DialogTaskSettings.MenuItemExportAll.Text = My.Resources.Strings.ExportAll
        DialogTaskSettings.MenuItemExportSelected.Text = My.Resources.Strings.ExportSelected
        DialogTaskSettings.OlvColumnName.Text = My.Resources.Strings.HeaderName
        DialogTaskSettings.OlvColumnEvent.Text = My.Resources.Strings.HeaderEvent
        DialogTaskSettings.OlvColumnCommand.Text = My.Resources.Strings.HeaderCommand
        DialogTaskSettings.OlvColumnArguments.Text = My.Resources.Strings.HeaderArguments

        DialogTaskSettings.OlvColumnName.Text = My.Resources.Strings.HeaderName
        DialogTaskSettings.OlvColumnEvent.Text = My.Resources.Strings.HeaderEvent
        DialogTaskSettings.OlvColumnCommand.Text = My.Resources.Strings.HeaderCommand
        DialogTaskSettings.OlvColumnArguments.Text = My.Resources.Strings.HeaderArguments

        DialogTaskSettings.ResumeLayout()

        ' DialogTimerSettings.
        DialogTimerSettings.SuspendLayout()

        DialogTimerSettings.GroupBoxDuration.Text = My.Resources.Strings.Duration
        DialogTimerSettings.LabelRestarts.Text = My.Resources.Strings.Restarts
        DialogTimerSettings.CheckBoxCountUp.Text = My.Resources.Strings.CountUp
        DialogTimerSettings.CheckBoxAutoStart.Text = My.Resources.Strings.AutoStart
        DialogTimerSettings.CheckBoxAlarmSet.Text = My.Resources.Strings.Alarm
        DialogTimerSettings.CheckBoxLoop.Text = My.Resources.Strings.LoopAlarm
        DialogTimerSettings.TextBoxNote.Text = My.Resources.Strings.Note

        DialogTimerSettings.ButtonImport.Text = My.Resources.Strings.Import
        DialogTimerSettings.ButtonExport.Text = My.Resources.Strings.Export
        DialogTimerSettings.ButtonOK.Text = My.Resources.Strings.Ok
        DialogTimerSettings.ButtonCancel.Text = My.Resources.Strings.Cancel

        DialogTimerSettings.ResumeLayout()

    End Sub
End Class


