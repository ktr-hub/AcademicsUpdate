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
    public partial class MarksUI : Form
    {
        public MarksUI()
        {
            InitializeComponent();
        }

        private void MarksUI_Load(object sender, EventArgs e)
        {
            updateComboBoxes();
            DataTable marksDataTable = Marks.Select();
            dataGridMarks.DataSource = marksDataTable;
            dataGridMarks.Columns[0].Visible = false;
            dataGridMarks.Columns[2].Visible = false;
            dataGridMarks.Columns[4].Visible = false;
            dataGridMarks.Columns[5].Visible = false;
            dataGridMarks.Columns[7].Visible = false;
        }

        public void updateComboBoxes()
        {

            cbRoll.DataSource = new BindingSource(Student.rollToId, null);
            cbRoll.DisplayMember = "Key";
            cbRoll.ValueMember = "Value";

            Subject.Select();
            cbSubject.DataSource = new BindingSource(Subject.subjectNameToID, null); 
            cbSubject.DisplayMember = "Key";
            cbSubject.ValueMember = "Value";

            Semester.Select();
            cbSemester.DataSource = new BindingSource(Semester.semesterToId, null);
            cbSemester.DisplayMember = "Key";
            cbSemester.ValueMember = "Value";

            clearAllFields();
        }

        private void dataGridMarks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridMarks.Rows[e.RowIndex];
                txtMarks.Text = row.Cells[8].Value.ToString();
                cbRoll.Text = row.Cells[1].Value.ToString();
                cbSemester.Text = row.Cells[3].Value.ToString();
                cbSubject.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Marks marksObj = new Marks();
                marksObj.student.StudentID = Convert.ToInt32(cbRoll.SelectedValue);
                marksObj.subject.subjectID = Convert.ToInt32(cbSubject.SelectedValue);
                marksObj.semester.semesterID = Convert.ToInt32(cbSemester.SelectedValue);
                marksObj.marks = Convert.ToInt32(txtMarks.Text);

                if (marksObj.Insert())
                {
                    MessageBox.Show("Marks entered successfully");
                    MarksUI_Load(sender,e);
                }
            }
            finally
            {
                clearAllFields();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Marks marksObj = new Marks();
                marksObj.marks = Convert.ToInt32(txtMarks.Text);
                marksObj.MarksID = 0;
                MessageBox.Show( cbRoll.SelectedValue + " " + cbSubject.SelectedValue + " " + cbSemester.SelectedValue);
                foreach (DataGridViewRow row in dataGridMarks.Rows)
                {
                    int id1 = Convert.ToInt32(row.Cells["StudentID"].Value);
                    int id2 = Convert.ToInt32(row.Cells["SubjectID"].Value);
                    int id3 = Convert.ToInt32(row.Cells["SemesterID"].Value);
                    if(id1==Convert.ToInt32(cbRoll.SelectedValue)&&
                        id2== Convert.ToInt32(cbSubject.SelectedValue) &&
                        id3 == Convert.ToInt32(cbSemester.SelectedValue))
                    {
                        marksObj.MarksID = Convert.ToInt32(row.Cells["MarksId"].Value);
                    }
                }

                if (marksObj.MarksID != 0 && marksObj.Update())
                {
                    MarksUI_Load(sender, e);
                    MessageBox.Show("Updated");
                }
                else if (marksObj.MarksID == 0)
                {
                    MessageBox.Show("Data Not found to update. First click add to update later");
                }
                else
                {
                    MessageBox.Show("Not updated");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Enter correct input " + exception.Message);
            }
            finally
            {
                clearAllFields();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Marks marksObj = new Marks();
                marksObj.MarksID = 0;
                foreach (DataGridViewRow row in dataGridMarks.Rows)
                {
                    int id1 = Convert.ToInt32(row.Cells["StudentID"].Value);
                    int id2 = Convert.ToInt32(row.Cells["SubjectID"].Value);
                    int id3 = Convert.ToInt32(row.Cells["SemesterID"].Value);
                    if (id1 == Convert.ToInt32(cbRoll.SelectedValue) &&
                        id2 == Convert.ToInt32(cbSubject.SelectedValue) &&
                        id3 == Convert.ToInt32(cbSemester.SelectedValue))
                    {
                        marksObj.MarksID = Convert.ToInt32(row.Cells["MarksId"].Value);
                    }
                }
                if (marksObj.MarksID != 0 && marksObj.Delete())
                {
                    MarksUI_Load(sender, e);
                    MessageBox.Show("Updated");
                }
                else if (marksObj.MarksID == 0)
                {
                    MessageBox.Show("Data Not found to delete");
                }
                else
                {
                    MessageBox.Show("Not deleted");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Enter correct input " + exception.Message);
            }
            finally
            {
                clearAllFields();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAllFields();
        }

        public void clearAllFields()
        {
            txtMarks.Text = null;
            cbRoll.Text = null;
            cbSemester.Text = null;
            cbSubject.Text = null;
        }

        private void btnGoToStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentUI studentUI = new StudentUI();
            studentUI.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
