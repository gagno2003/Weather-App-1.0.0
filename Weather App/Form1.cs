using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Weather_App
{
    public partial class WeatherApp : Form
    {
        public WeatherApp()
        {
            InitializeComponent();
        }

        static public WeatherApp main = new WeatherApp();
        static public double lon = new double();
        static public double lat = new double();
        static async Task<Root> WeatherInformation(string city)
        {
            const string apiKey = "995c5315f51d5cdacb0eb720472f2085";
            HttpClient httpClient = new HttpClient();
            var weatherString = httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}").GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var root = JsonConvert.DeserializeObject<Root>(weatherString);
            Root roots = new Root();
            if (root.name == null)
            {
                roots = new Root { name = "", timezone = 0, Rtemp_max = 0, Rfeels_like = 0, Rspeed = 0, Rhumidity = 0, Rpressure = 0, Rtemp_min = 0, Ricon = "", Rdescription = "", Rlat = 0, Rlon = 0 };
            }
            else
            {
                roots = new Root { name = root.name, timezone = root.timezone / 3600, Rtemp_max = root.main.temp_max - 273.15, Rfeels_like = root.main.feels_like - 273.15, Rspeed = root.wind.speed, Rhumidity = root.main.humidity, Rpressure = root.main.pressure, Rtemp_min = root.main.temp_min - 273.15, Ricon = root.weather[0].icon, Rdescription = root.weather[0].description, Rlat = root.coord.lat, Rlon = root.coord.lon };
            }

            
            return roots;

        }

        static public string ImageLink(string icon)
        {
            string ImageLink = $"http://openweathermap.org/img/wn/{icon}@2x.png";
            return ImageLink;
        }

        static public void Boxes(string city, GroupBox groupbox, PictureBox picturebox, Label temp_max, Label temp_min, Label speed)
        {
            
            if (WeatherInformation(city).Result.name != "")
            {
                groupbox.Text = WeatherInformation(city).Result.name;
                WebRequest request = WebRequest.Create(ImageLink(WeatherInformation(city).Result.Ricon));
                using (var response = request.GetResponse())
                {
                    using (var str = response.GetResponseStream())
                    {
                        picturebox.Image = Bitmap.FromStream(str);
                    }
                }

                double tempmaxround = WeatherInformation(city).Result.Rtemp_max;
                double tempminround = WeatherInformation(city).Result.Rtemp_min;
                double speedround = WeatherInformation(city).Result.Rspeed;


                temp_min.Text = Math.Round(tempminround).ToString() + "°C";
                temp_max.Text = Math.Round(tempmaxround).ToString() + "°C";
                speed.Text = "↖" + Math.Round(speedround).ToString() + "mph";
            }
            else
            {
               
            }


            


        }

        public static TextBox RcityChanger = new TextBox();
        public static PictureBox iconbox = new PictureBox();
        private List<bool> bools = new List<bool>();
          

        private void WeatherApp_Load(object sender, EventArgs e)
        {
            FileStream sb1 = new FileStream("City1.txt", FileMode.OpenOrCreate);
            StreamWriter sw1 = new StreamWriter(sb1);
            
            sw1.Close();

            FileStream sb2 = new FileStream("City2.txt", FileMode.OpenOrCreate);
            StreamWriter sw2 = new StreamWriter(sb2);
            sw2.Close();

            FileStream sb3 = new FileStream("City3.txt", FileMode.OpenOrCreate);
            StreamWriter sw3 = new StreamWriter(sb3);
            sw3.Close();

            FileStream sb4 = new FileStream("City4.txt", FileMode.OpenOrCreate);
            StreamWriter sw4 = new StreamWriter(sb4);
            sw4.Close();

            FileStream sb5 = new FileStream("City5.txt", FileMode.OpenOrCreate);
            StreamWriter sw5 = new StreamWriter(sb5);
            sw5.Close();

            FileStream sb6 = new FileStream("City6.txt", FileMode.OpenOrCreate);
            StreamWriter sw6 = new StreamWriter(sb6);
            sw6.Close();


            iconbox = pictureBox1;
            pictureBox1.Hide();
            CityChangerBox.Hide();
            RcityChanger = CityChangerBox;
            main = this;
            mapcontrol.Hide();
            MainSize(749, 430);
            bools = new List<bool>()
            {
                first, two, three, four, five, six
            };
            using (StreamReader st = new StreamReader("City1.txt"))
            {
                string text = st.ReadToEnd();
                Boxes(text, FirstGroupBox, FirstIconBox, tempmax, tempmin, Wind1);
            }
            using (StreamReader st = new StreamReader("City2.txt"))
            {
                string text = st.ReadToEnd();
                Boxes(text, SecondGroupBox, SecondIconBox, tempmax2, tempmin2, Wind2);
            }
            using (StreamReader st = new StreamReader("City3.txt"))
            {
                string text = st.ReadToEnd();
                Boxes(text, ThirdGroupBox, ThirdIconBox, tempmax3, tempmin3, Wind3);
            }
            using (StreamReader st = new StreamReader("City4.txt"))
            {
                string text = st.ReadToEnd();
                Boxes(text, FourthGroupBox, FourthIconBox, tempmax4, tempmin4, Wind4);
            }
            using (StreamReader st = new StreamReader("City5.txt"))
            {
                string text = st.ReadToEnd();
                Boxes(text, FifthGroupBox, FifthIconBox, tempmax5, tempmin5, Wind5);
            }
            using (StreamReader st = new StreamReader("City6.txt"))
            {
                string text = st.ReadToEnd();
                Boxes(text, SixthGroupBox, SixthIconBox, tempmax6, tempmin6, Wind6);
            }
            WeatherTimer.Start();
        }

        public static bool YN = false;

        private void WeatherTimer_Tick(object sender, EventArgs e)
        {
            if (Search.Text == "" && YN == true)
            {
                FirstGroupBox.Show();
                SecondGroupBox.Show();
                ThirdGroupBox.Show();
                FourthGroupBox.Show();
                FifthGroupBox.Show();
                SixthGroupBox.Show();

                using (StreamReader st = new StreamReader("City1.txt"))
                {
                    string text = st.ReadToEnd();
                    Boxes(text, FirstGroupBox, FirstIconBox, tempmax, tempmin, Wind1);
                }

                YN = false;
               

            }
        }


        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchIcon_Click(null, null);
            }
        }

        private void Search_Enter_1(object sender, EventArgs e)
        {
            if (Search.Text == "Search")
            {
                Search.Text = "";
                Search.ForeColor = Color.Black;
            }
        }

        private void Search_Leave_1(object sender, EventArgs e)
        {
            if (Search.Text == "")
            {
                Search.Text = "Search";
                Search.ForeColor = Color.Silver;
            }
        }

        private void SearchIcon_Click(object sender, EventArgs e)
        {
            if (maporweather == false)
            {
                SecondGroupBox.Hide();
                ThirdGroupBox.Hide();
                FourthGroupBox.Hide();
                FifthGroupBox.Hide();
                SixthGroupBox.Hide();

                if (WeatherInformation(Search.Text).Result.name != "")
                {
                    Boxes(Search.Text, FirstGroupBox, FirstIconBox, tempmax, tempmin, Wind1);
                    lon = WeatherInformation(FirstGroupBox.Text).Result.Rlon;
                    lat = WeatherInformation(FirstGroupBox.Text).Result.Rlat;
                }
                else
                {
                    FirstGroupBox.Hide();
                }
                
               
                YN = true;
            }
            else
            {
                using (StreamReader st = new StreamReader("City1.txt"))
                {
                    string text = st.ReadToEnd();
                    if (WeatherInformation(text).Result.name != "")
                    {
                        Boxes(text, FirstGroupBox, FirstIconBox, tempmax, tempmin, Wind1);
                        lon = WeatherInformation(Search.Text).Result.Rlon;
                        lat = WeatherInformation(Search.Text).Result.Rlat;
                    }
                    else
                    {

                    }
                    
                }
               
                YN = true;
            }
            
        }

        private void WeatherApp_Click(object sender, EventArgs e)
        {
            
        }

        
        public void MainSize(int width, int height)
        {
            main.Width = width;
            main.Height = height;
        }
        public void GetMoreInformation(GroupBox gbox, PictureBox pbox, Label max, Label min)
        {
            MoreInformation.Text = gbox.Text;
            description.Text = WeatherInformation(gbox.Text).Result.Rdescription.ToString();
            int size = (MoreInformation.Width - description.Width) / 2;
            description.Left = size;
            SeventhIconBox.Image = pbox.Image;
            max7.Text = max.Text;
            min7.Text = min.Text;
            double Rfeelslike = Math.Round(WeatherInformation(gbox.Text).Result.Rfeels_like);
            feelslike.Text = Rfeelslike.ToString() + "°C";
            pressure.Text = WeatherInformation(gbox.Text).Result.Rpressure.ToString() + "hPa";
            humidity.Text = WeatherInformation(gbox.Text).Result.Rhumidity.ToString() + "%";
            MainSize(934, 430);
        }
        bool first = false;
        bool two = false;
        bool three = false;
        bool four = false;
        bool five = false;
        bool six = false;

       
        public bool onlyone(int n)
        {
            
            for (int i = 0; i < bools.Count; i++)
            {
                bools[i] = false;
            }
            bools[n] = true;
            
            return bools[n];
        }
        private void GroupBox2Cloack_Click(object sender, EventArgs e)
        {
            GetMoreInformation(SecondGroupBox, SecondIconBox, tempmax2, tempmin2);
            lon = WeatherInformation(SecondGroupBox.Text).Result.Rlon;
            lat = WeatherInformation(SecondGroupBox.Text).Result.Rlat;
            onlyone(1);
        }

        private void GroupBox1Cloack_Click(object sender, EventArgs e)
        {
            GetMoreInformation(FirstGroupBox, FirstIconBox, tempmax, tempmin);
            lon = WeatherInformation(FirstGroupBox.Text).Result.Rlon;
            lat = WeatherInformation(FirstGroupBox.Text).Result.Rlat;
            onlyone(0);
        }

        private void GroupBox3Cloack_Click(object sender, EventArgs e)
        {
            GetMoreInformation(ThirdGroupBox, ThirdIconBox, tempmax3, tempmin3);
            lon = WeatherInformation(ThirdGroupBox.Text).Result.Rlon;
            lat = WeatherInformation(ThirdGroupBox.Text).Result.Rlat;
            onlyone(2);
        }

        private void GroupBox4Cloack_Click(object sender, EventArgs e)
        {
            GetMoreInformation(FourthGroupBox, FourthIconBox, tempmax4, tempmin4);
            lon = WeatherInformation(FourthGroupBox.Text).Result.Rlon;
            lat = WeatherInformation(FourthGroupBox.Text).Result.Rlat;
            onlyone(3);
        }

        private void GroupBox5Cloack_Click(object sender, EventArgs e)
        {
            GetMoreInformation(FifthGroupBox, FifthIconBox, tempmax5, tempmin5);
            lon = WeatherInformation(FifthGroupBox.Text).Result.Rlon;
            lat = WeatherInformation(FifthGroupBox.Text).Result.Rlat;
            onlyone(4);
        }

        private void GroupBox6Cloack_Click(object sender, EventArgs e)
        {
            GetMoreInformation(SixthGroupBox, SixthIconBox, tempmax6, tempmin6);
            lon = WeatherInformation(SixthGroupBox.Text).Result.Rlon;
            lat = WeatherInformation(SixthGroupBox.Text).Result.Rlat;
            onlyone(5);
        }

        private void WeatherBTN_Click(object sender, EventArgs e)
        {
            mapcontrol.Hide();
            Search.Show();
            SearchIcon.Show();
            maporweather = false;
        }

        bool maporweather = false;
        private void MapBTN_Click(object sender, EventArgs e)
        {
            mapcontrol.Show();
            maporweather = true;
        }

        public static int counter = 0;
        private void ChangeCityClick_Click(object sender, EventArgs e)
        {
            counter++;
            if (counter % 2 == 0)
            {
                CityChangerBox.Hide();
                pictureBox1.Hide();
            }
            else
            {
                pictureBox1.Show();
                CityChangerBox.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


            if (bools[0] == true)
            {
                if (WeatherInformation(CityChangerBox.Text).Result.name != "")
                {
                    File.Delete("City1.txt");
                    FileStream sb1 = new FileStream("City1.txt", FileMode.OpenOrCreate);
                    StreamWriter sw1 = new StreamWriter(sb1);
                    sw1.Write(CityChangerBox.Text);
                    sw1.Close();

                    Boxes(CityChangerBox.Text, FirstGroupBox, FirstIconBox, tempmax, tempmin, Wind1);
                    GroupBox1Cloack_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Uncorrect city!");
                }
                
                
            }
            else if (bools[1] == true)
            {
                if (WeatherInformation(CityChangerBox.Text).Result.name != "")
                {
                    File.Delete("City2.txt");
                    FileStream sb1 = new FileStream("City2.txt", FileMode.OpenOrCreate);
                    StreamWriter sw1 = new StreamWriter(sb1);
                    sw1.Write(CityChangerBox.Text);
                    sw1.Close();

                    Boxes(CityChangerBox.Text, SecondGroupBox, SecondIconBox, tempmax2, tempmin2, Wind2);
                    GroupBox2Cloack_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Uncorrect city!");
                }
            }
            else if (bools[2] == true)
            {
                if (WeatherInformation(CityChangerBox.Text).Result.name != "")
                {
                    File.Delete("City3.txt");
                    FileStream sb1 = new FileStream("City3.txt", FileMode.OpenOrCreate);
                    StreamWriter sw1 = new StreamWriter(sb1);
                    sw1.Write(CityChangerBox.Text);
                    sw1.Close();

                    Boxes(CityChangerBox.Text, ThirdGroupBox, ThirdIconBox, tempmax3, tempmin3, Wind3);
                    GroupBox3Cloack_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Uncorrect city!");
                }
            }
            else if (bools[3] == true)
            {
                if (WeatherInformation(CityChangerBox.Text).Result.name != "")
                {
                    File.Delete("City4.txt");
                    FileStream sb1 = new FileStream("City4.txt", FileMode.OpenOrCreate);
                    StreamWriter sw1 = new StreamWriter(sb1);
                    sw1.Write(CityChangerBox.Text);
                    sw1.Close();

                    Boxes(CityChangerBox.Text, FourthGroupBox, FourthIconBox, tempmax4, tempmin4, Wind4);
                    GroupBox4Cloack_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Uncorrect city!");
                }
            }
            else if (bools[4] == true)
            {
                if (WeatherInformation(CityChangerBox.Text).Result.name != "")
                {
                    File.Delete("City5.txt");
                    FileStream sb1 = new FileStream("City5.txt", FileMode.OpenOrCreate);
                    StreamWriter sw1 = new StreamWriter(sb1);
                    sw1.Write(CityChangerBox.Text);
                    sw1.Close();

                    Boxes(CityChangerBox.Text, FifthGroupBox, FifthIconBox, tempmax5, tempmin5, Wind5);
                    GroupBox5Cloack_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Uncorrect city!");
                }
            }
            else if (bools[5] == true)
            {
                if (WeatherInformation(CityChangerBox.Text).Result.name != "")
                {
                    File.Delete("City6.txt");
                    FileStream sb1 = new FileStream("City6.txt", FileMode.OpenOrCreate);
                    StreamWriter sw1 = new StreamWriter(sb1);
                    sw1.Write(CityChangerBox.Text);
                    sw1.Close();

                    Boxes(CityChangerBox.Text, SixthGroupBox, SixthIconBox, tempmax6, tempmin6, Wind6);
                    GroupBox6Cloack_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Uncorrect city!");
                }
            }

            CityChangerBox.Text = "";

        }

        private void CityChangerBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pictureBox1_Click(null, null);
            }
        }
    }
}
