
namespace Academics
{
    partial class Home
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
            this.btnUpdateMarks = new System.Windows.Forms.Button();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUpdateMarks
            // 
            this.btnUpdateMarks.BackColor = System.Drawing.SystemColors.Info;
            this.btnUpdateMarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnUpdateMarks.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnUpdateMarks.Location = new System.Drawing.Point(385, 170);
            this.btnUpdateMarks.Name = "btnUpdateMarks";
            this.btnUpdateMarks.Size = new System.Drawing.Size(157, 45);
            this.btnUpdateMarks.TabIndex = 1;
            this.btnUpdateMarks.Text = "Enter Marks";
            this.btnUpdateMarks.UseVisualStyleBackColor = false;
            this.btnUpdateMarks.Click += new System.EventHandler(this.btnUpdateMarks_Click);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.BackColor = System.Drawing.SystemColors.Info;
            this.btnAddStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAddStudent.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddStudent.Location = new System.Drawing.Point(385, 100);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(157, 45);
            this.btnAddStudent.TabIndex = 2;
            this.btnAddStudent.Text = "Admit Student";
            this.btnAddStudent.UseVisualStyleBackColor = false;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(255, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(412, 43);
            this.label1.TabIndex = 5;
            this.label1.Text = "Parayana School";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(963, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 32);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::Academics.Properties.Resources.img_backtoschool;
            this.ClientSize = new System.Drawing.Size(1009, 249);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.btnUpdateMarks);
            this.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Name = "Home";
            this.Text = "Academics";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnUpdateMarks;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}