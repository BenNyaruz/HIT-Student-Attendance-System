using HIT_Student_Attendance_System.Staff_Interface;
using System;
using System.Windows.Forms;

namespace HIT_Student_Attendance_System.Report
{
    public partial class ReportView : Form
    {
        public ReportView()
        {
            InitializeComponent();
        }

        private void Report_View_Load(object sender, EventArgs e)
        {           
            // TODO: This line of code loads data into the 'regNumberDataSet.System_Users' table. You can move, or remove it, as needed.
            this.system_UsersTableAdapter.FillBy(this.regNumberDataSet.System_Users, "Student");
            RegNumber_comboBox.Text = "";

            this.reportViewer.RefreshReport();
        }

        private void Load_btn_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hITSASDataSet.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.FillBy(this.hITSASDataSet.Students, RegNumber_comboBox.Text.ToString());
            // TODO: This line of code loads data into the 'hITSASDataSet.Attendance' table. You can move, or remove it, as needed.
            this.attendanceTableAdapter.FillBy(this.hITSASDataSet.Attendance, RegNumber_comboBox.Text.ToString());
            // TODO: This line of code loads data into the 'hITSASDataSet.System_Users' table. You can move, or remove it, as needed.
            this.system_UsersTableAdapter1.FillBy(this.hITSASDataSet.System_Users, RegNumber_comboBox.Text.ToString());

            this.reportViewer.RefreshReport();
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Lecturer_Portal)
                {
                    form.Show();
                    break;
                }
            }
            this.Close();
        }
    }
}
