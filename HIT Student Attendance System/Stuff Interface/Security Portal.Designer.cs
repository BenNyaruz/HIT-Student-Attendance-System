namespace HIT_Student_Attendance_System.Staff_Interface
{
    partial class Security_Portal
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
            this.Outbtn = new System.Windows.Forms.Panel();
            this.OfficerName_lbl = new System.Windows.Forms.Label();
            this.Logout_btn = new System.Windows.Forms.Button();
            this.Officer_pictureBox = new System.Windows.Forms.PictureBox();
            this.Security_Portal_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Error_btn = new System.Windows.Forms.Button();
            this.Level = new System.Windows.Forms.Label();
            this.Department = new System.Windows.Forms.Label();
            this.RegNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Department_lbl = new System.Windows.Forms.Label();
            this.Student_pictureBox = new System.Windows.Forms.PictureBox();
            this.Camera_comboBox = new System.Windows.Forms.ComboBox();
            this.Cleared_button = new System.Windows.Forms.Button();
            this.QRCode = new System.Windows.Forms.PictureBox();
            this.TimeKeeper = new System.Windows.Forms.Timer(this.components);
            this.Outbtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Officer_pictureBox)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Student_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // Outbtn
            // 
            this.Outbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Outbtn.Controls.Add(this.OfficerName_lbl);
            this.Outbtn.Controls.Add(this.Logout_btn);
            this.Outbtn.Controls.Add(this.Officer_pictureBox);
            this.Outbtn.Controls.Add(this.Security_Portal_lbl);
            this.Outbtn.Controls.Add(this.label1);
            this.Outbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Outbtn.Location = new System.Drawing.Point(0, 0);
            this.Outbtn.Name = "Outbtn";
            this.Outbtn.Size = new System.Drawing.Size(1451, 118);
            this.Outbtn.TabIndex = 2;
            // 
            // OfficerName_lbl
            // 
            this.OfficerName_lbl.AutoSize = true;
            this.OfficerName_lbl.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OfficerName_lbl.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.OfficerName_lbl.Location = new System.Drawing.Point(169, 46);
            this.OfficerName_lbl.Name = "OfficerName_lbl";
            this.OfficerName_lbl.Size = new System.Drawing.Size(166, 27);
            this.OfficerName_lbl.TabIndex = 10;
            this.OfficerName_lbl.Text = "Officer\'s Name";
            // 
            // Logout_btn
            // 
            this.Logout_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Logout_btn.BackColor = System.Drawing.Color.Red;
            this.Logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Logout_btn.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logout_btn.ForeColor = System.Drawing.Color.White;
            this.Logout_btn.Location = new System.Drawing.Point(1314, 33);
            this.Logout_btn.Name = "Logout_btn";
            this.Logout_btn.Size = new System.Drawing.Size(125, 53);
            this.Logout_btn.TabIndex = 21;
            this.Logout_btn.Text = "Log out";
            this.Logout_btn.UseVisualStyleBackColor = false;
            this.Logout_btn.Click += new System.EventHandler(this.Logout_btn_Click);
            // 
            // Officer_pictureBox
            // 
            this.Officer_pictureBox.BackColor = System.Drawing.Color.White;
            this.Officer_pictureBox.Image = global::HIT_Student_Attendance_System.Properties.Resources.HIT_logo;
            this.Officer_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.Officer_pictureBox.Name = "Officer_pictureBox";
            this.Officer_pictureBox.Size = new System.Drawing.Size(163, 118);
            this.Officer_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Officer_pictureBox.TabIndex = 9;
            this.Officer_pictureBox.TabStop = false;
            // 
            // Security_Portal_lbl
            // 
            this.Security_Portal_lbl.AutoSize = true;
            this.Security_Portal_lbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Security_Portal_lbl.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.Security_Portal_lbl.Location = new System.Drawing.Point(736, 73);
            this.Security_Portal_lbl.Name = "Security_Portal_lbl";
            this.Security_Portal_lbl.Size = new System.Drawing.Size(117, 17);
            this.Security_Portal_lbl.TabIndex = 7;
            this.Security_Portal_lbl.Text = "Security Portal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Location = new System.Drawing.Point(591, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 33);
            this.label1.TabIndex = 8;
            this.label1.Text = "Student Attendance System";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.Error_btn);
            this.panel3.Controls.Add(this.Level);
            this.panel3.Controls.Add(this.Department);
            this.panel3.Controls.Add(this.RegNumber);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.Department_lbl);
            this.panel3.Controls.Add(this.Student_pictureBox);
            this.panel3.Controls.Add(this.Camera_comboBox);
            this.panel3.Controls.Add(this.Cleared_button);
            this.panel3.Controls.Add(this.QRCode);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1451, 560);
            this.panel3.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(938, 369);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 19);
            this.label8.TabIndex = 19;
            this.label8.Text = "ID Number :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(67, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 26);
            this.label7.TabIndex = 17;
            this.label7.Text = "Camera:";
            // 
            // Error_btn
            // 
            this.Error_btn.BackColor = System.Drawing.Color.OrangeRed;
            this.Error_btn.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_btn.Location = new System.Drawing.Point(554, 208);
            this.Error_btn.Name = "Error_btn";
            this.Error_btn.Size = new System.Drawing.Size(134, 47);
            this.Error_btn.TabIndex = 16;
            this.Error_btn.Text = "&Error";
            this.Error_btn.UseVisualStyleBackColor = false;
            this.Error_btn.Click += new System.EventHandler(this.Error_btn_Click);
            // 
            // Level
            // 
            this.Level.AutoSize = true;
            this.Level.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Level.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Level.Location = new System.Drawing.Point(1045, 462);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(73, 30);
            this.Level.TabIndex = 15;
            this.Level.Text = "Level";
            // 
            // Department
            // 
            this.Department.AutoSize = true;
            this.Department.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Department.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Department.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Department.Location = new System.Drawing.Point(1045, 411);
            this.Department.Name = "Department";
            this.Department.Size = new System.Drawing.Size(148, 30);
            this.Department.TabIndex = 15;
            this.Department.Text = "Department";
            // 
            // RegNumber
            // 
            this.RegNumber.AutoSize = true;
            this.RegNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RegNumber.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegNumber.ForeColor = System.Drawing.SystemColors.Highlight;
            this.RegNumber.Location = new System.Drawing.Point(1045, 360);
            this.RegNumber.Name = "RegNumber";
            this.RegNumber.Size = new System.Drawing.Size(154, 30);
            this.RegNumber.TabIndex = 15;
            this.RegNumber.Text = "Reg Number";
            this.RegNumber.TextChanged += new System.EventHandler(this.RegNumberChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(938, 473);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Level :";
            // 
            // Department_lbl
            // 
            this.Department_lbl.AutoSize = true;
            this.Department_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Department_lbl.Location = new System.Drawing.Point(938, 421);
            this.Department_lbl.Name = "Department_lbl";
            this.Department_lbl.Size = new System.Drawing.Size(108, 19);
            this.Department_lbl.TabIndex = 14;
            this.Department_lbl.Text = "Department :";
            // 
            // Student_pictureBox
            // 
            this.Student_pictureBox.Location = new System.Drawing.Point(938, 31);
            this.Student_pictureBox.Name = "Student_pictureBox";
            this.Student_pictureBox.Size = new System.Drawing.Size(395, 316);
            this.Student_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Student_pictureBox.TabIndex = 13;
            this.Student_pictureBox.TabStop = false;
            // 
            // Camera_comboBox
            // 
            this.Camera_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Camera_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Camera_comboBox.FormattingEnabled = true;
            this.Camera_comboBox.Location = new System.Drawing.Point(197, 21);
            this.Camera_comboBox.Name = "Camera_comboBox";
            this.Camera_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Camera_comboBox.Size = new System.Drawing.Size(304, 28);
            this.Camera_comboBox.TabIndex = 11;
            this.Camera_comboBox.SelectedIndexChanged += new System.EventHandler(this.Camera_comboBox_SelectedIndexChanged);
            // 
            // Cleared_button
            // 
            this.Cleared_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Cleared_button.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cleared_button.Location = new System.Drawing.Point(755, 208);
            this.Cleared_button.Name = "Cleared_button";
            this.Cleared_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Cleared_button.Size = new System.Drawing.Size(134, 47);
            this.Cleared_button.TabIndex = 10;
            this.Cleared_button.Text = "&Cleared";
            this.Cleared_button.UseVisualStyleBackColor = false;
            this.Cleared_button.Click += new System.EventHandler(this.Cleared_button_Click);
            // 
            // QRCode
            // 
            this.QRCode.BackColor = System.Drawing.Color.Snow;
            this.QRCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.QRCode.Location = new System.Drawing.Point(12, 71);
            this.QRCode.Name = "QRCode";
            this.QRCode.Size = new System.Drawing.Size(489, 405);
            this.QRCode.TabIndex = 9;
            this.QRCode.TabStop = false;
            // 
            // TimeKeeper
            // 
            this.TimeKeeper.Interval = 1000;
            this.TimeKeeper.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Security_Portal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1451, 678);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Outbtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Security_Portal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Security Portal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Security_Portal_FormClosing);
            this.Load += new System.EventHandler(this.Security_Portal_Load);
            this.Outbtn.ResumeLayout(false);
            this.Outbtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Officer_pictureBox)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Student_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QRCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Outbtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Security_Portal_lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Camera_comboBox;
        private System.Windows.Forms.Button Cleared_button;
        private System.Windows.Forms.PictureBox QRCode;
        private System.Windows.Forms.Button Error_btn;
        private System.Windows.Forms.Label Level;
        private System.Windows.Forms.Label Department;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Department_lbl;
        private System.Windows.Forms.PictureBox Student_pictureBox;
        private System.Windows.Forms.PictureBox Officer_pictureBox;
        private System.Windows.Forms.Label OfficerName_lbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer TimeKeeper;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Logout_btn;
        private System.Windows.Forms.Label RegNumber;
    }
}