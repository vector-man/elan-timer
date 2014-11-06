Imports System.ComponentModel
' From Jaex at: http://stackoverflow.com/questions/10803184/windows-forms-button-with-drop-down-menu
Public Class DowpDownButton
    Inherits Button
    Public Property Menu() As ContextMenuStrip
        Get
            Return m_Menu
        End Get
        Set(value As ContextMenuStrip)
            m_Menu = value
        End Set
    End Property
    Private m_Menu As ContextMenuStrip

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)

        If Menu IsNot Nothing AndAlso e.Button = MouseButtons.Left Then
            Menu.Show(Me, New Point(0, Me.Height))
        End If
    End Sub

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        MyBase.OnPaint(pevent)

        Dim arrowX As Integer = ClientRectangle.Width - 14
        Dim arrowY As Integer = ClientRectangle.Height / 2 - 1

        Dim brush As Brush = If(Enabled, SystemBrushes.ControlText, SystemBrushes.ButtonShadow)
        Dim arrows As Point() = New Point() {New Point(arrowX, arrowY), New Point(arrowX + 7, arrowY), New Point(arrowX + 3, arrowY + 4)}
        pevent.Graphics.FillPolygon(brush, arrows)
    End Sub
End Class
