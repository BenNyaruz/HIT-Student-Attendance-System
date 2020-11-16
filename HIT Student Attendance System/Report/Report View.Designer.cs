namespace HIT_Student_Attendance_System.Report
{
    partial class ReportView
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.RegNumber_comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Load_btn = new System.Windows.Forms.Button();
            this.Back_btn = new System.Windows.Forms.Button();
            this.regNumberDataSet = new HIT_Student_Attendance_System.System_Database.RegNumberDataSet();
            this.systemUsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.system_UsersTableAdapter = new HIT_Student_Attendance_System.System_Database.RegNumberDataSetTableAdapters.System_UsersTableAdapter();
            this.hITSASDataSet = new HIT_Student_Attendance_System.System_Database.HITSASDataSet();
            this.systemUsersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.system_UsersTableAdapter1 = new HIT_Student_Attendance_System.System_Database.HITSASDataSetTableAdapters.System_UsersTableAdapter();
            this.studentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentsTableAdapter = new HIT_Student_Attendance_System.System_Database.HITSASDataSetTableAdapters.StudentsTableAdapter();
            this.attendanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.attendanceTableAdapter = new HIT_Student_Attendance_System.System_Database.HITSASDataSetTableAdapters.AttendanceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.regNumberDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemUsersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hITSASDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemUsersBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer.BackColor = System.Drawing.Color.LightGray;
            this.reportViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportDataSource1.Name = "StudentNameDataSet";
            reportDataSource1.Value = this.systemUsersBindingSource1;
            reportDataSource2.Name = "DepartmentDataSet";
            reportDataSource2.Value = this.studentsBindingSource;
            reportDataSource3.Name = "AttendanceDataSet";
            reportDataSource3.Value = this.attendanceBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "HIT_Student_Attendance_System.Report.Attendance Report.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(-1, 122);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(1154, 596);
            this.reportViewer.TabIndex = 0;
            this.reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // RegNumber_comboBox
            // 
            this.RegNumber_comboBox.DataSource = this.systemUsersBindingSource;
            this.RegNumber_comboBox.DisplayMember = "ID_Number";
            this.RegNumber_comboBox.FormattingEnabled = true;
            this.RegNumber_comboBox.Location = new System.Drawing.Point(207, 30);
            this.RegNumber_comboBox.Name = "RegNumber_comboBox";
            this.RegNumber_comboBox.Size = new System.Drawing.Size(231, 21);
            this.RegNumber_comboBox.TabIndex = 1;
            this.RegNumber_comboBox.ValueMember = "ID_Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(49, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Student Reg No:";
            // 
            // Load_btn
            // 
            this.Load_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Load_btn.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Load_btn.Location = new System.Drawing.Point(575, 27);
            this.Load_btn.Name = "Load_btn";
            this.Load_btn.Size = new System.Drawing.Size(115, 40);
            this.Load_btn.TabIndex = 3;
            this.Load_btn.Text = "&Load";
            this.Load_btn.UseVisualStyleBackColor = false;
            this.Load_btn.Click += new System.EventHandler(this.Load_btn_Click);
            // 
            // Back_btn
            // 
            this.Back_btn.BackColor = System.Drawing.Color.Red;
            this.Back_btn.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back_btn.Location = new System.Drawing.Point(835, 27);
            this.Back_btn.Name = "Back_btn";
            this.Back_btn.Size = new System.Drawing.Size(115, 40);
            this.Back_btn.TabIndex = 4;
            this.Back_btn.Text = "&Back";
            this.Back_btn.UseVisualStyleBackColor = false;
            this.Back_btn.Click += new System.EventHandler(this.Back_btn_Click);
            // 
            // regNumberDataSet
            // 
            this.regNumberDataSet.DataSetName = "RegNumberDataSet";
            this.regNumberDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // systemUsersBindingSource
            // 
            this.systemUsersBindingSource.DataMember = "System Users";
            this.systemUsersBindingSource.DataSource = this.regNumberDataSet;
            // 
            // system_UsersTableAdapter
            // 
            this.system_UsersTableAdapter.ClearBeforeFill = true;
            // 
            // hITSASDataSet
            // 
            this.hITSASDataSet.DataSetName = "HITSASDataSet";
            this.hITSASDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // systemUsersBindingSource1
            // 
            this.systemUsersBindingSource1.DataMember = "System Users";
            this.systemUsersBindingSource1.DataSource = this.hITSASDataSet;
            // 
            // system_UsersTableAdapter1
            // 
            this.system_UsersTableAdapter1.ClearBeforeFill = true;
            // 
            // studentsBindingSource
            // 
            this.studentsBindingSource.DataMember = "Students";
            this.studentsBindingSource.DataSource = this.hITSASDataSet;
            // 
            // studentsTableAdapter
            // 
            this.studentsTableAdapter.ClearBeforeFill = true;
            // 
            // attendanceBindingSource
            // 
            this.attendanceBindingSource.DataMember = "Attendance";
            this.attendanceBindingSource.DataSource = this.hITSASDataSet;
            // 
            // attendanceTableAdapter
            // 
            this.attendanceTableAdapter.ClearBeforeFill = true;
            // 
            // ReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1154, 720);
            this.Controls.Add(this.Back_btn);
            this.Controls.Add(this.Load_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RegNumber_comboBox);
            this.Controls.Add(this.reportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Report_View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.regNumberDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemUsersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hITSASDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemUsersBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.ComboBox RegNumber_comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Load_btn;
        private System.Windows.Forms.Button Back_btn;
        private System_Database.RegNumberDataSet regNumberDataSet;
        private System.Windows.Forms.BindingSource systemUsersBindingSource;
        private System_Database.RegNumberDataSetTableAdapters.System_UsersTableAdapter system_UsersTableAdapter;
        private System_Database.HITSASDataSet hITSASDataSet;
        private System.Windows.Forms.BindingSource systemUsersBindingSource1;
        private System_Database.HITSASDataSetTableAdapters.System_UsersTableAdapter system_UsersTableAdapter1;
        private System.Windows.Forms.BindingSource studentsBindingSource;
        private System_Database.HITSASDataSetTableAdapters.StudentsTableAdapter studentsTableAdapter;
        private System.Windows.Forms.BindingSource attendanceBindingSource;
        private System_Database.HITSASDataSetTableAdapters.AttendanceTableAdapter attendanceTableAdapter;
    }
}