Public Class ApplicationModel
    Sub New()
        MyClass.AlwaysOnTop = False
        MyClass.EnableAutomaticUpdateChecking = True
        MyClass.NumberOfDaysBetweenUpdateChecks = 90
        MyClass.OpacityLevel = 100
    End Sub
    Public Property AlwaysOnTop As Boolean
    Public Property EnableAutomaticUpdateChecking As Boolean
    Public Property NumberOfDaysBetweenUpdateChecks As Integer
    Public Property OpacityLevel As Integer
    'Public Function Defaults() As ApplicationSettings
    '    MyClass.AlwaysOnTop = False
    '    MyClass.EnableAutomaticUpdateChecking = True
    '    MyClass.NumberOfDaysBetweenUpdateChecks = 90
    '    MyClass.OpacityLevel = 100
    '    Return Me
    'End Function
End Class
