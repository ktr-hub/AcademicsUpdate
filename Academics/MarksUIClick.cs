using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academics
{
    public partial class MarksUIClick : Form
    {
        DTO dto = new DTO();
        public MarksUIClick()
        {
            InitializeComponent();
        }
        public void popUpAdd()
        {
            btnUpdate.Visible = false;
            btnAdd.Visible = true;
            updateComboBoxes();
        }
        public void popUpUpdate(int marks, string semester, string subject, int rollNo,int marksId)
        {
            btnUpdate.Visible = true;
            btnAdd.Visible = false;

            cbRoll.Text = rollNo.ToString();
            cbSubject.Text = subject;
            cbSemester.Text = semester;
            txtMarks.Text = marks.ToString();
            cbRoll.Enabled = false;
            cbSubject.Enabled = false;
            cbSemester.Enabled = false;
            dto.MarksID = marksId;
         }
        public void updateComboBoxes()
        {
            dto.FillStudentObjects();
            dto.FillSemesterObjects();
            dto.FillSubjectsObjects();
            cbRoll.DataSource = new BindingSource(dto.studentObjects, null);
            cbRoll.DisplayMember = "RollNo";
            cbRoll.ValueMember = "StudentID";
            cbRoll.SelectedIndex = -1;
            cbSemester.DataSource = new BindingSource(dto.semesterObjects, null);
            cbSemester.DisplayMember = "SemesterDescription";
            cbSemester.ValueMember = "SemesterID";
            cbSemester.SelectedIndex = -1;
            cbSubject.DataSource = new BindingSource(dto.subjectObjects, null);
            cbSubject.DisplayMember = "SubjectName";
            cbSubject.ValueMember = "SubjectID";
            cbSubject.SelectedIndex = -1;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                dto.StudentID = Convert.ToInt32(cbRoll.SelectedValue);
                dto.SubjectID = Convert.ToInt32(cbSubject.SelectedValue);
                dto.SemesterID = Convert.ToInt32(cbSemester.SelectedValue);
                dto.MarksScored = Convert.ToInt32(txtMarks.Text);
                dto.InsertMarks(out string _status);
                MessageBox.Show(_status);
            }
            catch (FormatException)
            {
                MessageBox.Show("Marks should contain valid numbers(0-100)");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error occurred" + exception.Message);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                dto.StudentID = Convert.ToInt32(cbRoll.SelectedValue);
                dto.SubjectID = Convert.ToInt32(cbSubject.SelectedValue);
                dto.SemesterID = Convert.ToInt32(cbSemester.SelectedValue);
                dto.MarksScored = Convert.ToInt32(txtMarks.Text);
                dto.UpdateMarks(out string _status);
                MessageBox.Show(_status);
            }
            catch (FormatException)
            {
                MessageBox.Show("Marks should contain valid numbers(0-100)");
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred");
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MarksUIClick_Load(object sender, EventArgs e)
        {
        }
    }
}
