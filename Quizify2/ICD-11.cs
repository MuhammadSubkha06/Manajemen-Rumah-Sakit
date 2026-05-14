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
    public partial class ICD_11 : Form
    {
        bool comboLoaded = false;
        public ICD_11() 
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        private void LoadComboBoxICD()
        {
            using (SqlConnection conn = new SqlConnection(Koneksi.ConnectionString))
            {
                string query = "SELECT id, name FROM dbo.[icd-11]";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();

                try
                {
                    da.Fill(dt);
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember  = "name";
                    comboBox1.ValueMember = "id";        
                    comboBox1.SelectedIndex = -1;        
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat daftar ICD: " + ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && comboBox1.SelectedValue != null)
            {
                if (int.TryParse    (comboBox1.SelectedValue.ToString(), out int idIcd))
                {
                    LoadICDDetails(idIcd);
                    LoadRecommendedDoctors(idIcd);
                }
            }
        }

        private void LoadICDDetails(int idIcd)
        {
            using (SqlConnection conn = new SqlConnection(Koneksi.ConnectionString))
            {
                conn.Open();
                string queryDesc = "SELECT description FROM dbo.[icd-11] WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(queryDesc, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idIcd);
                    object result = cmd.ExecuteScalar();
                    txtDesc.Text = result != null ? result.ToString() : "Tidak ada deskripsi.";
                }

                string queryExc = "SELECT exclusion FROM dbo.[icd-11_exclusion] WHERE id = @id";
                using (SqlCommand cmdExc = new SqlCommand(queryExc, conn))
                {
                    cmdExc.Parameters.AddWithValue("@id", idIcd);
                    using (SqlDataReader reader = cmdExc.ExecuteReader())
                    {
                        txtExc.Text = "";
                        while (reader.Read())
                        {
                            txtExc.Text += "• " + reader["exclusion"].ToString() + Environment.NewLine;
                        }
                    }
                }
            }
        }

        private void LoadRecommendedDoctors(int idIcd)
        {
            panel1.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(Koneksi.ConnectionString))
            {
                string query = @"
                    SELECT 
                        [icd-11_doctor_recommendation].[icd-11_id],
                        doctor_category.category,
                        doctor.id AS doctor_id, 
                        doctor.name
                    FROM dbo.[icd-11_doctor_recommendation]
                    LEFT JOIN dbo.doctor 
                        ON dbo.doctor.doctor_category_id = dbo.[icd-11_doctor_recommendation].doctor_category_id
                    LEFT JOIN dbo.doctor_category 
                        ON dbo.[icd-11_doctor_recommendation].doctor_category_id = dbo.doctor_category.id
                    WHERE [icd-11_doctor_recommendation].[icd-11_id] = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idIcd);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int yPos = 5; 

                            while (reader.Read())
                            {
                                string categoryName = reader["category"] != DBNull.Value ? reader["category"].ToString() : "Kategori Tidak Diketahui";

                                Label lblCategory = new Label();
                                lblCategory.Text = categoryName;
                                lblCategory.Location = new Point(5, yPos);
                                lblCategory.AutoSize = true;
                                lblCategory.Font = new Font(lblCategory.Font, FontStyle.Regular); 

                                panel1.Controls.Add(lblCategory); 

                                if (reader["doctor_id"] != DBNull.Value)
                                {
                                    string docId = reader["doctor_id"].ToString();
                                    string docName = reader["name"].ToString();

                                    LinkLabel lnkDoc = new LinkLabel();
                                    lnkDoc.Text = docName;
                                    lnkDoc.Location = new Point(200, yPos); 
                                    lnkDoc.AutoSize = true;
                                    lnkDoc.Tag = docId;
                                    lnkDoc.LinkClicked += DoctorLinkClicked;

                                    panel1.Controls.Add(lnkDoc);
                                }
                                else
                                {
                                    Label lblNoDoc = new Label();
                                    lblNoDoc.Text = "- Belum ada dokter -";
                                    lblNoDoc.Location = new Point(200, yPos);
                                    lblNoDoc.AutoSize = true;
                                    lblNoDoc.ForeColor = Color.Gray;

                                    panel1.Controls.Add(lblNoDoc);
                                }

                                yPos += 25; 
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal memuat rekomendasi dokter: " + ex.Message);
                    }
                }
            }
        }

        private void DoctorLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel clickedLink = sender as LinkLabel;

            string selectedDoctorId = clickedLink.Tag.ToString();

        }

        private void ICD_11_Load(object sender, EventArgs e)
        {
            LoadComboBoxICD();
        }
    }
}
