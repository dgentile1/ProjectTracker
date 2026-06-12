using com.sun.tools.javadoc;
using Microsoft.Win32;
using MPXJ.Net;
using ProjectTracker.Models;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using Task = System.Threading.Tasks.Task;


namespace ProjectTracker
{
    public partial class Form1 : Form
    {
        private readonly System.Windows.Forms.Timer refreshTimer = new();
        private List<MainScheduleGridView> _allRows = new();
        private List<string> _programmerList = new();
        private Dictionary<Guid, ProjectModification> _pendingChanges = new();
        private Dictionary<Guid, ProjectModification> _savedModifications = new();

        //For Tool Tip Delay
        private readonly System.Windows.Forms.Timer _notesToolTipTimer = new System.Windows.Forms.Timer();
        private DataGridViewCell? _hoverCell;
        private int _notesToolTipDelayMs = 1250; // 1.25 second delay before showing tooltip, adjust as needed
        private readonly ToolTip _toolTip = new();
        private object? _cellValueBeforeEdit;

        public Form1()
        {
            InitializeComponent();
            Load += (_, _) => ThemeManager.ApplyTheme(this);

            // Add:
            cklbxProjectNames.ItemCheck += (s, e) => ApplyFilters();
            cklbxProgrammersNames.ItemCheck += (s, e) => ApplyFilters();

            refreshTimer.Interval = 5 * 60 * 1000;

            refreshTimer.Tick += async (s, e) =>
            {
                await RefreshProjectData();
            };

            refreshTimer.Start();
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1);

            //ToolTip setup ----------------------------------------
            dgvDetailView.ShowCellToolTips = false; // disable built-in tooltips

            // configure an existing designer ToolTip named `_toolTip` (or create one)
            _toolTip.InitialDelay = 0;
            _toolTip.ReshowDelay = 100;
            _toolTip.AutoPopDelay = 5000;
            _toolTip.ShowAlways = true;

            // timer for delayed show
            _notesToolTipTimer.Interval = _notesToolTipDelayMs;
            _notesToolTipTimer.Tick += NotesToolTipTimer_Tick;

