Imports Mono.Addins
Public Class RendererManager
    Sub New(configDir As String, addinsDir As String, databaseDir As String)
        'AddinManager.Initialize( System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.), My.Application.Info.AssemblyName), System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Addins"))
        AddinManager.Initialize(configDir, addinsDir, databaseDir)
        AddinManager.Registry.Update()
    End Sub
    Public Function GetRendererNode(id As String) As TypeExtensionNode(Of EggzleLib.RendererAttribute)
        Dim rendererNodes = AddinManager.GetExtensionNodes(GetType(EggzleLib.Extend.Rendering.IRenderer))
        Dim node = From nodes As TypeExtensionNode(Of EggzleLib.RendererAttribute) In rendererNodes
                   Where nodes.Id = id
                   Select nodes
        If node.Count = 0 Then
            Return rendererNodes.Item(0)
        End If
        Return node.First
    End Function
    Public Function GetRendererList() As List(Of Settings.Models.RendererModel)
        Dim rendererList As New List(Of Settings.Models.RendererModel)
        For Each node As TypeExtensionNode(Of EggzleLib.RendererAttribute) In AddinManager.GetExtensionNodes(GetType(EggzleLib.Extend.Rendering.IRenderer))
            rendererList.Add(New Settings.Models.RendererModel(node.Id, node.Data.Name))
        Next
        Return rendererList
    End Function
End Class
