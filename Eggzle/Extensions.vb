Imports System.Runtime.CompilerServices
Module ListExtensions
    <Extension()>
    Public Function Clone(Of T As ICloneable)(listToClone As IList(Of T)) As IList(Of T)
        Return listToClone.Select(Function(item) DirectCast(item.Clone(), T)).ToList()
    End Function
End Module