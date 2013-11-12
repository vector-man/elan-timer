﻿Imports System.Drawing
Imports System.Text
Public Class EggzleRenderer : Implements Rendering.IRenderer, IDisposable

    Private stringAlignment As StringFormat
    Private Const MaximumFontSize = Int16.MaxValue
    Private backgroundBrush As SolidBrush
    Private foregroundBrush As SolidBrush
    Sub New()
        stringAlignment = New StringFormat
        stringAlignment.Alignment = Drawing.StringAlignment.Center
        stringAlignment.LineAlignment = Drawing.StringAlignment.Center
        backgroundBrush = New SolidBrush(Color.Black)
        foregroundBrush = New SolidBrush(Color.Black)
    End Sub

    Public Sub Render(args As RenderArgs) Implements Rendering.IRenderer.Render
        Dim info As Information.ITimerInfo = CType(args.Data, Information.ITimerInfo)

        Dim time As String
        If ((info.IsExpired) AndAlso (Not args.Note = String.Empty)) Then
            time = args.Note
        Else
            time = String.Format(args.FormatProvider, String.Concat("{0:", args.Format, "}"), info.Current)
        End If

        Dim prefferedFontSize As Long
        If (args.SizeToFit) Then
            prefferedFontSize = MaximumFontSize
        Else
            prefferedFontSize = args.Font.Size
        End If

        ' Dim minimumFontSize = If(prefferedFontSize = MaximumFontSize, 12, prefferedFontSize)

        Using f2 As Font = AppropriateFont(args.Graphics, args.Font.Size, prefferedFontSize, args.ClientRectangle.Size, time, args.Font)
            args.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
            '  args.Graphics.Clear(args.BackgroundColor)

            backgroundBrush.Color = args.BackgroundColor
            args.Graphics.FillRectangle(backgroundBrush, args.ClientRectangle)

            foregroundBrush.Color = args.ForegroundColor
            args.Graphics.DrawString(time, f2, foregroundBrush, args.ClientRectangle, stringAlignment)
        End Using
    End Sub

    Private Function AppropriateFont(ByVal g As System.Drawing.Graphics, ByVal minFontSize As Integer, ByVal maxFontSize As Integer, ByVal layoutSize As Size, ByVal s As String, ByVal f As Font) As Font
        If maxFontSize = minFontSize Then
            f = New Font(f.FontFamily, minFontSize, f.Style)
        End If
        Dim extent As SizeF
        extent = g.MeasureString(s, f)

        If maxFontSize <= minFontSize Then
            Return f
        End If

        Dim hRatio As Single = layoutSize.Height / extent.Height
        Dim wRatio As Single = layoutSize.Width / extent.Width

        Dim ratio As Single = If((hRatio < wRatio), hRatio, wRatio)

        Dim newSize As Single = f.Size * ratio

        If newSize < minFontSize Then
            newSize = minFontSize
        ElseIf newSize > maxFontSize Then
            newSize = maxFontSize
        End If

        f = New Font(f.FontFamily, newSize, f.Style)

        Return f
    End Function
    Private Function BestFontSize(g As System.Drawing.Graphics, z As Size, f As Font, s As String) As Font
        Dim p As SizeF = g.MeasureString(s, f)
        Dim hRatio As Double = z.Height / p.Height
        Dim wRatio As Double = z.Width / p.Width
        Dim ratio As Double = Math.Min(hRatio, wRatio)
        Return New Font(f.FontFamily, CType(f.Size * ratio, Single), f.Style)
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                stringAlignment.Dispose()
                backgroundBrush.Dispose()
                foregroundBrush.Dispose()
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class


