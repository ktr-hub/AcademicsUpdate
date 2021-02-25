
namespace Academics
{
    partial class MarksUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MarksHeading = new System.Windows.Forms.Label();
            this.lblRoll = new System.Windows.Forms.Label();
            this.lblMarks = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblSemester = new System.Windows.Forms.Label();
            this.cbRoll = new System.Windows.Forms.ComboBox();
            this.cbSemester = new System.Windows.Forms.ComboBox();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.txtMarks = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridMarks = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGoToStudent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMarks)).BeginInit();
            this.SuspendLayout();
            // 
            // MarksHeading
            // 
            this.MarksHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.MarksHeading.Location = new System.Drawing.Point(149, 18);
            this.MarksHeading.Name = "MarksHeading";
            this.MarksHeading.Size = new System.Drawing.Size(176, 45);
            this.MarksHeading.TabIndex = 0;
            this.MarksHeading.Text = "Marks";
            // 
            // lblRoll
            // 
            this.lblRoll.AutoSize = true;
            this.lblRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRoll.Location = new System.Drawing.Point(52, 92);
            this.lblRoll.Name = "lblRoll";
            this.lblRoll.Size = new System.Drawing.Size(74, 25);
            this.lblRoll.TabIndex = 1;
            this.lblRoll.Text = "Roll No";
            // 
            // lblMarks
            // 
            this.lblMarks.AutoSize = true;
            this.lblMarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMarks.Location = new System.Drawing.Point(52, 224);
            this.lblMarks.Name = "lblMarks";
            this.lblMarks.Size = new System.Drawing.Size(66, 25);
            this.lblMarks.TabIndex = 2;
            this.lblMarks.Text = "Marks";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSubject.Location = new System.Drawing.Point(52, 181);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(78, 25);
            this.lblSubject.TabIndex = 3;
            this.lblSubject.Text = "Subject";
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSemester.Location = new System.Drawing.Point(52, 133);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(96, 25);
            this.lblSemester.TabIndex = 4;
            this.lblSemester.Text = "Semester";
            // 
            // cbRoll
            // 
            this.cbRoll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoll.FormattingEnabled = true;
            this.cbRoll.Location = new System.Drawing.Point(260, 92);
            this.cbRoll.Name = "cbRoll";
            this.cbRoll.Size = new System.Drawing.Size(121, 28);
            this.cbRoll.TabIndex = 5;
            // 
            // cbSemester
            // 
            this.cbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSemester.FormattingEnabled = true;
            this.cbSemester.Location = new System.Drawing.Point(260, 134);
            this.cbSemester.Name = "cbSemester";
            this.cbSemester.Size = new System.Drawing.Size(121, 28);
            this.cbSemester.TabIndex = 6;
            // 
            // cbSubject
            // 
            this.cbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Location = new System.Drawing.Point(260, 178);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(121, 28);
            this.cbSubject.TabIndex = 7;
            // 
            // txtMarks
            // 
            this.txtMarks.Location = new System.Drawing.Point(260, 224);
            this.txtMarks.Name = "txtMarks";
            this.txtMarks.Size = new System.Drawing.Size(121, 26);
            this.txtMarks.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(47, 282);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 38);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(170, 282);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(91, 38);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(301, 282);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 38);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridMarks
            // 
            this.dataGridMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMarks.Location = new System.Drawing.Point(418, 72);
            this.dataGridMarks.Name = "dataGridMarks";
            this.dataGridMarks.RowHeadersWidth = 62;
            this.dataGridMarks.RowTemplate.Height = 28;
            this.dataGridMarks.Size = new System.Drawing.Size(595, 366);
            this.dataGridMarks.TabIndex = 12;
            this.dataGridMarks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMarks_CellClick);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(170, 338);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(91, 38);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGoToStudent
            // 
            this.btnGoToStudent.Location = new System.Drawing.Point(51, 399);
            this.btnGoToStudent.Name = "btnGoToStudent";
            this.btnGoToStudent.Size = new System.Drawing.Size(330, 39);
            this.btnGoToStudent.TabIndex = 14;
            this.btnGoToStudent.Text = "Go To Student";
            this.btnGoToStudent.UseVisualStyleBackColor = true;
            this.btnGoToStudent.Click += new System.EventHandler(this.btnGoToStudent_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.Location = new System.Drawing.Point(589, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 45);
            this.label1.TabIndex = 15;
            this.label1.Text = "Marks DataTable";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MarksUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGoToStudent);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dataGridMarks);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtMarks);
            this.Controls.Add(this.cbSubject);
            this.Controls.Add(this.cbSemester);
            this.Controls.Add(this.cbRoll);
            this.Controls.Add(this.lblSemester);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblMarks);
            this.Controls.Add(this.lblRoll);
            this.Controls.Add(this.MarksHeading);
            this.Name = "MarksUI";
            this.Text = "MarksUI";
            this.Load += new System.EventHandler(this.MarksUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMarks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MarksHeading;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.Label lblMarks;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.ComboBox cbRoll;
        private System.Windows.Forms.ComboBox cbSemester;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.TextBox txtMarks;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridMarks;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGoToStudent;
        private System.Windows.Forms.Label label1;
    }
}