            // wire DataGridView events
            dgvDetailView.CellMouseEnter += dgvDetailView_CellMouseEnter;
            dgvDetailView.CellMouseLeave += dgvDetailView_CellMouseLeave;
            dgvDetailView.Scroll += (_, _) =>
            {
                _notesToolTipTimer.Stop();
                _toolTip.Hide(dgvDetailView);
            };
            //-------------------------------------------------------
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            dgvDetailView.DataError += dgvDetailView_DataError;
            try
            {
                dgvDetailView.AutoGenerateColumns = false;

                await RefreshProjectData();
                refreshTimer.Start();


                await LoadAndShowProgrammersAsync();
                dgvDetailView.DataBindingComplete += (s, e) => ApplyRowStyles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public async Task<string> DownloadMppFromGitHubAsync()
        {
            string githubOwner = "Firefly-Integrations";
            string githubRepo = "production-schedule";
            string githubBranch = "main";
            string githubMppPath = "2026 Forecast.mpp";

            string encodedPath = Uri.EscapeDataString(githubMppPath);

            string githubApiUrl =
                $"https://api.github.com/repos/" +
                $"{githubOwner}/{githubRepo}/contents/{encodedPath}" +
                $"?ref={githubBranch}";

            using HttpClient client = new();

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", GitHubConfig.GitHubToken);

            client.DefaultRequestHeaders.UserAgent.ParseAdd(
                "ProductionScheduleViewer");

            string json =
                await client.GetStringAsync(githubApiUrl);

            GitHubFileResponse fileInfo = JsonSerializer.Deserialize<GitHubFileResponse>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? throw new InvalidOperationException("Failed to deserialize GitHub file response.");

            if (string.IsNullOrWhiteSpace(fileInfo?.Download_Url))
            {
                throw new Exception("GitHub did not return a download_url.");
            }

            byte[] fileBytes =
                await client.GetByteArrayAsync(fileInfo.Download_Url);

            string tempFile =
                Path.Combine(
                    Path.GetTempPath(),
                    $"{Guid.NewGuid()}.mpp");

            await File.WriteAllBytesAsync(
                tempFile,
                fileBytes);

            return tempFile;
        }

        private async Task<List<MainScheduleGridView>> LoadProjectTasksAsync()
        {
            SetStatus("Connecting to GitHub...", 15);
            string tempFile = await DownloadMppFromGitHubAsync();

            try
            {
                SetStatus("Reading project file...", 35);
                var reader = new UniversalProjectReader();
                var project = reader.Read(tempFile);

                SetStatus("Parsing tasks...", 55);
                var allTasks = project.Tasks
                        .Where(t => !string.IsNullOrWhiteSpace(t.Name))
                        .Where(t => string.Equals(t.GetText(1)?.ToString(), "2.0 Production", StringComparison.OrdinalIgnoreCase))
                        .ToList();

                var level1Tasks = allTasks.Where(t => t.OutlineLevel == 1).ToList();
                var level2Tasks = allTasks.Where(t => t.OutlineLevel == 2).ToList();

                var embeddedTasks = level2Tasks
                     .Where(t => t.Name.Contains("Embedded", StringComparison.OrdinalIgnoreCase))
                     .ToList();
                var testingTasks = level2Tasks
                     .Where(t => t.Name.Contains("Testing", StringComparison.OrdinalIgnoreCase))
                     .ToList();
                var testCorrectionsTasks = level2Tasks
                     .Where(t => t.Name.Contains("Test Corrections", StringComparison.OrdinalIgnoreCase))
                     .ToList();

                List<MainScheduleGridView> rows = level1Tasks
                    .Select(parent =>
                    {
                        // Find matching level 2 child by WBS prefix
                        var embeddedChild = embeddedTasks.FirstOrDefault(c =>
                           c.WBS.StartsWith(parent.WBS + ".", StringComparison.OrdinalIgnoreCase) ||
                           c.WBS == parent.WBS);

                        var testingChild = testingTasks.FirstOrDefault(c =>
                           c.WBS.StartsWith(parent.WBS + ".", StringComparison.OrdinalIgnoreCase) ||
                           c.WBS == parent.WBS);

                        var testCorrectionsChild = testCorrectionsTasks.FirstOrDefault(c =>
                           c.WBS.StartsWith(parent.WBS + ".", StringComparison.OrdinalIgnoreCase) ||
                           c.WBS == parent.WBS);

                        return new MainScheduleGridView
                        {
                            MSProjectGuid = parent.GUID,
                            ProjectName = parent.Name,           // Level 1 name
                            StartDate = embeddedChild?.Start,          // Level 2 date
                            CurrentFinishDate = embeddedChild?.Finish,        // Level 2 date
                            CurrentPercent = (int?)(embeddedChild?.PercentageComplete),
                            TestingStartDate = testingChild?.Start,
                            ReleasedDate = testCorrectionsChild?.Finish
                        };
                    })
                    .ToList();

                //List<MainScheduleGridView> rows =
                //    project.Tasks
                //        .Where(t => !string.IsNullOrWhiteSpace(t.Name))
                //        .Where(t => t.OutlineLevel == 1)
                //        .Where(t => string.Equals(t.GetText(1)?.ToString(), "2.0 Production", StringComparison.OrdinalIgnoreCase))
                //        .Select(t => new MainScheduleGridView
                //        {
                //            MSProjectGuid = t.GUID,
                //            ProjectName = t.Name,
                //            StartDate = t.Start,
                //            CurrentFinishDate = t.Finish,
                //            CurrentPercent = (int)(t.PercentageComplete ?? 0)
                //        })
                //        .ToList();
                SetStatus("Applying saved modifications...", 80);
                var modifications = _savedModifications;

                foreach (var row in rows)
                {
                    if (row.MSProjectGuid.HasValue &&
                        modifications.TryGetValue(
                            row.MSProjectGuid.Value,
                            out ProjectModification? mod))
                    {
                        row.ProgrammersName = mod.ProgrammersName;
                        row.UpdatedStartDate = mod.UpdatedStartDate;
                        row.UpdatedFinishDate = mod.UpdatedFinishDate;
                        row.UpdatedTestingStartDate = mod.UpdatedTestingStartDate;
                        row.UpdatedPercent = mod.UpdatedPercent;
                        row.TestingRounds = mod.TestingRounds;
                        row.Notes = mod.Notes ?? string.Empty;

                        EnsureProgrammerInComboColumn(mod.ProgrammersName);
                    }
                }

                foreach (var row in rows)
                {
                    if (row.MSProjectGuid.HasValue &&
                        _pendingChanges.TryGetValue(row.MSProjectGuid.Value, out ProjectModification? pending))
                    {
                        row.ProgrammersName = pending.ProgrammersName;
                        row.UpdatedStartDate = pending.UpdatedStartDate;
                        row.UpdatedFinishDate = pending.UpdatedFinishDate;
                        row.UpdatedTestingStartDate = pending.UpdatedTestingStartDate;
                        row.UpdatedPercent = pending.UpdatedPercent;
                        row.TestingRounds = pending.TestingRounds;
                        row.Notes = pending.Notes ?? string.Empty;
                    }
                }

                DateTime start = dtpStart.Value.Date;
                DateTime end = dtpEnd.Value.Date;

                if (rbtnTwoWeeks.Checked)
                {
                    start = DateTime.Now.AddDays(-7);
                    end = DateTime.Now.AddDays(7);
                }
                else if (rbtnMonth.Checked)
                {
                    start = DateTime.Now.AddMonths(-1);
                    end = DateTime.Now.AddMonths(1);
                }

                var filteredRows =
                rows
                    .Where(r =>
                        (r.StartDate >= start && r.StartDate <= end) ||
                        (r.IsModified && r.UpdatedFinishDate.HasValue && r.UpdatedFinishDate.Value >= start && r.UpdatedFinishDate.Value <= end) ||
                        (r.CurrentFinishDate >= start && r.CurrentFinishDate <= end))
                    .ToList();


                return filteredRows;
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        private Dictionary<Guid, ProjectModification> LoadModificationFile()
        {
            string filePath = "ProjectModifications.json";

            if (!File.Exists(filePath))
            {
                return new Dictionary<Guid, ProjectModification>();
            }

            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<Dictionary<Guid, ProjectModification>>(json) ?? new Dictionary<Guid, ProjectModification>();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshProjectData();
        }

        private async Task RefreshProjectData()
        {
            SetStatus("Loading modifications...", 5);
            _savedModifications = LoadModificationFile();

            SetStatus("Downloading schedule...", 10);
            var rows = await LoadProjectTasksAsync();

            _allRows = rows;

            SetStatus("Updating view...", 90);
            PopulateProjectNames();
            ApplyFilters();
            UpdateStatistics(rows);

            SetStatus($"Ready — last refreshed {DateTime.Now:h:mm tt}", 100);
        }

        private void PopulateProjectNames()
        {
            cklbxProjectNames.BeginUpdate();
            cklbxProjectNames.Items.Clear();

            var names = _allRows
                .Select(r => r.ProjectName)
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Distinct()
                .OrderBy(n => n, StringComparer.OrdinalIgnoreCase);

            foreach (var name in names)
                cklbxProjectNames.Items.Add(name);

            cklbxProjectNames.EndUpdate();
        }

        private async Task LoadAndShowProgrammersAsync()
        {
            List<Programmers> programmers = new();

            try
            {
                programmers = await JsonFileHelper.LoadListAsync<Programmers>("Programmers.json");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to load programmers from Desktop: {ex}");
                programmers = new List<Programmers>();
            }

            // Store programmer names for the combo box
            _programmerList = programmers
                .Select(p => string.IsNullOrWhiteSpace(p.LastName) ? p.FirstName : $"{p.FirstName} {p.LastName}")
                .ToList();

            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    cklbxProgrammersNames.BeginUpdate();
                    cklbxProgrammersNames.Items.Clear();
                    foreach (var p in programmers)
                    {
                        var display = string.IsNullOrWhiteSpace(p.LastName) ? p.FirstName : $"{p.FirstName} {p.LastName}";
                        cklbxProgrammersNames.Items.Add(display);
                    }
                    cklbxProgrammersNames.EndUpdate();
                    SetupComboBoxColumn();  // Setup the grid column
                });
            }
            else
            {
                cklbxProgrammersNames.BeginUpdate();
                cklbxProgrammersNames.Items.Clear();
                foreach (var p in programmers)
                {
                    var display = string.IsNullOrWhiteSpace(p.LastName) ? p.FirstName : $"{p.FirstName} {p.LastName}";
                    cklbxProgrammersNames.Items.Add(display);
                }
                cklbxProgrammersNames.EndUpdate();
                SetupComboBoxColumn();  // Setup the grid column
            }
        }
        private void SetupComboBoxColumn()
        {
            if (dgvDetailView.Columns["ProgrammersName"] is not DataGridViewComboBoxColumn comboColumn)
                return;

            comboColumn.Items.Clear();
            comboColumn.Items.Add(string.Empty);
            foreach (var programmer in _programmerList)
            {
                comboColumn.Items.Add(programmer);
            }
        }


