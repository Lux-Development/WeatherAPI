using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherAPI.Auth
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
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

        private void login_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            if (Properties.Settings.Default.pastloginsaved == true)
            {
                siticoneSeparator1.Visible = true; siticoneSeparator2.Visible = true;
                label1.Visible = true;
                siticoneGroupBox1.Visible = true;
                label3.Visible = true;
                siticoneButton2.Visible = true;
                label9.Visible = true;
                pictureBox2.Visible = true;

                label3.Text = Properties.Settings.Default.login_email;
                label9.Text = Properties.Settings.Default.register_fullname;
            }
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            // Will save login data to a setting: email/password/logindate
            // Will save pastloginsaved=true

            Properties.Settings.Default.pastloginsaved = true;
            Properties.Settings.Default.login_email = loginemail.Text;
            Properties.Settings.Default.login_password = loginpassword.Text;
            Properties.Settings.Default.past_logindate = DateTime.Now.ToString("d")+", "+DateTime.Now.ToString("t");
            Properties.Settings.Default.Save();

            UI main = new UI(); main.Show(); this.Hide();
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        { 
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            UI main = new UI(); main.Show(); this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            register main = new register(); main.Show(); this.Hide();
        }
    }
}
