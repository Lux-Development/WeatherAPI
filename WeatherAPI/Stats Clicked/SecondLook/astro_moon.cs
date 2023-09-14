using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherAPI.Stats_Clicked.SecondLook
{
    public partial class astro_moon : Form
    {
        public astro_moon()
        {
            InitializeComponent();
        }

        private void astro_moon_Load(object sender, EventArgs e)
        {
            label3.Text = Properties.Settings.Default.moonrise;
            label4.Text = Properties.Settings.Default.moonset;
            label6.Text = Properties.Settings.Default.moonphase;
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
