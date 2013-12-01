Namespace CodeIsle.Timers
    Public MustInherit Class AlarmTimer
        Inherits TimerBase
        Implements IDisposable

        Private _enabled As Boolean
        Private _alarm As Alarm
        Private _alarmEnabled As Boolean
        Sub New(duration As TimeSpan)
            MyClass.New(duration, Nothing, False)
        End Sub
        Sub New(duration As TimeSpan, alarm As Alarm)
            MyClass.New(duration, alarm, True)
        End Sub
        Sub New(duration As TimeSpan, alarm As Alarm, alarmEnabled As Boolean)
            MyClass.New(duration, alarm, alarmEnabled, 0)
        End Sub
        Sub New(duration As TimeSpan, alarm As Alarm, alarmEnabled As Boolean, restarts As Integer)
            MyClass.New(duration, alarm, alarmEnabled, restarts, 1)
        End Sub
        Sub New(duration As TimeSpan, alarm As Alarm, alarmEnabled As Boolean, restarts As Integer, expirationPollRate As Integer)
            MyBase.New(duration, restarts, expirationPollRate)
            MyClass.Alarm = alarm
            MyClass.AlarmEnabled = alarmEnabled
        End Sub
        Private Sub AlarmTimer_Expired(sender As Object, e As TimerEventArgs)
            Try
                _alarm.Play()
            Catch ex As Exception

            End Try
        End Sub
        Private Sub AlarmTimer_Paused(sender As Object, e As TimerEventArgs)
                Try
                _alarm.Stop()
                Catch ex As Exception

                End Try
        End Sub
        Private Sub AlarmTimer_Started(sender As Object, e As TimerEventArgs)
                Try
                    _alarm.Stop()
                Catch ex As Exception

                End Try
        End Sub
        Private Sub AlarmTimer_Restarted(sender As Object, e As TimerEventArgs)
            Try
                _alarm.Stop()
            Catch ex As Exception

            End Try
        End Sub


        Public Property AlarmEnabled() As Boolean
            Get
                Return _alarmEnabled
            End Get

            Set(value As Boolean)
                _alarmEnabled = value
                RemoveHandler MyBase.Started, AddressOf AlarmTimer_Started
                RemoveHandler MyBase.Expired, AddressOf AlarmTimer_Expired
                RemoveHandler MyBase.Paused, AddressOf AlarmTimer_Paused
                RemoveHandler MyBase.Restarted, AddressOf AlarmTimer_Restarted
                If _alarmEnabled Then
                    AddHandler MyBase.Started, AddressOf AlarmTimer_Started
                    AddHandler MyBase.Expired, AddressOf AlarmTimer_Expired
                    AddHandler MyBase.Paused, AddressOf AlarmTimer_Paused
                    AddHandler MyBase.Restarted, AddressOf AlarmTimer_Restarted
                End If
            End Set
        End Property
        Public Property Alarm As Alarm
            Get
                Return _alarm
            End Get
            Set(value As Alarm)
                If _alarm IsNot Nothing Then
                    _alarm.Dispose()
                    _alarm = Nothing
                End If
                _alarm = value
            End Set
        End Property

        Public Overrides Sub Reset()
            MyBase.Reset()
            Try
                _alarm.Stop()
            Catch ex As Exception

            End Try
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

                    Try
                        _alarm.Dispose()
                    Catch ex As Exception

                    Finally
                        _alarm = Nothing
                    End Try

                    RemoveHandler MyBase.Started, AddressOf AlarmTimer_Started
                    RemoveHandler MyBase.Expired, AddressOf AlarmTimer_Expired
                    RemoveHandler MyBase.Paused, AddressOf AlarmTimer_Paused
                    RemoveHandler MyBase.Restarted, AddressOf AlarmTimer_Restarted
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
End Namespace
