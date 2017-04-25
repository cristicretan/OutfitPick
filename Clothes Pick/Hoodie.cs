using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clothes_Pick
{
    public partial class Hoodie : Form
    {
        public Hoodie()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ControlBox = false;
            this.Text = String.Empty;
            InitializeComponent();


            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Gallery\Hoodies\Cropped";
            string path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Gallery\Hoodies\Cropped" + @"\image";
            int fCount = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Length;
            int aux = 0;
            PictureBox[] pb = new PictureBox[50];
            for (int i = 1; i <= fCount; i++)
            {
                string image = path1 + i + "cropped" + ".png";
                aux = aux + 1;
                pb[i] = new PictureBox();
                pb[i].Height = 220;
                pb[i].Width = 245;
                pb[i].BackgroundImage = Image.FromFile(image);
                pb[i].BackgroundImageLayout = ImageLayout.Zoom;
                flowLayoutPanel1.Controls.Add(pb[i]);
            }
        }
    }
}
