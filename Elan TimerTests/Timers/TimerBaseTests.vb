Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ElanTimer.CodeIsle.Timers


Namespace ElanTimer.CodeIsle.Timers.Tests

    <TestClass()> Public Class TimerBaseTests

        <TestMethod()> Public Sub ResetTest()
            Dim timer As New AlarmTimer(TimeSpan.Zero)

            timer.Reset(New TimeSpan(0, 0, 0, 10), New TimeSpan(0, 0, 32), 3)

            Assert.AreEqual(3, timer.ElapsedRestarts)
            Assert.AreEqual(New TimeSpan(0, 0, 2), timer.Elapsed)
        End Sub
    End Class


End Namespace


