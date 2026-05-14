using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizify2
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public static string HashPassword(string password)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Koneksi.ConnectionString))
            {
                connection.Open();
                if (tbPass.Text == "" || tbUsn.Text == "")
                {
                    MessageBox.Show("Username dan password tidak boleh kosong!");
                    return;
                }

                using (SqlCommand command = new SqlCommand("SELECT * FROM [user] WHERE username = @username AND password = @password", connection))
                {
                    command.Parameters.AddWithValue("@username", tbUsn.Text);
                    command.Parameters.AddWithValue("@password", HashPassword(tbPass.Text));
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        GlobalSession.Username = reader["username"].ToString();
                        GlobalSession.isLogin = true;
                        MainForm mainFrm = new MainForm();
                        mainFrm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login gagal! Periksa username dan password Anda.");


                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tbPass.UseSystemPasswordChar = false;
            }
            else
            {
                tbPass.UseSystemPasswordChar = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(GlobalSession.isLogin)
            {
                MainForm mainFrm = new MainForm();
                mainFrm.Show();
                this.Hide();
            }
        }
    }
}
