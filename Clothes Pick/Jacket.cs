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
    public partial class Jacket : Form
    {

        static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Gallery\Jackets\Cropped";
        string path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Gallery\Jackets\Cropped" + @"\image";
        int fCount = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Length;
        int aux = 0;
        PictureBox[] pb = new PictureBox[50];

        public Jacket()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ControlBox = false;
            this.Text = String.Empty;
            InitializeComponent();

        }

        private void Jacket_Load(object sender, EventArgs e)
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
