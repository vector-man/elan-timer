Imports Newtonsoft
Namespace Settings
    Public Class TimeSettings : Implements ISettings
        Private _time As Models.TimeModel
        Private backupTime As Models.TimeModel
        Private _path As String
        Private _defaultModel As Models.TimeModel
        Private jsonDatabase As JsonDatabase
        Sub New()
            jsonDatabase = New JsonDatabase
        End Sub
        Sub New(path As String, defaultModel As Models.TimeModel, load As Boolean)
            MyClass.New()
            _path = path
            _defaultModel = defaultModel
            If load Then
                MyClass.Load()
            End If
            If (_time Is Nothing) Then
                _time = defaultModel
            End If
        End Sub


        Public Property Duration As TimeSpan
            Get
                Return _time.Duration
            End Get
            Set(value As TimeSpan)
                _time.Duration = value
            End Set
        End Property
        Public Property CountUp As Boolean
            Get
                Return _time.CountUp
            End Get
            Set(value As Boolean)
                _time.CountUp = value
            End Set
        End Property
        Public Property StartImmediately As Boolean
            Get
                Return _time.StartImmediately
            End Get
            Set(value As Boolean)
                _time.StartImmediately = value
            End Set
        End Property
        Public Property Restarts As Integer
            Get
                Return _time.Restarts
            End Get
            Set(value As Integer)
                _time.Restarts = value
            End Set
        End Property
        Public Property AlarmEnabled As Boolean
            Get
                Return _time.AlarmEnabled
            End Get
            Set(value As Boolean)
                _time.AlarmEnabled = value
            End Set
        End Property
        Public Property AlarmPath As String
            Get
                Return _time.AlarmPath
            End Get
            Set(value As String)
                _time.AlarmPath = value
            End Set
        End Property
        Public Property AlarmLoop As Boolean
            Get
                Return _time.AlarmLoop
            End Get
            Set(value As Boolean)
                _time.AlarmLoop = value
            End Set
        End Property

        Public Property AlarmVolume As Integer
            Get
                Return _time.AlarmVolume
            End Get
            Set(value As Integer)
                _time.AlarmVolume = value
            End Set
        End Property
        Public Property Note As String
            Get
                Return _time.Note
            End Get
            Set(value As String)
                _time.Note = value
            End Set
        End Property
        Public Sub ExportTo(path As String) Implements ISettings.ExportTo
            jsonDatabase.Save(path, _time)
        End Sub

        Public Sub ImportFrom(path As String) Implements ISettings.ImportFrom
            _time = jsonDatabase.Load(path, GetType(Models.TimeModel))
            If (_time Is Nothing) Then
                _time = _defaultModel
            End If
        End Sub

        Public Sub Load() Implements ISettings.Load
            ImportFrom(_path)
        End Sub

        Public Sub Save() Implements ISettings.Save
            ExportTo(_path)
        End Sub

        'Public Sub RollBack() Implements ISettings.RollBack
        '    _time = backupTime
        '    '_time.AlarmEnabled = backupTime.AlarmEnabled
        '    '_time.AlarmEnabled = backupTime.AlarmLoop
        '    '_time.AlarmPath = backupTime.AlarmPath
        '    '_time.AlarmVolume = backupTime.AlarmVolume
        '    '_time.AutoStart = backupTime.AutoStart
        '    '_time.CountUp = backupTime.CountUp
        '    '_time.Duration = backupTime.Duration
        '    '_time.Memo = backupTime.Memo
        '    '_time.Restarts = backupTime.Restarts
        'End Sub
        Private Function Clone(time As Models.TimeModel)
            Return New Models.TimeModel(time.Duration, time.CountUp, time.StartImmediately, time.Restarts, time.AlarmEnabled, time.AlarmPath, time.AlarmLoop, time.AlarmVolume, time.Note)
        End Function

        Public Sub BeginEdit() Implements ISettings.BeginEdit
            backupTime = Clone(_time)
        End Sub

        Public Sub CancelEdit() Implements ISettings.CancelEdit
            _time = Clone(backupTime)
        End Sub

        Public Sub EndEdit() Implements ISettings.EndEdit
            backupTime = Nothing
        End Sub
    End Class
End Namespace
