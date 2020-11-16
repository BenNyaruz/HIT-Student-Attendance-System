namespace HIT_Student_Attendance_System.Report
{
    partial class Email_Reports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.systemUsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hITSASDataSet = new HIT_Student_Attendance_System.System_Database.HITSASDataSet();
            this.attendanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.system_UsersTableAdapter = new HIT_Student_Attendance_System.System_Database.HITSASDataSetTableAdapters.System_UsersTableAdapter();
            this.attendanceTableAdapter = new HIT_Student_Attendance_System.System_Database.HITSASDataSetTableAdapters.AttendanceTableAdapter();
            this.studentsTableAdapter = new HIT_Student_Attendance_System.System_Database.HITSASDataSetTableAdapters.StudentsTableAdapter();
            this.Back_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.systemUsersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hITSASDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // systemUsersBindingSource
            // 
            this.systemUsersBindingSource.DataMember = "System Users";
            this.systemUsersBindingSource.DataSource = this.hITSASDataSet;
            // 
            // hITSASDataSet
            // 
            this.hITSASDataSet.DataSetName = "HITSASDataSet";
            this.hITSASDataSet.EnforceConstraints = false;
            this.hITSASDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // attendanceBindingSource
            // 
            this.attendanceBindingSource.DataMember = "Attendance";
            this.attendanceBindingSource.DataSource = this.hITSASDataSet;
            // 
            // studentsBindingSource
            // 
            this.studentsBindingSource.DataMember = "Students";
            this.studentsBindingSource.DataSource = this.hITSASDataSet;
            // 
            // reportViewer
            // 
            this.reportViewer.BackColor = System.Drawing.Color.Silver;
            reportDataSource4.Name = "StudentNameDataSet";
            reportDataSource4.Value = this.systemUsersBindingSource;
            reportDataSource5.Name = "AttendanceDataSet";
            reportDataSource5.Value = this.attendanceBindingSource;
            reportDataSource6.Name = "DepartmentDataSet";
            reportDataSource6.Value = this.studentsBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "HIT_Student_Attendance_System.Report.Attendance Report.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 53);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(1036, 524);
            this.reportViewer.TabIndex = 0;
            // 
            // system_UsersTableAdapter
            // 
            this.system_UsersTableAdapter.ClearBeforeFill = true;
            // 
            // attendanceTableAdapter
            // 
            this.attendanceTableAdapter.ClearBeforeFill = true;
            // 
            // studentsTableAdapter
            // 
            this.studentsTableAdapter.ClearBeforeFill = true;
            // 
            // Back_btn
            // 
            this.Back_btn.BackColor = System.Drawing.Color.Red;
            this.Back_btn.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back_btn.Location = new System.Drawing.Point(397, 7);
            this.Back_btn.Name = "Back_btn";
            this.Back_btn.Size = new System.Drawing.Size(115, 40);
            this.Back_btn.TabIndex = 5;
            this.Back_btn.Text = "&Back";
            this.Back_btn.UseVisualStyleBackColor = false;
            this.Back_btn.Click += new System.EventHandler(this.Back_btn_Click);
            // 
            // Email_Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 577);
            this.Controls.Add(this.Back_btn);
            this.Controls.Add(this.reportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Email_Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email_Reports";
            this.Load += new System.EventHandler(this.Email_Reports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.systemUsersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hITSASDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System_Database.HITSASDataSet hITSASDataSet;
        private System.Windows.Forms.BindingSource systemUsersBindingSource;
        private System_Database.HITSASDataSetTableAdapters.System_UsersTableAdapter system_UsersTableAdapter;
        private System.Windows.Forms.BindingSource attendanceBindingSource;
        private System_Database.HITSASDataSetTableAdapters.AttendanceTableAdapter attendanceTableAdapter;
        private System.Windows.Forms.BindingSource studentsBindingSource;
        private System_Database.HITSASDataSetTableAdapters.StudentsTableAdapter studentsTableAdapter;
        private System.Windows.Forms.Button Back_btn;
    }
}