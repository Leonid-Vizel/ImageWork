using System;
using System.Drawing;
using System.Windows.Forms;
using Zbitmap;

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
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(dialog.FileName);
                    Activate();
                }
                catch
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void textBtn_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Transformations.PasteText(pictureBox1.Image as Bitmap, "COCK AND BALLS", this.Font, Color.Red, new PointF(100, 100));
        }

        private void bitmapBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox2.Image = Transformations.PasteBitmap(pictureBox1.Image as Bitmap, Image.FromFile(dialog.FileName) as Bitmap, new PointF(100, 100));
                }
                catch
                { }
            }
        }

        private void rotatedTextBtn_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Transformations.PasteText(pictureBox1.Image as Bitmap, "COCK AND BALLS", this.Font, Color.Red, new PointF(50, 50), 90F);
        }

        private void rotatedBitmapBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox2.Image = Transformations.PasteBitmap(pictureBox1.Image as Bitmap, Image.FromFile(dialog.FileName) as Bitmap, new PointF(100, 100), 90F);
                }
                catch
                { }
            }
        }

        private void opacityBtn_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Transformations.SetOpacity(pictureBox1.Image as Bitmap, 0.5F);
        }

        private void sizeChangeBtn_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Transformations.Resize(pictureBox1.Image as Bitmap, new Size(1000, 1000));
        }

        private void grayShadeBtn_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Transformations.ToBlackWhite(pictureBox1.Image as Bitmap);
        }

        private void cropBitmap_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Transformations.CropImage(pictureBox1.Image as Bitmap, new Rectangle(50, 50, 100, 100));
        }

        private void inverseColorBtn_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Transformations.InverseColor(pictureBox1.Image as Bitmap);
        }

        private void mirrorBtn_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Transformations.Mirror(pictureBox1.Image as Bitmap,true,false);
        }

        private void clipCircleBtn_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Transformations.ClipCircle(pictureBox1.Image as Bitmap);
        }

        private void clipEllipseBtn_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Transformations.ClipEllipse(pictureBox1.Image as Bitmap);
        }

        private void clipTriangleBtn_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Transformations.ClipTriangle(pictureBox1.Image as Bitmap);
        }
    }
}
