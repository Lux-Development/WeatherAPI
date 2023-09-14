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
    public partial class cloud_stength : Form
    {
        public cloud_stength()
        {
            InitializeComponent();
        }

        private void cloud_stength_Load(object sender, EventArgs e)
        {

            label8.Text = $"The current cloud strength in {Properties.Settings.Default.city} is {Properties.Settings.Default.clouds}%";

            int visibiletoint = Int32.Parse(Properties.Settings.Default.clouds);
            if (visibiletoint >= 70)
            { // SeaGreen
                siticoneGroupBox3.FillColor = Color.SeaGreen;

                risk.BorderColor = Color.SeaGreen;
                risk.CustomBorderColor = Color.SeaGreen;
                risk.Text = "Low Risk";
                risk_desc.Text = "Low-risk events or situations have a low likelihood of occurrence and may result in minor and easily manageable negative consequences. These risks require basic attention and standard mitigation measures.";

                label1.Text = "However the cloud strength being high, there is no actual risk factor! Just make sure to take a umbrella as this increases the chance of rain! This may also cause some foggy conditions, for a more detailed risk factor on your vision please refer to the visibility page.";
            }
            else
            {
                siticoneGroupBox3.FillColor = Color.Green;

                risk.BorderColor = Color.Green;
                risk.CustomBorderColor = Color.Green;
                risk.Text = "Negligible Risk";
                risk_desc.Text = "Negligible risks have an extremely low likelihood of occurrence and pose minimal potential harm or adverse consequences. These risks are unlikely to have a noticeable impact and do not require significant attention or mitigation efforts.";

                label1.Text = "The sky is clear and there is a very low likelihood of rain or restricted vision in your location, for a more detailed risk factor on your vision please refer to the visibility page.";
            }
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
