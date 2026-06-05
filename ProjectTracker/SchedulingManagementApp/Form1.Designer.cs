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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            dgvDetailView = new DataGridView();
            openDetailView = new DataGridViewButtonColumn();
            mSProjectGuidDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            projectNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            startDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            currentFinishDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            updatedFinishDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            currentPercentDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            updatedPercentDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            durationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            notesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isModifiedDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)dgvDetailView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mainScheduleGridViewBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mSProjectFieldsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)projectTaskBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)projectModificationBindingSource).BeginInit();
            gbxRange.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDetailView
            // 
            dgvDetailView.AutoGenerateColumns = false;
            dgvDetailView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetailView.Columns.AddRange(new DataGridViewColumn[] { openDetailView, mSProjectGuidDataGridViewTextBoxColumn, projectNameDataGridViewTextBoxColumn, startDateDataGridViewTextBoxColumn, currentFinishDateDataGridViewTextBoxColumn, updatedFinishDateDataGridViewTextBoxColumn, currentPercentDataGridViewTextBoxColumn, updatedPercentDataGridViewTextBoxColumn, durationDataGridViewTextBoxColumn, notesDataGridViewTextBoxColumn, isModifiedDataGridViewCheckBoxColumn });
            dgvDetailView.DataSource = mainScheduleGridViewBindingSource;
            dgvDetailView.Location = new Point(344, 102);
            dgvDetailView.Name = "dgvDetailView";
            dgvDetailView.Size = new Size(1150, 874);
            dgvDetailView.TabIndex = 0;
            // 
            // openDetailView
            // 
            openDetailView.HeaderText = "Detail View";
            openDetailView.Name = "openDetailView";
            openDetailView.Text = "View";
            openDetailView.UseColumnTextForButtonValue = true;
            // 
            // mSProjectGuidDataGridViewTextBoxColumn
            // 
            mSProjectGuidDataGridViewTextBoxColumn.DataPropertyName = "MSProjectGuid";
            mSProjectGuidDataGridViewTextBoxColumn.HeaderText = "MSProjectGuid";
            mSProjectGuidDataGridViewTextBoxColumn.Name = "mSProjectGuidDataGridViewTextBoxColumn";
            mSProjectGuidDataGridViewTextBoxColumn.ReadOnly = true;
            mSProjectGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // projectNameDataGridViewTextBoxColumn
            // 
            projectNameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            projectNameDataGridViewTextBoxColumn.DataPropertyName = "ProjectName";
            projectNameDataGridViewTextBoxColumn.HeaderText = "Project Name";
            projectNameDataGridViewTextBoxColumn.Name = "projectNameDataGridViewTextBoxColumn";
            projectNameDataGridViewTextBoxColumn.ReadOnly = true;
            projectNameDataGridViewTextBoxColumn.Width = 96;
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            dataGridViewCellStyle6.Format = "MM/dd/yyyy";
            dataGridViewCellStyle6.NullValue = null;
            startDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            startDateDataGridViewTextBoxColumn.HeaderText = "Start Date";
            startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            startDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // currentFinishDateDataGridViewTextBoxColumn
            // 
            currentFinishDateDataGridViewTextBoxColumn.DataPropertyName = "CurrentFinishDate";
            dataGridViewCellStyle7.Format = "MM/dd/yyyy";
            dataGridViewCellStyle7.NullValue = null;
            currentFinishDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            currentFinishDateDataGridViewTextBoxColumn.HeaderText = "Current Finish Date";
            currentFinishDateDataGridViewTextBoxColumn.Name = "currentFinishDateDataGridViewTextBoxColumn";
            currentFinishDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // updatedFinishDateDataGridViewTextBoxColumn
            // 
            updatedFinishDateDataGridViewTextBoxColumn.DataPropertyName = "UpdatedFinishDate";
            dataGridViewCellStyle8.Format = "MM/dd/yyyy";
            dataGridViewCellStyle8.NullValue = null;
            updatedFinishDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            updatedFinishDateDataGridViewTextBoxColumn.HeaderText = "Updated Finish Date";
            updatedFinishDateDataGridViewTextBoxColumn.Name = "updatedFinishDateDataGridViewTextBoxColumn";
            // 
            // currentPercentDataGridViewTextBoxColumn
            // 
            currentPercentDataGridViewTextBoxColumn.DataPropertyName = "CurrentPercent";
            dataGridViewCellStyle9.Format = "0'%'";
            dataGridViewCellStyle9.NullValue = null;
            currentPercentDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            currentPercentDataGridViewTextBoxColumn.HeaderText = "Current %";
            currentPercentDataGridViewTextBoxColumn.Name = "currentPercentDataGridViewTextBoxColumn";
            currentPercentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // updatedPercentDataGridViewTextBoxColumn
            // 
            updatedPercentDataGridViewTextBoxColumn.DataPropertyName = "UpdatedPercent";
            dataGridViewCellStyle10.Format = "0'%'";
            updatedPercentDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            updatedPercentDataGridViewTextBoxColumn.HeaderText = "Updated %";
            updatedPercentDataGridViewTextBoxColumn.Name = "updatedPercentDataGridViewTextBoxColumn";
            // 
            // durationDataGridViewTextBoxColumn
            // 
            durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            durationDataGridViewTextBoxColumn.HeaderText = "Duration";
            durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            // 
            // notesDataGridViewTextBoxColumn
            // 
            notesDataGridViewTextBoxColumn.DataPropertyName = "Notes";
            notesDataGridViewTextBoxColumn.HeaderText = "Notes";
            notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            // 
            // isModifiedDataGridViewCheckBoxColumn
            // 
            isModifiedDataGridViewCheckBoxColumn.DataPropertyName = "IsModified";
            isModifiedDataGridViewCheckBoxColumn.HeaderText = "IsModified";
            isModifiedDataGridViewCheckBoxColumn.Name = "isModifiedDataGridViewCheckBoxColumn";
            isModifiedDataGridViewCheckBoxColumn.ReadOnly = true;
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
            btnRefresh.Location = new Point(763, 63);
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
            lblProjectCount.Location = new Point(41, 845);
            lblProjectCount.Name = "lblProjectCount";
            lblProjectCount.Size = new Size(38, 15);
            lblProjectCount.TabIndex = 2;
            lblProjectCount.Text = "label1";
            // 
            // lblModifiedCount
            // 
            lblModifiedCount.AutoSize = true;
            lblModifiedCount.Location = new Point(41, 888);
            lblModifiedCount.Name = "lblModifiedCount";
            lblModifiedCount.Size = new Size(38, 15);
            lblModifiedCount.TabIndex = 3;
            lblModifiedCount.Text = "label1";
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
            gbxRange.Location = new Point(344, 12);
            gbxRange.Name = "gbxRange";
            gbxRange.Size = new Size(413, 84);
            gbxRange.TabIndex = 8;
            gbxRange.TabStop = false;
            gbxRange.Text = "Range";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 979);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1506, 22);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 16);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1506, 1001);
            Controls.Add(statusStrip1);
            Controls.Add(gbxRange);
            Controls.Add(lblModifiedCount);
            Controls.Add(lblProjectCount);
            Controls.Add(btnRefresh);
            Controls.Add(dgvDetailView);
            Name = "Form1";
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDetailView;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn startDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn finishDataGridViewTextBoxColumn;
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
        private DataGridViewButtonColumn openDetailView;
        private DataGridViewTextBoxColumn mSProjectGuidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn projectNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn currentFinishDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn updatedFinishDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn currentPercentDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn updatedPercentDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isModifiedDataGridViewCheckBoxColumn;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
    }
}
