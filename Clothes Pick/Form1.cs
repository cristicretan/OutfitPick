using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Device.Location;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clothes_Pick
{
    public partial class Form1 : Form
    {

        public int NumberOfClick = 0;

        public DialogResult Result;

        public bool button2clicked = true;

        public bool firstload = false;

        public static string path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Gallery\";

        public Form1()
        {
            InitializeComponent();

            

            button4.TabStop = false;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 0, 0, 0); // transparent

            button2.TabStop = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 0, 0, 0); // transparent

        }

        public static List<string> GetFilesFrom(string searchfolder, string[] filters)
        {

            List<string> filesFound = new List<string>();
            var searchOption = SearchOption.AllDirectories;
            try
            {
                foreach(var filter in filters)
                {
                    filesFound.AddRange(Directory.GetFiles(searchfolder, string.Format("*.{0}", filter), searchOption));
                }
            }
            catch 
            {
                MessageBox.Show(searchfolder.ToString() + " is null.");
            }
            
            return filesFound;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            firstload = true;

            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += watcher_PositionChanged;
            watcher.Start();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += @"\Gallery\";

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            // MessageBox.Show(temperature.ToString());

            

        }

        public async void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            var lat = e.Position.Location.Latitude;
            var lon = e.Position.Location.Longitude;

            RootObject myWeather = await OpenWeatherMapProxy.GetWeather(lat, lon);

            Program.Temperature = (int)myWeather.main.temp;

            if (DateTime.Now.Hour > 8 && DateTime.Now.Hour < 20)
            {
                if (myWeather.weather[0].id == 801) this.BackgroundImage = Properties.Resources._02d;  /// clouds
                else if (myWeather.weather[0].id == 802) this.BackgroundImage = Properties.Resources._03d; /// clouds
                else if (myWeather.weather[0].id == 803) this.BackgroundImage = Properties.Resources._04d; /// clouds
                else if (myWeather.weather[0].id == 804) this.BackgroundImage = Properties.Resources._04d; /// clouds
                else if (myWeather.weather[0].id == 800) this.BackgroundImage = Properties.Resources._01d; /// clear
                else if (myWeather.weather[0].id >= 200 && myWeather.weather[0].id <= 232) this.BackgroundImage = Properties.Resources._11d; /// rain
                else if (myWeather.weather[0].id >= 500 && myWeather.weather[0].id <= 504) this.BackgroundImage = Properties.Resources._09d; /// rain
                else if (myWeather.weather[0].id >= 520 && myWeather.weather[0].id <= 531) this.BackgroundImage = Properties.Resources._09d; /// rain
                else if (myWeather.weather[0].id == 511) this.BackgroundImage = Properties.Resources._13d; /// snow (freezing rain)
                else if (myWeather.weather[0].id >= 600 && myWeather.weather[0].id <= 622) this.BackgroundImage = Properties.Resources._13d; /// snow
                else if (myWeather.weather[0].id >= 701 && myWeather.weather[0].id <= 781) this.BackgroundImage = Properties.Resources._50d; /// mist
                else if (myWeather.weather[0].id >= 300 && myWeather.weather[0].id <= 321) this.BackgroundImage = Properties.Resources._09d; /// rain
            }
            else
            {
                if (myWeather.weather[0].id == 801) this.BackgroundImage = Properties.Resources._02n;  /// clouds
                else if (myWeather.weather[0].id == 802) this.BackgroundImage = Properties.Resources._03n; /// clouds
                else if (myWeather.weather[0].id == 803) this.BackgroundImage = Properties.Resources._04n; /// clouds
                else if (myWeather.weather[0].id == 804) this.BackgroundImage = Properties.Resources._04n; /// clouds
                else if (myWeather.weather[0].id == 800) this.BackgroundImage = Properties.Resources._01n; /// clear
                else if (myWeather.weather[0].id >= 200 && myWeather.weather[0].id <= 232) this.BackgroundImage = Properties.Resources._11n; /// rain
                else if (myWeather.weather[0].id >= 500 && myWeather.weather[0].id <= 504) this.BackgroundImage = Properties.Resources._09n; /// rain
                else if (myWeather.weather[0].id >= 520 && myWeather.weather[0].id <= 531) this.BackgroundImage = Properties.Resources._09n; /// rain
                else if (myWeather.weather[0].id == 511) this.BackgroundImage = Properties.Resources._13n; /// snow (freezing rain)
                else if (myWeather.weather[0].id >= 600 && myWeather.weather[0].id <= 622) this.BackgroundImage = Properties.Resources._13n; /// snow
                else if (myWeather.weather[0].id >= 701 && myWeather.weather[0].id <= 781) this.BackgroundImage = Properties.Resources._50n; /// mist
                else if (myWeather.weather[0].id >= 300 && myWeather.weather[0].id <= 321) this.BackgroundImage = Properties.Resources._09n; /// rain
            }


            /// MessageBox.Show(((int)myWeather.main.temp).ToString() + "°C" + " " + myWeather.weather[0].description, "Weather For Today", MessageBoxButtons.OK);

        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        TempBelow15 tempbelow15 = new TempBelow15();

        private void button3_Click(object sender, EventArgs e)
        {

            string coatpath = path1 + @"Coat\Cropped\";
            string tshirtspath = path1 + @"T-Shirts\Cropped\";
            string hoodiepath = path1 + @"Hoodies\Cropped\";
            string jacketpath = path1 + @"Jackets\Cropped\";
            string pantspath = path1 + @"Pants\Cropped\";
            string shirtpath = path1 + @"Shirts\Cropped\";
            string skirtpath = path1 + @"Skirts\Cropped\";
            string sweaterpath = path1 + @"Sweaters\Cropped\";


            var filters = new string[] { "png" };

            List<string> Coatpath = GetFilesFrom(coatpath, filters);
            Program.CoatsPathBelow = Coatpath;
            List<string> Tshirtpath = GetFilesFrom(tshirtspath, filters);
            Program.TshirtsPathBelow = Tshirtpath;
            List<string> Hoodiepath = GetFilesFrom(hoodiepath, filters);
            Program.HoodiesPathBelow = Hoodiepath;
            List<string> Jacketpath = GetFilesFrom(jacketpath, filters);
            Program.JacketsPathBelow = Jacketpath;
            List<string> Pantspath = GetFilesFrom(pantspath, filters);
            Program.PantsPathBelow = Pantspath;
            List<string> Skirtpath = GetFilesFrom(skirtpath, filters);
            Program.SkirtPathBelow = Skirtpath;
            List<string> Shirtpath = GetFilesFrom(shirtpath, filters);
            Program.ShirtsPathBelow = Shirtpath;
            List<string> Sweaterpath = GetFilesFrom(sweaterpath, filters);
            Program.SweatersPathBelow = Sweaterpath;


            foreach (var coats in Coatpath)
            {
                bool ok = true;
                foreach(var existent in Program.CoatsListBelow)
                {
                    if(existent == Image.FromFile(coats))
                    {
                        ok = false;
                        break;
                    }
                }
                if(ok) Program.CoatsListBelow.Add(Image.FromFile(coats));
            }

            foreach (var tshirts in Tshirtpath)
            {
                bool ok = true;
                foreach(var existent in Program.TshirtsListBelow)
                {
                    if(existent == Image.FromFile(tshirts))
                    {
                        ok = false;
                        break;
                    }
                }
               if(ok) Program.TshirtsListBelow.Add(Image.FromFile(tshirts));
            }

            foreach (var hoodies in Hoodiepath)
            {
                bool ok = true;
                foreach(var existent in Program.HoodiesListBelow)
                {
                    if(existent == Image.FromFile(hoodies))
                    {
                        ok = false;
                        break;
                    }
                }
                if(ok) Program.HoodiesListBelow.Add(Image.FromFile(hoodies));
            }

            foreach (var jackets in Jacketpath)
            {
                bool ok = true;
                foreach (var existent in Program.JacketsListBelow)
                {
                    if(existent == Image.FromFile(jackets))
                    {
                        ok = false;
                        break;
                    }
                }
                if(ok) Program.JacketsListBelow.Add(Image.FromFile(jackets));
            }

            foreach (var pants in Pantspath)
            {
                bool ok = true;
                foreach(var existent in Program.PantsListBelow)
                {
                    if(existent == Image.FromFile(pants))
                    {
                        ok = false;
                        break;
                    }
                }
                if(ok) Program.PantsListBelow.Add(Image.FromFile(pants));
            }

            foreach (var skirts in Skirtpath)
            {
                bool ok = true;
                foreach(var existent in Program.SkirtListBelow)
                {
                    if(existent == Image.FromFile(skirts))
                    {
                        ok = false;
                        break;
                    }
                }
                if(ok) Program.SkirtListBelow.Add(Image.FromFile(skirts));
            }

            foreach (var shirts in Shirtpath)
            {
                bool ok = true;
                foreach (var existent in Program.ShirtsListBelow)
                {
                    if(existent == Image.FromFile(shirts))
                    {
                        ok = false;
                        break;
                    }
                }
                if(ok) Program.ShirtsListBelow.Add(Image.FromFile(shirts));
            }

            foreach (var sweaters in Sweaterpath)
            {
                bool ok = true;
                foreach (var existent in Program.SweatersListBelow)
                {
                    if (existent == Image.FromFile(sweaters))
                    {
                        ok = false;
                        break;
                    }
                }
                if(ok) Program.SweatersListBelow.Add(Image.FromFile(sweaters));
            }

            PickMyClothes pick = new PickMyClothes();
            pick.Show();
            this.Hide();

            /*
            if(Program.Buffer.Clothes.Count == 0 && Program.Buffer.Colors.Count == 0)
            {
                MessageBox.Show("Articles is null.");
            }
            else
            {
                if(Program.Temperature <= 15)
                {
                    
                    tempbelow15.Show();
                    this.Hide();
                    // 1.jacket or coat 
                    // 2.hoodie or sweater or shirt
                    // 2.1 sweater
                    // 2.1.1 shirt or t - shirt
                    // 2.1.2 if(shirt) optional t - shirt
                    // 2.2 hoodie  ->  t - shirt
                    // 2.3 t - shirt
                    // 3.pants -> based on color
                    // based on color 

                }

                else if(Program.Temperature >= 15 && Program.Temperature <= 20)
                {

                    // 1. hoodie or sweater or shirt 
                    // 1.1 sweater
                    // 1.1.1 shirt or t - shirt
                    // 1.1.2 if(shirt) optional t- shirt
                    // 1.2 hoodie 
                    // 1.2.1 t - shirt
                    // 1.3 shirt
                    // 1.3.1 t - shirt
                    // 2. pants -> based on color
                }

                else if(Program.Temperature > 20  && Program.Temperature < 27)
                {
                    // 1. hoodie or shirt
                    // 1.1 hoodie
                    // 1.1.1 t - shirt
                    // 1.2 shirt
                    // 1.2.1 t- shirt
                    // 2. pants -> based on color
                }

            }
            */

        }

    }
}
