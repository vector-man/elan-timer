Public Class BorderlessToolStripSystemRenderer
    Inherits ToolStripProfessionalRenderer
    Sub New()
        MyBase.New()
        Me.RoundedEdges = False
    End Sub
    Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
        If (e.ToolStrip.GetType() = GetType(ToolStrip)) Then
        Else
            MyBase.OnRenderToolStripBorder(e)
        End If
    End Sub
    Protected Overrides Sub OnRenderSeparator(e As ToolStripSeparatorRenderEventArgs)
        If (Not e.Vertical OrElse (e.Item Is Nothing OrElse Not TypeOf e.Item Is ToolStripSeparator)) Then
            MyBase.OnRenderSeparator(e)
        Else
            Dim bounds = New Rectangle(Point.Empty, e.Item.Size)
            bounds.Y += 3
            bounds.Height = Math.Max(0, bounds.Height - 6)
            If (bounds.Height >= 4) Then bounds.Inflate(0, -2)
            Using pen = New Pen(SeparatorBackColor)
                Dim x As Integer = bounds.Width / 2
                e.Graphics.DrawLine(pen, x, bounds.Top, x, bounds.Bottom - 1)
                Using pen1 = New Pen(SeparatorForeColor)
                    e.Graphics.DrawLine(pen1, x + 1, bounds.Top + 1, x + 1, bounds.Bottom)
                End Using
            End Using
        End If
    End Sub
    Property SeparatorBackColor As Color
    Property SeparatorForeColor As Color
End Class
