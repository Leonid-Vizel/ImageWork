using System;
using System.Drawing;
using System.Windows.Forms;
using ZBitmap;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
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
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(100, 100), Font, 90F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(120, 100), Font, 90F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(140, 100), Font, 90F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(160, 100), Font, 90F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(180, 100), Font, 90F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(200, 100), Font, 90F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(220, 100), Font, 90F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(240, 100), Font, 90F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(260, 100), Font, 90F),
                new TextOverlay("COCK AND BALLS", Color.Red, new Point(280, 100), Font, 90F)
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
    }
}
