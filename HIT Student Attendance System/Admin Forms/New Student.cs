using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace HIT_Student_Attendance_System.Admin_Forms
{
    public partial class New_Student : Form
    {
        private readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HIT_Student_Attendance_System.Properties.Settings.Setting"].ConnectionString);
        private string Sex;
        private string Marital_Status;
        readonly string AdminFirstName;
        readonly string AdminSurname;
        readonly string AdminRegNumber;

        public New_Student(string name, string surname, string regnumber)
        {
            InitializeComponent();
            AdminFirstName = name;
            AdminSurname = surname;
            AdminRegNumber = regnumber;
        }

        private void Upload_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opf = new OpenFileDialog() { Filter = "Choose Image (*.jpg;)|*.jpg;", ValidateNames = true, Multiselect = false })
            {
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    Student_pictureBox.Image = Image.FromFile(opf.FileName);
                }
            }
        }

        private void Save_btn_Click(object sender, EventArgs e)
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

                //bool IsValidEmail(string email)
                //{
                //    try
                //    {
                //        var addr = new System.Net.Mail.MailAddress(email);
                //        return addr.Address == email;
                //    }
                //    catch
                //    {
                //        return false;
                //    }
                //}

                MemoryStream ms = new MemoryStream();
                Student_pictureBox.Image.Save(ms, Student_pictureBox.Image.RawFormat);
                byte[] imgByte = ms.ToArray();



                connection.Open();
                SqlCommand Studentscommand = connection.CreateCommand();
                Studentscommand.CommandType = CommandType.Text;
                Studentscommand.CommandText = "INSERT INTO [Students] ([ID_Number], [School], [Department], [Level]) VALUES (@IDNumber, @School, @Department, @Level)";
                Studentscommand.Parameters.Add("@IDNumber", SqlDbType.VarChar, 8).Value = ID_Number.Text.Trim();
                Studentscommand.Parameters.Add("@School", SqlDbType.VarChar).Value = School_comboBox.Text.Trim();
                Studentscommand.Parameters.Add("@Department", SqlDbType.VarChar, 3).Value = Department_comboBox.Text.Trim();
                Studentscommand.Parameters.Add("@Level", SqlDbType.VarChar, 3).Value = Level_ComboBox.Text.Trim();
                Studentscommand.ExecuteNonQuery();



                var SecretKey = "b14ca5898a4e4133bbce2ea2315a1916";

                SqlCommand Userscommand = connection.CreateCommand();
                Userscommand.CommandType = CommandType.Text;
                Userscommand.CommandText = "INSERT INTO [System Users] ([ID_Number], [Full_Name], [Surname], [Sex], [Marital_Status], [Picture], [School_Role], [Email_Address], [Password]) VALUES (@IDNumber, @FullName, @Surname, @Sex, @MaritalStatus, @Picture, @SchoolRole, @EmailAddress, @Password)";
                Userscommand.Parameters.Add("@IDNumber", SqlDbType.VarChar, 8).Value = ID_Number.Text.Trim();
                Userscommand.Parameters.Add("@FullName", SqlDbType.VarChar).Value = Full_Name.Text.Trim();
                Userscommand.Parameters.Add("@Surname", SqlDbType.VarChar).Value = Surname.Text.Trim();
                Userscommand.Parameters.Add("@Sex", SqlDbType.VarChar, 1).Value = Sex;
                Userscommand.Parameters.Add("@MaritalStatus", SqlDbType.VarChar).Value = Marital_Status;
                Userscommand.Parameters.Add("@Picture", SqlDbType.VarBinary).Value = imgByte;
                Userscommand.Parameters.Add("@SchoolRole", SqlDbType.VarChar).Value = "Student";
                Userscommand.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = Email_Address.Text.Trim();
                Userscommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = EncryptString(SecretKey, Password.Text.Trim());
                Userscommand.ExecuteNonQuery();

                #region Generate QR Code
                QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
                var qrData = qrGenerator.CreateQrCode(ID_Number.Text.Trim(), QRCoder.QRCodeGenerator.ECCLevel.H);
                var qrCode = new QRCoder.QRCode(qrData);
                var image = qrCode.GetGraphic(150);
                pictureBoxQrImage.Image = image;

                #region Saving QR Code
                SaveFileDialog sf = new SaveFileDialog
                {
                    Filter = "JPG(*.JPG)|*.jpg"
                };

                if (sf.ShowDialog() == DialogResult.OK)
                {                 
                    pictureBoxQrImage.Image.Save(sf.FileName);
                }
                #endregion

                #endregion

                DialogResult dialogResult = MessageBox.Show("Do you wish to add another Student?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                              

                if (dialogResult == DialogResult.Yes)
                {
                    ID_Number.Text ="";
                    School_comboBox.Text = "";
                    Department_comboBox.Text = "";
                    Level_ComboBox.Text = "";
                    Full_Name.Text = "";
                    Surname.Text = "";
                    Male_radioButton.Checked = false;
                    Female_radioButton.Checked = false;
                    Single_radioButton.Checked = false;
                    Married_radioButton.Checked = false;
                    Sex = "";
                    Marital_Status = "";
                    imgByte = null;
                    Email_Address.Text = "";
                    Password.Text = "";
                    Student_pictureBox.Image = null;
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
            catch(Exception ex)
            {
                connection.Close();
                DialogResult dialogResult = MessageBox.Show("Data NOT saved..." + ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);

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
            AdministrationPortal.Show();
            Close();
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

        private void School_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (School_comboBox.Text.Trim() == "Information Security Assurance")
            {
                Department_comboBox.Text = "ISS";
            }
            else if (School_comboBox.Text.Trim() == "Information Technology")
            {
                Department_comboBox.Text = "IIT";
            }
            else if (School_comboBox.Text.Trim() == "Software Engineering")
            {
                Department_comboBox.Text = "ISE";
            }
            else if (School_comboBox.Text.Trim() == "Computer Science")
            {
                Department_comboBox.Text = "ICE";
            }
        }
    }
}
