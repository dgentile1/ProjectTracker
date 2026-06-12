namespace ProjectTracker
{
    partial class frmStartup
    {
        private System.ComponentModel.IContainer components = null;

        // ── Controls ───────────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlSelectUser;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlSelectUser = new Panel();
            cmbProgrammer = new ComboBox();
            lblInstruction = new Label();
            lblTitle = new Label();
            btnContinue = new Button();
            SuspendLayout();
            // 
            // pnlSelectUser
            // 
            pnlSelectUser.Dock = DockStyle.Fill;
            pnlSelectUser.Location = new Point(0, 0);
            pnlSelectUser.Name = "pnlSelectUser";
            pnlSelectUser.Padding = new Padding(30);
            pnlSelectUser.Size = new Size(420, 169);
            pnlSelectUser.TabIndex = 0;
            pnlSelectUser.Visible = false;
            // 
            // cmbProgrammer
            // 
            cmbProgrammer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProgrammer.Font = new Font("Segoe UI", 10F);
            cmbProgrammer.Location = new Point(32, 76);
            cmbProgrammer.Name = "cmbProgrammer";
            cmbProgrammer.Size = new Size(357, 25);
            cmbProgrammer.Sorted = true;
            cmbProgrammer.TabIndex = 6;
            // 
            // lblInstruction
            // 
            lblInstruction.AutoSize = true;
            lblInstruction.Font = new Font("Segoe UI", 9F);
            lblInstruction.Location = new Point(72, 55);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new Size(276, 15);
            lblInstruction.TabIndex = 8;
            lblInstruction.Text = "Choose your name from the list below to continue.";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(126, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(168, 25);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "Select Your Name";
            // 
            // btnContinue
            // 
            btnContinue.Font = new Font("Segoe UI", 10F);
            btnContinue.Location = new Point(150, 115);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(120, 34);
            btnContinue.TabIndex = 10;
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = true;
            // 
            // frmStartup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 169);
            Controls.Add(btnContinue);
            Controls.Add(lblTitle);
            Controls.Add(lblInstruction);
            Controls.Add(cmbProgrammer);
            Controls.Add(pnlSelectUser);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmStartup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Startup";
            Load += frmStartup_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cmbProgrammer;
        private Label lblInstruction;
        private Label lblTitle;
        private Button btnContinue;
    }
}