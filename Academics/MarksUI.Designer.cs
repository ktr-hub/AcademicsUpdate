
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridMarks = new System.Windows.Forms.DataGridView();
            this.btnGoToHome = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMarks)).BeginInit();
            this.SuspendLayout();
            // 
            // MarksHeading
            // 
            this.MarksHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MarksHeading.Location = new System.Drawing.Point(642, 83);
            this.MarksHeading.Name = "MarksHeading";
            this.MarksHeading.Size = new System.Drawing.Size(101, 33);
            this.MarksHeading.TabIndex = 0;
            this.MarksHeading.Text = "Search";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(693, 182);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 38);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(693, 245);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(91, 38);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(693, 316);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 38);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridMarks
            // 
            this.dataGridMarks.AllowUserToAddRows = false;
            this.dataGridMarks.AllowUserToDeleteRows = false;
            this.dataGridMarks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMarks.Location = new System.Drawing.Point(24, 66);
            this.dataGridMarks.MultiSelect = false;
            this.dataGridMarks.Name = "dataGridMarks";
            this.dataGridMarks.ReadOnly = true;
            this.dataGridMarks.RowHeadersWidth = 62;
            this.dataGridMarks.RowTemplate.Height = 28;
            this.dataGridMarks.Size = new System.Drawing.Size(566, 372);
            this.dataGridMarks.TabIndex = 12;
            this.dataGridMarks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMarks_CellClick);
            // 
            // btnGoToHome
            // 
            this.btnGoToHome.Location = new System.Drawing.Point(922, 18);
            this.btnGoToHome.Name = "btnGoToHome";
            this.btnGoToHome.Size = new System.Drawing.Size(68, 39);
            this.btnGoToHome.TabIndex = 14;
            this.btnGoToHome.Text = "Back";
            this.btnGoToHome.UseVisualStyleBackColor = true;
            this.btnGoToHome.Click += new System.EventHandler(this.btnGoToStudent_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.Location = new System.Drawing.Point(168, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 45);
            this.label1.TabIndex = 15;
            this.label1.Text = "Marks DataTable";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(647, 119);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(163, 26);
            this.txtSearch.TabIndex = 16;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // MarksUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 450);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGoToHome);
            this.Controls.Add(this.dataGridMarks);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
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
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridMarks;
        private System.Windows.Forms.Button btnGoToHome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
    }
}