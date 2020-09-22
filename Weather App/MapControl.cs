using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.MapProviders;

namespace Weather_App
{
    public partial class MapControl : UserControl
    {
        public MapControl()
        {
            InitializeComponent();
        }

        private void MapControl_Load(object sender, EventArgs e)
        {
            lonlatreset.Start();
            MapPR.MapProvider = GMapProviders.GoogleMap;
            MapPR.Zoom = 10;
            
        }

        private void lonlatreset_Tick(object sender, EventArgs e)
        {
            MapPR.Position = new GMap.NET.PointLatLng(WeatherApp.lat, WeatherApp.lon);

        }
    }
}
