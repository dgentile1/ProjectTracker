namespace ProjectTracker
{
    partial class frmTrelloURL
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
            btnSave = new Button();
            btnCancel = new Button();
            tbxTrelloURL = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 11.25F);
            btnSave.Location = new Point(197, 101);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 11.25F);
            btnCancel.Location = new Point(341, 101);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // tbxTrelloURL
            // 
            tbxTrelloURL.Location = new Point(25, 58);
            tbxTrelloURL.Name = "tbxTrelloURL";
            tbxTrelloURL.Size = new Size(584, 23);
            tbxTrelloURL.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(197, 27);
            label1.Name = "label1";
            label1.Size = new Size(246, 22);
            label1.TabIndex = 4;
            label1.Text = "Enter the project's Trello URL below";
            // 
            // frmTrelloURL
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 147);
            Controls.Add(label1);
            Controls.Add(tbxTrelloURL);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            MaximizeBox = false;
            Name = "frmTrelloURL";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Trello URL";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnCancel;
        private TextBox tbxTrelloURL;
        private Label label1;
    }
}