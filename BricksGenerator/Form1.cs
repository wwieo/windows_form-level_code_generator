using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BricksGenerator
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        int bk_casual_count = 1;
        private void bk_casual_Click(object sender, EventArgs e)
        {
            PictureBox pb = new PictureBox();
            pb.Name = "bk_casual" + bk_casual_count.ToString();
            pb.Location = new Point(0, 50);
            pb.Size = bk_casual.Size;
            pb.Image = bk_casual.Image;
            this.Controls.Add(pb);
            bk_casual_count += 1;

            pb.MouseDown += new MouseEventHandler(down_bk);
            pb.MouseMove += new MouseEventHandler(drag_bk);
            pb.MouseUp += new MouseEventHandler(up_bk);
        }

        Point point;
        void down_bk(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            point = e.Location;
        }

        void drag_bk(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (e.Button == MouseButtons.Left)
            {
                pb.Left += e.X - point.X;
                pb.Top += e.Y - point.Y;
            }
        }

        void up_bk(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb.Left > 360) pb.Left = 360 - pb.Width;
            else if (pb.Left < 0) pb.Left = 0;
            
            if (pb.Top < 50)pb.Top = 50;
            if (pb.Top + pb.Height > 690) pb.Top = 690- pb.Height;
            //Console.WriteLine(pb.Location);
        }
    }
}
