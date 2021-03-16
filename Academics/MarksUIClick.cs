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
        LocalHostReference.Service1Client lhr = new LocalHostReference.Service1Client();
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
        public void popUpUpdate(int marks, string semester, string subject, int rollNo,int marksId, string name)
        {
            btnUpdate.Visible = true;
            btnAdd.Visible = false;

            cbRoll.Text = rollNo.ToString();
            cbName.Text = name;
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
            cbRoll.DataSource = new BindingSource(lhr.GetStudentDatatable(), null);
            cbRoll.DisplayMember = "RollNo";
            cbRoll.ValueMember = "StudentID";
            cbRoll.SelectedIndex = -1;
            cbName.DataSource = new BindingSource(lhr.GetStudentDatatable(), null);
            cbName.DisplayMember = "NameRollNo";
            cbName.ValueMember = "StudentID";
            cbName.SelectedIndex = -1;
            cbSemester.DataSource = new BindingSource(lhr.GetSemesterDatatable(), null);
            cbSemester.DisplayMember = "SemesterDescription";
            cbSemester.ValueMember = "SemesterID";
            cbSemester.SelectedIndex = -1;
            cbSubject.DataSource = new BindingSource(lhr.GetSubjectsDatatable(), null);
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
                string _status = lhr.InsertMarks(dto);
                MessageBox.Show(_status);
                if (MessageBox.Show("Add Again?", "Add marks", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    Close();
                }
                txtMarks.Clear();
                cbRoll.SelectedIndex = -1;
                cbSemester.SelectedIndex = -1;
                cbSubject.SelectedIndex = -1;
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
                string _status = lhr.UpdateMarks(dto);
                MessageBox.Show(_status);
                Close();
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
        private void cbRoll_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(DTO item in lhr.GetStudentDatatable())
            {
                if (item.StudentID.Equals(cbRoll.SelectedValue))
                {
                    cbName.Text = item.Name+" ( " + item.RollNo.ToString() + " )";
                    break;
                }
            }
        }
        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DTO item in lhr.GetStudentDatatable())
            {
                if (item.StudentID.Equals(cbName.SelectedValue))
                {
                    cbRoll.Text = item.RollNo.ToString();
                    break;
                }
            }
        }
    }
}
