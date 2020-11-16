using AForge.Video;
using AForge.Video.DirectShow;
using HIT_Student_Attendance_System.Notifications;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ZXing;

namespace HIT_Student_Attendance_System.Staff_Interface
{
    public partial class Lecturer_Portal : Form
    {
        private readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HIT_Student_Attendance_System.Properties.Settings.Setting"].ConnectionString);
        readonly string FirstName;
        readonly string Surname;
        readonly string RegNumber;
        private FilterInfoCollection FilterInfoCollection;
        private VideoCaptureDevice captureDevice;

        public Lecturer_Portal(string name, string surname, string regnumber)
        {
            InitializeComponent();
            FirstName = name;
            Surname = surname;
            RegNumber = regnumber;
            LecturersName_lbl.Text = FirstName + " " + Surname + " (" + RegNumber + ") ";
        }

        private void TimeKeeper_Tick(object sender, EventArgs e)
        {
            try
            {
                if (QR_Code_Scanner.Image != null)
                {
                    BarcodeReader barcodeReader = new BarcodeReader();
                    Result resulte = barcodeReader.Decode((Bitmap)QR_Code_Scanner.Image);
                    if (resulte != null)
                    {
                        TimeKeeper.Stop();
                        Scanned_RegNumber.Text = resulte.ToString();
                        if (captureDevice.IsRunning)
                        {
                            captureDevice.Stop();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }           
        }

        private void Lecturer_Portal_Load(object sender, EventArgs e)
        {
            #region TimeTable
            try
            {
                string CoursesQuery = "SELECT [Course Code] FROM [Courses] WHERE [Lecturer ID] =  @RegNumber";
                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber;
                connection.Open();
                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                DataTable CoursesDTBL = new DataTable();
                CoursesSDA.Fill(CoursesDTBL);
                connection.Close();

                string TimeTablequery = "Select * FROM [Time Table]";
                SqlCommand TimeTableSelectCommand = new SqlCommand(TimeTablequery, connection);
                connection.Open();
                SqlDataAdapter TimeTablesda = new SqlDataAdapter(TimeTableSelectCommand);
                DataTable TimeTabledtbl = new DataTable();
                TimeTablesda.Fill(TimeTabledtbl);
                connection.Close();


                foreach (DataRow CourseCode in CoursesDTBL.Rows)
                {
                    foreach (DataRow TimeTableRow in TimeTabledtbl.Rows)
                    {
                        #region Monday
                        if ((TimeTableRow["0800-0900"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Monday"))
                        {
                            if (M1.Text.Trim() == "")
                            {
                                M1.Text = TimeTableRow["0800-0900"].ToString().Trim();
                            }
                            else if (M1.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                M1.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["0900-1000"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Monday"))
                        {
                            if (M2.Text.Trim() == "")
                            {
                                M2.Text = TimeTableRow["0900-1000"].ToString().Trim();
                            }
                            else if (M2.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                M2.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1015-1115"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Monday"))
                        {
                            if (M3.Text.Trim() == "")
                            {
                                M3.Text = TimeTableRow["1015-1115"].ToString().Trim();
                            }
                            else if (M3.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                M3.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1115-1215"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Monday"))
                        {
                            if (M4.Text.Trim() == "")
                            {
                                M4.Text = TimeTableRow["1115-1215"].ToString().Trim();
                            }
                            else if (M4.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                M4.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1215-1315"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Monday"))
                        {
                            if (M5.Text.Trim() == "")
                            {
                                M5.Text = TimeTableRow["1215-1315"].ToString().Trim();
                            }
                            else if (M5.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                M5.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1400-1500"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Monday"))
                        {
                            if (M6.Text.Trim() == "")
                            {
                                M6.Text = TimeTableRow["1400-1500"].ToString().Trim();
                            }
                            else if (M6.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                M6.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1500-1600"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Monday"))
                        {
                            if (M7.Text.Trim() == "")
                            {
                                M7.Text = TimeTableRow["1500-1600"].ToString().Trim();
                            }
                            else if (M7.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                M7.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1600-1700"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Monday"))
                        {
                            if (M8.Text.Trim() == "")
                            {
                                M8.Text = TimeTableRow["1600-1700"].ToString().Trim();
                            }
                            else if (M8.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                M8.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1700-1800"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Monday"))
                        {
                            if (M9.Text.Trim() == "")
                            {
                                M9.Text = TimeTableRow["1700-1800"].ToString().Trim();
                            }
                            else if (M9.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                M9.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        #endregion

                        #region Tuesday
                        if ((TimeTableRow["0800-0900"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Tuesday"))
                        {
                            if (T1.Text.Trim() == "")
                            {
                                T1.Text = TimeTableRow["0800-0900"].ToString().Trim();
                            }
                            else if (T1.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                T1.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["0900-1000"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Tuesday"))
                        {
                            if (T2.Text.Trim() == "")
                            {
                                T2.Text = TimeTableRow["0900-1000"].ToString().Trim();
                            }
                            else if (T2.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                T2.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1015-1115"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Tuesday"))
                        {
                            if (T3.Text.Trim() == "")
                            {
                                T3.Text = TimeTableRow["1015-1115"].ToString().Trim();
                            }
                            else if (T3.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                T3.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1115-1215"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Tuesday"))
                        {
                            if (T4.Text.Trim() == "")
                            {
                                T4.Text = TimeTableRow["1115-1215"].ToString().Trim();
                            }
                            else if (T4.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                T4.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1215-1315"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Tuesday"))
                        {
                            if (T5.Text.Trim() == "")
                            {
                                T5.Text = TimeTableRow["1215-1315"].ToString().Trim();
                            }
                            else if (T5.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                T5.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1400-1500"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Tuesday"))
                        {
                            if (T6.Text.Trim() == "")
                            {
                                T6.Text = TimeTableRow["1400-1500"].ToString().Trim();
                            }
                            else if (T6.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                T6.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1500-1600"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Tuesday"))
                        {
                            if (T7.Text.Trim() == "")
                            {
                                T7.Text = TimeTableRow["1500-1600"].ToString().Trim();
                            }
                            else if (T7.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                T7.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1600-1700"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Tuesday"))
                        {
                            if (T8.Text.Trim() == "")
                            {
                                T8.Text = TimeTableRow["1600-1700"].ToString().Trim();
                            }
                            else if (T8.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                T8.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1700-1800"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Tuesday"))
                        {
                            if (T9.Text.Trim() == "")
                            {
                                T9.Text = TimeTableRow["1700-1800"].ToString().Trim();
                            }
                            else if (T9.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                T9.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        #endregion

                        #region Wednesday
                        if ((TimeTableRow["0800-0900"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Wednesday"))
                        {
                            if (W1.Text.Trim() == "")
                            {
                                W1.Text = TimeTableRow["0800-0900"].ToString().Trim();
                            }
                            else if (W1.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                W1.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["0900-1000"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Wednesday"))
                        {
                            if (W2.Text.Trim() == "")
                            {
                                W2.Text = TimeTableRow["0900-1000"].ToString().Trim();
                            }
                            else if (W2.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                W2.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1015-1115"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Wednesday"))
                        {
                            if (W3.Text.Trim() == "")
                            {
                                W3.Text = TimeTableRow["1015-1115"].ToString().Trim();
                            }
                            else if (W3.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                W3.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1115-1215"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Wednesday"))
                        {
                            if (W4.Text.Trim() == "")
                            {
                                W4.Text = TimeTableRow["1115-1215"].ToString().Trim();
                            }
                            else if (W4.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                W4.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1215-1315"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Wednesday"))
                        {
                            if (W5.Text.Trim() == "")
                            {
                                W5.Text = TimeTableRow["1215-1315"].ToString().Trim();
                            }
                            else if (W5.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                W5.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1400-1500"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Wednesday"))
                        {
                            if (W6.Text.Trim() == "")
                            {
                                W6.Text = TimeTableRow["1400-1500"].ToString().Trim();
                            }
                            else if (W6.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                W6.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1500-1600"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Wednesday"))
                        {
                            if (W7.Text.Trim() == "")
                            {
                                W7.Text = TimeTableRow["1500-1600"].ToString().Trim();
                            }
                            else if (W7.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                W7.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1600-1700"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Wednesday"))
                        {
                            if (W8.Text.Trim() == "")
                            {
                                W8.Text = TimeTableRow["1600-1700"].ToString().Trim();
                            }
                            else if (W8.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                W8.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1700-1800"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Wednesday"))
                        {
                            if (W9.Text.Trim() == "")
                            {
                                W9.Text = TimeTableRow["1700-1800"].ToString().Trim();
                            }
                            else if (W9.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                W9.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        #endregion

                        #region Thursday
                        if ((TimeTableRow["0800-0900"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Thursday"))
                        {
                            if (Th1.Text.Trim() == "")
                            {
                                Th1.Text = TimeTableRow["0800-0900"].ToString().Trim();
                            }
                            else if (Th1.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                Th1.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["0900-1000"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Thursday"))
                        {
                            if (Th2.Text.Trim() == "")
                            {
                                Th2.Text = TimeTableRow["0900-1000"].ToString().Trim();
                            }
                            else if (Th2.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                Th2.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1015-1115"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Thursday"))
                        {
                            if (Th3.Text.Trim() == "")
                            {
                                Th3.Text = TimeTableRow["1015-1115"].ToString().Trim();
                            }
                            else if (Th3.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                Th3.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1115-1215"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Thursday"))
                        {
                            if (Th4.Text.Trim() == "")
                            {
                                Th4.Text = TimeTableRow["1115-1215"].ToString().Trim();
                            }
                            else if (Th4.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                Th4.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1215-1315"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Thursday"))
                        {
                            if (Th5.Text.Trim() == "")
                            {
                                Th5.Text = TimeTableRow["1215-1315"].ToString().Trim();
                            }
                            else if (Th5.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                Th5.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1400-1500"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Thursday"))
                        {
                            if (Th6.Text.Trim() == "")
                            {
                                Th6.Text = TimeTableRow["1400-1500"].ToString().Trim();
                            }
                            else if (Th6.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                Th6.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1500-1600"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Thursday"))
                        {
                            if (Th7.Text.Trim() == "")
                            {
                                Th7.Text = TimeTableRow["1500-1600"].ToString().Trim();
                            }
                            else if (Th7.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                Th7.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1600-1700"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Thursday"))
                        {
                            if (Th8.Text.Trim() == "")
                            {
                                Th8.Text = TimeTableRow["1600-1700"].ToString().Trim();
                            }
                            else if (Th8.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                Th8.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1700-1800"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Thursday"))
                        {
                            if (Th9.Text.Trim() == "")
                            {
                                Th9.Text = TimeTableRow["1700-1800"].ToString().Trim();
                            }
                            else if (Th9.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                Th9.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        #endregion

                        #region Friday
                        if ((TimeTableRow["0800-0900"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Friday"))
                        {
                            if (F1.Text.Trim() == "")
                            {
                                F1.Text = TimeTableRow["0800-0900"].ToString().Trim();
                            }
                            else if (F1.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                F1.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["0900-1000"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Friday"))
                        {
                            if (F2.Text.Trim() == "")
                            {
                                F2.Text = TimeTableRow["0900-1000"].ToString().Trim();
                            }
                            else if (F2.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                F2.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1015-1115"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Friday"))
                        {
                            if (F3.Text.Trim() == "")
                            {
                                F3.Text = TimeTableRow["1015-1115"].ToString().Trim();
                            }
                            else if (F3.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                F3.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1115-1215"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Friday"))
                        {
                            if (F4.Text.Trim() == "")
                            {
                                F4.Text = TimeTableRow["1115-1215"].ToString().Trim();
                            }
                            else if (F4.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                F4.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1215-1315"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Friday"))
                        {
                            if (F5.Text.Trim() == "")
                            {
                                F5.Text = TimeTableRow["1215-1315"].ToString().Trim();
                            }
                            else if (F5.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                F5.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1400-1500"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Friday"))
                        {
                            if (F6.Text.Trim() == "")
                            {
                                F6.Text = TimeTableRow["1400-1500"].ToString().Trim();
                            }
                            else if (F6.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                F6.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1500-1600"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Friday"))
                        {
                            if (F7.Text.Trim() == "")
                            {
                                F7.Text = TimeTableRow["1500-1600"].ToString().Trim();
                            }
                            else if (F7.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                F7.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1600-1700"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Friday"))
                        {
                            if (F8.Text.Trim() == "")
                            {
                                F8.Text = TimeTableRow["1600-1700"].ToString().Trim();
                            }
                            else if (F8.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                F8.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        if ((TimeTableRow["1700-1800"].ToString().Trim() == CourseCode["Course Code"].ToString().Trim()) && (TimeTableRow["WeekDay"].ToString().Trim() == "Friday"))
                        {
                            if (F9.Text.Trim() == "")
                            {
                                F9.Text = TimeTableRow["1700-1800"].ToString().Trim();
                            }
                            else if (F9.Text.Trim() != CourseCode["Course Code"].ToString().Trim())
                            {
                                F9.Text += " / " + CourseCode["Course Code"].ToString().Trim();
                            }
                        }
                        #endregion                        
                    }
                }
                
            }
            catch (Exception)
            {
                connection.Close();
                MessageBox.Show("TimeTable failed to load", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion
            
            #region Remove
            try
            {
                M1.Text = M1.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                M2.Text = M2.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                M3.Text = M3.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                M4.Text = M4.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                M5.Text = M5.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                M6.Text = M6.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                M7.Text = M7.Text.Remove(15, 9);
            }
            catch (Exception)
            { }
            
            try
            {
                M8.Text = M8.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                M9.Text = M9.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                T1.Text = T1.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                T2.Text = T2.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                T3.Text = T3.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                T4.Text = T4.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                T5.Text = T5.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                T6.Text = T6.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                T7.Text = T7.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                T8.Text = T8.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                T9.Text = T9.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                W1.Text = W1.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                W2.Text = W2.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                W3.Text = W3.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                W4.Text = W4.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                W5.Text = W5.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                W6.Text = W6.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                W7.Text = W7.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                W8.Text = W8.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                W9.Text = W9.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                Th1.Text = Th1.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                Th2.Text = Th2.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                Th3.Text = Th3.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                Th4.Text = Th4.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                Th5.Text = Th5.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                Th6.Text = Th6.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                Th7.Text = Th7.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                Th8.Text = Th8.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                Th9.Text = Th9.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                F1.Text = F1.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                F2.Text = F2.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                F3.Text = F3.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                F4.Text = F4.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                F5.Text = F5.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                F6.Text = F6.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                F7.Text = F7.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                F8.Text = F8.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            try
            {
                F9.Text = F9.Text.Remove(15, 9);
            }
            catch (Exception)
            { }

            #endregion

            #region Camera
            try
            {
                FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                foreach (FilterInfo filterInfo in FilterInfoCollection)
                {
                    Camera_comboBox.Items.Add(filterInfo.Name);
                    Camera_comboBox.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                
            }
            #endregion
        }

        private void Start_button_Click(object sender, EventArgs e)
        {
            if (Start_button.Text == "&Start")
            {
                #region Students
                try
                {
                    TimeSpan start1 = new TimeSpan(08, 0, 0);
                    TimeSpan end1 = new TimeSpan(09, 0, 0);

                    TimeSpan start2 = new TimeSpan(09, 0, 0);
                    TimeSpan end2 = new TimeSpan(10, 15, 0);

                    TimeSpan start3 = new TimeSpan(10, 15, 0);
                    TimeSpan end3 = new TimeSpan(11, 15, 0);

                    TimeSpan start4 = new TimeSpan(11, 15, 0);
                    TimeSpan end4 = new TimeSpan(12, 15, 0);

                    TimeSpan start5 = new TimeSpan(12, 15, 0);
                    TimeSpan end5 = new TimeSpan(13, 15, 0);

                    TimeSpan start6 = new TimeSpan(14, 0, 0);
                    TimeSpan end6 = new TimeSpan(15, 0, 0);

                    TimeSpan start7 = new TimeSpan(15, 0, 0);
                    TimeSpan end7 = new TimeSpan(16, 0, 0);

                    TimeSpan start8 = new TimeSpan(16, 0, 0);
                    TimeSpan end8 = new TimeSpan(17, 0, 0);

                    TimeSpan start9 = new TimeSpan(17, 0, 0);
                    TimeSpan end9 = new TimeSpan(18, 0, 0);
                    TimeSpan now = DateTime.Now.TimeOfDay;
                    string dateValue = DateTime.Now.ToString("dddd");

                    if (dateValue == "Monday")
                    {
                        #region Monday
                        if (start1 <= now && end1 > now)
                        {
                            #region Load Students
                            //if (M1.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = M1.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start2 <= now && end2 > now)
                        {
                            #region Load Students
                            //if (M2.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = M2.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion

                        }
                        else if (start3 <= now && end3 > now)
                        {
                            #region Load Students
                            //if (M3.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = M3.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();
                                        
                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion

                        }
                        else if (start4 <= now && end4 > now)
                        {
                            #region Load Students
                            //if (M4.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = M4.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion

                        }
                        else if (start5 <= now && end5 > now)
                        {
                            #region Load Students
                            //if (M5.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = M5.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion

                        }
                        else if (start6 <= now && end6 > now)
                        {
                            #region Load Students
                            //if (M6.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = M6.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion

                        }
                        else if (start7 <= now && end7 > now)
                        {
                            #region Load Students
                            //if (M7.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = M7.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion

                        }
                        else if (start8 <= now && end8 > now)
                        {
                            #region Load Students
                            //if (M8.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = M8.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion

                        }
                        else if (start9 <= now && end9 > now)
                        {
                            #region Load Students
                            //if (M9.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = M9.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();
                                        
                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion

                        }
                        #endregion
                    }
                    else if (dateValue == "Tuesday")
                    {
                        #region Tuesday
                        if (start1 <= now && end1 > now)
                        {
                            #region Load Students
                            //if (T1.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = T1.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start2 <= now && end2 > now)
                        {
                            #region Load Students
                            //if (T2.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = T2.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start3 <= now && end3 > now)
                        {
                            #region Load Students
                            //if (T3.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = T3.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start4 <= now && end4 > now)
                        {
                            #region Load Students
                            //if (T4.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = T4.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start5 <= now && end5 > now)
                        {
                            #region Load Students
                            //if (T5.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = T5.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start6 <= now && end6 > now)
                        {
                            #region Load Students
                            //if (T6.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = T6.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start7 <= now && end7 > now)
                        {
                            #region Load Students
                            //if (T7.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = T7.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start8 <= now && end8 > now)
                        {
                            #region Load Students
                            //if (T8.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = T8.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add( StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start9 <= now && end9 > now)
                        {
                            #region Load Students
                            //if (T9.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = T9.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }                        
                        #endregion
                    }
                    else if (dateValue == "Wednesday")
                    {
                        #region Wednesday
                        if (start1 <= now && end1 > now)
                        {
                            #region Load Students
                            //if (W1.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = W1.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start2 <= now && end2 > now)
                        {
                            #region Load Students
                            //if (W2.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = W2.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start3 <= now && end3 > now)
                        {
                            #region Load Students
                            //if (W3.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = W3.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start4 <= now && end4 > now)
                        {
                            #region Load Students
                            //if (W4.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = W4.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start5 <= now && end5 > now)
                        {
                            #region Load Students
                            //if (W5.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = W5.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start6 <= now && end6 > now)
                        {
                            #region Load Students
                            //if (W6.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = W6.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start7 <= now && end7 > now)
                        {
                            #region Load Students
                            //if (W7.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = W7.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start8 <= now && end8 > now)
                        {
                            #region Load Students
                            //if (W8.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = W8.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start9 <= now && end9 > now)
                        {
                            #region Load Students
                            //if (W9.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = W9.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    else if (dateValue == "Thursday")
                    {
                        #region Thursday
                        if (start1 <= now && end1 > now)
                        {
                            #region Load Students
                            //if (Th1.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = Th1.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start2 <= now && end2 > now)
                        {
                            #region Load Students
                            //if (Th2.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = Th2.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start3 <= now && end3 > now)
                        {
                            #region Load Students
                            //if (Th3.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = Th3.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start4 <= now && end4 > now)
                        {
                            #region Load Students
                            //if (Th4.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = Th4.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start5 <= now && end5 > now)
                        {
                            #region Load Students
                            //if (Th5.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = Th5.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start6 <= now && end6 > now)
                        {
                            #region Load Students
                            //if (Th6.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = Th6.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start7 <= now && end7 > now)
                        {
                            #region Load Students
                            //if (Th7.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = Th7.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start8 <= now && end8 > now)
                        {
                            #region Load Students
                            //if (Th8.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = Th8.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start9 <= now && end9 > now)
                        {
                            #region Load Students
                            
                            string[] CourseArray = Th9.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    else if (dateValue == "Friday")
                    {
                        #region Friday
                        if (start1 <= now && end1 > now)
                        {
                            #region Load Students
                            //if (F1.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = F1.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start2 <= now && end2 > now)
                        {
                            #region Load Students
                            //if (F2.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = F2.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start3 <= now && end3 > now)
                        {
                            #region Load Students
                            //if (F3.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = F3.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start4 <= now && end4 > now)
                        {
                            #region Load Students
                            //if (F4.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = F4.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start5 <= now && end5 > now)
                        {
                            #region Load Students
                            //if (F5.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = F5.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start6 <= now && end6 > now)
                        {
                            #region Load Students
                            //if (F6.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = F6.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start7 <= now && end7 > now)
                        {
                            #region Load Students
                            //if (F7.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = F7.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start8 <= now && end8 > now)
                        {
                            #region Load Students
                            //if (F8.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = F8.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();


                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (start9 <= now && end9 > now)
                        {
                            #region Load Students
                            //if (F9.Text == "")
                            //{
                            //    goto CurrentlyFree;
                            //}

                            string[] CourseArray = F9.Text.Split('/');

                            foreach (string Course in CourseArray)
                            {
                                string CoursesQuery = "SELECT [Department], [Level] FROM [Courses] WHERE [Course Code] = @CourseCode and [Lecturer ID] =  @RegNumber";
                                SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                                CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Course.Trim();
                                CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Trim();
                                connection.Open();
                                SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                                DataTable CoursesDTBL = new DataTable();
                                CoursesSDA.Fill(CoursesDTBL);
                                connection.Close();

                                foreach (DataRow Department in CoursesDTBL.Rows)
                                {
                                    string StudentQuery = "SELECT [ID_Number] FROM [Students] WHERE [Department] = @Dept and [Level] =  @Lvl";
                                    SqlCommand StudentSelectCommand = new SqlCommand(StudentQuery, connection);
                                    StudentSelectCommand.Parameters.Add("@Dept", SqlDbType.VarChar, 3).Value = Department["Department"].ToString().Trim();
                                    StudentSelectCommand.Parameters.Add("@Lvl", SqlDbType.VarChar, 3).Value = Department["Level"].ToString().Trim();
                                    connection.Open();
                                    SqlDataAdapter StudentSDA = new SqlDataAdapter(StudentSelectCommand);
                                    DataTable StudentDTBL = new DataTable();
                                    StudentSDA.Fill(StudentDTBL);
                                    connection.Close();

                                    foreach (DataRow Student in StudentDTBL.Rows)
                                    {
                                        string StudentNameQuery = "SELECT [Surname] FROM [System Users] WHERE [ID_Number] = @RegNumber";
                                        SqlCommand StudentNameSelectCommand = new SqlCommand(StudentNameQuery, connection);
                                        StudentNameSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Student["ID_Number"].ToString().Trim();
                                        connection.Open();
                                        SqlDataAdapter StudentNameSDA = new SqlDataAdapter(StudentNameSelectCommand);
                                        DataTable StudentNameDTBL = new DataTable();
                                        StudentNameSDA.Fill(StudentNameDTBL);
                                        connection.Close();

                                        Absent_Students_dataGridView.Rows.Add(false, StudentNameDTBL.Rows[0][0].ToString().Trim(), Student["ID_Number"].ToString().Trim(), Course.Trim());
                                    }
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    goto CurrentlyFree;
                }
                #endregion

                #region Camera
                try
                {
                    captureDevice = new VideoCaptureDevice(FilterInfoCollection[Camera_comboBox.SelectedIndex].MonikerString);
                    captureDevice.NewFrame += CaptureDevice_NewFrame;
                    captureDevice.Start();
                    TimeKeeper.Start();
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                #endregion

                #region Change Button Name
                if (Absent_Students_dataGridView.Rows.Count != 0)
                {
                    Start_button.Text = "&Stop";
                    Start_button.BackColor = Color.Red;
                }
                #endregion
            }
            else if (Start_button.Text == "&Stop")
            {
                #region Update Attendance
                if (Absent_Students_dataGridView.Rows.Count != 0)
                {
                    try
                    {
                        for (int i = 0; i < Absent_Students_dataGridView.Rows.Count; i++)
                        {
                            bool isCellChecked = (bool)Absent_Students_dataGridView.Rows[i].Cells[0].Value;

                            string CoursesQuery = "SELECT  [Total_Attendance_Time], [Total_Excused_Time], [Total_Absent_Time], [Last_Attendance] FROM [Attendance] WHERE [Course_Code] = @CourseCode and [ID_Number] =  @RegNumber";
                            SqlCommand CourseSelectCommand = new SqlCommand(CoursesQuery, connection);
                            CourseSelectCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Absent_Students_dataGridView.Rows[i].Cells[3].Value.ToString().Trim();
                            CourseSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Absent_Students_dataGridView.Rows[i].Cells[2].Value.ToString().Trim();
                            connection.Open();
                            SqlDataAdapter CoursesSDA = new SqlDataAdapter(CourseSelectCommand);
                            DataTable CoursesDTBL = new DataTable();
                            CoursesSDA.Fill(CoursesDTBL);
                            connection.Close();

                            if (CoursesDTBL.Rows.Count == 1)
                            {
                                if (isCellChecked == true)
                                {
                                    string AttendanceQuery = "UPDATE [Attendance]  SET [Total_Attendance_Time] = @TotalAttendanceTime, [Last_Attendance] = @LastAttendance WHERE [ID_Number] = @RegNumber and [Course_Code] = @CourseCode";
                                    SqlCommand AttandanceUpdateCommand = new SqlCommand(AttendanceQuery, connection);
                                    AttandanceUpdateCommand.Parameters.Add("@TotalAttendanceTime", SqlDbType.Int).Value = (Convert.ToInt32(CoursesDTBL.Rows[0][0]) + 1);
                                    AttandanceUpdateCommand.Parameters.Add("@LastAttendance", SqlDbType.VarChar).Value = DateTime.Now.ToString().Trim();
                                    AttandanceUpdateCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Absent_Students_dataGridView.Rows[i].Cells[2].Value.ToString().Trim();
                                    AttandanceUpdateCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Absent_Students_dataGridView.Rows[i].Cells[3].Value.ToString().Trim();
                                    connection.Open();
                                    AttandanceUpdateCommand.ExecuteNonQuery();
                                    connection.Close();
                                }
                                else if (isCellChecked == false && Absent_Students_dataGridView.Rows[i].Cells[4].Value.ToString().Trim() == "")
                                {
                                    string AttendanceQuery = "UPDATE [Attendance]  SET [Total_Absent_Time] = @TotalAbsentTime, [Last_Attendance] = @LastAttendance WHERE [ID_Number] = @RegNumber and [Course_Code] = @CourseCode";
                                    SqlCommand AttandanceUpdateCommand = new SqlCommand(AttendanceQuery, connection);
                                    AttandanceUpdateCommand.Parameters.Add("@TotalAbsentTime", SqlDbType.Int).Value = (Convert.ToInt32(CoursesDTBL.Rows[0][2]) + 1);
                                    AttandanceUpdateCommand.Parameters.Add("@LastAttendance", SqlDbType.VarChar).Value = DateTime.Now.ToString().Trim();
                                    AttandanceUpdateCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Absent_Students_dataGridView.Rows[i].Cells[2].Value.ToString().Trim();
                                    AttandanceUpdateCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Absent_Students_dataGridView.Rows[i].Cells[3].Value.ToString().Trim();
                                    connection.Open();
                                    AttandanceUpdateCommand.ExecuteNonQuery();
                                    connection.Close();
                                }
                                else if (isCellChecked == false && Absent_Students_dataGridView.Rows[i].Cells[4].Value.ToString().Trim() == "Excused")
                                {
                                    string AttendanceQuery = "UPDATE [Attendance]  SET [Total_Excused_Time] = @TotalExcusedTime, [Last_Attendance] = @LastAttendance WHERE [ID_Number] = @RegNumber and [Course_Code] = @CourseCode";
                                    SqlCommand AttandanceUpdateCommand = new SqlCommand(AttendanceQuery, connection);
                                    AttandanceUpdateCommand.Parameters.Add("@TotalExcusedTime", SqlDbType.Int).Value = (Convert.ToInt32(CoursesDTBL.Rows[0][1]) + 1);
                                    AttandanceUpdateCommand.Parameters.Add("@LastAttendance", SqlDbType.VarChar).Value = DateTime.Now.ToString().Trim();
                                    AttandanceUpdateCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Absent_Students_dataGridView.Rows[i].Cells[2].Value.ToString().Trim();
                                    AttandanceUpdateCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Absent_Students_dataGridView.Rows[i].Cells[3].Value.ToString().Trim();
                                    connection.Open();
                                    AttandanceUpdateCommand.ExecuteNonQuery();
                                    connection.Close();
                                }
                                else if (isCellChecked == false && Absent_Students_dataGridView.Rows[i].Cells[4].Value.ToString().Trim() == "Not Excused" || Absent_Students_dataGridView.Rows[i].Cells[4].Value.ToString().Trim() == "")
                                {
                                    string AttendanceQuery = "UPDATE [Attendance]  SET [Total_Absent_Time] = @TotalAbsentTime, [Last_Attendance] = @LastAttendance WHERE [ID_Number] = @RegNumber and [Course_Code] = @CourseCode";
                                    SqlCommand AttandanceUpdateCommand = new SqlCommand(AttendanceQuery, connection);
                                    AttandanceUpdateCommand.Parameters.Add("@TotalAbsentTime", SqlDbType.Int).Value = (Convert.ToInt32(CoursesDTBL.Rows[0][2]) + 1);
                                    AttandanceUpdateCommand.Parameters.Add("@LastAttendance", SqlDbType.VarChar).Value = DateTime.Now.ToString().Trim();
                                    AttandanceUpdateCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Absent_Students_dataGridView.Rows[i].Cells[2].Value.ToString().Trim();
                                    AttandanceUpdateCommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Absent_Students_dataGridView.Rows[i].Cells[3].Value.ToString().Trim();
                                    connection.Open();
                                    AttandanceUpdateCommand.ExecuteNonQuery();
                                    connection.Close();
                                }
                            }
                            else
                            {
                                if (isCellChecked == true)
                                {
                                    SqlCommand Studentscommand = connection.CreateCommand();
                                    Studentscommand.CommandType = CommandType.Text;
                                    Studentscommand.CommandText = "INSERT INTO [Attendance] ([ID_Number], [Course_Code], [Total_Attendance_Time], [Last_Attendance], [Total_Absent_Time], [Total_Excused_Time]) VALUES (@IDNumber, @CourseCode, @TotalAttendanceTime, @LastAttendance, @TotalAbsentTime, @TotalExcusedTime)";
                                    Studentscommand.Parameters.Add("@IDNumber", SqlDbType.VarChar, 8).Value = Absent_Students_dataGridView.Rows[i].Cells[2].Value.ToString().Trim();
                                    Studentscommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Absent_Students_dataGridView.Rows[i].Cells[3].Value.ToString().Trim();
                                    Studentscommand.Parameters.Add("@TotalAttendanceTime", SqlDbType.Int).Value = 1;
                                    Studentscommand.Parameters.Add("@TotalExcusedTime", SqlDbType.Int).Value = 0;
                                    Studentscommand.Parameters.Add("@TotalAbsentTime", SqlDbType.Int).Value = 0;
                                    Studentscommand.Parameters.Add("@LastAttendance", SqlDbType.VarChar).Value = DateTime.Now.ToString().Trim();
                                    connection.Open();
                                    Studentscommand.ExecuteNonQuery();
                                    connection.Close();
                                }
                                else if (isCellChecked == false && Absent_Students_dataGridView.Rows[i].Cells[4].Value.ToString().Trim() == "")
                                {
                                    SqlCommand Studentscommand = connection.CreateCommand();
                                    Studentscommand.CommandType = CommandType.Text;
                                    Studentscommand.CommandText = "INSERT INTO [Attendance] ([ID_Number], [Course_Code], [Total_Absent_Time], [Total_Attendance_Time], [Total_Excused_Time]) VALUES (@IDNumber, @CourseCode, @TotalAbsentTime, @TotalAttendanceTime, @TotalExcusedTime)";
                                    Studentscommand.Parameters.Add("@IDNumber", SqlDbType.VarChar, 8).Value = Absent_Students_dataGridView.Rows[i].Cells[2].Value.ToString().Trim();
                                    Studentscommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Absent_Students_dataGridView.Rows[i].Cells[3].Value.ToString().Trim();
                                    Studentscommand.Parameters.Add("@TotalAbsentTime", SqlDbType.Int).Value = 1;
                                    Studentscommand.Parameters.Add("@TotalAttendanceTime", SqlDbType.Int).Value = 0;
                                    Studentscommand.Parameters.Add("@TotalExcusedTime", SqlDbType.Int).Value = 0;
                                    connection.Open();
                                    Studentscommand.ExecuteNonQuery();
                                    connection.Close();
                                }
                                else if (isCellChecked == false && Absent_Students_dataGridView.Rows[i].Cells[4].Value.ToString().Trim() == "Excused")
                                {
                                    SqlCommand Studentscommand = connection.CreateCommand();
                                    Studentscommand.CommandType = CommandType.Text;
                                    Studentscommand.CommandText = "INSERT INTO [Attendance] ([ID_Number], [Course_Code], [Total_Excused_Time], [Total_Absent_Time], [Total_Attendance_Time]) VALUES (@IDNumber, @CourseCode, @TotalAbsentTime, @TotalAttendanceTime, @TotalExcusedTime)";
                                    Studentscommand.Parameters.Add("@IDNumber", SqlDbType.VarChar, 8).Value = Absent_Students_dataGridView.Rows[i].Cells[2].Value.ToString().Trim();
                                    Studentscommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Absent_Students_dataGridView.Rows[i].Cells[3].Value.ToString().Trim();
                                    Studentscommand.Parameters.Add("@TotalExcusedTime", SqlDbType.Int).Value = 1;
                                    Studentscommand.Parameters.Add("@TotalAbsentTime", SqlDbType.Int).Value = 0;
                                    Studentscommand.Parameters.Add("@TotalAttendanceTime", SqlDbType.Int).Value = 0;
                                    connection.Open();
                                    Studentscommand.ExecuteNonQuery();
                                    connection.Close();
                                }
                                else if (isCellChecked == false && Absent_Students_dataGridView.Rows[i].Cells[4].Value.ToString().Trim() == "Not Excused")
                                {
                                    SqlCommand Studentscommand = connection.CreateCommand();
                                    Studentscommand.CommandType = CommandType.Text;
                                    Studentscommand.CommandText = "INSERT INTO [Attendance] ([ID_Number], [Course_Code], [Total_Absent_Time], [Total_Attendance_Time], [Total_Excused_Time]) VALUES (@IDNumber, @CourseCode, @TotalAbsentTime, @TotalAttendanceTime, @TotalExcusedTime)";
                                    Studentscommand.Parameters.Add("@IDNumber", SqlDbType.VarChar, 8).Value = Absent_Students_dataGridView.Rows[i].Cells[2].Value.ToString().Trim();
                                    Studentscommand.Parameters.Add("@CourseCode", SqlDbType.VarChar).Value = Absent_Students_dataGridView.Rows[i].Cells[3].Value.ToString().Trim();
                                    Studentscommand.Parameters.Add("@TotalAbsentTime", SqlDbType.Int).Value = 1;
                                    Studentscommand.Parameters.Add("@TotalAttendanceTime", SqlDbType.Int).Value = 0;
                                    Studentscommand.Parameters.Add("@TotalExcusedTime", SqlDbType.Int).Value = 0;
                                    connection.Open();
                                    Studentscommand.ExecuteNonQuery();
                                    connection.Close();
                                }
                            }
                        }

                        MessageBox.Show("Attendance Register Updated", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        connection.Close();
                        MessageBox.Show("Attendance Register NOT Updated..." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                     
                    }
                }
                #endregion

                #region Close Camera
                try
                {
                    if (captureDevice.IsRunning)
                    {
                        captureDevice.Stop();
                        TimeKeeper.Stop();
                    }
                }
                catch (Exception /*ex*/)
                {
                    //MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                #endregion

                Start_button.Text = "&Done";
                Start_button.BackColor = Color.GreenYellow;
            }
            else
            {
                #region Close
                try
                {
                    if (captureDevice.IsRunning)
                    {
                        captureDevice.Stop();
                        TimeKeeper.Stop();
                    }
                    Application.Exit();
                }
                catch (Exception)
                {
                    Application.Exit();
                }
                #endregion
            }

        CurrentlyFree:
            ;

        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                QR_Code_Scanner.Image = (Bitmap)eventArgs.Frame.Clone();
            }
            catch (Exception)
            {
                
            }            
        }

        private void Lecturer_Portal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (captureDevice.IsRunning)
                {
                    captureDevice.Stop();
                    TimeKeeper.Stop();
                }
            }
            catch(Exception)
            {
                Application.Exit();
            }
        }

        private void Logout_btn_Click(object sender, EventArgs e)
        {
            #region Close
            try
            {
                if (captureDevice.IsRunning)
                {
                    captureDevice.Stop();
                    TimeKeeper.Stop();
                }
                Application.Exit();
            }
            catch (Exception)
            {
                Application.Exit();
            }
            #endregion
        }

        private void Scanned_RegNumber_TextChanged(object sender, EventArgs e)
        {
            #region Mark Attendance
            if (Scanned_RegNumber.TextLength == 8)
            {
                try
                {
                    string GateQuery = "SELECT  [Check_in_Time], [Check_out_Time] FROM [School Gate] WHERE [ID_Number] =  @RegNumber";
                    SqlCommand GateSelectCommand = new SqlCommand(GateQuery, connection);
                    GateSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = Scanned_RegNumber.Text.Trim();
                    connection.Open();
                    SqlDataAdapter GateSDA = new SqlDataAdapter(GateSelectCommand);
                    DataTable GateDTBL = new DataTable();
                    GateSDA.Fill(GateDTBL);
                    connection.Close();


                    foreach (DataGridViewRow Student in Absent_Students_dataGridView.Rows)
                    {
                        if (Student.Cells[2].Value.ToString().Trim() == Scanned_RegNumber.Text.Trim())
                        {
                            try
                            {
                                if (GateDTBL.Rows[0][0].ToString().Trim() != DBNull.Value.ToString().Trim() && GateDTBL.Rows[0][1].ToString().Trim() == DBNull.Value.ToString().Trim())
                                {
                                    Student.Cells[0].Value = true;
                                    System.Media.SystemSounds.Beep.Play();
                                    NotificationBox pop = new NotificationBox(Student.Cells[1].Value.ToString().Trim(), Student.Cells[2].Value.ToString().Trim());
                                    pop.Show();
                                    WaitSomeTime(pop);
                                    Scanned_RegNumber.Text = "";

                                    #region Camera
                                    try
                                    {
                                        captureDevice = new VideoCaptureDevice(FilterInfoCollection[Camera_comboBox.SelectedIndex].MonikerString);
                                        captureDevice.NewFrame += CaptureDevice_NewFrame;
                                        captureDevice.Start();
                                        TimeKeeper.Start();
                                    }
                                    catch (Exception)
                                    {

                                    }
                                    #endregion
                                }
                                else if (GateDTBL.Rows[0][0].ToString().Trim() == DBNull.Value.ToString().Trim() && GateDTBL.Rows[0][1].ToString().Trim() != DBNull.Value.ToString().Trim())
                                {
                                    Student.Cells[0].Value = false;
                                    System.Media.SystemSounds.Exclamation.Play();
                                    ErrorNotificationBox Errorpop = new ErrorNotificationBox(Student.Cells[1].Value.ToString().Trim(), Student.Cells[2].Value.ToString().Trim());
                                    Errorpop.Show();
                                    WaitSomeTime(Errorpop);
                                    Scanned_RegNumber.Text = "";

                                    #region Camera
                                    try
                                    {
                                        captureDevice = new VideoCaptureDevice(FilterInfoCollection[Camera_comboBox.SelectedIndex].MonikerString);
                                        captureDevice.NewFrame += CaptureDevice_NewFrame;
                                        captureDevice.Start();
                                        TimeKeeper.Start();
                                    }
                                    catch (Exception)
                                    {
                                        //MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    #endregion
                                }
                            }
                            catch (Exception)
                            {
                                connection.Close();
                                System.Media.SystemSounds.Exclamation.Play();
                                ErrorNotificationBox Errorpop = new ErrorNotificationBox(Student.Cells[1].Value.ToString().Trim(), Student.Cells[2].Value.ToString().Trim());
                                Errorpop.Show();
                                WaitSomeTime(Errorpop);
                                Scanned_RegNumber.Text = "";

                                #region Camera
                                try
                                {
                                    captureDevice = new VideoCaptureDevice(FilterInfoCollection[Camera_comboBox.SelectedIndex].MonikerString);
                                    captureDevice.NewFrame += CaptureDevice_NewFrame;
                                    captureDevice.Start();
                                    TimeKeeper.Start();
                                }
                                catch (Exception /*exp*/)
                                {
                                    //MessageBox.Show(exp.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                #endregion
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    connection.Close();
                    MessageBox.Show("The Reg Number is invalid...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Scanned_RegNumber.Text = "";
                }
            }
            else
            {
                #region Camera
                try
                {
                    captureDevice = new VideoCaptureDevice(FilterInfoCollection[Camera_comboBox.SelectedIndex].MonikerString);
                    captureDevice.NewFrame += CaptureDevice_NewFrame;
                    captureDevice.Start();
                    TimeKeeper.Start();
                }
                catch (Exception)
                {
                    
                }
                #endregion
            }
            #endregion
        }

        public async void WaitSomeTime(Form item)
        {
            await System.Threading.Tasks.Task.Delay(3000);
            item.Close();
        }

        private void Attendance_Report_btn_Click(object sender, EventArgs e)
        {
            #region Load Report
            Report.ReportView ReportViewer = new Report.ReportView();
            ReportViewer.Show();
            this.Hide();
            #endregion
        }
    }
}