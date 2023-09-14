using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherAPI.Stats_Clicked.SecondLook
{
    public partial class new_Windspeed : Form
    {
        public new_Windspeed()
        {
            InitializeComponent();
        }

        private void new_Windspeed_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CONFIG_SPEED == "mph")
            {
                label8.Text = $"The current wind speed in {Properties.Settings.Default.city} is {Properties.Settings.Default.windspeed} mph";
            }
            else
            {
                label8.Text = $"The current wind speed in {Properties.Settings.Default.city} is {Properties.Settings.Default.windspeed} kph";
            }

            // 1-5 mph == 0,5 always -1 from first. always use exact digit on second.

            int windstoint = Int32.Parse(Properties.Settings.Default.windspeedmph);
            if (windstoint == 0)
            {
                siticoneGroupBox3.FillColor = Color.Green;

                risk.BorderColor = Color.Green;
                risk.CustomBorderColor = Color.SeaGreen;
                risk.Text = "Negligible Risk";
                risk_desc.Text = "Negligible risks have an extremely low likelihood of occurrence and pose minimal potential harm or adverse consequences. These risks are unlikely to have a noticeable impact and do not require significant attention or mitigation efforts.";

                label3.Text = "Calm"; // Title of condition
                label1.Text = "Virtually no perceivable wind movement. Leaves and vegetation remain still. Smoke rises vertically. Ideal for delicate activities such as reading or painting outdoors.";
            }
            if (windstoint > 0 && windstoint <= 5)
            {
                siticoneGroupBox3.FillColor = Color.Green;

                risk.BorderColor = Color.Green;
                risk.CustomBorderColor = Color.Green;
                risk.Text = "Negligible Risk";
                risk_desc.Text = "Negligible risks have an extremely low likelihood of occurrence and pose minimal potential harm or adverse consequences. These risks are unlikely to have a noticeable impact and do not require significant attention or mitigation efforts.";

                label3.Text = "Light Breeze"; // Title of condition
                label1.Text = "Gentle and barely noticeable wind movement. Leaves rustle softly. Wind direction can be determined by the direction of smoke drift. Suitable for most outdoor activities.";
            }
            if (windstoint > 5 && windstoint <= 15)
            {
                siticoneGroupBox3.FillColor = Color.Green;

                risk.BorderColor = Color.Green;
                risk.CustomBorderColor = Color.Green;
                risk.Text = "Negligible Risk";
                risk_desc.Text = "Negligible risks have an extremely low likelihood of occurrence and pose minimal potential harm or adverse consequences. These risks are unlikely to have a noticeable impact and do not require significant attention or mitigation efforts.";

                label3.Text = "Moderate Breeze"; // Title of condition
                label1.Text = "Noticeable wind movement with some resistance when walking against it. Leaves and small branches sway. Wind can be felt on the face. Comfortable for outdoor recreational activities like flying kites or sailing.";
            }
            if (windstoint > 15 && windstoint <= 25)
            {
                siticoneGroupBox3.FillColor = Color.SeaGreen;

                risk.BorderColor = Color.SeaGreen;
                risk.CustomBorderColor = Color.SeaGreen;
                risk.Text = "Low Risk";
                risk_desc.Text = "Low-risk events or situations have a low likelihood of occurrence and may result in minor and easily manageable negative consequences. These risks require basic attention and standard mitigation measures.";

                label3.Text = "Fresh Breeze"; // Title of condition
                label1.Text = "Moderate wind that can be felt on the skin with increased resistance when walking against it. Trees sway noticeably. Waves become larger on bodies of water. Challenging for activities requiring precise control, like outdoor photography.";
            }
            if (windstoint > 25 && windstoint <= 39)
            {
                siticoneGroupBox3.FillColor = Color.Goldenrod;

                risk.BorderColor = Color.Goldenrod;
                risk.CustomBorderColor = Color.Goldenrod;
                risk.Text = "Moderate Risk";
                risk_desc.Text = "Moderate-risk events or situations have a reasonable likelihood of occurrence and can result in noticeable but manageable negative consequences. These risks require attention, planning, and mitigation measures to reduce their impact.";

                label3.Text = "Strong Breeze"; // Title of condition
                label1.Text = "Brisk wind that creates significant resistance when walking against it. Larger branches sway. Unsecured objects may be blown around. Outdoor activities like cycling or jogging become more demanding.";
            }
            if (windstoint > 39 && windstoint <= 54)
            {
                siticoneGroupBox3.FillColor = Color.DarkOrange;

                risk.BorderColor = Color.DarkOrange;
                risk.CustomBorderColor = Color.DarkOrange;
                risk.Text = "Elevated Risk";
                risk_desc.Text = "Elevated risks have a significant likelihood of occurrence and the potential to cause moderate negative consequences. These risks demand increased attention, proactive planning, and effective mitigation strategies.";

                label3.Text = "Moderate Gale"; // Title of condition
                label1.Text = "Strong wind capable of moving small branches and causing difficulty when walking. Loose objects are blown around. Traveling against the wind becomes challenging. Outdoor events and sports may need to be postponed or adjusted.";
            }
            if (windstoint > 54 && windstoint <= 72)
            {
                siticoneGroupBox3.FillColor = Color.Red;

                risk.BorderColor = Color.Red;
                risk.CustomBorderColor = Color.Red;
                risk.Text = "High Risk";
                risk_desc.Text = "High-risk events or situations have a substantial likelihood of occurrence and the potential to cause significant negative consequences. These risks require careful attention, thorough planning, and proactive mitigation strategies.";

                label3.Text = "Fresh Gale"; // Title of condition
                label1.Text = "Very strong wind that can break twigs and cause walking to be extremely challenging. Trees sway vigorously. Driving may become hazardous. Outdoor activities are significantly impacted, and caution should be exercised.";
            }
            if (windstoint > 72 && windstoint <= 95)
            {
                siticoneGroupBox3.FillColor = Color.Red;

                risk.BorderColor = Color.Red;
                risk.CustomBorderColor = Color.Red;
                risk.Text = "High Risk";
                risk_desc.Text = "High-risk events or situations have a substantial likelihood of occurrence and the potential to cause significant negative consequences. These risks require careful attention, thorough planning, and proactive mitigation strategies.";

                label3.Text = "Strong Gale"; // Title of condition
                label1.Text = "Powerful wind that can cause considerable damage and pose dangers to property and personal safety. Trees are uprooted or damaged. Structural damage is possible. Outdoor activities are highly discouraged, and shelter should be sought.";
            }
            if (windstoint > 95 && windstoint <= 110)
            {
                siticoneGroupBox3.FillColor = Color.DarkRed;

                risk.BorderColor = Color.DarkRed;
                risk.CustomBorderColor = Color.DarkRed;
                risk.Text = "Very High Risk";
                risk_desc.Text = "Very high-risk events or situations have a high likelihood of occurrence and the potential to cause severe negative consequences. These risks demand urgent attention, comprehensive planning, and robust mitigation efforts.";

                label3.Text = "Storm"; // Title of condition
                label1.Text = "Violent windstorm with the potential for widespread damage and significant risks to life and property. Structural damage to buildings. Trees and large objects are uprooted or displaced. Evacuation is often recommended.";
            }
            if (windstoint > 110)
            {
                siticoneGroupBox3.FillColor = Color.Indigo;

                risk.BorderColor = Color.Indigo;
                risk.CustomBorderColor = Color.Indigo;
                risk.Text = "Critical Risk";
                risk_desc.Text = "Critical risks have an exceptionally high likelihood of occurrence and the potential to cause widespread negative consequences. These risks require immediate attention, extensive planning, and extraordinary measures to mitigate their impact.";

                label3.Text = "Hurricane/Extreme Wind"; // Title of condition
                label1.Text = "Catastrophic wind strength associated with hurricanes, typhoons, or tornadoes. Severe destruction to buildings and infrastructure. Life-threatening conditions prevail. Immediate evacuation and seeking shelter are vital.";
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
    }
}
