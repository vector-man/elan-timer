' Taken from: http://stackoverflow.com/questions/16361685/how-to-get-name-by-string-value-from-a-net-resource-resx-file.
Imports System.Resources
Imports System.Threading
Imports System.Reflection

Public Class ResourceHelper

    ''' <summary>
    ''' ResourceHelper
    ''' </summary>
    ''' <param name="resourceName">i.e. "Namespace.ResourceFileName"</param>
    ''' <param name="assembly">i.e. GetType().Assembly if working on the local assembly</param>
    Public Sub New(resourceName As String, assembly As Assembly)
        ResourceManager = New ResourceManager(resourceName, assembly)
    End Sub

    Private Property ResourceManager() As ResourceManager
        Get
            Return m_ResourceManager
        End Get
        Set(value As ResourceManager)
            m_ResourceManager = value
        End Set
    End Property
    Private m_ResourceManager As ResourceManager

    Public Function GetResourceName(value As String) As String
        Dim entry As DictionaryEntry = ResourceManager.GetResourceSet(Thread.CurrentThread.CurrentCulture, True, True).OfType(Of DictionaryEntry)().FirstOrDefault(Function(dictionaryEntry) dictionaryEntry.Value.ToString() = value)
        Return entry.Key.ToString()
    End Function

    Public Function GetResourceValue(name As String) As String
        Dim value As String = ResourceManager.GetString(name)
        Return If(Not String.IsNullOrEmpty(value), value, Nothing)
    End Function
End Class