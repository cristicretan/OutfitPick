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
        private bool isPostBack = true;

        public string connection_string { get; private set; }

        public LogIn()
        {
            InitializeComponent();

            isPostBack = false;

            var dt1 = DateTime.Parse("08:00 AM").ToString("hh:mm tt");
            var dt2 = DateTime.Parse("08:00 PM").ToString("hh:mm tt");

                button3.TabStop = false;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 0, 0, 0); // transparent
            button3.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent

            roundedButton1.TabStop = false;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            roundedButton1.FlatAppearance.MouseDownBackColor = Color.FromArgb(68, 102, 85);
            roundedButton1.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 68, 102, 85);

            label5.BackColor = Color.FromArgb(30, 0, 0, 0);

            if (!isPostBack) this.CenterToScreen();

        }

        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void LogIn_Load(object sender, EventArgs e)
        {
            connection_init();
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
            f.SetDesktopLocation(this.Left, this.Top);
            f.Show();
            this.Hide();
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

        private void LogIn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.Font = new Font(label4.Font, FontStyle.Underline);
            label4.ForeColor = Color.FromArgb(68, 102, 85);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.Font = new Font(label4.Font, FontStyle.Regular);
            label4.ForeColor = Color.White;
        }
    }
}


