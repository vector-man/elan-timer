Imports PropertyChanged
<ImplementPropertyChanged>
Public Class CheckedGroupBox
    Inherits GroupBox

    Private _checkBox As CheckBox

    ' Add the CheckBox to the control.
    Public Sub New()
        MyBase.New()

        _checkBox = New CheckBox
        _checkBox.Location = New Point(8, 0)
        _checkBox.Margin = New Padding(0)
        _checkBox.AutoSize = True
        Me.Controls.Add(_checkBox)


        _checkBox.DataBindings.Add("Checked", Me, "Checked")

        AddHandler _checkBox.CheckedChanged, AddressOf EnableDisableControls
        AddHandler _checkBox.Layout, AddressOf EnableDisableControls

        Me.Text = "CheckedGroupBox"
    End Sub

    ' Keep the CheckBox text synced with our text.
    Public Overrides Property Text() As String
        Get
            Return _checkBox.Text
        End Get
        Set(ByVal Value As String)
            _checkBox.Text = Value

            Dim gr As Graphics = Me.CreateGraphics
            Dim s As SizeF = gr.MeasureString(_checkBox.Text, _
                Me.Font)
            _checkBox.Size = New Size(s.Width + 20, _
                s.Height)
        End Set
    End Property

    Public Property Checked As Boolean

    ' Enable/disable contained controls.
    Private Sub EnableDisableControls()
        For Each ctl As Control In Me.Controls
            If (ctl IsNot _checkBox) Then
                Try
                    ctl.Enabled = _checkBox.Checked
                Catch ex As Exception
                End Try
            End If
        Next ctl
    End Sub
End Class