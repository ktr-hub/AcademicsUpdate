using LogicLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Academics
{
    public partial class StudentUI : Form
    {
        DTO dto;
        LocalHostReference.Service1Client lhr = new LocalHostReference.Service1Client();
        int _selectedStudentId;        
        int _selectedRollGrid;
        string _selectedNameGrid;
        public StudentUI()
        {
            InitializeComponent();
        }
        private void StudentUI_Load(object sender, EventArgs e)
        {
            var bindingList = new BindingList<DTO>(lhr.GetStudentDatatable());
            dataGridStudent.DataSource = new BindingSource(bindingList, null);
            dataGridStudent.Columns[0].Visible = false;
            dataGridStudent.Columns[1].Visible = false;
            dataGridStudent.Columns[2].Visible = false;
            dataGridStudent.Columns[3].Visible = false;
            dataGridStudent.Columns[4].Visible = false;
            dataGridStudent.Columns[5].Visible = false;
            dataGridStudent.Columns[6].Visible = false;
        }
        private void dataGridStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridStudent.Rows[e.RowIndex];
                _selectedRollGrid = Convert.ToInt32(row.Cells[7].Value);
                _selectedNameGrid = row.Cells[8].Value.ToString();
                _selectedStudentId = Convert.ToInt32(row.Cells[6].Value);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            StudentClickUI student = new StudentClickUI();
            student.popUpAdd();
            student.ShowDialog();
            dataGridStudent.DataSource = new BindingSource(lhr.GetStudentDatatable(), null);
            dataGridStudent.ClearSelection();
            _selectedRollGrid = 0;
            _selectedNameGrid = null;
            _selectedStudentId = 0;
        }
        private void btnGoToHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridStudent.DataSource = lhr.callSearch(txtSearch.Text);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedRollGrid != 0)
            {
                StudentClickUI student = new StudentClickUI();
                student.popUpUpdate(_selectedRollGrid, _selectedNameGrid, _selectedStudentId);
                student.ShowDialog();
                dataGridStudent.DataSource = new BindingSource(lhr.GetStudentDatatable(), null);
                dataGridStudent.ClearSelection();
                _selectedRollGrid = 0;
                _selectedNameGrid = null;
                _selectedStudentId = 0;
            }
            else
            {
                MessageBox.Show("Please click on index cell to update");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedRollGrid != 0)
                {
                    if (
                    MessageBox.Show("Are you sure to delete this record?",
                                    "Marks Details",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        dto = new DTO();
                        dto.Name = _selectedNameGrid;
                        dto.RollNo = _selectedRollGrid;
                        dto.StudentID = _selectedStudentId;
                        string _status = lhr.DeleteStudent(dto);
                        MessageBox.Show(_status);
                        dataGridStudent.DataSource = new BindingSource(lhr.GetStudentDatatable(), null);
                        dataGridStudent.ClearSelection();
                        _selectedRollGrid = 0;
                        _selectedNameGrid = null;
                        _selectedStudentId = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Please click on index cell to delete");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred");
            }
        }
    }
}
