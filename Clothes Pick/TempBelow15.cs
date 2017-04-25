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
        public static string path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Gallery\Pants";
        public static string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Gallery\Hoodies";
        public static string path3 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Gallery\Sweaters";
        public static string path4 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Gallery\Shirts";

        string[] hoodies; 
        string[] sweaters; 
        string[] shirts;

        public string coatcolor;
        public string jacketcolor;

        public bool coatclicked = false;
        public bool jacketclicked = false;

        public Image coatimage;
        public Image jacketimage;
        

    public TempBelow15()
        {
            InitializeComponent();
        }

        private void coatbutton_Click(object sender, EventArgs e)
        {

            coatclicked = true;

            DialogResult DialogResult = MessageBox.Show("Load your preffered coat");
            if(DialogResult == DialogResult.OK)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                path += @"\Gallery\Coats\Cropped\";

                ofd.InitialDirectory = path;

                ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if(ofd.ShowDialog() == DialogResult.OK)
                {

                    coatimage = new Bitmap(ofd.FileName);

                    string resultString = Regex.Match(ofd.FileName, @"\d+").Value;

                    string coatname = "Coat " + resultString;

                    var index = Program.Buffer.Clothes.IndexOf(coatname);

                    coatcolor = Program.Buffer.Colors[index]; //coat color

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

            jacketclicked = true;

            DialogResult DialogResult = MessageBox.Show("Load your preffered jacket");
            if (DialogResult == DialogResult.OK)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                path += @"\Gallery\Jackets";

                ofd.InitialDirectory = path;

                ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    jacketimage = new Bitmap(ofd.FileName);

                    string resultString = Regex.Match(ofd.FileName, @"\d+").Value;

                    string jacketname = "Jacket " + resultString;

                    var index = Program.Buffer.Clothes.IndexOf(jacketname);

                    jacketcolor = Program.Buffer.Colors[index]; //jacket color

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

        // List of Colors
        static List<Color> clist = new List<Color>()
        {
            Color.Black,
            Color.FromArgb(204, 102, 0), Color.Brown, Color.FromArgb(49, 17, 4),
            Color.LightBlue, Color.Blue, Color.DarkBlue,
            Color.LightGreen, Color.Green, Color.DarkGreen,
            Color.FromArgb(228, 114, 151), Color.Red, Color.DarkRed,
            Color.LightYellow, Color.Yellow, Color.FromArgb(205, 149, 12),
            Color.LightGray, Color.Gray, Color.DarkGray,
            Color.FromArgb(144, 116, 225), Color.Indigo, Color.FromArgb(55, 43, 82),
            Color.FromArgb(255,192,76), Color.Orange, Color.DarkOrange,
            Color.LightPink, Color.Pink, Color.FromArgb(153,115,121),
            Color.LightCyan, Color.Cyan, Color.DarkCyan,
            Color.FromArgb(231,205,171), Color.FromArgb(222,184,135), Color.FromArgb(177,147,108),
            Color.White
        };

        // List Of Color Names
        static List<string> cnlist = new List<string>
        {
            "Black",
            "Light Brown","Brown", "Dark Brown",
            "Light Blue", "Blue", "Dark Blue",
            "Light Green", "Green", "Dark Green",
            "Light Red", "Red", "Dark Red",
            "Light Yellow", "Yellow", "Dark Yellow",
            "Light Gray", "Gray", "Dark Gray",
            "Light Indigo", "Indigo", "Dark Indigo",
            "Light Orange", "Orange", "Dark Orange",
            "Light Pink", "Pink", "Dark Pink",
            "Light Cyan", "Cyan", "Dark Cyan",
            "Light Beige", "Beige", "Dark Beige",
            "White"
        };

        //Get the Closest Color.
        static string closestColor2(List<Color> colors, Color target)
        {
            var colorDiffs = colors.Select(n => ColorDiff(n, target)).Min(n => n);
            int x = colors.FindIndex(n => ColorDiff(n, target) == colorDiffs);
            return cnlist[x];
        }

        //Distance in RGB Space
        static int ColorDiff(Color c1, Color c2)
        {
            return (int)Math.Sqrt((c1.R - c2.R) * (c1.R - c2.R)
                                   + (c1.G - c2.G) * (c1.G - c2.G)
                                   + (c1.B - c2.B) * (c1.B - c2.B));
        }

        public string GetDominantColor(string inputFile, int k)
        {
            using (Image image = Image.FromFile(inputFile))
            {
                const int maxResizedDimension = 200;
                Size resizedSize;
                if (image.Width > image.Height)
                {
                    resizedSize = new Size(maxResizedDimension, (int)Math.Floor((image.Height / (image.Width * 1.0f)) * maxResizedDimension));
                }
                else
                {
                    resizedSize = new Size((int)Math.Floor((image.Width / (image.Width * 1.0f)) * maxResizedDimension), maxResizedDimension);
                }

                using (Bitmap resized = new Bitmap(image, resizedSize))
                {
                    List<Color> colors = new List<Color>(resized.Width * resized.Height);
                    for (int x = 0; x < resized.Width; x++)
                    {
                        for (int y = 0; y < resized.Height; y++)
                        {
                            colors.Add(resized.GetPixel(x, y));
                        }
                    }

                    KMeansClusteringCalculator clustering = new KMeansClusteringCalculator();
                    IList<Color> dominantColours = clustering.Calculate(k, colors, 5.0d);

                    Console.WriteLine("Dominant colours for {0}:", inputFile);
                    foreach (Color color in dominantColours)
                    {
                        return closestColor2(clist, color);
                    }

                    const int swatchHeight = 20;
                    using (Bitmap bmp = new Bitmap(resized.Width, resized.Height + swatchHeight))
                    {
                        using (Graphics gfx = Graphics.FromImage(bmp))
                        {
                            gfx.DrawImage(resized, new Rectangle(0, 0, resized.Width, resized.Height));

                            int swatchWidth = (int)Math.Floor(bmp.Width / (k * 1.0f));
                            for (int i = 0; i < k; i++)
                            {
                                using (SolidBrush brush = new SolidBrush(dominantColours[i]))
                                {
                                    gfx.FillRectangle(brush, new Rectangle(i * swatchWidth, resized.Height, swatchWidth, swatchHeight));
                                }
                            }
                        }

                        string outputFile = string.Format("{0}.output.png", Path.GetFileNameWithoutExtension(inputFile));
                    }

                }

            }
            return null;

        }

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

            //coatclicked

            List<string> rightcolors = new List<string>();

            if(coatclicked)
            {
                rightcolors = GetRightColor(coatcolor);
            }

            //jacketclicked

            if(jacketclicked)
            {
                rightcolors = GetRightColor(jacketcolor);
            }

            string rightsweater;
            bool exists = false;

            foreach (string myFile in Directory.GetFiles(path3, "*.png", SearchOption.AllDirectories))
            {
                rightsweater = GetDominantColor(myFile, 1);
                exists = false;
                foreach (string s in rightcolors)
                    if (rightsweater == s)
                    {
                        exists = true;
                        break;
                    }
                if (exists)
                {
                    Program.SweatersListBelow.Add(Image.FromFile(myFile));
                    Program.SweatersPathBelow.Add(myFile);
                }

            }

            foreach(Image image in Program.SweatersListBelow)
            {
                pictureBox1.Image = image;
            }

            
        }

        private void shirtbutton_Click(object sender, EventArgs e)
        {
            label2.Text = "Pick your color for your shirt.";
            shirtclicked = true;
            sweaterbutton.Visible = false;
            shirtbutton.Visible = false;
            hoodiebutton.Visible = false;
            pictureBox1.Visible = true;
            nextbutton.Visible = true;
            previousbutton.Visible = true;

            //coatclicked

            List<string> rightcolors = new List<string>();

            if (coatclicked)
            {
                rightcolors = GetRightColor(coatcolor);
            }

            //jacketclicked

            if (jacketclicked)
            {
                rightcolors = GetRightColor(jacketcolor);
            }

            string rightshirt;
            bool exists = false;



            foreach (string myFile in Directory.GetFiles(path4, "*.png", SearchOption.AllDirectories))
            {
                rightshirt = GetDominantColor(myFile, 1);
                exists = false;
                foreach (string s in rightcolors)
                    if (rightshirt == s)
                    {
                        exists = true;
                        break;
                    }
                if (exists)
                {
                    Program.ShirtsListBelow.Add(Image.FromFile(myFile));
                    Program.ShirtsPathBelow.Add(myFile);
                }

            }

            foreach (Image image in Program.ShirtsListBelow)
            {
                pictureBox1.Image = image;
            }
        }

        private void hoodiebutton_Click(object sender, EventArgs e)
        {
            label2.Text = "Pick your color for your hoodie.";
            hoodieclicked = true;
            sweaterbutton.Visible = false;
            shirtbutton.Visible = false;
            hoodiebutton.Visible = false;
            pictureBox1.Visible = true;
            nextbutton.Visible = true;
            previousbutton.Visible = true;

            //coatclicked

            List<string> rightcolors = new List<string>();

            if (coatclicked)
            {
                rightcolors = GetRightColor(coatcolor);
            }

            //jacketclicked

            if (jacketclicked)
            {
                rightcolors = GetRightColor(jacketcolor);
            }

            string righthoodie;
            bool exists = false;

            foreach (string myFile in Directory.GetFiles(path2, "*.png", SearchOption.AllDirectories))
            {
                righthoodie = GetDominantColor(myFile, 1);
                exists = false;
                foreach (string s in rightcolors)
                    if (righthoodie == s)
                    {
                        exists = true;
                        break;
                    }
                if (exists)
                {
                    Program.HoodiesListBelow.Add(Image.FromFile(myFile));
                    Program.HoodiesPathBelow.Add(myFile);
                }

            }

            foreach (Image image in Program.HoodiesListBelow)
            {
                pictureBox1.Image = image;
            }
        }

        public int i = 0;
        public bool pictureBox1clicked = false;

        private void nextbutton_Click(object sender, EventArgs e)
        {
            if (sweaterclicked)
            {
                if (Program.SweatersListBelow.Count != 1 || Program.SweatersListBelow.Count == 0)
                {
                    ++i;
                    if (i >= Program.SweatersListBelow.Count - 1)
                    {
                        i = 0;
                        pictureBox1.Image = Program.SweatersListBelow[i];
                    }
                    else pictureBox1.Image = Program.SweatersListBelow[i];
                }
                else pictureBox1.Image = Program.SweatersListBelow[i];
            }
            else if (shirtclicked)
            {
                if (Program.ShirtsListBelow.Count != 1 || Program.ShirtsListBelow.Count == 0)
                {
                    ++i;
                    if (i >= Program.ShirtsListBelow.Count - 1)
                    {
                        i = 0;
                        pictureBox1.Image = Program.ShirtsListBelow[i];
                    }
                    else pictureBox1.Image = Program.ShirtsListBelow[i];
                }
                else pictureBox1.Image = Program.ShirtsListBelow[i];
            }
            else if (hoodieclicked)
            {
                if (Program.HoodiesListBelow.Count != 1 || Program.HoodiesListBelow.Count == 0)
                {
                    ++i;
                    if (i >= Program.HoodiesListBelow.Count - 1)
                    {
                        i = 0;
                        pictureBox1.Image = Program.HoodiesListBelow[i];
                    }
                    else pictureBox1.Image = Program.HoodiesListBelow[i];
                }
                else pictureBox1.Image = Program.HoodiesListBelow[i];
            }
         
        }

        private void previousbutton_Click(object sender, EventArgs e)
        {
            if (sweaterclicked)
            {
                if (Program.SweatersListBelow.Count != 1 || Program.SweatersListBelow.Count == 0)
                {
                    --i;
                    if (i < 0)
                    {
                        i = Program.SweatersListBelow.Count - 1;
                        pictureBox1.Image = Program.SweatersListBelow[i];
                    }
                } 
                else pictureBox1.Image = Program.SweatersListBelow[i];
            }
            else if (shirtclicked)
            {
                
                if (Program.ShirtsListBelow.Count != 1 || Program.ShirtsListBelow.Count == 0)
                {
                    --i;
                    if (i < 0)
                    {
                        i = Program.ShirtsListBelow.Count - 1;
                        pictureBox1.Image = Program.ShirtsListBelow[i];
                    }
                }
                else pictureBox1.Image = Program.ShirtsListBelow[i];
            }
            else if(hoodieclicked)
            {
                
                if (Program.HoodiesListBelow.Count != 1 || Program.HoodiesListBelow.Count == 0)
                {
                    --i;
                    if (i < 0)
                    {
                        i = Program.ShirtsListBelow.Count - 1;
                        pictureBox1.Image = Program.HoodiesListBelow[Program.ShirtsListBelow.Count - 1];
                    }
                }
                else pictureBox1.Image = Program.HoodiesListBelow[i];
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
            if (color == "Black")
            {
                AddToList(Colors, "Light Brown", "Brown", "Dark Brown", "Blue", "Dark Blue", "Dark Green", "Green", "Red", "Dark Red", "Light Red",
                                "Light Grey", "Dark Grey", "Grey", "Light Indigo", "Indigo", "Dark Indigo", "Orange", "Dark Orange", "Dark Pink", "Light Cyan",
                                "Cyan", "Dark Cyan", "Light Beige", "Beige", "Dark Beige", "White", "Black");
            }
            else if (color == "Light Brown")
            {
                AddToList(Colors, "Black", "Light Brown", "Brown", "Dark Brown", "Light Blue", "Light Beige", "Beige", "Dark Beige", "Dark Red", "Red",
                                "Light Grey", "Grey", "Dark Grey", "White", "Dark Blue", "Indigo", "Dark Indigo");
            }
            else if (color == "Brown")
            {
                AddToList(Colors, "Black", "Light Brown", "Brown", "Dark Brown", "Dark Blue", "Dark Grey", "Grey", "White", "Light Beige", "Beige", "Dark Beige");
            }
            else if (color == "Dark Brown")
            {
                AddToList(Colors, "Light Brown", "Brown", "Dark Brown", "Black", "Dark Blue", "Light Beige", "Beige", "Dark Beige", "White", "Dark Grey", "Grey");
            }
            else if (color == "Light Blue")
            {
                AddToList(Colors, "Light Blue", "Blue", "Dark Blue", "Light Brown", "Dark Red", "Blue", "Dark Blue", "White", "Light Grey", "Grey", "Dark Grey");
            }
            else if (color == "Blue")
            {
                AddToList(Colors, "Light Blue", "Blue", "Dark Blue", "Black", "White", "Dark Blue", "Light Grey", "Grey", "Dark Grey");
            }
            else if (color == "Dark Blue")
            {
                AddToList(Colors, "Black", "Light Brown", "Brown", "Dark Brown", "Light Blue", "Blue", "Dark Blue",
                                  "Light Green", "Green", "Dark Green", "Light Red", "Red", "Dark Red", "Light Yellow", "Yellow", "Dark Yellow",
                                  "Light Gray", "Gray", "Dark Gray", "Light Indigo", "Indigo", "Dark Indigo", "Light Orange", "Orange", "Dark Orange",
                                  "Light Pink", "Pink", "Dark Pink", "Light Cyan", "Cyan", "Dark Cyan", "Light Beige", "Beige", "Dark Beige",
                                  "White");
            }
            else if (color == "Light Green")
            {
                AddToList(Colors, "Light Green", "Green", "Dark Green", "Orange", "White", "Light Beige", "Beige", "Dark Beige", "Light Brown");
            }
            else if (color == "Green")
            {
                AddToList(Colors, "Light Green", "Green", "Dark Green", "Black", "White", "Light Beige", "Beige", "Dark Beige", "Light Grey", "Grey", "Dark Grey");
            }
            else if (color == "Dark Green")
            {
                AddToList(Colors, "Light Green", "Green", "Dark Green", "Black", "Dark Red", "Light Beige", "Beige", "Dark Beige", "Light Grey", "Grey", "Dark Grey");
            }
            else if (color == "Light Red")
            {
                AddToList(Colors, "Light Red", "Red", "Dark Red", "Black", "Light Beige", "Beige", "Dark Beige", "White", "Grey", "Light Grey", "Dark Grey");
            }
            else if (color == "Red")
            {
                AddToList(Colors, "Light Red", "Red", "Dark Red", "Black", "Light Beige", "Beige", "Dark Beige", "White", "Light Grey", "Grey");
            }
            else if (color == "Dark Red")
            {
                AddToList(Colors, "Light Red", "Red", "Dark Red", "Light Blue", "Light Brown", "Light Beige", "Beige", "Dark Beige", "Light Grey", "Grey", "Dark Grey", "Green",
                                   "Dark Green", "White", "Black", "Dark Yellow");
            }
            else if (color == "Light Yellow")
            {
                AddToList(Colors, "Black", "Light Brown", "Brown", "Dark Brown", "Light Blue", "Light Green", "Light Red", "Red", "Dark Red", 
                                  "Light Yellow", "Yellow", "Dark Yellow", "Light Grey", "Grey", "Dark Grey", "Light Beige", "Beige", "Dark Beige", "White");
            }
            else if (color == "Yellow")
            {
                AddToList(Colors, "Black", "Light Brown", "Brown", "Dark Brown", "Light Blue", "Light Green", "Light Red", "Red", "Dark Red", "Light Yellow", "Yellow", "Dark Yellow",
                                   "Light Grey", "Grey", "Dark Grey", "Light Beige", "Beige", "Dark Beige", "White");
            }
            else if (color == "Dark Yellow")
            {
                AddToList(Colors, "Black", "Light Brown", "Brown", "Dark Brown", "Light Blue", "Light Green", 
                                  "Light Red", "Red", "Dark Red", "Light Yellow", "Yellow", "Dark Yellow", "Light Grey", "Grey", "Dark Grey", "Light Beige", "Beige", "Dark Beige", "White");
            }
            else if (color == "Light Grey" || color == "Grey" || color == "Dark Grey")
            {
                AddToList(Colors, "Black",
                    "Light Brown", "Brown", "Dark Brown", "Light Blue", "Blue", "Dark Blue",
                    "Light Green", "Green", "Dark Green", "Light Red", "Red", "Dark Red", "Light Yellow", "Yellow", "Dark Yellow",
                    "Light Gray", "Gray", "Dark Gray", "Light Indigo", "Indigo", "Dark Indigo", "Light Orange", "Orange", "Dark Orange",
                    "Light Pink", "Pink", "Dark Pink", "Light Cyan", "Cyan", "Dark Cyan", "Light Beige", "Beige", "Dark Beige",
                    "White");
            }
            else if (color == "Light Indigo" || color == "Indigo" || color == "Dark Indigo")
            {
                AddToList(Colors, "Light Indigo", "Indigo", "Dark Indigo", "Light Grey", "Grey", "Dark Grey", "White", "Black");
            }
            else if (color == "Light Orange")
            {
                AddToList(Colors, "Light Orange", "Orange", "Dark Orange", "Light Grey", "Grey", "Dark Grey", "Light Beige", "Beige", "Dark Beige", "White");
            }
            else if (color == "Orange")
            {
                AddToList(Colors, "Light Orange", "Orange", "Dark Orange", "Light Beige", "Beige", "Dark Beige", "Light Grey", "Grey", "Dark Grey", "White", "Black");
            }
            else if (color == "Dark Orange")
            {
                AddToList(Colors, "Light Orange", "Orange", "Dark Orange", "Dark Red", "Light Grey", "Grey", "Dark Grey", "Light Beige", "Beige", "Dark Beige", "Black", "White", "Dark Blue");
            }
            else if (color == "Light Pink")
            {
                AddToList(Colors, "Light Pink", "Pink", "Dark Pink", "Light Grey", "Grey", "Dark Grey", "Light Beige", "Beige", "Dark Beige", "Light Red", "Red", "Dark Red", "Black", "White", "Dark Blue");
            }
            else if (color == "Pink")
            {
                AddToList(Colors, "Light Pink", "Pink", "Dark Pink", "Black", "White", "Dark Blue");
            }
            else if (color == "Dark Pink")
            {
                AddToList(Colors, "Light Pink", "Pink", "Dark Pink", "Black", "White", "Light Grey", "Grey", "Dark Grey");
            }
            else if (color == "Light Cyan")
            {
                AddToList(Colors, "Light Cyan", "Cyan", "Dark Cyan", "White", "Light Beige", "Beige", "Dark Beige");
            }
            else if (color == "Cyan")
            {
                AddToList(Colors, "Light Cyan", "Cyan", "Dark Cyan", "White", "Dark Blue", "Black", "Light Beige", "Beige", "Dark Beige");
            }
            else if (color == "Dark Cyan")
            {
                AddToList(Colors, "Light Cyan", "Cyan", "Dark Cyan", "White", "Black", "Light Beige", "Beige", "Dark Beige");
            }
            else if (color == "Light Beige" || color == "Beige" || color == "Dark Beige")
            {
                AddToList(Colors, "Black",
                    "Light Brown", "Brown", "Dark Brown", "Light Blue", "Blue", "Dark Blue",
                    "Light Green", "Green", "Dark Green", "Light Red", "Red", "Dark Red", "Light Yellow", "Yellow", "Dark Yellow",
                    "Light Gray", "Gray", "Dark Gray", "Light Indigo", "Indigo", "Dark Indigo", "Light Orange", "Orange", "Dark Orange",
                    "Light Pink", "Pink", "Dark Pink", "Light Cyan", "Cyan", "Dark Cyan", "Light Beige", "Beige", "Dark Beige",
                    "White");
            }
            else if (color == "White")
            {
                AddToList(Colors, "Black",
                    "Light Brown", "Brown", "Dark Brown", "Light Blue", "Blue", "Dark Blue",
                    "Light Green", "Green", "Dark Green", "Light Red", "Red", "Dark Red", "Light Yellow", "Yellow", "Dark Yellow",
                    "Light Gray", "Gray", "Dark Gray", "Light Indigo", "Indigo", "Dark Indigo", "Light Orange", "Orange", "Dark Orange",
                    "Light Pink", "Pink", "Dark Pink", "Light Cyan", "Cyan", "Dark Cyan", "Light Beige", "Beige", "Dark Beige",
                    "White");
            }

            return Colors;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            pictureBox1clicked = true;

            pictureBox1.Visible = false;

            label1.Visible = true;
            label1.Text = "Here are the recommended outfits for you:";
            label2.Visible = false;
            label1.Location = new Point(91, 33);

            nextbutton.Visible = false;
            previousbutton.Visible = false;

            pantsNext.Visible = true;
            pantsPrevious.Visible = true;

            if (sweaterclicked)
            {
                if(coatclicked)
                {
                    Image clickedsweater;
                    clickedsweater = Program.SweatersListBelow[i];

                    string clickedsweaterColor;
                    clickedsweaterColor = GetDominantColor(Program.SweatersPathBelow[i], 1);

                    OverTopBox.Visible = true;
                    topBox.Visible = true;
                    pantsBox.Visible = true;

                    OverTopBox.Image = coatimage;
                    topBox.Image = clickedsweater;

                    List<string> rightcolors = new List<string>();

                    rightcolors = GetRightColor(clickedsweaterColor);

                    string rightpants;
                    bool exists = false;

                    path1 += @"\Cropped";

                    foreach(string myFile in Directory.GetFiles(path1, "*.png", SearchOption.AllDirectories))
                    {
                        rightpants = GetDominantColor(myFile, 1);
                        exists = false;
                        foreach (string s in rightcolors)
                            if (rightpants == s)
                            {
                                exists = true;
                                break;
                            }
                        if (exists)
                        {
                            Program.PantsListBelow.Add(Image.FromFile(myFile));
                            Program.PantsPathBelow.Add(myFile);
                        }
                    }

                    foreach(Image pantsimage in Program.PantsListBelow)
                    {
                        pantsBox.Image = pantsimage;
                    }

                }
                else if(jacketclicked)
                {
                    Image clickedsweater;
                    clickedsweater = Program.SweatersListBelow[i];

                    string clickedsweaterColor = GetDominantColor(Program.SweatersPathBelow[i], 1);

                    OverTopBox.Visible = true;
                    topBox.Visible = true;
                    pantsBox.Visible = true;

                    OverTopBox.Image = jacketimage;
                    topBox.Image = clickedsweater;

                    List<string> rightcolors = new List<string>();

                    rightcolors = GetRightColor(clickedsweaterColor);

                    string rightpants;
                    bool exists = false;

                    path1 += @"\Cropped";

                    foreach (string myFile in Directory.GetFiles(path1, "*.png", SearchOption.AllDirectories))
                    {
                        rightpants = GetDominantColor(myFile, 1);
                        exists = false;
                        foreach (string s in rightcolors)
                            if (rightpants == s)
                            {
                                exists = true;
                                break;
                            }
                        if (exists)
                        {
                            Program.PantsListBelow.Add(Image.FromFile(myFile));
                            Program.PantsPathBelow.Add(myFile);
                        }
                    }

                    foreach (Image pantsimage in Program.PantsListBelow)
                    {
                        pantsBox.Image = pantsimage;
                    }

                }
                
            }
            else if(shirtclicked)
            {
                if(coatclicked)
                {
                    Image clickedshirt;
                    clickedshirt = Program.ShirtsListBelow[i];

                    string clickedshirtColor = GetDominantColor(Program.ShirtsPathBelow[i] , 1);

                    OverTopBox.Visible = true;
                    topBox.Visible = true;
                    pantsBox.Visible = true;

                    OverTopBox.Image = coatimage;
                    topBox.Image = clickedshirt;

                    List<string> rightcolors = new List<string>();

                    rightcolors = GetRightColor(clickedshirtColor);

                    string rightpants;
                    bool exists = false;

                    path1 += @"\Cropped";

                    foreach (string myFile in Directory.GetFiles(path1, "*.png", SearchOption.AllDirectories))
                    {
                        rightpants = GetDominantColor(myFile, 1);
                        exists = false;
                        foreach (string s in rightcolors)
                            if (rightpants == s)
                            {
                                exists = true;
                                break;
                            }
                        if (exists)
                        {
                            Program.PantsListBelow.Add(Image.FromFile(myFile));
                            Program.PantsPathBelow.Add(myFile);
                        }
                    }

                    foreach (Image pantsimage in Program.PantsListBelow)
                    {
                        pantsBox.Image = pantsimage;
                    }

                }
                else if(jacketclicked)
                {
                    Image clickedshirt;
                    clickedshirt = Program.ShirtsListBelow[i];

                    string clickedshirtColor = GetDominantColor(Program.ShirtsPathBelow[i], 1);

                    OverTopBox.Visible = true;
                    topBox.Visible = true;
                    pantsBox.Visible = true;

                    OverTopBox.Image = jacketimage;
                    topBox.Image = clickedshirt;

                    List<string> rightcolors = new List<string>();

                    rightcolors = GetRightColor(clickedshirtColor);

                    string rightpants;
                    bool exists = false;

                    path1 += @"\Cropped";

                    foreach (string myFile in Directory.GetFiles(path1, "*.png", SearchOption.AllDirectories))
                    {
                        rightpants = GetDominantColor(myFile, 1);
                        exists = false;
                        foreach (string s in rightcolors)
                            if (rightpants == s)
                            {
                                exists = true;
                                break;
                            }
                        if (exists)
                        {
                            Program.PantsListBelow.Add(Image.FromFile(myFile));
                            Program.PantsPathBelow.Add(myFile);
                        }
                    }

                    foreach (Image pantsimage in Program.PantsListBelow)
                    {
                        pantsBox.Image = pantsimage;
                    }
                }


            }
            else if(hoodieclicked)
            {
                if(coatclicked)
                {
                    Image clickedhoodie;
                    clickedhoodie = Program.HoodiesListBelow[i];

                    string clickedhoodieColor = GetDominantColor(Program.HoodiesPathBelow[i], 1);

                    OverTopBox.Visible = true;
                    topBox.Visible = true;
                    pantsBox.Visible = true;

                    OverTopBox.Image = coatimage;
                    topBox.Image = clickedhoodie;

                    List<string> rightcolors = new List<string>();

                    rightcolors = GetRightColor(clickedhoodieColor);

                    string rightpants;
                    bool exists = false;

                    path1 += @"\Cropped";

                    foreach (string myFile in Directory.GetFiles(path1, "*.png", SearchOption.AllDirectories))
                    {
                        rightpants = GetDominantColor(myFile, 1);
                        exists = false;
                        foreach (string s in rightcolors)
                            if (rightpants == s)
                            {
                                exists = true;
                                break;
                            }
                        if (exists)
                        {
                            Program.PantsListBelow.Add(Image.FromFile(myFile));
                            Program.PantsPathBelow.Add(myFile);
                        }
                    }

                    foreach (Image pantsimage in Program.PantsListBelow)
                    {
                        pantsBox.Image = pantsimage;
                    }
                }
                else if(jacketclicked)
                {
                    Image clickedhoodie;
                    clickedhoodie = Program.HoodiesListBelow[i];

                    string clickedhoodieColor = GetDominantColor(Program.HoodiesPathBelow[i], 1);

                    OverTopBox.Visible = true;
                    topBox.Visible = true;
                    pantsBox.Visible = true;

                    OverTopBox.Image = jacketimage;
                    topBox.Image = clickedhoodie;

                    List<string> rightcolors = new List<string>();

                    rightcolors = GetRightColor(clickedhoodieColor);

                    string rightpants;
                    bool exists = false;

                    path1 += @"\Cropped";

                    foreach (string myFile in Directory.GetFiles(path1, "*.png", SearchOption.AllDirectories))
                    {
                        rightpants = GetDominantColor(myFile, 1);
                        exists = false;
                        foreach (string s in rightcolors)
                            if (rightpants == s)
                            {
                                exists = true;
                                break;
                            }
                        if (exists)
                        {
                            Program.PantsListBelow.Add(Image.FromFile(myFile));
                            Program.PantsPathBelow.Add(myFile);
                        }
                    }

                    foreach (Image pantsimage in Program.PantsListBelow)
                    {
                        pantsBox.Image = pantsimage;
                    }
                }
            }
        }

        private void TempBelow15_Load(object sender, EventArgs e)
        {

            path2 += @"\Cropped";
            path3 += @"\Cropped";
            path4 += @"\Cropped";

            if (!Directory.Exists(path2)) Directory.CreateDirectory(path2);
            if (!Directory.Exists(path3)) Directory.CreateDirectory(path3);
            if (!Directory.Exists(path4)) Directory.CreateDirectory(path4);

            hoodies = Directory.GetFiles(path2);
            sweaters = Directory.GetFiles(path3);
            shirts = Directory.GetFiles(path4);

        }

        public int k = 0;
        
        private void pantsNext_Click(object sender, EventArgs e)
        {
                if (Program.PantsListBelow.Count != 1)
                {
                    ++k;
                    if (k >= Program.PantsListBelow.Count - 1)
                    {
                        k = 0;
                        pantsBox.Image = Program.PantsListBelow[k];
                    }
                    else pantsBox.Image = Program.PantsListBelow[k];
                }
                else pantsBox.Image = Program.PantsListBelow[0];
        }

        private void pantsPrevious_Click(object sender, EventArgs e)
        {
            if (Program.PantsListBelow.Count != 1)
            {
                --k;
                if (k < 0)
                {
                    k = Program.PantsListBelow.Count - 1;
                    pantsBox.Image = Program.PantsListBelow[k];
                }
                else pantsBox.Image = Program.PantsListBelow[k];
            }
            else pantsBox.Image = Program.PantsListBelow[0];
        }

        private void topBox_Click(object sender, EventArgs e)
        {

        }
    }
}
