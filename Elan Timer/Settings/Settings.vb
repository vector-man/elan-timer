Imports System.IO
Namespace Settings
    Public Class Settings
        ' Root path can be set to application folder, or the My Documents folder, depending on the setting of 'EnableDocumentsDataFolder'.
        Private Shared ReadOnly RootPath As String = If(My.Settings.EnableDocumentsDataFolder, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), My.Application.Info.AssemblyName), My.Application.Info.DirectoryPath)
        Private Shared ReadOnly DataPath As String = Path.Combine(RootPath, My.Settings.DataFolder)
        ' The folder where all time setting files are stored.
        Public Shared ReadOnly TimePath As String = Path.Combine(Directory.CreateDirectory(Path.Combine(DataPath, My.Settings.TimeFolder)).FullName)
        ' The path to the default time data file.
        Private Shared ReadOnly DefaultTimePath As String = Path.Combine(TimePath, My.Settings.DefaultTimeFile)
        ' The settings object for Time.
        Public Shared ReadOnly Time As New TimeSettings(DefaultTimePath, New Models.TimeModel(New TimeSpan(0, 5, 0), False, False, 0, True, String.Empty, False, 100, String.Empty, False, False), True)
        ' The folder where all task setting files are stored.
        Public Shared ReadOnly TasksPath As String = Path.Combine(Directory.CreateDirectory(Path.Combine(DataPath, My.Settings.TaskFolder)).FullName)
        ' The path to the default tasks data file.
        Private Shared ReadOnly DefaultTasksPath As String = Path.Combine(TasksPath, My.Settings.DefaultTaskFile)
        ' The settings object for Tasks.
        Public Shared ReadOnly Tasks As New TaskSettings(DefaultTasksPath, New List(Of Models.TaskModel), True, Not Common.IsSingleInstance())
        ' The folder where all look setting files are stored.
        Public Shared ReadOnly LookPath As String = Path.Combine(Directory.CreateDirectory(Path.Combine(DataPath, My.Settings.LookFolder)).FullName)
        ' The path to the default look data file.
        Private Shared ReadOnly DefaultLookPath As String = Path.Combine(LookPath, My.Settings.DefaultLookFile)
        ' The settings object for Look.
        Public Shared ReadOnly Look As New LookSettings(DefaultLookPath, New Models.LookModel(My.Settings.DefaultFont, True, Color.White, Color.Silver, 100, String.Empty, "d"), True)
        ' The folder where all alarm sound files are stored.
        Public Shared ReadOnly AlarmsPath As String = Directory.CreateDirectory(System.IO.Path.Combine(DataPath, My.Settings.AlarmFolder)).FullName
    End Class
End Namespace
