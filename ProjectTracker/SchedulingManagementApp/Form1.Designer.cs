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
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            dgvDetailView = new DataGridView();
            MSProjectGuid = new DataGridViewTextBoxColumn();
            ProgrammersName = new DataGridViewComboBoxColumn();
            ProjectName = new DataGridViewTextBoxColumn();
            TrelloLink = new DataGridViewButtonColumn();
            StartDate = new DataGridViewTextBoxColumn();
            CurrentFinishDate = new DataGridViewTextBoxColumn();
            UpdatedFinishDate = new DataGridViewTextBoxColumn();
            CurrentPercent = new DataGridViewTextBoxColumn();
            UpdatedPercent = new DataGridViewTextBoxColumn();
            TestingStartDate = new DataGridViewTextBoxColumn();
            TestingRounds = new DataGridViewTextBoxColumn();
            ReleasedDate = new DataGridViewTextBoxColumn();
            ReleasedChecked = new DataGridViewCheckBoxColumn();
            Notes = new DataGridViewTextBoxColumn();
            isModified = new DataGridViewCheckBoxColumn();
            DetailView = new DataGridViewButtonColumn();
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
            rbtnModified = new RadioButton();
            rbtnMonth = new RadioButton();
            rbtnTwoWeeks = new RadioButton();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar1 = new ToolStripProgressBar();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            btnSettings = new Button();
            panel1 = new Panel();
            cklbxProgrammersNames = new CheckedListBox();
            cklbxProjectNames = new CheckedListBox();
            btnSave = new Button();
            btnRevert = new Button();
            btnModifiedReport = new Button();
            tbxSearchProgrammers = new TextBox();
            tbxSearchProjects = new TextBox();
            btnUnselectAllProgrammers = new Button();
            btnUnselectAllProjects = new Button();
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
            dgvDetailView.AllowUserToAddRows = false;
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
            dgvDetailView.Columns.AddRange(new DataGridViewColumn[] { MSProjectGuid, ProgrammersName, ProjectName, TrelloLink, StartDate, CurrentFinishDate, UpdatedFinishDate, CurrentPercent, UpdatedPercent, TestingStartDate, TestingRounds, ReleasedDate, ReleasedChecked, Notes, isModified, DetailView });
            dgvDetailView.DataSource = mainScheduleGridViewBindingSource;
            dgvDetailView.Location = new Point(448, 147);
            dgvDetailView.Name = "dgvDetailView";
            dgvDetailView.RowHeadersWidth = 20;
            dgvDetailView.Size = new Size(1387, 702);
            dgvDetailView.TabIndex = 0;
            dgvDetailView.CellBeginEdit += dgvDetailView_CellBeginEdit;
            dgvDetailView.CellClick += dgvDetailView_CellClick;
            dgvDetailView.CellEndEdit += dgvDetailView_CellEndEdit;
            dgvDetailView.CellValueChanged += dgvDetailView_CellValueChanged;
            dgvDetailView.EditingControlShowing += dgvDetailView_EditingControlShowing;
            // 
            // MSProjectGuid
            // 
            MSProjectGuid.DataPropertyName = "MSProjectGuid";
            dataGridViewCellStyle2.Format = "MM/dd/yyyy";
            dataGridViewCellStyle2.NullValue = null;
            MSProjectGuid.DefaultCellStyle = dataGridViewCellStyle2;
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
            ProjectName.Width = 5;
            // 
            // TrelloLink
            // 
            TrelloLink.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            TrelloLink.DividerWidth = 5;
            TrelloLink.HeaderText = "Trello Link";
            TrelloLink.MinimumWidth = 64;
            TrelloLink.Name = "TrelloLink";
            TrelloLink.Text = "Open";
            TrelloLink.UseColumnTextForButtonValue = true;
            TrelloLink.Width = 65;
            // 
            // StartDate
            // 
            StartDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            StartDate.DataPropertyName = "StartDate";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "MM/dd/yyyy";
            StartDate.DefaultCellStyle = dataGridViewCellStyle3;
            StartDate.HeaderText = "Emb. Start Date";
            StartDate.Name = "StartDate";
            StartDate.ReadOnly = true;
            StartDate.Width = 104;
            // 
            // CurrentFinishDate
            // 
            CurrentFinishDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            CurrentFinishDate.DataPropertyName = "CurrentFinishDate";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "MM/dd/yyyy";
            CurrentFinishDate.DefaultCellStyle = dataGridViewCellStyle4;
            CurrentFinishDate.HeaderText = "Curr. Emb. Finish Date";
            CurrentFinishDate.Name = "CurrentFinishDate";
            CurrentFinishDate.ReadOnly = true;
            CurrentFinishDate.Width = 115;
            // 
            // UpdatedFinishDate
            // 
            UpdatedFinishDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            UpdatedFinishDate.DataPropertyName = "UpdatedFinishDate";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "MM/dd/yyyy";
            UpdatedFinishDate.DefaultCellStyle = dataGridViewCellStyle5;
            UpdatedFinishDate.HeaderText = "Updated Finish Date";
            UpdatedFinishDate.Name = "UpdatedFinishDate";
            UpdatedFinishDate.Visible = false;
            // 
            // CurrentPercent
            // 
            CurrentPercent.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            CurrentPercent.DataPropertyName = "CurrentPercent";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "0\\%";
            dataGridViewCellStyle6.NullValue = "0%";
            CurrentPercent.DefaultCellStyle = dataGridViewCellStyle6;
            CurrentPercent.HeaderText = "Curr. Emb. %";
            CurrentPercent.MinimumWidth = 65;
            CurrentPercent.Name = "CurrentPercent";
            CurrentPercent.ReadOnly = true;
            CurrentPercent.Width = 84;
            // 
            // UpdatedPercent
            // 
            UpdatedPercent.DataPropertyName = "UpdatedPercent";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "0\\%";
            dataGridViewCellStyle7.NullValue = "0%";
            UpdatedPercent.DefaultCellStyle = dataGridViewCellStyle7;
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
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "MM/dd/yyyy";
            TestingStartDate.DefaultCellStyle = dataGridViewCellStyle8;
            TestingStartDate.HeaderText = "Testing Start Date";
            TestingStartDate.Name = "TestingStartDate";
            TestingStartDate.Width = 92;
            // 
            // TestingRounds
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "0";
            dataGridViewCellStyle9.NullValue = "0";
            TestingRounds.DefaultCellStyle = dataGridViewCellStyle9;
            TestingRounds.HeaderText = "Testing Rounds";
            TestingRounds.MinimumWidth = 60;
            TestingRounds.Name = "TestingRounds";
            TestingRounds.Width = 60;
            // 
            // ReleasedDate
            // 
            ReleasedDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ReleasedDate.DataPropertyName = "ReleasedDate";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "MM/dd/yyyy";
            dataGridViewCellStyle10.NullValue = null;
            ReleasedDate.DefaultCellStyle = dataGridViewCellStyle10;
            ReleasedDate.HeaderText = "Released Date";
            ReleasedDate.Name = "ReleasedDate";
            ReleasedDate.ReadOnly = true;
            ReleasedDate.Width = 97;
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
            Notes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Notes.DataPropertyName = "Notes";
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            Notes.DefaultCellStyle = dataGridViewCellStyle11;
            Notes.HeaderText = "Notes";
            Notes.MinimumWidth = 100;
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
            DetailView.MinimumWidth = 64;
            DetailView.Name = "DetailView";
            DetailView.Text = "View";
            DetailView.UseColumnTextForButtonValue = true;
            DetailView.Width = 64;
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
            btnRefresh.Location = new Point(867, 108);
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
            gbxRange.Controls.Add(rbtnModified);
            gbxRange.Controls.Add(rbtnMonth);
            gbxRange.Controls.Add(rbtnTwoWeeks);
            gbxRange.Controls.Add(label1);
            gbxRange.Controls.Add(label2);
            gbxRange.Controls.Add(dtpStart);
            gbxRange.Controls.Add(dtpEnd);
            gbxRange.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxRange.Location = new Point(448, 12);
            gbxRange.Name = "gbxRange";
            gbxRange.Size = new Size(413, 129);
            gbxRange.TabIndex = 8;
            gbxRange.TabStop = false;
            gbxRange.Text = "Range";
            // 
            // rbtnModified
            // 
            rbtnModified.AutoSize = true;
            rbtnModified.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbtnModified.Location = new Point(317, 90);
            rbtnModified.Name = "rbtnModified";
            rbtnModified.Size = new Size(79, 21);
            rbtnModified.TabIndex = 27;
            rbtnModified.TabStop = true;
            rbtnModified.Text = "Modified";
            rbtnModified.UseVisualStyleBackColor = true;
            rbtnModified.CheckedChanged += rbtnModified_CheckedChanged;
            // 
            // rbtnMonth
            // 
            rbtnMonth.AutoSize = true;
            rbtnMonth.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbtnMonth.Location = new Point(177, 90);
            rbtnMonth.Name = "rbtnMonth";
            rbtnMonth.Size = new Size(64, 21);
            rbtnMonth.TabIndex = 26;
            rbtnMonth.TabStop = true;
            rbtnMonth.Text = "Month";
            rbtnMonth.UseVisualStyleBackColor = true;
            rbtnMonth.CheckedChanged += rbtnMonth_CheckedChanged;
            // 
            // rbtnTwoWeeks
            // 
            rbtnTwoWeeks.AutoSize = true;
            rbtnTwoWeeks.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbtnTwoWeeks.Location = new Point(18, 90);
            rbtnTwoWeeks.Name = "rbtnTwoWeeks";
            rbtnTwoWeeks.Size = new Size(90, 21);
            rbtnTwoWeeks.TabIndex = 25;
            rbtnTwoWeeks.TabStop = true;
            rbtnTwoWeeks.Text = "Two Weeks";
            rbtnTwoWeeks.UseVisualStyleBackColor = true;
            rbtnTwoWeeks.CheckedChanged += rbtnTwoWeeks_CheckedChanged;
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
            btnSettings.Location = new Point(1727, 108);
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
            cklbxProgrammersNames.Sorted = true;
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
            cklbxProjectNames.Sorted = true;
            cklbxProjectNames.TabIndex = 16;
            cklbxProjectNames.SelectedIndexChanged += cklbxProjectNames_SelectedIndexChanged;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(1265, 95);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 46);
            btnSave.TabIndex = 17;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnRevert
            // 
            btnRevert.Location = new Point(981, 108);
            btnRevert.Name = "btnRevert";
            btnRevert.Size = new Size(108, 33);
            btnRevert.TabIndex = 18;
            btnRevert.Text = "Revert";
            btnRevert.UseVisualStyleBackColor = true;
            btnRevert.Click += btnRevert_Click;
            // 
            // btnModifiedReport
            // 
            btnModifiedReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnModifiedReport.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnModifiedReport.Location = new Point(1695, 50);
            btnModifiedReport.Name = "btnModifiedReport";
            btnModifiedReport.Size = new Size(140, 46);
            btnModifiedReport.TabIndex = 20;
            btnModifiedReport.Text = "Modified Report";
            btnModifiedReport.UseVisualStyleBackColor = true;
            // 
            // tbxSearchProgrammers
            // 
            tbxSearchProgrammers.Location = new Point(12, 73);
            tbxSearchProgrammers.Name = "tbxSearchProgrammers";
            tbxSearchProgrammers.PlaceholderText = "Search Programmers....";
            tbxSearchProgrammers.Size = new Size(190, 23);
            tbxSearchProgrammers.TabIndex = 21;
            tbxSearchProgrammers.TextChanged += tbxSearchProgrammers_TextChanged;
            // 
            // tbxSearchProjects
            // 
            tbxSearchProjects.Location = new Point(208, 73);
            tbxSearchProjects.Name = "tbxSearchProjects";
            tbxSearchProjects.PlaceholderText = "Search Projects....";
            tbxSearchProjects.Size = new Size(234, 23);
            tbxSearchProjects.TabIndex = 22;
            tbxSearchProjects.TextChanged += tbxSearchProjects_TextChanged;
            // 
            // btnUnselectAllProgrammers
            // 
            btnUnselectAllProgrammers.Location = new Point(12, 692);
            btnUnselectAllProgrammers.Name = "btnUnselectAllProgrammers";
            btnUnselectAllProgrammers.Size = new Size(96, 33);
            btnUnselectAllProgrammers.TabIndex = 23;
            btnUnselectAllProgrammers.Text = "Unselect All";
            btnUnselectAllProgrammers.UseVisualStyleBackColor = true;
            // 
            // btnUnselectAllProjects
            // 
            btnUnselectAllProjects.Location = new Point(208, 692);
            btnUnselectAllProjects.Name = "btnUnselectAllProjects";
            btnUnselectAllProjects.Size = new Size(96, 33);
            btnUnselectAllProjects.TabIndex = 24;
            btnUnselectAllProjects.Text = "Unselect All";
            btnUnselectAllProjects.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1847, 874);
            Controls.Add(btnUnselectAllProjects);
            Controls.Add(btnUnselectAllProgrammers);
            Controls.Add(tbxSearchProjects);
            Controls.Add(tbxSearchProgrammers);
            Controls.Add(btnModifiedReport);
            Controls.Add(btnRevert);
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
        private Button btnRevert;
        private Button btnModifiedReport;
        private TextBox tbxSearchProgrammers;
        private TextBox tbxSearchProjects;
        private Button btnUnselectAllProgrammers;
        private Button btnUnselectAllProjects;
        private DataGridViewTextBoxColumn MSProjectGuid;
        private DataGridViewComboBoxColumn ProgrammersName;
        private DataGridViewTextBoxColumn ProjectName;
        private DataGridViewButtonColumn TrelloLink;
        private DataGridViewTextBoxColumn StartDate;
        private DataGridViewTextBoxColumn CurrentFinishDate;
        private DataGridViewTextBoxColumn UpdatedFinishDate;
        private DataGridViewTextBoxColumn CurrentPercent;
        private DataGridViewTextBoxColumn UpdatedPercent;
        private DataGridViewTextBoxColumn TestingStartDate;
        private DataGridViewTextBoxColumn TestingRounds;
        private DataGridViewTextBoxColumn ReleasedDate;
        private DataGridViewCheckBoxColumn ReleasedChecked;
        private DataGridViewTextBoxColumn Notes;
        private DataGridViewCheckBoxColumn isModified;
        private DataGridViewButtonColumn DetailView;
        private RadioButton rbtnTwoWeeks;
        private RadioButton rbtnMonth;
        private RadioButton rbtnModified;
    }
}
