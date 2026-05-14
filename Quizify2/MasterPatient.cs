using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizify2
{
    public partial class MasterPatient : Form
    {
        public MasterPatient()
        {
            InitializeComponent();
            tampilPatient();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                tbName.Text = row.Cells["name"].Value.ToString();
                tbPhone.Text = row.Cells["phone_number"].Value.ToString();
                tbEmail.Text = row.Cells["email"].Value.ToString();
                tbDateOfBirth.Text = row.Cells["date_of_birth"].Value.ToString();
                tbAddress.Text = row.Cells["address"].Value.ToString();
                tbGender.Text = row.Cells["gender"].Value.ToString();
                tbBloodType.Text = row.Cells["blood_type"].Value.ToString();
                tbLastUpdt.Text = row.Cells["last_updated_at"].Value.ToString();
            }
        }

        void tampilPatient()
        {
            using (SqlConnection connection = new SqlConnection(Koneksi.ConnectionString))
            {
                connection.Open();
                string query = "SELECT name, phone_number, email, date_of_birth, address, gender, blood_type, last_updated_at FROM [patient]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void lblUpdtAt_Click(object sender, EventArgs e)
        {

        }

        private void tbLastUpdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Koneksi.ConnectionString);

            string query = "SELECT * FROM [patient] WHERE name LIKE @name";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.SelectCommand.Parameters.AddWithValue("@name", "%" + tbSearch.Text + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}
