using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WeatherAPI.Stats_Clicked.SecondLook
{
    public partial class astro_sun : Form
    {
        public astro_sun()
        {
            InitializeComponent();
        }

        private void astro_sun_Load(object sender, EventArgs e)
        {
            label3.Text = Properties.Settings.Default.sunrise;
            label4.Text = Properties.Settings.Default.sunset;
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
