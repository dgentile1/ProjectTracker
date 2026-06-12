using System.Drawing;
using System.Windows.Forms;

namespace ProjectTracker
{
    partial class frmDetailView
    {
        // ── Designer infrastructure ───────────────────────────────────────
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        // ── Controls ──────────────────────────────────────────────────────
        private Panel pnlScroll;
        private Panel pnlButtons;

        // General Information
        private Label lblSectionGeneral;
        private Label lblLineGeneral;
        private Label lblProgrammerName;
        private TextBox tbxProgrammerName;
        private Label lblProjectName;
        private TextBox tbxProjectName;

        // Embedded Development
        private Label lblSectionEmbedded;
        private Label lblLineEmbedded;
        private Label lblEmbeddedStart;
        private TextBox tbxEmbeddedStart;
        private Label lblUpdatedStart;
        private DateTimePicker dtpUpdatedStart;
        private Label lblCurrEmbFinish;
        private TextBox tbxCurrEmbFinish;
        private Label lblUpdatedFinish;
        private DateTimePicker dtpUpdatedFinish;
        private Label lblCurrEmbPct;
        private TextBox tbxCurrEmbPct;
        private Label lblUpdatedPct;
        private NumericUpDown nudUpdatedPct;

        // Testing
        private Label lblSectionTesting;
        private Label lblLineTesting;
        private Label lblTestingStart;
        private TextBox tbxTestingStart;
        private Label lblUpdatedTestStart;
        private DateTimePicker dtpUpdatedTestStart;
        private Label lblTestingRounds;
        private NumericUpDown nudTestingRounds;

        // Release
        private Label lblSectionRelease;
        private Label lblLineRelease;
        private Label lblReleaseDate;
        private TextBox tbxReleaseDate;
        private Label lblReleased;
        private CheckBox chkReleased;
        private Label lblReleasedDate;
        private DateTimePicker dtpReleasedDate;

        // Notes
        private Label lblSectionNotes;
        private Label lblLineNotes;
        private RichTextBox rtbNotes;
        private Label lblLegend;

        // Buttons
        private Button btnSave;
        private Button btnClose;

