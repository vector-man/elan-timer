Imports Newtonsoft
Namespace Settings
    Public Class ProfileSettings
        Implements ISettings
        Private _profile As Models.ProfileModel
        Private _path As String
        Private jsonDatabase As JsonDatabase
        Sub New(path As String)
            jsonDatabase = New JsonDatabase
            _path = path
            _profile = New Models.ProfileModel
            Load()
            If _profile Is Nothing Then
                _profile = New Models.ProfileModel(New TimeSpan(0, 5, 0), New Font("Arial", 32), True, Color.GhostWhite, Color.OrangeRed, New List(Of Models.TaskModel), 100, 0, 100)
            End If

        End Sub

        Public Property BackgroundColor As Color
            Get
                Return _profile.BackgroundColor
            End Get
            Set(value As Color)
                _profile.BackgroundColor = value
            End Set
        End Property

        Public Property ForegroundColor As Color
            Get
                Return _profile.ForegroundColor
            End Get
            Set(value As Color)
                _profile.ForegroundColor = value
            End Set
        End Property

        Public Property SizeToFit As Boolean
            Get
                Return _profile.SizeToFit
            End Get
            Set(value As Boolean)
                _profile.SizeToFit = value
            End Set
        End Property
        Public Property Font As Font
            Get
                Return _profile.Font
            End Get
            Set(value As Font)
                _profile.Font = value
            End Set
        End Property
        Public Property Time As TimeSpan
            Get
                Return _profile.Time
            End Get
            Set(value As TimeSpan)
                _profile.Time = value
            End Set
        End Property
        Public Property Opacity As Integer
            Get
                Return _profile.Opacity
            End Get
            Set(value As Integer)
                _profile.Opacity = value
            End Set
        End Property
        Public Property Restarts As Integer
            Get
                Return _profile.Restarts
            End Get
            Set(value As Integer)
                _profile.Restarts = value
            End Set
        End Property
        Public Property Volume As Integer
            Get
                Return _profile.Volume
            End Get
            Set(value As Integer)
                _profile.Volume = value
            End Set
        End Property
        Public Sub Load() Implements ISettings.Load
            ImportFrom(_path)
        End Sub

        Public Sub Save() Implements ISettings.Save
            ExportTo(_path)
        End Sub

        Public Sub ExportTo(path As String) Implements ISettings.ExportTo
            jsonDatabase.Save(path, _profile)
        End Sub

        Public Sub ImportFrom(path As String) Implements ISettings.ImportFrom
            _profile = jsonDatabase.Load(path, GetType(Models.ProfileModel))
        End Sub
    End Class
End Namespace
