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


        private void bk_casual_Click(object sender, EventArgs e)
        {
            spawn(bk_casual, "bk_casual");                
        }

        private void bk_glass_Click(object sender, EventArgs e)
        {
            spawn(bk_glass, "bk_glass");
        }

        
    }
}
