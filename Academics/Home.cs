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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            PictureBox pb = new PictureBox(); pb.Location = new Point(0, 0);
            pb.Size = new Size(150, 150);
            pb.ImageLocation = @"C:\Users\ktirupat\source\repos\AcademicsUpdate\Academics\img_backtoschool.jpg";
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            StudentUI studentUI = new StudentUI();
            studentUI.ShowDialog();
        }

        private void btnUpdateMarks_Click(object sender, EventArgs e)
        {
            MarksUI marksUI = new MarksUI();
            marksUI.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
