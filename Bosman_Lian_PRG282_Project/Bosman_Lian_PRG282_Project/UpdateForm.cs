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
    public partial class UpdateForm : Form
    {
        private MainForm _mainForm; //instance of MainForm to use 
        
        private bool studentFound=false; // boolean for found student
        
        public UpdateForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm=mainForm;

            btnUpdatedStudent.Enabled = false; //cannot press button if no student has been updated
            
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {

        }

        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            string studentID = txtStudentID.Text.Trim(); //trim whitespaces
            studentFound = false;

            // Clear fields if the ID is changed
            txtFirstName.Clear();
            txtLastName.Clear();
            txtAge.Clear();
            txtCourseID.Clear();

            if (string.IsNullOrEmpty(studentID))
            {
                txtStudentID.BackColor=Color.White; //default color when no text is entered
                return;
            };

            try
            {
                var lines = File.ReadAllLines("student.txt").ToList(); //read all lines in student.txt file to list
                foreach (string line in lines)
                {
                    string[] fields = line.Split(',').Select(field => field.Trim()).ToArray(); //split each line with commas, trim to remove whitespace adn store each part in array

                    
                    if (fields.Length >= 5 && fields[0].Equals($"Student ID: {studentID}")) //check if array has 5 parts or more, and if first field matches student ID
                    {
                        //if match is found, show in text boxes the given details of student
                        txtFirstName.Text = fields[1].Split(':').Length > 1 ? fields[1].Split(':')[1].Trim() : "";
                        txtLastName.Text = fields[2].Split(':').Length > 1 ? fields[2].Split(':')[1].Trim() : "";
                        txtAge.Text = fields[3].Split(':').Length > 1 ? fields[3].Split(':')[1].Trim() : "";
                        txtCourseID.Text = fields[4].Split(':').Length > 1 ? fields[4].Split(':')[1].Trim() : "";

                        studentFound = true; //indicate student is found and turn text color to green
                        txtStudentID.ForeColor=Color.Green;
                        
                        return;
                    }
                }

                if (!studentFound)
                {
                    txtStudentID.ForeColor=Color.Red; //indicate that student is not found by showing text in red
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching: " + ex.Message);
            }
        }
    
            
            

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCourseID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            
                if (!studentFound)
                {
                    MessageBox.Show("Enter a valid Student ID to update.");
                    return;
                }

                string studentID = txtStudentID.Text.Trim(); //remove whitespaces with trim
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string age = txtAge.Text.Trim();
                string courseID = txtCourseID.Text.Trim();
                if (!string.IsNullOrEmpty(age))
                {
                    if (!int.TryParse(age, out int Age) || Age <= 0)
                    {
                        MessageBox.Show("Age must be a number greater than zero.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                        return;
                    }
                }

                // **Validation for First Name capitalization**
                if (!string.IsNullOrEmpty(firstName) && !char.IsUpper(firstName[0]))
                {
                    MessageBox.Show("First Name must start with a capital letter.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFirstName.Focus();
                    return;
                }

                // **Validation for Last Name capitalization**
                if (!string.IsNullOrEmpty(lastName) && !char.IsUpper(lastName[0]))
                {
                    MessageBox.Show("Last Name must start with a capital letter.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLastName.Focus();
                    return;
                }

                try
                {
                    var lines = File.ReadAllLines("student.txt").ToList(); //reads lines from studnet.txt file and store to list
                    for (int i = 0; i < lines.Count; i++)
                    {
                        string[] fields = lines[i].Split(',').Select(field => field.Trim()).ToArray(); //split lines by commas, trim whitespaces, and store each part to array

                        if (fields.Length >= 5 && fields[0].Equals($"Student ID: {studentID}")) //correct format for array, at least 5 parts, check first field matches student ID
                        {
                            //get existing values
                            string existingFirstName = fields[1].Split(':').Length > 1 ? fields[1].Split(':')[1].Trim() : "";
                            string existingLastName = fields[2].Split(':').Length > 1 ? fields[2].Split(':')[1].Trim() : "";
                            string existingAge = fields[3].Split(':').Length > 1 ? fields[3].Split(':')[1].Trim() : "";
                            string existingCourseID = fields[4].Split(':').Length > 1 ? fields[4].Split(':')[1].Trim() : "";

                            //Only Update details that user entered, if space empty, original value will be displayed and saved
                            string updatedFirstName = !string.IsNullOrEmpty(firstName) ? firstName : existingFirstName;
                            string updatedLastName = !string.IsNullOrEmpty(lastName) ? lastName : existingLastName;
                            string updatedAge = !string.IsNullOrEmpty(age) ? age : existingAge;
                            string updatedCourseID = !string.IsNullOrEmpty(courseID) ? courseID : existingCourseID;




                            lines[i] = $"Student ID: {studentID}, First Name: {updatedFirstName}, Last Name: {updatedLastName}, Age: {updatedAge}, Course ID: {updatedCourseID}"; //update display, keeping unchanged values if any
                            studentFound = true;

                            break;
                        }
                    }

                    File.WriteAllLines("student.txt", lines);
                    MessageBox.Show($"{studentID} successfully updated.");

                    // Refresh the DataGridView in MainForm
                    _mainForm.loadStudents();

                    _mainForm.refreshSummary(); //generate summary report with updated values
                    btnUpdatedStudent.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not update due to error: " + ex.Message);
                }

                //clear text boxes after updated
                txtStudentID.Clear();
                txtFirstName.Clear();
                txtLastName.Clear();
                txtAge.Clear();
                txtCourseID.Clear();
            
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
            this.Close(); //close this form
            _mainForm.Show();
        }

        private void btnUpdatedStudent_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainForm.Show();
        }
    }
}
