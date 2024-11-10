using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Bosman_Lian_PRG282_Project
{
    public partial class IntroForm : Form
    {
        public IntroForm()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void pbStudentSystem_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\bosma\Desktop\Bosman_Lian_PRG282_Project\Student System.PNG"; //change to directory on own computer

            if (File.Exists(filePath))
            {
                pbStudentSystem.Image = Image.FromFile(filePath);// display image from file
                pbStudentSystem.SizeMode= PictureBoxSizeMode.Zoom;
                
            }
            else
            {
                MessageBox.Show("Image not found");
            }
            
            

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var confirmResult= MessageBox.Show("Are you sure you want to Exit?","Confirm Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                this.Close(); //closes form
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            MainForm main= new MainForm();
            this.Hide();

            main.FormClosed += (s, args) => this.Show(); //event handler to show introform when mainform is closed

            main.Show();
            
            

            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
