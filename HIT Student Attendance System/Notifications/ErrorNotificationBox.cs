using System.Windows.Forms;

namespace HIT_Student_Attendance_System.Notifications
{
    public partial class ErrorNotificationBox : Form
    {
        public ErrorNotificationBox(string Surname, string RegNumber)
        {
            InitializeComponent();
            StudentNametxt.Text = Surname + "   (" + RegNumber + ")  ";
        }
    }
}
