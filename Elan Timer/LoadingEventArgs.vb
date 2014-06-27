Imports System.IO
Public Class LoadingEventArgs
    Inherits EventArgs
    Sub New(input As String)
        MyBase.New()
        Me.Input = input
    End Sub
    Public Property Input As String
End Class