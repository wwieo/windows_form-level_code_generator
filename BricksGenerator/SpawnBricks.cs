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
    public partial class Form1: Form 
    {

        Dictionary<string, PictureBox> AllBrickList =  new Dictionary<string, PictureBox>();
  

        int bk_casual_count = 1;
        int bk_glass_count = 1;
        public void spawn(PictureBox brick, String brick_name)
        {
        

            PictureBox pb = new PictureBox();
            if (brick_name == "bk_casual")
            {
                pb.Name = "bk_casual" + bk_casual_count.ToString();
                bk_casual_count += 1;
            }
            else if (brick_name == "bk_glass") 
            {
                pb.Name = "bk_glass" + bk_glass_count.ToString();
                bk_glass_count += 1;
            }
            

            pb.Size = brick.Size;
            pb.Image = brick.Image;
            pb.Location = new Point(0, 50);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
   

            this.Controls.Add(pb);
            pb.MouseDown += new MouseEventHandler(down_bk);
            pb.MouseMove += new MouseEventHandler(drag_bk);         
            pb.MouseUp += new MouseEventHandler(up_bk);

         
            AllBrickList.Add(pb.Name, pb);

            pb.BringToFront();
            pictureBox2.SendToBack();
            pictureBox3.SendToBack();
        }

        Point point;
        void down_bk(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            point = e.Location;
        }

        
        void drag_bk(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            PictureBox pb = sender as PictureBox;
            Pen pen = new Pen(Color.Black, 2);
            string current_brick_name = pb.Name;

            if (e.Button == MouseButtons.Left)
            {
                pb.Left += e.X - point.X;
                pb.Top += e.Y - point.Y;

                int bk_X = pb.Location.X + pb.Width / 2;
                int bk_Y = pb.Location.Y + pb.Height / 2;        
                Graphics GPS = this.CreateGraphics();
                GPS.Clear(Color.LightGray);
                GPS.DrawLine(pen, bk_X - 1000, bk_Y ,bk_X + 1000, bk_Y);
                GPS.DrawLine(pen, bk_X, bk_Y - 1000, bk_X, bk_Y + 1000);  

                foreach (KeyValuePair<string, PictureBox> item in AllBrickList)
                {
                    if(item.Value.Name != current_brick_name)
                    {
                        if(Math.Abs(bk_X-(item.Value.Location.X+item.Value.Width/2)) <= 3)
                        {
                            pb.Left = item.Value.Location.X + item.Value.Width/2 - pb.Width/2;     
                        }
                        if(Math.Abs(bk_Y - (item.Value.Location.Y + item.Value.Height / 2)) <= 3)
                        {
                            pb.Top = item.Value.Location.Y + item.Value.Height / 2 - pb.Height / 2;
                        }
                    }
                }
                //Console.WriteLine(AllBrickList[current_brick_name].Location);
            }
           
        }


        void up_bk(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb.Left + pb.Width> 360) pb.Left = 360 - pb.Width;
            else if (pb.Left < 0) pb.Left = 0;

            if (pb.Top < 50) {
                AllBrickList.Remove(pb.Name);
                pb.Dispose();
            }
            if (pb.Top + pb.Height > 690)pb.Top = 690 - pb.Height;
            
            //Console.WriteLine(pb.Location);

            Graphics GPS = this.CreateGraphics();
            GPS.Clear(Color.LightGray);
        }
    }
}
