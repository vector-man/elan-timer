Imports NAudio.Wave
Namespace CodeIsle.Timers
    Public MustInherit Class AlarmTimer
        Inherits TimerBase
        Implements IDisposable

        Private _alarmSet As Boolean ' Variable to see whether the alarm is set
        Private _alarmFile As String
        Private _enabled As Boolean
        Private reader As WaveFileReader
        Private loopSteram As LoopStream
        Private waveOut As WaveOut

        Sub New(duration As TimeSpan)
            MyClass.New(duration, Nothing, Nothing)
        End Sub
        Sub New(duration As TimeSpan, alarmFile As String)
            MyClass.New(duration, alarmFile, True)
        End Sub
        Sub New(duration As TimeSpan, alarmFile As String, alarmSet As Boolean)
            MyBase.New(duration)
            _alarmFile = alarmFile
            _alarmFile = alarmFile

            MyClass.AlarmSet = alarmSet
            Try
                reader = New WaveFileReader(alarmFile)
                loopSteram = New LoopStream(reader)
                waveOut = New WaveOut
                waveOut.Init(loopSteram)
            Catch ex As Exception

            End Try

        End Sub
        Private Sub AlarmTimer_Expired(sender As Object, e As TimerEventArgs)
            waveOut.Play()
        End Sub
        Private Sub AlarmTimer_Paused(sender As Object, e As TimerEventArgs)
            waveOut.Stop()
        End Sub
        Private Sub AlarmTimer_Started(sender As Object, e As TimerEventArgs)
            waveOut.Stop()
        End Sub
        Private Sub AlarmTimer_Restarted(sender As Object, e As TimerEventArgs)
            waveOut.Stop()
        End Sub


        Public Property AlarmSet() As Boolean
            Get
                Return _alarmSet
            End Get

            Set(value As Boolean)
                _alarmSet = value

                If _alarmSet Then

                    AddHandler MyBase.Started, AddressOf AlarmTimer_Started
                    AddHandler MyBase.Expired, AddressOf AlarmTimer_Expired
                    AddHandler MyBase.Paused, AddressOf AlarmTimer_Paused
                    AddHandler MyBase.Restarted, AddressOf AlarmTimer_Restarted
                Else
                    RemoveHandler MyBase.Started, AddressOf AlarmTimer_Started
                    RemoveHandler MyBase.Expired, AddressOf AlarmTimer_Expired
                    RemoveHandler MyBase.Paused, AddressOf AlarmTimer_Paused
                    RemoveHandler MyBase.Restarted, AddressOf AlarmTimer_Restarted
                End If
            End Set
        End Property
        Public Overrides Sub Reset()
            MyBase.Reset()
            waveOut.Stop()
        End Sub
        Public Overrides ReadOnly Property Current As TimeSpan
            Get

            End Get
        End Property

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
                RemoveHandler MyBase.Started, AddressOf AlarmTimer_Started
                RemoveHandler MyBase.Expired, AddressOf AlarmTimer_Expired
                RemoveHandler MyBase.Paused, AddressOf AlarmTimer_Paused
                RemoveHandler MyBase.Restarted, AddressOf AlarmTimer_Restarted

                waveOut.Stop()
                waveOut.Dispose()
                waveOut = Nothing
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
End Namespace
