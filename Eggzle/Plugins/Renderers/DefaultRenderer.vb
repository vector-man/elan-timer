Imports System.Runtime.InteropServices
Namespace CodeIsle.Plugins.Renderers
    <Guid("e993d2a8-f05d-4333-a9ab-a4b0b9dcf005")>
    Public Class DefaultRenderer
        Implements IRenderPlugin
        'Private sw As New Stopwatch
        Private stringAlignment As StringFormat

        Sub New()
            stringAlignment = New StringFormat
            stringAlignment.Alignment = Drawing.StringAlignment.Center
            stringAlignment.LineAlignment = Drawing.StringAlignment.Center
        End Sub

        Private Function AppropriateFont(ByVal g As System.Drawing.Graphics, ByVal minFontSize As Integer, ByVal maxFontSize As Integer, ByVal layoutSize As Size, ByVal s As String, ByVal f As Font,
                                         ByRef extent As SizeF) As Font
            If maxFontSize = minFontSize Then
                f = New Font(f.FontFamily, minFontSize, f.Style)
            End If

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
            extent = g.MeasureString(s, f)

            Return f
        End Function
        Private Function BestFontSize(g As System.Drawing.Graphics, z As Size, f As Font, s As String) As Font
            Dim p As SizeF = g.MeasureString(s, f)
            Dim hRatio As Double = z.Height / p.Height
            Dim wRatio As Double = z.Width / p.Width
            Dim ratio As Double = Math.Min(hRatio, wRatio)
            Return New Font(f.FontFamily, CType(f.Size * ratio, Single), f.Style)
        End Function

        Public Sub Render(e As PaintEventArgs, context As EggzleLib.AlarmTimerContext, surfaceSize As Size) Implements IRenderPlugin.Render
            'sw.Start()

            'Dim time As String = settings.Time.ToString("hh\:mm\:ss\:fff")
            'Dim time As String = context.Timer.Current.ToString("hh\:mm\:ss\:fff")
            Dim time As String = context.Current.ToString("hh\:mm\:ss")
            ' Using f As New Font("Letters Laughing", 1, FontStyle.Bold)
            'Using f As New Font("V5 Prophit", 1, FontStyle.Bold)
            'Using f As New Font("Crystal", 32, FontStyle.Italic)
            'Using f As New Font("Press Start 2P", 32, FontStyle.Regular) ' Good
            'Using f As New Font("digital display tfb", 32, FontStyle.Regular)
            'Using f As New Font("Let's Go Digital", 12, FontStyle.Bold Or FontStyle.Italic)
            'Using f As New Font("LCD Phone", 32, FontStyle.Regular)
            'Using f As New Font("Airborne Pilot", 32, FontStyle.Regular)
            'Using f As New Font("Hybrid", 32, FontStyle.Bold)
            'Using f As New Font("Airstrip Four", 32, FontStyle.Regular)
            'Using f As New Font("Teleindicadores 1", 32, FontStyle.Regular)
            'Using f As New Font("Alfphabet", 32, FontStyle.Regular)
            'Using f As New Font("Telegrama", 32, FontStyle.Regular) ' Good
            'Using f As New Font("White Rabbit", 32, FontStyle.Regular) ' Good
            Using f As New Font("MonoMMM_5", 32, FontStyle.Regular) ' Good
                Dim size As SizeF
                Using f2 As Font = AppropriateFont(e.Graphics, 12, 99999, surfaceSize, time, f, size)
                    'Dim p As New Point(((settings.Size.Width - size.Width) / 2), ((settings.Size.Height - size.Height) / 2))
                    'e.Graphics.Clear(Color.White)

                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
                    'e.Graphics.Clear(Color.FromArgb(((settings.PreviewOpacity / 100) * 255), settings.BackgroundColor))

                    'e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, surfaceSize.Width, surfaceSize.Height)
                    'e.Graphics.DrawString(time, f2, New SolidBrush(Color.ForestGreen), New Rectangle(New Point(0, 0), surfaceSize), stringAlignment)
                    e.Graphics.FillRectangle(New SolidBrush(Color.GhostWhite), 0, 0, surfaceSize.Width, surfaceSize.Height)
                    e.Graphics.DrawString(time, f2, New SolidBrush(Color.OrangeRed), New Rectangle(New Point(0, 0), surfaceSize), stringAlignment)
                End Using
            End Using
            ' Debug.Print(GetType(Renderers.DefaultRenderer).GUID.ToString)

            'sw.Stop()
            'Debug.Print(sw.Elapsed.TotalMilliseconds)
            'sw.Reset()
            'End
        End Sub

        Public Sub Install() Implements IPlugin.Install

        End Sub


        Public Sub Uninstall() Implements IPlugin.Uninstall

        End Sub

        Public Sub Load() Implements IPlugin.Load

        End Sub

        Public Sub Save() Implements IPlugin.Save

        End Sub

        Public Sub ShowSettigs() Implements IPlugin.ShowSettigs

        End Sub

        Public ReadOnly Property AuthorEmail As String Implements IPlugin.AuthorEmail
            Get
                Return "admin@codeisle.com"
            End Get
        End Property

        Public ReadOnly Property AuthorName As String Implements IPlugin.AuthorName
            Get
                Return "codeisle.com"
            End Get
        End Property

        Public ReadOnly Property AuthorWebsite As String Implements IPlugin.AuthorWebsite
            Get
                Return "http://www.codeisle.com"
            End Get
        End Property

        Public ReadOnly Property Description As String Implements IPlugin.Description
            Get
                Return "Default Eggzle renderer."
            End Get
        End Property

        Public ReadOnly Property Id As Guid Implements IPlugin.Id
            Get
                Return MyClass.GetType.GUID
            End Get
        End Property

        Public ReadOnly Property Name As String Implements IPlugin.Name
            Get

                Return "Eggzle"
            End Get
        End Property

        Public ReadOnly Property Version As Version Implements IPlugin.Version
            Get
                Return My.Application.Info.Version
            End Get
        End Property
    End Class
End Namespace