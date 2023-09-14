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
    public partial class new_UV : Form
    {
        public new_UV()
        {
            InitializeComponent();
        }

        private void UV_Load(object sender, EventArgs e)
        {
            label8.Text = $"The current UV in {Properties.Settings.Default.city} is {Properties.Settings.Default.uv}";

            int uvtoint = Int32.Parse(Properties.Settings.Default.uv);
            if (uvtoint == 0 || uvtoint == 1 || uvtoint == 2)
            { // SeaGreen
                siticoneGroupBox3.FillColor = Color.SeaGreen;

                risk.BorderColor = Color.SeaGreen;
                risk.CustomBorderColor = Color.SeaGreen;
                risk.Text = "Low Risk";
                risk_desc.Text = "Low-risk events or situations have a low likelihood of occurrence and may result in minor and easily manageable negative consequences. These risks require basic attention and standard mitigation measures.";

                label1.Text = "UV Index 0-2 means minimal danger from the sun’s UV rays for the average person. Most people can stay in the sun for up to one hour during peak sun (10 am to 4 pm) without burning. However, people with very sensitive skin and infants should always be protected from prolonged sun exposure.";
            }
            if (uvtoint == 3 || uvtoint == 4 || uvtoint == 5)
            { // Goldenrod
                siticoneGroupBox3.FillColor = Color.Goldenrod;

                risk.BorderColor = Color.Goldenrod;
                risk.CustomBorderColor = Color.Goldenrod;
                risk.Text = "Moderate Risk";
                risk_desc.Text = "Moderate-risk events or situations have a reasonable likelihood of occurrence and can result in noticeable but manageable negative consequences. These risks require attention, planning, and mitigation measures to reduce their impact.";

                label1.Text = "UV Index 3-5 means low risk of harm from unprotected sun exposure. Fair-skinned people, however, may burn in less than 20 minutes. Wearing a hat with a wide brim and sunglasses will protect your eyes. Always use a broad-spectrum sunscreen with an SPF of at least 30, and wear long-sleeved shirts when outdoors.";
            }
            if (uvtoint == 6 || uvtoint == 7)
            { // DarkOrange
                siticoneGroupBox3.FillColor = Color.DarkOrange;

                risk.BorderColor = Color.DarkOrange;
                risk.CustomBorderColor = Color.DarkOrange;
                risk.Text = "Elevated Risk";
                risk_desc.Text = "Elevated risks have a significant likelihood of occurrence and the potential to cause moderate negative consequences. These risks demand increased attention, proactive planning, and effective mitigation strategies.";

                label1.Text = "UV Index 6-7 means moderate risk of harm from unprotected sun exposure. Fair-skinned people, however, may burn in less than 20 minutes. Wearing a hat with a wide brim and sunglasses will protect your eyes. Always use a broad-spectrum sunscreen with an SPF of at least 30 and wear long-sleeved shirts when outdoors. Remember to protect sensitive areas like the nose and the rims of the ears. Sunscreen prevents sunburn and some of the sun’s damaging effects on the immune system. Use a lip balm or lip cream containing a sunscreen.";
            }
            if (uvtoint == 8 || uvtoint == 9 || uvtoint == 10)
            { // DarkRed
                siticoneGroupBox3.FillColor = Color.Red;

                risk.BorderColor = Color.Red;
                risk.CustomBorderColor = Color.Red;
                risk.Text = "High Risk";
                risk_desc.Text = "High-risk events or situations have a substantial likelihood of occurrence and the potential to cause significant negative consequences. These risks require careful attention, thorough planning, and proactive mitigation strategies.";

                label1.Text = "UV Index 8-10 means high risk of harm from unprotected sun exposure. Fair-skinned people may burn in less than 10 minutes. Minimize sun exposure during midday hours of 10 am to 4 pm. Protect yourself by liberally applying a broad-spectrum sunscreen of at least SPF 30. Wear protective clothing and sunglasses to protect the eyes. When outside, seek shade. Don’t forget that water, sand, pavement, and glass reflect UV rays even under a tree, near a building or beneath a shady umbrella. Wear long-sleeved shirts and trousers made from tightly-woven fabrics. UV rays can pass through the holes and spaces of loosely knit fabrics.";
            }
            if (uvtoint > 10)
            { // Indigo
                siticoneGroupBox3.FillColor = Color.Indigo;

                risk.BorderColor = Color.Indigo;
                risk.CustomBorderColor = Color.Indigo;
                risk.Text = "Critical Risk";
                risk_desc.Text = "Critical risks have an exceptionally high likelihood of occurrence and the potential to cause widespread negative consequences. These risks require immediate attention, extensive planning, and extraordinary measures to mitigate their impact.";

                label1.Text = "UV Index of 11+ means a very high risk of harm from unprotected sun exposure. Fair skinned people may burn in less than 5 minutes. Outdoor workers and vacationers who can receive very intense sun exposure are especially at risk. Minimize sun exposure during midday hours of 10 am to 4 pm. Apply broad-spectrum SPF 30+ sunscreen every 2 hours, more frequently if you are sweating or swimming. Avoid being in the sun as much as possible and wear sunglasses that block out 99-100% of all UV rays (UVA and UVB). Wear a hat with a wide brim which will block roughly 50% of UV radiation from reaching the eyes.";
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
