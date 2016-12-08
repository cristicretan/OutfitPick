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

namespace OODB
{
    public partial class Register : Form
    {
        SqlConnection connection = new SqlConnection(Connection.connection_string);
        
        string _Username;
        string _Password;
        string _Nume;
        string _Prenume;
        string _Email;

        public Register()
        {
            InitializeComponent();
        }

        private void connection_test()
        {
            // SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();

            if (connection.State.Equals(ConnectionState.Open))
            {
                //   MessageBox.Show("Connection is valid and open!");
            }
            else
            {
                MessageBox.Show("Connection error");
            }
            connection.Close();
        }

        private void insert_database1()
        {
            _Username = textBox1.Text;
            _Password = textBox2.Text;
            _Nume = textBox3.Text;
            _Prenume = textBox4.Text;
            _Email = textBox5.Text;

            SqlCommand cmd;
            string query = "INSERT INTO Clienti(Username,Password,Nume,Prenume,Email) VALUES(@Username,@Password,@Nume,@Prenume,@Email)";
            cmd = new SqlCommand(query, connection);

            if (string.IsNullOrEmpty(_Username) || string.IsNullOrEmpty(_Password) || string.IsNullOrEmpty(_Nume) || string.IsNullOrEmpty(_Prenume) || string.IsNullOrEmpty(_Email))
            {
                MessageBox.Show("You have to complete all fields ");
            }
            else if (!_Email.Contains("@"))
            {
                MessageBox.Show("You have to insert a valid email format! ");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Username", _Username);
                cmd.Parameters.AddWithValue("@Password", _Password);
                cmd.Parameters.AddWithValue("@Nume", _Nume);
                cmd.Parameters.AddWithValue("@Prenume", _Prenume);
                cmd.Parameters.AddWithValue("@Email", _Email);
                try
                {
                    connection.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Account succesfully created!");
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection_test();
            insert_database1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogIn frm = new LogIn();
            frm.Show();
            Hide();
        }
    }
}