using System.Drawing;

namespace ZBitmap
{
    /// <summary>
    /// Класс с информацией о всех отступах
    /// </summary>
    public class TotalIndent
    {
        #region Indents
        /// <summary>
        /// Верхний отступ
        /// </summary>
        public Indent TopIndent { get; internal set; }
        /// <summary>
        /// Правый отступ
        /// </summary>
        public Indent RightIndent { get; internal set; }
        /// <summary>
        /// Левый отступ
        /// </summary>
        public Indent LeftIndent { get; internal set; }
        /// <summary>
        /// Нижний отступ
        /// </summary>
        public Indent BottomIndent { get; internal set; }
        #endregion

        #region Intersections
        /// <summary>
        /// Цвет верхнего левого пересечения отступов
        /// </summary>
        public Color TopLeftCorner { get; set; }
        /// <summary>
        /// Цвет верхнего правого пересечения отступов
        /// </summary>
        public Color TopRightCorner { get; set; }
        /// <summary>
        /// Цвет нижнего левого пересечения отступов
        /// </summary>
        public Color BottomLeftCorner { get; set; }
        /// <summary>
        /// Цвет нижнего правого пересечения отступов
        /// </summary>
        public Color BottomRightCorner { get; set; }
        #endregion

        internal TotalIndent() {/*Nothing*/}
    }

    public class IndentBuilder
    {
        private Indent[] Indents { get; set; }
        private Color[] CornerColors { get; set; }

        public IndentBuilder()
        {
            Indents = new Indent[4];
            CornerColors = new Color[4] { Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent };
        }

        /// <summary>
        /// Задаёт отступ для определённой стороны
        /// </summary>
        /// <param name="side">Сторона отступа</param>
        /// <param name="indent">Отступ</param>
        /// <returns>Текущий объект TotalIndent</returns>
        public IndentBuilder WithIndent(IndentSides side, Indent indent)
        {
            int index = (int)side;
            if (index >= 0 && index <= 4)
            {
                Indents[index] = indent;
            }
            return this;
        }

        /// <summary>
        /// Задаёт одинаковый отступ со всех сторон
        /// </summary>
        /// <param name="indent">Отступ</param>
        /// <returns>Текущий объект TotalIndent</returns>
        public IndentBuilder WithAllIndent(Indent indent)
        {
            for (int i = 0; i < Indents.Length; i++)
            {
                Indents[i] = indent;
            }
            return this;
        }

        /// <summary>
        /// Задаёт одинаковый отступ со всех сторон
        /// </summary>
        /// <param name="color">Цвет отступа</param>
        /// <param name="width">Ширина отступа</param>
        /// <returns>Текущий объект TotalIndent</returns>
        public IndentBuilder WithAllIndent(Color color, int width = 0)
        {
            var indent = new Indent(color, width);
            for (int i = 0; i < Indents.Length; i++)
            {
                Indents[i] = indent;
            }
            return this;
        }

        /// <summary>
        /// Задаёт одинаковый цвет всех пересенчений отступов
        /// </summary>
        /// <param name="color">Цвет пересечения</param>
        /// <returns>Текущий объект TotalIndent</returns>
        public IndentBuilder WithAllCornersColor(Color color)
        {
            for (int i = 0; i < CornerColors.Length; i++)
            {
                CornerColors[i] = color;
            }
            return this;
        }

        /// <summary>
        /// Задаёт цвет одного из пересечений отступов (Углов)
        /// </summary>
        /// <param name="color">Цвет пересечения</param>
        /// <returns>Текущий объект TotalIndent</returns>
        public IndentBuilder WithCornerColor(Corners corner, Color color)
        {
            int index = (int)corner;
            if (index >= 0 && index <= 4)
            {
                CornerColors[index] = color;
            }
            return this;
        }

        /// <summary>
        /// Собирает ранее настроенные параметры в объект типа TotalIndent
        /// </summary>
        /// <returns>Объект типа TotalIndent</returns>
        public TotalIndent Build()
            => new TotalIndent()
            { 
                TopIndent = Indents[0] ?? new Indent(Color.Black),
                RightIndent = Indents[1] ?? new Indent(Color.Black),
                LeftIndent = Indents[2] ?? new Indent(Color.Black),
                BottomIndent = Indents[3] ?? new Indent(Color.Black),
                TopLeftCorner = CornerColors[0],
                TopRightCorner = CornerColors[1],
                BottomLeftCorner = CornerColors[2],
                BottomRightCorner = CornerColors[3]
            };
    }

    /// <summary>
    /// Стороны отступов
    /// </summary>
    public enum IndentSides
    {
        Top,
        Right,
        Left,
        Bottom
    }

    /// <summary>
    /// Углы пересечений
    /// </summary>
    public enum Corners
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
}
