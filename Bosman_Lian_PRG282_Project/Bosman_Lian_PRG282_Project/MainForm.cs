using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bosman_Lian_PRG282_Project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCourseID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnShowTable_Click(object sender, EventArgs e)
        {
            loadStudents();


        }
        public void loadStudents()
        {
            dataGridView1.ReadOnly = true; //disables typing in DataGridView
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //enables selection of rows in DataGridView
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            //add headings for datagridview
            dataGridView1.Columns.Add("StudentID", "Student ID");
            dataGridView1.Columns.Add("FirstName", "First Name");
            dataGridView1.Columns.Add("LastName", "Last Name");
            dataGridView1.Columns.Add("Age", "Age");
            dataGridView1.Columns.Add("CourseID", "Course ID");

            string filePath = "student.txt";
            try
            {
                string[] lines = File.ReadAllLines(filePath); //read all lines from student.txt

                foreach (string line in lines)
                {
                    string[] fields = line.Split(',').Select(field => field.Trim()).ToArray(); //split each line with comma, remove whitespaces, and save each part to field array

                    //table data from student.txt file
                    string studentID = fields[0].Split(':')[1].Trim();
                    string firstName = fields[1].Split(':')[1].Trim();
                    string lastName = fields[2].Split(':')[1].Trim();
                    string age = fields[3].Split(':')[1].Trim();
                    string courseID = fields[4].Split(':')[1].Trim();

                    dataGridView1.Rows.Add(studentID, firstName, lastName, age, courseID); //add data to DataGridView rows
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("student.txt was not found");

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured" + ex.Message);
            }

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            // Check if all fields are filled in
            if (string.IsNullOrWhiteSpace(txtStudentID.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtAge.Text) ||
                string.IsNullOrWhiteSpace(txtCourseID.Text))
            {
                MessageBox.Show("Please fill in all the fields to add a student.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string courseID = txtCourseID.Text.Trim().ToUpper();

            if (!char.IsUpper(firstName[0]) || !char.IsUpper(lastName[0]))
            {
                MessageBox.Show("The first letters of First name and Last Name should be capitilised ", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                try
                {


                    // To Parse input fields
                    int studentID;
                    int age;

                    // Validate that studentID is a 4- digit number
                    if (!int.TryParse(txtStudentID.Text, out studentID) | txtStudentID.Text.Length != 4 || studentID < 1000 || studentID > 9999)
                    {
                        MessageBox.Show("Student ID must be a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtStudentID.Focus();
                        return;
                    }

                    if (!int.TryParse(txtAge.Text, out age)|| age<=0) //Validate that age is numeric and greater than 0
                    {
                        MessageBox.Show("Age must be a number, greater than 0", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtAge.Focus();
                        return;
                    }


                    string filePath = "student.txt";
                    bool isDuplicate=false;

                    //checks if ID already exists
                    if (File.Exists(filePath))
                    {
                        var lines = File.ReadAllLines(filePath);
                        foreach (var line in lines)
                        {
                            if (line.Contains($"Student ID: {studentID}"))
                            {
                                isDuplicate = true; 
                                break;
                            }
                        }
                    }
                    if (isDuplicate) //prevents entering exisiting student ID number
                    {
                        MessageBox.Show($"Student ID {studentID} already exists. Please use different ID","ID already exists",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtStudentID.Focus();
                        return;
                    }



                    // Format student data as a line in the text file
                    string studentData = $"Student ID: {studentID}, First Name: {firstName}, Last Name: {lastName}, Age: {age}, Course ID: {courseID}";

                    try
                    {
                        using (StreamWriter writer = new StreamWriter(filePath, true))  //write  student data to file student.txt, each student to new line
                        {
                            writer.WriteLine(studentData); //
                        }
                        MessageBox.Show($"{firstName} saved to student.txt");
                        loadStudents();  // Refresh the DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error has occurred: " + ex.Message);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("An error occured" + ex.Message);
                }

                // Clear input fields after successful addition
                txtStudentID.Clear();
                txtFirstName.Clear();
                txtLastName.Clear();
                txtAge.Clear();
                txtCourseID.Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateForm update= new UpdateForm(this);    //new instance of Update Form
            this.Hide();

            update.FormClosed += (s, args) => this.Show();  //attach eventHandler to show Mainform when update form is closed

            update.Show(); //show update form
        }

        

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedRows[0].Cells["StudentID"].Value == null) //ensure empty line or no student data can be clicked
            {
                MessageBox.Show("Please select valid student to delete");
                return;
            }

            var confirmResult = MessageBox.Show($"Are you sure you want to delete this Student?","Confirm Deletion",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {

                string studentID = dataGridView1.SelectedRows[0].Cells["StudentID"].Value.ToString();   //select the value in student id's cell

                string filePath = "student.txt";

                bool deletedStudent = false;

                try
                {
                    var lines = File.ReadAllLines(filePath).Where(line => !line.Contains($"Student ID: {studentID}")).ToList();     //reads filtered lines, exluding any line that contains the student id

                    File.WriteAllLines(filePath, lines);  // write lines to file

                    deletedStudent = true;
                    MessageBox.Show($"Student ID: {studentID} has been deleted");
                    loadStudents();  // call loadStudents method to refresh datagridview
                    updateSummary(); // call summary method to update changes made in the report

                }
                catch
                {
                    MessageBox.Show("Could not delete student");

                }

                if (!deletedStudent)
                {
                    MessageBox.Show("Please select a student on the Table");
                }
            }
               
            

        }

       

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); //closes main form
        }

        private void btnSummaryReport_Click(object sender, EventArgs e)
        {
            //call summary report
            updateSummary(); //call method to generate summary report
            MessageBox.Show("Summary displayed in summary.txt file in the bin folder");
        }
        private void updateSummary()
        {
            string filePath = "student.txt";
            string summaryPath = "summary.txt";

            int studentCount = 0;
            int ageSum = 0;

            try
            {
                // Read each line from student.txt
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    // Split each line and retrieve the Age field
                    string[] fields = line.Split(',').Select(field => field.Trim()).ToArray();
                    if (fields.Length >= 4) // Ensure the line has enough data
                    {
                        string ageString = fields[3].Split(':')[1].Trim();
                        if (int.TryParse(ageString, out int age))
                        {
                            ageSum += age;
                            studentCount++;
                        }
                    }
                }

                // Calculate the average age if there are students
                double averageAge = studentCount > 0 ? (double)ageSum / studentCount : 0;

                // display of the summary text
                string summaryText = $"Total Students: {studentCount}\nAverage Age: {averageAge:F2}";

                // Write the summary report to the summary.txt file in the bin folder
                File.WriteAllText(summaryPath, summaryText);

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("student.txt file was not found. Please ensure that the file exists.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the summary: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void refreshSummary() //called in updateForm
        {
            updateSummary();
        }
    }
    
}
