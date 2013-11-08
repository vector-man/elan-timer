Imports System
Imports System.Drawing
Imports System.Windows.Forms
Namespace Rendering
    Public Interface IRenderer
        Sub Render(args As RenderArgs)
    End Interface
End Namespace