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
using System.Xml.Linq;

namespace Quizify2
{
    public partial class MasterDoctor : Form
    {
        bool comboLoaded = false;

        public MasterDoctor()
        {
            InitializeComponent();
            
            loadCategory();
            tampilDokter(); 
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
                tbCategory.Text = row.Cells["doctor_category_id"].Value.ToString();
                tbAddress.Text = row.Cells["address"].Value.ToString();
                tbGender.Text = row.Cells["gender"].Value.ToString();
                tbAssRoom.Text = row.Cells["assigned_room"].Value.ToString();
                tbLastUpdt.Text = row.Cells["last_updated_at"].Value.ToString();
            }
        }

        void tampilDokter()
        {
            using (SqlConnection connection = new SqlConnection(Koneksi.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [doctor]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboLoaded) return;
            if (comboBox1.SelectedValue == null) return;

            int categoryId;

            if (comboBox1.SelectedValue is DataRowView)
                return;
            else
                categoryId = Convert.ToInt32(comboBox1.SelectedValue);

            using (SqlConnection connection = new SqlConnection(Koneksi.ConnectionString))
            {
                connection.Open();

                string query = @"SELECT 
                        d.name,
                        d.phone_number,
                        d.email,
                        d.city_of_birth,
                        d.date_of_birth,
                        d.address,
                        d.gender,
                        d.assigned_room,
                        dc.category
                        FROM doctor d
                        JOIN doctor_category dc 
                        ON d.doctor_category_id = dc.id
                        WHERE d.doctor_category_id = @category";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@category", categoryId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        void loadCategory()
        {
            using (SqlConnection connection = new SqlConnection(Koneksi.ConnectionString))
            {
                connection.Open();

                string query = "SELECT id, category FROM doctor_category";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "category";
                comboBox1.ValueMember = "id";

                comboLoaded = true; 
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Koneksi.ConnectionString);

            string query = "SELECT * FROM [doctor] WHERE name LIKE @name";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.SelectCommand.Parameters.AddWithValue("@name", "%" + tbSearch.Text + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void MasterDoctor_Load(object sender, EventArgs e)
        {

        }
    }
}
