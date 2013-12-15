Namespace Prefs
    Public Class LookPreferences : Implements IPreferences
        Private _path As String
        Private jsonDatabase As JsonDatabase
        Private _look As Models.LookModel
        Private backupLook As Models.LookModel
        Private _defaultModel As Object
        Sub New()
            jsonDatabase = New JsonDatabase
        End Sub
        Sub New(path As String, defaultModel As Models.LookModel, load As Boolean)
            MyClass.New()
            _defaultModel = defaultModel
            _path = path
            If load Then
                MyClass.Load()
            End If
            If (_look Is Nothing) Then
                _look = defaultModel
            End If
        End Sub
        Public Property Renderer As String
            Get
                Return _look.Renderer
            End Get
            Set(value As String)
                _look.Renderer = value
            End Set
        End Property
        Public Property BackgroundColor As Color
            Get
                Return _look.BackgroundColor
            End Get
            Set(value As Color)
                _look.BackgroundColor = value
            End Set
        End Property

        Public Property ForegroundColor As Color
            Get
                Return _look.ForegroundColor
            End Get
            Set(value As Color)
                _look.ForegroundColor = value
            End Set
        End Property

        Public Property GrowToFit As Boolean
            Get
                Return _look.GrowToFit
            End Get
            Set(value As Boolean)
                _look.GrowToFit = value
            End Set
        End Property
        Public Property Font As Font
            Get
                Return _look.Font
            End Get
            Set(value As Font)
                _look.Font = value
            End Set
        End Property
        Public Property Opacity As Integer
            Get
                Return _look.Opacity
            End Get
            Set(value As Integer)
                _look.Opacity = value
            End Set
        End Property
        Public Property DisplayFormat As String
            Get
                Return _look.DisplayFormat
            End Get
            Set(value As String)
                _look.DisplayFormat = value
            End Set
        End Property
        Public Sub ExportTo(path As String) Implements IPreferences.ExportTo
            jsonDatabase.Save(path, _look)
        End Sub

        Public Sub ImportFrom(path As String) Implements IPreferences.ImportFrom
            _look = jsonDatabase.Load(path, GetType(Models.LookModel))
            If _look Is Nothing Then
                _look = _defaultModel
            End If
        End Sub

        Public Sub Load() Implements IPreferences.Load
            ImportFrom(_path)
        End Sub

        Public Sub Save() Implements IPreferences.Save
            ExportTo(_path)
        End Sub

        Private Function Clone(look As Models.LookModel)
            Return New Models.LookModel(look.Font, look.GrowToFit, look.BackgroundColor, look.ForegroundColor, look.Opacity, look.Renderer, look.DisplayFormat)
        End Function

        Public Sub BeginEdit() Implements IPreferences.BeginEdit
            backupLook = Clone(_look)
        End Sub

        Public Sub CancelEdit() Implements IPreferences.CancelEdit
            _look = Clone(backupLook)
        End Sub

        Public Sub EndEdit() Implements IPreferences.EndEdit
            backupLook = Nothing
        End Sub
    End Class
End Namespace