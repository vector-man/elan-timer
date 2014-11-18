Imports NAudio.Wave
Public Class Sound : Implements IDisposable
    Private reader As WaveFileReader
    Private loopStream As LoopStream
    Private waveOut As WaveOut
    Private _enabled As Boolean
    Private _sound As String
    Public Event PlaybackStopped(sender As Object, e As StoppedEventArgs)

    Public ReadOnly Property Sound As String
        Get
            Return _sound
        End Get
    End Property

    Sub New()

    End Sub
    Sub New(sound As String, volume As Integer, [loop] As Boolean)
        Me.Load(sound)
        Me.Loop = [loop]
    End Sub

    Public Sub Load(sound As String)
        DisposeObjects()
        reader = New WaveFileReader(sound)
        _sound = sound
        reader = New WaveFileReader(_sound)
        loopStream = New LoopStream(reader)
        waveOut = New WaveOut()
        Me.Volume = Volume
        Me.Loop = [Loop]
        waveOut.Init(loopStream)

        RemoveHandler waveOut.PlaybackStopped, AddressOf OnPlaybackStopped
        AddHandler waveOut.PlaybackStopped, AddressOf OnPlaybackStopped
    End Sub
    Private Sub DisposeObjects()
        If (waveOut IsNot Nothing) Then
            RemoveHandler waveOut.PlaybackStopped, AddressOf OnPlaybackStopped
            waveOut.Stop()
            waveOut.Dispose()
        End If

        If (loopStream IsNot Nothing) Then
            loopStream.Dispose()
        End If

        If (reader IsNot Nothing) Then
            reader.Dispose()
        End If
    End Sub
    Public Sub Play()
        ' Rewind stream.
        loopStream.Position = 0
        ' Play audio.
        waveOut.Play()
    End Sub
    Public ReadOnly Property Playing
        Get
            Return (waveOut.PlaybackState = PlaybackState.Playing)
        End Get
    End Property

    Public Sub [Stop]()
        waveOut.Stop()
    End Sub
    Public Sub Pause()
        waveOut.Pause()
    End Sub


    Public Property Volume As Integer
        Get
            Return waveOut.Volume * 100
        End Get
        Set(value As Integer)
            waveOut.Volume = value / 100
        End Set
    End Property
    Public Property [Loop] As Boolean
        Get
            Return loopStream.EnableLooping
        End Get
        Set(value As Boolean)
            loopStream.EnableLooping = value
        End Set
    End Property

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If (Not Me.disposedValue) Then
            If disposing Then
                DisposeObjects()
            End If
        End If
        Me.disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Private Sub OnPlaybackStopped(sender As Object, e As StoppedEventArgs)
        Me.Stop()
        RaiseEvent PlaybackStopped(sender, e)
    End Sub

End Class
