Imports System

Namespace CodeIsle.Plugins.Renderers
    Public Interface IRenderPlugin
        Inherits IPlugin
        Sub Render(e As PaintEventArgs, settings As Timers.AlarmTimerContext, surfaceSize As Size)
    End Interface
End Namespace
