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

        public static int temperature = 0;

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

        private void Form1_Load(object sender, EventArgs e)
        {

            firstload = true;

            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += watcher_PositionChanged;
            watcher.Start();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += @"\Gallery\";

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        }

        public async void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            var lat = e.Position.Location.Latitude;
            var lon = e.Position.Location.Longitude;

            RootObject myWeather = await OpenWeatherMapProxy.GetWeather(lat, lon);

            temperature = (int)myWeather.main.temp;
           
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
            if(Program.Buffer.Clothes.Count == 0 && Program.Buffer.Colors.Count == 0)
            {
                MessageBox.Show("Articles is null.");
            }
            else
            {
                if(temperature <= 15)
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

                else if(temperature  >= 15 && temperature <= 20)
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

                else if(temperature > 20  && temperature < 27)
                {
                    // 1. hoodie or shirt
                    // 1.1 hoodie
                    // 1.1.1 t - shirt
                    // 1.2 shirt
                    // 1.2.1 t- shirt
                    // 2. pants -> based on color
                }

            }
            
        }

    }
}
