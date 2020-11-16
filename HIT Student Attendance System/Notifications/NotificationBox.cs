using System.Windows.Forms;

namespace HIT_Student_Attendance_System
{
    public partial class NotificationBox : Form
    {
        public NotificationBox(string Surname, string RegNumber)
        {
            InitializeComponent();
            StudentNametxt.Text = Surname + "   (" + RegNumber + ")  "; 
        }
    }
}
