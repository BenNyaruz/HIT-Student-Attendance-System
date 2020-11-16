using System.Windows.Forms;

namespace HIT_Student_Attendance_System.Staff_Interface
{
    public partial class Administration_Portal : Form
    {
        readonly string FirstName;
        readonly string Surname;
        readonly string RegNumber;
        public Administration_Portal(string name, string surname, string regnumber)
        {
            InitializeComponent();
            FirstName = name;
            Surname = surname;
            RegNumber = regnumber;
            AdminName_lbl.Text = FirstName + " " + Surname + " (" + RegNumber + ") ";
            
        }

        private void Student_Managment_Click(object sender, System.EventArgs e)
        {
            Admin_Forms.New_Student NewStudent = new Admin_Forms.New_Student(FirstName, Surname, RegNumber);
            this.Hide();
            NewStudent.Show();
        }

        private void Staff_Managment_Click(object sender, System.EventArgs e)
        {
            Admin_Forms.New_Stuff NewStuff = new Admin_Forms.New_Stuff(FirstName, Surname, RegNumber);
            this.Hide();
            NewStuff.Show();
        }

        private void Logout_btn_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void SendReports_btn_Click(object sender, System.EventArgs e)
        {
            #region Load Report
            Report.Email_Reports EmailReport = new Report.Email_Reports();
            EmailReport.Show();
            #endregion
        }
    }
}
