Imports System.ComponentModel
Imports PropertyChanged
<ImplementPropertyChanged>
Public Class CheckedGroupBox
    Inherits GroupBox

    Private _checkBox As CheckBox

    ' Add the CheckBox to the control.
    Public Sub New()
        MyBase.New()
        _checkBox = New CheckBox()
        _checkBox.Location = New Point(8, 0)
        _checkBox.Margin = New Padding(0)
        _checkBox.AutoSize = True
        Controls.Add(_checkBox)


        _checkBox.DataBindings.Add("Checked", Me, "Checked")

        AddHandler _checkBox.CheckedChanged, AddressOf EnableDisableControls
        AddHandler _checkBox.Layout, AddressOf EnableDisableControls
        Me.Text = "CheckedGroupBox"
    End Sub

    ' Keep the CheckBox text synced with our text.
    <Browsable(True)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overrides Property Text As String
        Get
            If (Me.Site IsNot Nothing AndAlso Me.Site.DesignMode = True) Then
                Return _checkBox.Text
            Else
                Return String.Empty
            End If
        End Get
        Set(ByVal Value As String)
            MyBase.Text = String.Empty
            _checkBox.Text = Value

            Dim gr As Graphics = Me.CreateGraphics
            Dim s As SizeF = gr.MeasureString(_checkBox.Text, _
                Me.Font)
            _checkBox.Size = New Size(s.Width + 20, _
                s.Height)
            MyBase.OnTextChanged(New EventArgs())
        End Set
    End Property


    <Browsable(True)>
    Public Property Checked As Boolean

    ' Enable/disable contained controls.
    Private Sub EnableDisableControls(sender As Object, e As EventArgs)
        For Each ctl As Control In Me.Controls
            If (ctl IsNot _checkBox) Then
                Try
                    ctl.Enabled = _checkBox.Checked
                Catch ex As Exception
                End Try
            End If
        Next ctl
    End Sub
    Protected Overrides Sub Dispose(disposing As Boolean)
        MyBase.Dispose(disposing)
        If (disposing) Then
            RemoveHandler _checkBox.CheckedChanged, AddressOf EnableDisableControls
            RemoveHandler _checkBox.Layout, AddressOf EnableDisableControls
            _checkBox.Dispose()
        End If
    End Sub
End Class