
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Academics
{
    public partial class StudentUI : Form
    {
        public StudentUI()
        {
            InitializeComponent();
        }
        private void StudentUI_Load(object sender, EventArgs e)
        {
            DataTable data = Student.Select();
            dataGridStudent.DataSource = data;
            dataGridStudent.Columns[0].Visible = false;
        }

        private void dataGridStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridStudent.Rows[e.RowIndex];
                textRoll.Text = row.Cells[1].Value.ToString();
                textName.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student();
                bool isName = InputValidation.validateString(textName.Text);
                student.Name = textName.Text;
                student.RollNo = Convert.ToInt32(textRoll.Text);
                if (isName && student.Insert())
                {
                    MessageBox.Show("Student inserted successfully");
                    StudentUI_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Not inserted");
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Enter Roll No in integers");
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
                Student student = new Student();
                bool isName = InputValidation.validateString(textName.Text);
                student.Name = textName.Text;
                student.RollNo = Convert.ToInt32(textRoll.Text);
                student.StudentID = Student.rollToId[student.RollNo];
                if (isName && student.Update())
                {
                    MessageBox.Show("Student updated successfully");
                    StudentUI_Load(sender, e);
                }
                else if (isName == false)
                {
                    MessageBox.Show("Enter correct text");
                }
                else
                {
                    MessageBox.Show("Not updated");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter correct inputs");
            }
            catch (Exception)
            {
                MessageBox.Show("Roll No not found to update");
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
                bool isName = InputValidation.validateString(textName.Text);
                Student student = new Student();
                student.Name = textName.Text;
                student.RollNo = Convert.ToInt32(textRoll.Text);
                student.StudentID = Student.rollToId[student.RollNo];
                if (isName && student.Delete())
                {
                    MessageBox.Show("Student deleted successfully");
                    StudentUI_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Not deleted");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter correct input");
            }
            catch (Exception)
            {
                MessageBox.Show("Roll No not found to delete");
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
            textName.Text = null;
            textRoll.Text = null;
        }

        private void btnGoToMarks_Click(object sender, EventArgs e)
        {
            this.Hide();
            MarksUI marksUI = new MarksUI();
            marksUI.ShowDialog();
        }
    }
}
