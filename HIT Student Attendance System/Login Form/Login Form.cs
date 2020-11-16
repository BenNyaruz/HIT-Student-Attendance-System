using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HIT_Student_Attendance_System.Login_Form
{
    public partial class Login_Form : Form
    {
        private readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HIT_Student_Attendance_System.Properties.Settings.Setting"].ConnectionString);

        public Login_Form()
        {
            InitializeComponent();
        }

        private void Accept_btn_Click(object sender, EventArgs e)
        {
            var SecretKey = "b14ca5898a4e4133bbce2ea2315a1916";

            string SystemUsersquery = "Select [School_Role], [Full_Name], [Surname] FROM [System Users] WHERE [ID_Number] = @Username and [Password] = @Password";
            SqlCommand SelectCommand = new SqlCommand(SystemUsersquery, connection);
            SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar, 8).Value = Username_txt.Text.Trim();
            SelectCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = EncryptString(SecretKey, Password_txt.Text.Trim());
            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(SelectCommand);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            connection.Close();

            try
            {
                if (dtbl.Rows[0][0].ToString() == "Student")
                {
                    #region Load Student Portal 
                    Student_Interface.Student_Portal StudentPortal = new Student_Interface.Student_Portal(dtbl.Rows[0][1].ToString(), dtbl.Rows[0][2].ToString(), Username_txt.Text.Trim());
                    this.Hide();
                    connection.Close();
                    StudentPortal.Show();
                    #endregion
                }
                else if (dtbl.Rows[0][0].ToString() == "Staff Members")
                {
                    string StaffQuery = "Select [Staff Title] FROM [Staff Members] WHERE [ID Number] = @Username";
                    SqlCommand SelectStaffCommand = new SqlCommand(StaffQuery, connection);
                    SelectStaffCommand.Parameters.Add("@Username", SqlDbType.VarChar, 8).Value = Username_txt.Text.Trim();
                    connection.Open();
                    SqlDataAdapter Staffsda = new SqlDataAdapter(SelectStaffCommand);
                    DataTable Staffdtbl = new DataTable();
                    Staffsda.Fill(Staffdtbl);
                    connection.Close();

                    if (Staffdtbl.Rows[0][0].ToString() == "Security")
                    {
                        #region Load Security Portal 
                        Staff_Interface.Security_Portal SecurityPortal = new Staff_Interface.Security_Portal(dtbl.Rows[0][1].ToString(), dtbl.Rows[0][2].ToString(), Username_txt.Text.Trim());
                        this.Hide();
                        connection.Close();
                        SecurityPortal.Show();
                        #endregion
                    }
                    else if (Staffdtbl.Rows[0][0].ToString() == "Lecturer")
                    {
                        #region Load Lecturer Portal 
                        Staff_Interface.Lecturer_Portal LecturerPortal = new Staff_Interface.Lecturer_Portal(dtbl.Rows[0][1].ToString(), dtbl.Rows[0][2].ToString(), Username_txt.Text.Trim());
                        this.Hide();
                        connection.Close();
                        LecturerPortal.Show();
                        #endregion
                    }
                    else if (Staffdtbl.Rows[0][0].ToString() == "Admin")
                    {
                        #region Load Admin Portal 
                        Staff_Interface.Administration_Portal AdministrationPortal = new Staff_Interface.Administration_Portal(dtbl.Rows[0][1].ToString(), dtbl.Rows[0][2].ToString(), Username_txt.Text.Trim());
                        this.Hide();
                        connection.Close();
                        AdministrationPortal.Show();
                        #endregion
                    }
                    else
                    {
                        connection.Close();
                        DialogResult dialogResult = MessageBox.Show("Your Username or Password is incorrect", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        if (dialogResult == DialogResult.OK)
                        {
                            Username_txt.Text = "";
                            Password_txt.Text = "";
                            Username_txt.Focus();
                        }
                    }
                }
            }
            catch (Exception)
            {
                connection.Close();
                DialogResult dialogResult = MessageBox.Show("Your Username or Password is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (dialogResult == DialogResult.OK)
                {
                    Username_txt.Text = "";
                    Password_txt.Text = "";
                    Username_txt.Focus();
                }
            }

        }

        private void Quit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Username_txt_TextChanged(object sender, EventArgs e)
        {
            Username_txt.CharacterCasing = CharacterCasing.Upper;
        }

        public static string EncryptString(string key, string plainText)
        {
            #region AES Encryption Algorithm
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);

            #endregion
        }
    }
}
