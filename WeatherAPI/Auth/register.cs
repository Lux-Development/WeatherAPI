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
using WeatherAPI.Stats_Clicked.SecondLook;

namespace WeatherAPI.Auth
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        static void OnProcessExit(object sender, EventArgs e)
        {

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

        private void register_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            siticoneTextBox4.Text = "@";
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {

        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void siticoneButton1_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.register_fullname = siticoneTextBox7.Text + " " + siticoneTextBox1.Text;
            Properties.Settings.Default.register_handle = siticoneTextBox6.Text;
            Properties.Settings.Default.register_email = siticoneTextBox6.Text;
            Properties.Settings.Default.register_pass = siticoneTextBox3.Text;
            Properties.Settings.Default.Save();
        }

        private void siticoneControlBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
