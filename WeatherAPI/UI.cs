using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpDX.Direct3D9;
using Siticone.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using WeatherAPI.Settings;
using WeatherAPI.Stats_Clicked;
using WeatherAPI.Stats_Clicked.SecondLook;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WeatherAPI
{
    public partial class UI : Form
    {
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public UI()
        {
            InitializeComponent();

            if (Properties.Settings.Default.locktotaskbar == true)
            {
                siticoneDragControl1.Dispose();
                this.StartPosition = FormStartPosition.Manual;

                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 15, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
                
            }

            if (Properties.Settings.Default.alwaysontop == true)
            {
                SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
            }
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public string GetIP()
        {
            string input = new WebClient().DownloadString("http://checkip.dyndns.org/");
            return new Regex("\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}").Matches(input)[0].ToString();
        }

        private void UI_Load(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            this.Hide();
            

            // API for current city: http://ip-api.com/json/ip
            // API for current IP: http://checkip.dyndns.org/
            // API for current weather: https://api.weatherapi.com/v1/current.xml?key=[REMOVEDFORSECURITY]&q=[CITY]&aqi=no

            // Get current IP address
            string IP = "";
            try
            {
                IP = GetIP();
            }
            catch { 
                Application.Restart();
            }

            // Get current city/state
            var js1 = new WebClient().DownloadString("http://ip-api.com/json/" + IP);
            var data1 = JObject.Parse(js1);

            var CITY = data1["city"];
            label1.Text = CITY.ToString();
            Properties.Settings.Default.city = CITY.ToString();
            Properties.Settings.Default.Save();

            Properties.Settings.Default.currentcity = CITY.ToString();
            Properties.Settings.Default.Save();

            string AppData = @"C:\ProgramData\WeatherApp\Data";

            if (!Directory.Exists(AppData))
            {
                Directory.CreateDirectory(AppData);
            }

            // Download XML API - Astro
            WebClient Client2 = new WebClient();
            Client2.DownloadFile($"https://api.weatherapi.com/v1/astronomy.xml?key=d38681c27517404199e183249232406&q={CITY}", $@"{AppData}\Results_Astro.xml");

            XmlDocument MyDoc2 = new XmlDocument(); MyDoc2.Load($@"{AppData}\Results_Astro.xml");

            // Information from astroAPI : [SUNRISE]
            XmlNode MyNode522 = MyDoc2.SelectSingleNode("root/astronomy/astro/sunrise");
            string sunrise = MyNode522.InnerText.ToString();
            Properties.Settings.Default.sunrise = sunrise.ToString();
            Properties.Settings.Default.Save();

            // Information from astroAPI : [SUNSET]
            XmlNode MyNode5232 = MyDoc2.SelectSingleNode("root/astronomy/astro/sunset");
            string sunset = MyNode5232.InnerText.ToString();
            Properties.Settings.Default.sunset = sunset.ToString();
            Properties.Settings.Default.Save();

            // Information from astroAPI : [MOONRISE]
            XmlNode MyNo2de5232 = MyDoc2.SelectSingleNode("root/astronomy/astro/moonrise");
            string moonrise = MyNo2de5232.InnerText.ToString();
            Properties.Settings.Default.moonrise = moonrise.ToString();
            Properties.Settings.Default.Save();

            // Information from astroAPI : [MOONSET]
            XmlNode MyNodes5232 = MyDoc2.SelectSingleNode("root/astronomy/astro/moonset");
            string moonset = MyNodes5232.InnerText.ToString();
            Properties.Settings.Default.moonset = moonset.ToString();
            Properties.Settings.Default.Save();

            // Information from astroAPI : [MOONPHASE]
            XmlNode MyNodesd5232 = MyDoc2.SelectSingleNode("root/astronomy/astro/moon_phase");
            string moonphase = MyNodesd5232.InnerText.ToString();
            Properties.Settings.Default.moonphase = moonphase.ToString();
            Properties.Settings.Default.Save();

            // Information from astroAPI : [ISMOONUP?]
            XmlNode MyNodesdd5232 = MyDoc2.SelectSingleNode("root/astronomy/astro/is_moon_up");
            string moonvisible = MyNodesdd5232.InnerText.ToString();
            if (moonvisible == "1")
            {
                label11.Text = "Yes";
            }
            else
            {
                label11.Text = "No";
            }

            // Information from astroAPI : [ISSUNUP?]
            XmlNode MyNodcesdd5232 = MyDoc2.SelectSingleNode("root/astronomy/astro/is_sun_up");
            string sunvisible = MyNodcesdd5232.InnerText.ToString();
            if (sunvisible == "1")
            {
                label10.Text = "Yes";
            }
            else
            {
                label10.Text = "No";
            }

            // Download XML API
            WebClient Client = new WebClient();
            Client.DownloadFile($"https://api.weatherapi.com/v1/current.xml?key=d38681c27517404199e183249232406&q={CITY}&aqi=no", $@"{AppData}\Results.xml");

            XmlDocument MyDoc = new XmlDocument(); MyDoc.Load($@"{AppData}\Results.xml");

            // Information from weatherAPI : [TEMPERATURE]
            // [NEW] Check C/F temperature before grabbing
            if (Properties.Settings.Default.CONFIG_TEMPERATURE == "c")
            {
                XmlNode MyNode = MyDoc.SelectSingleNode("root/current/temp_c");
                string temperature_c = MyNode.InnerText.ToString();
                decimal temperature_rounded = Decimal.Parse(temperature_c);

                decimal rounded_temp = Math.Round(temperature_rounded, 0);
                siticoneGroupBox3.Text = rounded_temp.ToString();

                Properties.Settings.Default.temp = rounded_temp.ToString();
                Properties.Settings.Default.Save();
            }
            else
            {
                XmlNode MyNode = MyDoc.SelectSingleNode("root/current/temp_f");
                string temperature_c = MyNode.InnerText.ToString();
                decimal temperature_rounded = Decimal.Parse(temperature_c);

                decimal rounded_temp = Math.Round(temperature_rounded, 0);
                siticoneGroupBox3.Text = rounded_temp.ToString();

                Properties.Settings.Default.temp = rounded_temp.ToString();
                Properties.Settings.Default.Save();
            }

            // Information from weatherAPI : [CONDITION]
            XmlNode MyNode2 = MyDoc.SelectSingleNode("root/current/condition/text");
            string conidition = MyNode2.InnerText.ToString();
            siticoneGroupBox4.Text = conidition;

            // Information from weatherAPI : [HUMIDITY]
            XmlNode MyNode3 = MyDoc.SelectSingleNode("root/current/humidity");
            string humidity = MyNode3.InnerText.ToString();
            label3.Text = humidity+"%";
            Properties.Settings.Default.humidity = humidity.ToString();
            Properties.Settings.Default.Save();

            // Information from weatherAPI : [WINDSPEED]
            if (Properties.Settings.Default.CONFIG_SPEED == "mph")
            {
                XmlNode MyNode4 = MyDoc.SelectSingleNode("root/current/wind_mph");
                string windspeed = MyNode4.InnerText.ToString();
                label5.Text = windspeed;

                decimal rounded_windspeedconverter = Decimal.Parse(windspeed);
                decimal rounded_windspeed = Math.Round(rounded_windspeedconverter, 0);
                Properties.Settings.Default.windspeed = rounded_windspeed.ToString();
                Properties.Settings.Default.Save();
            }
            else
            {
                XmlNode MyNode4 = MyDoc.SelectSingleNode("root/current/wind_kph");
                string windspeed = MyNode4.InnerText.ToString();
                label5.Text = windspeed;

                decimal rounded_windspeedconverter = Decimal.Parse(windspeed);
                decimal rounded_windspeed = Math.Round(rounded_windspeedconverter, 0);
                Properties.Settings.Default.windspeed = rounded_windspeed.ToString();
                Properties.Settings.Default.Save();
            }

            // Extended from above, easier way to check in new_Windspeed.cs

            XmlNode MyNode44 = MyDoc.SelectSingleNode("root/current/wind_mph");
            string windspeed22 = MyNode44.InnerText.ToString();

            decimal rounded_windspeedconvertermph = Decimal.Parse(windspeed22);
            decimal rounded_windspeedmph = Math.Round(rounded_windspeedconvertermph, 0);
            Properties.Settings.Default.windspeedmph = rounded_windspeedmph.ToString();
            Properties.Settings.Default.Save();

            // Information from weatherAPI : [UVINDEX]
            XmlNode MyNode5 = MyDoc.SelectSingleNode("root/current/uv");
            string uvindex = MyNode5.InnerText.ToString();
            label6.Text = uvindex;
            Properties.Settings.Default.uv = uvindex.ToString();
            Properties.Settings.Default.Save();

            // Information from weatherAPI : [CLOUD]
            XmlNode MyNode52 = MyDoc.SelectSingleNode("root/current/cloud");
            string clouds = MyNode52.InnerText.ToString();
            label12.Text = clouds+"%";
            Properties.Settings.Default.clouds = clouds.ToString();
            Properties.Settings.Default.Save();

            // Information from weatherAPI : [WINDDIRECTION]
            XmlNode MyNode6 = MyDoc.SelectSingleNode("root/current/wind_dir");
            string winddirection = MyNode6.InnerText.ToString();
            label8.Text = winddirection;

            // Information from weatherAPI : [FEELSLIKE]
            if (Properties.Settings.Default.CONFIG_TEMPERATURE == "c")
            {
                XmlNode MyNode = MyDoc.SelectSingleNode("root/current/feelslike_c");
                string temperature_c = MyNode.InnerText.ToString();

                label9.Text = temperature_c+ "°C";
            }
            else
            {
                XmlNode MyNode = MyDoc.SelectSingleNode("root/current/feelslike_f");
                string temperature_f = MyNode.InnerText.ToString();

                label9.Text = temperature_f + "°F";
            }

            // Information from weatherAPI : [VISIBLE]
            if (Properties.Settings.Default.CONFIG_DISTANCE == "m")
            {
                XmlNode MyNode8 = MyDoc.SelectSingleNode("root/current/vis_miles");
                string visible = MyNode8.InnerText.ToString();
                label7.Text = visible;
                siticoneGroupBox8.Text = "Visible (miles)";

                decimal rounded_milesc = Decimal.Parse(visible);
                decimal rounded_milescs = Math.Round(rounded_milesc, 0);
                Properties.Settings.Default.visibility = rounded_milescs.ToString();
                Properties.Settings.Default.Save();
            }
            else
            {
                XmlNode MyNode8 = MyDoc.SelectSingleNode("root/current/vis_km");
                string visible = MyNode8.InnerText.ToString();
                label7.Text = visible;
                siticoneGroupBox8.Text = "Visible (km)";

                decimal rounded_milesc = Decimal.Parse(visible);
                decimal rounded_milescs = Math.Round(rounded_milesc, 0);
                Properties.Settings.Default.visibility = rounded_milescs.ToString();
                Properties.Settings.Default.Save();
            }

            XmlNode MyNo2de42 = MyDoc.SelectSingleNode("root/current/vis_miles");
            string vis_miless = MyNo2de42.InnerText.ToString();

            decimal rounded_miles = Decimal.Parse(vis_miless);
            decimal rounded_miless = Math.Round(rounded_miles, 0);
            Properties.Settings.Default.visibilitymiles = rounded_miless.ToString();
            Properties.Settings.Default.Save();


            // XML Finished


            this.Show();

            {
                if (Properties.Settings.Default.CONFIG_SIT == false)
                {
                    try
                    {
                        this.ShowInTaskbar = false;
                    }
                    catch (Exception)
                    {

                    }
                }
            }

            if (Properties.Settings.Default.CONFIG_SEARCH == false)
            {
                siticoneTextBox1.Visible = false;
            }

            if (Properties.Settings.Default.CONFIG_STATS == false)
            {
                siticoneGroupBox1.Visible = false;
            }

            // Information from weatherAPI : [ISDAY] (Yes=DayRain.png) (No=NightRain.png)

            string[] Thunderstorm = { // All use thunderstorm.png
                "Thunderstorm", 
                "Thunderstorm with light rain", 
                "Thunderstorm with rain", 
                "Thunderstorm with heavy rain",
                "Light thunderstorm",
                "Heavy thunderstorm",
                "Ragged thunderstorm",
                "Thunderstorm with light drizzle",
                "Thunderstorm with drizzle",
                "Thunderstorm with heavy drizzle"
            };

            string[] Drizzle = { // All use drizzle.png
                "Drizzle",
                "Light intensity drizzle",
                "Heavy intensity drizzle",
                "light intensity drizzle rain",
                "Drizzle rain",
                "Heavy intensity drizzle rain",
                "Shower rain and drizzle",
                "Heavy shower rain and drizzle",
                "Shower drizzle"
            };

            string[] Rain = { // All use rain.png OR rain_night.png
                "Rain",
                "Light rain",
                "Moderate rain",
                "Heavy intensity rain",
                "Very heavy rain",
                "Extreme rain",
                "Freezing rain",
                "Light intensity shower rain",
                "Shower rain",
                "Heavy intensity shower rain",
                "Ragged shower rain"
            };

            string[] Snow = { // All use snow.png
                "Snow",
                "Light snow",
                "Heavy snow",
                "Sleet",
                "Light shower sleet",
                "Shower sleet",
                "Light rain and snow",
                "Rain and snow",
                "Light shower snow",
                "Shower snow",
                "Heavy shower snow"
            };

            string[] Atmosphere = {
                "Mist",  // Mist.png
                "Smoke", // Mist.png
                "Haze",  // Haze.png
                "Fog"   // fog.png
            };

            string[] Clear = {
                "Clear", // Clear.png OR clear_night.png
                "Sunny"
            };

            string[] Clouds = {
                "Clouds", // clouds.png
                "Overcast", // clouds.png
                "Partly cloudy" // Partially_cloudy.png (DAYONLY)
            };

            if (Properties.Settings.Default.CONFIG_SOUND == true)
            {
                try
                {
                    SoundPlayer soundPlayer = new SoundPlayer("C:\\Windows\\Media\\Windows Unlock.wav");
                    soundPlayer.Play();
                }
                catch (Exception)
                {

                }
            }

            XmlNode MyNode9 = MyDoc.SelectSingleNode("root/current/is_day");
            string isday = MyNode9.InnerText.ToString();
            if (isday == "0") // NIGHT
            {
                Properties.Settings.Default.isday = false;
                label2.Text = System.DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToString("dd") + " " + DateTime.Now.ToString("MMMM") + $": Nighttime";

                foreach (string check1 in Thunderstorm) // Check each string in thunderstorm
                {
                    if (check1 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.Thunderstorm;
                        Properties.Settings.Default.weatherpng = "Thunderstorm";
                    }
                }

                foreach (string check2 in Drizzle) // Check each string in drizzle
                {
                    if (check2 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.drizzle;
                        Properties.Settings.Default.weatherpng = "drizzle";
                    }
                }

                foreach (string check3 in Rain) // Check each string in Rain
                {
                    if (check3 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.rain_night; // DUE TO IT IS NIGHT
                        Properties.Settings.Default.weatherpng = "rain_night";
                    }
                }

                foreach (string check4 in Snow) // Check each string in Snow
                {
                    if (check4 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.snow;
                        Properties.Settings.Default.weatherpng = "snow";
                    }
                }

                foreach (string check5 in Atmosphere) // Check each string in Atmosphere
                {
                    if (check5 == conidition) // If matches with current condition then fun time :)
                    {
                        if (check5 == "Mist") // Due to different images in here we need to check
                        {
                            pictureBox1.Image = Properties.Resources.mist;
                            Properties.Settings.Default.weatherpng = "mist";
                        }
                        if (check5 == "Smoke") // Due to different images in here we need to check
                        {
                            pictureBox1.Image = Properties.Resources.mist;
                            Properties.Settings.Default.weatherpng = "mist";
                        }
                        if (check5 == "Haze") // Due to different images in here we need to check
                        {
                            pictureBox1.Image = Properties.Resources.haze;
                            Properties.Settings.Default.weatherpng = "haze";
                        }
                        if (check5 == "Fog") // Due to different images in here we need to check
                        {
                            pictureBox1.Image = Properties.Resources.fog;
                            Properties.Settings.Default.weatherpng = "fog";
                        }
                    }
                }

                foreach (string check6 in Clear) // Check each string in Clear
                {
                    if (check6 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.clear_night; // DUE TO IT IS NIGHT
                        Properties.Settings.Default.weatherpng = "clear_night";
                    }
                }

                foreach (string check7 in Clouds) // Check each string in Clear
                {
                    if (check7 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.clouds;
                        Properties.Settings.Default.weatherpng = "clouds";
                    }
                }
            }
            else // DAY
            {
                Properties.Settings.Default.isday = true;
                label2.Text = System.DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToString("dd") + " " + DateTime.Now.ToString("MMMM") + $": Daytime";

                foreach (string check1 in Thunderstorm) // Check each string in thunderstorm
                {
                    if (check1 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.Thunderstorm;
                        Properties.Settings.Default.weatherpng = "Thunderstorm";
                    }
                }

                foreach (string check2 in Drizzle) // Check each string in drizzle
                {
                    if (check2 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.drizzle;
                        Properties.Settings.Default.weatherpng = "drizzle";
                    }
                }

                foreach (string check3 in Rain) // Check each string in Rain
                {
                    if (check3 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.rain;
                        Properties.Settings.Default.weatherpng = "rain";
                    }
                }

                foreach (string check4 in Snow) // Check each string in Snow
                {
                    if (check4 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.snow;
                        Properties.Settings.Default.weatherpng = "snow";
                    }
                }

                foreach (string check5 in Atmosphere) // Check each string in Atmosphere
                {
                    if (check5 == conidition) // If matches with current condition then fun time :)
                    {
                        if (check5 == "Mist") // Due to different images in here we need to check
                        {
                            pictureBox1.Image = Properties.Resources.mist;
                            Properties.Settings.Default.weatherpng = "mist";
                        }
                        if (check5 == "Smoke") // Due to different images in here we need to check
                        {
                            pictureBox1.Image = Properties.Resources.mist;
                            Properties.Settings.Default.weatherpng = "mist";
                        }
                        if (check5 == "Haze") // Due to different images in here we need to check
                        {
                            pictureBox1.Image = Properties.Resources.haze;
                            Properties.Settings.Default.weatherpng = "haze";
                        }
                        if (check5 == "Fog") // Due to different images in here we need to check
                        {
                            pictureBox1.Image = Properties.Resources.fog;
                            Properties.Settings.Default.weatherpng = "fog";
                        }
                    }
                }

                foreach (string check6 in Clear) // Check each string in Clear
                {
                    if (check6 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.Clear;
                        Properties.Settings.Default.weatherpng = "Clear";
                    }
                }

                foreach (string check7 in Clouds) // Check each string in Clear
                {
                    if (check7 == conidition) // If matches with current condition then fun time :)
                    {
                        if (check7 == "Clouds")
                        {
                            pictureBox1.Image = Properties.Resources.clouds;
                            Properties.Settings.Default.weatherpng = "clouds";
                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.Partially_cloudy;
                            Properties.Settings.Default.weatherpng = "Partially_cloudy";
                        }
                    }
                }
            }

            // [!] Create a exception (If condition is NOT found in any list then messagebox and quick on accept)
            // -> "Something went wrong on our end"
        }

        private void siticoneLabel2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneTextBox1_IconRightClick(object sender, EventArgs e)
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

            label2.Text = System.DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToString("dd") + " " + DateTime.Now.ToString("MMMM");

            // API for current city: http://ip-api.com/json/ip
            // API for current IP: http://checkip.dyndns.org/
            // API for current weather: https://api.weatherapi.com/v1/current.xml?key=[REMOVEDFORSECURITY]&q=[CITY]&aqi=no

            // Get current IP address
            string IP = "";
            try
            {
                IP = GetIP();
            }
            catch
            {
                Application.Restart();
            }

            string CITY = siticoneTextBox1.Text;
            label1.Text = siticoneTextBox1.Text;

            Properties.Settings.Default.city = CITY;
            Properties.Settings.Default.Save();

            string AppData = @"C:\ProgramData\WeatherApp\Data";

            if (!Directory.Exists(AppData))
            {
                Directory.CreateDirectory(AppData);
            }

            try
            {
                // Download XML API - Astro
                WebClient Client2 = new WebClient();
                Client2.DownloadFile($"https://api.weatherapi.com/v1/astronomy.xml?key=d38681c27517404199e183249232406&q={CITY}", $@"{AppData}\Results_Astro.xml");
            }
            catch (Exception)
            {
                MessageBox.Show("The city/country you entered was not found, please make sure the spelling is correct.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Restart();
            }

            XmlDocument MyDoc2 = new XmlDocument(); MyDoc2.Load($@"{AppData}\Results_Astro.xml");

            // Information from astroAPI : [SUNRISE]
            XmlNode MyNode522 = MyDoc2.SelectSingleNode("root/astronomy/astro/sunrise");
            string sunrise = MyNode522.InnerText.ToString();
            Properties.Settings.Default.sunrise = sunrise.ToString();
            Properties.Settings.Default.Save();

            // Information from astroAPI : [SUNSET]
            XmlNode MyNode5232 = MyDoc2.SelectSingleNode("root/astronomy/astro/sunset");
            string sunset = MyNode5232.InnerText.ToString();
            Properties.Settings.Default.sunset = sunset.ToString();
            Properties.Settings.Default.Save();

            // Information from astroAPI : [MOONRISE]
            XmlNode MyNo2de5232 = MyDoc2.SelectSingleNode("root/astronomy/astro/moonrise");
            string moonrise = MyNo2de5232.InnerText.ToString();
            Properties.Settings.Default.moonrise = moonrise.ToString();
            Properties.Settings.Default.Save();

            // Information from astroAPI : [MOONSET]
            XmlNode MyNodes5232 = MyDoc2.SelectSingleNode("root/astronomy/astro/moonset");
            string moonset = MyNodes5232.InnerText.ToString();
            Properties.Settings.Default.moonset = moonset.ToString();
            Properties.Settings.Default.Save();

            // Information from astroAPI : [MOONPHASE]
            XmlNode MyNodesd5232 = MyDoc2.SelectSingleNode("root/astronomy/astro/moon_phase");
            string moonphase = MyNodesd5232.InnerText.ToString();
            Properties.Settings.Default.moonphase = moonphase.ToString();
            Properties.Settings.Default.Save();

            // Information from astroAPI : [ISMOONUP?]
            XmlNode MyNodesdd5232 = MyDoc2.SelectSingleNode("root/astronomy/astro/is_moon_up");
            string moonvisible = MyNodesdd5232.InnerText.ToString();
            if (moonvisible == "1")
            {
                label11.Text = "Yes";
            }
            else
            {
                label11.Text = "No";
            }

            // Information from astroAPI : [ISSUNUP?]
            XmlNode MyNodcesdd5232 = MyDoc2.SelectSingleNode("root/astronomy/astro/is_sun_up");
            string sunvisible = MyNodcesdd5232.InnerText.ToString();
            if (sunvisible == "1")
            {
                label10.Text = "Yes";
            }
            else
            {
                label10.Text = "No";
            }

            // Download XML API
            WebClient Client = new WebClient();
            Client.DownloadFile($"https://api.weatherapi.com/v1/current.xml?key=d38681c27517404199e183249232406&q={CITY}&aqi=no", $@"{AppData}\Results.xml");

            XmlDocument MyDoc = new XmlDocument(); MyDoc.Load($@"{AppData}\Results.xml");

            // Information from weatherAPI : [TEMPERATURE]
            // [NEW] Check C/F temperature before grabbing
            if (Properties.Settings.Default.CONFIG_TEMPERATURE == "c")
            {
                XmlNode MyNode = MyDoc.SelectSingleNode("root/current/temp_c");
                string temperature_c = MyNode.InnerText.ToString();
                decimal temperature_rounded = Decimal.Parse(temperature_c);

                decimal rounded_temp = Math.Round(temperature_rounded, 0);
                siticoneGroupBox3.Text = rounded_temp.ToString();

                Properties.Settings.Default.temp = rounded_temp.ToString();
                Properties.Settings.Default.Save();
            }
            else
            {
                XmlNode MyNode = MyDoc.SelectSingleNode("root/current/temp_f");
                string temperature_c = MyNode.InnerText.ToString();
                decimal temperature_rounded = Decimal.Parse(temperature_c);

                decimal rounded_temp = Math.Round(temperature_rounded, 0);
                siticoneGroupBox3.Text = rounded_temp.ToString();

                Properties.Settings.Default.temp = rounded_temp.ToString();
                Properties.Settings.Default.Save();
            }

            // Information from weatherAPI : [CONDITION]
            XmlNode MyNode2 = MyDoc.SelectSingleNode("root/current/condition/text");
            string conidition = MyNode2.InnerText.ToString();
            siticoneGroupBox4.Text = conidition;

            // Information from weatherAPI : [HUMIDITY]
            XmlNode MyNode3 = MyDoc.SelectSingleNode("root/current/humidity");
            string humidity = MyNode3.InnerText.ToString();
            label3.Text = humidity + "%";
            Properties.Settings.Default.humidity = humidity.ToString();
            Properties.Settings.Default.Save();

            // Information from weatherAPI : [WINDSPEED]
            if (Properties.Settings.Default.CONFIG_SPEED == "mph")
            {
                XmlNode MyNode4 = MyDoc.SelectSingleNode("root/current/wind_mph");
                string windspeed = MyNode4.InnerText.ToString();
                label5.Text = windspeed;

                decimal rounded_windspeedconverter = Decimal.Parse(windspeed);
                decimal rounded_windspeed = Math.Round(rounded_windspeedconverter, 0);
                Properties.Settings.Default.windspeed = rounded_windspeed.ToString();
                Properties.Settings.Default.Save();
            }
            else
            {
                XmlNode MyNode4 = MyDoc.SelectSingleNode("root/current/wind_kph");
                string windspeed = MyNode4.InnerText.ToString();
                label5.Text = windspeed;

                decimal rounded_windspeedconverter = Decimal.Parse(windspeed);
                decimal rounded_windspeed = Math.Round(rounded_windspeedconverter, 0);
                Properties.Settings.Default.windspeed = rounded_windspeed.ToString();
                Properties.Settings.Default.Save();
            }

            // Extended from above, easier way to check in new_Windspeed.cs

            XmlNode MyNode44 = MyDoc.SelectSingleNode("root/current/wind_mph");
            string windspeed22 = MyNode44.InnerText.ToString();

            decimal rounded_windspeedconvertermph = Decimal.Parse(windspeed22);
            decimal rounded_windspeedmph = Math.Round(rounded_windspeedconvertermph, 0);
            Properties.Settings.Default.windspeedmph = rounded_windspeedmph.ToString();
            Properties.Settings.Default.Save();

            // Information from weatherAPI : [UVINDEX]
            XmlNode MyNode5 = MyDoc.SelectSingleNode("root/current/uv");
            string uvindex = MyNode5.InnerText.ToString();
            label6.Text = uvindex;
            Properties.Settings.Default.uv = uvindex.ToString();
            Properties.Settings.Default.Save();

            // Information from weatherAPI : [CLOUD]
            XmlNode MyNode52 = MyDoc.SelectSingleNode("root/current/cloud");
            string clouds = MyNode52.InnerText.ToString();
            label12.Text = clouds + "%";
            Properties.Settings.Default.clouds = clouds.ToString();
            Properties.Settings.Default.Save();

            // Information from weatherAPI : [WINDDIRECTION]
            XmlNode MyNode6 = MyDoc.SelectSingleNode("root/current/wind_dir");
            string winddirection = MyNode6.InnerText.ToString();
            label8.Text = winddirection;

            // Information from weatherAPI : [FEELSLIKE]
            if (Properties.Settings.Default.CONFIG_TEMPERATURE == "c")
            {
                XmlNode MyNode = MyDoc.SelectSingleNode("root/current/feelslike_c");
                string temperature_c = MyNode.InnerText.ToString();

                label9.Text = temperature_c + "°C";
            }
            else
            {
                XmlNode MyNode = MyDoc.SelectSingleNode("root/current/feelslike_f");
                string temperature_f = MyNode.InnerText.ToString();

                label9.Text = temperature_f + "°F";
            }

            // Information from weatherAPI : [VISIBLE]
            if (Properties.Settings.Default.CONFIG_DISTANCE == "m")
            {
                XmlNode MyNode8 = MyDoc.SelectSingleNode("root/current/vis_miles");
                string visible = MyNode8.InnerText.ToString();
                label7.Text = visible;
                siticoneGroupBox8.Text = "Visible (miles)";

                decimal rounded_milesc = Decimal.Parse(visible);
                decimal rounded_milescs = Math.Round(rounded_milesc, 0);
                Properties.Settings.Default.visibility = rounded_milescs.ToString();
                Properties.Settings.Default.Save();
            }
            else
            {
                XmlNode MyNode8 = MyDoc.SelectSingleNode("root/current/vis_km");
                string visible = MyNode8.InnerText.ToString();
                label7.Text = visible;
                siticoneGroupBox8.Text = "Visible (km)";

                decimal rounded_milesc = Decimal.Parse(visible);
                decimal rounded_milescs = Math.Round(rounded_milesc, 0);
                Properties.Settings.Default.visibility = rounded_milescs.ToString();
                Properties.Settings.Default.Save();
            }

            XmlNode MyNo2de42 = MyDoc.SelectSingleNode("root/current/vis_miles");
            string vis_miless = MyNo2de42.InnerText.ToString();

            decimal rounded_miles = Decimal.Parse(vis_miless);
            decimal rounded_miless = Math.Round(rounded_miles, 0);
            Properties.Settings.Default.visibilitymiles = rounded_miless.ToString();
            Properties.Settings.Default.Save();


            // XML Finished

            {
                if (Properties.Settings.Default.CONFIG_SIT == false)
                {
                    try
                    {
                        this.ShowInTaskbar = false;
                    }
                    catch (Exception)
                    {

                    }
                }
            }

            if (Properties.Settings.Default.CONFIG_SEARCH == false)
            {
                siticoneTextBox1.Visible = false;
            }

            if (Properties.Settings.Default.CONFIG_STATS == false)
            {
                siticoneGroupBox1.Visible = false;
            }

            // Information from weatherAPI : [ISDAY] (Yes=DayRain.png) (No=NightRain.png)

            string[] Thunderstorm = { // All use thunderstorm.png
                "Thunderstorm",
                "Thunderstorm with light rain",
                "Thunderstorm with rain",
                "Thunderstorm with heavy rain",
                "Light thunderstorm",
                "Heavy thunderstorm",
                "Ragged thunderstorm",
                "Thunderstorm with light drizzle",
                "Thunderstorm with drizzle",
                "Thunderstorm with heavy drizzle"
            };

            string[] Drizzle = { // All use drizzle.png
                "Drizzle",
                "Light intensity drizzle",
                "Heavy intensity drizzle",
                "light intensity drizzle rain",
                "Drizzle rain",
                "Heavy intensity drizzle rain",
                "Shower rain and drizzle",
                "Heavy shower rain and drizzle",
                "Shower drizzle"
            };

            string[] Rain = { // All use rain.png OR rain_night.png
                "Rain",
                "Light rain",
                "Moderate rain",
                "Heavy intensity rain",
                "Very heavy rain",
                "Extreme rain",
                "Freezing rain",
                "Light intensity shower rain",
                "Shower rain",
                "Heavy intensity shower rain",
                "Ragged shower rain"
            };

            string[] Snow = { // All use snow.png
                "Snow",
                "Light snow",
                "Heavy snow",
                "Sleet",
                "Light shower sleet",
                "Shower sleet",
                "Light rain and snow",
                "Rain and snow",
                "Light shower snow",
                "Shower snow",
                "Heavy shower snow"
            };

            string[] Atmosphere = {
                "Mist",  // Mist.png
                "Smoke", // Mist.png
                "Haze",  // Haze.png
                "Fog"   // fog.png
            };

            string[] Clear = {
                "Clear", // Clear.png OR clear_night.png
                "Sunny"
            };

            string[] Clouds = {
                "Clouds", // clouds.png
                "Overcast", // clouds.png
                "Partly cloudy" // Partially_cloudy.png (DAYONLY)
            };

            if (Properties.Settings.Default.CONFIG_SOUND == true)
            {
                try
                {
                    SoundPlayer soundPlayer = new SoundPlayer("C:\\Windows\\Media\\Windows Unlock.wav");
                    soundPlayer.Play();
                }
                catch (Exception)
                {

                }
            }

            XmlNode MyNode9 = MyDoc.SelectSingleNode("root/current/is_day");
            string isday = MyNode9.InnerText.ToString();
            if (isday == "0") // NIGHT
            {
                label2.Text = System.DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToString("dd") + " " + DateTime.Now.ToString("MMMM") + $": Nighttime";

                foreach (string check1 in Thunderstorm) // Check each string in thunderstorm
                {
                    if (check1 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.Thunderstorm;
                    }
                }

                foreach (string check2 in Drizzle) // Check each string in drizzle
                {
                    if (check2 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.drizzle;
                    }
                }

                foreach (string check3 in Rain) // Check each string in Rain
                {
                    if (check3 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.rain_night; // DUE TO IT IS NIGHT
                    }
                }

                foreach (string check4 in Snow) // Check each string in Snow
                {
                    if (check4 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.snow;
                    }
                }

                foreach (string check5 in Atmosphere) // Check each string in Atmosphere
                {
                    if (check5 == conidition) // If matches with current condition then fun time :)
                    {
                        if (check5 == "Mist") // Due to different images in here we need to check
                        {
                            pictureBox1.Image = Properties.Resources.mist;
                        }
                        if (check5 == "Smoke") // Due to different images in here we need to check
                        {
                            pictureBox1.Image = Properties.Resources.mist;
                        }
                        if (check5 == "Haze") // Due to different images in here we need to check
                        {
                            pictureBox1.Image = Properties.Resources.haze;
                        }
                        if (check5 == "Fog") // Due to different images in here we need to check
                        {
                            pictureBox1.Image = Properties.Resources.fog;
                        }
                    }
                }

                foreach (string check6 in Clear) // Check each string in Clear
                {
                    if (check6 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.clear_night; // DUE TO IT IS NIGHT
                    }
                }

                foreach (string check7 in Clouds) // Check each string in Clear
                {
                    if (check7 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.clouds;
                    }
                }
            }
            else // DAY
            {
                label2.Text = System.DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToString("dd") + " " + DateTime.Now.ToString("MMMM") + $": Daytime";

                foreach (string check1 in Thunderstorm) // Check each string in thunderstorm
                {
                    if (check1 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.Thunderstorm;
                    }
                }

                foreach (string check2 in Drizzle) // Check each string in drizzle
                {
                    if (check2 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.drizzle;
                    }
                }

                foreach (string check3 in Rain) // Check each string in Rain
                {
                    if (check3 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.rain;
                    }
                }

                foreach (string check4 in Snow) // Check each string in Snow
                {
                    if (check4 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.snow;
                    }
                }

                foreach (string check5 in Atmosphere) // Check each string in Atmosphere
                {
                    if (check5 == conidition) // If matches with current condition then fun time :)
                    {
                        if (check5 == "Mist") // Due to different images in here we need to check
                        {
                            pictureBox1.Image = Properties.Resources.mist;
                        }
                        if (check5 == "Smoke") // Due to different images in here we need to check
                        {
                            pictureBox1.Image = Properties.Resources.mist;
                        }
                        if (check5 == "Haze") // Due to different images in here we need to check
                        {
                            pictureBox1.Image = Properties.Resources.haze;
                        }
                        if (check5 == "Fog") // Due to different images in here we need to check
                        {
                            pictureBox1.Image = Properties.Resources.fog;
                        }
                    }
                }

                foreach (string check6 in Clear) // Check each string in Clear
                {
                    if (check6 == conidition) // If matches with current condition then fun time :)
                    {
                        pictureBox1.Image = Properties.Resources.Clear;
                    }
                }

                foreach (string check7 in Clouds) // Check each string in Clear
                {
                    if (check7 == conidition) // If matches with current condition then fun time :)
                    {
                        if (check7 == "Clouds")
                        {
                            pictureBox1.Image = Properties.Resources.clouds;
                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.Partially_cloudy;
                        }
                    }
                }
            }

            // [!] Create a exception (If condition is NOT found in any list then messagebox and quick on accept)
            // -> "Something went wrong on our end"
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CONFIG_SE == true)
            {
                try
                {
                    SoundPlayer soundPlayer = new SoundPlayer("C:\\Windows\\Media\\Windows Pop-up Blocked.wav");
                    soundPlayer.Play();
                }
                catch (Exception)
                {

                }
            }

            Environment.Exit(0);
        }

        private void siticoneGroupBox7_Click(object sender, EventArgs e)
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

            this.panel1.Controls.Clear();
            new_UV open = new new_UV
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            open.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(open);
            open.Show();

            siticoneTextBox1.PlaceholderText = "Return home to search!";
            siticoneTextBox1.Text = null;
            siticoneTextBox1.Enabled = false;
        }

        private void siticoneGroupBox2_Click(object sender, EventArgs e)
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

            this.panel1.Controls.Clear();
            new_Humidity open = new new_Humidity
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            open.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(open);
            open.Show();

            siticoneTextBox1.PlaceholderText = "Return home to search!";
            siticoneTextBox1.Text = null;
            siticoneTextBox1.Enabled = false;
        }

        private void siticoneGroupBox5_Click(object sender, EventArgs e)
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

            this.panel1.Controls.Clear();
            new_Windspeed open = new new_Windspeed
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            open.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(open);
            open.Show();

            siticoneTextBox1.PlaceholderText = "Return home to search!";
            siticoneTextBox1.Text = null;
            siticoneTextBox1.Enabled = false;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

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

            this.panel1.Controls.Clear();
            settings open = new settings
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            open.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(open);
            open.Show();

            siticoneTextBox1.PlaceholderText = "Return home to search!";
            siticoneTextBox1.Text = null;
            siticoneTextBox1.Enabled = false;
        }

        private void siticoneGroupBox9_Click(object sender, EventArgs e)
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

            this.panel1.Controls.Clear();
            new_temperature open = new new_temperature
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            open.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(open);
            open.Show();

            siticoneTextBox1.PlaceholderText = "Return home to search!";
            siticoneTextBox1.Text = null;
            siticoneTextBox1.Enabled = false;
        }

        private void siticoneGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneGroupBox8_Click(object sender, EventArgs e)
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

            this.panel1.Controls.Clear();
            new_Visible open = new new_Visible
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            open.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(open);
            open.Show();

            siticoneTextBox1.PlaceholderText = "Return home to search!";
            siticoneTextBox1.Text = null;
            siticoneTextBox1.Enabled = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void siticoneGroupBox6_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneGroupBox10_Click(object sender, EventArgs e)
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

            this.panel1.Controls.Clear();
            astro_sun open = new astro_sun
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            open.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(open);
            open.Show();

            siticoneTextBox1.PlaceholderText = "Return home to search!";
            siticoneTextBox1.Text = null;
            siticoneTextBox1.Enabled = false;
        }

        private void siticoneGroupBox11_Click(object sender, EventArgs e)
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

            this.panel1.Controls.Clear();
            astro_moon open = new astro_moon
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            open.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(open);
            open.Show();

            siticoneTextBox1.PlaceholderText = "Return home to search!";
            siticoneTextBox1.Text = null;
            siticoneTextBox1.Enabled = false;
        }

        private void siticoneGroupBox12_Click(object sender, EventArgs e)
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

            this.panel1.Controls.Clear();
            cloud_stength open = new cloud_stength
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            open.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(open);
            open.Show();

            siticoneTextBox1.PlaceholderText = "Return home to search!";
            siticoneTextBox1.Text = null;
            siticoneTextBox1.Enabled = false;
        }

        private void siticoneButton2_Click_1(object sender, EventArgs e)
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

            this.panel1.Controls.Clear();
            Notifications open = new Notifications
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            open.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(open);
            open.Show();

            siticoneTextBox1.PlaceholderText = "Return home to search!";
            siticoneTextBox1.Text = null;
            siticoneTextBox1.Enabled = false;
        }

        private void siticoneButton2_MouseHover(object sender, EventArgs e)
        {
            siticoneToolTip1.SetToolTip(siticoneButton2, "Show daily updates of my current location");
        }

        private void siticoneButton1_MouseHover(object sender, EventArgs e)
        {
            siticoneToolTip1.SetToolTip(siticoneButton1, "Customize the weather application to your personal preferences");
        }

        private void siticoneGroupBox2_MouseHover(object sender, EventArgs e)
        {
            siticoneToolTip1.SetToolTip(siticoneGroupBox2, "Show a detailed risk factor of the current humidity levels");
        }

        private void siticoneGroupBox5_MouseHover(object sender, EventArgs e)
        {
            siticoneToolTip1.SetToolTip(siticoneGroupBox5, "Show a detailed risk factor of the current wind speed");
        }

        private void siticoneGroupBox9_MouseHover(object sender, EventArgs e)
        {
            siticoneToolTip1.SetToolTip(siticoneGroupBox9, "Show a detailed risk factor of the current temperature");
        }

        private void siticoneGroupBox8_MouseHover(object sender, EventArgs e)
        {
            siticoneToolTip1.SetToolTip(siticoneGroupBox8, "Show a detailed risk factor of the current visibility scale");
        }

        private void siticoneGroupBox7_MouseHover(object sender, EventArgs e)
        {
            siticoneToolTip1.SetToolTip(siticoneGroupBox7, "Show a detailed risk factor of the current UV index");
        }

        private void siticoneGroupBox12_MouseHover(object sender, EventArgs e)
        {
            siticoneToolTip1.SetToolTip(siticoneGroupBox12, "Show a detailed risk factor of the current cloud strength");
        }

        private void siticoneGroupBox11_MouseHover(object sender, EventArgs e)
        {
            siticoneToolTip1.SetToolTip(siticoneGroupBox11, "Show information about the moon such as moonrise, moonset and the moonphase");
        }

        private void siticoneGroupBox10_MouseHover(object sender, EventArgs e)
        {
            siticoneToolTip1.SetToolTip(siticoneGroupBox10, "Show information about the sun such as sunrise and sunset");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneButton3_MouseHover(object sender, EventArgs e)
        {
            siticoneToolTip1.SetToolTip(siticoneButton3, "Edit or view your account details and manage how we use your data");
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
