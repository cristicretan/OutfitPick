using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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


            button11.TabStop = false;
            button11.FlatStyle = FlatStyle.Flat;
            button11.FlatAppearance.BorderSize = 0;
            button11.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            button11.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            button11.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent

            Button b1 = new Button();
            Button b2 = new Button();
            Button b3 = new Button();
            Button b4 = new Button();
            Button b5 = new Button();
            Button b6 = new Button();
            Button b7 = new Button();
            Button b8 = new Button();

            child = new Hoodie();
            child2 = new Sweater();
            child3 = new Pants();
            child4 = new Shirt();
            child5 = new Jacket();
            child6 = new Skirt();
            child7 = new Coat();
            child8 = new Tshirt();

            control();

         /*   scrollablePanel1.AutoScroll = false;
            scrollablePanel1.VerticalScroll.Enabled = false;
            scrollablePanel1.VerticalScroll.Visible = false;
            scrollablePanel1.VerticalScroll.Maximum = 0;
            scrollablePanel1.AutoScroll = true; */
        }

        Hoodie child = new Hoodie();
        Sweater child2 = new Sweater();
        Pants child3 = new Pants();
       Shirt child4 = new Shirt();
        Jacket child5 = new Jacket();
        Skirt child6 = new Skirt();
        Coat child7 = new Coat();
        Tshirt child8 = new Tshirt();

        private void control ()
        {
         //   flowLayoutPanel1.HorizontalScroll.Maximum = 0;
           // flowLayoutPanel1.AutoScroll = false;
            //flowLayoutPanel1.VerticalScroll.Visible = false;
            //flowLayoutPanel1.AutoScroll = true;
             HorizontalScroll.Enabled = false;
            //  flowLayoutPanel1.BackColor = Color.FromArgb(0, 255, 255, 255);
            //flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
         //   int x = 0;
        //    flowLayoutPanel1.BackColor = Color.FromArgb(x, Color.Blue);

            Button b1 = new Button();
            b1.Height = 80;
            b1.Width = 163;
            flowLayoutPanel1.Controls.Add(b1);
           // scrollablePanel1.Controls.Add(b1);
            b1.Click += new EventHandler(b1_Click);
            b1.BackColor = Color.Transparent;
            //b1.Image = Image.FromFile(@"C:\Users\Alexandra\Desktop\ts.jpg");
           
            b1.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b1.Text = "Hoodie";
            b1.TabStop = false;
            b1.FlatStyle = FlatStyle.Flat;
            b1.FlatAppearance.BorderSize = 0;
            b1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            b1.FlatAppearance.MouseDownBackColor = Color.FromArgb(68, 102, 85);
            b1.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 68, 102, 85);



            Button b2 = new Button();
            b2.Height = 80;
            b2.Width = 163;
            flowLayoutPanel1.Controls.Add(b2);
          // scrollablePanel2.Controls.Add(b2);
            b2.Click += new EventHandler(b2_Click);
            b2.BackColor = Color.Transparent;

            b2.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b2.Text = "Sweater";
            b2.TabStop = false;
            b2.FlatStyle = FlatStyle.Flat;
            b2.FlatAppearance.BorderSize = 0;
            b2.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            b2.FlatAppearance.MouseDownBackColor = Color.FromArgb(68, 102, 85);
            b2.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 68, 102, 85);



            Button b3 = new Button();
            b3.Height = 80;
            b3.Width = 163;
           flowLayoutPanel1.Controls.Add(b3);
          // scrollablePanel2.Controls.Add(b3);
            b3.Click += new EventHandler(b3_Click);
            b3.BackColor = Color.Transparent;

            b3.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b3.Text = "Pants";
            b3.TabStop = false;
            b3.FlatStyle = FlatStyle.Flat;
            b3.FlatAppearance.BorderSize = 0;
            b3.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            b3.FlatAppearance.MouseDownBackColor = Color.FromArgb(68, 102, 85);
            b3.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 68, 102, 85);


            Button b4 = new Button();
            b4.Height = 80;
            b4.Width = 163;
            flowLayoutPanel1.Controls.Add(b4);
           // scrollablePanel2.Controls.Add(b4);
            b4.Click += new EventHandler(b4_Click);
            b4.BackColor = Color.Transparent;

            b4.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b4.Text = "Shirt";
            b4.TabStop = false;
            b4.FlatStyle = FlatStyle.Flat;
            b4.FlatAppearance.BorderSize = 0;
            b4.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            b4.FlatAppearance.MouseDownBackColor = Color.FromArgb(68, 102, 85);
            b4.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 68, 102, 85);
            

            Button b5 = new Button();
            b5.Height = 80;
            b5.Width = 163;
            flowLayoutPanel1.Controls.Add(b5);
            b5.Click += new EventHandler(b5_Click);
            b5.BackColor = Color.Transparent;
            // b1.Image = Image.FromFile(@"C:\Users\Alexandra\Desktop\17857990_1498974720136336_1709821674_n.jpg");

            b5.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b5.Text = "Jacket";
            b5.TabStop = false;
            b5.FlatStyle = FlatStyle.Flat;
            b5.FlatAppearance.BorderSize = 0;
            b5.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            b5.FlatAppearance.MouseDownBackColor = Color.FromArgb(68, 102, 85);
            b5.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 68, 102, 85);




            Button b6 = new Button();
            b6.Height = 80;
            b6.Width = 163;
            flowLayoutPanel1.Controls.Add(b6);
            b6.Click += new EventHandler(b6_Click);
            b6.BackColor = Color.Transparent;

            b6.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b6.Text = "Skirt";
            b6.TabStop = false;
            b6.FlatStyle = FlatStyle.Flat;
            b6.FlatAppearance.BorderSize = 0;
            b6.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            b6.FlatAppearance.MouseDownBackColor = Color.FromArgb(68, 102, 85);
            b6.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 68, 102, 85);




            Button b7 = new Button();
            b7.Height = 80;
            b7.Width = 163;
            flowLayoutPanel1.Controls.Add(b7);
            b7.Click += new EventHandler(b7_Click);
            b7.BackColor = Color.Transparent;

            b7.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b7.Text = "Coat";
            b7.TabStop = false;
            b7.FlatStyle = FlatStyle.Flat;
            b7.FlatAppearance.BorderSize = 0;
            b7.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            b7.FlatAppearance.MouseDownBackColor = Color.FromArgb(68, 102, 85);
            b7.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 68, 102, 85);

            Button b8 = new Button();
            b8.Height = 80;
            b8.Width = 163;
            flowLayoutPanel1.Controls.Add(b8);
            b8.Click += new EventHandler(b8_Click);
            b8.BackColor = Color.Transparent;

            b8.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b8.Text = "T shirt";
            b8.TabStop = false;
            b8.FlatStyle = FlatStyle.Flat;
            b8.FlatAppearance.BorderSize = 0;
            b8.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            b8.FlatAppearance.MouseDownBackColor = Color.FromArgb(68, 102, 85);
            b8.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 68, 102, 85);



        }

        Form1 frm = new Form1();
        Form3 Tshirtsform = new Form3();
        PantsForm pantsform = new PantsForm();
        Sweaterform sweaterform = new Sweaterform();
        ShirtForm shirtform = new ShirtForm();
        CoatForm coatform = new CoatForm();
        JacketForm jacketform = new JacketForm();
        HoodieForm hoodieform = new HoodieForm();
        SkirtForm skirtform = new SkirtForm();

        private void button11_Click(object sender, EventArgs e)
        {
            button11.BackColor = Color.Transparent;
            button11.FlatStyle = FlatStyle.Flat;
            button11.FlatAppearance.BorderSize = 0;
            button11.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            button11.FlatAppearance.MouseDownBackColor = Color.FromArgb(68, 102, 85);
            button11.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 68, 102, 85);

            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to add a hoodie to your garderobe?", "Confirmation", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                hoodieform.Show();
                this.Hide();
            }
            else
            {
                if (ActiveMdiChild != null)
                    ActiveMdiChild.Close();

                Hoodie child = new Hoodie();
                child.MdiParent = this;
                child.Show();
                child.Location = new Point(0, 160);
            }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to add a sweater to your garderobe?", "Confirmation", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                sweaterform.Show();
                this.Hide();
            }
            else
            {
                if (ActiveMdiChild != null)
                    ActiveMdiChild.Close();

                Sweater child = new Sweater();
                child.MdiParent = this;
                child.Show();
                child.Location = new Point(0, 160);
            }
        }

        protected void b3_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to add pants to your garderobe?", "Confirmation", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                pantsform.Show();
                this.Hide();
            }
            else
            {

                if (ActiveMdiChild != null)
                    ActiveMdiChild.Close();

                Pants child = new Pants();
                child.MdiParent = this;
                child.Show();
                child.Location = new Point(0, 160);
            }
        }

        protected void b4_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to add shirt to your garderobe?", "Confirmation", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                shirtform.Show();
                this.Hide();
            }
            else
            {

                if (ActiveMdiChild != null)
                    ActiveMdiChild.Close();

                Shirt child = new Shirt();
                child.MdiParent = this;
                child.Show();
                child.Location = new Point(0, 160);
            }
        }

        protected void b5_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you want to add a jacket to your garderobe?", "Confirmation", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                jacketform.Show();
                this.Hide();
            }
            else
            {

                if (ActiveMdiChild != null)
                    ActiveMdiChild.Close();

                Jacket child = new Jacket();
                child.MdiParent = this;
                child.Show();
                child.Location = new Point(0, 160);

            }
        }

        protected void b6_Click(object sender, EventArgs e)
        {

            DialogResult Result = MessageBox.Show("Do you want to add a skirt to your garderobe?", "Confirmation", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                
                skirtform.Show();
                this.Hide();
            }
            else
            {

                if (ActiveMdiChild != null)
                    ActiveMdiChild.Close();

                Skirt child = new Skirt();
                child.MdiParent = this;
                child.Show();
                child.Location = new Point(0, 160);
            }
        }

        protected void b7_Click(object sender, EventArgs e)
        {

            DialogResult Result = MessageBox.Show("Do you want to add a coat to your garderobe?", "Confirmation", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                coatform.Show();
                this.Hide();
            }
            else
            {
                if (ActiveMdiChild != null)
                    ActiveMdiChild.Close();

                Coat child = new Coat();
                child.MdiParent = this;
                child.Show();
                child.Location = new Point(0, 160);
            }
        }

        protected void b8_Click(object sender, EventArgs e)
        {

            DialogResult Result = MessageBox.Show("Do you want to add a T shirt to your garderobe?", "Confirmation", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                Tshirtsform.Show();
                this.Hide();
            }
            else
            {
                if (ActiveMdiChild != null)
                    ActiveMdiChild.Close();

                Tshirt child = new Tshirt();
                child.MdiParent = this;
                child.Show();
                child.Location = new Point(0, 160);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

            //   flowLayoutPanel1.BackColor = Color.FromArgb(0, 0, 0, 0);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
         //   Form2.Image = Image.FromFile(@"C:\Users\Alexandra\Desktop\ts.jpg");
        }
    }
    }



