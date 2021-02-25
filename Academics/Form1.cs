using Academics.Academics;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Student s = new Student();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            s.Name = textName.Text;
            if (s.Insert(s)) 
            {
                MessageBox.Show("textname updated successfully"); 
            }
            else
            {
                MessageBox.Show("Not inserted");
            }
            
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
