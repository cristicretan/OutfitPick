using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clothes_Pick
{
    public partial class TempBelow15 : Form
    {

        public static string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Gallery\Hoodies\Cropped";
        public static string path3 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Gallery\Sweaters\Cropped";
        public static string path4 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Gallery\Shirts\Cropped";

        List<Image> HoodiesList = new List<Image>();
        List<Image> SweatersList = new List<Image>();
        List<Image> ShirtsList = new List<Image>();

        public static string[] hoodies = Directory.GetFiles(path2);
        string[] sweaters = Directory.GetFiles(path3);
        string[] shirts = Directory.GetFiles(path4);

        

    public TempBelow15()
        {
            InitializeComponent();
        }

        private void coatbutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Load your preffered coat");
            if(DialogResult == DialogResult.OK)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                path += @"\Gallery\Coats";

                ofd.InitialDirectory = path;

                ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if(ofd.ShowDialog() == DialogResult.OK)
                {

                    string resultString = Regex.Match(ofd.FileName, @"\d+").Value;

                    string coatname = "Coat " + resultString;

                    var index = Program.Buffer.Clothes.IndexOf(coatname);

                    //findcolor
                    coatbutton.Visible = false;
                    jacketbutton.Visible = false;

                    if(coatbutton.Visible == false && jacketbutton.Visible == false)
                    {
                        label2.Text = "Sweater, shirt or hoodie?";
                        sweaterbutton.Visible = true;
                        shirtbutton.Visible = true;
                        hoodiebutton.Visible = true;
                    }


                }
                else
                {
                    MessageBox.Show("Please pick a coat.");
                    this.Refresh();
                }

            }



        }

        private void jacketbutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Load your preffered jacket");
            if (DialogResult == DialogResult.OK)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                path += @"\Gallery\Jackets";

                ofd.InitialDirectory = path;

                ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    string resultString = Regex.Match(ofd.FileName, @"\d+").Value;

                    string jacketname = "Jacket " + resultString;

                    var index = Program.Buffer.Clothes.IndexOf(jacketname);

                    //findcolor
                    coatbutton.Visible = false;
                    jacketbutton.Visible = false;

                    if (coatbutton.Visible == false && jacketbutton.Visible == false)
                    {
                        label2.Text = "Sweater, shirt or hoodie?";
                        sweaterbutton.Visible = true;
                        shirtbutton.Visible = true;
                        hoodiebutton.Visible = true;
                    }

                }
                else
                {
                    MessageBox.Show("Please pick a jacket.");
                    this.Refresh();
                }

            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        bool sweaterclicked = false;
        bool shirtclicked = false;
        bool hoodieclicked = false;

        private void sweaterbutton_Click(object sender, EventArgs e)
        {
            label2.Text = "Pick your color for your sweater.";
            sweaterclicked = true;
            sweaterbutton.Visible = false;
            shirtbutton.Visible = false;
            hoodiebutton.Visible = false;
            pictureBox1.Visible = true;
            nextbutton.Visible = true;
            previousbutton.Visible = true;

            foreach (string myFile in Directory.GetFiles(path3, "*.png", SearchOption.AllDirectories))
            {
                SweatersList.Add(Image.FromFile(myFile));
            }


            
        }

        private void shirtbutton_Click(object sender, EventArgs e)
        {
            label2.Text = "Pick your color for your shirt.";
            sweaterclicked = true;
            sweaterbutton.Visible = false;
            shirtbutton.Visible = false;
            hoodiebutton.Visible = false;
            pictureBox1.Visible = true;
            nextbutton.Visible = true;
            previousbutton.Visible = true;

            foreach (string myFile in Directory.GetFiles(path4, "*.png", SearchOption.AllDirectories))
            {
                ShirtsList.Add(Image.FromFile(myFile));
            }
        }

        private void hoodiebutton_Click(object sender, EventArgs e)
        {
            label2.Text = "Pick your color for your hoodie.";
            sweaterclicked = true;
            sweaterbutton.Visible = false;
            shirtbutton.Visible = false;
            hoodiebutton.Visible = false;
            pictureBox1.Visible = true;
            nextbutton.Visible = true;
            previousbutton.Visible = true;

            foreach (string myFile in Directory.GetFiles(path2, "*.png", SearchOption.AllDirectories))
            {
                HoodiesList.Add(Image.FromFile(myFile));
            }
        }

        public int i = 0;

        private void nextbutton_Click(object sender, EventArgs e)
        {
            ++i;
            if (sweaterclicked)
            {
                if (i == SweatersList.Count) i = 0;
                pictureBox1.Image = SweatersList[i];
            }
            else if (shirtclicked)
            {
                if (i == ShirtsList.Count) i = 0;
                pictureBox1.Image = ShirtsList[i];
            }
            else
            {
                if (i == HoodiesList.Count) i = 0;
                pictureBox1.Image = HoodiesList[i];
            }

            
        }

        private void previousbutton_Click(object sender, EventArgs e)
        {
            --i;
            if (sweaterclicked)
            {
                if (i == -1) i = SweatersList.Count;
                pictureBox1.Image = SweatersList[i];
            }
            else if (shirtclicked)
            {
                if (i == -1) i = ShirtsList.Count;
                pictureBox1.Image = ShirtsList[i];
            }
            else
            {
                if (i == -1) i = ShirtsList.Count;
                 pictureBox1.Image = HoodiesList[i];
            }

        }

        public void AddToList(List<string> someStringList, params string[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                someStringList.Add(list[i]);
            }
        }

        public List<string> GetRightColor(string color)
        {
            List<string> Colors = new List<string>();
            if(color == "Black")
            {
                AddToList(Colors, "Light Brown", "Brown", "Dark Brown", "Blue", "Dark Blue", "Dark Green", "Green", "Red", "Dark Red", "Light Red",
                                "Light Grey", "Dark Grey", "Grey", "Light Indigo", "Indigo", "Dark Indigo", "Orange", "Dark Orange", "Dark Pink",
                                "Cyan", "Dark Cyan", "Light Beige", "Beige", "Dark Beige", "White");
            }

            return Colors;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
