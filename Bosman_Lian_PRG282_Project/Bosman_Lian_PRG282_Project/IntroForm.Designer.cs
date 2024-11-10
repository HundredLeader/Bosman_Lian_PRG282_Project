namespace Bosman_Lian_PRG282_Project
{
    partial class IntroForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroForm));
            this.lblStudentManagement = new System.Windows.Forms.Label();
            this.pbStudentSystem = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentSystem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStudentManagement
            // 
            this.lblStudentManagement.AutoSize = true;
            this.lblStudentManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentManagement.Location = new System.Drawing.Point(215, 49);
            this.lblStudentManagement.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudentManagement.Name = "lblStudentManagement";
            this.lblStudentManagement.Size = new System.Drawing.Size(541, 29);
            this.lblStudentManagement.TabIndex = 0;
            this.lblStudentManagement.Text = "Welcome to our Student Management System";
            this.lblStudentManagement.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbStudentSystem
            // 
            this.pbStudentSystem.Image = ((System.Drawing.Image)(resources.GetObject("pbStudentSystem.Image")));
            this.pbStudentSystem.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbStudentSystem.InitialImage")));
            this.pbStudentSystem.Location = new System.Drawing.Point(266, 94);
            this.pbStudentSystem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbStudentSystem.Name = "pbStudentSystem";
            this.pbStudentSystem.Size = new System.Drawing.Size(500, 375);
            this.pbStudentSystem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStudentSystem.TabIndex = 1;
            this.pbStudentSystem.TabStop = false;
            this.pbStudentSystem.Click += new System.EventHandler(this.pbStudentSystem_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(55, 487);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 52);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(855, 487);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 52);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // IntroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pbStudentSystem);
            this.Controls.Add(this.lblStudentManagement);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "IntroForm";
            this.Text = "Student Management System";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentSystem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStudentManagement;
        private System.Windows.Forms.PictureBox pbStudentSystem;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNext;
    }
}

