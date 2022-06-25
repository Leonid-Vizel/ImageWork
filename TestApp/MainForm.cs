using System;
using System.Drawing;
using System.Windows.Forms;
using ZBitmap;

namespace TestApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox1.Image = Image.FromFile(dialog.FileName);
                    }
                    catch
                    {
                        Close();
                    }
                    Activate();
                }
                else
                {
                    Close();
                }
            }
        }

        private void textBtn_Click(object sender, EventArgs e)
        {
            Bitmap fromBox = new Bitmap(pictureBox1.Image as Bitmap);
            Transformations.PasteTexts(fromBox, new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 100), Font));
            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = fromBox;
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void multiTextBtn_Click(object sender, EventArgs e)
        {
            Bitmap fromBox = new Bitmap(pictureBox1.Image as Bitmap);
            Transformations.PasteTexts(fromBox,
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 100), Font),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 120), Font),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 140), Font),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 160), Font),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 180), Font),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 200), Font),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 220), Font),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 240), Font),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 260), Font),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 280), Font)
                );
            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = fromBox;
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void bitmapBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                Bitmap fromFile = null;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        fromFile = Image.FromFile(dialog.FileName) as Bitmap;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки: {ex}");
                        return;
                    }
                    Bitmap fromBox = new Bitmap(pictureBox1.Image as Bitmap);
                    Transformations.PasteBitmap(fromBox, new BitmapOverlay(fromFile, new Point(100, 100), disposeAfterUsage: true)); //disposeAfterUsage: true для того, чтобы очистилось после прорисовки
                    Image imageToDispose = pictureBox2.Image;
                    pictureBox2.Image = fromBox;
                    imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
                }
            }
        }

        private void rotatedTextBtn_Click(object sender, EventArgs e)
        {
            Bitmap fromBox = new Bitmap(pictureBox1.Image as Bitmap);
            Transformations.PasteText(fromBox, new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 100), Font, 90F));
            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = fromBox;
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void rotatedBitmapBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                Bitmap fromFile = null;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        fromFile = Image.FromFile(dialog.FileName) as Bitmap;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки: {ex}");
                        return;
                    }
                    Bitmap fromBox = new Bitmap(pictureBox1.Image as Bitmap);
                    Transformations.PasteBitmap(fromBox, new BitmapOverlay(fromFile, new Point(100, 100), 90F, true));
                    Image imageToDispose = pictureBox2.Image;
                    pictureBox2.Image = fromBox;
                    imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
                }
            }
        }

        private void opacityBtn_Click(object sender, EventArgs e)
        {
            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = Transformations.SetOpacity(pictureBox1.Image as Bitmap, 0.5F);
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void sizeChangeBtn_Click(object sender, EventArgs e)
        {
            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = Transformations.Resize(pictureBox1.Image as Bitmap, new Size(1000, 1000));
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void grayShadeBtn_Click(object sender, EventArgs e)
        {
            Bitmap fromBox = new Bitmap(pictureBox1.Image as Bitmap);
            Transformations.ToBlackWhite(fromBox);
            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = fromBox;
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void cropBitmap_Click(object sender, EventArgs e)
        {
            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = Transformations.CropImage(pictureBox1.Image as Bitmap, new Rectangle(50, 50, 100, 100));
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void inverseColorBtn_Click(object sender, EventArgs e)
        {
            Bitmap fromBox = new Bitmap(pictureBox1.Image as Bitmap);
            Transformations.InverseColor(fromBox);
            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = fromBox;
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void mirrorBtn_Click(object sender, EventArgs e)
        {
            Bitmap fromBox = new Bitmap(pictureBox1.Image as Bitmap);
            Transformations.Mirror(fromBox, true, false);
            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = fromBox;
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void clipCircleBtn_Click(object sender, EventArgs e)
        {
            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = Transformations.ClipCircle(pictureBox1.Image as Bitmap);
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void clipEllipseBtn_Click(object sender, EventArgs e)
        {
            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = Transformations.ClipEllipse(pictureBox1.Image as Bitmap);
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void clipTriangleBtn_Click(object sender, EventArgs e)
        {
            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = Transformations.ClipTriangle(pictureBox1.Image as Bitmap);
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void multiRotatedTextBtn_Click(object sender, EventArgs e)
        {
            Bitmap fromBox = new Bitmap(pictureBox1.Image as Bitmap);
            Transformations.PasteTexts(fromBox,
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 100), Font, 10F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 100), Font, 20F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 100), Font, 30F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 100), Font, 40F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 100), Font, 50F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 100), Font, 60F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 100), Font, 70F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 100), Font, 80F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 100), Font, 90F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 100), Font, 100F)
                );
            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = fromBox;
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void multiRotatedBitmapBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap fromFile = null;
                    try
                    {
                        fromFile = Image.FromFile(dialog.FileName) as Bitmap;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки: {ex}");
                        return;
                    }
                    Bitmap fromBox = new Bitmap(pictureBox1.Image as Bitmap);
                    Transformations.PasteBitmaps(fromBox,
                            new BitmapOverlay(fromFile, new Point(200, 200), 90F, false),
                            new BitmapOverlay(fromFile, new Point(200, 200), -90F, true));
                    Image imageToDispose = pictureBox2.Image;
                    pictureBox2.Image = fromBox;
                    imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
                }
            }
        }

        private void multiBitmapBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap fromFile = null;
                    try
                    {
                        fromFile = Image.FromFile(dialog.FileName) as Bitmap;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки: {ex}");
                        return;
                    }
                    Bitmap fromBox = new Bitmap(pictureBox1.Image as Bitmap);
                    Transformations.PasteBitmaps(fromBox,
                            new BitmapOverlay(fromFile, new Point(100, 100), disposeAfterUsage: false), //Чтобы сразу не стёрлось из памяти, так как использую один и тот же объект
                            new BitmapOverlay(fromFile, new Point(200, 200), disposeAfterUsage: true)); //Уничтожаю объект под конец
                    Image imageToDispose = pictureBox2.Image;
                    pictureBox2.Image = fromBox;
                    imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
                }
            }
        }

        private void marginBtn_Click(object sender, EventArgs e)
        {
            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = Transformations.ApplyMargin(pictureBox1.Image as Bitmap, new IndentBuilder().WithAllIndent(Color.Black, 100).Build());
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void marginColorBtn_Click(object sender, EventArgs e)
        {
            IndentBuilder builder = new IndentBuilder();
            builder.WithIndent(IndentSides.Top, new Indent(Color.Red, 100));
            builder.WithIndent(IndentSides.Bottom, new Indent(Color.Red, 100));
            builder.WithIndent(IndentSides.Left, new Indent(Color.Blue, 100));
            builder.WithIndent(IndentSides.Right, new Indent(Color.Blue, 100));
            builder.WithCornerColor(Corners.TopLeft, Color.Green);
            builder.WithCornerColor(Corners.TopRight, Color.Green);
            builder.WithCornerColor(Corners.BottomLeft, Color.Green);
            builder.WithCornerColor(Corners.BottomRight, Color.Green);

            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = Transformations.ApplyMargin(pictureBox1.Image as Bitmap, builder.Build());
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void paddingBtn_Click(object sender, EventArgs e)
        {
            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = Transformations.ApplyPadding(pictureBox1.Image as Bitmap, new IndentBuilder().WithAllIndent(Color.Black, 100).Build());
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void paddingColorBtn_Click(object sender, EventArgs e)
        {
            IndentBuilder builder = new IndentBuilder();
            builder.WithIndent(IndentSides.Top, new Indent(Color.Red, 100));
            builder.WithIndent(IndentSides.Bottom, new Indent(Color.Red, 100));
            builder.WithIndent(IndentSides.Left, new Indent(Color.Blue, 100));
            builder.WithIndent(IndentSides.Right, new Indent(Color.Blue, 100));
            builder.WithCornerColor(Corners.TopLeft, Color.Green);
            builder.WithCornerColor(Corners.TopRight, Color.Green);
            builder.WithCornerColor(Corners.BottomLeft, Color.Green);
            builder.WithCornerColor(Corners.BottomRight, Color.Green);

            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = Transformations.ApplyPadding(pictureBox1.Image as Bitmap, builder.Build());
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void demotivateBtn_Click(object sender, EventArgs e)
        {
            TotalIndent lowerMargin = new IndentBuilder().WithIndent(IndentSides.Bottom, new Indent(Color.Black, 100)).Build();
            TotalIndent blackMargin = new IndentBuilder().WithAllIndent(Color.Black, 5).Build();
            TotalIndent whiteMargin = new IndentBuilder().WithAllIndent(Color.White, 3).Build();
            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = Transformations.ApplyMargins(pictureBox1.Image as Bitmap, blackMargin, whiteMargin, blackMargin, lowerMargin);
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void roundedBtn_Click(object sender, EventArgs e)
        {
            Image imageToDispose = pictureBox2.Image;
            pictureBox2.Image = Transformations.ApplyRoundedCorners(pictureBox1.Image as Bitmap, 100, Color.Transparent);
            imageToDispose?.Dispose(); //Это можно не делать, так как оставленное в памяти изображение скорее всего будет очищено сборщиком мусора
        }

        private void translateBtn_Click(object sender, EventArgs e)
        {
            if (translateBtn.Text.Equals("Translate to English"))
            {
                translateBtn.Text = "Translate back to Russian";
                Text = "Library test";
                textBtn.Text = "Text overlay";
                bitmapBtn.Text = "Bitmap overlay";
                rotatedTextBtn.Text = "Rotated text overlay";
                rotatedBitmapBtn.Text = "Rotated bitmap overlay";
                opacityBtn.Text = "Set opacity to 50%";
                sizeChangeBtn.Text = "Resize to 1000 x1000";
                grayShadeBtn.Text = "To gray shade";
                cropBitmap.Text = "Clip square 100x100";
                inverseColorBtn.Text = "Invert colors";
                mirrorBtn.Text = "Mirror (X)";
                clipCircleBtn.Text = "Clip circle";
                clipEllipseBtn.Text = "Clip ellipse";
                clipTriangleBtn.Text = "Clip triangle";
                multiTextBtn.Text = "Overlay of 10 texts";
                multiRotatedTextBtn.Text = "Overlay of 10 rotated texts";
                multiRotatedBitmapBtn.Text = "Overlay of 2 rotated bitmaps";
                multiBitmapBtn.Text = "Overlay of 2 bitmaps";
                marginBtn.Text = "Margin 100 from each side";
                marginColorBtn.Text = "Margin with corners";
                paddingBtn.Text = "Padding 100 from each side";
                paddingColorBtn.Text = "Padding with corners";
                demotivateBtn.Text = "Demotivator";
                roundedBtn.Text = "Rounded corners";
            }
            else
            {
                translateBtn.Text = "Translate to English";
                Text = "Тест либы";
                textBtn.Text = "Наложение текста";
                bitmapBtn.Text = "Наложение картинки";
                rotatedTextBtn.Text = "Наложение повёрнутого текста";
                rotatedBitmapBtn.Text = "Наложение повёрнутого текста";
                opacityBtn.Text = "Задать прозрачность 50%";
                sizeChangeBtn.Text = "Задать размер 1000 x1000";
                grayShadeBtn.Text = "В оттенок серого";
                cropBitmap.Text = "Вырезать квадрат 100x100";
                inverseColorBtn.Text = "Инверсия цвета";
                mirrorBtn.Text = "Отзеркалить (X)";
                clipCircleBtn.Text = "Вырезать круг";
                clipEllipseBtn.Text = "Вырезать эллипс";
                clipTriangleBtn.Text = "Вырезать треугольник";
                multiTextBtn.Text = "Наложение десяти текстов";
                multiRotatedTextBtn.Text = "Наложение 10 повёрнутых текстов";
                multiRotatedBitmapBtn.Text = "Наложение 2 повёрнутых картинок";
                multiBitmapBtn.Text = "Наложение двух картинок";
                marginBtn.Text = "[MARGIN]\r\nОтступ 100 с каждой стороны";
                marginColorBtn.Text = "[MARGIN]\r\nОтступ с уголками";
                paddingBtn.Text = "[PADDING]\r\nОтступ 100 с каждой стороны";
                paddingColorBtn.Text = "[PADDING]\r\nОтступ с уголками";
                demotivateBtn.Text = "Демотиватор";
                roundedBtn.Text = "Закруглённые углы";
            }
        }
    }
}
