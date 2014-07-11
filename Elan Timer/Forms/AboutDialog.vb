﻿Imports System.IO

Public NotInheritable Class AboutDialog
    Private Sub DialogAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetStrings()

        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub SetStrings()
        Me.SuspendLayout()

        Me.Text = My.Resources.Strings.About
        Me.LinkLabelLicense.Text = My.Resources.Strings.License
        Me.ButtonOk.Text = My.Resources.Strings.Ok

        Me.ResumeLayout()

    End Sub

    Private Sub LinkLabelLicense_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelLicense.LinkClicked
        Try
            Process.Start(Path.Combine(My.Application.Info.DirectoryPath, My.Settings.LicenseFile))
            Me.Close()
        Catch

        End Try
    End Sub
End Class
