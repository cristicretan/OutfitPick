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


            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("You have to complete user and password fields");
                return;
            }

            while (reader.Read())
            {
                Username = reader.GetSqlString(1).Value.Trim().ToString();
                Password = reader.GetSqlString(2).Value.Trim().ToString();

                if ((textBox1.Text == Username) && (Password == textBox2.Text))
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
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Register();
            f.Show();
            Hide();
        }
    }
}


