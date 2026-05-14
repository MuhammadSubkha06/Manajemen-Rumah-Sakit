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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewMeeting newMeeting = new NewMeeting();
            newMeeting.Show();
            this.Hide();
        }

        private void lblUser_Click(object sender, EventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = "Welcome, " + GlobalSession.Username;    
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
           
            GlobalSession.Username = null;
            GlobalSession.isLogin = false;
            FormLogin frmLogin = new FormLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void btnMstrDctr_Click(object sender, EventArgs e)
        {
            MasterDoctor masterDoctorForm = new MasterDoctor();
            masterDoctorForm.Show();
            this.Hide();
        }

        private void btnMstrPatient_Click(object sender, EventArgs e)
        {
            MasterPatient masterPatientForm = new MasterPatient();
            masterPatientForm.Show();
            this.Hide();
        }

        private void btnMngMeet_Click(object sender, EventArgs e)
        {
            ManageMeeting manageMeetingForm = new ManageMeeting();
            manageMeetingForm.Show();
            this.Hide();
        }

        private void btnICD11_Click(object sender, EventArgs e)
        {
            ICD_11 icd11Form = new ICD_11();
            icd11Form.Show();
            this.Hide();
        }
    }
}