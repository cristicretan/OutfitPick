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
using System.Runtime.InteropServices;
using Clothes_Pick;

namespace OODB
{
    public partial class Register : Form
    {
        SqlConnection connection = new SqlConnection(Connection.connection_string);

        public Register()
        {
            InitializeComponent();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            MessageBox.Show(path);

            button2.TabStop = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent

            roundedButton1.TabStop = false;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            roundedButton1.FlatAppearance.MouseDownBackColor = Color.FromArgb(68, 102, 85);
            roundedButton1.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 68, 102, 85);

            
        }

        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        private void connection_test()
        {
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
            var salt = Encrypt.GenerateRandomSalt();
            var _Password = Encrypt.SHA128(Encrypt.SHA128(alphaBlendTextBox2.Text) + salt);

            string _Username = alphaBlendTextBox1.Text;
            string _Nume = alphaBlendTextBox3.Text;
            string _Prenume = alphaBlendTextBox4.Text;
            string _Email = alphaBlendTextBox5.Text;

            SqlCommand cmd;
            string query = "INSERT INTO Clienti(Username,Password,Nume,Prenume,Email,salt) VALUES(@Username,@Password,@Nume,@Prenume,@Email,@salt)";
            cmd = new SqlCommand(query, connection);


            if (string.IsNullOrEmpty(_Username) || string.IsNullOrEmpty(_Password) || string.IsNullOrEmpty(_Nume) || string.IsNullOrEmpty(_Prenume) || string.IsNullOrEmpty(_Email))
            {
                MessageBox.Show("You have to complete all fields ");
            }
            else if (!_Email.Contains("@"))
            {
                MessageBox.Show("You have to insert a valid email format! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (alphaBlendTextBox1.Text.Length < 5)
            {
                MessageBox.Show("Please check your username, minimum length is five characters! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (alphaBlendTextBox2.Text.Length < 6)
            {
                MessageBox.Show("Please check your password, minimum length is six characters! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Username", _Username);
                cmd.Parameters.AddWithValue("@Password", _Password);
                cmd.Parameters.AddWithValue("@Nume", _Nume);
                cmd.Parameters.AddWithValue("@Prenume", _Prenume);
                cmd.Parameters.AddWithValue("@Email", _Email);
                cmd.Parameters.AddWithValue("@salt", salt);
                try
                {
                    connection.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Account succesfully created! Now you can log in");
                        
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
            frm.SetDesktopLocation(this.Left, this.Top);
            frm.Show();
            Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            alphaBlendTextBox1.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            alphaBlendTextBox2.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            alphaBlendTextBox3.Focus();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
            alphaBlendTextBox4.Focus();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            alphaBlendTextBox5.Focus();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Register_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

    }
}