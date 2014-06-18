Namespace Rendering
    Public Class Surface
        Inherits Label

        Sub New()
            MyBase.New()
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.SetStyle(ControlStyles.ResizeRedraw, True)
            Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        End Sub
    End Class
End Namespace