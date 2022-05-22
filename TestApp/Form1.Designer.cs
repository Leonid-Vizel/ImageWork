
namespace TestApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBtn = new System.Windows.Forms.Button();
            this.bitmapBtn = new System.Windows.Forms.Button();
            this.rotatedTextBtn = new System.Windows.Forms.Button();
            this.rotatedBitmapBtn = new System.Windows.Forms.Button();
            this.opacityBtn = new System.Windows.Forms.Button();
            this.sizeChangeBtn = new System.Windows.Forms.Button();
            this.grayShadeBtn = new System.Windows.Forms.Button();
            this.cropBitmap = new System.Windows.Forms.Button();
            this.inverseColorBtn = new System.Windows.Forms.Button();
            this.mirrorBtn = new System.Windows.Forms.Button();
            this.clipCircleBtn = new System.Windows.Forms.Button();
            this.clipEllipseBtn = new System.Windows.Forms.Button();
            this.clipTriangleBtn = new System.Windows.Forms.Button();
            this.multiTextBtn = new System.Windows.Forms.Button();
            this.multiRotatedTextBtn = new System.Windows.Forms.Button();
            this.multiRotatedBitmapBtn = new System.Windows.Forms.Button();
            this.multiBitmapBtn = new System.Windows.Forms.Button();
            this.marginBtn = new System.Windows.Forms.Button();
            this.marginColorBtn = new System.Windows.Forms.Button();
            this.paddingBtn = new System.Windows.Forms.Button();
            this.paddingColorBtn = new System.Windows.Forms.Button();
            this.demotivateBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(495, 668);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(845, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(495, 668);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // textBtn
            // 
            this.textBtn.Location = new System.Drawing.Point(512, 12);
            this.textBtn.Name = "textBtn";
            this.textBtn.Size = new System.Drawing.Size(105, 58);
            this.textBtn.TabIndex = 2;
            this.textBtn.Text = "Наложение текста";
            this.textBtn.UseVisualStyleBackColor = true;
            this.textBtn.Click += new System.EventHandler(this.textBtn_Click);
            // 
            // bitmapBtn
            // 
            this.bitmapBtn.Location = new System.Drawing.Point(512, 140);
            this.bitmapBtn.Name = "bitmapBtn";
            this.bitmapBtn.Size = new System.Drawing.Size(105, 58);
            this.bitmapBtn.TabIndex = 3;
            this.bitmapBtn.Text = "Наложение картинки";
            this.bitmapBtn.UseVisualStyleBackColor = true;
            this.bitmapBtn.Click += new System.EventHandler(this.bitmapBtn_Click);
            // 
            // rotatedTextBtn
            // 
            this.rotatedTextBtn.Location = new System.Drawing.Point(512, 268);
            this.rotatedTextBtn.Name = "rotatedTextBtn";
            this.rotatedTextBtn.Size = new System.Drawing.Size(105, 58);
            this.rotatedTextBtn.TabIndex = 4;
            this.rotatedTextBtn.Text = "Наложение повёрнутого текста";
            this.rotatedTextBtn.UseVisualStyleBackColor = true;
            this.rotatedTextBtn.Click += new System.EventHandler(this.rotatedTextBtn_Click);
            // 
            // rotatedBitmapBtn
            // 
            this.rotatedBitmapBtn.Location = new System.Drawing.Point(512, 396);
            this.rotatedBitmapBtn.Name = "rotatedBitmapBtn";
            this.rotatedBitmapBtn.Size = new System.Drawing.Size(105, 58);
            this.rotatedBitmapBtn.TabIndex = 5;
            this.rotatedBitmapBtn.Text = "Наложение повёрнутой картинки";
            this.rotatedBitmapBtn.UseVisualStyleBackColor = true;
            this.rotatedBitmapBtn.Click += new System.EventHandler(this.rotatedBitmapBtn_Click);
            // 
            // opacityBtn
            // 
            this.opacityBtn.Location = new System.Drawing.Point(512, 524);
            this.opacityBtn.Name = "opacityBtn";
            this.opacityBtn.Size = new System.Drawing.Size(105, 58);
            this.opacityBtn.TabIndex = 6;
            this.opacityBtn.Text = "Задать прозрачность 50%";
            this.opacityBtn.UseVisualStyleBackColor = true;
            this.opacityBtn.Click += new System.EventHandler(this.opacityBtn_Click);
            // 
            // sizeChangeBtn
            // 
            this.sizeChangeBtn.Location = new System.Drawing.Point(512, 588);
            this.sizeChangeBtn.Name = "sizeChangeBtn";
            this.sizeChangeBtn.Size = new System.Drawing.Size(105, 58);
            this.sizeChangeBtn.TabIndex = 7;
            this.sizeChangeBtn.Text = "Задать размер 1000 x1000";
            this.sizeChangeBtn.UseVisualStyleBackColor = true;
            this.sizeChangeBtn.Click += new System.EventHandler(this.sizeChangeBtn_Click);
            // 
            // grayShadeBtn
            // 
            this.grayShadeBtn.Location = new System.Drawing.Point(623, 12);
            this.grayShadeBtn.Name = "grayShadeBtn";
            this.grayShadeBtn.Size = new System.Drawing.Size(105, 58);
            this.grayShadeBtn.TabIndex = 8;
            this.grayShadeBtn.Text = "В оттенок серого";
            this.grayShadeBtn.UseVisualStyleBackColor = true;
            this.grayShadeBtn.Click += new System.EventHandler(this.grayShadeBtn_Click);
            // 
            // cropBitmap
            // 
            this.cropBitmap.Location = new System.Drawing.Point(623, 140);
            this.cropBitmap.Name = "cropBitmap";
            this.cropBitmap.Size = new System.Drawing.Size(105, 58);
            this.cropBitmap.TabIndex = 9;
            this.cropBitmap.Text = "Вырезать квадрат 100x100";
            this.cropBitmap.UseVisualStyleBackColor = true;
            this.cropBitmap.Click += new System.EventHandler(this.cropBitmap_Click);
            // 
            // inverseColorBtn
            // 
            this.inverseColorBtn.Location = new System.Drawing.Point(623, 76);
            this.inverseColorBtn.Name = "inverseColorBtn";
            this.inverseColorBtn.Size = new System.Drawing.Size(105, 58);
            this.inverseColorBtn.TabIndex = 10;
            this.inverseColorBtn.Text = "Инверсия цвета";
            this.inverseColorBtn.UseVisualStyleBackColor = true;
            this.inverseColorBtn.Click += new System.EventHandler(this.inverseColorBtn_Click);
            // 
            // mirrorBtn
            // 
            this.mirrorBtn.Location = new System.Drawing.Point(623, 204);
            this.mirrorBtn.Name = "mirrorBtn";
            this.mirrorBtn.Size = new System.Drawing.Size(105, 58);
            this.mirrorBtn.TabIndex = 11;
            this.mirrorBtn.Text = "Отзеркалить (X)";
            this.mirrorBtn.UseVisualStyleBackColor = true;
            this.mirrorBtn.Click += new System.EventHandler(this.mirrorBtn_Click);
            // 
            // clipCircleBtn
            // 
            this.clipCircleBtn.Location = new System.Drawing.Point(623, 268);
            this.clipCircleBtn.Name = "clipCircleBtn";
            this.clipCircleBtn.Size = new System.Drawing.Size(105, 58);
            this.clipCircleBtn.TabIndex = 12;
            this.clipCircleBtn.Text = "Вырезать круг";
            this.clipCircleBtn.UseVisualStyleBackColor = true;
            this.clipCircleBtn.Click += new System.EventHandler(this.clipCircleBtn_Click);
            // 
            // clipEllipseBtn
            // 
            this.clipEllipseBtn.Location = new System.Drawing.Point(623, 332);
            this.clipEllipseBtn.Name = "clipEllipseBtn";
            this.clipEllipseBtn.Size = new System.Drawing.Size(105, 58);
            this.clipEllipseBtn.TabIndex = 13;
            this.clipEllipseBtn.Text = "Вырезать эллипс";
            this.clipEllipseBtn.UseVisualStyleBackColor = true;
            this.clipEllipseBtn.Click += new System.EventHandler(this.clipEllipseBtn_Click);
            // 
            // clipTriangleBtn
            // 
            this.clipTriangleBtn.Location = new System.Drawing.Point(623, 396);
            this.clipTriangleBtn.Name = "clipTriangleBtn";
            this.clipTriangleBtn.Size = new System.Drawing.Size(105, 58);
            this.clipTriangleBtn.TabIndex = 14;
            this.clipTriangleBtn.Text = "Вырезать треугольник";
            this.clipTriangleBtn.UseVisualStyleBackColor = true;
            this.clipTriangleBtn.Click += new System.EventHandler(this.clipTriangleBtn_Click);
            // 
            // multiTextBtn
            // 
            this.multiTextBtn.Location = new System.Drawing.Point(512, 76);
            this.multiTextBtn.Name = "multiTextBtn";
            this.multiTextBtn.Size = new System.Drawing.Size(105, 58);
            this.multiTextBtn.TabIndex = 15;
            this.multiTextBtn.Text = "Наложение десяти текстов";
            this.multiTextBtn.UseVisualStyleBackColor = true;
            this.multiTextBtn.Click += new System.EventHandler(this.multiTextBtn_Click);
            // 
            // multiRotatedTextBtn
            // 
            this.multiRotatedTextBtn.Location = new System.Drawing.Point(512, 332);
            this.multiRotatedTextBtn.Name = "multiRotatedTextBtn";
            this.multiRotatedTextBtn.Size = new System.Drawing.Size(105, 58);
            this.multiRotatedTextBtn.TabIndex = 16;
            this.multiRotatedTextBtn.Text = "Наложение 10 повёрнутых текстов";
            this.multiRotatedTextBtn.UseVisualStyleBackColor = true;
            this.multiRotatedTextBtn.Click += new System.EventHandler(this.multiRotatedTextBtn_Click);
            // 
            // multiRotatedBitmapBtn
            // 
            this.multiRotatedBitmapBtn.Location = new System.Drawing.Point(512, 460);
            this.multiRotatedBitmapBtn.Name = "multiRotatedBitmapBtn";
            this.multiRotatedBitmapBtn.Size = new System.Drawing.Size(105, 58);
            this.multiRotatedBitmapBtn.TabIndex = 17;
            this.multiRotatedBitmapBtn.Text = "Наложение 2 повёрнутых картинок";
            this.multiRotatedBitmapBtn.UseVisualStyleBackColor = true;
            this.multiRotatedBitmapBtn.Click += new System.EventHandler(this.multiRotatedBitmapBtn_Click);
            // 
            // multiBitmapBtn
            // 
            this.multiBitmapBtn.Location = new System.Drawing.Point(512, 204);
            this.multiBitmapBtn.Name = "multiBitmapBtn";
            this.multiBitmapBtn.Size = new System.Drawing.Size(105, 58);
            this.multiBitmapBtn.TabIndex = 18;
            this.multiBitmapBtn.Text = "Наложение двух картинок";
            this.multiBitmapBtn.UseVisualStyleBackColor = true;
            this.multiBitmapBtn.Click += new System.EventHandler(this.multiBitmapBtn_Click);
            // 
            // marginBtn
            // 
            this.marginBtn.Location = new System.Drawing.Point(623, 460);
            this.marginBtn.Name = "marginBtn";
            this.marginBtn.Size = new System.Drawing.Size(105, 58);
            this.marginBtn.TabIndex = 19;
            this.marginBtn.Text = "[MARGIN]\r\nОтступ 100 с каждой стороны";
            this.marginBtn.UseVisualStyleBackColor = true;
            this.marginBtn.Click += new System.EventHandler(this.marginBtn_Click);
            // 
            // marginColorBtn
            // 
            this.marginColorBtn.Location = new System.Drawing.Point(623, 524);
            this.marginColorBtn.Name = "marginColorBtn";
            this.marginColorBtn.Size = new System.Drawing.Size(105, 58);
            this.marginColorBtn.TabIndex = 20;
            this.marginColorBtn.Text = "[MARGIN]\r\nОтступ с уголками";
            this.marginColorBtn.UseVisualStyleBackColor = true;
            this.marginColorBtn.Click += new System.EventHandler(this.marginColorBtn_Click);
            // 
            // paddingBtn
            // 
            this.paddingBtn.Location = new System.Drawing.Point(623, 588);
            this.paddingBtn.Name = "paddingBtn";
            this.paddingBtn.Size = new System.Drawing.Size(105, 58);
            this.paddingBtn.TabIndex = 21;
            this.paddingBtn.Text = "[PADDING]\r\nОтступ 100 с каждой стороны";
            this.paddingBtn.UseVisualStyleBackColor = true;
            this.paddingBtn.Click += new System.EventHandler(this.paddingBtn_Click);
            // 
            // paddingColorBtn
            // 
            this.paddingColorBtn.Location = new System.Drawing.Point(734, 12);
            this.paddingColorBtn.Name = "paddingColorBtn";
            this.paddingColorBtn.Size = new System.Drawing.Size(105, 58);
            this.paddingColorBtn.TabIndex = 22;
            this.paddingColorBtn.Text = "[PADDING]\r\nОтступ с уголками";
            this.paddingColorBtn.UseVisualStyleBackColor = true;
            this.paddingColorBtn.Click += new System.EventHandler(this.paddingColorBtn_Click);
            // 
            // demotivateBtn
            // 
            this.demotivateBtn.Location = new System.Drawing.Point(734, 76);
            this.demotivateBtn.Name = "demotivateBtn";
            this.demotivateBtn.Size = new System.Drawing.Size(105, 58);
            this.demotivateBtn.TabIndex = 23;
            this.demotivateBtn.Text = "Демотиватор";
            this.demotivateBtn.UseVisualStyleBackColor = true;
            this.demotivateBtn.Click += new System.EventHandler(this.demotivateBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 692);
            this.Controls.Add(this.demotivateBtn);
            this.Controls.Add(this.paddingColorBtn);
            this.Controls.Add(this.paddingBtn);
            this.Controls.Add(this.marginColorBtn);
            this.Controls.Add(this.marginBtn);
            this.Controls.Add(this.multiBitmapBtn);
            this.Controls.Add(this.multiRotatedBitmapBtn);
            this.Controls.Add(this.multiRotatedTextBtn);
            this.Controls.Add(this.multiTextBtn);
            this.Controls.Add(this.clipTriangleBtn);
            this.Controls.Add(this.clipEllipseBtn);
            this.Controls.Add(this.clipCircleBtn);
            this.Controls.Add(this.mirrorBtn);
            this.Controls.Add(this.inverseColorBtn);
            this.Controls.Add(this.cropBitmap);
            this.Controls.Add(this.grayShadeBtn);
            this.Controls.Add(this.sizeChangeBtn);
            this.Controls.Add(this.opacityBtn);
            this.Controls.Add(this.rotatedBitmapBtn);
            this.Controls.Add(this.rotatedTextBtn);
            this.Controls.Add(this.bitmapBtn);
            this.Controls.Add(this.textBtn);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тест либы";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button textBtn;
        private System.Windows.Forms.Button bitmapBtn;
        private System.Windows.Forms.Button rotatedTextBtn;
        private System.Windows.Forms.Button rotatedBitmapBtn;
        private System.Windows.Forms.Button opacityBtn;
        private System.Windows.Forms.Button sizeChangeBtn;
        private System.Windows.Forms.Button grayShadeBtn;
        private System.Windows.Forms.Button cropBitmap;
        private System.Windows.Forms.Button inverseColorBtn;
        private System.Windows.Forms.Button mirrorBtn;
        private System.Windows.Forms.Button clipCircleBtn;
        private System.Windows.Forms.Button clipEllipseBtn;
        private System.Windows.Forms.Button clipTriangleBtn;
        private System.Windows.Forms.Button multiTextBtn;
        private System.Windows.Forms.Button multiRotatedTextBtn;
        private System.Windows.Forms.Button multiRotatedBitmapBtn;
        private System.Windows.Forms.Button multiBitmapBtn;
        private System.Windows.Forms.Button marginBtn;
        private System.Windows.Forms.Button marginColorBtn;
        private System.Windows.Forms.Button paddingBtn;
        private System.Windows.Forms.Button paddingColorBtn;
        private System.Windows.Forms.Button demotivateBtn;
    }
}

