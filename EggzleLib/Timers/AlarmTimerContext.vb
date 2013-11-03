Imports System.Drawing
Namespace CodeIsle.Timers
    Public Class AlarmTimerContext
        Private timer As CodeIsle.Timers.AlarmTimer
        Public Property TimeStopped As Boolean
        Public Property Size As Size
        Public Property PreviewOpacity As Double = 100

        Sub New(ByRef timer As CodeIsle.Timers.AlarmTimer)
            MyClass.timer = timer
        End Sub

        Public ReadOnly Property Enabled As Boolean
            Get
                Return If(timer IsNot Nothing, timer.Enabled, False)
            End Get
        End Property
        Public ReadOnly Property Remaining As TimeSpan
            Get
                Return If(timer IsNot Nothing, timer.Remaining, New TimeSpan())
            End Get
        End Property
        Public ReadOnly Property Current As TimeSpan
            Get
                Return If(timer IsNot Nothing, timer.Current, New TimeSpan())
            End Get
        End Property
        Public ReadOnly Property AlarmSet As Boolean
            Get
                Return If(timer IsNot Nothing, timer.AlarmSet, False)
            End Get
        End Property
        Public ReadOnly Property Elapsed As TimeSpan
            Get
                Return If(timer IsNot Nothing, timer.Elapsed, New TimeSpan())
            End Get
        End Property
        Public ReadOnly Property Duration As TimeSpan
            Get
                Return If(timer IsNot Nothing, timer.Duration, New TimeSpan())
            End Get
        End Property
    End Class
End Namespace
