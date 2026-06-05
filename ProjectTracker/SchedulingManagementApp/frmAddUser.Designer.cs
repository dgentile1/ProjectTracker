namespace ProjectTracker
{
    partial class frmAddUser
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
            tbxFirstName = new TextBox();
            tbxLastName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // tbxFirstName
            // 
            tbxFirstName.Location = new Point(80, 30);
            tbxFirstName.Name = "tbxFirstName";
            tbxFirstName.Size = new Size(232, 23);
            tbxFirstName.TabIndex = 2;
            // 
            // tbxLastName
            // 
            tbxLastName.Location = new Point(425, 28);
            tbxLastName.Name = "tbxLastName";
            tbxLastName.Size = new Size(232, 23);
            tbxLastName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 33);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 4;
            label1.Text = "First Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(353, 33);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 5;
            label2.Text = "Last Name:";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(340, 70);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(101, 36);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(234, 70);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 36);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // frmAddUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(675, 120);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbxLastName);
            Controls.Add(tbxFirstName);
            Name = "frmAddUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Programmer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tbxFirstName;
        private TextBox tbxLastName;
        private Label label1;
        private Label label2;
        private Button btnCancel;
        private Button btnSave;
    }
}