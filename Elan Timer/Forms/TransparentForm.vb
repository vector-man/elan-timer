Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Public Class TransparentForm

    'Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
    '    Dim renderer = New VisualStyleRenderer("System.Windows.Forms.TabPage", 1, 0)
    '    'TabRenderer.DrawTabPage(e.Graphics, Me.ClientRectangle)
    '    renderer.DrawBackground(e.Graphics, Me.ClientRectangle)
    'End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.BackColor = Color.Transparent

        ' Add any initialization after the InitializeComponent() call.
    End Sub
End Class