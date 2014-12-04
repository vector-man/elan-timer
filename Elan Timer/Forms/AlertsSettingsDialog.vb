Imports NLog
Imports System.IO

Public Class AlertsSettingsDialog

    Private alarmPlayer As Sound

    Private toolTip As New ToolTip()

    ' Logging
    Private Shared logger As Logger = LogManager.GetCurrentClassLogger()

    Public Property Alerts As New AlertsModel

    Public Property AlarmEnabled As Boolean
        Get
            Return Alerts.AlarmEnabled
        End Get
        Set(value As Boolean)
            Alerts.AlarmEnabled = value
        End Set
    End Property

    Public Property AlarmPerRestart As Boolean
        Get
            Return Alerts.AlarmPerRestart
        End Get
        Set(value As Boolean)
            Alerts.AlarmPerRestart = value
        End Set
    End Property

    Public Property DisplayNoteEnabled As Boolean
        Get
            Return Alerts.DisplayNoteEnabled
        End Get
        Set(value As Boolean)
            Alerts.DisplayNoteEnabled = value
        End Set
    End Property

    Public Property FlashTaskbar As Boolean
        Get
            Return Alerts.FlashTaskbar
        End Get
        Set(value As Boolean)
            Alerts.FlashTaskbar = value
        End Set
    End Property

    Public Property AlarmLoop As Boolean
        Get
            Return Alerts.AlarmLoop
        End Get
        Set(value As Boolean)
            Alerts.AlarmLoop = value
        End Set
    End Property

    Public Property AlarmName As String
        Get
            Return Alerts.AlarmName
        End Get
        Set(value As String)
            Alerts.AlarmName = value
        End Set
    End Property

    Public Property AlarmVolume As Integer
        Get
            Return Alerts.AlarmVolume
        End Get
        Set(value As Integer)
            Alerts.AlarmVolume = value
        End Set
    End Property

    Public Property AlertEnabled As Boolean
        Get
            Return Alerts.AlertEnabled
        End Get
        Set(value As Boolean)
            Alerts.AlertEnabled = value
        End Set
    End Property

    Public Property SoundsPath As String

    Public Property SelectedSound As New KeyValuePair(Of String, String)

    Protected Property SupportedSoundExtensions As String() = {".mp3", ".wav", ".wave"}

    Private Function GetSoundsByPath(soundsPath As String) As List(Of KeyValuePair(Of String, String))
        Dim dict As New List(Of KeyValuePair(Of String, String))

        If (Directory.Exists(soundsPath)) Then
            For Each sound As String In My.Computer.FileSystem.GetFiles(soundsPath) _
                .Where(Function(f) SupportedSoundExtensions.Contains(Path.GetExtension(f)))

                dict.Add(New KeyValuePair(Of String, String)(Path.GetFileNameWithoutExtension(sound), Path.GetFileName(sound)))
            Next
        End If

        Return dict
    End Function

    Private Sub Initialize()
        ComboBoxAlarmPath.DataSource = If(GetSoundsByPath(SoundsPath), New List(Of KeyValuePair(Of String, String)))
        ComboBoxAlarmPath.ValueMember = "Value"
        ComboBoxAlarmPath.DisplayMember = "Key"
        CheckBoxAlertEnabled.DataBindings.Add("Checked", Me, "AlertEnabled")
        CheckBoxDisplayNoteEnabled.DataBindings.Add("Checked", Me, "DisplayNoteEnabled")
        CheckBoxFlashTaskbar.DataBindings.Add("Checked", Me, "FlashTaskbar")
        CheckedGroupBox1.DataBindings.Add("Checked", Me, "AlarmEnabled")
        TrackBarVolume.DataBindings.Add("Value", Me, "AlarmVolume")
        CheckBoxLoop.DataBindings.Add("Checked", Me, "AlarmLoop")
        CheckBoxAlarmPerRestart.DataBindings.Add("Checked", Me, "AlarmPerRestart")
        ComboBoxAlarmPath.DataBindings.Add("SelectedValue", Me, "AlarmName")

        alarmPlayer = New Sound()

        RemoveHandler alarmPlayer.PlaybackStopped, AddressOf AlarmPlayer_PlaybackStopped
        AddHandler alarmPlayer.PlaybackStopped, AddressOf AlarmPlayer_PlaybackStopped

        UpdateAlarmPlayer()
    End Sub

    Private Sub ButtonAlarmPlay_Click(sender As Object, e As EventArgs) Handles ButtonAlarmPlay.Click
        Try
            If (alarmPlayer Is Nothing) Then Return

            If (alarmPlayer.Playing) Then
                alarmPlayer.Stop()
            Else
                ButtonAlarmPlay.Image = My.Resources.stop_red
                alarmPlayer.Play()
            End If
        Catch ex As Exception
            logger.Error(ex)

            ButtonAlarmPlay.Image = My.Resources.play_green
        End Try
    End Sub

    Private Sub AlarmPlayer_PlaybackStopped(sender As Object, e As NAudio.Wave.StoppedEventArgs)
        ButtonAlarmPlay.Image = My.Resources.play_green
    End Sub

    Private Sub TrackBarVolume_Scroll(sender As Object, e As EventArgs) Handles TrackBarVolume.Scroll
        toolTip.SetToolTip(TrackBarVolume, TrackBarVolume.Value.ToString())
    End Sub

    Private Sub TrackBarVolume_ValueChanged(sender As Object, e As EventArgs) Handles TrackBarVolume.ValueChanged
        Try
            If (alarmPlayer Is Nothing) Then Return

            alarmPlayer.Volume = TrackBarVolume.Value
        Catch ex As Exception
            logger.Error(ex)
        End Try
    End Sub

    Private Sub AlertsSettingsDialog_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        If (alarmPlayer Is Nothing) Then Return

        RemoveHandler alarmPlayer.PlaybackStopped, AddressOf AlarmPlayer_PlaybackStopped
        alarmPlayer.Dispose()
    End Sub

    Private Sub AlertsSettingsDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Initialize()
    End Sub

    Private Sub ComboBoxAlarmPath_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAlarmPath.SelectedIndexChanged
        UpdateAlarmPlayer()
    End Sub

    Private Sub UpdateAlarmPlayer()
        If (alarmPlayer Is Nothing) Then Return

        If (alarmPlayer.Playing) Then alarmPlayer.Stop()

        Try
            Dim soundFileName As String = Path.Combine(SoundsPath, ComboBoxAlarmPath.SelectedValue)
            alarmPlayer.Load(soundFileName)
            alarmPlayer.Volume = AlarmVolume
        Catch ex As Exception
            logger.Error(ex)
        End Try
    End Sub

End Class