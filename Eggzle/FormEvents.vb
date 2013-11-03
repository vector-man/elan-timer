Public Class FormEvents
    Public Shared Sub Settings_Click()
        Try
            FormSettings.ShowDialog(FormMain)
        Catch ex As Exception
            MessageBox.Show(ex.InnerException.ToString)
        End Try

    End Sub
End Class
