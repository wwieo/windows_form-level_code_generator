using FSharp.Data.Runtime.StructuralTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
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

        private void bk_casual_Click(object sender, EventArgs e)
        {
            spawn(bk_casual, bk_casual.Name, 0, 0, 0);
        }
        private void bk_glass_Click(object sender, EventArgs e)
        {
            spawn(bk_glass, bk_glass.Name, 0, 0, 0);
        }
        private void bk_hurt_Click(object sender, EventArgs e)
        {
            spawn(bk_hurt, bk_hurt.Name, 0, 0, 0);
        }
        private void bk_wick_Click(object sender, EventArgs e)
        {
            spawn(bk_wick, bk_wick.Name, 0, 0, 0);
        }
        private void bk_r_phurt_Click(object sender, EventArgs e)
        {
            spawn(bk_r_phurt, bk_r_phurt.Name, 0, 0, 0);
        }
        private void bk_phurt_Click(object sender, EventArgs e)
        {
            spawn(bk_phurt, bk_phurt.Name, 0, 0, 0);
        }
        private void bk_rock_Click(object sender, EventArgs e)
        {
            spawn(bk_rock, bk_rock.Name, 0, 0, 0);
        }
        private void bk_r_gravity_Click(object sender, EventArgs e)
        {
            spawn(bk_r_gravity, bk_r_gravity.Name, 0, 0, 0);
        }
        private void bk_gravity_Click(object sender, EventArgs e)
        {
            spawn(bk_gravity, bk_gravity.Name, 0, 0, 0);
        }
        private void bk_r_disgravity_Click(object sender, EventArgs e)
        {
            spawn(bk_r_disgravity, bk_r_disgravity.Name, 0, 0, 0);
        }
        private void bk_disgravity_Click(object sender, EventArgs e)
        {
            spawn(bk_disgravity, bk_disgravity.Name, 0, 0, 0);
        }
        private void bk_energy_Click(object sender, EventArgs e)
        {
            spawn(bk_energy, bk_energy.Name, 0, 0, 0);
        }
        private void bk_s_laser_Click(object sender, EventArgs e)
        {
            spawn(bk_s_laser, bk_s_laser.Name, 0, 0, 0);
        }
        private void bk_d_laser_Click(object sender, EventArgs e)
        {
            spawn(bk_d_laser, bk_d_laser.Name, 0, 0, 0);
        }
        private void bk_way_s_laser_Click(object sender, EventArgs e)
        {
            spawn(bk_way_s_laser, bk_way_s_laser.Name, 0, 0, 0);
        }
        private void bk_way_d_laser_Click(object sender, EventArgs e)
        {
            spawn(bk_way_d_laser, bk_way_d_laser.Name, 0, 0, 0);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, PictureBox> item in currenExistBrickList) item.Value.Dispose();
            currenExistBrickList.Clear();
            BrickAngle.Clear();

            Graphics GPS = this.CreateGraphics();
            GPS.Clear(Color.LightGray);
        }

        private void btnTransCode_Click(object sender, EventArgs e)
        {
            string result = "";
            foreach (KeyValuePair<string, PictureBox> item in currenExistBrickList)
            {
                if (!item.Key.Contains("ball"))
                {
                    result += transName(item.Value);
                    result += transPosAndAng(item.Value);
                }
                
            }
            txtRstCode.Text = result;
            if (result != "") Clipboard.SetText(result);
        }

        private string transName(PictureBox brick)
        {

            string executing = "";
            if (brick.Name.Contains("bk_casual")) executing += "n";
            else if (brick.Name.Contains("bk_glass")) executing += "g";
            else if (brick.Name.Contains("bk_hurt")) executing += "h";
            else if (brick.Name.Contains("bk_wick")) executing += "w";
            else if (brick.Name.Contains("bk_r_phurt")) executing += "phr";
            else if (brick.Name.Contains("bk_phurt")) executing += "ph";
            else if (brick.Name.Contains("bk_rock")) executing += "r";
            else if (brick.Name.Contains("bk_r_gravity")) executing += "grr";
            else if (brick.Name.Contains("bk_gravity")) executing += "gr";
            else if (brick.Name.Contains("bk_r_disgravity")) executing += "dgr";
            else if (brick.Name.Contains("bk_disgravity")) executing += "dg";
            else if (brick.Name.Contains("bk_energy")) executing += "b";
            else if (brick.Name.Contains("bk_s_laser")) executing += "sl";
            else if (brick.Name.Contains("bk_d_laser")) executing += "dl";
            else if (brick.Name.Contains("bk_way_s_laser")) executing += "slw";
            else if (brick.Name.Contains("bk_way_d_laser")) executing += "dlw";

            return executing;
        }

        private string transPosAndAng(PictureBox brick)
        {
            string executing = "(";
            executing += (brick.Location.X.ToString() + "," + (brick.Location.Y-50).ToString());
            if (brick.Name.Contains("bk_way_s_laser") || brick.Name.Contains("bk_way_d_laser"))
            {
                foreach (KeyValuePair<string, int> item in BrickAngle)
                {
                    if (brick.Name == item.Key) 
                    { 
                        executing += ("," + item.Value.ToString());
                        break;
                    }
                }
            }
            executing += ")/";     
            return executing;
        }

        private void btnSpawn_Click(object sender, EventArgs e)
        {
            var brickList = new Dictionary<string, PictureBox>()
            {
                { "n" , bk_casual },
                { "g" , bk_glass },
                { "h" , bk_hurt },
                { "w" , bk_wick },
                { "r" , bk_rock },
                { "phr" , bk_r_phurt },
                { "ph" , bk_phurt },
                { "grr" , bk_r_gravity },
                { "gr" , bk_gravity },
                { "dgr" , bk_r_disgravity },
                { "dg" , bk_disgravity },
                { "b" , bk_energy },
                { "sl" , bk_s_laser },
                { "dl" , bk_d_laser },
                { "slw" , bk_way_s_laser },
                { "dlw" , bk_way_d_laser }
            };

            try
            {
                string SourceCode = txtSource.Text;
                char[] seperate = { '/' };
                string[] SourceArray = SourceCode.Split(seperate);
                foreach (KeyValuePair<string, PictureBox> item in currenExistBrickList) item.Value.Dispose();
                currenExistBrickList.Clear();
                BrickAngle.Clear();
                Graphics GPS = this.CreateGraphics();
                GPS.Clear(Color.LightGray);                

                foreach (string brick_team in SourceArray)
                {
                    char[] sep = { '(', ',', ')' };
                    string[] source = brick_team.Split(sep);

                    if(source[0]!= "")
                    {
                        var brick = brickList[source[0]];
                        var brickName = brickList[source[0]].Name;
                        if (brickName == "bk_way_s_laser" || brickName == "bk_way_d_laser")
                        {
                            spawn(brick, brickName, Int32.Parse(source[1]), Int32.Parse(source[2]), Int32.Parse(source[3]));
                        }
                        else
                        {
                            spawn(brick, brickName, Int32.Parse(source[1]), Int32.Parse(source[2]), 0);
                        }
                    }               
                }                           
            }
            catch(Exception ex)
            {
                MessageBox.Show("生成錯誤");
            }            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           var frm = Form.ActiveForm;
           using (var bmp = new Bitmap(frm.Width, frm.Height)) {

                frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                Image sourceImg = CutImage(bmp, new Point(7, 80), new Rectangle(0, 0, 360, 640));
     
                SaveFileDialog save = new SaveFileDialog();
                save.Title = "Saving";
                save.Filter = "Image Files (*.png)|*.png";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    sourceImg.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }        
            }
        }

        private Image CutImage(Image SourceImage, Point StartPoint, Rectangle CutArea)
        {
            Bitmap NewBitmap = new Bitmap(CutArea.Width, CutArea.Height);
            Graphics tmpGraph = Graphics.FromImage(NewBitmap);
            tmpGraph.DrawImage(SourceImage, CutArea, StartPoint.X, StartPoint.Y, CutArea.Width, CutArea.Height, GraphicsUnit.Pixel);
            tmpGraph.Dispose();
            return NewBitmap;
        }

        private void ball0_Click(object sender, EventArgs e)
        {
            spawn(ball0, "ball0", 0, 0, 0);
        }

        private void ball10_Click(object sender, EventArgs e)
        {
            spawn(ball10, "ball10", 0, 0, 0);
        }

        private void ball20_Click(object sender, EventArgs e)
        {
            spawn(ball20, "ball20", 0, 0, 0);
        }

        private void ball30_Click(object sender, EventArgs e)
        {
            spawn(ball30, "ball30", 0, 0, 0);
        }

        private void ball40_Click(object sender, EventArgs e)
        {
            spawn(ball40, "ball40", 0, 0, 0);
        }

        private void ball45_Click(object sender, EventArgs e)
        {
            spawn(ball45, "ball45", 0, 0, 0);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            spawn(ball100, "ball100", 0, 0, 0);
        }


    }
}
