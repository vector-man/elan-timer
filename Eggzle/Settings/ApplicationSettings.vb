Public Class ApplicationSettings
    Sub New()
        MyClass.AlwaysOnTop = False
        MyClass.EnableAutomaticUpdateChecking = True
        MyClass.NumberOfDaysBetweenUpdateChecks = 90
    End Sub
    Public Property AlwaysOnTop As Boolean
    Public Property EnableAutomaticUpdateChecking As Boolean
    Public Property NumberOfDaysBetweenUpdateChecks As Integer
End Class
