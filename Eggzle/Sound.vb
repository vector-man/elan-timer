'Imports DirectShowLib
'Imports Microsoft.DirectX.AudioVideoPlayback
'Class Player
'    ' Private Player As DirectShowLib
'    Private _Player As Audio
'    Sub New()

'    End Sub
'    Public Sub Play(ByVal Path As String)
'        Try
'            _Player = New Audio(Path)
'            _Player.Play()
'        Catch ex As Exception
'            Throw ex
'        End Try
'        _Player = Nothing
'    End Sub
'    Public Sub [Stop]()
'        Try
'            _Player.Stop()
'            _Player = Nothing

'        Catch ex As Exception

'        End Try

'    End Sub
'    Public ReadOnly Property Stopped() As Boolean
'        Get
'            Return _Player.Stopped
'        End Get
'    End Property

'    Public ReadOnly Property Playing()
'        Get
'            Return _Player.Playing
'        End Get
'    End Property
'    Public WriteOnly Property Pause() As Boolean

'        Set(ByVal value As Boolean)
'            Try
'                If value = True Then
'                    _Player.Pause()
'                Else
'                    _Player.Play()
'                End If
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Set
'    End Property
'    Public ReadOnly Property Paused() As Boolean
'        Get
'            Return _Player.Paused


'        End Get
'    End Property

'    ' Public Declare Function PlaySound Lib "WINMM.DLL" Alias "sndPlaySoundA" (ByVal Sound As String, ByVal Options As Integer) As Integer
'End Class
