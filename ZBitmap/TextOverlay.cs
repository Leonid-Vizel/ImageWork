using System.Drawing;

namespace ZBitmap
{
    /// <summary>
    /// Класс для хранения информации об тексте для вставки
    /// </summary>
    public class TextOverlay
    {
        /// <summary>
        /// Текст
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Цвет текста
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// Позиция текста
        /// </summary>
        public Point Location { get; set; }
        /// <summary>
        /// Шрифт текста
        /// </summary>
        public Font Font { get; set; }
        /// <summary>
        /// Угол поворота текста
        /// </summary>
        public float Angle
        {
            get => angle;
            set => angle = value % 360;
        }

        private float angle;

        /// <summary>
        /// Основной конструктор класса TextOverlay
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="color">Цвет текста</param>
        /// <param name="location">Позиция текста</param>
        /// <param name="font">Шрифт текста</param>
        /// <param name="angle">Угол поворота текста</param>
        public TextOverlay(string text, Color color, Point location, Font font, float angle = 0)
        {
            Text = text;
            Color = color;
            Location = location;
            Font = font;
            Angle = angle;
        }
    }
}
