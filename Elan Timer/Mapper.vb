Imports System.Reflection

Public Class Mapper
    Private _maps As Dictionary(Of String, Dictionary(Of String, String))
    Sub New()
        _maps = New Dictionary(Of String, Dictionary(Of String, String))
    End Sub
    Public Sub Create(Of T1, T2)()
        Create(Of T1, T2)(New Dictionary(Of String, String))
    End Sub
    Public Sub Create(Of T1, T2)(mappings As Dictionary(Of String, String))
        Dim key As String = GetKey(GetType(T1), GetType(T2))

        Dim properties1 As String() = GetProperties(GetType(T1)).Select(Function(p) p.Name).ToArray()
        Dim properties2 As String() = GetProperties(GetType(T2)).Select(Function(p) p.Name).ToArray()

        Dim common As String() = properties1.Intersect(properties2).ToArray()

        For Each p In common
            If Not mappings.ContainsKey(p) Then
                mappings.Add(p, p)
            End If
        Next
        _maps.Add(key, mappings)
    End Sub
    Public Sub Map(source As Object, target As Object)
        Map(source, target, Function(key) True)
    End Sub
    Public Sub Map(source As Object, target As Object, condition As Func(Of String, Boolean))
        Dim key As String = GetKey(source.GetType(), target.GetType())

        Dim map As Dictionary(Of String, String) = _maps(key)

        For Each p As KeyValuePair(Of String, String) In map
            If (condition.Invoke(p.Key)) Then
                Dim sourceProperty As PropertyInfo = source.GetType().GetProperty(p.Key)
                Dim targetProperty As PropertyInfo = target.GetType().GetProperty(p.Key)

                targetProperty.SetValue(target, sourceProperty.GetValue(source, Nothing), Nothing)
            End If
        Next

    End Sub

    Private Function GetProperties(t As Type) As PropertyInfo()
        Return t.GetProperties(BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
    End Function
    Private Function GetKey(T1 As Type, T2 As Type) As String
        Dim types As String() = New String() {T1.ToString(), T2.ToString()}
        Array.Sort(types)
        Return String.Join("_", types)
    End Function
End Class
