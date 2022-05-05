using System;
using System.Drawing;

namespace ZBitmap
{
    /// <summary>
    /// Класс для хранения информации об изображении для вставки
    /// </summary>
    public class BitmapOverlay : IDisposable
    {
        /// <summary>
        /// Изображение
        /// </summary>
        public Bitmap Bitmap { get; set; }
        /// <summary>
        /// Позиция изображения
        /// </summary>
        public Point Location { get; set; }
        /// <summary>
        /// Размер изображения
        /// </summary>
        public Size Size { get; set; }
        /// <summary>
        /// Использовать ли метод Dispose() для изображения после использования
        /// </summary>
        public bool DisposeAfterUsage { get; set; }
        /// <summary>
        /// Угол поворота изображения
        /// </summary>
        public float Angle
        {
            get => angle;
            set => angle = value % 360;
        }

        private float angle;

        /// <summary>
        /// Конструктор без изказания изменения размера
        /// </summary>
        /// <param name="bitmap">Изображение</param>
        /// <param name="location">Позиция изображения</param>
        /// <param name="angle">Угол поворота изображения</param>
        /// <param name="disposeAfterUsage">Использовать ли метод Dispose() для изображения после использования</param>
        public BitmapOverlay(Bitmap bitmap, Point location, float angle = 0, bool disposeAfterUsage = false)
        {
            Bitmap = bitmap;
            Location = location;
            Size = bitmap.Size;
            Angle = angle;
            DisposeAfterUsage = disposeAfterUsage;
        }

        /// <summary>
        /// Конструктор с указанием нового размера изображения
        /// </summary>
        /// <param name="bitmap">Изображение</param>
        /// <param name="location">Позиция изображения</param>
        /// <param name="size">Размер изображения</param>
        /// <param name="angle">Угол поворота изображения</param>
        /// <param name="disposeAfterUsage">Использовать ли метод Dispose() для изображения после использования</param>
        public BitmapOverlay(Bitmap bitmap, Point location, Size size, float angle = 0, bool disposeAfterUsage = false)
        {
            Bitmap = bitmap;
            Location = location;
            Size = size;
            Angle = angle;
            DisposeAfterUsage = disposeAfterUsage;
        }

        /// <summary>
        /// Вызывает Dispose() у Bitmap
        /// </summary>
        public void Dispose() => Bitmap.Dispose();
    }
}
