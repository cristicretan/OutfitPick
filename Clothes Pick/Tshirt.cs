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
    public partial class Tshirt : Form
    {

        static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Gallery\T-Shirts\Cropped";
        string path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Gallery\T-Shirts\Cropped" + @"\image";
        int fCount = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Length;
        int aux = 0;
        PictureBox[] pb = new PictureBox[50];

        public Tshirt()
        {
            InitializeComponent();
        }

        private void Tshirt_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 1; i <= fCount; i++)
                {
                    string image = path1 + i + "cropped" + ".png";
                    aux = aux + 1;
                    pb[i] = new PictureBox();
                    pb[i].InitialImage = null;
                    pb[i].BackgroundImage = null;
                    pb[i].Image = null;
                    pb[i].Height = 220;
                    pb[i].Width = 245;
                    pb[i].BackgroundImage = Image.FromFile(image);
                    pb[i].BackgroundImageLayout = ImageLayout.Zoom;
                    flowLayoutPanel1.Controls.Add(pb[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
