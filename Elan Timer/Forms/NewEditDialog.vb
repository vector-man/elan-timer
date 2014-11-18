Imports NLog

Public Class NewEditDialog
    Private imageList As New ImageList()

    Public Property Editing As Boolean
        Get
            Return Not ButtonStart.Enabled
        End Get
        Set(value As Boolean)
            ButtonStart.Enabled = Not value
        End Set
    End Property

    Public Property SelectedTabIndex As Integer
        Get
            Return TabControl1.SelectedIndex
        End Get
        Set(value As Integer)
            TabControl1.SelectedIndex = value
        End Set
    End Property

    Protected Overrides Sub OnLoad(e As EventArgs)
        Me.StartPosition = If(Owner Is Nothing, FormStartPosition.CenterScreen, FormStartPosition.CenterParent)
        Me.TopMost = True
        MyBase.OnLoad(e)
    End Sub

    Public Sub AddTab(text As String, icon As Image, form As Form)
        Dim tabPage As TabPage = New TabPage(text)
        tabPage.UseVisualStyleBackColor = True
        form.TopLevel = False
        form.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        tabPage.Controls.Add(form)

        TabControl1.TabPages.Add(tabPage)

        tabPage.ImageKey = Me.TabControl1.TabCount - 1
        imageList.Images.Add(tabPage.ImageKey, icon)

        form.Show()
        form.Dock = DockStyle.Top
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub
    Private Sub SetStrings()
        Me.ButtonOk.Text = My.Resources.Strings.Ok
        Me.ButtonCancel.Text = My.Resources.Strings.Cancel
        Me.ButtonStart.Text = My.Resources.Strings.Start

        Me.DowpDownButtonPresets.Text = My.Resources.Strings.Presets
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStrings()

        TabControl1.ImageList = imageList
    End Sub
End Class