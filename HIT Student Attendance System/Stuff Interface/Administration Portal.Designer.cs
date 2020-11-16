namespace HIT_Student_Attendance_System.Staff_Interface
{
    partial class Administration_Portal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administration_Portal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Logout_btn = new System.Windows.Forms.Button();
            this.AdminName_lbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Security_Portal_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Staff_Managment = new System.Windows.Forms.Button();
            this.Student_Managment = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SendReports_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.Logout_btn);
            this.panel1.Controls.Add(this.AdminName_lbl);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Security_Portal_lbl);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1436, 111);
            this.panel1.TabIndex = 0;
            // 
            // Logout_btn
            // 
            this.Logout_btn.BackColor = System.Drawing.Color.Brown;
            this.Logout_btn.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logout_btn.Location = new System.Drawing.Point(1256, 34);
            this.Logout_btn.Name = "Logout_btn";
            this.Logout_btn.Size = new System.Drawing.Size(115, 40);
            this.Logout_btn.TabIndex = 1;
            this.Logout_btn.Text = "Log out";
            this.Logout_btn.UseVisualStyleBackColor = false;
            this.Logout_btn.Click += new System.EventHandler(this.Logout_btn_Click);
            // 
            // AdminName_lbl
            // 
            this.AdminName_lbl.AutoSize = true;
            this.AdminName_lbl.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminName_lbl.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.AdminName_lbl.Location = new System.Drawing.Point(168, 41);
            this.AdminName_lbl.Name = "AdminName_lbl";
            this.AdminName_lbl.Size = new System.Drawing.Size(162, 27);
            this.AdminName_lbl.TabIndex = 12;
            this.AdminName_lbl.Text = "Admin\'s Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox1.Image = global::HIT_Student_Attendance_System.Properties.Resources.HIT_logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Security_Portal_lbl
            // 
            this.Security_Portal_lbl.AutoSize = true;
            this.Security_Portal_lbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Security_Portal_lbl.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.Security_Portal_lbl.Location = new System.Drawing.Point(684, 64);
            this.Security_Portal_lbl.Name = "Security_Portal_lbl";
            this.Security_Portal_lbl.Size = new System.Drawing.Size(158, 17);
            this.Security_Portal_lbl.TabIndex = 9;
            this.Security_Portal_lbl.Text = "Adminstration Portal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Location = new System.Drawing.Point(560, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 33);
            this.label1.TabIndex = 10;
            this.label1.Text = "Student Attendance System";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.Staff_Managment);
            this.panel2.Controls.Add(this.Student_Managment);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1436, 101);
            this.panel2.TabIndex = 1;
            // 
            // Staff_Managment
            // 
            this.Staff_Managment.BackColor = System.Drawing.Color.RoyalBlue;
            this.Staff_Managment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Staff_Managment.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Staff_Managment.ForeColor = System.Drawing.Color.SpringGreen;
            this.Staff_Managment.Location = new System.Drawing.Point(1165, 24);
            this.Staff_Managment.Name = "Staff_Managment";
            this.Staff_Managment.Size = new System.Drawing.Size(192, 53);
            this.Staff_Managment.TabIndex = 0;
            this.Staff_Managment.Text = "New Staff ";
            this.Staff_Managment.UseVisualStyleBackColor = false;
            this.Staff_Managment.Click += new System.EventHandler(this.Staff_Managment_Click);
            // 
            // Student_Managment
            // 
            this.Student_Managment.BackColor = System.Drawing.Color.RoyalBlue;
            this.Student_Managment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Student_Managment.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Student_Managment.ForeColor = System.Drawing.Color.SpringGreen;
            this.Student_Managment.Location = new System.Drawing.Point(137, 24);
            this.Student_Managment.Name = "Student_Managment";
            this.Student_Managment.Size = new System.Drawing.Size(192, 53);
            this.Student_Managment.TabIndex = 0;
            this.Student_Managment.Text = "New Student";
            this.Student_Managment.UseVisualStyleBackColor = false;
            this.Student_Managment.Click += new System.EventHandler(this.Student_Managment_Click);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.SendReports_btn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 212);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1436, 220);
            this.panel3.TabIndex = 2;
            // 
            // SendReports_btn
            // 
            this.SendReports_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.SendReports_btn.Font = new System.Drawing.Font("Arial Black", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendReports_btn.Location = new System.Drawing.Point(515, 76);
            this.SendReports_btn.Name = "SendReports_btn";
            this.SendReports_btn.Size = new System.Drawing.Size(480, 92);
            this.SendReports_btn.TabIndex = 0;
            this.SendReports_btn.Text = "SEND REPORTS";
            this.SendReports_btn.UseVisualStyleBackColor = false;
            this.SendReports_btn.Click += new System.EventHandler(this.SendReports_btn_Click);
            // 
            // Administration_Portal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 432);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Administration_Portal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administration Portal";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Student_Managment;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Security_Portal_lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label AdminName_lbl;
        private System.Windows.Forms.Button Staff_Managment;
        private System.Windows.Forms.Button Logout_btn;
        private System.Windows.Forms.Button SendReports_btn;
    }
}