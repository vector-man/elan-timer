<Serializable>
Public Class MutableKeyValuePair(Of Tkey, TValue)
    Private _key As Tkey
    Sub New(key As Tkey, value As TValue)
        Me._key = key
        Me.Value = value
    End Sub
    Public ReadOnly Property Key As Tkey
        Get
            Return _key
        End Get
    End Property
    Public Property Value As TValue
End Class
