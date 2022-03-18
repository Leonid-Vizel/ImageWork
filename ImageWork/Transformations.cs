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
            int grayScale;
            Color initialColor;
            for (int i = 0; i < initial.Width; i++)
            {
                for (int j = 0; j < initial.Height; j++)
                {
                    initialColor = initial.GetPixel(i, j);
                    grayScale = (initialColor.R + initialColor.G + initialColor.B) / 3;
                    newMap.SetPixel(i, j, Color.FromArgb(grayScale, grayScale, grayScale));
                }
            }
            return newMap;
        }

        private static bool CheckStrigFitness(Bitmap initial, string text, Font font, PointF position, Graphics graphics)
        {
            if (position.X > initial.Width)
            {
                return false;
            }

            if (position.Y > initial.Height)
            {
                return false;
            }

            SizeF size = graphics.MeasureString(text, font);

            if (size.Width + position.X > initial.Width)
            {
                return false;
            }

            if (size.Height + position.Y > initial.Height)
            {
                return false;
            }

            return true;
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
                if (!CheckStrigFitness(initial, text, font, position, graphics))
                {
                    return null;
                }
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
                graphics.TranslateTransform(position.X,position.Y);
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
        public static Bitmap Resize(Bitmap initial, int width, int height)
        {
            Bitmap newMap = new Bitmap(width, height);
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
                    graphics.DrawImage(initial, new Rectangle(0, 0, width, height), 0, 0, initial.Width, initial.Height, GraphicsUnit.Pixel, wrapMode);
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
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                graphics.DrawImage(initial, new Rectangle(0, 0, initial.Width, initial.Height), 0, 0, initial.Width, initial.Height, GraphicsUnit.Pixel, attributes);
                graphics.Flush();
            }
            return newMap;
        }
    }
}
