Imports System.IO

Public Interface IImporterExporter
    Function Import(Of T)(stream As Stream)
    Sub Export(Of T)(ByRef obj As Object, stream As Stream)
End Interface
