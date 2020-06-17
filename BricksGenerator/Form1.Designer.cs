namespace BricksGenerator
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.bk_glass = new System.Windows.Forms.PictureBox();
            this.bk_casual = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bk_glass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bk_casual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.MenuText;
            this.pictureBox3.Image = global::BricksGenerator.Properties.Resources.TRASHBOX1;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(360, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // bk_glass
            // 
            this.bk_glass.Image = global::BricksGenerator.Properties.Resources.glass_brick;
            this.bk_glass.Location = new System.Drawing.Point(385, 59);
            this.bk_glass.Name = "bk_glass";
            this.bk_glass.Size = new System.Drawing.Size(95, 13);
            this.bk_glass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bk_glass.TabIndex = 3;
            this.bk_glass.TabStop = false;
            this.bk_glass.Click += new System.EventHandler(this.bk_glass_Click);
            // 
            // bk_casual
            // 
            this.bk_casual.Image = global::BricksGenerator.Properties.Resources.casual;
            this.bk_casual.Location = new System.Drawing.Point(390, 23);
            this.bk_casual.Name = "bk_casual";
            this.bk_casual.Size = new System.Drawing.Size(80, 15);
            this.bk_casual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bk_casual.TabIndex = 2;
            this.bk_casual.TabStop = false;
            this.bk_casual.Click += new System.EventHandler(this.bk_casual_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BricksGenerator.Properties.Resources.bg;
            this.pictureBox2.Location = new System.Drawing.Point(360, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(140, 690);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(492, 753);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.bk_glass);
            this.Controls.Add(this.bk_casual);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(510, 800);
            this.Name = "Form1";
            this.Text = "BricksGenerator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bk_glass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bk_casual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox bk_casual;
        private System.Windows.Forms.PictureBox bk_glass;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

