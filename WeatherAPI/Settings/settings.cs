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

namespace WeatherAPI.Settings
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }

        private void siticoneGroupBox2_Click(object sender, EventArgs e)
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

            Application.Restart();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
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

            // Show in taskbar Configuration
            if (showintaskbar.Checked == true)
            {
                Properties.Settings.Default.CONFIG_SIT = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.CONFIG_SIT = false;
                Properties.Settings.Default.Save();
            }

            // Temperature Configuration
            if (c.Checked == true)
            {
                Properties.Settings.Default.CONFIG_TEMPERATURE = "c";
                Properties.Settings.Default.Save();
            }
            if (f.Checked == true)
            {
                Properties.Settings.Default.CONFIG_TEMPERATURE = "f";
                Properties.Settings.Default.Save();
            }

            // Distance Configuration
            if (miles.Checked == true)
            {
                Properties.Settings.Default.CONFIG_DISTANCE = "m";
                Properties.Settings.Default.Save();
            }
            if (km.Checked == true)
            {
                Properties.Settings.Default.CONFIG_DISTANCE = "km";
                Properties.Settings.Default.Save();
            }

            // Speed Configuration
            if (mph.Checked == true)
            {
                Properties.Settings.Default.CONFIG_SPEED = "mph";
                Properties.Settings.Default.Save();
            }
            if (kph.Checked == true)
            {
                Properties.Settings.Default.CONFIG_SPEED = "kph";
                Properties.Settings.Default.Save();
            }

            // Pin to tasbark Configuration
            if (ltt.Checked == true)
            {
                Properties.Settings.Default.locktotaskbar = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.locktotaskbar = false;
                Properties.Settings.Default.Save();
            }

            // Always on top Configuration
            if (nm.Checked == true)
            {
                Properties.Settings.Default.alwaysontop = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.alwaysontop = false;
                Properties.Settings.Default.Save();
            }

            // Sounds
            if (sound.Checked == true)
            {
                Properties.Settings.Default.CONFIG_SOUND = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.CONFIG_SOUND = false;
                Properties.Settings.Default.Save();
            }

            // Search
            if (search.Checked == true)
            {
                Properties.Settings.Default.CONFIG_SEARCH = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.CONFIG_SEARCH = false;
                Properties.Settings.Default.Save();
            }

            // Stats
            if (stats.Checked == true)
            {
                Properties.Settings.Default.CONFIG_STATS = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.CONFIG_STATS = false;
                Properties.Settings.Default.Save();
            }

            // Sound effects
            if (sse.Checked == true)
            {
                Properties.Settings.Default.CONFIG_SE = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.CONFIG_SE = false;
                Properties.Settings.Default.Save();
            }

            Application.Restart();
        }

        private void settings_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CONFIG_SIT == true)
            {
                showintaskbar.Checked = true;
            }
            else
            {
                showintaskbar.Checked = false;
            }

            if (Properties.Settings.Default.CONFIG_TEMPERATURE == "c")
            {
                c.Checked = true;
            }
            else
            {
                f.Checked = true;
            }

            if (Properties.Settings.Default.CONFIG_SPEED == "mph")
            {
                mph.Checked = true;
            }
            else
            {
                kph.Checked = true;
            }

            if (Properties.Settings.Default.CONFIG_DISTANCE == "m")
            {
                miles.Checked = true;
            }
            else
            {
                km.Checked = true;
            }

            if (Properties.Settings.Default.locktotaskbar == true)
            {
                ltt.Checked = true;
            }
            else
            {
                ltt.Checked = false;
            }

            if (Properties.Settings.Default.alwaysontop == true)
            {
                nm.Checked = true;
            }
            else
            {
                nm.Checked = false;
            }

            if (Properties.Settings.Default.CONFIG_SOUND == true)
            {
                sound.Checked = true;
            }
            else
            {
                sound.Checked = false;
            }

            if (Properties.Settings.Default.CONFIG_SEARCH == true)
            {
                search.Checked = true;
            }
            else
            {
                search.Checked = false;
            }

            if (Properties.Settings.Default.CONFIG_STATS == true)
            {
                stats.Checked = true;
            }
            else
            {
                stats.Checked = false;
            }

            if (Properties.Settings.Default.CONFIG_SE == true)
            {
                sse.Checked = true;
            }
            else
            {
                sse.Checked = false;
            }
        }

        private void siticoneToggleSwitch1_CheckedChanged(object sender, EventArgs e)
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
        }

        private void ltt_CheckedChanged(object sender, EventArgs e)
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
        }

        private void search_CheckedChanged(object sender, EventArgs e)
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
        }

        private void stats_CheckedChanged(object sender, EventArgs e)
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
        }

        private void siticoneToggleSwitch2_CheckedChanged(object sender, EventArgs e)
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
        }

        private void miles_CheckedChanged(object sender, EventArgs e)
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
        }

        private void km_CheckedChanged(object sender, EventArgs e)
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
        }

        private void c_CheckedChanged(object sender, EventArgs e)
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
        }

        private void f_CheckedChanged(object sender, EventArgs e)
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
        }

        private void mph_CheckedChanged(object sender, EventArgs e)
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
        }

        private void kph_CheckedChanged(object sender, EventArgs e)
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
        }

        private void sound_CheckedChanged(object sender, EventArgs e)
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
        }

        private void siticoneToggleSwitch1_CheckedChanged_1(object sender, EventArgs e)
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
        }
    }
}
