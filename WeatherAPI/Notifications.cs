using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherAPI
{
    public partial class Notifications : Form
    {
        public Notifications()
        {
            InitializeComponent();
        }

        public void weather()
        {
            string pic = Properties.Settings.Default.weatherpng;
            bool isday = Properties.Settings.Default.isday;

            if (isday == false)
            {
                if (pic == "Thunderstorm")
                {
                    weather_pic.Image = Properties.Resources.Thunderstorm;
                    weather_text.Text = "It's a stormy night in your current location, best to stay inside.";
                }
                if (pic == "drizzle")
                {
                    weather_pic.Image = Properties.Resources.drizzle;
                    weather_text.Text = "It's a little bit of rain in your current location, wear some warm clothes.";
                }
                if (pic == "rain_night")
                {
                    weather_pic.Image = Properties.Resources.rain_night;
                    weather_text.Text = "It's a rainy night in your current location, wear some warm clothes, and make a nice warm drink.";
                }
                if (pic == "snow")
                {
                    weather_pic.Image = Properties.Resources.snow;
                    weather_text.Text = "It's a snowy night in your current location, go and build a snowman!";
                }
                if (pic == "mist")
                {
                    weather_pic.Image = Properties.Resources.mist;
                    weather_text.Text = "It's a mist night in your current location, your vision may be restricted.";
                }
                if (pic == "haze")
                {
                    weather_pic.Image = Properties.Resources.haze;
                    weather_text.Text = "It's a haze night in your current location, your vision may be restricted.";
                }
                if (pic == "fog")
                {
                    weather_pic.Image = Properties.Resources.fog;
                    weather_text.Text = "It's a foggy night in your current location, your vision may be restricted.";
                }
                if (pic == "clear_night")
                {
                    weather_pic.Image = Properties.Resources.clear_night;
                    weather_text.Text = "It's a nice and clear night in your current location, may be uncomfortable when sleeping.";
                }
                if (pic == "clouds")
                {
                    weather_pic.Image = Properties.Resources.clouds;
                    weather_text.Text = "It's a cloudy night in your current location, perfect for sleeping conditions.";
                }
            }
            else
            {
                if (pic == "Thunderstorm")
                {
                    weather_pic.Image = Properties.Resources.Thunderstorm;
                    weather_text.Text = "It's a stormy day in your current location, best to stay inside.";
                }
                if (pic == "drizzle")
                {
                    weather_pic.Image = Properties.Resources.drizzle;
                    weather_text.Text = "It's a little bit of rain in your current location, take a umbrella outside.";
                }
                if (pic == "rain")
                {
                    weather_pic.Image = Properties.Resources.rain;
                    weather_text.Text = "It's a rainy day in your current location, wear some nice warm clothes.";
                }
                if (pic == "snow")
                {
                    weather_pic.Image = Properties.Resources.snow;
                    weather_text.Text = "It's a snowy day in your current location, go outside and have throw some snowballs!";
                }
                if (pic == "mist")
                {
                    weather_pic.Image = Properties.Resources.mist;
                    weather_text.Text = "It's a mist day in your current location, your vision may be restricted.";
                }
                if (pic == "haze")
                {
                    weather_pic.Image = Properties.Resources.haze;
                    weather_text.Text = "It's a haze day in your current location, your vision may be restricted.";
                }
                if (pic == "fog")
                {
                    weather_pic.Image = Properties.Resources.fog;
                    weather_text.Text = "It's a foggy day in your current location, your vision may be restricted.";
                }
                if (pic == "Clear")
                {
                    weather_pic.Image = Properties.Resources.Clear;
                    weather_text.Text = "It's a sunny day in your current location, consider UV protection.";
                }
                if (pic == "clouds") 
                {
                    weather_pic.Image = Properties.Resources.clouds;
                    weather_text.Text = "It's a cloudy day in your current location, your vision may be restricted.";
                }
                if (pic == "Partially_cloudy")
                {
                    weather_pic.Image = Properties.Resources.Partially_cloudy;
                    weather_text.Text = "It's a partially cloudy day in your current location, perfect for outdoor activities.";
                }
            }
        }

        public void humidity()
        {
            int humidtoint = Int32.Parse(Properties.Settings.Default.humidity);
            if (humidtoint < 20)
            { // SeaGreen
                humid_msg.Text = "It's a extremely humid condition in your current location, try to stay cool and hydrated.";
            }
            if (humidtoint > 20 && humidtoint <= 40)
            { // Goldenrod
                humid_msg.Text = "It's a dry humid condition in your current location, skin may feel dry.";
            }
            if (humidtoint > 40 && humidtoint <= 60)
            { // SeaGreen
                humid_msg.Text = "It's a optimal humid condition in your current location, ideal conditions for outdoor activities.";
            }
            if (humidtoint > 60 && humidtoint <= 80)
            { // Goldenrod
                humid_msg.Text = "It's a humid condition in your current location, increased risk of mold and mildew growth.";
            }
            if (humidtoint > 80 && humidtoint <= 100)
            { // DarkRed
                humid_msg.Text = "A oppressive humid condition in your current location, skin may feel damp and sticky.";
            }
        }

        public void visibility()
        {
            int visibiletoint = Int32.Parse(Properties.Settings.Default.visibilitymiles);
            if (visibiletoint >= 11)
            { // MediumSpringGreen
                visible_msg.Text = "An amazing visibility scale in your current location, distant objects are clearly visible.";
            }
            if (visibiletoint == 7 || visibiletoint == 8 || visibiletoint == 9 || visibiletoint == 10)
            { // SeaGreen
                visible_msg.Text = "A clear visibility scale in your current location, objects are easily discernible.";
            }
            if (visibiletoint == 4 || visibiletoint == 5 || visibiletoint == 6)
            { // Goldenrod
                visible_msg.Text = "A moderate visibility scale in your current location, caution required for outdoor activities.";
            }
            if (visibiletoint == 2 || visibiletoint == 3)
            { // DarkOrange
                visible_msg.Text = "A restricted visibility scale in your current location, distant objects are obscured.";
            }

            if (visibiletoint == 1)
            { // DarkRed
                visible_msg.Text = "A very limited visibility scale in your current location, driving is not encouraged.";
            }
            if (visibiletoint == 0)
            { // Indigo
                visible_msg.Text = "A zero visibility scale in your current location, objects are barely visible, increased caution.";
            }
        }

        public void windspeed()
        {

        }

        public void sunset_sunrise()
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Notifications_Load(object sender, EventArgs e)
        {
            weather();
            humidity();
            visibility();
        }
    }
}
