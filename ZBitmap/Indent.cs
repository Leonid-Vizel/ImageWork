using System.Drawing;

namespace ZBitmap
{
    /// <summary>
    /// Отступ с одной из сторон
    /// </summary>
    public class Indent
    {
        /// <summary>
        /// Цвет заполнения отступа
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// Значение отступа
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Конструктор класса Indent
        /// </summary>
        /// <param name="color">Цвет отступа</param>
        /// <param name="width">Ширина отступа</param>
        public Indent(Color color, int width = 0)
        {
            Color = color;
            Width = width;
        }
    }
}
