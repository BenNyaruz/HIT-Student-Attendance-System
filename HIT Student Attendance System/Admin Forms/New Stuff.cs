using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HIT_Student_Attendance_System.Admin_Forms
{
    public partial class New_Stuff : Form
    {
        private readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HIT_Student_Attendance_System.Properties.Settings.Setting"].ConnectionString);
        private string Sex;
        private string Marital_Status;
        readonly string AdminFirstName;
        readonly string AdminSurname;
        readonly string AdminRegNumber;

        public New_Stuff(string name, string surname, string regnumber)
        {
            InitializeComponent();
            AdminFirstName = name;
            AdminSurname = surname;
            AdminRegNumber = regnumber;
        }

        private void Save_btn_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Male_radioButton.Checked == true)
                {
                    Sex = Male_radioButton.Text.Trim();
                }
                else if (Female_radioButton.Checked == true)
                {
                    Sex = Female_radioButton.Text.Trim();
                }



                if (Single_radioButton.Checked == true)
                {
                    Marital_Status = Single_radioButton.Text.Trim();
                }
                else if (Married_radioButton.Checked == true)
                {
                    Marital_Status = Married_radioButton.Text.Trim();
                }

                connection.Open();
                SqlCommand Studentscommand = connection.CreateCommand();
                Studentscommand.CommandType = CommandType.Text;
                Studentscommand.CommandText = "INSERT INTO [Staff Members] ([ID Number], [Staff Title]) VALUES (@IDNumber, @StaffTitle)";
                Studentscommand.Parameters.Add("@IDNumber", SqlDbType.VarChar, 8).Value = ID_Number.Text.Trim();
                Studentscommand.Parameters.Add("@StaffTitle", SqlDbType.VarChar).Value = Stuff_Title.Text.Trim();
                Studentscommand.ExecuteNonQuery();



                var SecretKey = "b14ca5898a4e4133bbce2ea2315a1916";

                SqlCommand Userscommand = connection.CreateCommand();
                Userscommand.CommandType = CommandType.Text;
                Userscommand.CommandText = "INSERT INTO [System Users] ([ID_Number], [Full_Name], [Surname], [Sex], [Marital_Status], [School_Role], [Email_Address], [Password]) VALUES (@IDNumber, @FullName, @Surname, @Sex, @MaritalStatus, @SchoolRole, @EmailAddress, @Password)";
                Userscommand.Parameters.Add("@IDNumber", SqlDbType.VarChar, 8).Value = ID_Number.Text.Trim();
                Userscommand.Parameters.Add("@FullName", SqlDbType.VarChar).Value = Full_Name.Text.Trim();
                Userscommand.Parameters.Add("@Surname", SqlDbType.VarChar).Value = Surname.Text.Trim();
                Userscommand.Parameters.Add("@Sex", SqlDbType.VarChar, 1).Value = Sex;
                Userscommand.Parameters.Add("@MaritalStatus", SqlDbType.VarChar).Value = Marital_Status;
                Userscommand.Parameters.Add("@SchoolRole", SqlDbType.VarChar).Value = "Staff Members";
                Userscommand.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = Email_Address.Text.Trim();
                Userscommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = EncryptString(SecretKey, Password.Text.Trim());
                Userscommand.ExecuteNonQuery();


                DialogResult dialogResult = MessageBox.Show("Do you wish to add another Stuff Member?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


                if (dialogResult == DialogResult.Yes)
                {
                    ID_Number.Text = "";
                    Full_Name.Text = "";
                    Surname.Text = "";
                    Male_radioButton.Checked = false;
                    Female_radioButton.Checked = false;
                    Single_radioButton.Checked = false;
                    Married_radioButton.Checked = false;
                    Sex = "";
                    Marital_Status = "";
                    Email_Address.Text = "";
                    Password.Text = "";
                    Stuff_Title.Text = "";
                    connection.Close();
                    ID_Number.Focus();
                }
                else
                {
                    connection.Close();
                    Staff_Interface.Administration_Portal AdministrationPortal = new Staff_Interface.Administration_Portal(AdminFirstName, AdminSurname, AdminRegNumber);
                    AdministrationPortal.Show();
                    Close();
                }
            }
            catch (Exception ex)
            {
                connection.Close();
                DialogResult dialogResult = MessageBox.Show("Data NOT saved....." + ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);

                if (dialogResult == DialogResult.Cancel)
                {
                    connection.Close();
                    Staff_Interface.Administration_Portal AdministrationPortal = new Staff_Interface.Administration_Portal(AdminFirstName, AdminSurname, AdminRegNumber);
                    AdministrationPortal.Show();
                    Close();
                }
            }
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            Staff_Interface.Administration_Portal AdministrationPortal = new Staff_Interface.Administration_Portal(AdminFirstName, AdminSurname, AdminRegNumber);
            this.Hide();
            AdministrationPortal.Show();
        }

        private void ID_Number_TextChanged(object sender, EventArgs e)
        {
            ID_Number.CharacterCasing = CharacterCasing.Upper;
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
    


