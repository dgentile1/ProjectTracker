namespace ProjectTracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            dgvDetailView = new DataGridView();
            mainScheduleGridViewBindingSource = new BindingSource(components);
            mSProjectFieldsBindingSource = new BindingSource(components);
            projectTaskBindingSource = new BindingSource(components);
            btnRefresh = new Button();
            projectModificationBindingSource = new BindingSource(components);
            lblProjectCount = new Label();
            lblModifiedCount = new Label();
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            gbxRange = new GroupBox();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar1 = new ToolStripProgressBar();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            btnSettings = new Button();
            panel1 = new Panel();
            cklbxProgrammersNames = new CheckedListBox();
            cklbxProjectNames = new CheckedListBox();
            btnSave = new Button();
            MSProjectGuid = new DataGridViewTextBoxColumn();
            ProgrammersName = new DataGridViewComboBoxColumn();
            ProjectName = new DataGridViewTextBoxColumn();
            StartDate = new DataGridViewTextBoxColumn();
            CurrentFinishDate = new DataGridViewTextBoxColumn();
            UpdatedFinishDate = new DataGridViewTextBoxColumn();
            CurrentPercent = new DataGridViewTextBoxColumn();
            UpdatedPercent = new DataGridViewTextBoxColumn();
            TestingStartDate = new DataGridViewTextBoxColumn();
            TestingPercent = new DataGridViewTextBoxColumn();
            ReleasedDate = new DataGridViewTextBoxColumn();
            ReleasedChecked = new DataGridViewCheckBoxColumn();
            Notes = new DataGridViewTextBoxColumn();
            isModified = new DataGridViewCheckBoxColumn();
            DetailView = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvDetailView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mainScheduleGridViewBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mSProjectFieldsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)projectTaskBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)projectModificationBindingSource).BeginInit();
            gbxRange.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDetailView
            // 
            dgvDetailView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetailView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDetailView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDetailView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetailView.Columns.AddRange(new DataGridViewColumn[] { MSProjectGuid, ProgrammersName, ProjectName, StartDate, CurrentFinishDate, UpdatedFinishDate, CurrentPercent, UpdatedPercent, TestingStartDate, TestingPercent, ReleasedDate, ReleasedChecked, Notes, isModified, DetailView });
            dgvDetailView.DataSource = mainScheduleGridViewBindingSource;
            dgvDetailView.Location = new Point(448, 102);
            dgvDetailView.Name = "dgvDetailView";
            dgvDetailView.RowHeadersWidth = 62;
            dgvDetailView.Size = new Size(1387, 747);
            dgvDetailView.TabIndex = 0;
            dgvDetailView.CellEndEdit += dgvDetailView_CellEndEdit;
            dgvDetailView.CellValueChanged += dgvDetailView_CellValueChanged;
            // 
            // mainScheduleGridViewBindingSource
            // 
            mainScheduleGridViewBindingSource.DataSource = typeof(MainScheduleGridView);
            // 
            // mSProjectFieldsBindingSource
            // 
            mSProjectFieldsBindingSource.DataSource = typeof(MSProjectFields);
            // 
            // projectTaskBindingSource
            // 
            projectTaskBindingSource.DataSource = typeof(MSProjectFields);
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(867, 63);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(108, 33);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // projectModificationBindingSource
            // 
            projectModificationBindingSource.DataSource = typeof(ProjectModification);
            // 
            // lblProjectCount
            // 
            lblProjectCount.AutoSize = true;
            lblProjectCount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProjectCount.Location = new Point(12, 15);
            lblProjectCount.Name = "lblProjectCount";
            lblProjectCount.Size = new Size(65, 21);
            lblProjectCount.TabIndex = 2;
            lblProjectCount.Text = "Projects";
            // 
            // lblModifiedCount
            // 
            lblModifiedCount.AutoSize = true;
            lblModifiedCount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblModifiedCount.Location = new Point(12, 47);
            lblModifiedCount.Name = "lblModifiedCount";
            lblModifiedCount.Size = new Size(119, 21);
            lblModifiedCount.TabIndex = 3;
            lblModifiedCount.Text = "Lines Modified: ";
            // 
            // dtpStart
            // 
            dtpStart.CustomFormat = "MM/dd/yyyy";
            dtpStart.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.Location = new Point(59, 38);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(150, 29);
            dtpStart.TabIndex = 4;
            dtpStart.Value = new DateTime(2026, 6, 5, 0, 0, 0, 0);
            // 
            // dtpEnd
            // 
            dtpEnd.CustomFormat = "MM/dd/yyyy";
            dtpEnd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(246, 38);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(150, 29);
            dtpEnd.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 41);
            label1.Name = "label1";
            label1.Size = new Size(47, 21);
            label1.TabIndex = 6;
            label1.Text = "From";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(214, 40);
            label2.Name = "label2";
            label2.Size = new Size(27, 21);
            label2.TabIndex = 7;
            label2.Text = "->";
            // 
            // gbxRange
            // 
            gbxRange.BackColor = SystemColors.Control;
            gbxRange.Controls.Add(label1);
            gbxRange.Controls.Add(label2);
            gbxRange.Controls.Add(dtpStart);
            gbxRange.Controls.Add(dtpEnd);
            gbxRange.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxRange.Location = new Point(448, 12);
            gbxRange.Name = "gbxRange";
            gbxRange.Size = new Size(413, 84);
            gbxRange.TabIndex = 8;
            gbxRange.TabStop = false;
            gbxRange.Text = "Range";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1, toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 852);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1847, 22);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // btnSettings
            // 
            btnSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSettings.Location = new Point(1727, 63);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(108, 33);
            btnSettings.TabIndex = 12;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(lblProjectCount);
            panel1.Controls.Add(lblModifiedCount);
            panel1.Location = new Point(12, 758);
            panel1.Name = "panel1";
            panel1.Size = new Size(386, 91);
            panel1.TabIndex = 13;
            // 
            // cklbxProgrammersNames
            // 
            cklbxProgrammersNames.CheckOnClick = true;
            cklbxProgrammersNames.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cklbxProgrammersNames.FormattingEnabled = true;
            cklbxProgrammersNames.Location = new Point(12, 102);
            cklbxProgrammersNames.Name = "cklbxProgrammersNames";
            cklbxProgrammersNames.Size = new Size(190, 584);
            cklbxProgrammersNames.TabIndex = 15;
            cklbxProgrammersNames.SelectedIndexChanged += cklbxProgrammersNames_SelectedIndexChanged;
            // 
            // cklbxProjectNames
            // 
            cklbxProjectNames.CheckOnClick = true;
            cklbxProjectNames.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cklbxProjectNames.FormattingEnabled = true;
            cklbxProjectNames.Location = new Point(208, 102);
            cklbxProjectNames.Name = "cklbxProjectNames";
            cklbxProjectNames.Size = new Size(234, 584);
            cklbxProjectNames.TabIndex = 16;
            cklbxProjectNames.SelectedIndexChanged += cklbxProjectNames_SelectedIndexChanged;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(1260, 50);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 46);
            btnSave.TabIndex = 17;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // MSProjectGuid
            // 
            MSProjectGuid.DataPropertyName = "MSProjectGuid";
            MSProjectGuid.HeaderText = "MSProjectGuid";
            MSProjectGuid.Name = "MSProjectGuid";
            MSProjectGuid.Visible = false;
            // 
            // ProgrammersName
            // 
            ProgrammersName.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ProgrammersName.DataPropertyName = "ProgrammersName";
            ProgrammersName.HeaderText = "Programmers Name";
            ProgrammersName.Name = "ProgrammersName";
            ProgrammersName.Width = 108;
            // 
            // ProjectName
            // 
            ProjectName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            ProjectName.DataPropertyName = "ProjectName";
            ProjectName.HeaderText = "Project Name";
            ProjectName.Name = "ProjectName";
            ProjectName.ReadOnly = true;
            ProjectName.Width = 21;
            // 
            // StartDate
            // 
            StartDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            StartDate.DataPropertyName = "StartDate";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "MM/dd/yyyy";
            StartDate.DefaultCellStyle = dataGridViewCellStyle2;
            StartDate.HeaderText = "Emb. Start Date";
            StartDate.Name = "StartDate";
            StartDate.ReadOnly = true;
            StartDate.Width = 104;
            // 
            // CurrentFinishDate
            // 
            CurrentFinishDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            CurrentFinishDate.DataPropertyName = "CurrentFinishDate";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "MM/dd/yyyy";
            CurrentFinishDate.DefaultCellStyle = dataGridViewCellStyle3;
            CurrentFinishDate.HeaderText = "Curr. Emb. Finish Date";
            CurrentFinishDate.Name = "CurrentFinishDate";
            CurrentFinishDate.ReadOnly = true;
            CurrentFinishDate.Width = 115;
            // 
            // UpdatedFinishDate
            // 
            UpdatedFinishDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            UpdatedFinishDate.DataPropertyName = "UpdatedFinishDate";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "MM/dd/yyyy";
            UpdatedFinishDate.DefaultCellStyle = dataGridViewCellStyle4;
            UpdatedFinishDate.HeaderText = "Updated Finish Date";
            UpdatedFinishDate.Name = "UpdatedFinishDate";
            UpdatedFinishDate.Visible = false;
            UpdatedFinishDate.Width = 105;
            // 
            // CurrentPercent
            // 
            CurrentPercent.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            CurrentPercent.DataPropertyName = "CurrentPercent";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CurrentPercent.DefaultCellStyle = dataGridViewCellStyle5;
            CurrentPercent.HeaderText = "Curr. Emb. %";
            CurrentPercent.MinimumWidth = 65;
            CurrentPercent.Name = "CurrentPercent";
            CurrentPercent.ReadOnly = true;
            CurrentPercent.Width = 84;
            // 
            // UpdatedPercent
            // 
            UpdatedPercent.DataPropertyName = "UpdatedPercent";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "0%";
            dataGridViewCellStyle6.NullValue = null;
            UpdatedPercent.DefaultCellStyle = dataGridViewCellStyle6;
            UpdatedPercent.DividerWidth = 5;
            UpdatedPercent.HeaderText = "Updated %";
            UpdatedPercent.MinimumWidth = 60;
            UpdatedPercent.Name = "UpdatedPercent";
            UpdatedPercent.Width = 60;
            // 
            // TestingStartDate
            // 
            TestingStartDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            TestingStartDate.DataPropertyName = "TestingStartDate";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "MM/dd/yyyy";
            TestingStartDate.DefaultCellStyle = dataGridViewCellStyle7;
            TestingStartDate.HeaderText = "Testing Start Date";
            TestingStartDate.Name = "TestingStartDate";
            TestingStartDate.Width = 92;
            // 
            // TestingPercent
            // 
            TestingPercent.DataPropertyName = "TestingPercent";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "0%";
            TestingPercent.DefaultCellStyle = dataGridViewCellStyle8;
            TestingPercent.HeaderText = "Testing %";
            TestingPercent.MinimumWidth = 60;
            TestingPercent.Name = "TestingPercent";
            TestingPercent.Width = 60;
            // 
            // ReleasedDate
            // 
            ReleasedDate.DataPropertyName = "ReleasedDate";
            ReleasedDate.HeaderText = "ReleasedDate";
            ReleasedDate.Name = "ReleasedDate";
            ReleasedDate.ReadOnly = true;
            // 
            // ReleasedChecked
            // 
            ReleasedChecked.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ReleasedChecked.DataPropertyName = "ReleasedChecked";
            ReleasedChecked.DividerWidth = 5;
            ReleasedChecked.HeaderText = "Released";
            ReleasedChecked.Name = "ReleasedChecked";
            ReleasedChecked.Width = 64;
            // 
            // Notes
            // 
            Notes.DataPropertyName = "Notes";
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            Notes.DefaultCellStyle = dataGridViewCellStyle9;
            Notes.HeaderText = "Notes";
            Notes.Name = "Notes";
            // 
            // isModified
            // 
            isModified.DataPropertyName = "IsModified";
            isModified.HeaderText = "IsModified";
            isModified.Name = "isModified";
            isModified.ReadOnly = true;
            isModified.Visible = false;
            // 
            // DetailView
            // 
            DetailView.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            DetailView.HeaderText = "Detail View";
            DetailView.Name = "DetailView";
            DetailView.Text = "View";
            DetailView.UseColumnTextForButtonValue = true;
            DetailView.Width = 64;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1847, 874);
            Controls.Add(btnSave);
            Controls.Add(cklbxProjectNames);
            Controls.Add(cklbxProgrammersNames);
            Controls.Add(panel1);
            Controls.Add(btnSettings);
            Controls.Add(statusStrip1);
            Controls.Add(gbxRange);
            Controls.Add(btnRefresh);
            Controls.Add(dgvDetailView);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetailView).EndInit();
            ((System.ComponentModel.ISupportInitialize)mainScheduleGridViewBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)mSProjectFieldsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)projectTaskBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)projectModificationBindingSource).EndInit();
            gbxRange.ResumeLayout(false);
            gbxRange.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDetailView;
        private BindingSource projectTaskBindingSource;
        private Button btnRefresh;
        private BindingSource mSProjectFieldsBindingSource;
        private BindingSource projectModificationBindingSource;
        private Label lblProjectCount;
        private Label lblModifiedCount;
        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
        private BindingSource mainScheduleGridViewBindingSource;
        private Label label1;
        private Label label2;
        private GroupBox gbxRange;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
        private Button btnSettings;
        private Panel panel1;
        private CheckedListBox cklbxProgrammersNames;
        private CheckedListBox cklbxProjectNames;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button btnSave;
        private DataGridViewTextBoxColumn MSProjectGuid;
        private DataGridViewComboBoxColumn ProgrammersName;
        private DataGridViewTextBoxColumn ProjectName;
        private DataGridViewTextBoxColumn StartDate;
        private DataGridViewTextBoxColumn CurrentFinishDate;
        private DataGridViewTextBoxColumn UpdatedFinishDate;
        private DataGridViewTextBoxColumn CurrentPercent;
        private DataGridViewTextBoxColumn UpdatedPercent;
        private DataGridViewTextBoxColumn TestingStartDate;
        private DataGridViewTextBoxColumn TestingPercent;
        private DataGridViewTextBoxColumn ReleasedDate;
        private DataGridViewCheckBoxColumn ReleasedChecked;
        private DataGridViewTextBoxColumn Notes;
        private DataGridViewCheckBoxColumn isModified;
        private DataGridViewButtonColumn DetailView;
    }
}
