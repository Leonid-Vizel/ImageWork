using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;

namespace ZBitmap
{
    /// <summary>
    /// Основной класс библиотеки ZBitmap для преобразования изображений
    /// </summary>
    public static class Transformations
    {
        /// <summary>
        /// Статический конструктор класса для инициализации цветовых матриц
        /// </summary>
        static Transformations()
        {
            blackWhiteMatrix = new ColorMatrix(
                   new float[][]
                   {
                     new float[] {.3f, .3f, .3f, 0, 0},
                     new float[] {.59f, .59f, .59f, 0, 0},
                     new float[] {.11f, .11f, .11f, 0, 0},
                     new float[] {0, 0, 0, 1, 0},
                     new float[] {0, 0, 0, 0, 1}
                   });
            inverseColorMatrix = new ColorMatrix(
                   new float[][]
                   {
                    new float[] {-1, 0, 0, 0, 0},
                    new float[] {0, -1, 0, 0, 0},
                    new float[] { 0, 0, -1, 0, 0 },
                    new float[] { 0, 0, 0, 1, 0 },
                    new float[] { 1, 1, 1, 0, 1 }
                   });
        }

        #region ColorMatrixes
        /// <summary>
        /// Цветовая матрица для чёрно-белого преобразования цветов
        /// </summary>
        private static ColorMatrix blackWhiteMatrix;
        /// <summary>
        /// Цветовая матрица для инверсии цветов
        /// </summary>
        private static ColorMatrix inverseColorMatrix;
        #endregion

        /// <summary>
        /// Метод для перевода изображения в чёрно-белый формат
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        public static void ToBlackWhite(Bitmap initial)
        {
            using (Graphics graphics = Graphics.FromImage(initial))
            {
                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(blackWhiteMatrix);
                    graphics.DrawImage(initial, new Rectangle(0, 0, initial.Width, initial.Height), 0, 0, initial.Width, initial.Height, GraphicsUnit.Pixel, attributes);
                }
                graphics.Flush();
            }
        }

