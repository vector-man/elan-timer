Public Class CheckedGroupBox
    Inherits GroupBox

    Private WithEvents _checkBox As CheckBox

    ' Add the CheckBox to the control.
    Public Sub New()
        MyBase.New()

        _checkBox = New CheckBox
        _checkBox.Location = New Point(8, 0)
        _checkBox.Margin = New Padding(0)
        Me.Text = "CheckedGroupBox"
        _checkBox.AutoSize = True
        Me.Controls.Add(_checkBox)
    End Sub

    ' Keep the CheckBox text synced with our text.
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal Value As String)
            MyBase.Text = Value
            _checkBox.Text = Value

            Dim gr As Graphics = Me.CreateGraphics
            Dim s As SizeF = gr.MeasureString(MyBase.Text, _
                Me.Font)
            _checkBox.Size = New Size(s.Width + 20, _
                s.Height)
        End Set
    End Property

    ' Delegate to CheckBox.Checked.
    Public Property Checked() As Boolean
        Get
            Return _checkBox.Checked
        End Get
        Set(ByVal Value As Boolean)
            _checkBox.Checked = Value
        End Set
    End Property

    ' Enable/disable contained controls.
    Private Sub EnableDisableControls()
        For Each ctl As Control In Me.Controls
            If Not (ctl Is _checkBox) Then
                Try
                    ctl.Enabled = _checkBox.Checked
                Catch ex As Exception
                End Try
            End If
        Next ctl
    End Sub

    ' Enable/disable contained controls.
    Private Sub CheckBox_CheckedChanged(ByVal sender As _
        Object, ByVal e As System.EventArgs) Handles _
        _checkBox.CheckedChanged
        EnableDisableControls()
    End Sub

    ' Enable/disable contained controls.
    ' We do this here to set editability
    ' when the control is first loaded.
    Private Sub CheckBox_Layout(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.LayoutEventArgs) _
        Handles _checkBox.Layout
        EnableDisableControls()
    End Sub
End Class