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
End Class
