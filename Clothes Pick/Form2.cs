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

            button1.TabStop = false;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 0, 0, 0); // transparent

            button2.TabStop = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 0, 0, 0); // transparent

            button3.TabStop = false;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 2;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 0, 0, 0); // transparent

            button4.TabStop = false;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 0, 0, 0); // transparent

            button5.TabStop = false;
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 2;
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            button5.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 0, 0, 0); // transparent

            button6.TabStop = false;
            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 2;
            button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            button6.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 0, 0, 0); // transparent

            button7.TabStop = false;
            button7.FlatStyle = FlatStyle.Flat;
            button7.FlatAppearance.BorderSize = 2;
            button7.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            button7.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 0, 0, 0); // transparent

            button8.TabStop = false;
            button8.FlatStyle = FlatStyle.Flat;
            button8.FlatAppearance.BorderSize = 2;
            button8.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            button8.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 0, 0, 0); // transparent

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
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
