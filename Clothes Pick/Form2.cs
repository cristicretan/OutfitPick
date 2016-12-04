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
            this.MouseWheel += new MouseEventHandler(panel1_MouseWheel);
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
        }

        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
                Form2 frm = new Form2();
                panel1.Top += e.Delta > 0 ? 10 : -10;
                if (panel1.Top > 0) panel1.Top = 0;
        }

        Form3 tshirtsform = new Form3();

        private void button2_Click(object sender, EventArgs e)
        {
            tshirtsform.Show();
            this.Hide();
        }

        public Point pPt = Point.Empty;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            pPt = e.Location;
        }

        public void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine("panel2.top:" + panel1.Top);
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                Form2 frm = new Form2();
                panel1.Top += e.Y - pPt.Y;
                if (panel1.Top > 0) panel1.Top = 0;
            }
        }

        PantsForm pantsform = new PantsForm();

        private void button3_Click(object sender, EventArgs e)
        {
            pantsform.Show();
            this.Hide();
        }

        Sweaterform sweaterform = new Sweaterform();

        private void button5_Click(object sender, EventArgs e)
        {
            sweaterform.Show();
            this.Hide();
        }

        ShirtForm shirtform = new ShirtForm();

        private void button4_Click(object sender, EventArgs e)
        {
            shirtform.Show();
            this.Hide();
        }

        CoatForm coatform = new CoatForm();

        private void button6_Click(object sender, EventArgs e)
        {
            coatform.Show();
            this.Hide();
        }

        JacketForm jacketform = new JacketForm();
        
        private void button7_Click(object sender, EventArgs e)
        {
            jacketform.Show();
            this.Hide();
        }

        HoodieForm hoodieform = new HoodieForm();

        private void button8_Click(object sender, EventArgs e)
        {
            hoodieform.Show();
            this.Hide();
        }
    }
}
