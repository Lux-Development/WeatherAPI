using Siticone.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherAPI.Stats_Clicked.SecondLook
{
    public partial class new_Visible : Form
    {
        public new_Visible()
        {
            InitializeComponent();
        }

        private void new_Visible_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CONFIG_DISTANCE == "m")
            {
                label8.Text = $"The current visibility in {Properties.Settings.Default.city} is {Properties.Settings.Default.visibility} miles";
            }
            else
            {
                label8.Text = $"The current visibility in {Properties.Settings.Default.city} is {Properties.Settings.Default.visibility} km";
            }

            int visibiletoint = Int32.Parse(Properties.Settings.Default.visibilitymiles);
            if (visibiletoint >= 11)
            { // MediumSpringGreen
                siticoneGroupBox3.FillColor = Color.Green;

                risk.BorderColor = Color.Green;
                risk.CustomBorderColor = Color.Green;
                risk.Text = "Negligible Risk";
                risk_desc.Text = "Negligible risks have an extremely low likelihood of occurrence and pose minimal potential harm or adverse consequences. These risks are unlikely to have a noticeable impact and do not require significant attention or mitigation efforts.";

                label3.Text = "Excellent Visibility"; // Negligible Risk
                label1.Text = "Exceptional clarity with minimal atmospheric interference. Distant objects are clearly visible. Ideal for outdoor activities, driving, and scenic views.";
            }
            if (visibiletoint == 7 || visibiletoint == 8 || visibiletoint == 9 || visibiletoint == 10)
            { // SeaGreen
                siticoneGroupBox3.FillColor = Color.SeaGreen;

                risk.BorderColor = Color.SeaGreen;
                risk.CustomBorderColor = Color.SeaGreen;
                risk.Text = "Low Risk";
                risk_desc.Text = "Low-risk events or situations have a low likelihood of occurrence and may result in minor and easily manageable negative consequences. These risks require basic attention and standard mitigation measures.";

                label3.Text = "Good Visibility"; // Low  Risk
                label1.Text = "Clear visibility with slight haziness or minor atmospheric particles. Objects are easily discernible. Suitable for most outdoor activities and everyday visibility.";
            }
            if (visibiletoint == 4 || visibiletoint == 5 || visibiletoint == 6)
            { // Goldenrod
                siticoneGroupBox3.FillColor = Color.Goldenrod;

                risk.BorderColor = Color.Goldenrod;
                risk.CustomBorderColor = Color.Goldenrod;
                risk.Text = "Moderate Risk";
                risk_desc.Text = "Moderate-risk events or situations have a reasonable likelihood of occurrence and can result in noticeable but manageable negative consequences. These risks require attention, planning, and mitigation measures to reduce their impact.";

                label3.Text = "Fair Visibility"; // Moderate Risk
                label1.Text = "Moderate visibility with noticeable haziness or moderate atmospheric particles. Some distant objects may appear less distinct. Caution required for outdoor activities like navigation or driving.";
            }
            if (visibiletoint == 2 || visibiletoint == 3)
            { // DarkOrange
                siticoneGroupBox3.FillColor = Color.DarkOrange;

                risk.BorderColor = Color.DarkOrange;
                risk.CustomBorderColor = Color.DarkOrange;
                risk.Text = "Elevated Risk";
                risk_desc.Text = "Elevated risks have a significant likelihood of occurrence and the potential to cause moderate negative consequences. These risks demand increased attention, proactive planning, and effective mitigation strategies.";

                label3.Text = "Limited Visibility"; // Elevated Risk
                label1.Text = "Restricted visibility with significant haziness or moderate to heavy atmospheric particles. Distant objects are obscured, reducing clarity. Outdoor activities may require increased caution and slower movement.";
            }

            if (visibiletoint == 1)
            { // DarkRed
                siticoneGroupBox3.FillColor = Color.Red;

                risk.BorderColor = Color.Red;
                risk.CustomBorderColor = Color.Red;
                risk.Text = "High Risk";
                risk_desc.Text = "High-risk events or situations have a substantial likelihood of occurrence and the potential to cause significant negative consequences. These risks require careful attention, thorough planning, and proactive mitigation strategies.";

                label3.Text = "Poor Visibility"; // High Risk
                label1.Text = "Very limited visibility with dense haziness or heavy atmospheric particles. Nearby objects may be difficult to discern. Outdoor activities should be approached with extreme caution and reduced speed.";
            }
            if (visibiletoint == 0)
            { // Indigo
                siticoneGroupBox3.FillColor = Color.Indigo;

                risk.BorderColor = Color.Indigo;
                risk.CustomBorderColor = Color.Indigo;
                risk.Text = "Critical Risk";
                risk_desc.Text = "Critical risks have an exceptionally high likelihood of occurrence and the potential to cause widespread negative consequences. These risks require immediate attention, extensive planning, and extraordinary measures to mitigate their impact.";

                label3.Text = "Extremely Poor Visibility"; // Critical Risk
                label1.Text = "Nearly zero visibility due to dense fog, heavy smoke, or intense precipitation. Objects are barely visible, if at all. Outdoor activities are highly discouraged due to severe safety concerns.";
            }
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CONFIG_SE == true)
            {
                try
                {
                    SoundPlayer soundPlayer = new SoundPlayer("C:\\Windows\\Media\\Windows Navigation Start.wav");
                    soundPlayer.Play();
                }
                catch (Exception)
                {

                }
            }

            Application.Restart();
        }

        private void risk_Click(object sender, EventArgs e)
        {

        }
    }
}
