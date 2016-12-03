using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clothes_Pick
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.Focus();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.AutoScroll = false;

            Point pPt = Point.Empty;

            panel1.MouseWheel += (ss, ee) =>
            {
                Panel pa = ss as Panel;
                pa.Top += ee.Delta > 0 ? 10 : -10;
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();
        }

        public Point pPt = Point.Empty;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            pPt = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine("panel2.top:" + panel1.Top);
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                Panel pa = sender as Panel; pa.Top = pa.Top + e.Y - pPt.Y;
            }
        }
    }
}
