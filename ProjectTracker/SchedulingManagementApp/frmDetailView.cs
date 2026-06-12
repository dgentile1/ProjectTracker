using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace ProjectTracker
{
    public partial class frmDetailView : Form
    {
        // ── State ─────────────────────────────────────────────────────────
        private Guid _projectGuid;
        private const string ModFile = "ProjectModifications.json";

        // ─────────────────────────────────────────────────────────────────
        //  Constructor
        // ─────────────────────────────────────────────────────────────────
        public frmDetailView()
        {
            InitializeComponent();
            Load += (_, _) => ThemeManager.ApplyTheme(this);
        }

        // ─────────────────────────────────────────────────────────────────
        //  Public loader  –  call from frmForm1 when a row is selected
        // ─────────────────────────────────────────────────────────────────
        /// <summary>
        /// Populates all fields from a <see cref="MainScheduleGridView"/> row
        /// and merges any existing <see cref="ProjectModification"/> overrides.
        /// </summary>
        public void LoadProject(MainScheduleGridView row)
        {
            if (row.MSProjectGuid == null)
                throw new ArgumentException("Row has no MSProjectGuid.");

            _projectGuid = row.MSProjectGuid.Value;

            // ── Read-only fields (MPP source) ─────────────────────────────
            tbxProjectName.Text = row.ProjectName ?? string.Empty;
            
            tbxEmbeddedStart.Text = row.StartDate.HasValue ? row.StartDate.Value.ToShortDateString() : string.Empty;
            tbxCurrEmbFinish.Text = row.CurrentFinishDate.HasValue ? row.CurrentFinishDate.Value.ToShortDateString() : string.Empty;
            tbxCurrEmbPct.Text = row.CurrentPercent.HasValue ? row.CurrentPercent.Value + " %" : string.Empty;
            tbxTestingStart.Text = row.TestingStartDate.HasValue ? row.TestingStartDate.Value.ToShortDateString() : string.Empty;
            tbxReleaseDate.Text = row.ReleasedDate.HasValue ? row.ReleasedDate.Value.ToShortDateString() : string.Empty;

            // ── Editable defaults (from MainScheduleGridView JSON columns) ─
            tbxProgrammerName.Text = row.ProgrammersName ?? string.Empty;
            tbxTrelloURL.Text = row.TrelloUrl ?? string.Empty;
            SetDatePicker(dtpUpdatedStart, row.UpdatedStartDate);
            SetDatePicker(dtpUpdatedFinish, row.UpdatedFinishDate);
            SetDatePicker(dtpUpdatedTestStart, row.UpdatedTestingStartDate);
            nudUpdatedPct.Value = row.UpdatedPercent ?? (row.CurrentPercent ?? 0);
            nudTestingRounds.Value = row.TestingRounds ?? 0;
            chkReleased.Checked = row.ReleasedChecked ?? false;
            SetDatePicker(dtpReleasedDate, row.ReleasedDate);
            rtbNotes.Text = row.Notes ?? string.Empty;

            // ── Overlay saved modifications if they exist ──────────────────
            var mods = LoadModifications();
            if (mods.TryGetValue(_projectGuid, out var mod))
            {
                tbxProgrammerName.Text = mod.ProgrammersName ?? tbxProgrammerName.Text;
                tbxTrelloURL.Text = mod.TrelloUrl ?? tbxTrelloURL.Text;
                SetDatePicker(dtpUpdatedStart, mod.UpdatedStartDate ?? row.UpdatedStartDate);
                SetDatePicker(dtpUpdatedFinish, mod.UpdatedFinishDate ?? row.UpdatedFinishDate);
                SetDatePicker(dtpUpdatedTestStart, mod.UpdatedTestingStartDate ?? row.UpdatedTestingStartDate);
                nudUpdatedPct.Value = mod.UpdatedPercent ?? nudUpdatedPct.Value;
                nudTestingRounds.Value = mod.TestingRounds ?? nudTestingRounds.Value;
                chkReleased.Checked = mod.ReleasedChecked;
                SetDatePicker(dtpReleasedDate, mod.ReleasedDate ?? row.ReleasedDate);
                rtbNotes.Text = mod.Notes ?? rtbNotes.Text;
            }

            // Released date is independent — always enabled
            dtpReleasedDate.Enabled = true;
        }

        // ─────────────────────────────────────────────────────────────────
        //  Event handlers
        // ─────────────────────────────────────────────────────────────────
        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnSave.Text = "Saving…";

            try
            {
                var mods = LoadModifications();

                mods[_projectGuid] = new ProjectModification
                {
                    MSProjectGuid = _projectGuid,
                    ProgrammersName = tbxProgrammerName.Text.Trim(),
                    TrelloUrl = string.IsNullOrWhiteSpace(tbxTrelloURL.Text) ? null : tbxTrelloURL.Text.Trim(),
                    UpdatedStartDate = dtpUpdatedStart.Checked ? dtpUpdatedStart.Value : (DateTime?)null,
                    UpdatedFinishDate = dtpUpdatedFinish.Checked ? dtpUpdatedFinish.Value : (DateTime?)null,
                    UpdatedTestingStartDate = dtpUpdatedTestStart.Checked ? dtpUpdatedTestStart.Value : (DateTime?)null,
                    UpdatedPercent = (int)nudUpdatedPct.Value,
                    TestingRounds = (int)nudTestingRounds.Value,
                    ReleasedChecked = chkReleased.Checked,
                    ReleasedDate = dtpReleasedDate.Checked ? dtpReleasedDate.Value : (DateTime?)null,
                    Notes = rtbNotes.Text.Trim()
                };

                string json = JsonSerializer.Serialize(mods, new JsonSerializerOptions { WriteIndented = true });

                await File.WriteAllTextAsync(ModFile, json);

                MessageBox.Show("Changes saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ProjectSaved?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Save failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "Save Changes";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkReleased_CheckedChanged(object sender, EventArgs e)
        {
            // chkReleased and dtpReleasedDate are independent —
            // the date can be set regardless of whether the checkbox is ticked.
        }

        // ─────────────────────────────────────────────────────────────────
        //  Public event – lets frmForm1 refresh its grid after a save
        // ─────────────────────────────────────────────────────────────────
        /// <summary>
        /// Raised after a successful save.
        /// Usage: detailView.ProjectSaved += (s, e) => RefreshProjectData();
        /// </summary>
        public event EventHandler? ProjectSaved;

        // ─────────────────────────────────────────────────────────────────
        //  JSON helpers
        // ─────────────────────────────────────────────────────────────────
        private static Dictionary<Guid, ProjectModification> LoadModifications()
        {
            if (!File.Exists(ModFile))
                return new Dictionary<Guid, ProjectModification>();

            try
            {
                string json = File.ReadAllText(ModFile);
                return JsonSerializer.Deserialize<Dictionary<Guid, ProjectModification>>(json, JsonFileHelper.JsonOptions) ?? new Dictionary<Guid, ProjectModification>();
            }
            catch
            {
                return new Dictionary<Guid, ProjectModification>();
            }
        }

        // ─────────────────────────────────────────────────────────────────
        //  Helpers
        // ─────────────────────────────────────────────────────────────────
        private static void SetDatePicker(DateTimePicker dtp, DateTime? value)
        {
            if (value.HasValue)
            {
                dtp.Checked = true;
                dtp.Value = value.Value;
            }
            else
            {
                dtp.Checked = false;
            }
        }

        private void btnOpenTrello_Click(object sender, EventArgs e)
        {
            string url = tbxTrelloURL.Text.Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("No Trello URL has been entered for this project.",
                    "No URL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!Uri.TryCreate(url, UriKind.Absolute, out _))
            {
                MessageBox.Show("The URL entered is not valid.",
                    "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open URL: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}