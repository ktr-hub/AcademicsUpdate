using LogicLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace Academics
{
    public partial class StudentUI : Form
    {
        DTO dto;
        int _selectedRollGrid;
        string _selectedNameGrid;
        public StudentUI()
        {
            InitializeComponent();
        }
        private void StudentUI_Load(object sender, EventArgs e)
        {
            dto = new DTO();
            DataTable data = dto.GetStudentDatatable();
            dataGridStudent.DataSource = data;
            dataGridStudent.Columns[0].Visible = false;
            dataGridStudent.ClearSelection();
        }
        private void dataGridStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridStudent.Rows[e.RowIndex];
                _selectedRollGrid = Convert.ToInt32(row.Cells[1].Value);
                _selectedNameGrid = row.Cells[2].Value.ToString();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            StudentClickUI student = new StudentClickUI();
            student.popUpAdd();
            student.ShowDialog(); 
            DataTable data = dto.GetStudentDatatable();
            dataGridStudent.DataSource = data;
            dataGridStudent.ClearSelection();
        }
        private void btnGoToHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridStudent.DataSource = dto.callSearch(txtSearch.Text);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedRollGrid != 0)
            {
                StudentClickUI student = new StudentClickUI();
                student.popUpUpdate(_selectedRollGrid, _selectedNameGrid);
                student.ShowDialog(); 
                DataTable data = dto.GetStudentDatatable();
                dataGridStudent.DataSource = data;
                dataGridStudent.ClearSelection();
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
                        dto.DeleteStudent(out string _status);
                        MessageBox.Show(_status); 
                        DataTable data = dto.GetStudentDatatable();
                        dataGridStudent.DataSource = data;
                        dataGridStudent.ClearSelection();
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
