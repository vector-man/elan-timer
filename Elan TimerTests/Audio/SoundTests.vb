Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports ElanTimer


Namespace ElanTimer.Tests

    <TestClass()> Public Class SoundTests
        Private playbackCount = 0
        <TestMethod()> Public Sub LoadTest()
            Dim sound As New Sound()
            AddHandler sound.PlaybackStopped, AddressOf Sound_PlaybackStopped
            sound.Load("C:\Users\Michael\Documents\Visual Studio 2013\Projects\Elan Timer\bin\Debug\Data\Alarms\Military Alarm.wav")
            sound.Play()
            sound.Stop()
            sound.Load("C:\Users\Michael\Documents\Visual Studio 2013\Projects\Elan Timer\bin\Debug\Data\Alarms\Military Alarm.wav")
            sound.Play()
            sound.Stop()

            Assert.AreEqual(2, playbackCount)
        End Sub

        Private Sub Sound_PlaybackStopped()
            playbackCount += 1
        End Sub

    End Class


End Namespace


