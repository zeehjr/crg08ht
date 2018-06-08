using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using QRCoder;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace CRG08.BO
{
    public static class RelatorioUtils
    {
        public static void GerarQrCode(string texto, string filename = "qrcode.png") { 
            var qrGenerator = new QRCodeGenerator();

            var qrCodeData = qrGenerator.CreateQrCode(texto, QRCodeGenerator.ECCLevel.M);

            var qrCodeImage = GetGraphic(qrCodeData);

            qrCodeImage.Save(filename, ImageFormat.Png);
        }

        public static GraphicsPath PegarRetangulos(QRCodeData data)
        {
            var size = data.ModuleMatrix.Count;
            var graph = new GraphicsPath();

            for (var x = 0; x < size - 6; x++)
            {
                for (var y = 0; y < size - 6; y++)
                {
                    if (data.ModuleMatrix[y][x] == true)
                    {
                        var isLittleSquare = true;
                        var isSquare = true;
                        for (var xs = x; xs < x + 7; xs++)
                        {
                            if (!data.ModuleMatrix[y][xs])
                            {
                                isSquare = false;
                                break;
                            }
                            if (!data.ModuleMatrix[y + 6][xs])
                            {
                                isSquare = false;
                                break;
                            }
                        }
                        for (var ys = y; ys < y + 7; ys++)
                        {
                            if (!data.ModuleMatrix[ys][x])
                            {
                                isSquare = false;
                                break;
                            }
                            if (!data.ModuleMatrix[ys][x + 6])
                            {
                                isSquare = false;
                                break;
                            }
                        }

                        if (isSquare && data.ModuleMatrix[y + 3][x + 3])
                        {
                            graph.AddRectangle(new System.Drawing.Rectangle(x * 4, y * 4, 7 * 4, 7 * 4));
                        }
                        else
                        {
                            for (var xs = x; xs < x + 5; xs++)
                            {
                                if (!data.ModuleMatrix[y][xs])
                                {
                                    isLittleSquare = false;
                                    break;
                                }
                                if (!data.ModuleMatrix[y + 4][xs])
                                {
                                    isLittleSquare = false;
                                    break;
                                }
                            }
                            for (var ys = y; ys < y + 5; ys++)
                            {
                                if (!data.ModuleMatrix[ys][x])
                                {
                                    isLittleSquare = false;
                                    break;
                                }
                                if (!data.ModuleMatrix[ys][x + 4])
                                {
                                    isLittleSquare = false;
                                    break;
                                }
                            }

                            if (isLittleSquare && data.ModuleMatrix[y + 2][x + 2])
                            {
                                var littleOk = true;
                                for (var i = y + 1; i < y + 4; i++)
                                {
                                    if (data.ModuleMatrix[i][x + 1])
                                    {
                                        littleOk = false;
                                        break;
                                    }
                                    if (data.ModuleMatrix[i][x + 3])
                                    {
                                        littleOk = false;
                                        break;
                                    }
                                }
                                if (!littleOk) continue;
                                for (var i = x + 1; i < x + 4; i++)
                                {
                                    if (data.ModuleMatrix[y + 1][i])
                                    {
                                        littleOk = false;
                                        break;
                                    }
                                    if (data.ModuleMatrix[y + 3][i])
                                    {
                                        littleOk = false;
                                        break;
                                    }
                                }
                                if (littleOk)
                                    graph.AddRectangle(new System.Drawing.Rectangle(x * 4, y * 4, 5 * 4, 5 * 4));
                            }
                        }
                    }
                }
            }


            return graph;
        }

        public static Bitmap GetGraphic(QRCodeData qrCodeData)
        {
            var pixelsPerModule = 4;
            var darkColor = System.Drawing.Color.FromArgb(255, 56, 56, 56);
            var lightColor = System.Drawing.Color.White;
            Bitmap icon = Properties.Resources.ApenasLogoDigisystem;
            icon = ChangeOpacity(icon, 0.3F);
            //Bitmap icon = null;
            var iconSizePercent = 80;
            var iconBorderWidth = 1;
            var drawQuietZones = true;




            var size = (qrCodeData.ModuleMatrix.Count - (drawQuietZones ? 0 : 8)) * pixelsPerModule;
            var offset = drawQuietZones ? 0 : 4 * pixelsPerModule;

            var bmp = new Bitmap(size, size, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            var gfx = Graphics.FromImage(bmp);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.CompositingQuality = CompositingQuality.HighQuality;
            gfx.Clear(lightColor);

            var drawIconFlag = icon != null && iconSizePercent > 0 && iconSizePercent <= 100;

            GraphicsPath iconPath = null;
            float iconDestWidth = 0, iconDestHeight = 0, iconX = 0, iconY = 0;

            if (drawIconFlag)
            {
                iconDestWidth = (iconSizePercent * bmp.Width / 100f) + 2;
                iconDestHeight = drawIconFlag ? (iconDestWidth * icon.Height / icon.Width) + 2 : 0;
                iconX = (bmp.Width - iconDestWidth) / 2;
                iconY = (bmp.Height - iconDestHeight) / 2;

                var centerDest = new RectangleF(iconX - iconBorderWidth + 1, iconY - iconBorderWidth + 1, (iconDestWidth + iconBorderWidth * 2) - 2, (iconDestHeight + iconBorderWidth * 2) - 2);
                //iconPath = this.CreateRoundedRectanglePath(centerDest, iconBorderWidth * 2);
                iconPath = CreateRoundedRectanglePath(centerDest, 1);
            }

            var retangulos = PegarRetangulos(qrCodeData);

            gfx.FillPath(new SolidBrush(System.Drawing.Color.Black), retangulos);

            //if (drawIconFlag)
            //{
            //    iconPath = new GraphicsPath();
            //    //iconPath.AddString("digisystem", new System.Drawing.FontFamily("Arial"), (int)System.Drawing.FontStyle.Bold, 74, new System.Drawing.Point(size / 2, size / 2), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            //    iconPath.AddString("D", new System.Drawing.FontFamily("Arial"), (int)System.Drawing.FontStyle.Bold, 400, new System.Drawing.Point(size / 2, size / 2 + 40), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            //}

            var lightBrush = new SolidBrush(lightColor);
            var darkBrush = new SolidBrush(darkColor);


            for (var x = 0; x < size + offset; x = x + pixelsPerModule)
            {
                for (var y = 0; y < size + offset; y = y + pixelsPerModule)
                {
                    var module = qrCodeData.ModuleMatrix[(y + pixelsPerModule) / pixelsPerModule - 1][(x + pixelsPerModule) / pixelsPerModule - 1];
                    if (module)
                    {
                        var r = new System.Drawing.Rectangle(x - offset, y - offset, pixelsPerModule, pixelsPerModule);

                        var region = new Region(r);
                        //if (drawIconFlag)
                        //{
                        //    region.Exclude(iconPath);
                        //}
                        region.Exclude(retangulos);
                        gfx.FillRegion(darkBrush, region);
                        //if (drawIconFlag)
                        //{
                        //    var region = new Region(r);
                        //    region.Exclude(iconPath);
                        //    gfx.FillRegion(darkBrush, region);
                        //}
                        //else
                        //{
                        //    gfx.FillRectangle(darkBrush, r);
                        //}
                    }
                    else
                        gfx.FillRectangle(lightBrush, new System.Drawing.Rectangle(x - offset, y - offset, pixelsPerModule, pixelsPerModule));

                }
            }

            //if (drawIconFlag)
            //{
            //    //gfx.FillPath(new SolidBrush(System.Drawing.Color.Gray), iconPath);
            //    var pen1 = new System.Drawing.Pen(System.Drawing.Color.White, 6);
            //    var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(255, 56, 56, 56), 8);
            //    pen.Color = System.Drawing.Color.FromArgb(225, 15, 15, 15);
            //    //gfx.DrawPath(pen1, iconPath);
            //    //gfx.DrawPath(pen, iconPath);
            //    gfx.FillPath(new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(200, 56, 56, 56)), iconPath);
            //}

            if (drawIconFlag)
            {
                var rIcon = new System.Drawing.RectangleF(iconX, iconY, iconDestWidth, iconDestHeight);
                var regionIcon = new Region(rIcon);
                regionIcon.Exclude(retangulos);

                var iconDestRect = new RectangleF(iconX, iconY, iconDestWidth, iconDestHeight);
                gfx.Clip = regionIcon;
                gfx.DrawImage(icon, iconDestRect, new RectangleF(0, 0, icon.Width, icon.Height), GraphicsUnit.Pixel);
            }

            gfx.Save();
            return bmp;
        }

        public static Bitmap ChangeOpacity(System.Drawing.Image img, float opacityvalue)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height); // Determining Width and Height of Source Image
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix();
            colormatrix.Matrix33 = opacityvalue;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();   // Releasing all resource used by graphics 
            return bmp;
        }

        public static GraphicsPath CreateRoundedRectanglePath(RectangleF rect, int cornerRadius)
        {
            var roundedRect = new GraphicsPath();
            roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        }
    }
}
