Imports System.IO

Public Class SavingEventArgs
    Inherits EventArgs
    Sub New(output As String)
        MyBase.New()
        Me.Output = output
    End Sub
    Public Property Output As String
End Class
