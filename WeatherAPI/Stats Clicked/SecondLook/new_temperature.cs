using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherAPI.Stats_Clicked.SecondLook
{
    public partial class new_temperature : Form
    {
        public new_temperature()
        {
            InitializeComponent();
        }

        private void new_temperature_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CONFIG_TEMPERATURE == "c")
            {
                label8.Text = $"The current temperature in {Properties.Settings.Default.city} is {Properties.Settings.Default.temp}°C";

                // 1-5 mph == 0,5 always -1 from first. always use exact digit on second.

                int temptoint = Int32.Parse(Properties.Settings.Default.temp);
                if (temptoint >= -40 && temptoint <= -18)
                {
                    siticoneGroupBox3.FillColor = Color.Indigo;

                    risk.BorderColor = Color.Indigo;
                    risk.CustomBorderColor = Color.Indigo;
                    risk.Text = "Critical Risk";
                    risk_desc.Text = "Critical risks have an exceptionally high likelihood of occurrence and the potential to cause widespread negative consequences. These risks require immediate attention, extensive planning, and extraordinary measures to mitigate their impact.";

                    label3.Text = "Freezing"; // Title of condition
                    label1.Text = "Extremely cold temperatures, below the freezing point of water. Risk of frostbite and hypothermia. Water freezes rapidly. Heavy winter clothing and insulation are necessary.";
                }
                if (temptoint >= -17 && temptoint <= 0)
                {
                    siticoneGroupBox3.FillColor = Color.DarkOrange;

                    risk.BorderColor = Color.DarkOrange;
                    risk.CustomBorderColor = Color.DarkOrange;
                    risk.Text = "Elevated Risk";
                    risk_desc.Text = "Elevated risks have a significant likelihood of occurrence and the potential to cause moderate negative consequences. These risks demand increased attention, proactive planning, and effective mitigation strategies.";

                    label3.Text = "Cold"; // Title of condition
                    label1.Text = "Cold temperatures, around or slightly below the freezing point of water. Winter conditions. Light snowfall possible. Layered clothing and protection against frostbite are recommended.";
                }
                if (temptoint >= 1 && temptoint <= 15)
                {
                    siticoneGroupBox3.FillColor = Color.Green;

                    risk.BorderColor = Color.Green;
                    risk.CustomBorderColor = Color.Green;
                    risk.Text = "Negligible Risk";
                    risk_desc.Text = "Negligible risks have an extremely low likelihood of occurrence and pose minimal potential harm or adverse consequences. These risks are unlikely to have a noticeable impact and do not require significant attention or mitigation efforts.";

                    label3.Text = "Cool"; // Title of condition
                    label1.Text = "Moderately cool temperatures, typically associated with early spring or fall. Mildly chilly, but comfortable with appropriate clothing. Suitable for outdoor activities and light jackets or sweaters.";
                }
                if (temptoint >= 16 && temptoint <= 24)
                {
                    siticoneGroupBox3.FillColor = Color.SeaGreen;

                    risk.BorderColor = Color.SeaGreen;
                    risk.CustomBorderColor = Color.SeaGreen;
                    risk.Text = "Low Risk";
                    risk_desc.Text = "Low-risk events or situations have a low likelihood of occurrence and may result in minor and easily manageable negative consequences. These risks require basic attention and standard mitigation measures.";

                    label3.Text = "Mild"; // Title of condition
                    label1.Text = "Pleasant and moderate temperatures. Comfortable for most people. Ideal for outdoor activities without excessive heat or cold. Light clothing is sufficient.";
                }
                if (temptoint >= 24 && temptoint <= 32)
                {
                    siticoneGroupBox3.FillColor = Color.Goldenrod;

                    risk.BorderColor = Color.Goldenrod;
                    risk.CustomBorderColor = Color.Goldenrod;
                    risk.Text = "Moderate Risk";
                    risk_desc.Text = "Moderate-risk events or situations have a reasonable likelihood of occurrence and can result in noticeable but manageable negative consequences. These risks require attention, planning, and mitigation measures to reduce their impact.";

                    label3.Text = "Warm"; // Title of condition
                    label1.Text = "Noticeably warm temperatures. Warm and potentially humid conditions. Light clothing, sunscreen, and hydration are recommended for outdoor activities.";
                }
                if (temptoint >= 33 && temptoint <= 40)
                {
                    siticoneGroupBox3.FillColor = Color.Red;

                    risk.BorderColor = Color.Red;
                    risk.CustomBorderColor = Color.Red;
                    risk.Text = "High Risk";
                    risk_desc.Text = "High-risk events or situations have a substantial likelihood of occurrence and the potential to cause significant negative consequences. These risks require careful attention, thorough planning, and proactive mitigation strategies.";

                    label3.Text = "Hot"; // Title of condition
                    label1.Text = "High temperatures, particularly during summer months. Intense heat and potential heat-related illnesses. Protective measures such as hats, shade, and frequent hydration are crucial.";
                }
                if (temptoint >= 41 && temptoint <= 48)
                {
                    siticoneGroupBox3.FillColor = Color.DarkRed;

                    risk.BorderColor = Color.DarkRed;
                    risk.CustomBorderColor = Color.DarkRed;
                    risk.Text = "Very High Risk";
                    risk_desc.Text = "Very high-risk events or situations have a high likelihood of occurrence and the potential to cause severe negative consequences. These risks demand urgent attention, comprehensive planning, and robust mitigation efforts.";

                    label3.Text = "Very Hot"; // Title of condition
                    label1.Text = "Extremely high temperatures, especially in arid regions. Dangerously hot conditions. Heatstroke and heat exhaustion are possible. Limited outdoor activities and strict precautions are advised.";
                }
                if (temptoint > 48)
                {
                    siticoneGroupBox3.FillColor = Color.Indigo;

                    risk.BorderColor = Color.Indigo;
                    risk.CustomBorderColor = Color.Indigo;
                    risk.Text = "Critical Risk";
                    risk_desc.Text = "Critical risks have an exceptionally high likelihood of occurrence and the potential to cause widespread negative consequences. These risks require immediate attention, extensive planning, and extraordinary measures to mitigate their impact.";

                    label3.Text = "Extreme Heat"; // Title of condition
                    label1.Text = "Unbearably high temperatures, often associated with heatwaves. Life-threatening conditions. Extreme risk of heat-related illnesses. Mandatory precautions, such as staying indoors and using cooling systems, are necessary.";
                }
            }
            else
            {
                label8.Text = $"The current temperature in {Properties.Settings.Default.city} is {Properties.Settings.Default.temp}°F";

                // 1-5 mph == 0,5 always -1 from first. always use exact digit on second.

                int temptoint = Int32.Parse(Properties.Settings.Default.temp);
                if (temptoint >= -40 && temptoint <= -0)
                {
                    siticoneGroupBox3.FillColor = Color.FromArgb(0, 12, 207);

                    siticoneGroupBox3.FillColor = Color.Indigo;

                    risk.BorderColor = Color.Indigo;
                    risk.Text = "Critical Risk";
                    risk_desc.Text = "Critical risks have an exceptionally high likelihood of occurrence and the potential to cause widespread negative consequences. These risks require immediate attention, extensive planning, and extraordinary measures to mitigate their impact.";

                    label3.Text = "Freezing"; // Title of condition
                    label1.Text = "Extremely cold temperatures, below the freezing point of water. Risk of frostbite and hypothermia. Water freezes rapidly. Heavy winter clothing and insulation are necessary.";
                }
                if (temptoint >= 1 && temptoint <= 32)
                {
                    siticoneGroupBox3.FillColor = Color.DarkOrange;

                    risk.BorderColor = Color.DarkOrange;
                    risk.Text = "Elevated Risk";
                    risk_desc.Text = "Elevated risks have a significant likelihood of occurrence and the potential to cause moderate negative consequences. These risks demand increased attention, proactive planning, and effective mitigation strategies.";

                    label3.Text = "Cold"; // Title of condition
                    label1.Text = "Cold temperatures, around or slightly below the freezing point of water. Winter conditions. Light snowfall possible. Layered clothing and protection against frostbite are recommended.";
                }
                if (temptoint >= 33 && temptoint <= 59)
                {
                    siticoneGroupBox3.FillColor = Color.Green;

                    risk.BorderColor = Color.Green;
                    risk.Text = "Negligible Risk";
                    risk_desc.Text = "Negligible risks have an extremely low likelihood of occurrence and pose minimal potential harm or adverse consequences. These risks are unlikely to have a noticeable impact and do not require significant attention or mitigation efforts.";

                    label3.Text = "Cool"; // Title of condition
                    label1.Text = "Moderately cool temperatures, typically associated with early spring or fall. Mildly chilly, but comfortable with appropriate clothing. Suitable for outdoor activities and light jackets or sweaters.";
                }
                if (temptoint >= 60 && temptoint <= 75)
                {
                    siticoneGroupBox3.FillColor = Color.SeaGreen;

                    risk.BorderColor = Color.SeaGreen;
                    risk.Text = "Low Risk";
                    risk_desc.Text = "Low-risk events or situations have a low likelihood of occurrence and may result in minor and easily manageable negative consequences. These risks require basic attention and standard mitigation measures.";

                    label3.Text = "Mild"; // Title of condition
                    label1.Text = "Pleasant and moderate temperatures. Comfortable for most people. Ideal for outdoor activities without excessive heat or cold. Light clothing is sufficient.";
                }
                if (temptoint >= 76 && temptoint <= 89)
                {
                    siticoneGroupBox3.FillColor = Color.Goldenrod;

                    risk.BorderColor = Color.Goldenrod;
                    risk.Text = "Moderate Risk";
                    risk_desc.Text = "Moderate-risk events or situations have a reasonable likelihood of occurrence and can result in noticeable but manageable negative consequences. These risks require attention, planning, and mitigation measures to reduce their impact.";

                    label3.Text = "Warm"; // Title of condition
                    label1.Text = "Noticeably warm temperatures. Warm and potentially humid conditions. Light clothing, sunscreen, and hydration are recommended for outdoor activities.";
                }
                if (temptoint >= 90 && temptoint <= 104)
                {
                    siticoneGroupBox3.FillColor = Color.Red;

                    risk.BorderColor = Color.Red;
                    risk.Text = "High Risk";
                    risk_desc.Text = "High-risk events or situations have a substantial likelihood of occurrence and the potential to cause significant negative consequences. These risks require careful attention, thorough planning, and proactive mitigation strategies.";

                    label3.Text = "Hot"; // Title of condition
                    label1.Text = "High temperatures, particularly during summer months. Intense heat and potential heat-related illnesses. Protective measures such as hats, shade, and frequent hydration are crucial.";
                }
                if (temptoint >= 105 && temptoint <= 119)
                {
                    siticoneGroupBox3.FillColor = Color.DarkRed;

                    risk.BorderColor = Color.DarkRed;
                    risk.Text = "Very High Risk";
                    risk_desc.Text = "Very high-risk events or situations have a high likelihood of occurrence and the potential to cause severe negative consequences. These risks demand urgent attention, comprehensive planning, and robust mitigation efforts.";

                    label3.Text = "Very Hot"; // Title of condition
                    label1.Text = "Extremely high temperatures, especially in arid regions. Dangerously hot conditions. Heatstroke and heat exhaustion are possible. Limited outdoor activities and strict precautions are advised.";
                }
                if (temptoint > 120)
                {
                    siticoneGroupBox3.FillColor = Color.Indigo;

                    risk.BorderColor = Color.Indigo;
                    risk.Text = "Critical Risk";
                    risk_desc.Text = "Critical risks have an exceptionally high likelihood of occurrence and the potential to cause widespread negative consequences. These risks require immediate attention, extensive planning, and extraordinary measures to mitigate their impact.";

                    label3.Text = "Extreme Heat"; // Title of condition
                    label1.Text = "Unbearably high temperatures, often associated with heatwaves. Life-threatening conditions. Extreme risk of heat-related illnesses. Mandatory precautions, such as staying indoors and using cooling systems, are necessary.";
                }
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
