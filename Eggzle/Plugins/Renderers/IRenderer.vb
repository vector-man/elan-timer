Imports System

Namespace CodeIsle.Plugins.Renderers
    Public Interface IRenderer
        Inherits IPlugin
        Sub Render(e As PaintEventArgs, settings As TimerRenderContext, surfaceSize As Size)
    End Interface
End Namespace
