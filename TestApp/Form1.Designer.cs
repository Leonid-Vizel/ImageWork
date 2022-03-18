
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(332, 442);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(461, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(332, 440);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // textBtn
            // 
            this.textBtn.Location = new System.Drawing.Point(350, 12);
            this.textBtn.Name = "textBtn";
            this.textBtn.Size = new System.Drawing.Size(105, 58);
            this.textBtn.TabIndex = 2;
            this.textBtn.Text = "Наложение текста";
            this.textBtn.UseVisualStyleBackColor = true;
            this.textBtn.Click += new System.EventHandler(this.textBtn_Click);
            // 
            // bitmapBtn
            // 
            this.bitmapBtn.Location = new System.Drawing.Point(350, 76);
            this.bitmapBtn.Name = "bitmapBtn";
            this.bitmapBtn.Size = new System.Drawing.Size(105, 58);
            this.bitmapBtn.TabIndex = 3;
            this.bitmapBtn.Text = "Наложение картинки";
            this.bitmapBtn.UseVisualStyleBackColor = true;
            this.bitmapBtn.Click += new System.EventHandler(this.bitmapBtn_Click);
            // 
            // rotatedTextBtn
            // 
            this.rotatedTextBtn.Location = new System.Drawing.Point(350, 140);
            this.rotatedTextBtn.Name = "rotatedTextBtn";
            this.rotatedTextBtn.Size = new System.Drawing.Size(105, 58);
            this.rotatedTextBtn.TabIndex = 4;
            this.rotatedTextBtn.Text = "Наложение повёрнутого текста";
            this.rotatedTextBtn.UseVisualStyleBackColor = true;
            this.rotatedTextBtn.Click += new System.EventHandler(this.rotatedTextBtn_Click);
            // 
            // rotatedBitmapBtn
            // 
            this.rotatedBitmapBtn.Location = new System.Drawing.Point(350, 204);
            this.rotatedBitmapBtn.Name = "rotatedBitmapBtn";
            this.rotatedBitmapBtn.Size = new System.Drawing.Size(105, 58);
            this.rotatedBitmapBtn.TabIndex = 5;
            this.rotatedBitmapBtn.Text = "Наложение повёрнутой картинки";
            this.rotatedBitmapBtn.UseVisualStyleBackColor = true;
            this.rotatedBitmapBtn.Click += new System.EventHandler(this.rotatedBitmapBtn_Click);
            // 
            // opacityBtn
            // 
            this.opacityBtn.Location = new System.Drawing.Point(350, 268);
            this.opacityBtn.Name = "opacityBtn";
            this.opacityBtn.Size = new System.Drawing.Size(105, 58);
            this.opacityBtn.TabIndex = 6;
            this.opacityBtn.Text = "Задать прозрачность 50%";
            this.opacityBtn.UseVisualStyleBackColor = true;
            this.opacityBtn.Click += new System.EventHandler(this.opacityBtn_Click);
            // 
            // sizeChangeBtn
            // 
            this.sizeChangeBtn.Location = new System.Drawing.Point(350, 332);
            this.sizeChangeBtn.Name = "sizeChangeBtn";
            this.sizeChangeBtn.Size = new System.Drawing.Size(105, 58);
            this.sizeChangeBtn.TabIndex = 7;
            this.sizeChangeBtn.Text = "Задать размер 1000 x1000";
            this.sizeChangeBtn.UseVisualStyleBackColor = true;
            this.sizeChangeBtn.Click += new System.EventHandler(this.sizeChangeBtn_Click);
            // 
            // grayShadeBtn
            // 
            this.grayShadeBtn.Location = new System.Drawing.Point(350, 396);
            this.grayShadeBtn.Name = "grayShadeBtn";
            this.grayShadeBtn.Size = new System.Drawing.Size(105, 58);
            this.grayShadeBtn.TabIndex = 8;
            this.grayShadeBtn.Text = "В оттенок серого";
            this.grayShadeBtn.UseVisualStyleBackColor = true;
            this.grayShadeBtn.Click += new System.EventHandler(this.grayShadeBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 464);
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
    }
}

