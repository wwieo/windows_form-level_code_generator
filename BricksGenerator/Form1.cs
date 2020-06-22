using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            spawn(bk_casual, "bk_casual");
        }
        private void bk_glass_Click(object sender, EventArgs e)
        {
            spawn(bk_glass, "bk_glass");
        }

        private void bk_hurt_Click(object sender, EventArgs e)
        {
            spawn(bk_hurt, "bk_hurt");
        }

        private void bk_wick_Click(object sender, EventArgs e)
        {
            spawn(bk_wick, "bk_wick");
        }

        private void bk_r_phurt_Click(object sender, EventArgs e)
        {
            spawn(bk_r_phurt, "bk_r_phurt");
        }

        private void bk_phurt_Click(object sender, EventArgs e)
        {
            spawn(bk_phurt, "bk_phurt");
        }

        private void bk_rock_Click(object sender, EventArgs e)
        {
            spawn(bk_rock, "bk_rock");
        }

        private void bk_r_gravity_Click(object sender, EventArgs e)
        {
            spawn(bk_r_gravity, "bk_r_gravity");
        }

        private void bk_gravity_Click(object sender, EventArgs e)
        {
            spawn(bk_gravity, "bk_gravity");
        }

        private void bk_r_disgravity_Click(object sender, EventArgs e)
        {
            spawn(bk_r_disgravity, "bk_r_disgravity");
        }
        private void bk_disgravity_Click(object sender, EventArgs e)
        {
            spawn(bk_disgravity, "bk_disgravity");
        }
        private void bk_energy_Click(object sender, EventArgs e)
        {
            spawn(bk_energy, "bk_energy");
        }

        private void bk_s_laser_Click(object sender, EventArgs e)
        {
            spawn(bk_s_laser, "bk_s_laser");
        }

        private void bk_d_laser_Click(object sender, EventArgs e)
        {
            spawn(bk_d_laser, "bk_d_laser");
        }

        private void bk_way_s_laser_Click(object sender, EventArgs e)
        {
            spawn(bk_way_s_laser, "bk_way_s_laser");
        }
    }
}
