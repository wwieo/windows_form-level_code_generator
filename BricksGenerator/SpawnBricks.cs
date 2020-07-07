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
       
        Dictionary<string, PictureBox> AllBrickList = new Dictionary<string, PictureBox>();
        Dictionary<string, int> BrickAngle = new Dictionary<string, int>();

        int bk_casual_count = 1;
        int bk_glass_count = 1;
        int bk_hurt_count = 1;
        int bk_wick_count = 1;
        int bk_r_phurt_count = 1;
        int bk_phurt_count = 1;
        int bk_rock_count = 1;
        int bk_r_gravity_count = 1;
        int bk_gravity_count = 1;
        int bk_r_disgravity_count = 1;
        int bk_disgravity_count = 1;
        int bk_energy_count = 1;
        int bk_s_laser_count = 1;
        int bk_d_laser_count = 1;
        int bk_way_s_laser_count = 1;
        int bk_way_d_laser_count = 1;

        public void spawn(PictureBox brick, String brick_name, int brick_X, int brick_Y, int angle)
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
            else if (brick_name == "bk_hurt")
            {
                pb.Name = "bk_hurt" + bk_hurt_count.ToString();
                bk_hurt_count += 1;
            }
            else if (brick_name == "bk_wick")
            {
                pb.Name = "bk_wick" + bk_wick_count.ToString();
                bk_wick_count += 1;
            }
            else if (brick_name == "bk_r_phurt")
            {
                pb.Name = "bk_r_phurt" + bk_r_phurt_count.ToString();
                bk_r_phurt_count += 1;
            }
            else if (brick_name == "bk_phurt")
            {
                pb.Name = "bk_phurt" + bk_phurt_count.ToString();
                bk_phurt_count += 1;
            }
            else if (brick_name == "bk_rock")
            {
                pb.Name = "bk_rock" + bk_rock_count.ToString();
                bk_rock_count += 1;
            }
            else if (brick_name == "bk_r_gravity")
            {
                pb.Name = "bk_r_gravity" + bk_r_gravity_count.ToString();
                bk_r_gravity_count += 1;
            }
            else if (brick_name == "bk_gravity")
            {
                pb.Name = "bk_gravity" + bk_gravity_count.ToString();
                bk_gravity_count += 1;
            }
            else if (brick_name == "bk_r_disgravity")
            {
                pb.Name = "bk_r_disgravity" + bk_r_disgravity_count.ToString();
                bk_r_disgravity_count += 1;
            }
            else if (brick_name == "bk_disgravity")
            {
                pb.Name = "bk_disgravity" + bk_disgravity_count.ToString();
                bk_disgravity_count += 1;
            }
            else if (brick_name == "bk_energy")
            {
                pb.Name = "bk_energy" + bk_energy_count.ToString();
                bk_energy_count += 1;
            }
            else if (brick_name == "bk_s_laser")
            {
                pb.Name = "bk_s_laser" + bk_s_laser_count.ToString();
                bk_s_laser_count += 1;
            }
            else if (brick_name == "bk_d_laser")
            {
                pb.Name = "bk_d_laser" + bk_d_laser_count.ToString();
                bk_d_laser_count += 1;
            }
            else if (brick_name == "bk_way_s_laser")
            {
                pb.Name = "bk_way_s_laser" + bk_way_s_laser_count.ToString();
                bk_way_s_laser_count += 1;
            }
            else if (brick_name == "bk_way_d_laser")
            {
                pb.Name = "bk_way_d_laser" + bk_way_d_laser_count.ToString();
                bk_way_d_laser_count += 1;
            }

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
                pb.Paint += new PaintEventHandler(way_paint);
                pb.Image = RotateImage(pb.Image, -angle);
                BrickAngle.Add(pb.Name, angle);
            }
                

            AllBrickList.Add(pb.Name, pb);

            if (AllBrickList.Count > 0)
            {
                foreach (PictureBox pbb in AllBrickList.Values)
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
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(pb_angle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

            Point point;
        void down_bk(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            point = e.Location;
            PictureBox pb = sender as PictureBox;
            int bk_X = pb.Location.X + pb.Width / 2;
            int bk_Y = pb.Location.Y + pb.Height / 2;
            Pen pen = new Pen(Color.Black, 2);
            Pen penB = new Pen(Color.Blue, 2);
            Pen penR = new Pen(Color.Red, 2);

            Graphics GPS = this.CreateGraphics();
            GPS.Clear(Color.LightGray);
            GPS.DrawLine(pen, bk_X - 1000, bk_Y, bk_X + 1000, bk_Y);
            GPS.DrawLine(pen, bk_X, bk_Y - 1000, bk_X, bk_Y + 1000);
            if (pb.Name.Contains("bk_r_phurt") || pb.Name.Contains("bk_gravity") || pb.Name.Contains("bk_disgravity")||
                pb.Name.Contains("bk_r_gravity")||pb.Name.Contains("bk_r_disgravity"))
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
                    Console.WriteLine(bk_angle.Value);
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
                Graphics GPS = this.CreateGraphics();
                GPS.Clear(Color.LightGray);
                GPS.DrawLine(pen, bk_X - 1000, bk_Y, bk_X + 1000, bk_Y);
                GPS.DrawLine(pen, bk_X, bk_Y - 1000, bk_X, bk_Y + 1000);

                foreach (KeyValuePair<string, PictureBox> item in AllBrickList)
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
                if (pb.Name.Contains("bk_way_d_laser")|| pb.Name.Contains("bk_way_s_laser"))
                {
                    
                    foreach (KeyValuePair<string, int>  bk_angle in BrickAngle)
                    {
                       // Console.WriteLine(bk_angle.Value);
                        if(pb.Name == bk_angle.Key)
                        {
                            int terminal_X = (int)(1000 * Math.Cos((Math.PI / 180) * -bk_angle.Value));
                            int terminal_Y = (int)(1000 * Math.Sin((Math.PI / 180) * -bk_angle.Value));

                            if (pb.Name.Contains("bk_way_d_laser"))
                                GPS.DrawLine(penR, bk_X, bk_Y, bk_X - terminal_X, bk_Y - terminal_Y);
                            GPS.DrawLine(penR, bk_X, bk_Y, bk_X + terminal_X, bk_Y + terminal_Y);
                        }
                    }
                }
                //Console.WriteLine(AllBrickList[current_brick_name].Location);
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
                AllBrickList.Remove(pb.Name);
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
