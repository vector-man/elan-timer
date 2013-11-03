Imports NAudio.Wave
Public Class Alarm : Implements IDisposable
    Private reader As WaveFileReader
    Private loopStream As LoopStream
    Private waveOut As New WaveOut
    Private _enabled As Boolean
    Sub New(path As String, volume As Integer, [loop] As Boolean)
        reader = New WaveFileReader(path)
        loopStream = New LoopStream(reader)
        waveOut = New WaveOut
        Me.Volume = volume
        Me.Loop = [loop]
        waveOut.Init(loopStream)
    End Sub

    Public Sub Play()
        ' Rewind stream.
        loopStream.Position = 0
        ' Play audio.
        waveOut.Play()
    End Sub
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
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                waveOut.Stop()
                waveOut.Dispose()
                waveOut = Nothing

                loopStream.Dispose()
                loopStream = Nothing

                reader.Dispose()
                reader = Nothing

            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
