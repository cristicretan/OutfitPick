using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using Clothes_Pick;

namespace OODB
{
    public partial class LogIn : Form
    {
        SqlConnection connection = new SqlConnection(Connection.connection_string);
        

        public string connection_string { get; private set; }

        public LogIn()
        {
            InitializeComponent();

            button3.TabStop = false;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent


            roundedButton1.TabStop = false;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent

            roundedButton2.TabStop = false;
            roundedButton2.FlatStyle = FlatStyle.Flat;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            connection_init();
        }
        private void connection_init()
        {

            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();

            if (connection.State.Equals(ConnectionState.Open))
            {
                MessageBox.Show("Connection is valid and open!");
            }
            else
            {
                MessageBox.Show("Connection error");
            }
            connection.Close();
        }

        /*
        private string get_username(string _username)
        {
            connection.Close();
            string query = "SELECT * FROM Clienti";

            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())

            {
                _username = reader.GetSqlValue(1).ToString();
            }

            return _username;
        }

        private string get_passowrd(string _password)
        {
            connection.Close();
            string query = "SELECT * FROM Clienti";

            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())

            {
                _password = reader.GetSqlValue(2).ToString();
            }

            return _password;
        }
        */

        private void validation()
        {
            string Username;
            string Password;

            string query = "SELECT * FROM Clienti";

            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            if (string.IsNullOrEmpty(alphaBlendTextBox1.Text) || string.IsNullOrEmpty(alphaBlendTextBox2.Text))
            {
                MessageBox.Show("You have to complete user and password fields");
                return;
            }

            while (reader.Read())
            {
                Username = reader.GetSqlString(1).Value.Trim().ToString();
                Password = reader.GetSqlString(2).Value.Trim().ToString();

                if ((alphaBlendTextBox1.Text == Username) && (Password == alphaBlendTextBox2.Text))
                {
                   // MessageBox.Show("Merge");
                    // LogIn.user = textBox1.Text;
                    // P1 p1forms = new P1();
                    //  p1forms.ShowDialog();
                    Form1 frm = new Form1();
                    frm.Show();
                    Hide();
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Close();
            validation();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Register();
            f.Show();
            Hide();
        }

        private void roundedButton2_MouseEnter(object sender, EventArgs e)
        {
            roundedButton2.UseVisualStyleBackColor = false;
            roundedButton2.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Black);
        }

        private void roundedButton2_MouseLeave(object sender, EventArgs e)
        {
            roundedButton2.UseVisualStyleBackColor = true;
            roundedButton2.BackColor = Color.Transparent;
        }

        private void roundedButton1_MouseEnter(object sender, EventArgs e)
        {
            roundedButton1.UseVisualStyleBackColor = false;
            roundedButton1.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Black);
        }

        private void roundedButton1_MouseLeave(object sender, EventArgs e)
        {
            roundedButton1.UseVisualStyleBackColor = true;
            roundedButton1.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            alphaBlendTextBox1.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            alphaBlendTextBox2.Focus();
        }
    }
}


