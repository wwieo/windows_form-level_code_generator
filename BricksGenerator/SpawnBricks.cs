using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BricksGenerator
{
    public partial class Form1 : Form
    {
       
        Dictionary<string, PictureBox> currenExistBrickList = new Dictionary<string, PictureBox>();
        Dictionary<string, int> BrickAngle = new Dictionary<string, int>();

        
        Dictionary<string, int> allBrickList = new Dictionary<string, int>()
            {
            //brickName: brickNameCounts
                { "bk_casual" ,  1},
                { "bk_glass" ,  1},
                { "bk_hurt" ,  1},
                { "bk_wick" ,  1},
                { "bk_rock" ,  1},
                { "bk_r_phurt" ,  1},
                { "bk_phurt" ,  1},
                { "bk_r_gravity" ,  1},
                { "bk_gravity" ,  1},
                { "bk_r_disgravity" ,  1},
                { "bk_disgravity" ,  1},
                { "bk_energy" ,  1},
                { "bk_s_laser" ,  1},
                { "bk_d_laser" ,  1},
                { "bk_way_s_laser" ,  1},
                { "bk_way_d_laser" ,  1},
                { "bk_little_hp" ,  1},
                { "bk_huge_hp" ,  1},
                { "ball0" ,  1},
                { "ball10" ,  1},
                { "ball20" ,  1},
                { "ball30" , 1},
                { "ball40" ,  1},
                { "ball45" ,  1},
                { "ball100" ,  1}
            };
       
        public void spawn(PictureBox brick, String brick_name, int brick_X, int brick_Y, int angle)
        {
            PictureBox pb = new PictureBox();
            pb.Name = brick_name;
            pb.Name += allBrickList[brick_name].ToString();
            allBrickList[brick_name] += 1;            

            pb.Size = brick.Size;
            pb.Image = brick.Image;
            pb.Location = new Point(brick_X, brick_Y+50);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;

            this.Controls.Add(pb);
            pb.MouseDown += new MouseEventHandler(down_bk);
            pb.MouseMove += new MouseEventHandler(drag_bk);
            pb.MouseUp += new MouseEventHandler(up_bk);
            pb.MouseWheel += new MouseEventHandler(scale_bk);
            if(brick_name == "bk_way_s_laser" || brick_name == "bk_way_d_laser")
            {
                // rotate brick image
                //pb.Paint += new PaintEventHandler(way_paint);
                //pb.Image = RotateImage(pb.Image, -angle);
                BrickAngle.Add(pb.Name, angle);
            }
                
            currenExistBrickList.Add(pb.Name, pb);

            if (currenExistBrickList.Count > 0)
            {
                foreach (PictureBox pbb in currenExistBrickList.Values)
                {
                    if (pbb.Name.Contains("bk_phurt") || pbb.Name.Contains("bk_r_phurt")
                        || pbb.Name.Contains("bk_gravity") || pbb.Name.Contains("bk_r_gravity")
                        || pbb.Name.Contains("bk_r_disgravity") || pbb.Name.Contains("bk_disgravity")) pbb.SendToBack();

                    else pbb.BringToFront();

                    pictureBox2.SendToBack();
                    pictureBox3.SendToBack();
                }
            }
        }
        public static Image RotateImage(Image img, int pb_angle)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            gfx.RotateTransform(pb_angle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.DrawImage(img, new Point(0, 0));
            gfx.Dispose();
            return bmp;
        }

            Point point;
        void down_bk(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pbDrawline(pb, e);
        }
        void pbDrawline(PictureBox pb, MouseEventArgs e)
        {
            point = e.Location;
            
            int bk_X = pb.Location.X + pb.Width / 2;
            int bk_Y = pb.Location.Y + pb.Height / 2;
            Pen pen = new Pen(Color.Black, 2);
            Pen penB = new Pen(Color.Blue, 2);
            Pen penR = new Pen(Color.Red, 2);

            Graphics GPS = this.CreateGraphics();
            GPS.Clear(Color.LightGray);
            GPS.DrawLine(pen, bk_X - 1000, bk_Y, bk_X + 1000, bk_Y);
            GPS.DrawLine(pen, bk_X, bk_Y - 1000, bk_X, bk_Y + 1000);
            if (pb.Name.Contains("bk_r_phurt") || pb.Name.Contains("bk_gravity") || pb.Name.Contains("bk_disgravity") ||
                pb.Name.Contains("bk_r_gravity") || pb.Name.Contains("bk_r_disgravity"))
            {
                if (pb.Name.Contains("bk_gravity") || pb.Name.Contains("bk_disgravity") ||
                    pb.Name.Contains("bk_r_gravity") || pb.Name.Contains("bk_r_disgravity"))
                {
                    GPS.DrawEllipse(penB, bk_X - 125, bk_Y - 125, 250, 250);
                    GPS.DrawEllipse(penB, bk_X - 50, bk_Y - 50, 100, 100);
                }
                if (pb.Name.Contains("bk_r_phurt"))
                {
                    GPS.DrawEllipse(penB, bk_X - 25, bk_Y - 25, 50, 50);
                }
            }
            if (pb.Name.Contains("bk_way_d_laser") || pb.Name.Contains("bk_way_s_laser"))
            {

                foreach (KeyValuePair<string, int> bk_angle in BrickAngle)
                {
                    //Console.WriteLine(bk_angle.Value);
                    if (pb.Name == bk_angle.Key)
                    {
                        int terminal_X = (int)(1000 * Math.Cos((Math.PI / 180) * -bk_angle.Value));
                        int terminal_Y = (int)(1000 * Math.Sin((Math.PI / 180) * -bk_angle.Value));

                        if (pb.Name.Contains("bk_way_d_laser"))
                            GPS.DrawLine(penR, bk_X, bk_Y, bk_X - terminal_X, bk_Y - terminal_Y);
                        GPS.DrawLine(penR, bk_X, bk_Y, bk_X + terminal_X, bk_Y + terminal_Y);
                    }
                }
            }
            Pen penSmash = new Pen(Color.Green, 5);
            if (pb.Name.Contains("ball"))
            {
                if (pb.Name.Contains("ball100")) GPS.DrawLine(penSmash, bk_X, bk_Y, bk_X, bk_Y + calculateDistance(4));
                if (pb.Name.Contains("ball0")) GPS.DrawLine(penSmash, bk_X, bk_Y, bk_X, bk_Y + calculateDistance(7));
                if (pb.Name.Contains("ball10")) GPS.DrawLine(penSmash, bk_X, bk_Y, bk_X, bk_Y + calculateDistance(4.5));
                if (pb.Name.Contains("ball20")) GPS.DrawLine(penSmash, bk_X, bk_Y, bk_X, bk_Y + calculateDistance(6));
                if (pb.Name.Contains("ball30")) GPS.DrawLine(penSmash, bk_X, bk_Y, bk_X, bk_Y + calculateDistance(5));
                if (pb.Name.Contains("ball40")) GPS.DrawLine(penSmash, bk_X, bk_Y, bk_X, bk_Y + calculateDistance(5.5));
                if (pb.Name.Contains("ball45")) GPS.DrawLine(penSmash, bk_X, bk_Y, bk_X, bk_Y + calculateDistance(4));
            }
        }
        int calculateDistance(double ratio)
        {
            int result = (int)((2/Math.Sqrt(ratio)*175));
            return result;
        }
        float pb_angle;
        void drag_bk(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            PictureBox pb = sender as PictureBox;
            Pen penB = new Pen(Color.Blue, 2);
            Pen penR = new Pen(Color.Red, 2);
            Pen pen = new Pen(Color.Black, 2);
            string current_brick_name = pb.Name;

            if (e.Button == MouseButtons.Left)
            {
                pb.Left += e.X - point.X;
                pb.Top += e.Y - point.Y;

                int bk_X = pb.Location.X + pb.Width / 2;
                int bk_Y = pb.Location.Y + pb.Height / 2;
                foreach (KeyValuePair<string, PictureBox> item in currenExistBrickList)
                {
                    if (item.Value.Name != current_brick_name)
                    {
                        if (Math.Abs(bk_X - (item.Value.Location.X + item.Value.Width / 2)) <= 3)
                        {
                            pb.Left = item.Value.Location.X + item.Value.Width / 2 - pb.Width / 2;
                        }
                        if (Math.Abs(bk_Y - (item.Value.Location.Y + item.Value.Height / 2)) <= 3)
                        {
                            pb.Top = item.Value.Location.Y + item.Value.Height / 2 - pb.Height / 2;
                        }
                    }
                }

                Graphics GPS = this.CreateGraphics();
                GPS.Clear(Color.LightGray);
                GPS.DrawLine(pen, bk_X - 1000, bk_Y, bk_X + 1000, bk_Y);
                GPS.DrawLine(pen, bk_X, bk_Y - 1000, bk_X, bk_Y + 1000);
                if (pb.Name.Contains("bk_r_phurt") || pb.Name.Contains("bk_gravity") || pb.Name.Contains("bk_disgravity") ||
                    pb.Name.Contains("bk_r_gravity") || pb.Name.Contains("bk_r_disgravity"))
                {
                    if (pb.Name.Contains("bk_gravity") || pb.Name.Contains("bk_disgravity") ||
                        pb.Name.Contains("bk_r_gravity") || pb.Name.Contains("bk_r_disgravity"))
                    {
                        GPS.DrawEllipse(penB, bk_X - 125, bk_Y - 125, 250, 250);
                        GPS.DrawEllipse(penB, bk_X - 50, bk_Y - 50, 100, 100);
                    }
                    if (pb.Name.Contains("bk_r_phurt"))
                    {
                        GPS.DrawEllipse(penB, bk_X - 25, bk_Y - 25, 50, 50);
                    }
                }
                if (pb.Name.Contains("bk_way_d_laser") || pb.Name.Contains("bk_way_s_laser"))
                {

                    foreach (KeyValuePair<string, int> bk_angle in BrickAngle)
                    {
                        // Console.WriteLine(bk_angle.Value);
                        if (pb.Name == bk_angle.Key)
                        {
                            int terminal_X = (int)(1000 * Math.Cos((Math.PI / 180) * -bk_angle.Value));
                            int terminal_Y = (int)(1000 * Math.Sin((Math.PI / 180) * -bk_angle.Value));

                            if (pb.Name.Contains("bk_way_d_laser"))
                                GPS.DrawLine(penR, bk_X, bk_Y, bk_X - terminal_X, bk_Y - terminal_Y);
                            GPS.DrawLine(penR, bk_X, bk_Y, bk_X + terminal_X, bk_Y + terminal_Y);
                        }
                    }
                }
                Pen penSmash = new Pen(Color.Green, 5);

                if (pb.Name.Contains("ball"))
                {
                    if (pb.Name.Contains("ball100")) GPS.DrawLine(penSmash, bk_X, bk_Y, bk_X, bk_Y + calculateDistance(4));
                    if (pb.Name.Contains("ball0")) GPS.DrawLine(penSmash, bk_X, bk_Y, bk_X, bk_Y + calculateDistance(7));
                    if (pb.Name.Contains("ball10")) GPS.DrawLine(penSmash, bk_X, bk_Y, bk_X, bk_Y + calculateDistance(4.5));
                    if (pb.Name.Contains("ball20")) GPS.DrawLine(penSmash, bk_X, bk_Y, bk_X, bk_Y + calculateDistance(6));
                    if (pb.Name.Contains("ball30")) GPS.DrawLine(penSmash, bk_X, bk_Y, bk_X, bk_Y + calculateDistance(5));
                    if (pb.Name.Contains("ball40")) GPS.DrawLine(penSmash, bk_X, bk_Y, bk_X, bk_Y + calculateDistance(5.5));
                    if (pb.Name.Contains("ball45")) GPS.DrawLine(penSmash, bk_X, bk_Y, bk_X, bk_Y + calculateDistance(4));
                }
                //Console.WriteLine(currenExistBrickList[current_brick_name].Location);
            }
            else if(e.Button == MouseButtons.Right)
            {
                if(pb.Name.Contains("bk_way_s_laser") || pb.Name.Contains("bk_way_d_laser"))
                {
                    Rectangle rect = pb.ClientRectangle;
                    float centerX = (rect.Left + rect.Right) * 0.5f;
                    float centerY = (rect.Top + rect.Bottom) * 0.5f;
                    pb_angle = (float)(Math.Atan2(e.Y - centerY, e.X - centerX) * 180.0 / Math.PI);
                    
                    pb.Invalidate();

                    lblAngle.Visible = true;
                    int angle = (int)pb_angle;
                    angle = -angle;
                    lblAngle.Text = angle.ToString();

                    Graphics GPS = this.CreateGraphics();
                    GPS.Clear(Color.LightGray);
                    
                    int bk_X = pb.Location.X + pb.Width / 2;
                    int bk_Y = pb.Location.Y + pb.Height / 2;
                    int terminal_X = (int)(1000 * Math.Cos((Math.PI / 180) * -angle));
                    int terminal_Y = (int)(1000 * Math.Sin((Math.PI / 180) * -angle));
     
                    if (pb.Name.Contains("bk_way_d_laser"))
                        GPS.DrawLine(penR, bk_X, bk_Y, bk_X -terminal_X, bk_Y - terminal_Y);
                    GPS.DrawLine(penR, bk_X, bk_Y, bk_X + terminal_X, bk_Y + terminal_Y);

                    foreach (KeyValuePair<string, int> item in BrickAngle)
                    {
                        if(pb.Name == item.Key)
                        {
                            BrickAngle[item.Key] = angle;
                            //Console.WriteLine(item.Key);
                            break;
                        }
                    }
                }
            }

        }

        void way_paint(object sender, PaintEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            Rectangle rect = pb.ClientRectangle;
            float centerX = (rect.Left + rect.Right) * 0.5f;
            float centerY = (rect.Top + rect.Bottom) * 0.5f;
            float scale = (float)pb.Width / pb.Image.Width;

            e.Graphics.TranslateTransform(centerX, centerY);
            e.Graphics.RotateTransform(pb_angle);
            e.Graphics.TranslateTransform(-centerX, -centerY);
            e.Graphics.ScaleTransform(scale, scale);
            e.Graphics.Clear(System.Drawing.Color.LightGray);
            e.Graphics.DrawImage(pb.Image, 0, 0);
        }


        void up_bk(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb.Left + pb.Width > 360) pb.Left = 360 - pb.Width;
            else if (pb.Left < 0) pb.Left = 0;

            if (pb.Top < 50)
            {
                currenExistBrickList.Remove(pb.Name);
                pb.Dispose();
            }
            if (pb.Top + pb.Height > 690) pb.Top = 690 - pb.Height;

            //Console.WriteLine(pb.Location);
            lblAngle.Visible = false;
            Graphics GPS = this.CreateGraphics();
            GPS.Clear(Color.LightGray);
        }

        void scale_bk(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            PictureBox pb = sender as PictureBox;
            Graphics GPS = this.CreateGraphics();
            if (pb.Name.Contains("bk_phurt") || pb.Name.Contains("bk_gravity") || pb.Name.Contains("bk_disgravity"))
            {
                if (e.Delta >= 0)
                {
                    pb.Width = (int)(pb.Width * 1.05);
                    pb.Height = (int)(pb.Height * 1.05);
                    GPS.Clear(Color.LightGray);
                }
                else
                {
                    pb.Width = (int)(pb.Width * 0.95);
                    pb.Height = (int)(pb.Height * 0.95);
                    GPS.Clear(Color.LightGray);
                }
            }

        }
    }
}
