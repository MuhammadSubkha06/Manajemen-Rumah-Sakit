namespace Quizify2
{
    partial class MainForm
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
            this.lblUser = new System.Windows.Forms.Label();
            this.btnICD11 = new System.Windows.Forms.Button();
            this.btnMstrDctr = new System.Windows.Forms.Button();
            this.btnMstrPatient = new System.Windows.Forms.Button();
            this.btnNewMeet = new System.Windows.Forms.Button();
            this.btnMngMeet = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(31, 21);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(98, 24);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Welcome";
            this.lblUser.Click += new System.EventHandler(this.lblUser_Click);
            // 
            // btnICD11
            // 
            this.btnICD11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnICD11.Location = new System.Drawing.Point(180, 73);
            this.btnICD11.Name = "btnICD11";
            this.btnICD11.Size = new System.Drawing.Size(222, 49);
            this.btnICD11.TabIndex = 2;
            this.btnICD11.Text = "Master ICD-11";
            this.btnICD11.UseVisualStyleBackColor = true;
            this.btnICD11.Click += new System.EventHandler(this.btnICD11_Click);
            // 
            // btnMstrDctr
            // 
            this.btnMstrDctr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMstrDctr.Location = new System.Drawing.Point(180, 128);
            this.btnMstrDctr.Name = "btnMstrDctr";
            this.btnMstrDctr.Size = new System.Drawing.Size(222, 49);
            this.btnMstrDctr.TabIndex = 3;
            this.btnMstrDctr.Text = "Master Doctor";
            this.btnMstrDctr.UseVisualStyleBackColor = true;
            this.btnMstrDctr.Click += new System.EventHandler(this.btnMstrDctr_Click);
            // 
            // btnMstrPatient
            // 
            this.btnMstrPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMstrPatient.Location = new System.Drawing.Point(180, 183);
            this.btnMstrPatient.Name = "btnMstrPatient";
            this.btnMstrPatient.Size = new System.Drawing.Size(222, 49);
            this.btnMstrPatient.TabIndex = 4;
            this.btnMstrPatient.Text = "Master Patient";
            this.btnMstrPatient.UseVisualStyleBackColor = true;
            this.btnMstrPatient.Click += new System.EventHandler(this.btnMstrPatient_Click);
            // 
            // btnNewMeet
            // 
            this.btnNewMeet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewMeet.Location = new System.Drawing.Point(180, 238);
            this.btnNewMeet.Name = "btnNewMeet";
            this.btnNewMeet.Size = new System.Drawing.Size(222, 49);
            this.btnNewMeet.TabIndex = 5;
            this.btnNewMeet.Text = "New Meeting";
            this.btnNewMeet.UseVisualStyleBackColor = true;
            this.btnNewMeet.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnMngMeet
            // 
            this.btnMngMeet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMngMeet.Location = new System.Drawing.Point(180, 293);
            this.btnMngMeet.Name = "btnMngMeet";
            this.btnMngMeet.Size = new System.Drawing.Size(222, 49);
            this.btnMngMeet.TabIndex = 6;
            this.btnMngMeet.Text = "Manage Meeting";
            this.btnMngMeet.UseVisualStyleBackColor = true;
            this.btnMngMeet.Click += new System.EventHandler(this.btnMngMeet_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(462, 21);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(118, 33);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 367);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnMngMeet);
            this.Controls.Add(this.btnNewMeet);
            this.Controls.Add(this.btnMstrPatient);
            this.Controls.Add(this.btnMstrDctr);
            this.Controls.Add(this.btnICD11);
            this.Controls.Add(this.lblUser);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital Management";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnICD11;
        private System.Windows.Forms.Button btnMstrDctr;
        private System.Windows.Forms.Button btnMstrPatient;
        private System.Windows.Forms.Button btnNewMeet;
        private System.Windows.Forms.Button btnMngMeet;
        private System.Windows.Forms.Button btnLogout;
    }
}