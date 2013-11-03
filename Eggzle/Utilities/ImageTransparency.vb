Imports System.Drawing
Imports System.Drawing.Imaging

Namespace ImageUtils
    Class ImageTransparency
        Public Shared Function ChangeOpacity(img As Image, opacityvalue As Single) As Bitmap
            Dim bmp As New Bitmap(img.Width, img.Height)
            ' Determining Width and Height of Source Image
            Dim g As Graphics = Graphics.FromImage(bmp)
            Dim colormatrix As New ColorMatrix()
            colormatrix.Matrix33 = opacityvalue
            Dim imgAttribute As New ImageAttributes()
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.[Default], ColorAdjustType.Bitmap)
            g.DrawImage(img, New Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, _
                GraphicsUnit.Pixel, imgAttribute)
            g.Dispose()
            ' Releasing all resource used by graphics
            Return bmp
        End Function
    End Class
End Namespace