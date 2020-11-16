using System;
using System.Drawing;
using System.Windows.Forms;
using ZXing;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Media;

namespace HIT_Student_Attendance_System.Staff_Interface
{
    public partial class Security_Portal : Form
    {
        private readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HIT_Student_Attendance_System.Properties.Settings.Setting"].ConnectionString);
        FilterInfoCollection FilterInfoCollection;
        VideoCaptureDevice captureDevice;
        private byte[] imgbyte;
        private readonly string FirstName;
        private readonly string Surname;
        private readonly string RegNumberVar;

        public Security_Portal(string name, string surname, string regnumber)
        {
            InitializeComponent();
            FirstName = name;
            Surname = surname;
            RegNumberVar = regnumber;
            OfficerName_lbl.Text = FirstName + " " + Surname + " (" + RegNumberVar + ") ";
        } 

        private void Timer1_Tick(object sender, EventArgs e)
        {
            #region QR Code Scan
            if (RegNumber.Text.Trim() == "")
            {
                try
                {
                    if (QRCode.Image != null)
                    {
                        BarcodeReader barcodeReader = new BarcodeReader();
                        Result result = barcodeReader.Decode((Bitmap)QRCode.Image);
                        if (result != null)
                        {
                            RegNumber.Text = result.ToString();
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
            #endregion

            #region Scan Check
            if (RegNumber.Text.Trim() == "")
            {
                Cleared_button.Enabled = false;
            }
            else
            {
                Cleared_button.Enabled = true;
            }
            #endregion
        }

        private void Security_Portal_Load(object sender, EventArgs e)
        {
            #region Start Session
            try
            {
                FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                foreach (FilterInfo filterInfo in FilterInfoCollection)
                {
                    Camera_comboBox.Items.Add(filterInfo.Name);
                    Camera_comboBox.SelectedIndex = 0;
                }
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

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                QRCode.Image = (Bitmap)eventArgs.Frame.Clone();
            }
            catch (Exception)
            {
                
            }
        }

        private void Security_Portal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (captureDevice.IsRunning)
                {
                    captureDevice.Stop();
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void Logout_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegNumberChanged(object sender, EventArgs e)
        {
            #region Load Student Info
            if (RegNumber.Text.Trim() != "")
            {
                try
                {
                    string GateQuery = "SELECT  [School], [Level] FROM [Students] WHERE [ID_Number] =  @RegNumber";
                    SqlCommand GateSelectCommand = new SqlCommand(GateQuery, connection);
                    GateSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Text.Trim();
                    connection.Open();
                    SqlDataAdapter GateSDA = new SqlDataAdapter(GateSelectCommand);
                    DataTable GateDTBL = new DataTable();
                    GateSDA.Fill(GateDTBL);
                    connection.Close();

                    if (GateDTBL.Rows[0][0].ToString() != null)
                    {
                        #region Picture
                        try
                        {
                            string StudentInfoquery = "Select [Picture] FROM [System Users] WHERE [ID_Number] =  @RegNumber";
                            SqlCommand StudentInfoSelectCommand = new SqlCommand(StudentInfoquery, connection);
                            StudentInfoSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Text.Trim();
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
                        Department.Text = GateDTBL.Rows[0][0].ToString();
                        Level.Text = GateDTBL.Rows[0][1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Record Not Found", "Not a Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RegNumber.Text = "";
                    }

                }
                catch (Exception)
                {
                    connection.Close();
                    RegNumber.Text = "";
                }
            }
            #endregion
        }

        private void Cleared_button_Click(object sender, EventArgs e)
        {
            #region Update Attendance

            if (RegNumber.Text != "")
            {
                try
                {
                    string GateQuery = "SELECT  [Check_in_Time], [Check_out_Time] FROM [School Gate] WHERE [ID_Number] =  @RegNumber";
                    SqlCommand GateSelectCommand = new SqlCommand(GateQuery, connection);
                    GateSelectCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Text.Trim();
                    connection.Open();
                    SqlDataAdapter GateSDA = new SqlDataAdapter(GateSelectCommand);
                    DataTable GateDTBL = new DataTable();
                    GateSDA.Fill(GateDTBL);
                    connection.Close();

                    if (GateDTBL.Rows.Count == 0)
                    {
                        connection.Open();
                        SqlCommand Studentscommand = connection.CreateCommand();
                        Studentscommand.CommandType = CommandType.Text;
                        Studentscommand.CommandText = "INSERT INTO [School Gate] ([ID_Number], [Check_in_Time], [Check_out_Time], [Officer_ID]) VALUES (@IDNumber, @CheckinTime, @CheckoutTime, @OfficerID)";
                        Studentscommand.Parameters.Add("@IDNumber", SqlDbType.VarChar, 8).Value = RegNumber.Text.Trim();
                        Studentscommand.Parameters.Add("@CheckinTime", SqlDbType.VarChar).Value = DateTime.Now.ToString().Trim();
                        Studentscommand.Parameters.Add("@CheckoutTime", SqlDbType.VarChar).Value = DBNull.Value.ToString().Trim();
                        Studentscommand.Parameters.Add("@OfficerID", SqlDbType.VarChar, 8).Value = RegNumberVar.Trim();
                        Studentscommand.ExecuteNonQuery();
                        connection.Close();

                        SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                        simpleSound.Play();
                    }
                    else if (GateDTBL.Rows.Count == 1 && GateDTBL.Rows[0][0].ToString() == DBNull.Value.ToString().Trim() && GateDTBL.Rows[0][1].ToString() != DBNull.Value.ToString().Trim())
                    {
                        string AttendanceQuery = "UPDATE [School Gate]  SET [Check_in_Time] = @CheckinTime, [Check_out_Time] = @CheckoutTime, [Officer_ID] = @OfficerID WHERE [ID_Number] = @RegNumber";
                        SqlCommand AttandanceUpdateCommand = new SqlCommand(AttendanceQuery, connection);
                        AttandanceUpdateCommand.Parameters.Add("@CheckinTime", SqlDbType.VarChar).Value = DateTime.Now.ToString().Trim();
                        AttandanceUpdateCommand.Parameters.Add("@CheckoutTime", SqlDbType.VarChar).Value = DBNull.Value.ToString().Trim();
                        AttandanceUpdateCommand.Parameters.Add("@OfficerID", SqlDbType.VarChar, 8).Value = RegNumberVar.Trim();
                        AttandanceUpdateCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Text.Trim();
                        connection.Open();
                        AttandanceUpdateCommand.ExecuteNonQuery();
                        connection.Close();

                        SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                        simpleSound.Play();
                    }
                    else if (GateDTBL.Rows.Count == 1 && GateDTBL.Rows[0][0].ToString() != DBNull.Value.ToString().Trim() && GateDTBL.Rows[0][1].ToString() == DBNull.Value.ToString().Trim())
                    {
                        string AttendanceQuery = "UPDATE [School Gate]  SET [Check_in_Time] = @CheckinTime, [Check_out_Time] = @CheckoutTime, [Officer_ID] = @OfficerID WHERE [ID_Number] = @RegNumber";
                        SqlCommand AttandanceUpdateCommand = new SqlCommand(AttendanceQuery, connection);
                        AttandanceUpdateCommand.Parameters.Add("@CheckinTime", SqlDbType.VarChar).Value = DBNull.Value.ToString().Trim();
                        AttandanceUpdateCommand.Parameters.Add("@CheckoutTime", SqlDbType.VarChar).Value = DateTime.Now.ToString().Trim();
                        AttandanceUpdateCommand.Parameters.Add("@OfficerID", SqlDbType.VarChar, 8).Value = RegNumberVar.Trim();
                        AttandanceUpdateCommand.Parameters.Add("@RegNumber", SqlDbType.VarChar, 8).Value = RegNumber.Text.Trim();
                        connection.Open();
                        AttandanceUpdateCommand.ExecuteNonQuery();
                        connection.Close();

                        SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                        simpleSound.Play();
                    }
                }
                catch (Exception)
                {
                    connection.Close();
                    MessageBox.Show("Student NOT cleared", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                }

                RegNumber.Text = "";
                Student_pictureBox.Image = null;
                Department.Text = "";
                Level.Text = "";
            }
            #endregion

            #region New Session
            try
            {
                captureDevice = new VideoCaptureDevice(FilterInfoCollection[Camera_comboBox.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
            }
            catch (Exception)
            {
                
            }
            #endregion
        }

        private void Error_btn_Click(object sender, EventArgs e)
        {
            RegNumber.Text = "";
            Student_pictureBox.Image = null;
            Department.Text = "";
            Level.Text = "";
            SystemSounds.Exclamation.Play();

            #region New Session
            try
            {                
                captureDevice = new VideoCaptureDevice(FilterInfoCollection[Camera_comboBox.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
            }
            catch (Exception)
            {
                
            }
            #endregion
        }

        private void Camera_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Start Session
            try
            {
                captureDevice = new VideoCaptureDevice(FilterInfoCollection[Camera_comboBox.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
            }
            catch (Exception)
            {
                
            }
            #endregion
        }
    }
}
