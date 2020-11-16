using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace HIT_Student_Attendance_System.Report
{
    public partial class Email_Reports : Form
    {
        private readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HIT_Student_Attendance_System.Properties.Settings.Setting"].ConnectionString);

        public Email_Reports()
        {
            InitializeComponent();
        }

        private void Email_Reports_Load(object sender, EventArgs e)
        {
            string EmailQuery = "SELECT [Full_Name], [ID_Number], [Email_Address] FROM [System Users] WHERE [School_Role] = @SchoolRole";
            SqlCommand EmailSelectCommand = new SqlCommand(EmailQuery, connection);
            EmailSelectCommand.Parameters.Add("@SchoolRole", SqlDbType.VarChar).Value = "Student";
            connection.Open();
            SqlDataAdapter EmailSDA = new SqlDataAdapter(EmailSelectCommand);
            DataTable EmailDTBL = new DataTable();
            EmailSDA.Fill(EmailDTBL);
            connection.Close();

            foreach (DataRow Student in EmailDTBL.Rows)
            {
                try
                {
                    // TODO: This line of code loads data into the 'hITSASDataSet.Students' table. You can move, or remove it, as needed.
                    this.studentsTableAdapter.FillBy(this.hITSASDataSet.Students, Student["ID_Number"].ToString().Trim());
                    // TODO: This line of code loads data into the 'hITSASDataSet.Attendance' table. You can move, or remove it, as needed.
                    this.attendanceTableAdapter.FillBy(this.hITSASDataSet.Attendance, Student["ID_Number"].ToString().Trim());
                    // TODO: This line of code loads data into the 'hITSASDataSet.System_Users' table. You can move, or remove it, as needed.
                    this.system_UsersTableAdapter.FillBy(this.hITSASDataSet.System_Users, Student["ID_Number"].ToString().Trim());

                    this.reportViewer.RefreshReport();

                    using (MailMessage Messege = new MailMessage("hitsasemail@gmail.com", Student["Email_Address"].ToString().Trim()))
                    {
                        Messege.Subject = "Attendance Report for" + Student["Full_Name"].ToString().Trim();
                        Messege.Body = "Good Day\n\n Please find the monthly Attendance Report attached below.\n\n\nTimeMap Solutions\nAdministartion\nMr Samupindu\nmesamupindi@hit.ac.zw";
                        Messege.Attachments.Add(new Attachment(ExportReportToPDF(Student["ID_Number"].ToString().Trim(), " Attendance Report.pdf")));
                        Messege.IsBodyHtml = true;
                       
                        SmtpClient smtp = new SmtpClient
                        {
                            Host = "smtp.google.com"
                        };
                        NetworkCredential credential = new NetworkCredential();
                        credential.UserName = "hitsasemail@gmail.com";
                        credential.Password = "hitsas123";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = credential;
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.Send(Messege);
                    }
                    MessageBox.Show("Sent an Email to (" + Student["Full_Name"].ToString().Trim() + ")", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to send an email to (" + Student["Full_Name"].ToString().Trim() + ") ..." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
            }           
        }

        private string ExportReportToPDF(string RegNumber, string reportName)
        {
            try
            {
                Warning[] warnings;
                string[] streamIds;
                string mimeType = "application/pdf";
                string encoding = String.Empty;
                string filenameExtension = String.Empty;
                string deviceInfo = "<DeviceInfo>" + "<OutputFormat>PDF</OutputFormat>" + "<PageWidth>8.5in</PageWidth>" + "<PageHeight>11in</PageHeight>" + "<MarginTop>0.5in</MarginTop>" + "<MarginLeft>1in</MarginLeft>" + "<MarginRight>1in</MarginRight>" + "<MarginBottom>0.5in</MarginBottom>" + "</DeviceInfo>";

                byte[] bytes = reportViewer.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out filenameExtension, out streamIds, out warnings);
                string filename = RegNumber + reportName;
                using (System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
                return filename;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Staff_Interface.Administration_Portal)
                {
                    form.Show();
                    break;
                }
            }
            this.Close();
        }
    }
}
