﻿Namespace Settings
    Public Class LookSettings : Implements ISettings
        Private _path As String
        Private jsonDatabase As JsonDatabase
        Private _look As Models.LookModel
        Private backupLook As Models.LookModel
        Private _defaultModel As Object
        Sub New()
            jsonDatabase = New JsonDatabase
        End Sub
        Sub New(path As String, Optional defaultModel As Models.LookModel = Nothing, Optional load As Boolean = True)
            MyClass.New()
            _defaultModel = defaultModel
            _path = path
            If load Then
                MyClass.Load()
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

        Public Property SizeToFit As Boolean
            Get
                Return _look.SizeToFit
            End Get
            Set(value As Boolean)
                _look.SizeToFit = value
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
        Public Sub ExportTo(path As String) Implements ISettings.ExportTo
            jsonDatabase.Save(path, _look)
        End Sub

        Public Sub ImportFrom(path As String) Implements ISettings.ImportFrom
            _look = jsonDatabase.Load(path, GetType(Models.LookModel))
            If _look Is Nothing Then
                _look = _defaultModel
            End If
        End Sub

        Public Sub Load() Implements ISettings.Load
            ImportFrom(_path)
        End Sub

        Public Sub Save() Implements ISettings.Save
            ExportTo(_path)
        End Sub

        Private Function Clone(look As Models.LookModel)
            Return New Models.LookModel(look.Font, look.SizeToFit, look.BackgroundColor, look.ForegroundColor, look.Opacity, look.Renderer, look.DisplayFormat)
        End Function

        Public Sub BeginEdit() Implements ISettings.BeginEdit
            backupLook = Clone(_look)
        End Sub

        Public Sub CancelEdit() Implements ISettings.CancelEdit
            _look = Clone(backupLook)
        End Sub

        Public Sub EndEdit() Implements ISettings.EndEdit
            backupLook = Nothing
        End Sub
    End Class
End Namespace