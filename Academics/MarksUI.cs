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
    public partial class MarksUI : Form
    {
        int _selectedRollNo;
        string _selectedSubject;
        string _selectedSemester;
        int _enteredMarksScored;
        int _selectedMarksID;
        DTO dto;
        public MarksUI()
        {
            InitializeComponent();
        }

        private void MarksUI_Load(object sender, EventArgs e)
        {
            dto = new DTO();
            DataTable data = dto.GetMarksDatatable();
            dataGridMarks.DataSource = data;
            dataGridMarks.Columns[0].Visible = false;
            dataGridMarks.Columns[4].Visible = false;
            dataGridMarks.Columns[5].Visible = false;
            dataGridMarks.Columns[7].Visible = false;
            dataGridMarks.ClearSelection();
            dataGridMarks.CurrentCell = null;
        }
        private void dataGridMarks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridMarks.Rows[e.RowIndex];
                _selectedMarksID = Convert.ToInt32(row.Cells[7].Value);
                _selectedRollNo = Convert.ToInt32(row.Cells[1].Value);
                _selectedSubject = row.Cells[6].Value.ToString();
                _selectedSemester = row.Cells[3].Value.ToString();
                _enteredMarksScored = Convert.ToInt32(row.Cells[8].Value);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MarksUIClick click = new MarksUIClick();
            click.popUpAdd();
            click.ShowDialog();
            DataTable data = dto.GetMarksDatatable();
            dataGridMarks.DataSource = data;
            dataGridMarks.ClearSelection();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedMarksID != 0)
            {
                MarksUIClick click = new MarksUIClick();
                click.popUpUpdate(_enteredMarksScored, _selectedSemester, _selectedSubject, _selectedRollNo, _selectedMarksID);
                click.ShowDialog(); 
                DataTable data = dto.GetMarksDatatable();
                dataGridMarks.DataSource = data;
                dataGridMarks.ClearSelection();
            }
            else
            {
                MessageBox.Show("Please click any cell to update");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedMarksID != 0)
                {
                    if (
                    MessageBox.Show("Are you sure to delete this record?",
                                    "Marks Details",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        dto = new DTO();
                        dto.RollNo = _selectedRollNo;
                        dto.subjectName = _selectedSubject;
                        dto.SemesterDescription =  _selectedSemester;
                        dto.MarksScored = _enteredMarksScored;
                        dto.MarksID = _selectedMarksID;
                        dto.DeleteMarks(out string _status);
                        MessageBox.Show(_status); 
                        DataTable data = dto.GetMarksDatatable();
                        dataGridMarks.DataSource = data;
                        dataGridMarks.ClearSelection();
                    }
                }
                else
                {
                    MessageBox.Show("Please click any cell to delete");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Enter correct input " + exception.Message);
            }
        }

        private void btnGoToStudent_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridMarks.DataSource = dto.callSearchMarks(txtSearch.Text);
        }
    }
}
