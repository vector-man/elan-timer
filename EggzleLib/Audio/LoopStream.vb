Imports NAudio.Wave
''' <summary>
''' Stream for looping playback
''' </summary>
Public Class LoopStream
    Inherits WaveStream
    Private sourceStream As WaveStream

    ''' <summary>
    ''' Creates a new Loop stream
    ''' </summary>
    ''' <param name="sourceStream">The stream to read from. Note: the Read method of this stream should return 0 when it reaches the end
    ''' or else we will not loop to the start again.</param>
    Public Sub New(sourceStream As WaveStream)
        Me.sourceStream = sourceStream
        Me.EnableLooping = True
    End Sub

    ''' <summary>
    ''' Use this to turn looping on or off
    ''' </summary>
    Public Property EnableLooping() As Boolean
        Get
            Return m_EnableLooping
        End Get
        Set(value As Boolean)
            m_EnableLooping = Value
        End Set
    End Property
    Private m_EnableLooping As Boolean

    ''' <summary>
    ''' Return source stream's wave format
    ''' </summary>
    Public Overrides ReadOnly Property WaveFormat() As WaveFormat
        Get
            Return sourceStream.WaveFormat
        End Get
    End Property

    ''' <summary>
    ''' LoopStream simply returns
    ''' </summary>
    Public Overrides ReadOnly Property Length() As Long
        Get
            Return sourceStream.Length
        End Get
    End Property

    ''' <summary>
    ''' LoopStream simply passes on positioning to source stream
    ''' </summary>
    Public Overrides Property Position() As Long
        Get
            Return sourceStream.Position
        End Get
        Set(value As Long)
            sourceStream.Position = value
        End Set
    End Property

    Public Overrides Function Read(buffer As Byte(), offset As Integer, count As Integer) As Integer
        Dim totalBytesRead As Integer = 0

        While totalBytesRead < count
            Dim bytesRead As Integer = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead)
            If bytesRead = 0 Then
                If sourceStream.Position = 0 OrElse Not EnableLooping Then
                    ' something wrong with the source stream
                    Exit While
                End If
                ' loop
                sourceStream.Position = 0
            End If
            totalBytesRead += bytesRead
        End While
        Return totalBytesRead
    End Function
End Class