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
    public partial class ManageMeeting : Form
    {
        public ManageMeeting()
        {
            InitializeComponent();
            tampilMeeting();
            tampilRecord();
        }

        private void ManageMeeting_Load(object sender, EventArgs e)
        {

        }

        void tampilMeeting()
        {
            using (SqlConnection connection = new SqlConnection(Koneksi.ConnectionString))
            {
                connection.Open();
                string query = "SELECT meeting.id, meeting.date, patient.name, doctor.name, doctor_category.category, meeting.queue_number  FROM [dbo].[meeting]  LEFT JOIN [dbo].[doctor] ON [dbo].[doctor].[id] = dbo.meeting.doctor_id  LEFT JOIN dbo.doctor_category ON dbo.doctor.doctor_category_id = dbo.doctor_category.id  LEFT JOIN dbo.patient ON dbo.meeting.patient_id = dbo.patient.id";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                tbMeeting.DataSource = dataTable;
                tbMeeting.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                tbMeeting.Columns["Payment"].DisplayIndex = tbMeeting.ColumnCount - 1;
            }
        }


        void tampilRecord()
        {
            using (SqlConnection connection = new SqlConnection(Koneksi.ConnectionString))
            {
                connection.Open();
                string query = "SELECT  patient_record.meeting_id, patient_record.notes FROM dbo.patient_record ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@meetingId", tbRecord.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                tbRecord.DataSource = dataTable;
                tbRecord.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                tbRecord.Columns["Edit"].DisplayIndex = tbRecord.ColumnCount - 1;
                tbRecord.Columns["Delete"].DisplayIndex = tbRecord.ColumnCount - 1;
            }
        }

        private void tbRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbMeeting_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
