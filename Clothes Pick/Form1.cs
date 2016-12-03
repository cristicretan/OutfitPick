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

        public static string path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Gallery\";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += watcher_PositionChanged;
            watcher.Start();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += @"\Gallery\";

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }

        private async void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            var lat = e.Position.Location.Latitude;
            var lon = e.Position.Location.Longitude;

            RootObject myWeather = await OpenWeatherMapProxy.GetWeather(lat, lon);

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
    }
}
