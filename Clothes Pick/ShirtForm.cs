using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clothes_Pick
{
    public partial class ShirtForm : Form
    {
        Image currentImage;

        public Pen cropPen;
        public DashStyle cropDashStyle = DashStyle.DashDot;

        int NumberOfClick = 0;

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        public DialogResult Result;

        bool button2clicked = true;

        private List<Point> Points = null;
        private bool Selecting = false;

        private Bitmap SelectedArea = null;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public static string path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Gallery\Shirts\";

        public ShirtForm()
        {
            InitializeComponent();
        }

        private void ShirtForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2clicked = true;
            NumberOfClick++;
            if (pictureBox5.Image != null)
            {
                Bitmap varBmp = new Bitmap(pictureBox5.Image);
                Bitmap newBitmap = new Bitmap(varBmp);
                pictureBox5.Visible = true;
                varBmp.Dispose();

                videoSource.Stop();
                pictureBox5.Image = newBitmap;
                pictureBox5.Invalidate();

                switch (NumberOfClick)
                {
                    case 1:
                        pictureBox1.Image = newBitmap;

                        pictureBox1.Image.Save(path1 + "image1.png", ImageFormat.Png);

                        DialogResult result = MessageBox.Show("Crop your image", "Information", MessageBoxButtons.OK);

                        if (result == DialogResult.OK)
                        {
                            pictureBox5.Visible = true;
                            button2.Visible = false;
                            pictureBox5.Image = pictureBox1.Image;
                        }

                        break;
                    case 2:
                        pictureBox2.Image = pictureBox1.Image;
                        pictureBox1.Image = newBitmap;

                        pictureBox1.Image.Save(path1 + "image2.png", ImageFormat.Png);

                        DialogResult result1 = MessageBox.Show("Crop your image", "Information", MessageBoxButtons.OK);

                        if (result1 == DialogResult.OK)
                        {
                            pictureBox5.Visible = true;
                            button2.Visible = false;
                            pictureBox5.Image = pictureBox1.Image;

                        }

                        break;
                    case 3:

                        pictureBox3.Image = pictureBox2.Image;
                        pictureBox2.Image = pictureBox1.Image;
                        pictureBox1.Image = newBitmap;

                        pictureBox5.Visible = true;
                        button2.Visible = false;
                        pictureBox5.Image = pictureBox1.Image;

                        pictureBox1.Image.Save(path1 + "image3.png", ImageFormat.Png);

                        DialogResult result2 = MessageBox.Show("Crop your image", "Information", MessageBoxButtons.OK);

                        if (result2 == DialogResult.OK)
                        {
                            pictureBox5.Visible = true;
                            button2.Visible = false;
                            pictureBox5.Image = pictureBox1.Image;

                        }

                        break;
                    case 4:

                        pictureBox5.Visible = true;
                        button2.Visible = false;

                        pictureBox4.Image = pictureBox3.Image;
                        pictureBox3.Image = pictureBox2.Image;
                        pictureBox2.Image = pictureBox1.Image;
                        pictureBox1.Image = newBitmap;

                        pictureBox1.Image.Save(path1 + "image4.png", ImageFormat.Png);

                        DialogResult result3 = MessageBox.Show("Crop your image", "Information", MessageBoxButtons.OK);

                        if (result3 == DialogResult.OK)
                        {
                            pictureBox5.Visible = true;
                            button2.Visible = false;
                            pictureBox5.Image = pictureBox1.Image;

                        }

                        break;
                    default:

                        pictureBox5.Visible = true;
                        button2.Visible = false;

                        newBitmap.Save(path1 + "image" + NumberOfClick.ToString() + ".png", ImageFormat.Png);

                        pictureBox4.Image = pictureBox3.Image;
                        pictureBox3.Image = pictureBox2.Image;
                        pictureBox2.Image = pictureBox1.Image;
                        pictureBox1.Image = newBitmap;

                        DialogResult result4 = MessageBox.Show("Crop your image", "Information", MessageBoxButtons.OK);

                        if (result4 == DialogResult.OK)
                        {
                            pictureBox5.Visible = true;
                            button2.Visible = false;
                            pictureBox5.Image = pictureBox1.Image;
                        }

                        break;
                }

            }
        }

        public void SelectImage()
        {
            Result = MessageBox.Show("Do you want to add a photo from your gallery or do you want to take a photo right now?", "Confirmation", MessageBoxButtons.YesNo);

            if (Result == DialogResult.Yes)
            {

                ++NumberOfClick;
                switch (NumberOfClick)
                {
                    case 1:
                        OpenFileDialog f = new OpenFileDialog();
                        f.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            currentImage = Image.FromFile(f.FileName);
                            pictureBox1.Image = currentImage;

                            pictureBox1.Image.Save(path1 + "image1.png", ImageFormat.Png);

                            DialogResult result = MessageBox.Show("Crop your image", "Information", MessageBoxButtons.OK);

                            if (result == DialogResult.OK)
                            {
                                pictureBox5.Visible = true;
                                pictureBox5.Image = pictureBox1.Image;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please pick a photo.");
                            Form2 frm = new Form2();
                            frm.Show();
                            this.Close();
                        }

                        break;
                    case 2:
                        OpenFileDialog f2 = new OpenFileDialog();
                        f2.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                        if (f2.ShowDialog() == DialogResult.OK)
                        {
                            currentImage = Image.FromFile(f2.FileName);
                            pictureBox2.Image = pictureBox1.Image;
                            pictureBox1.Image = currentImage;

                            pictureBox1.Image.Save(path1 + "image2.png", ImageFormat.Png);

                            DialogResult result1 = MessageBox.Show("Crop your image", "Information", MessageBoxButtons.OK);

                            if (result1 == DialogResult.OK)
                            {
                                pictureBox5.Visible = true;
                                pictureBox5.Image = pictureBox1.Image;

                            }
                        }
                        else
                        {
                            MessageBox.Show("Please pick a photo.");
                            Form2 frm = new Form2();
                            frm.Show();
                            this.Close();
                        }

                        break;
                    case 3:
                        OpenFileDialog f3 = new OpenFileDialog();
                        f3.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                        if (f3.ShowDialog() == DialogResult.OK)
                        {
                            currentImage = Image.FromFile(f3.FileName);
                            pictureBox3.Image = pictureBox2.Image;
                            pictureBox2.Image = pictureBox1.Image;
                            pictureBox1.Image = currentImage;

                            pictureBox5.Visible = true;
                            pictureBox5.Image = pictureBox1.Image;

                            pictureBox1.Image.Save(path1 + "image3.png", ImageFormat.Png);

                            DialogResult result2 = MessageBox.Show("Crop your image", "Information", MessageBoxButtons.OK);

                            if (result2 == DialogResult.OK)
                            {
                                pictureBox5.Visible = true;
                                pictureBox5.Image = pictureBox1.Image;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please pick a photo.");
                            Form2 frm = new Form2();
                            frm.Show();
                            this.Close();
                        }

                        break;
                    case 4:
                        OpenFileDialog f4 = new OpenFileDialog();
                        f4.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                        if (f4.ShowDialog() == DialogResult.OK)
                        {
                            currentImage = Image.FromFile(f4.FileName);
                            pictureBox4.Image = pictureBox3.Image;
                            pictureBox3.Image = pictureBox2.Image;
                            pictureBox2.Image = pictureBox1.Image;
                            pictureBox1.Image = currentImage;

                            pictureBox1.Image.Save(path1 + "image4.png", ImageFormat.Png);

                            DialogResult result3 = MessageBox.Show("Crop your image", "Information", MessageBoxButtons.OK);

                            if (result3 == DialogResult.OK)
                            {
                                pictureBox5.Visible = true;
                                pictureBox5.Image = pictureBox1.Image;

                            }
                        }
                        else
                        {
                            MessageBox.Show("Please pick a photo.");
                            Form2 frm = new Form2();
                            frm.Show();
                            this.Close();
                        }

                        break;
                    default:

                        OpenFileDialog f5 = new OpenFileDialog();
                        f5.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                        if (f5.ShowDialog() == DialogResult.OK)
                        {
                            currentImage = Image.FromFile(f5.FileName);

                            currentImage.Save(path1 + "image" + NumberOfClick.ToString() + ".png", ImageFormat.Png);

                            pictureBox4.Image = pictureBox3.Image;
                            pictureBox3.Image = pictureBox2.Image;
                            pictureBox2.Image = pictureBox1.Image;
                            pictureBox1.Image = currentImage;

                            DialogResult result4 = MessageBox.Show("Crop your image", "Information", MessageBoxButtons.OK);

                            if (result4 == DialogResult.OK)
                            {
                                pictureBox5.Visible = true;
                                pictureBox5.Image = pictureBox1.Image;

                            }
                        }
                        else
                        {
                            MessageBox.Show("Please pick a photo.");
                            Form2 frm = new Form2();
                            frm.Show();
                            this.Close();
                        }

                        break;
                }

            }

            if (Result == DialogResult.No)
            {

                button2clicked = false;

                if (videoSource.IsRunning)
                {
                    videoSource.Stop();
                    pictureBox5.Image = null;
                    pictureBox5.Invalidate();
                }
                else
                {
                    button2.Parent = pictureBox5;
                    pictureBox5.Visible = true;
                    button2.Visible = true;
                    comboBox1.SelectedIndex = 0;
                    videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);

                    //set New Frame Event Handler
                    videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                    videoSource.Start();
                }
            }
        }

        private void ShirtForm_Load(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += @"\Gallery\Shirts\";

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo device in videoDevices)
            {
                comboBox1.Items.Add(device.Name);
            }

            videoSource = new VideoCaptureDevice();

            SelectImage();
        }

        void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            pictureBox5.Image = image;
        }

        private static void GetDominantColor(string inputFile, int k, int NumberOfClicks)
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
                        Console.WriteLine("K: {0} (#{1:x2}{2:x2}{3:x2})", color, color.R, color.G, color.B);
                        string hex = color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
                        MessageBox.Show(hex);
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
                        bmp.Save(path1 + "dominantcolor" + NumberOfClicks.ToString() + ".png", ImageFormat.Png);
                    }

                }

            }

        }

        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            if (button2clicked == true)
            {
                Selecting = false;

                // Copy the selected area.
                SelectedArea = GetSelectedArea(pictureBox5.Image, Color.Transparent, Points);

                if (SelectedArea == null) return;

                SelectedArea.Save(path1 + "image" + NumberOfClick.ToString() + "cropped.png", ImageFormat.Png);

                string filename = path1 + "image" + NumberOfClick.ToString() + "cropped.png";
                string filep = path1 + "image" + NumberOfClick.ToString() + "cropped.png";

                GetDominantColor(filep, 3, NumberOfClick);


                if (File.Exists(filename))
                {
                    pictureBox5.Visible = false;
                }

                Points.Clear();

                if (pictureBox1.Image != null)
                {
                    DialogResult result1 = MessageBox.Show("Do you want to upload more shirts?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {
                        SelectImage();
                    }
                    else
                    {
                        Form2 frm = new Form2();
                        frm.Show();
                        this.Hide();
                    }
                }
            }
        }

        PointF zoomed(Point p1, float zoom, Point offset)
        {
            return (new PointF(p1.X * zoom + offset.X, p1.Y * zoom + offset.Y));
        }

        PointF unZoomed(Point p1, float zoom, Point offset)
        {
            return (new PointF((p1.X - offset.X) / zoom, (p1.Y - offset.Y) / zoom));
        }

        private void pictureBox5_Paint(object sender, PaintEventArgs e)
        {
            if ((Points != null) && (Points.Count > 1))
            {
                using (Pen dashed_pen = new Pen(Color.Black))
                {
                    dashed_pen.DashPattern = new float[] { 5, 5 };
                    e.Graphics.DrawLines(Pens.White, Points.ToArray());
                    e.Graphics.DrawLines(dashed_pen, Points.ToArray());
                }
            }
        }

        private Bitmap GetSelectedArea(Image source, Color bg_color, List<Point> points)
        {
            // Make a new bitmap that has the background
            // color except in the selected area.
            Bitmap big_bm = new Bitmap(source);

            PointF mDown = Point.Empty;
            PointF mLast = Point.Empty;
            float zoom = 1f;
            RectangleF ImgArea = RectangleF.Empty;

            SizeF sp = pictureBox5.ClientSize;
            SizeF si = pictureBox5.Image.Size;
            float rp = sp.Width / sp.Height;   // calculate the ratios of
            float ri = si.Width / si.Height;   // pbox and image

            if (rp > ri)
            {
                zoom = sp.Height / si.Height;
                float width = si.Width * zoom;
                float left = (sp.Width - width) / 2;
                ImgArea = new RectangleF(left, 0, width, sp.Height);
            }
            else
            {
                zoom = sp.Width / si.Width;
                float height = si.Height * zoom;
                float top = (sp.Height - height) / 2;
                ImgArea = new RectangleF(0, top, sp.Width, height);
            }

            float zoom1 = 1f * pictureBox5.ClientSize.Width / pictureBox5.Image.Width;

            float offx = (pictureBox5.ClientSize.Width - pictureBox5.Image.Width * zoom) / 2;
            float offy = (pictureBox5.ClientSize.Height - pictureBox5.Image.Height * zoom) / 2;
            Point offset = Point.Round(new PointF(offx, offy));

            List<Point> unzoomedPoints = points.Select(x => (Point.Round((unZoomed(Point.Round(x), zoom, offset))))).ToList();



            using (Graphics gr = Graphics.FromImage(big_bm))
            {

                // Set the background color.
                gr.Clear(bg_color);

                // Make a brush out of the original image.
                using (Brush br = new TextureBrush(source))
                {
                    // Fill the selected area with the brush.
                    gr.FillPolygon(br, unzoomedPoints.ToArray());

                    // Find the bounds of the selected area.
                    Rectangle source_rect = GetPointListBounds(unzoomedPoints, big_bm.Size);

                    if (source_rect == Rectangle.Empty)
                    {
                        MessageBox.Show("Nothing selected!");
                        return null;
                    }

                    // Make a bitmap that only holds the selected area.
                    Bitmap result = new Bitmap(source_rect.Width, source_rect.Height);

                    // Copy the selected area to the result bitmap.
                    using (Graphics result_gr = Graphics.FromImage(result))
                    {
                        result_gr.Clear(Color.Transparent);
                        Rectangle dest_rect = new Rectangle(0, 0, source_rect.Width, source_rect.Height);
                        result_gr.DrawImage(big_bm, dest_rect, source_rect, GraphicsUnit.Pixel);

                    }

                    // Return the result.
                    return result;
                }
            }

        }

        private Rectangle GetPointListBounds(List<Point> points, Size isz)
        {
            int xmin = points[0].X;
            int xmax = xmin;
            int ymin = points[0].Y;
            int ymax = ymin;

            for (int i = 1; i < points.Count; i++)
            {
                if (xmin > points[i].X) xmin = points[i].X;
                if (xmax < points[i].X) xmax = points[i].X;
                if (ymin > points[i].Y) ymin = points[i].Y;
                if (ymax < points[i].Y) ymax = points[i].Y;
            }

            if (xmin > isz.Width || xmax < 0 || ymin > isz.Height || ymax < 0) return Rectangle.Empty;

            xmin = Math.Max(xmin, 0);
            ymin = Math.Max(ymin, 0);
            xmax = Math.Min(xmax, isz.Width);
            ymax = Math.Min(ymax, isz.Height);

            return new Rectangle(xmin, ymin, xmax - xmin, ymax - ymin);
        }

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            if (Result == DialogResult.Yes)
            {
                Points = new List<Point>();
                Selecting = true;
            }

            if (button2clicked == true)
            {
                if (Result == DialogResult.No && NumberOfClick > 0)
                {
                    Points = new List<Point>();
                    Selecting = true;
                }
            }
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            if (Result == DialogResult.Yes)
            {
                if (!Selecting) return;
                Points.Add(new Point(e.X, e.Y));
                pictureBox5.Invalidate();
            }

            if (button2clicked == true)
            {
                if (Result == DialogResult.No && NumberOfClick > 0)
                {
                    if (!Selecting) return;
                    Points.Add(new Point(e.X, e.Y));
                    pictureBox5.Invalidate();
                }
            }
        }
    }
}
