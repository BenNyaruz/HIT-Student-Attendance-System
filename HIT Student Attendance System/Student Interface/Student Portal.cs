using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HIT_Student_Attendance_System.Student_Interface
{
    public partial class Student_Portal : Form
    {
        private readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HIT_Student_Attendance_System.Properties.Settings.Setting"].ConnectionString);
        readonly string FirstName;
        readonly string Surname;
        readonly string RegNumber;                
        private string dateValue;
        private byte[] imgbyte;

        public Student_Portal(string name, string surname, string regnumber)
        {
            InitializeComponent();
            FirstName = name;
            Surname = surname;
            RegNumber = regnumber;
            StudentName_lbl.Text = FirstName + " " + Surname + " (" + RegNumber + ") ";
            
        }

        private void Student_Portal_Load(object sender, EventArgs e)
        {
            #region Picture
            try
            {
                string StudentInfoquery = "Select [Picture] FROM [System Users] WHERE [ID_Number] =  @RegNumber";
                SqlCommand StudentInfoSelectCommand = new SqlCommand(StudentInfoquery, connection);
                StudentInfoSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber;
                connection.Open();
                SqlDataReader dr = StudentInfoSelectCommand.ExecuteReader();


                if (dr.Read())
                {
                    imgbyte = (byte[])dr.GetValue(0);
                }
                connection.Close();

                Student_pictureBox.Image = Image.FromStream(new MemoryStream(imgbyte));
            }
            catch (Exception)
            {
                MessageBox.Show("Profile Picture NOT FOUND", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion

            #region TimeTable
            try
            {                
                string Studentquery = "SELECT [Department], [Level] FROM [Students] WHERE [ID_Number] =  @RegNumber";
                SqlCommand StudentSelectCommand = new SqlCommand(Studentquery, connection);
                StudentSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber;
                connection.Open();
                SqlDataAdapter Studentsda = new SqlDataAdapter(StudentSelectCommand);
                DataTable Studentdtbl = new DataTable();
                Studentsda.Fill(Studentdtbl);
                connection.Close();
               
                string TimeTablequery = "SELECT * FROM [Time Table] WHERE [Department Code] = @dept and [Level] = @level";
                SqlCommand TimeTableSelectCommand = new SqlCommand(TimeTablequery, connection);
                TimeTableSelectCommand.Parameters.Add("@dept", SqlDbType.VarChar, 3).Value = Studentdtbl.Rows[0][0].ToString();
                TimeTableSelectCommand.Parameters.Add("@level", SqlDbType.VarChar, 3).Value = Studentdtbl.Rows[0][1].ToString();
                connection.Open();
                SqlDataAdapter TimeTablesda = new SqlDataAdapter(TimeTableSelectCommand);
                DataTable TimeTabledtbl = new DataTable();
                TimeTablesda.Fill(TimeTabledtbl);
                connection.Close();


                M1.Text = TimeTabledtbl.Rows[0][3].ToString();
                M2.Text = TimeTabledtbl.Rows[0][4].ToString();
                M3.Text = TimeTabledtbl.Rows[0][6].ToString();
                M4.Text = TimeTabledtbl.Rows[0][7].ToString();
                M5.Text = TimeTabledtbl.Rows[0][8].ToString();
                M6.Text = TimeTabledtbl.Rows[0][10].ToString();
                M7.Text = TimeTabledtbl.Rows[0][11].ToString();
                M8.Text = TimeTabledtbl.Rows[0][12].ToString();
                M9.Text = TimeTabledtbl.Rows[0][13].ToString();


                T1.Text = TimeTabledtbl.Rows[1][3].ToString();
                T2.Text = TimeTabledtbl.Rows[1][4].ToString();
                T3.Text = TimeTabledtbl.Rows[1][6].ToString();
                T4.Text = TimeTabledtbl.Rows[1][7].ToString();
                T5.Text = TimeTabledtbl.Rows[1][8].ToString();
                T6.Text = TimeTabledtbl.Rows[1][10].ToString();
                T7.Text = TimeTabledtbl.Rows[1][11].ToString();
                T8.Text = TimeTabledtbl.Rows[1][12].ToString();
                T9.Text = TimeTabledtbl.Rows[1][13].ToString();


                W1.Text = TimeTabledtbl.Rows[2][3].ToString();
                W2.Text = TimeTabledtbl.Rows[2][4].ToString();
                W3.Text = TimeTabledtbl.Rows[2][6].ToString();
                W4.Text = TimeTabledtbl.Rows[2][7].ToString();
                W5.Text = TimeTabledtbl.Rows[2][8].ToString();
                W6.Text = TimeTabledtbl.Rows[2][10].ToString();
                W7.Text = TimeTabledtbl.Rows[2][11].ToString();
                W8.Text = TimeTabledtbl.Rows[2][12].ToString();
                W9.Text = TimeTabledtbl.Rows[2][13].ToString();


                Th1.Text = TimeTabledtbl.Rows[3][3].ToString();
                Th2.Text = TimeTabledtbl.Rows[3][4].ToString();
                Th3.Text = TimeTabledtbl.Rows[3][6].ToString();
                Th4.Text = TimeTabledtbl.Rows[3][7].ToString();
                Th5.Text = TimeTabledtbl.Rows[3][8].ToString();
                Th6.Text = TimeTabledtbl.Rows[3][10].ToString();
                Th7.Text = TimeTabledtbl.Rows[3][11].ToString();
                Th8.Text = TimeTabledtbl.Rows[3][12].ToString();
                Th9.Text = TimeTabledtbl.Rows[3][13].ToString();


                F1.Text = TimeTabledtbl.Rows[4][3].ToString();
                F2.Text = TimeTabledtbl.Rows[4][4].ToString();
                F3.Text = TimeTabledtbl.Rows[4][6].ToString();
                F4.Text = TimeTabledtbl.Rows[4][7].ToString();
                F5.Text = TimeTabledtbl.Rows[4][8].ToString();
                F6.Text = TimeTabledtbl.Rows[4][10].ToString();
                F7.Text = TimeTabledtbl.Rows[4][11].ToString();
                F8.Text = TimeTabledtbl.Rows[4][12].ToString();
                F9.Text = TimeTabledtbl.Rows[4][13].ToString();                
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("TimeTable failed to load..." + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion

            #region BaseRooms
            TimeKeeper.Start();
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
                dateValue = DateTime.Now.ToString("dddd");

                if (start1 <= now && end1 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [0800-0900] FROM [Base Rooms] WHERE [WeekDay] =  @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["0800-0900"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["0800-0900"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
                else if (start2 <= now && end2 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [0900-1000] FROM [Base Rooms] WHERE [WeekDay] =   @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["0900-1000"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["0900-1000"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
                else if (start3 <= now && end3 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [1015-1115] FROM [Base Rooms] WHERE [WeekDay] =   @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["1015-1115"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["1015-1115"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
                else if (start4 <= now && end4 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [1115-1215] FROM [Base Rooms] WHERE [WeekDay] =   @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["1115-1215"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["1115-1215"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
                else if (start5 <= now && end5 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [1215-1315] FROM [Base Rooms] WHERE [WeekDay] =   @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["1215-1315"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["1215-1315"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
                else if (start6 <= now && end6 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [1400-1500] FROM [Base Rooms] WHERE [WeekDay] =   @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["1400-1500"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["1400-1500"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
                else if (start7 <= now && end7 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [1500-1600] FROM [Base Rooms] WHERE [WeekDay] =   @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["1500-1600"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["1500-1600"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
                else if (start8 <= now && end8 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [1600-1700] FROM [Base Rooms] WHERE [WeekDay] =   @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["1600-1700"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["1600-1700"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
                else if (start9 <= now && end9 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [1700-1800] FROM [Base Rooms] WHERE [WeekDay] =   @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["1700-1800"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["1700-1800"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("BaseRooms failed to load..." + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion
        }

        private void TimeKeeper_Tick(object sender, EventArgs e)
        {
            #region BaseRooms
            
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
                dateValue = DateTime.Now.ToString("dddd");

                Base_Rooms_dataGridView.Rows.Clear();

                if (start1 <= now && end1 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [0800-0900] FROM [Base Rooms] WHERE [WeekDay] =  @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["0800-0900"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["0800-0900"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
                else if (start2 <= now && end2 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [0900-1000] FROM [Base Rooms] WHERE [WeekDay] =   @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["0900-1000"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["0900-1000"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
                else if (start3 <= now && end3 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [1015-1115] FROM [Base Rooms] WHERE [WeekDay] =   @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["1015-1115"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["1015-1115"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
                else if (start4 <= now && end4 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [1115-1215] FROM [Base Rooms] WHERE [WeekDay] =   @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["1115-1215"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["1115-1215"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
                else if (start5 <= now && end5 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [1215-1315] FROM [Base Rooms] WHERE [WeekDay] =   @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["1215-1315"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["1215-1315"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
                else if (start6 <= now && end6 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [1400-1500] FROM [Base Rooms] WHERE [WeekDay] =   @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["1400-1500"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["1400-1500"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
                else if (start7 <= now && end7 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [1500-1600] FROM [Base Rooms] WHERE [WeekDay] =   @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["1500-1600"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["1500-1600"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
                else if (start8 <= now && end8 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [1600-1700] FROM [Base Rooms] WHERE [WeekDay] =   @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["1600-1700"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["1600-1700"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
                else if (start9 <= now && end9 > now)
                {
                    string BaseRoomQuery = "SELECT [Department Code], [Level], [1700-1800] FROM [Base Rooms] WHERE [WeekDay] =   @dateValue";
                    SqlCommand BaseRoomSelectCommand = new SqlCommand(BaseRoomQuery, connection);
                    BaseRoomSelectCommand.Parameters.Add("@dateValue", SqlDbType.VarChar).Value = dateValue;
                    connection.Open();
                    SqlDataAdapter BaseRoomsda = new SqlDataAdapter(BaseRoomSelectCommand);
                    DataTable BaseRoomdtbl = new DataTable();
                    BaseRoomsda.Fill(BaseRoomdtbl);
                    connection.Close();

                    foreach (DataRow dr in BaseRoomdtbl.Rows)
                    {
                        if (dr["1700-1800"].ToString() != "")
                        {
                            Base_Rooms_dataGridView.Rows.Add(dr["1700-1800"].ToString().Trim(), dr["Department Code"].ToString().Trim(), dr["Level"].ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("BaseRooms failed to load..." + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion
        }

        private void Logout_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}