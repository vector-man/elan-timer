Imports Mono.Addins
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Namespace Extend.Renderers
    <TypeExtensionPoint("/Eggzle/Render")>
    Public Interface IRenderer
        Sub Initialize(timerInfo As EggzleLib.Information.ITimerInfo, renderInfo As EggzleLib.Information.IRenderInfo)
        Sub Render(e As PaintEventArgs, canvasSize As Size)
    End Interface
End Namespace