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

        private Point _mouseLastPosition;
        private bool _working;
        private readonly object _lock = new object();

        public Form2()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(panel1_MouseWheel);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.Focus();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.AutoScroll = false;
        }

        private int ValidateChange(int change)
        {
            const int padding = -1;
            if (change < 0)
            {
                var max = GetMax(padding);

                if (max < Height + Math.Abs(change))
                {
                    return Height - max;
                }
            }
            else
            {
                var min = GetMin();

                if (min > padding - Math.Abs(change))
                {
                    return padding - min;
                }
            }
            return change;
        }

        private int GetMax(int padding)
        {
            var max = int.MinValue;
            for (var i = 0; i < Controls.Count; i++)
            {
                var v = Controls[i].Top + Controls[i].Height + padding;
                if (v > max)
                {
                    max = v;
                }
            }
            return max;
        }

        private int GetMin()
        {
            var min = int.MaxValue;
            for (var i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].Top < min)
                {
                    min = Controls[i].Top;
                }
            }
            return min;
        }

        private void HandleDelta(int delta)
        {
            lock (_lock)
            {
                if (_working)
                {
                    return;
                }
                _working = true;
            }

            var change = ValidateChange(delta);

            for (var i = 0; i < Controls.Count; i++)
            {
                Controls[i].Top += change;
            }

            _working = false;
        }

        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            HandleDelta(e.Delta);
            base.OnMouseWheel(e);
        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseLastPosition = e.Location;
            }
            base.OnMouseDown(e);
        }

        public void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((MouseButtons & MouseButtons.Left) != 0)
            {
                var delta = e.Y - _mouseLastPosition.Y;
                HandleDelta(delta);
                _mouseLastPosition = e.Location;
            }
            base.OnMouseMove(e);

        }

        Form1 frm = new Form1();

        private void button1_Click(object sender, EventArgs e)
        {
            frm.Show();
            this.Hide();
        }

        Form3 tshirtsform = new Form3();

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to add a t-shirt to your garderobe?", "Confirmation", MessageBoxButtons.YesNo);
            if(Result == DialogResult.Yes)
            {
                tshirtsform.Show();
                this.Hide();
            }
            else
            {
                this.Refresh();
            }
            
        }

        PantsForm pantsform = new PantsForm();

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to add pants to your garderobe?", "Confirmation", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                pantsform.Show();
                this.Hide();
            }
            else
            {
                this.Refresh();
            }
        }

        Sweaterform sweaterform = new Sweaterform();

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to add a sweater to your garderobe?", "Confirmation", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                sweaterform.Show();
                this.Hide();
            }
            else
            {
                this.Refresh();
            }
        }

        ShirtForm shirtform = new ShirtForm();

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to add a shirt to your garderobe?", "Confirmation", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                shirtform.Show();
                this.Hide();
            }
            else
            {
                this.Refresh();
            }
        }

        CoatForm coatform = new CoatForm();

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to add a coat to your garderobe?", "Confirmation", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                coatform.Show();
                this.Hide();
            }
            else
            {
                this.Refresh();
            }
        }

        JacketForm jacketform = new JacketForm();
        
        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to add a jacket to your garderobe?", "Confirmation", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                jacketform.Show();
                this.Hide();
            }
            else
            {
                this.Refresh();
            }
        }

        HoodieForm hoodieform = new HoodieForm();

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to add a hoodie to your garderobe?", "Confirmation", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                hoodieform.Show();
                this.Hide();
            }
            else
            {
                this.Refresh();
            }
        }

    }
}
