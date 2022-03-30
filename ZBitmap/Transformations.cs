using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageWork
{
    public static class Transformations
    {
        /// <summary>
        /// Метод для перевода изображения в чёрно-белый формат
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <returns>Чёрно-белое изображение</returns>
        public static Bitmap ToBlackWhite(Bitmap initial)
        {
            Bitmap newMap = new Bitmap(initial.Width, initial.Height);
            using (Graphics graphics = Graphics.FromImage(newMap))
            {
                ColorMatrix colorMatrix = new ColorMatrix(
                   new float[][]
                   {
                     new float[] {.3f, .3f, .3f, 0, 0},
                     new float[] {.59f, .59f, .59f, 0, 0},
                     new float[] {.11f, .11f, .11f, 0, 0},
                     new float[] {0, 0, 0, 1, 0},
                     new float[] {0, 0, 0, 0, 1}
                   });
                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(colorMatrix);
                    graphics.DrawImage(initial, new Rectangle(0, 0, initial.Width, initial.Height), 0, 0, initial.Width, initial.Height, GraphicsUnit.Pixel, attributes);
                }
                graphics.Flush();
            }
            return newMap;
        }

        /// <summary>
        /// Метод, добавляющий на Bitmap текст в опереденном месте
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="text">Текст для вставки</param>
        /// <param name="font">Шрифт текста</param>
        /// <param name="position">Координаты текста на картинке</param>
        /// <returns>Изображение с текстом или null, если текст не помещается</returns>
        public static Bitmap PasteText(Bitmap initial, string text, Font font, Color color, PointF position)
        {
            Bitmap newMap = new Bitmap(initial);
            using (Graphics graphics = Graphics.FromImage(newMap))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawString(text, font, new SolidBrush(color), position);
                graphics.Flush();
            }
            return newMap;
        }

        /// <summary>
        /// Метод, добавляющий на Bitmap текст в опереденном месте с определённым углом
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="text">Текст для вставки</param>
        /// <param name="font">Шрифт текста</param>
        /// <param name="color">Цвет текста</param>
        /// <param name="position">Позиция текста</param>
        /// <param name="opacity">Уровень прозрасностьиот 0.0 до 1.0</param>
        /// <param name="angle">Угол поворота текста</param>
        /// <returns>Изображение с текстом или null, если текст не помещается</returns>
        public static Bitmap PasteText(Bitmap initial, string text, Font font, Color color, PointF position, float angle)
        {
            Bitmap newMap = new Bitmap(initial);
            using (Graphics graphics = Graphics.FromImage(newMap))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.TranslateTransform(position.X, position.Y);
                graphics.RotateTransform(angle);
                graphics.DrawString(text, font, new SolidBrush(color), 0, 0);
                graphics.Flush();
            }
            return newMap;
        }

        /// <summary>
        /// Метод, добавляющий на Bitmap другой Bitmap
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="additional">Изображение для вставки</param>
        /// <param name="position">Позиция картинки для вставки</param>
        public static Bitmap PasteBitmap(Bitmap initial, Bitmap additional, PointF position)
        {
            Bitmap newMap = new Bitmap(initial);
            using (Graphics graphics = Graphics.FromImage(newMap))
            {
                graphics.DrawImage(additional, position);
                graphics.Flush();
                return newMap;
            }
        }

        /// <summary>
        /// Метод, добавляющий на Bitmap другой Bitmap под углом
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="additional">Изображение для вставки</param>
        /// <param name="position">Позиция картинки для вставки</param>
        /// <param name="angle">Угол поворота изображения</param>
        public static Bitmap PasteBitmap(Bitmap initial, Bitmap additional, PointF position, float angle)
        {
            Bitmap newMap = new Bitmap(initial);
            using (Graphics graphics = Graphics.FromImage(newMap))
            {
                graphics.TranslateTransform(position.X, position.Y);
                graphics.RotateTransform(angle);
                graphics.DrawImage(additional, 0, 0);
                graphics.Flush();
                return newMap;
            }
        }

        /// <summary>
        /// Метод, изменяющий разрещение картинки
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="width">Ширина нового изображения</param>
        /// <param name="height">Высота нового изображения</param>
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

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(initial, new Rectangle(0, 0, size.Width, size.Height), 0, 0, initial.Width, initial.Height, GraphicsUnit.Pixel, wrapMode);
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
            Bitmap newMap = new Bitmap(initial.Width, initial.Height);
            using (Graphics graphics = Graphics.FromImage(newMap))
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
            return newMap;
        }

        /// <summary>
        /// Метод, вырезающий из изображения прямоугольник
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="section">Прямоугольник который хотите вырезать. Укажиет его Положение(x,y) и Размеры(height,width)</param>
        /// <returns>Вырезанный прямоугольник из изображения</returns>
        public static Bitmap CropImage(Bitmap initial, Rectangle section)
        {
            var newMap = new Bitmap(section.Width, section.Height);
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
        public static Bitmap InverseColor(Bitmap initial)
        {
            Bitmap newMap = new Bitmap(initial.Width, initial.Height);
            using (Graphics graphics = Graphics.FromImage(newMap))
            {
                ColorMatrix colorMatrix = new ColorMatrix(
                   new float[][]
                   {
                    new float[] {-1, 0, 0, 0, 0},
                    new float[] {0, -1, 0, 0, 0},
                    new float[] {0, 0, -1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {1, 1, 1, 0, 1}
                   });
                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(colorMatrix);
                    graphics.DrawImage(initial, new Rectangle(0, 0, initial.Width, initial.Height), 0, 0, initial.Width, initial.Height, GraphicsUnit.Pixel, attributes);
                }
                graphics.Flush();
            }
            return newMap;
        }

        /// <summary>
        /// Метод отзеркаливания изображения по X и/или Y
        /// </summary>
        /// <param name="initial">Исходное изображение</param>
        /// <param name="flipX">Отзеркалить по X</param>
        /// <param name="flipY">Отзеркалить по Y</param>
        /// <returns>Отзеркаленное изображение</returns>
        public static Bitmap Mirror(Bitmap initial, bool flipX, bool flipY)
        {
            Bitmap newMap = new Bitmap(initial);
            if (flipX && flipY)
            {
                newMap.RotateFlip(RotateFlipType.RotateNoneFlipXY);
            }
            else if (flipX)
            {
                newMap.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            else
            {
                newMap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }
            return newMap;
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
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(0 - radius, 0 - radius, side, side);
                graphics.SetClip(new Region(gp), CombineMode.Replace);
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
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(0, 0, initial.Width, initial.Height);
                graphics.SetClip(new Region(gp), CombineMode.Replace);
                graphics.DrawImage(initial, new Rectangle(0, 0, initial.Width, initial.Height),new Rectangle(0, 0, initial.Width, initial.Height),GraphicsUnit.Pixel);
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
                GraphicsPath gp = new GraphicsPath();
                gp.AddPolygon(new PointF[3]
                {
                    new PointF((float)initial.Width / 2, 0),
                    new PointF(initial.Width, initial.Height),
                    new PointF(0, initial.Height)
                });
                graphics.SetClip(new Region(gp), CombineMode.Replace);
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
                GraphicsPath gp = new GraphicsPath();
                gp.AddPolygon(polygonPoints);
                graphics.SetClip(new Region(gp), CombineMode.Replace);
                graphics.DrawImage(initial, new Rectangle(0, 0, initial.Width, initial.Height), new Rectangle(0, 0, initial.Width, initial.Height), GraphicsUnit.Pixel);
                graphics.Flush();
            }
            return newMap;
        }
    }
}