        private void InitializeComponent()
        {
            pnlScroll = new Panel();
            btnOpenTrello = new Button();
            lblTrelloURL = new Label();
            tbxTrelloURL = new TextBox();
            lblSectionGeneral = new Label();
            lblLineGeneral = new Label();
            lblProgrammerName = new Label();
            tbxProgrammerName = new TextBox();
            lblProjectName = new Label();
            tbxProjectName = new TextBox();
            lblSectionEmbedded = new Label();
            lblLineEmbedded = new Label();
            lblEmbeddedStart = new Label();
            tbxEmbeddedStart = new TextBox();
            lblUpdatedStart = new Label();
            dtpUpdatedStart = new DateTimePicker();
            lblCurrEmbFinish = new Label();
            tbxCurrEmbFinish = new TextBox();
            lblUpdatedFinish = new Label();
            dtpUpdatedFinish = new DateTimePicker();
            lblCurrEmbPct = new Label();
            tbxCurrEmbPct = new TextBox();
            lblUpdatedPct = new Label();
            nudUpdatedPct = new NumericUpDown();
            lblSectionTesting = new Label();
            lblLineTesting = new Label();
            lblTestingStart = new Label();
            tbxTestingStart = new TextBox();
            lblUpdatedTestStart = new Label();
            dtpUpdatedTestStart = new DateTimePicker();
            lblTestingRounds = new Label();
            nudTestingRounds = new NumericUpDown();
            lblSectionRelease = new Label();
            lblLineRelease = new Label();
            lblReleaseDate = new Label();
            tbxReleaseDate = new TextBox();
            lblReleased = new Label();
            chkReleased = new CheckBox();
            lblReleasedDate = new Label();
            dtpReleasedDate = new DateTimePicker();
            lblSectionNotes = new Label();
            lblLineNotes = new Label();
            rtbNotes = new RichTextBox();
            lblLegend = new Label();
            pnlButtons = new Panel();
            btnSave = new Button();
            btnClose = new Button();
            pnlScroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudUpdatedPct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTestingRounds).BeginInit();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlScroll
            // 
            pnlScroll.AutoScroll = true;
            pnlScroll.BackColor = Color.Transparent;
            pnlScroll.Controls.Add(btnOpenTrello);
            pnlScroll.Controls.Add(lblTrelloURL);
            pnlScroll.Controls.Add(tbxTrelloURL);
            pnlScroll.Controls.Add(lblSectionGeneral);
            pnlScroll.Controls.Add(lblLineGeneral);
            pnlScroll.Controls.Add(lblProgrammerName);
            pnlScroll.Controls.Add(tbxProgrammerName);
            pnlScroll.Controls.Add(lblProjectName);
            pnlScroll.Controls.Add(tbxProjectName);
            pnlScroll.Controls.Add(lblSectionEmbedded);
            pnlScroll.Controls.Add(lblLineEmbedded);
            pnlScroll.Controls.Add(lblEmbeddedStart);
            pnlScroll.Controls.Add(tbxEmbeddedStart);
            pnlScroll.Controls.Add(lblUpdatedStart);
            pnlScroll.Controls.Add(dtpUpdatedStart);
            pnlScroll.Controls.Add(lblCurrEmbFinish);
            pnlScroll.Controls.Add(tbxCurrEmbFinish);
            pnlScroll.Controls.Add(lblUpdatedFinish);
            pnlScroll.Controls.Add(dtpUpdatedFinish);
            pnlScroll.Controls.Add(lblCurrEmbPct);
            pnlScroll.Controls.Add(tbxCurrEmbPct);
            pnlScroll.Controls.Add(lblUpdatedPct);
            pnlScroll.Controls.Add(nudUpdatedPct);
            pnlScroll.Controls.Add(lblSectionTesting);
            pnlScroll.Controls.Add(lblLineTesting);
            pnlScroll.Controls.Add(lblTestingStart);
            pnlScroll.Controls.Add(tbxTestingStart);
            pnlScroll.Controls.Add(lblUpdatedTestStart);
            pnlScroll.Controls.Add(dtpUpdatedTestStart);
            pnlScroll.Controls.Add(lblTestingRounds);
            pnlScroll.Controls.Add(nudTestingRounds);
            pnlScroll.Controls.Add(lblSectionRelease);
            pnlScroll.Controls.Add(lblLineRelease);
            pnlScroll.Controls.Add(lblReleaseDate);
            pnlScroll.Controls.Add(tbxReleaseDate);
            pnlScroll.Controls.Add(lblReleased);
            pnlScroll.Controls.Add(chkReleased);
            pnlScroll.Controls.Add(lblReleasedDate);
            pnlScroll.Controls.Add(dtpReleasedDate);
            pnlScroll.Controls.Add(lblSectionNotes);
            pnlScroll.Controls.Add(lblLineNotes);
            pnlScroll.Controls.Add(rtbNotes);
            pnlScroll.Controls.Add(lblLegend);
            pnlScroll.Dock = DockStyle.Fill;
            pnlScroll.Location = new Point(0, 0);
            pnlScroll.Name = "pnlScroll";
            pnlScroll.Padding = new Padding(16, 12, 16, 8);
            pnlScroll.Size = new Size(624, 804);
            pnlScroll.TabIndex = 0;
            // 
            // btnOpenTrello
            // 
            btnOpenTrello.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOpenTrello.Location = new Point(527, 155);
            btnOpenTrello.Name = "btnOpenTrello";
            btnOpenTrello.Size = new Size(88, 28);
            btnOpenTrello.TabIndex = 42;
            btnOpenTrello.Text = "Open";
            btnOpenTrello.UseVisualStyleBackColor = true;
            btnOpenTrello.Click += btnOpenTrello_Click;
            // 
            // lblTrelloURL
            // 
            lblTrelloURL.AutoSize = true;
            lblTrelloURL.Font = new Font("Segoe UI", 8F);
            lblTrelloURL.ForeColor = Color.FromArgb(80, 80, 90);
            lblTrelloURL.Location = new Point(8, 141);
            lblTrelloURL.Name = "lblTrelloURL";
            lblTrelloURL.Size = new Size(57, 13);
            lblTrelloURL.TabIndex = 40;
            lblTrelloURL.Text = "Trello URL";
            // 
            // tbxTrelloURL
            // 
            tbxTrelloURL.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxTrelloURL.BackColor = SystemColors.Window;
            tbxTrelloURL.BorderStyle = BorderStyle.FixedSingle;
            tbxTrelloURL.Font = new Font("Segoe UI", 9F);
            tbxTrelloURL.ForeColor = Color.FromArgb(60, 60, 70);
            tbxTrelloURL.Location = new Point(8, 157);
            tbxTrelloURL.Name = "tbxTrelloURL";
            tbxTrelloURL.Size = new Size(513, 23);
            tbxTrelloURL.TabIndex = 41;
            tbxTrelloURL.TabStop = false;
            // 
            // lblSectionGeneral
            // 
            lblSectionGeneral.BackColor = Color.Transparent;
            lblSectionGeneral.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSectionGeneral.ForeColor = Color.FromArgb(40, 80, 160);
            lblSectionGeneral.Location = new Point(8, 0);
            lblSectionGeneral.Name = "lblSectionGeneral";
            lblSectionGeneral.Size = new Size(590, 32);
            lblSectionGeneral.TabIndex = 0;
            lblSectionGeneral.Text = "General Information";
            lblSectionGeneral.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblLineGeneral
            // 
            lblLineGeneral.BackColor = Color.FromArgb(40, 80, 160);
            lblLineGeneral.Location = new Point(8, 32);
            lblLineGeneral.Name = "lblLineGeneral";
            lblLineGeneral.Size = new Size(590, 1);
            lblLineGeneral.TabIndex = 1;
            // 
            // lblProgrammerName
            // 
            lblProgrammerName.AutoSize = true;
            lblProgrammerName.Font = new Font("Segoe UI", 8F);
            lblProgrammerName.ForeColor = Color.FromArgb(80, 80, 90);
            lblProgrammerName.Location = new Point(8, 39);
            lblProgrammerName.Name = "lblProgrammerName";
            lblProgrammerName.Size = new Size(101, 13);
            lblProgrammerName.TabIndex = 2;
            lblProgrammerName.Text = "Programmer Name";
            // 
            // tbxProgrammerName
            // 
            tbxProgrammerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxProgrammerName.BorderStyle = BorderStyle.FixedSingle;
            tbxProgrammerName.Font = new Font("Segoe UI", 9F);
            tbxProgrammerName.Location = new Point(8, 55);
            tbxProgrammerName.Name = "tbxProgrammerName";
            tbxProgrammerName.Size = new Size(607, 23);
            tbxProgrammerName.TabIndex = 3;
            // 
            // lblProjectName
            // 
            lblProjectName.AutoSize = true;
            lblProjectName.Font = new Font("Segoe UI", 8F);
            lblProjectName.ForeColor = Color.FromArgb(80, 80, 90);
            lblProjectName.Location = new Point(8, 90);
            lblProjectName.Name = "lblProjectName";
            lblProjectName.Size = new Size(86, 13);
            lblProjectName.TabIndex = 4;
            lblProjectName.Text = "Project Name ★";
            // 
            // tbxProjectName
            // 
            tbxProjectName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxProjectName.BackColor = Color.FromArgb(238, 238, 242);
            tbxProjectName.BorderStyle = BorderStyle.FixedSingle;
            tbxProjectName.Font = new Font("Segoe UI", 9F);
            tbxProjectName.ForeColor = Color.FromArgb(60, 60, 70);
            tbxProjectName.Location = new Point(8, 106);
            tbxProjectName.Name = "tbxProjectName";
            tbxProjectName.ReadOnly = true;
            tbxProjectName.Size = new Size(607, 23);
            tbxProjectName.TabIndex = 5;
            tbxProjectName.TabStop = false;
            // 
            // lblSectionEmbedded
            // 
            lblSectionEmbedded.BackColor = Color.Transparent;
            lblSectionEmbedded.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSectionEmbedded.ForeColor = Color.FromArgb(40, 80, 160);
            lblSectionEmbedded.Location = new Point(8, 187);
            lblSectionEmbedded.Name = "lblSectionEmbedded";
            lblSectionEmbedded.Size = new Size(590, 32);
            lblSectionEmbedded.TabIndex = 6;
            lblSectionEmbedded.Text = "Embedded Development";
            lblSectionEmbedded.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblLineEmbedded
            // 
            lblLineEmbedded.BackColor = Color.FromArgb(40, 80, 160);
            lblLineEmbedded.Location = new Point(8, 219);
            lblLineEmbedded.Name = "lblLineEmbedded";
            lblLineEmbedded.Size = new Size(590, 1);
            lblLineEmbedded.TabIndex = 7;
            // 
            // lblEmbeddedStart
            // 
            lblEmbeddedStart.AutoSize = true;
            lblEmbeddedStart.Font = new Font("Segoe UI", 8F);
            lblEmbeddedStart.ForeColor = Color.FromArgb(80, 80, 90);
            lblEmbeddedStart.Location = new Point(8, 226);
            lblEmbeddedStart.Name = "lblEmbeddedStart";
            lblEmbeddedStart.Size = new Size(128, 13);
            lblEmbeddedStart.TabIndex = 8;
            lblEmbeddedStart.Text = "Embedded Start Date ★";
            // 
            // tbxEmbeddedStart
            // 
            tbxEmbeddedStart.BackColor = Color.FromArgb(238, 238, 242);
            tbxEmbeddedStart.BorderStyle = BorderStyle.FixedSingle;
            tbxEmbeddedStart.Font = new Font("Segoe UI", 9F);
            tbxEmbeddedStart.ForeColor = Color.FromArgb(60, 60, 70);
            tbxEmbeddedStart.Location = new Point(8, 242);
            tbxEmbeddedStart.Name = "tbxEmbeddedStart";
            tbxEmbeddedStart.ReadOnly = true;
            tbxEmbeddedStart.Size = new Size(291, 23);
            tbxEmbeddedStart.TabIndex = 9;
            tbxEmbeddedStart.TabStop = false;
            // 
            // lblUpdatedStart
            // 
            lblUpdatedStart.AutoSize = true;
            lblUpdatedStart.Font = new Font("Segoe UI", 8F);
            lblUpdatedStart.ForeColor = Color.FromArgb(80, 80, 90);
            lblUpdatedStart.Location = new Point(307, 226);
            lblUpdatedStart.Name = "lblUpdatedStart";
            lblUpdatedStart.Size = new Size(106, 13);
            lblUpdatedStart.TabIndex = 10;
            lblUpdatedStart.Text = "Updated Start Date";
            // 
            // dtpUpdatedStart
            // 
            dtpUpdatedStart.Checked = false;
            dtpUpdatedStart.Font = new Font("Segoe UI", 9F);
            dtpUpdatedStart.Format = DateTimePickerFormat.Short;
            dtpUpdatedStart.Location = new Point(307, 242);
            dtpUpdatedStart.Name = "dtpUpdatedStart";
            dtpUpdatedStart.ShowCheckBox = true;
            dtpUpdatedStart.Size = new Size(291, 23);
            dtpUpdatedStart.TabIndex = 11;
            // 
            // lblCurrEmbFinish
            // 
            lblCurrEmbFinish.AutoSize = true;
            lblCurrEmbFinish.Font = new Font("Segoe UI", 8F);
            lblCurrEmbFinish.ForeColor = Color.FromArgb(80, 80, 90);
            lblCurrEmbFinish.Location = new Point(8, 278);
            lblCurrEmbFinish.Name = "lblCurrEmbFinish";
            lblCurrEmbFinish.Size = new Size(163, 13);
            lblCurrEmbFinish.TabIndex = 12;
            lblCurrEmbFinish.Text = "Curr. Embedded Finish Date ★";
            // 
            // tbxCurrEmbFinish
            // 
            tbxCurrEmbFinish.BackColor = Color.FromArgb(238, 238, 242);
            tbxCurrEmbFinish.BorderStyle = BorderStyle.FixedSingle;
            tbxCurrEmbFinish.Font = new Font("Segoe UI", 9F);
            tbxCurrEmbFinish.ForeColor = Color.FromArgb(60, 60, 70);
            tbxCurrEmbFinish.Location = new Point(8, 294);
            tbxCurrEmbFinish.Name = "tbxCurrEmbFinish";
            tbxCurrEmbFinish.ReadOnly = true;
            tbxCurrEmbFinish.Size = new Size(291, 23);
            tbxCurrEmbFinish.TabIndex = 13;
            tbxCurrEmbFinish.TabStop = false;
            // 
            // lblUpdatedFinish
            // 
            lblUpdatedFinish.AutoSize = true;
            lblUpdatedFinish.Font = new Font("Segoe UI", 8F);
            lblUpdatedFinish.ForeColor = Color.FromArgb(80, 80, 90);
            lblUpdatedFinish.Location = new Point(307, 278);
            lblUpdatedFinish.Name = "lblUpdatedFinish";
            lblUpdatedFinish.Size = new Size(171, 13);
            lblUpdatedFinish.TabIndex = 14;
            lblUpdatedFinish.Text = "Updated Embedded Finish Date";
            // 
            // dtpUpdatedFinish
            // 
            dtpUpdatedFinish.Checked = false;
            dtpUpdatedFinish.Font = new Font("Segoe UI", 9F);
            dtpUpdatedFinish.Format = DateTimePickerFormat.Short;
            dtpUpdatedFinish.Location = new Point(307, 294);
            dtpUpdatedFinish.Name = "dtpUpdatedFinish";
            dtpUpdatedFinish.ShowCheckBox = true;
            dtpUpdatedFinish.Size = new Size(291, 23);
            dtpUpdatedFinish.TabIndex = 15;
            // 
            // lblCurrEmbPct
            // 
            lblCurrEmbPct.AutoSize = true;
            lblCurrEmbPct.Font = new Font("Segoe UI", 8F);
            lblCurrEmbPct.ForeColor = Color.FromArgb(80, 80, 90);
            lblCurrEmbPct.Location = new Point(8, 330);
            lblCurrEmbPct.Name = "lblCurrEmbPct";
            lblCurrEmbPct.Size = new Size(166, 13);
            lblCurrEmbPct.TabIndex = 16;
            lblCurrEmbPct.Text = "Curr. Embedded % Complete ★";
            // 
            // tbxCurrEmbPct
            // 
            tbxCurrEmbPct.BackColor = Color.FromArgb(238, 238, 242);
            tbxCurrEmbPct.BorderStyle = BorderStyle.FixedSingle;
            tbxCurrEmbPct.Font = new Font("Segoe UI", 9F);
            tbxCurrEmbPct.ForeColor = Color.FromArgb(60, 60, 70);
            tbxCurrEmbPct.Location = new Point(8, 346);
            tbxCurrEmbPct.Name = "tbxCurrEmbPct";
            tbxCurrEmbPct.ReadOnly = true;
            tbxCurrEmbPct.Size = new Size(291, 23);
            tbxCurrEmbPct.TabIndex = 17;
            tbxCurrEmbPct.TabStop = false;
            // 
            // lblUpdatedPct
            // 
            lblUpdatedPct.AutoSize = true;
            lblUpdatedPct.Font = new Font("Segoe UI", 8F);
            lblUpdatedPct.ForeColor = Color.FromArgb(80, 80, 90);
            lblUpdatedPct.Location = new Point(307, 330);
            lblUpdatedPct.Name = "lblUpdatedPct";
            lblUpdatedPct.Size = new Size(116, 13);
            lblUpdatedPct.TabIndex = 18;
            lblUpdatedPct.Text = "Updated % Complete";
            // 
            // nudUpdatedPct
            // 
            nudUpdatedPct.BorderStyle = BorderStyle.FixedSingle;
            nudUpdatedPct.Font = new Font("Segoe UI", 9F);
            nudUpdatedPct.Location = new Point(307, 346);
            nudUpdatedPct.Name = "nudUpdatedPct";
            nudUpdatedPct.Size = new Size(291, 23);
            nudUpdatedPct.TabIndex = 19;
            // 
            // lblSectionTesting
            // 
            lblSectionTesting.BackColor = Color.Transparent;
            lblSectionTesting.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSectionTesting.ForeColor = Color.FromArgb(40, 80, 160);
            lblSectionTesting.Location = new Point(8, 376);
            lblSectionTesting.Name = "lblSectionTesting";
            lblSectionTesting.Size = new Size(590, 32);
            lblSectionTesting.TabIndex = 20;
            lblSectionTesting.Text = "Testing";
            lblSectionTesting.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblLineTesting
            // 
            lblLineTesting.BackColor = Color.FromArgb(40, 80, 160);
            lblLineTesting.Location = new Point(8, 408);
            lblLineTesting.Name = "lblLineTesting";
            lblLineTesting.Size = new Size(590, 1);
            lblLineTesting.TabIndex = 21;
            // 
            // lblTestingStart
            // 
            lblTestingStart.AutoSize = true;
            lblTestingStart.Font = new Font("Segoe UI", 8F);
            lblTestingStart.ForeColor = Color.FromArgb(80, 80, 90);
            lblTestingStart.Location = new Point(8, 415);
            lblTestingStart.Name = "lblTestingStart";
            lblTestingStart.Size = new Size(109, 13);
            lblTestingStart.TabIndex = 22;
            lblTestingStart.Text = "Testing Start Date ★";
            // 
            // tbxTestingStart
            // 
            tbxTestingStart.BackColor = Color.FromArgb(238, 238, 242);
            tbxTestingStart.BorderStyle = BorderStyle.FixedSingle;
            tbxTestingStart.Font = new Font("Segoe UI", 9F);
            tbxTestingStart.ForeColor = Color.FromArgb(60, 60, 70);
            tbxTestingStart.Location = new Point(8, 431);
            tbxTestingStart.Name = "tbxTestingStart";
            tbxTestingStart.ReadOnly = true;
            tbxTestingStart.Size = new Size(291, 23);
            tbxTestingStart.TabIndex = 23;
            tbxTestingStart.TabStop = false;
            // 
            // lblUpdatedTestStart
            // 
            lblUpdatedTestStart.AutoSize = true;
            lblUpdatedTestStart.Font = new Font("Segoe UI", 8F);
            lblUpdatedTestStart.ForeColor = Color.FromArgb(80, 80, 90);
            lblUpdatedTestStart.Location = new Point(307, 415);
            lblUpdatedTestStart.Name = "lblUpdatedTestStart";
            lblUpdatedTestStart.Size = new Size(145, 13);
            lblUpdatedTestStart.TabIndex = 24;
            lblUpdatedTestStart.Text = "Updated Testing Start Date";
            // 
            // dtpUpdatedTestStart
            // 
            dtpUpdatedTestStart.Checked = false;
            dtpUpdatedTestStart.Font = new Font("Segoe UI", 9F);
            dtpUpdatedTestStart.Format = DateTimePickerFormat.Short;
            dtpUpdatedTestStart.Location = new Point(307, 431);
            dtpUpdatedTestStart.Name = "dtpUpdatedTestStart";
            dtpUpdatedTestStart.ShowCheckBox = true;
            dtpUpdatedTestStart.Size = new Size(291, 23);
            dtpUpdatedTestStart.TabIndex = 25;
            // 
            // lblTestingRounds
            // 
            lblTestingRounds.AutoSize = true;
            lblTestingRounds.Font = new Font("Segoe UI", 8F);
            lblTestingRounds.ForeColor = Color.FromArgb(80, 80, 90);
            lblTestingRounds.Location = new Point(8, 467);
            lblTestingRounds.Name = "lblTestingRounds";
            lblTestingRounds.Size = new Size(123, 13);
            lblTestingRounds.TabIndex = 26;
            lblTestingRounds.Text = "Current Testing Round";
            // 
            // nudTestingRounds
            // 
            nudTestingRounds.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nudTestingRounds.BorderStyle = BorderStyle.FixedSingle;
            nudTestingRounds.Font = new Font("Segoe UI", 9F);
            nudTestingRounds.Location = new Point(8, 483);
            nudTestingRounds.Name = "nudTestingRounds";
            nudTestingRounds.Size = new Size(607, 23);
            nudTestingRounds.TabIndex = 27;
            // 
            // lblSectionRelease
            // 
            lblSectionRelease.BackColor = Color.Transparent;
            lblSectionRelease.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSectionRelease.ForeColor = Color.FromArgb(40, 80, 160);
            lblSectionRelease.Location = new Point(8, 513);
            lblSectionRelease.Name = "lblSectionRelease";
            lblSectionRelease.Size = new Size(590, 32);
            lblSectionRelease.TabIndex = 28;
            lblSectionRelease.Text = "Release";
            lblSectionRelease.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblLineRelease
            // 
            lblLineRelease.BackColor = Color.FromArgb(40, 80, 160);
            lblLineRelease.Location = new Point(8, 545);
            lblLineRelease.Name = "lblLineRelease";
            lblLineRelease.Size = new Size(590, 1);
            lblLineRelease.TabIndex = 29;
            // 
            // lblReleaseDate
            // 
            lblReleaseDate.AutoSize = true;
            lblReleaseDate.Font = new Font("Segoe UI", 8F);
            lblReleaseDate.ForeColor = Color.FromArgb(80, 80, 90);
            lblReleaseDate.Location = new Point(8, 552);
            lblReleaseDate.Name = "lblReleaseDate";
            lblReleaseDate.Size = new Size(85, 13);
            lblReleaseDate.TabIndex = 30;
            lblReleaseDate.Text = "Release Date ★";
            // 
            // tbxReleaseDate
            // 
            tbxReleaseDate.BackColor = Color.FromArgb(238, 238, 242);
            tbxReleaseDate.BorderStyle = BorderStyle.FixedSingle;
            tbxReleaseDate.Font = new Font("Segoe UI", 9F);
            tbxReleaseDate.ForeColor = Color.FromArgb(60, 60, 70);
            tbxReleaseDate.Location = new Point(8, 568);
            tbxReleaseDate.Name = "tbxReleaseDate";
            tbxReleaseDate.ReadOnly = true;
            tbxReleaseDate.Size = new Size(291, 23);
            tbxReleaseDate.TabIndex = 31;
            tbxReleaseDate.TabStop = false;
            // 
            // lblReleased
            // 
            lblReleased.AutoSize = true;
            lblReleased.Font = new Font("Segoe UI", 8F);
            lblReleased.ForeColor = Color.FromArgb(80, 80, 90);
            lblReleased.Location = new Point(8, 604);
            lblReleased.Name = "lblReleased";
            lblReleased.Size = new Size(53, 13);
            lblReleased.TabIndex = 32;
            lblReleased.Text = "Released";
            // 
            // chkReleased
            // 
            chkReleased.AutoSize = true;
            chkReleased.Font = new Font("Segoe UI", 9F);
            chkReleased.Location = new Point(8, 620);
            chkReleased.Name = "chkReleased";
            chkReleased.Size = new Size(116, 19);
            chkReleased.TabIndex = 33;
            chkReleased.Text = "Mark as Released";
            chkReleased.CheckedChanged += chkReleased_CheckedChanged;
            // 
            // lblReleasedDate
            // 
            lblReleasedDate.AutoSize = true;
            lblReleasedDate.Font = new Font("Segoe UI", 8F);
            lblReleasedDate.ForeColor = Color.FromArgb(80, 80, 90);
            lblReleasedDate.Location = new Point(307, 552);
            lblReleasedDate.Name = "lblReleasedDate";
            lblReleasedDate.Size = new Size(121, 13);
            lblReleasedDate.TabIndex = 34;
            lblReleasedDate.Text = "Updated Release Date";
            // 
            // dtpReleasedDate
            // 
            dtpReleasedDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpReleasedDate.Checked = false;
            dtpReleasedDate.Enabled = false;
            dtpReleasedDate.Font = new Font("Segoe UI", 9F);
            dtpReleasedDate.Format = DateTimePickerFormat.Short;
            dtpReleasedDate.Location = new Point(307, 568);
            dtpReleasedDate.Name = "dtpReleasedDate";
            dtpReleasedDate.ShowCheckBox = true;
            dtpReleasedDate.Size = new Size(308, 23);
            dtpReleasedDate.TabIndex = 35;
            // 
            // lblSectionNotes
            // 
            lblSectionNotes.BackColor = Color.Transparent;
            lblSectionNotes.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSectionNotes.ForeColor = Color.FromArgb(40, 80, 160);
            lblSectionNotes.Location = new Point(8, 640);
            lblSectionNotes.Name = "lblSectionNotes";
            lblSectionNotes.Size = new Size(590, 32);
            lblSectionNotes.TabIndex = 36;
            lblSectionNotes.Text = "Notes";
            lblSectionNotes.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblLineNotes
            // 
            lblLineNotes.BackColor = Color.FromArgb(40, 80, 160);
            lblLineNotes.Location = new Point(8, 672);
            lblLineNotes.Name = "lblLineNotes";
            lblLineNotes.Size = new Size(590, 1);
            lblLineNotes.TabIndex = 37;
            // 
            // rtbNotes
            // 
            rtbNotes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rtbNotes.BackColor = Color.White;
            rtbNotes.BorderStyle = BorderStyle.FixedSingle;
            rtbNotes.Font = new Font("Segoe UI", 9F);
            rtbNotes.Location = new Point(8, 679);
            rtbNotes.Name = "rtbNotes";
            rtbNotes.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbNotes.Size = new Size(607, 90);
            rtbNotes.TabIndex = 38;
            rtbNotes.Text = "";
            // 
            // lblLegend
            // 
            lblLegend.AutoSize = true;
            lblLegend.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblLegend.ForeColor = Color.FromArgb(120, 120, 130);
            lblLegend.Location = new Point(8, 779);
            lblLegend.Name = "lblLegend";
            lblLegend.Size = new Size(299, 13);
            lblLegend.TabIndex = 39;
            lblLegend.Text = "★  Read-only field (MPP source data — cannot be edited here)";
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.FromArgb(235, 235, 240);
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Controls.Add(btnClose);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new Point(0, 804);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(624, 48);
            pnlButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(0, 120, 215);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(369, 9);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(115, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save Changes";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(220, 53, 69);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(494, 9);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(80, 30);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // frmDetailView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 248);
            ClientSize = new Size(624, 852);
            Controls.Add(pnlScroll);
            Controls.Add(pnlButtons);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimumSize = new Size(580, 700);
            Name = "frmDetailView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Project Detail View";
            pnlScroll.ResumeLayout(false);
            pnlScroll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudUpdatedPct).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTestingRounds).EndInit();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Label lblTrelloURL;
        private TextBox tbxTrelloURL;
        private Button btnOpenTrello;
    }
}