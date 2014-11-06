Imports System.IO
Public Class LoadingEventArgs
    Inherits EventArgs
    Sub New(fileName As String)
        MyBase.New()
        Me.Input = fileName
    End Sub
    Public Property Input As String
End Class