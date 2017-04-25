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
    public partial class PickMyClothes : Form
    {

        Dictionary<int, List<Image>> Outfits = new Dictionary<int, List<Image>>();

        List<Image> TempBelow15PantsList = new List<Image>();
        List<Image> TempBelow15OverTopList = new List<Image>();
        List<Image> TempBelow15TopList = new List<Image>();

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

        void TempBetweenClothes()
        {
            foreach (var i in Program.PantsPathBelow)
            {
                if(Program.hoodie)
                {
                    foreach(var j in Program.HoodiesPathBelow)
                    {
                        string topcolor = GetDominantColor(j, 1);
                        string pantscolor = GetDominantColor(i, 1);

                        List<string> RightPants = GetRightColor(pantscolor);
                        List<string> RightTop = GetRightColor(topcolor);

                        foreach (var x in RightPants)
                        {
                            foreach (var y in RightTop)
                            {
                                if (x == y)
                                {
                                    int index1 = Program.PantsPathBelow.IndexOf(i);
                                    int index2 = Program.HoodiesPathBelow.IndexOf(j);

                                    TempBelow15PantsList.Add(Program.PantsListBelow[index1]);
                                    TempBelow15TopList.Add(Program.HoodiesListBelow[index2]);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                else if(Program.shirt)
                {
                    foreach(var j in Program.ShirtsPathBelow)
                    {
                        string topcolor = GetDominantColor(j, 1);
                        string pantscolor = GetDominantColor(i, 1);

                        List<string> RightPants = GetRightColor(pantscolor);
                        List<string> RightTop = GetRightColor(topcolor);

                        foreach (var x in RightPants)
                        {
                            foreach (var y in RightTop)
                            {
                                if (x == y)
                                {
                                    int index1 = Program.PantsPathBelow.IndexOf(i);
                                    int index2 = Program.ShirtsPathBelow.IndexOf(j);

                                    TempBelow15PantsList.Add(Program.PantsListBelow[index1]);
                                    TempBelow15TopList.Add(Program.ShirtsListBelow[index2]);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                else if(Program.sweater)
                {
                    foreach(var j in Program.SweatersPathBelow)
                    {
                        string topcolor = GetDominantColor(j, 1);
                        string pantscolor = GetDominantColor(i, 1);

                        List<string> RightPants = GetRightColor(pantscolor);
                        List<string> RightTop = GetRightColor(topcolor);

                        foreach (var x in RightPants)
                        {
                            foreach (var y in RightTop)
                            {
                                if (x == y)
                                {
                                    int index1 = Program.PantsPathBelow.IndexOf(i);
                                    int index2 = Program.SweatersPathBelow.IndexOf(j);

                                    TempBelow15PantsList.Add(Program.PantsListBelow[index1]);
                                    TempBelow15TopList.Add(Program.SweatersListBelow[index2]);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }

        void TempBelow15Clothes()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            int n = Directory.GetFiles(path + @"\Gallery\Pants\Cropped\", "*", SearchOption.TopDirectoryOnly).Length;
            int m;
            if(Program.coat) m = Directory.GetFiles(path + @"\Gallery\Coats\Cropped\", "*", SearchOption.TopDirectoryOnly).Length;
            else m = Directory.GetFiles(path + @"\Gallery\Jackets\Cropped\", "*", SearchOption.TopDirectoryOnly).Length;
            int t;
            if (Program.hoodie) t = Directory.GetFiles(path + @"\Gallery\Hoodies\Cropped\", "*", SearchOption.TopDirectoryOnly).Length;
            else if(Program.shirt) t = Directory.GetFiles(path + @"\Gallery\Shirts\Cropped\", "*", SearchOption.TopDirectoryOnly).Length;
            else t = Directory.GetFiles(path + @"\Gallery\Sweaters\Cropped\", "*", SearchOption.TopDirectoryOnly).Length;

            foreach (var i in Program.PantsPathBelow)
            {
                if(Program.coat)
                {
                    foreach(var j in Program.CoatsPathBelow)
                    {
                        if(Program.hoodie)
                            foreach(var k in Program.HoodiesPathBelow)
                            {
                                string pantscolor = GetDominantColor(i, 1);
                                string topcolor = GetDominantColor(k, 1);
                                string overtopcolor = GetDominantColor(j, 1);

                                List<string> RightPants = GetRightColor(pantscolor);
                                List<string> RightTop = GetRightColor(topcolor);
                                List<string> RightOverTop = GetRightColor(overtopcolor);

                                foreach (var x in RightPants)
                                {
                                    foreach (var y in RightTop)
                                    {
                                        foreach (var z in RightOverTop)
                                        {
                                            if (x == y && y == z)
                                            {
                                                int index1 = Program.PantsPathBelow.IndexOf(i);
                                                int index2 = Program.CoatsPathBelow.IndexOf(j);
                                                int index3 = Program.HoodiesPathBelow.IndexOf(k);
                                                TempBelow15PantsList.Add(Program.PantsListBelow[index1]);
                                                TempBelow15OverTopList.Add(Program.CoatsListBelow[index2]);
                                                TempBelow15TopList.Add(Program.HoodiesListBelow[index3]);
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    break;
                                }
                            }
                        
                        else if(Program.shirt)
                            foreach(var k in Program.ShirtsPathBelow)
                            {
                                string pantscolor = GetDominantColor(i, 1);
                                string topcolor = GetDominantColor(k, 1);
                                string overtopcolor = GetDominantColor(j, 1);

                                List<string> RightPants = GetRightColor(pantscolor);
                                List<string> RightTop = GetRightColor(topcolor);
                                List<string> RightOverTop = GetRightColor(overtopcolor);

                                foreach (var x in RightPants)
                                {
                                    foreach (var y in RightTop)
                                    {
                                        foreach (var z in RightOverTop)
                                        {
                                            if (x == y && y == z)
                                            {
                                                int index1 = Program.PantsPathBelow.IndexOf(i);
                                                int index2 = Program.CoatsPathBelow.IndexOf(j);
                                                int index3 = Program.ShirtsPathBelow.IndexOf(k);
                                                TempBelow15PantsList.Add(Program.PantsListBelow[index1]);
                                                TempBelow15OverTopList.Add(Program.CoatsListBelow[index2]);
                                                TempBelow15TopList.Add(Program.ShirtsListBelow[index3]);
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    break;
                                }
                            }
                        
                        else if(Program.sweater)
                            foreach(var k in Program.SweatersPathBelow)
                            {
                                string pantscolor = GetDominantColor(i, 1);
                                string topcolor = GetDominantColor(k, 1);
                                string overtopcolor = GetDominantColor(j, 1);

                                List<string> RightPants = GetRightColor(pantscolor);
                                List<string> RightTop = GetRightColor(topcolor);
                                List<string> RightOverTop = GetRightColor(overtopcolor);

                                foreach (var x in RightPants)
                                {
                                    foreach (var y in RightTop)
                                    {
                                        foreach (var z in RightOverTop)
                                        {
                                            if (x == y && y == z)
                                            {
                                                int index1 = Program.PantsPathBelow.IndexOf(i);
                                                int index2 = Program.CoatsPathBelow.IndexOf(j);
                                                int index3 = Program.SweatersPathBelow.IndexOf(k);
                                                TempBelow15PantsList.Add(Program.PantsListBelow[index1]);
                                                TempBelow15OverTopList.Add(Program.CoatsListBelow[index2]);
                                                TempBelow15TopList.Add(Program.SweatersListBelow[index3]);
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    break;
                                }
                            }
                        
                    }
                }
                else
                {
                    foreach(var j in Program.JacketsPathBelow)
                    {
                        if (Program.hoodie)
                            foreach (var k in Program.HoodiesPathBelow)
                            {
                                string pantscolor = GetDominantColor(i, 1);
                                string topcolor = GetDominantColor(k, 1);
                                string overtopcolor = GetDominantColor(j, 1);

                                List<string> RightPants = GetRightColor(pantscolor);
                                List<string> RightTop = GetRightColor(topcolor);
                                List<string> RightOverTop = GetRightColor(overtopcolor);

                                foreach (var x in RightPants)
                                {
                                    foreach (var y in RightTop)
                                    {
                                        foreach (var z in RightOverTop)
                                        {
                                            if (x == y && y == z)
                                            {
                                                int index1 = Program.PantsPathBelow.IndexOf(i);
                                                int index2 = Program.JacketsPathBelow.IndexOf(j);
                                                int index3 = Program.HoodiesPathBelow.IndexOf(k);
                                                TempBelow15PantsList.Add(Program.PantsListBelow[index1]);
                                                TempBelow15OverTopList.Add(Program.JacketsListBelow[index2]);
                                                TempBelow15TopList.Add(Program.HoodiesListBelow[index3]);
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    break;
                                }
                            }

                        else if (Program.shirt)
                            foreach (var k in Program.ShirtsPathBelow)
                            {
                                string pantscolor = GetDominantColor(i, 1);
                                string topcolor = GetDominantColor(k, 1);
                                string overtopcolor = GetDominantColor(j, 1);

                                List<string> RightPants = GetRightColor(pantscolor);
                                List<string> RightTop = GetRightColor(topcolor);
                                List<string> RightOverTop = GetRightColor(overtopcolor);

                                foreach (var x in RightPants)
                                {
                                    foreach (var y in RightTop)
                                    {
                                        foreach (var z in RightOverTop)
                                        {
                                            if (x == y && y == z)
                                            {
                                                int index1 = Program.PantsPathBelow.IndexOf(i);
                                                int index2 = Program.JacketsPathBelow.IndexOf(j);
                                                int index3 = Program.ShirtsPathBelow.IndexOf(k);
                                                TempBelow15PantsList.Add(Program.PantsListBelow[index1]);
                                                TempBelow15OverTopList.Add(Program.JacketsListBelow[index2]);
                                                TempBelow15TopList.Add(Program.ShirtsListBelow[index3]);
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    break;
                                }
                            }

                        else if (Program.sweater)
                            foreach (var k in Program.SweatersPathBelow)
                            {
                                string pantscolor = GetDominantColor(i, 1);
                                string topcolor = GetDominantColor(k, 1);
                                string overtopcolor = GetDominantColor(j, 1);

                                List<string> RightPants = GetRightColor(pantscolor);
                                List<string> RightTop = GetRightColor(topcolor);
                                List<string> RightOverTop = GetRightColor(overtopcolor);

                                foreach (var x in RightPants)
                                {
                                    foreach (var y in RightTop)
                                    {
                                        foreach (var z in RightOverTop)
                                        {
                                            if (x == y && y == z)
                                            {
                                                int index1 = Program.PantsPathBelow.IndexOf(i);
                                                int index2 = Program.JacketsPathBelow.IndexOf(j);
                                                int index3 = Program.SweatersPathBelow.IndexOf(k);
                                                TempBelow15PantsList.Add(Program.PantsListBelow[index1]);
                                                TempBelow15OverTopList.Add(Program.JacketsListBelow[index2]);
                                                TempBelow15TopList.Add(Program.SweatersListBelow[index3]);
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    break;
                                }
                            }
                    }
                }
            }


        }

        public PickMyClothes()
        {
            InitializeComponent();

            UnderTop.Visible = true;
            Bot.Visible = true;

            if (Program.Temperature <= 15)
            {

                OverTop.Visible = true;

                CoatOrJacket CoatorJacket = new CoatOrJacket();
                var dialogresult = CoatorJacket.ShowDialog();

                if(dialogresult == DialogResult.Yes)
                {
                    HoodieSweaterShirt HoodieOrSweaterOrShirt = new HoodieSweaterShirt();
                    var dialogresult1 = HoodieOrSweaterOrShirt.ShowDialog();
                }
                else
                {
                    HoodieSweaterShirt HoodieOrSweaterOrShirt = new HoodieSweaterShirt();
                    var dialogresult1 = HoodieOrSweaterOrShirt.ShowDialog();
                }

                if((Program.coat || Program.jacket) && (Program.shirt || Program.hoodie || Program.sweater))
                {
                    TempBelow15Clothes();

                    OverTop.Image = TempBelow15OverTopList[1];
                    UnderTop.Image = TempBelow15TopList[1];
                    Bot.Image = TempBelow15PantsList[1];

                    MessageBox.Show(TempBelow15TopList.Count + " " + TempBelow15OverTopList.Count + " " + TempBelow15PantsList.Count);
                }
            }
            else if (Program.Temperature > 15 && Program.Temperature <= 20)
            {
                HoodieSweaterShirt HoodieOrSweaterOrShirt = new HoodieSweaterShirt();
                var dialogresult1 = HoodieOrSweaterOrShirt.ShowDialog();

                if(Program.shirt || Program.hoodie || Program.sweater)
                {
                    TempBetweenClothes();
                    UnderTop.Image = TempBelow15TopList[1];
                    Bot.Image = TempBelow15PantsList[1];

                    MessageBox.Show(TempBelow15TopList.Count.ToString());
                }

            }
                Back.TabStop = false;
            Back.FlatStyle = FlatStyle.Flat;
            Back.FlatAppearance.BorderSize = 0;
            Back.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            Back.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            Back.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
        }

        Form1 main = new Form1();

        private void Back_Click(object sender, EventArgs e)
        {
            main.Show();
            this.Hide();
        }

        int index = 1;
        
        private void Next_Click(object sender, EventArgs e)
        {
            ++index;
            if (index >= TempBelow15PantsList.Count - 1) index = 1;
            if(Program.Temperature <= 15) OverTop.Image = TempBelow15OverTopList[index];
            UnderTop.Image = TempBelow15TopList[index];
            Bot.Image = TempBelow15PantsList[index];
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            --index;
            if (index < 2) index = TempBelow15PantsList.Count - 1;
            if(Program.Temperature <= 15) OverTop.Image = TempBelow15OverTopList[index];
            UnderTop.Image = TempBelow15TopList[index];
            Bot.Image = TempBelow15PantsList[index];
        }
    }
}
