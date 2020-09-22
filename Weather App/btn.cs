using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weather_App
{
    public partial class btn : UserControl
    {
        public btn()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WeatherApp.main.Width = 749;
            WeatherApp.main.Height = 430;
            WeatherApp.RcityChanger.Hide();
            WeatherApp.counter = 0;
            WeatherApp.iconbox.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WeatherApp.main.Width = 749;
            WeatherApp.main.Height = 430;
            WeatherApp.RcityChanger.Hide();
            WeatherApp.counter = 0;
            WeatherApp.iconbox.Hide();
        }
    }
}