        private void ApplyFilters()
        {
            if (_allRows == null)
                return;

            var filtered = _allRows.AsEnumerable();

            var checkedProjects = cklbxProjectNames.CheckedItems.Cast<string>().ToList();
            if (checkedProjects.Count > 0)
            {
                filtered = filtered.Where(r => checkedProjects.Any(p => string.Equals(r.ProjectName, p, StringComparison.OrdinalIgnoreCase)));
            }

            var checkedProgrammers = cklbxProgrammersNames.CheckedItems.Cast<string>().ToList();
            if (checkedProgrammers.Count > 0)
            {
                filtered = filtered.Where(r => checkedProgrammers.Any(pN => string.Equals(r.ProgrammersName, pN, StringComparison.OrdinalIgnoreCase)));
            }

            if (rbtnModified.Checked)
            { 
                filtered = filtered.Where(r => r.IsModified);
            }

            var list = filtered.ToList();
            dgvDetailView.DataSource = ConvertToDataTable(list);

            ApplyRowStyles();
            UpdateStatistics(list);
        }
        private DataTable ConvertToDataTable(List<MainScheduleGridView> rows)
        {
            var dt = new DataTable();
            dt.Columns.Add("MSProjectGuid");
            dt.Columns.Add("ProgrammersName");
            dt.Columns.Add("ProjectName");
            dt.Columns.Add("StartDate", typeof(DateTime));
            dt.Columns.Add("CurrentFinishDate", typeof(DateTime));
            dt.Columns.Add("UpdatedFinishDate", typeof(DateTime));
            dt.Columns.Add("CurrentPercent", typeof(int));
            dt.Columns.Add("UpdatedPercent", typeof(int));
            dt.Columns.Add("TestingStartDate", typeof(DateTime));
            dt.Columns.Add("TestingPercent", typeof(int));
            dt.Columns.Add("ReleasedChecked");
            dt.Columns.Add("ReleasedDate", typeof(DateTime));
            dt.Columns.Add("Notes");
            dt.Columns.Add("IsModified", typeof(bool));

            foreach (var row in rows)
            {
                bool hasPending = row.MSProjectGuid.HasValue &&
                      _pendingChanges.ContainsKey(row.MSProjectGuid.Value);

                dt.Rows.Add(
                    row.MSProjectGuid,
                    row.ProgrammersName ?? string.Empty,
                    row.ProjectName,
                    row.StartDate,
                    row.CurrentFinishDate,
                    row.UpdatedFinishDate,
                    row.CurrentPercent,
                    row.UpdatedPercent,
                    row.TestingStartDate,
                    row.TestingRounds,
                    row.ReleasedChecked,
                    row.ReleasedDate,
                    row.Notes,
                    hasPending
                );
            }

            return dt;
        }

