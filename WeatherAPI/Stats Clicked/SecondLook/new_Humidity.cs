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
    public partial class new_Humidity : Form
    {
        public new_Humidity()
        {
            InitializeComponent();
        }

        private void new_Humidity_Load(object sender, EventArgs e)
        {
            label8.Text = $"The current humidity in {Properties.Settings.Default.city} is {Properties.Settings.Default.humidity}%";

            int humidtoint = Int32.Parse(Properties.Settings.Default.humidity);
            if (humidtoint < 20)
            { // SeaGreen
                siticoneGroupBox3.FillColor = Color.Red;

                risk.BorderColor = Color.Red;
                risk.CustomBorderColor = Color.Red;
                risk.Text = "High Risk";
                risk_desc.Text = "High-risk events or situations have a substantial likelihood of occurrence and the potential to cause significant negative consequences. These risks require careful attention, thorough planning, and proactive mitigation strategies.";

                label1.Text = "Extremely dry conditions. Skin may feel dry and itchy. Plants may wilt and be prone to damage. Increased risk of dehydration.";
            }
            if (humidtoint > 20 && humidtoint <= 40)
            { // Goldenrod
                siticoneGroupBox3.FillColor = Color.Goldenrod;

                risk.BorderColor = Color.Goldenrod;
                risk.CustomBorderColor = Color.Goldenrod;
                risk.Text = "Moderate Risk";
                risk_desc.Text = "Moderate-risk events or situations have a reasonable likelihood of occurrence and can result in noticeable but manageable negative consequences. These risks require attention, planning, and mitigation measures to reduce their impact.";

                label1.Text = "Dry conditions. Skin may feel slightly dry. Plants may require additional watering. Increased risk of static electricity.";
            }
            if (humidtoint > 40 && humidtoint <= 60)
            { // SeaGreen
                siticoneGroupBox3.FillColor = Color.SeaGreen;

                risk.BorderColor = Color.SeaGreen;
                risk.CustomBorderColor = Color.SeaGreen;
                risk.Text = "Low Risk";
                risk_desc.Text = "Low-risk events or situations have a low likelihood of occurrence and may result in minor and easily manageable negative consequences. These risks require basic attention and standard mitigation measures.";

                label1.Text = "Comfortable and balanced conditions. Optimal humidity range for most people. Skin feels moisturized. Plants grow well. Ideal conditions for outdoor activities.";
            }
            if (humidtoint > 60 && humidtoint <= 80)
            { // Goldenrod
                siticoneGroupBox3.FillColor = Color.Goldenrod;

                risk.BorderColor = Color.Goldenrod;
                risk.CustomBorderColor = Color.Goldenrod;
                risk.Text = "Moderate Risk";
                risk_desc.Text = "Moderate-risk events or situations have a reasonable likelihood of occurrence and can result in noticeable but manageable negative consequences. These risks require attention, planning, and mitigation measures to reduce their impact.";

                label1.Text = "Moist and humid conditions. Skin feels sticky and sweaty. Increased risk of mold and mildew growth. Outdoor activities may feel more tiring.";
            }
            if (humidtoint > 80 && humidtoint <= 100)
            { // DarkRed
                siticoneGroupBox3.FillColor = Color.Red;

                risk.BorderColor = Color.Red;
                risk.CustomBorderColor = Color.Red;
                risk.Text = "High Risk";
                risk_desc.Text = "High-risk events or situations have a substantial likelihood of occurrence and the potential to cause significant negative consequences. These risks require careful attention, thorough planning, and proactive mitigation strategies.";

                label1.Text = "Extremely moist and oppressive conditions. Skin feels damp and sticky. Difficulties in cooling down. Increased risk of respiratory discomfort. Increased likelihood of thunderstorms or heavy rainfall.";
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
