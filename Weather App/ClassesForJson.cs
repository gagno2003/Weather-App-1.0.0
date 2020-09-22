using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_App
{
    public class Root
    {
        public double Rlon { get; set; }
        public double Rlat { get; set; }
        public string Rdescription { get; set; }
        public double Rtemp_min { get; set; }
        public string Ricon { get; set; }
        public int Rpressure { get; set; }
        public int Rhumidity { get; set; }
        public double Rspeed { get; set; }
        public double Rfeels_like { get; set; }
        public double Rtemp_max { get; set; }
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string Base { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }
    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }
    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }
    public class Clouds
    {
        public int all { get; set; }
    }
    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
}
