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
using System.Runtime.InteropServices;

namespace OODB
{
    public partial class LogIn : Form
    {
        SqlConnection connection = new SqlConnection(Connection.connection_string);
        bool login;
        string salt;


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

        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        private void LogIn_Load(object sender, EventArgs e)
        {
            connection_init();
            set_textbox_watermakrs();
        }

        private void connection_init()
        {
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

        private void set_textbox_watermakrs()
        {
            SendMessage(alphaBlendTextBox1.Handle, EM_SETCUEBANNER, 0, "Username");
            SendMessage(alphaBlendTextBox2.Handle, EM_SETCUEBANNER, 0, "Password");
        }

        private string get_Clienti_salt(string _username)
        {
            string current_Username = alphaBlendTextBox1.Text;
            string get_Clienti_salt_query = "SELECT salt FROM Clienti WHERE Username='" + current_Username + "'";
            var cmd = new SqlCommand(get_Clienti_salt_query, connection);

            try
            {
                connection.Open();

                if (cmd.ExecuteScalar() != null)
                {
                    salt = cmd.ExecuteScalar().ToString().Trim();
                }
                else
                {
                    login = false;
                    salt = null;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            connection.Close();
            return salt;
        }

        private void validation()
        {

            string Username = alphaBlendTextBox1.Text;
            string Password = alphaBlendTextBox2.Text;
            Password = Encrypt.SHA128(Encrypt.SHA128(alphaBlendTextBox2.Text) + get_Clienti_salt(Username));


            string query = "SELECT Username,Password FROM clienti WHERE Username='" + Username + "'" + "AND Password='" + Password + "'";

            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();

            if (cmd.ExecuteScalar() != null)
            {
                login = true;
            }

            if (login == true)
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
                connection.Close();
            }
            if (!login)
            {
                MessageBox.Show("Check your username or password");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            connection.Close();
            validation();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Register();
            f.Show();
            this.Hide();
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


