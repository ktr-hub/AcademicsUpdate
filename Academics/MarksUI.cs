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
        string _selectedName;
        DTO dto;
        LocalHostReference.Service1Client lhr = new LocalHostReference.Service1Client();
        public MarksUI()
        {
            InitializeComponent();
        }
        private void MarksUI_Load(object sender, EventArgs e)
        {
            //var bindingList = new BindingList<DTO>(lhr.GetMarksDatatable());
            dataGridMarks.DataSource = new BindingSource(lhr.GetMarksDatatable(), null);
            dataGridMarks.Columns[0].Visible = false;
            dataGridMarks.Columns[2].Visible = false;
            dataGridMarks.Columns[4].Visible = false;
            dataGridMarks.Columns[6].Visible = false;
        }
        private void dataGridMarks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridMarks.Rows[e.RowIndex];
                _selectedMarksID = Convert.ToInt32(row.Cells[0].Value);
                _selectedRollNo = Convert.ToInt32(row.Cells[7].Value);
                _selectedSubject = row.Cells[3].Value.ToString();
                _selectedSemester = row.Cells[5].Value.ToString();
                _enteredMarksScored = Convert.ToInt32(row.Cells[1].Value);
                _selectedName = row.Cells[8].Value.ToString();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            MarksUIClick click = new MarksUIClick();
            click.popUpAdd();
            click.ShowDialog();
            var bindingList = new BindingList<DTO>(lhr.GetMarksDatatable());
            dataGridMarks.DataSource = new BindingSource(bindingList, null);
            dataGridMarks.ClearSelection();
            _selectedMarksID = 0;
            _selectedRollNo = 0;
            _selectedSubject = null;
            _selectedSemester = null;
            _enteredMarksScored = 0;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedMarksID != 0)
            {
                MarksUIClick click = new MarksUIClick();
                click.popUpUpdate(_enteredMarksScored, _selectedSemester, _selectedSubject, _selectedRollNo, _selectedMarksID, _selectedName);
                click.ShowDialog();
                dataGridMarks.DataSource = new BindingSource(lhr.GetMarksDatatable(), null);
                dataGridMarks.ClearSelection();
                _selectedMarksID = 0;
                _selectedRollNo = 0;
                _selectedSubject = null;
                _selectedSemester = null;
                _enteredMarksScored = 0;
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
                        dto.SubjectName = _selectedSubject;
                        dto.SemesterDescription =  _selectedSemester;
                        dto.MarksScored = _enteredMarksScored;
                        dto.MarksID = _selectedMarksID;
                        string _status = lhr.DeleteMarks(dto);
                        MessageBox.Show(_status);
                        dataGridMarks.DataSource = new BindingSource(lhr.GetMarksDatatable(), null);
                        dataGridMarks.ClearSelection();
                        _selectedMarksID = 0;
                        _selectedRollNo = 0;
                        _selectedSubject = null;
                        _selectedSemester = null;
                        _enteredMarksScored = 0;
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
            dataGridMarks.DataSource = new BindingSource(lhr.callSearchMarks(txtSearch.Text), null);
        }
    }
}
