using System.Drawing;

namespace ZBitmap
{
    public class TotalIndent
    {
        #region Indents
        public Indent TopIndent { get; set; }
        public Indent RightIndent { get; set; }
        public Indent LeftIndent { get; set; }
        public Indent BottomIndent { get; set; }
        #endregion

        #region Intersections
        public Color TopLeftCorner { get; set; }
        public Color TopRightCorner { get; set; }
        public Color BottomLeftCorner { get; set; }
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

        public IndentBuilder WithIndent(IndentSides side, Indent indent)
        {
            int index = (int)side;
            if (index >= 0 && index <= 4)
            {
                Indents[index] = indent;
            }
            return this;
        }

        public IndentBuilder WithCornerColor(Corners corner, Color color)
        {
            int index = (int)corner;
            if (index >= 0 && index <= 4)
            {
                CornerColors[index] = color;
            }
            return this;
        }

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

    public enum IndentSides
    {
        Top,
        Right,
        Left,
        Bottom
    }

    public enum Corners
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
}
