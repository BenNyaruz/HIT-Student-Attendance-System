namespace HIT_Student_Attendance_System.Notifications
{
    partial class ErrorNotificationBox
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
            this.StudentNametxt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StudentNametxt
            // 
            this.StudentNametxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StudentNametxt.BackColor = System.Drawing.Color.Transparent;
            this.StudentNametxt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StudentNametxt.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentNametxt.ForeColor = System.Drawing.Color.White;
            this.StudentNametxt.Location = new System.Drawing.Point(16, 14);
            this.StudentNametxt.Name = "StudentNametxt";
            this.StudentNametxt.Size = new System.Drawing.Size(556, 95);
            this.StudentNametxt.TabIndex = 1;
            this.StudentNametxt.Text = "Student Name";
            this.StudentNametxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErrorNotificationBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(589, 122);
            this.Controls.Add(this.StudentNametxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ErrorNotificationBox";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ErrorNotificationBox";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label StudentNametxt;
    }
}