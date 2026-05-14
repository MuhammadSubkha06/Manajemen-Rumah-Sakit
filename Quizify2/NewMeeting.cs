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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quizify2
{
    public partial class NewMeeting : Form
    {
        public NewMeeting()
        {
            InitializeComponent();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewMeeting_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();

            using (SqlConnection connection = new SqlConnection(Koneksi.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT name FROM [patient]";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        autoCompleteStringCollection.Add(reader["name"].ToString());
                    }
                }
                catch (Exception ex)
                {

                }

                txt_name_pattient.AutoCompleteCustomSource = autoCompleteStringCollection;

            }

            loadCategory();

            using (SqlConnection connection = new SqlConnection(Koneksi.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT name FROM [doctor]";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        autoCompleteStringCollection.Add(reader["name"].ToString());
                    }

                    cmbName.AutoCompleteCustomSource = autoCompleteStringCollection;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
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

                cmbCategory.DisplayMember = "category";
                cmbCategory.ValueMember = "id";

                cmbCategory.DataSource = dt;
            }
        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedCategoryId = cmbName.SelectedValue?.ToString();
            using (SqlConnection connection = new SqlConnection(Koneksi.ConnectionString))
            {
                connection.Open();

                string query = "SELECT id, name FROM doctor WHERE doctor_category_id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                cmd.Parameters.AddWithValue("@id", selectedCategoryId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                
                cmbName.DisplayMember = "name";
                cmbName.ValueMember = "id";
                cmbName.DataSource = dt;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            int queue = 1;
            string selectedDoctorId = cmbName.SelectedValue?.ToString();
            string selectedDate = cmbName.SelectedValue?.ToString();
            using (SqlConnection connection = new SqlConnection(Koneksi.ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) queue FROM dbo.meeting WHERE doctor_id = @selectedDoctorId AND date = @selectedDate";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@selectedDoctorId", selectedDoctorId);
                cmd.Parameters.AddWithValue("@selectedDate", selectedDate);
                queue = Convert.ToInt32(cmbName.SelectedValue);

                if (queue > 10)
                {
                    queue = 10;
                }
                else
                {
                    queue = queue + 1;
                }
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MasterPatient masterPatient = new MasterPatient();
            masterPatient.Show();
            this.Hide();
        }
    }
}
