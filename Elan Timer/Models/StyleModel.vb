Imports PropertyChanged
<ImplementPropertyChanged>
Public Class StyleModel
    Implements ICloneable

    Public Property DisplayFont As Font

    Public Property GrowToFit As Boolean

    Public Property BackgroundColor As Color

    Public Property ForegroundColor As Color

    Public Property Transparency As Integer

    Public Property DisplayFormat As String

    Public Function Clone() As Object Implements ICloneable.Clone
        Return New StyleModel() With {.BackgroundColor = Me.BackgroundColor,
                                      .DisplayFont = Me.DisplayFont.Clone(),
                                      .DisplayFormat = Me.DisplayFormat,
                                      .ForegroundColor = Me.ForegroundColor,
                                      .GrowToFit = Me.GrowToFit,
                                      .Transparency = Me.Transparency}
    End Function
End Class