Imports Mono.Addins
Imports System
Imports System.Drawing
Imports System.Windows.Forms
<Assembly: AddinRoot("Eggzle", "0.0.1")> 
Namespace Extend.Rendering
    '<TypeExtensionPoint("/Eggzle/Rendering", ExtensionAttributeType:=GetType(RendererAttribute), NodeType:=GetType(TypeExtensionNode))>
    '<TypeExtensionPoint("/Eggzle/Rendering")>
    <TypeExtensionPoint(ExtensionAttributeType:=GetType(RendererAttribute), NodeType:=GetType(TypeExtensionNode))>
    Public Interface IRenderer
        Sub Render(args As RenderArgs)
    End Interface
End Namespace