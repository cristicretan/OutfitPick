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
    public partial class CoatOrJacket : Form
    {
        public CoatOrJacket()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.Yes;
            Program.coat = true;
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.No;
            Program.jacket = true;
            this.Close();
            
        }
    }
}
