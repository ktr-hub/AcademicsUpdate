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
    public partial class StudentClickUI : Form
    {
        DTO dto;
        public StudentClickUI()
        {
            InitializeComponent();
        }
        private void StudentClickUI_Load(object sender, EventArgs e)
        {
            
        }
        public void popUpAdd()
        {
            btnUpdate.Visible = false;
            btnAdd.Visible = true;
        }
        public void popUpUpdate(int rollNo,string name)
        {
            btnUpdate.Visible = true;
            btnAdd.Visible = false;
            textRoll.ReadOnly = true;
            textRoll.Text = rollNo.ToString();
            textName.Text = name;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                dto = new DTO();
                dto.Name = textName.Text;
                dto.RollNo = Convert.ToInt32(textRoll.Text);
                dto.InsertStudent(out string _status);
                MessageBox.Show(_status);
                if(MessageBox.Show("Add Again?","Add Students",MessageBoxButtons.YesNo)==DialogResult.No)
                {
                    Close();
                }
                textName.Clear();
                textRoll.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Roll No should contain numbers only");
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                dto = new DTO();
                dto.Name = textName.Text;
                dto.RollNo = Convert.ToInt32(textRoll.Text);
                dto.UpdateStudent(out string _status);
                MessageBox.Show(_status);
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Roll No should contain numbers only");
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred");
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
