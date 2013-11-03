Imports ServiceStack.Text.Json
Namespace CodeIsle.Data
    Public MustInherit Class DALBase
        Implements IDisposable
        Private _connection As NDatabase.Odb.IOdb
        Private fileName As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, My.Settings.DatabaseName)

        Event Loading(ender As Object, e As EventArgs)
        Event Saving(sender As Object, e As EventArgs)
        Sub New()
            Using context = NDatabase.Odb.OdbFactory.Open(fileName)
                _connection = context
            End Using
        End Sub
        Protected Sub OnLoading(sender As Object, e As EventArgs)
            RaiseEvent Loading(sender, e)
        End Sub
        Protected Sub OnSaving(sender As Object, e As EventArgs)
            RaiseEvent Saving(sender, e)
        End Sub

        Private Sub DAL_Save(sender As Object, e As EventArgs)

        End Sub
        Private Sub DAL_Load(sender As Object, e As EventArgs)

        End Sub
        Public Overridable Sub Load()

        End Sub
        Public Overridable Sub Save()

        End Sub


        Protected ReadOnly Property Connection As NDatabase.Odb.IOdb
            Get
                Return _connection
            End Get
        End Property
#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                    Using context = NDatabase.Odb.OdbFactory.Open(fileName)
                        _connection = context

                    End Using
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