        private void LbxProjectNames_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void LbxProgrammerNames_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void UpdateStatistics(List<MainScheduleGridView> rows)
        {
            lblProjectCount.Text =
                $"Projects: {rows.Count}";

            lblModifiedCount.Text =
                $"Modified: {_pendingChanges.Count}";
        }

        private void ApplyRowStyles()
        {
            foreach (DataGridViewRow dgvr in dgvDetailView.Rows)
            {
                if (dgvr.DataBoundItem is not DataRowView drv) continue;

                bool isModified = drv.Row["IsModified"] != DBNull.Value && (bool)drv.Row["IsModified"];

                dgvr.DefaultCellStyle.BackColor = isModified ? Color.LightCoral : Color.White;
                dgvr.DefaultCellStyle.ForeColor = Color.Black;

                // Apply testing column lock/unlock per row
                ApplyTestingColumnStyles(dgvr);
            }
        }

        private void dgvDetailView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ApplyRowStyles();
        }

        private async void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings settings = new frmSettings();
            settings.ShowDialog();

            // reload programmers after settings changed
            await LoadAndShowProgrammersAsync();

            // re-apply filters in case selection needs to limit updated list
            ApplyFilters();
        }

        private void cklbxProgrammersNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cklbxProjectNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dgvDetailView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvDetailView.Rows[e.RowIndex];

            if (row.DataBoundItem is DataRowView drv)
            {
                SaveRowToPendingChanges(drv.Row);

                bool isPending = Guid.TryParse(drv.Row["MSProjectGuid"]?.ToString(), out Guid g) &&
                                 _pendingChanges.ContainsKey(g);

                drv.Row["IsModified"] = isPending;
            }

            _cellValueBeforeEdit = null;

            // Re-evaluate locked columns in case UpdatedPercent changed
            ApplyTestingColumnStyles(row);
            ApplyRowStyles();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            SetStatus("Saving changes...", 50, isIndeterminate: true);
            try
            {
                var modifications = LoadModificationFile();

                foreach (DataGridViewRow dgvr in dgvDetailView.Rows)
                {
                    if (dgvr.DataBoundItem is not DataRowView drv) continue;

                    if (drv["MSProjectGuid"] == DBNull.Value || drv["MSProjectGuid"] == null)
                        continue;

                    if (!Guid.TryParse(drv["MSProjectGuid"]?.ToString(), out Guid guid))
                        continue;

                    // Only save rows that have been modified
                    bool isModified = drv.Row["IsModified"] != DBNull.Value && (bool)drv.Row["IsModified"];
                    if (!isModified) continue;

                    var mod = new ProjectModification
                    {
                        MSProjectGuid = guid,  // stored in both key and value
                        ProgrammersName = drv["ProgrammersName"]?.ToString(),

                        UpdatedFinishDate = DateTime.TryParse(
                            drv["UpdatedFinishDate"]?.ToString(), out DateTime ufd)
                            ? ufd : null,

                        UpdatedPercent = int.TryParse(
                            drv["UpdatedPercent"]?.ToString(), out int up)
                            ? up : null,

                        TestingRounds = int.TryParse(
                            drv["TestingPercent"]?.ToString(), out int tp)
                            ? tp : null,

                        ReleasedChecked = bool.TryParse(
                            drv["ReleasedChecked"]?.ToString(), out bool rc)
                            ? rc : false,

                        ReleasedDate = DateTime.TryParse(
                            drv["ReleasedDate"]?.ToString(), out DateTime rd)
                            ? rd : null,

                        Notes = drv["Notes"]?.ToString()
                    };

                    modifications[guid] = mod;
                }

                string json = JsonSerializer.Serialize(
                    modifications,
                    new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText("ProjectModifications.json", json);

                MessageBox.Show("Saved successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _pendingChanges.Clear();
                _savedModifications = LoadModificationFile();
                await RefreshProjectData();
            }
            catch (Exception ex)
            {
                SetStatus("Save failed.", 0);
                MessageBox.Show($"Save failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //ToolTip event handlers --------------------------------
        private void dgvDetailView_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (!string.Equals(dgvDetailView.Columns[e.ColumnIndex].Name, "Notes", StringComparison.OrdinalIgnoreCase))
                return;

            _hoverCell = dgvDetailView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            _notesToolTipTimer.Stop();
            _notesToolTipTimer.Start();
        }

        private void dgvDetailView_CellMouseLeave(object? sender, DataGridViewCellEventArgs e)
        {
            _notesToolTipTimer.Stop();
            _toolTip.Hide(dgvDetailView);
            _hoverCell = null;
        }

        private void NotesToolTipTimer_Tick(object? sender, EventArgs e)
        {
            _notesToolTipTimer.Stop();
            if (_hoverCell == null) return;

            string text = _hoverCell.Value?.ToString() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(text)) return;

            var rect = dgvDetailView.GetCellDisplayRectangle(_hoverCell.ColumnIndex, _hoverCell.RowIndex, true);
            var location = new Point(rect.Left + 4, rect.Bottom);
            _toolTip.Show(text, dgvDetailView, location, _toolTip.AutoPopDelay);
        }

        private void dgvDetailView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvDetailView.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];

            // Cancel edit if cell is locked
            if (cell.ReadOnly)
            {
                e.Cancel = true;
                return;
            }

            _cellValueBeforeEdit = cell.Value;
        }

        private void dgvDetailView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is not ComboBox combo) return;

            // Remove first to avoid duplicate subscriptions
            combo.SelectedIndexChanged -= ComboBoxColumn_SelectedIndexChanged;
            combo.SelectedIndexChanged += ComboBoxColumn_SelectedIndexChanged;
        }
        //-------------------------------------------------------
        private void ComboBoxColumn_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (dgvDetailView.CurrentCell == null) return;

            var row = dgvDetailView.CurrentRow;
            if (row == null) return;

            var newValue = (sender as ComboBox)?.SelectedItem?.ToString();

            if (Equals(_cellValueBeforeEdit?.ToString(), newValue)) return;

            dgvDetailView.CurrentCell.Value = newValue;

            if (row.DataBoundItem is DataRowView drv)
            {
                SaveRowToPendingChanges(drv.Row);

                bool isPending = Guid.TryParse(drv.Row["MSProjectGuid"]?.ToString(), out Guid g) &&
                                 _pendingChanges.ContainsKey(g);

                drv.Row["IsModified"] = isPending;
            }

            ApplyRowStyles();
        }

        private void SaveRowToPendingChanges(DataRow row)
        {
            if (!Guid.TryParse(row["MSProjectGuid"]?.ToString(), out Guid guid)) return;

            _savedModifications.TryGetValue(guid, out ProjectModification? saved);

            var current = new ProjectModification
            {
                MSProjectGuid = guid,
                ProgrammersName = row["ProgrammersName"]?.ToString(),

                UpdatedFinishDate = DateTime.TryParse(
                    row["UpdatedFinishDate"]?.ToString(), out DateTime ufd) ? ufd : null,

                UpdatedPercent = int.TryParse(
                    row["UpdatedPercent"]?.ToString(), out int up) ? up : null,

                TestingRounds = int.TryParse(
                    row["TestingPercent"]?.ToString(), out int tp) ? tp : null,

                ReleasedChecked = bool.TryParse(
                    row["ReleasedChecked"]?.ToString(), out bool rc) && rc,

                ReleasedDate = DateTime.TryParse(
                    row["ReleasedDate"]?.ToString(), out DateTime rd) ? rd : null,

                Notes = row["Notes"]?.ToString()
            };

            bool matchesSaved =
                saved != null &&
                current.ProgrammersName == saved.ProgrammersName &&
                current.UpdatedFinishDate == saved.UpdatedFinishDate &&
                current.UpdatedPercent == saved.UpdatedPercent &&
                current.TestingRounds == saved.TestingRounds &&
                current.ReleasedChecked == saved.ReleasedChecked &&
                current.ReleasedDate == saved.ReleasedDate &&
                current.Notes == saved.Notes;

            bool isEmpty =
                saved == null &&
                string.IsNullOrWhiteSpace(current.ProgrammersName) &&
                current.UpdatedFinishDate == null &&
                current.UpdatedPercent == null &&
                current.TestingRounds == null &&
                !current.ReleasedChecked &&
                current.ReleasedDate == null &&
                string.IsNullOrWhiteSpace(current.Notes);

            if (matchesSaved || isEmpty)
                _pendingChanges.Remove(guid);
            else
                _pendingChanges[guid] = current;
        }

        private async void btnRevert_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
            "Revert all unsaved changes?",
            "Revert",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            SetStatus("Reverting changes...", 50, isIndeterminate: true);
            _pendingChanges.Clear();
            await RefreshProjectData();
        }

        private void ApplyTestingColumnStyles(DataGridViewRow dgvr)
        {
            if (dgvr.DataBoundItem is not DataRowView drv) return;

            bool isComplete = int.TryParse(drv.Row["UpdatedPercent"]?.ToString(), out int pct) && pct == 100;

            string[] lockedColumns = { "TestingStartDate", "TestingRounds", "ReleasedDate", "ReleasedChecked" };

            foreach (var colName in lockedColumns)
            {
                if (dgvDetailView.Columns[colName] is not DataGridViewColumn col) continue;

                var cell = dgvr.Cells[col.Index];

                if (isComplete)
                {
                    cell.ReadOnly = false;
                    cell.Style.BackColor = Color.Empty;
                    cell.Style.ForeColor = Color.Empty;
                }
                else
                {
                    cell.ReadOnly = true;
                    cell.Style.BackColor = Color.LightGray;
                    cell.Style.ForeColor = Color.DarkGray;
                }
            }
        }

        private void tbxSearchProgrammers_TextChanged(object sender, EventArgs e)
        {
            string search = tbxSearchProgrammers.Text.Trim();

            // Save currently checked names before rebuilding
            var checkedNames = cklbxProgrammersNames.CheckedItems
                .Cast<string>()
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            cklbxProgrammersNames.BeginUpdate();
            cklbxProgrammersNames.Items.Clear();

            var filtered = string.IsNullOrWhiteSpace(search)
                ? _programmerList
                : _programmerList.Where(p => p.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            foreach (var name in filtered)
            {
                cklbxProgrammersNames.Items.Add(name, checkedNames.Contains(name));
            }

            cklbxProgrammersNames.EndUpdate();

            ApplyFilters();
        }

        private void tbxSearchProjects_TextChanged(object sender, EventArgs e)
        {
            string search = tbxSearchProjects.Text.Trim();

            // Save currently checked names before rebuilding
            var checkedNames = cklbxProjectNames.CheckedItems
                .Cast<string>()
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            cklbxProjectNames.BeginUpdate();
            cklbxProjectNames.Items.Clear();

            var allProjectNames = _allRows
                .Select(r => r.ProjectName)
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(n => n, StringComparer.OrdinalIgnoreCase);

            var filtered = string.IsNullOrWhiteSpace(search)
                ? allProjectNames
                : allProjectNames.Where(p => p.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);

            foreach (var name in filtered)
            {
                cklbxProjectNames.Items.Add(name, checkedNames.Contains(name));
            }

            cklbxProjectNames.EndUpdate();

            ApplyFilters();
        }

        private void dgvDetailView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Suppress the combobox "value not valid" error — this happens when
            // a saved ProgrammersName isn't in the combo items list yet during binding
            if (dgvDetailView.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                e.ThrowException = false;
                return;
            }

            // Let all other data errors surface normally
            MessageBox.Show($"Grid error: {e.Exception?.Message}", "Data Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void EnsureProgrammerInComboColumn(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) return;
            if (dgvDetailView.Columns["ProgrammersName"] is not DataGridViewComboBoxColumn col) return;

            if (!col.Items.Contains(name))
                col.Items.Add(name);
        }

        private void SetStatus(string message, int progressPercent, bool isIndeterminate = false)
        {
            if (InvokeRequired)
            {
                Invoke(() => SetStatus(message, progressPercent, isIndeterminate));
                return;
            }

            toolStripStatusLabel1.Text = message;
            toolStripProgressBar1.Style = isIndeterminate
                ? ProgressBarStyle.Marquee
                : ProgressBarStyle.Continuous;

            if (!isIndeterminate)
                toolStripProgressBar1.Value = Math.Clamp(progressPercent, 0, 100);
        }

        private void dgvDetailView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvDetailView.Rows[e.RowIndex].DataBoundItem is not DataRowView drv) return;

            if (!Guid.TryParse(drv.Row["MSProjectGuid"]?.ToString(), out Guid guid)) return;

            string colName = dgvDetailView.Columns[e.ColumnIndex]?.Name ?? string.Empty;

            // ── Trello button ─────────────────────────────────────────────────
            if (colName == "TrelloLink")
            {
                string projectName = drv.Row["ProjectName"]?.ToString() ?? string.Empty;

                // Check whether a URL is already saved — if so, open it directly.
                // If not (or Shift is held), open the edit form first.
                var mods = LoadModificationFile();
                bool hasUrl = mods.TryGetValue(guid, out var existingMod) &&
                              !string.IsNullOrWhiteSpace(existingMod.TrelloUrl);

                bool shiftHeld = (ModifierKeys & Keys.Shift) != 0;

                if (hasUrl && !shiftHeld)
                {
                    // Open the URL directly in the browser
                    OpenUrl(existingMod!.TrelloUrl!);
                }
                else
                {
                    // Open the edit form to set / update the URL
                    var trelloForm = new frmTrelloURL();
                    trelloForm.LoadForProject(guid, projectName);

                    if (trelloForm.ShowDialog(this) == DialogResult.OK)
                    {
                        // Reload so the in-memory state reflects the new URL
                        _savedModifications = LoadModificationFile();
                    }
                }

                return;
            }

            // ── Detail View button ────────────────────────────────────────────
            if (colName == "DetailView")
            {
                var sourceRow = _allRows.FirstOrDefault(r => r.MSProjectGuid == guid);
                if (sourceRow == null) return;

                var detail = new frmDetailView();

                detail.ProjectSaved += async (s, e) =>
                {
                    _savedModifications = LoadModificationFile();
                    await RefreshProjectData();
                };

                detail.LoadProject(sourceRow);
                detail.ShowDialog(this);
            }
        }


        private static void OpenUrl(string url)
        {
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

        private async void rbtnTwoWeeks_CheckedChanged(object sender, EventArgs e)
        {
            await RefreshProjectData();
        }

        private async void rbtnMonth_CheckedChanged(object sender, EventArgs e)
        {
            await RefreshProjectData();
        }

        private async void rbtnModified_CheckedChanged(object sender, EventArgs e)
        {
            await RefreshProjectData();
        }
    }
}