        /// <summary>
        /// Метод, добавляющий на Bitmap текст в опереденном месте
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="overlay">Объект с информацией о вставляемом тексте</param>
        public static void PasteText(Bitmap initial, TextOverlay overlay)
        {
            using (Graphics graphics = Graphics.FromImage(initial))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                if (overlay.Angle != 0)
                {
                    graphics.TranslateTransform(overlay.Location.X, overlay.Location.Y);
                    graphics.RotateTransform(overlay.Angle);
                    graphics.DrawString(overlay.Text, overlay.Font, new SolidBrush(overlay.Color), new Point(0, 0));
                }
                else
                {
                    graphics.DrawString(overlay.Text, overlay.Font, new SolidBrush(overlay.Color), overlay.Location);
                }
                graphics.Flush();
            }
        }

        /// <summary>
        /// Метод, последовательно вставляющий тексты на изображение
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="overlays">Массив с информацией о вставляемых текстах</param>
        public static void PasteTexts(Bitmap initial, params TextOverlay[] overlays)
        {
            if (overlays.Length == 0)
            {
                return;
            }
            using (Graphics graphics = Graphics.FromImage(initial))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                foreach (TextOverlay overlay in overlays)
                {
                    if (overlay.Angle != 0)
                    {
                        graphics.TranslateTransform(overlay.Location.X, overlay.Location.Y);
                        graphics.RotateTransform(overlay.Angle);
                        graphics.DrawString(overlay.Text, overlay.Font, new SolidBrush(overlay.Color), new Point(0, 0));
                        graphics.RotateTransform(-overlay.Angle);
                        graphics.TranslateTransform(-overlay.Location.X, -overlay.Location.Y);
                    }
                    else
                    {
                        graphics.DrawString(overlay.Text, overlay.Font, new SolidBrush(overlay.Color), overlay.Location);
                    }
                }
                graphics.Flush();
            }
        }

        /// <summary>
        /// Метод, добавляющий на Bitmap другой Bitmap
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="overlay">Объект с информацией о вставляемом изобрежении</param>
        public static void PasteBitmap(Bitmap initial, BitmapOverlay overlay)
        {
            using (Graphics graphics = Graphics.FromImage(initial))
            {
                if (overlay.Angle != 0)
                {
                    graphics.TranslateTransform(overlay.Location.X, overlay.Location.Y);
                    graphics.RotateTransform(overlay.Angle);
                    if (initial.Size.Equals(overlay.Size))
                    {
                        graphics.DrawImage(overlay.Bitmap, new Point(0, 0));
                    }
                    else
                    {
                        using (Bitmap resizedBitmap = Resize(overlay.Bitmap, overlay.Size))
                        {
                            graphics.DrawImage(resizedBitmap, new Point(0, 0));
                        }
                    }
                }
                else
                {
                    if (initial.Size.Equals(overlay.Size))
                    {
                        graphics.DrawImage(overlay.Bitmap, overlay.Location);
                    }
                    else
                    {
                        using (Bitmap resizedBitmap = Resize(overlay.Bitmap, overlay.Size))
                        {
                            graphics.DrawImage(resizedBitmap, overlay.Location);
                        }
                    }
                }
                graphics.Flush();
            }
            if (overlay.DisposeAfterUsage)
            {
                overlay.Bitmap.Dispose();
            }
        }

        /// <summary>
        /// Метод, последовательно накладывающий изображения на исходное изображение
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="overlays">Массив с информацией о вставляемых изображениях</param>
        public static void PasteBitmaps(Bitmap initial, params BitmapOverlay[] overlays)
        {
            using (Graphics graphics = Graphics.FromImage(initial))
            {
                foreach (BitmapOverlay overlay in overlays)
                {
                    if (overlay.Angle != 0)
                    {
                        graphics.TranslateTransform(overlay.Location.X, overlay.Location.Y);
                        graphics.RotateTransform(overlay.Angle);
                        if (initial.Size.Equals(overlay.Size))
                        {
                            graphics.DrawImage(overlay.Bitmap, new Point(0, 0));
                        }
                        else
                        {
                            using (Bitmap resizedBitmap = Resize(overlay.Bitmap, overlay.Size))
                            {
                                graphics.DrawImage(resizedBitmap, new Point(0, 0));
                            }
                        }
                        graphics.TranslateTransform(-overlay.Location.X, -overlay.Location.Y);
                        graphics.RotateTransform(-overlay.Angle);
                    }
                    else
                    {
                        if (initial.Size.Equals(overlay.Size))
                        {
                            graphics.DrawImage(overlay.Bitmap, overlay.Location);
                        }
                        else
                        {
                            using (Bitmap resizedBitmap = Resize(overlay.Bitmap, overlay.Size))
                            {
                                graphics.DrawImage(resizedBitmap, overlay.Location);
                            }
                        }
                    }
                    if (overlay.DisposeAfterUsage)
                    {
                        overlay.Bitmap.Dispose();
                    }
                }
                graphics.Flush();
            }
        }

        /// <summary>
        /// Метод, изменяющий разрещение картинки
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="size">Размеры нового изображения</param>
        public static Bitmap Resize(Bitmap initial, Size size)
        {
            Bitmap newMap = new Bitmap(size.Width, size.Height);
            newMap.SetResolution(initial.HorizontalResolution, initial.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(newMap))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(initial, new Rectangle(0, 0, size.Width, size.Height), 0, 0, initial.Width, initial.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return newMap;
        }

        /// <summary>
        /// Метод, задающий прозрачность изоражению
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="opacity">Значение прозрачности от 0.0 до 1.0 (1.0 - нет прозрасности. 0.0 - полная прозрачность)</param>
        /// <returns>Изображение указанной прозрасности</returns>
        public static Bitmap SetOpacity(Bitmap initial, float opacity)
        {
            Bitmap bitmapWithOpacity = new Bitmap(initial.Width, initial.Height);
            using (Graphics graphics = Graphics.FromImage(bitmapWithOpacity))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;
                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    graphics.DrawImage(initial, new Rectangle(0, 0, initial.Width, initial.Height), 0, 0, initial.Width, initial.Height, GraphicsUnit.Pixel, attributes);
                }
                graphics.Flush();
            }
            return bitmapWithOpacity;
        }

        /// <summary>
        /// Метод, вырезающий из изображения прямоугольник
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="section">Прямоугольник который хотите вырезать. Укажиет его Положение(x,y) и Размеры(height,width)</param>
        /// <returns>Вырезанный прямоугольник из изображения</returns>
        public static Bitmap CropImage(Bitmap initial, Rectangle section)
        {
            Bitmap newMap = new Bitmap(section.Width, section.Height);
            using (Graphics graphics = Graphics.FromImage(newMap))
            {
                graphics.DrawImage(initial, 0, 0, section, GraphicsUnit.Pixel);
                graphics.Flush();
            }
            return newMap;
        }

        /// <summary>
        /// Метод инвертирования цветов изображения
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <returns>Инвертированное изображение</returns>
        public static void InverseColor(Bitmap initial)
        {
            using (Graphics graphics = Graphics.FromImage(initial))
            {
                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(inverseColorMatrix);
                    graphics.DrawImage(initial, new Rectangle(0, 0, initial.Width, initial.Height), 0, 0, initial.Width, initial.Height, GraphicsUnit.Pixel, attributes);
                }
                graphics.Flush();
            }
        }

        /// <summary>
        /// Метод отзеркаливания изображения по X и/или Y
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="flipX">Отзеркалить по X</param>
        /// <param name="flipY">Отзеркалить по Y</param>
        public static void Mirror(Bitmap initial, bool flipX, bool flipY)
        {
            if (flipX && flipY)
            {
                initial.RotateFlip(RotateFlipType.RotateNoneFlipXY);
            }
            else if (flipX)
            {
                initial.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            else
            {
                initial.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }
        }

        /// <summary>
        /// Метод вырезания круга из изображения
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <returns>Круг, вырезанный из изображения</returns>
        public static Bitmap ClipCircle(Bitmap initial)
        {
            int side = Math.Min(initial.Width, initial.Height);
            int radius = side / 2;

            Bitmap newMap = new Bitmap(side, side);
            using (Graphics graphics = Graphics.FromImage(newMap))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.TranslateTransform(newMap.Width / 2, newMap.Height / 2);
                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddEllipse(0 - radius, 0 - radius, side, side);
                    using (Region region = new Region(gp))
                    {
                        graphics.SetClip(region, CombineMode.Replace);
                    }
                }
                graphics.DrawImage(initial, new Rectangle(-radius, -radius, side, side), new Rectangle(initial.Width / 2 - radius, initial.Height / 2 - radius, side, side), GraphicsUnit.Pixel);
                graphics.Flush();
            }
            return newMap;
        }

        /// <summary>
        /// Метод вырезания эллипса из изображения
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <returns>Эллипс, вырезанный из изображения</returns>
        public static Bitmap ClipEllipse(Bitmap initial)
        {
            Bitmap newMap = new Bitmap(initial.Width, initial.Height);
            using (Graphics graphics = Graphics.FromImage(newMap))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddEllipse(0, 0, initial.Width, initial.Height);
                    using (Region region = new Region(gp))
                    {
                        graphics.SetClip(region, CombineMode.Replace);
                    }
                }
                graphics.DrawImage(initial, new Rectangle(0, 0, initial.Width, initial.Height), new Rectangle(0, 0, initial.Width, initial.Height), GraphicsUnit.Pixel);
                graphics.Flush();
            }
            return newMap;
        }

        /// <summary>
        /// Метод вырезания треугольника из изображения
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <returns>Треугольник, вырезанный из изображения</returns>
        public static Bitmap ClipTriangle(Bitmap initial)
        {
            Bitmap newMap = new Bitmap(initial.Width, initial.Height);
            using (Graphics graphics = Graphics.FromImage(newMap))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddPolygon(new PointF[3]
                    {
                    new PointF((float)initial.Width / 2, 0),
                    new PointF(initial.Width, initial.Height),
                    new PointF(0, initial.Height)
                    });
                    using (Region region = new Region(gp))
                    {
                        graphics.SetClip(region, CombineMode.Replace);
                    }
                }
                graphics.DrawImage(initial, new Rectangle(0, 0, initial.Width, initial.Height), new Rectangle(0, 0, initial.Width, initial.Height), GraphicsUnit.Pixel);
                graphics.Flush();
            }
            return newMap;
        }

        /// <summary>
        /// Метод вырезания многоугольника из изображения
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="polygonPoints">Координаты углов многоугольника</param>
        /// <returns>Многоугольника, вырезанный из изображения</returns>
        public static Bitmap ClipPolygon(Bitmap initial, PointF[] polygonPoints)
        {
            Bitmap newMap = new Bitmap(initial.Width, initial.Height);
            using (Graphics graphics = Graphics.FromImage(newMap))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddPolygon(polygonPoints);
                    using (Region region = new Region(gp))
                    {
                        graphics.SetClip(region, CombineMode.Replace);
                    }
                }
                graphics.DrawImage(initial, new Rectangle(0, 0, initial.Width, initial.Height), new Rectangle(0, 0, initial.Width, initial.Height), GraphicsUnit.Pixel);
                graphics.Flush();
            }
            return newMap;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initial"></param>
        /// <param name="radius"></param>
        /// <param name="cornerColor"></param>
        /// <returns></returns>
        public static Bitmap ApplyRoundedCorners(Bitmap initial, int radius, Color cornerColor)
        {
            radius *= 2;
            Bitmap newMap = new Bitmap(initial.Width, initial.Height);
            using (Graphics graphics = Graphics.FromImage(newMap))
            {
                graphics.Clear(cornerColor);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddArc(0, 0, radius, radius, 180, 90);
                    gp.AddArc(0 + newMap.Width - radius, 0, radius, radius, 270, 90);
                    gp.AddArc(0 + newMap.Width - radius, 0 + newMap.Height - radius, radius, radius, 0, 90);
                    gp.AddArc(0, 0 + newMap.Height - radius, radius, radius, 90, 90);
                    using (Brush brush = new TextureBrush(initial))
                    {
                        graphics.FillPath(brush, gp);
                    }
                }
                graphics.Flush();
            }
            return newMap;
        }

        /// <summary>
        /// Метод добавления множества слоёв отступов разной настройки для изображения. Размер итогового изображения будет увеличен пропорционально размерам отступов
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="marginArray">Все отступы, которые должны быть применены</param>
        /// <returns>Изображение с отступами</returns>
        public static Bitmap ApplyMargins(Bitmap initial, params TotalIndent[] marginArray)
        {
            int updateWidth = initial.Width + marginArray.Sum(x => x.LeftIndent.Width) + marginArray.Sum(x => x.RightIndent.Width);
            int updateHeight = initial.Height + marginArray.Sum(x => x.TopIndent.Width) + marginArray.Sum(x => x.BottomIndent.Width);
            Point topLeftCornerLocation = new Point(0, 0);
            Bitmap newMap = new Bitmap(updateWidth, updateHeight);
            using (Graphics graphics = Graphics.FromImage(newMap))
            {
                foreach (TotalIndent margin in marginArray.Reverse())
                {
                    Point topRightCornerLocation = new Point(updateWidth - margin.RightIndent.Width, 0);
                    Point bottomLeftCornerLocation = new Point(0, updateHeight - margin.BottomIndent.Width);
                    Point bottomRightCornerLocation = new Point(updateWidth - margin.RightIndent.Width, updateHeight - margin.BottomIndent.Width);
                    graphics.FillRectangle(new SolidBrush(margin.TopIndent.Color), new Rectangle(topLeftCornerLocation, new Size(updateWidth, margin.TopIndent.Width)));
                    graphics.FillRectangle(new SolidBrush(margin.BottomIndent.Color), new Rectangle(bottomLeftCornerLocation, new Size(updateWidth, margin.BottomIndent.Width)));
                    graphics.FillRectangle(new SolidBrush(margin.LeftIndent.Color), new Rectangle(topLeftCornerLocation, new Size(margin.LeftIndent.Width, updateHeight)));
                    graphics.FillRectangle(new SolidBrush(margin.RightIndent.Color), new Rectangle(topRightCornerLocation, new Size(margin.RightIndent.Width, updateHeight)));

                    if (margin.TopLeftCorner != Color.Transparent)
                    {
                        graphics.FillRectangle(new SolidBrush(margin.TopLeftCorner), new Rectangle(topLeftCornerLocation, new Size(margin.LeftIndent.Width, margin.TopIndent.Width)));
                    }

                    if (margin.TopRightCorner != Color.Transparent)
                    {
                        graphics.FillRectangle(new SolidBrush(margin.TopRightCorner), new Rectangle(topRightCornerLocation, new Size(margin.RightIndent.Width, margin.TopIndent.Width)));
                    }

                    if (margin.BottomLeftCorner != Color.Transparent)
                    {
                        graphics.FillRectangle(new SolidBrush(margin.BottomLeftCorner), new Rectangle(bottomLeftCornerLocation, new Size(margin.LeftIndent.Width, margin.BottomIndent.Width)));
                    }

                    if (margin.BottomRightCorner != Color.Transparent)
                    {
                        graphics.FillRectangle(new SolidBrush(margin.BottomRightCorner), new Rectangle(bottomRightCornerLocation, new Size(margin.RightIndent.Width, margin.BottomIndent.Width)));
                    }
                    graphics.TranslateTransform(margin.LeftIndent.Width, margin.TopIndent.Width);
                    updateWidth -= margin.LeftIndent.Width + margin.RightIndent.Width;
                    updateHeight -= margin.TopIndent.Width + margin.BottomIndent.Width;
                }
                graphics.DrawImage(initial, new Rectangle(new Point(0, 0), initial.Size));
            }
            return newMap;
        }

        /// <summary>
        /// Метод добавления отступов разной настройки для изображения. Размер итогового изображения будет увеличен пропорционально размерам отступов
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="margins">Объект отступов</param>
        /// <returns>Изображение с отступами</returns>
        public static Bitmap ApplyMargin(Bitmap initial, TotalIndent margins)
        {
            int updateWidth = initial.Width + margins.LeftIndent.Width + margins.RightIndent.Width;
            int updateHeight = initial.Height + margins.TopIndent.Width + margins.BottomIndent.Width;
            Point topLeftCornerLocation = new Point(0, 0);
            Point topRightCornerLocation = new Point(margins.LeftIndent.Width + initial.Width, 0);
            Point bottomLeftCornerLocation = new Point(0, initial.Height + margins.TopIndent.Width);
            Point bottomRightCornerLocation = new Point(initial.Width + margins.LeftIndent.Width, initial.Height + margins.TopIndent.Width);
            Bitmap newMap = new Bitmap(updateWidth, updateHeight);
            using (Graphics graphics = Graphics.FromImage(newMap))
            {
                graphics.DrawImage(initial, new Rectangle(new Point(margins.LeftIndent.Width, margins.TopIndent.Width), initial.Size));
                graphics.FillRectangle(new SolidBrush(margins.TopIndent.Color), new Rectangle(topLeftCornerLocation, new Size(updateWidth, margins.TopIndent.Width)));
                graphics.FillRectangle(new SolidBrush(margins.BottomIndent.Color), new Rectangle(bottomLeftCornerLocation, new Size(updateWidth, margins.BottomIndent.Width)));
                graphics.FillRectangle(new SolidBrush(margins.LeftIndent.Color), new Rectangle(topLeftCornerLocation, new Size(margins.LeftIndent.Width, updateHeight)));
                graphics.FillRectangle(new SolidBrush(margins.RightIndent.Color), new Rectangle(topRightCornerLocation, new Size(margins.RightIndent.Width, updateHeight)));

                if (margins.TopLeftCorner != Color.Transparent)
                {
                    graphics.FillRectangle(new SolidBrush(margins.TopLeftCorner), new Rectangle(topLeftCornerLocation, new Size(margins.LeftIndent.Width, margins.TopIndent.Width)));
                }

                if (margins.TopRightCorner != Color.Transparent)
                {
                    graphics.FillRectangle(new SolidBrush(margins.TopRightCorner), new Rectangle(topRightCornerLocation, new Size(margins.RightIndent.Width, margins.TopIndent.Width)));
                }

                if (margins.BottomLeftCorner != Color.Transparent)
                {
                    graphics.FillRectangle(new SolidBrush(margins.BottomLeftCorner), new Rectangle(bottomLeftCornerLocation, new Size(margins.LeftIndent.Width, margins.BottomIndent.Width)));
                }

                if (margins.BottomRightCorner != Color.Transparent)
                {
                    graphics.FillRectangle(new SolidBrush(margins.BottomRightCorner), new Rectangle(bottomRightCornerLocation, new Size(margins.RightIndent.Width, margins.BottomIndent.Width)));
                }
            }
            return newMap;
        }

        /// <summary>
        /// Метод добавления отступов разной настройки для изображения. Размер итогового изображения не будет идентичен размеру исходного
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="paddings">Объект отступов</param>
        /// <returns>Изображение с отступами</returns>
        public static Bitmap ApplyPadding(Bitmap initial, TotalIndent paddings)
        {
            int updateWidth = initial.Width - paddings.LeftIndent.Width - paddings.RightIndent.Width;
            int updateHeight = initial.Height - paddings.TopIndent.Width - paddings.BottomIndent.Width;
            if (updateWidth <= 0 || updateHeight <= 0)
            {
                return null;
            }
            Bitmap newMap = null;
            using (Bitmap resizedBitmap = Resize(initial, new Size(updateWidth, updateHeight)))
            {
                newMap = ApplyMargin(resizedBitmap, paddings);
            }
            return newMap;
        }
    }
}
