Namespace codeisle
    Public Class Timer
        Private _startTime As TimeSpan '"" '= 0 'Variable stores time in HH:MM:SS.MS format
        Private _ticking As Boolean  'Variable stores True if the Timer is still ticking, and False if time is zero 
        Private _alarmSet As Boolean ' Variable to see whether the alarm is set
        Private _alarmFile As String
        Private alarmStopwatch As Stopwatch
        Private expiredTimer As System.Threading.Timer
        Private _enabled As Boolean
        Private Const AlarmTimerInterval As Integer = 100
        Private Lasttick As Integer
        Private enabledTask As task

        Private enabledCancellationTokenSource As System.Threading.CancellationTokenSource

#Region "Events"
        Public Event Started As EventHandler(Of TimerEventArgs)
        Public Event Stopped As EventHandler(Of TimerEventArgs)
        Public Event Expired As EventHandler(Of TimerEventArgs)
#End Region
        Sub New(startTime As TimeSpan)
            MyClass.New(startTime, Nothing, Nothing)
            Dim g As New PictureBox
        End Sub
        Sub New(startTime As TimeSpan, alarmFile As String)
            MyClass.New(startTime, alarmFile, True)
        End Sub
        Sub New(startTime As TimeSpan, alarmFile As String, alarmSet As Boolean)
            _startTime = startTime
            _alarmFile = alarmFile
            _alarmFile = alarmFile
            _alarmSet = AlarmSet
            'expiredTimer = New System.Threading.Timer(New System.Threading.TimerCallback(AddressOf ExpiredTimer_Tick), Nothing, 0, AlarmTimerInterval)
            alarmStopwatch = New Stopwatch
            enabledCancellationTokenSource = New Threading.CancellationTokenSource
        End Sub
        Private Sub StartEnabledTest()
            enabledCancellationTokenSource = New Threading.CancellationTokenSource
            Task.Run(Sub() EnabledTestAsync(enabledCancellationTokenSource.Token), enabledCancellationTokenSource.Token)
        End Sub
        Private Sub StopEnabledTest()
            enabledCancellationTokenSource.Cancel()
        End Sub
        Public Sub Start()
            _enabled = True
            alarmStopwatch.Start()
            StartEnabledTest()
            RaiseEvent Started(Me, New TimerEventArgs(MyClass.Time, _startTime))
        End Sub
        Public Sub [Stop]()
            _enabled = False
            StopEnabledTest()
            alarmStopwatch.Stop()
            My.Computer.Audio.Stop()
            RaiseEvent Stopped(Me, New TimerEventArgs(MyClass.Time, _startTime))
        End Sub
        Public Sub Reset()
            StopEnabledTest()
            alarmStopwatch.Reset()
            My.Computer.Audio.Stop()
        End Sub
        Public Sub Restart()
            My.Computer.Audio.Stop()
            _enabled = True
            StopEnabledTest()
            StartEnabledTest()
            alarmStopwatch.Restart()
        End Sub

        Public Property Enabled As Boolean
            Get
                Return _enabled
            End Get
            Set(value As Boolean)
                _enabled = value
                If (_enabled) Then
                    If (Not alarmStopwatch.IsRunning) Then
                        alarmStopwatch.Start()
                    End If
                Else
                    If (alarmStopwatch.IsRunning) Then
                        alarmStopwatch.Stop()
                    End If
                End If
            End Set
        End Property

        Public ReadOnly Property Time As TimeSpan
            Get
                Dim currentTime = _startTime - alarmStopwatch.Elapsed
                If currentTime.TotalMilliseconds < 0 Then
                    currentTime = New TimeSpan()
                End If
                Return currentTime
            End Get
        End Property
        Private Async Sub EnabledTestAsync(token As Threading.CancellationToken)
            While _enabled
                Await Task.Delay(10)
                If MyClass.Time.TotalMilliseconds <= 0 Then
                    MyClass.Stop()
                    ' MessageBox.Show(alarmStopwatch.ElapsedMilliseconds)
                    If _alarmSet Then
                        My.Computer.Audio.Play(_alarmFile, AudioPlayMode.BackgroundLoop)
                    End If
                End If
                If token.IsCancellationRequested Then
                    Exit While
                End If
            End While
            RaiseEvent Expired(Me, New TimerEventArgs(MyClass.Time, _startTime))
        End Sub
        Private Sub ExpiredTimer_Tick()
            If _enabled Then
                If MyClass.Time.TotalMilliseconds <= 0 Then
                    RaiseEvent Expired(Me, New TimerEventArgs(MyClass.Time, _startTime))
                    MyClass.Stop()
                    ' MessageBox.Show(alarmStopwatch.ElapsedMilliseconds)
                    If _alarmSet Then
                        My.Computer.Audio.Play(_alarmFile, AudioPlayMode.BackgroundLoop)
                    End If
                End If
            End If
        End Sub

        'Public Sub Tick()
        '    '' Debug.Print("Alarmset: " + _AlarmSet.ToString)
        '    If (_alarmSet Or _started) = False Then Exit Sub 'If the timer is set to 00:00:00 then exit sub
        '    '_Ticking = True
        '    ''Lasttick = Date.Now.AddMilliseconds(100).Millisecond
        '    'If MyClass.Milliseconds = 0 Then
        '    '    If MyClass.Hours > 0 And MyClass.Minutes > 0 And MyClass.Seconds = 0 Then 'if there are still hours and minutes left, but seconds are at 0...
        '    '        MyClass.Seconds -= 1 'decrement seconds by 1. Puts it at 59
        '    '        MyClass.Minutes -= 1 'decrement minutes by 1
        '    '    ElseIf MyClass.Hours > 0 And MyClass.Minutes > 0 And MyClass.Seconds > 0 Then 'if there are still hours, minutes and seconds left...
        '    '        MyClass.Seconds -= 1 'decrement seconds by 1
        '    '    ElseIf MyClass.Hours > 0 And MyClass.Minutes = 0 And MyClass.Seconds > 0 Then 'if there are still hours and seconds left, but minutes are at 0
        '    '        MyClass.Seconds -= 1 'decrement seconds by 1
        '    '    ElseIf MyClass.Hours > 0 And MyClass.Minutes = 0 And MyClass.Seconds = 0 Then 'if there are still hours, but minutes and seconds are at 0... 
        '    '        MyClass.Hours -= 1 'decrement hours
        '    '        MyClass.Minutes -= 1 'decrement minutes
        '    '        MyClass.Seconds -= 1 'decrement seconds
        '    '    ElseIf MyClass.Hours = 0 And _Minutes > 0 And _Seconds > 0 Then 'if there are still minutes and seconds left. but hours are at 0...
        '    '        MyClass.Seconds -= 1 'decrement seconds
        '    '    ElseIf MyClass.Hours = 0 And MyClass.Minutes > 0 And MyClass.Seconds = 0 Then 'if there are stll minutes left,  but hours and seconds are at 0...
        '    '        MyClass.Minutes -= 1 'decrement minutes
        '    '        MyClass.Seconds -= 1 'decrement seconds
        '    '    ElseIf _Hours = 0 And _Minutes = 0 And _Seconds >= 1 Then '
        '    '        _Seconds -= 1

        '    '    ElseIf _Hours = 0 And _Minutes = 0 And _Seconds = 0 And _Milliseconds = 0 Then
        '    '        _AlarmSet = False
        '    '        _Ticking = False
        '    '        _Started = False
        '    '    End If
        '    'End If
        '    'MyClass.Milliseconds -= _MillisecondDecrement
        '    If (_alarmSet Or _started) = False Then Exit Sub 'If the timer is set to 00:00:00 then exit sub
        '    MyClass.Milliseconds -= _millisecondDecrement
        '    If (MyClass.Milliseconds = 0) Then
        '        If (Not MyClass.Seconds = 0) Then
        '            MyClass.Seconds -= 1
        '        ElseIf Not (MyClass.Minutes = 0) Then
        '            MyClass.Minutes -= 1
        '            MyClass.Seconds -= 1
        '        ElseIf Not (MyClass.Hours = 0) Then
        '            MyClass.Hours -= 1
        '            MyClass.Minutes -= 1
        '            MyClass.Seconds -= 1
        '        End If
        '    End If

        '    'MyClass.Milliseconds -= 1 'decrement milliseconds
        '    'MyClass.Milliseconds = (Lasttick - Date.Now.Millisecond)
        'End Sub

        Public Property AlarmSet() As Boolean
            Get
                Return _alarmSet
            End Get

            Set(value As Boolean)
                _alarmSet = False
            End Set
        End Property
        'Public Property Paused() As Boolean
        '    Get
        '        Return _paused
        '    End Get
        '    Set(ByVal value As Boolean)
        '        _paused = value
        '        If _paused Then
        '            ' MyClass.Milliseconds = Math.Abs((Lasttick - Date.Now.Millisecond))
        '        End If
        '    End Set
        'End Property
    End Class
End Namespace
