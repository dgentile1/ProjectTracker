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

        //For Tool Tip Delay
        private readonly System.Windows.Forms.Timer _notesToolTipTimer = new System.Windows.Forms.Timer();
        private DataGridViewCell? _hoverCell;
        private int _notesToolTipDelayMs = 1250; // 1.25 second delay before showing tooltip, adjust as needed
        private readonly ToolTip _toolTip = new();

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
            string tempFile = await DownloadMppFromGitHubAsync();

            try
            {
                var reader = new UniversalProjectReader();
                var project = reader.Read(tempFile);

                var allTasks = project.Tasks
                        .Where(t => !string.IsNullOrWhiteSpace(t.Name))
                        .Where(t => string.Equals(t.GetText(1)?.ToString(), "2.0 Production", StringComparison.OrdinalIgnoreCase))
                        .ToList();

                var level1Tasks = allTasks.Where(t => t.OutlineLevel == 1).ToList();
                var level2Tasks = allTasks.Where(t => t.OutlineLevel == 2).ToList();

                var embeddedTasks = level2Tasks
                     .Where(t => t.Name.Contains("Embedded", StringComparison.OrdinalIgnoreCase))
                     .ToList();

                List<MainScheduleGridView> rows = level1Tasks
                    .Select(parent =>
                    {
                        // Find matching level 2 child by WBS prefix
                        var embeddedChild = embeddedTasks.FirstOrDefault(c =>
                           c.WBS.StartsWith(parent.WBS + ".", StringComparison.OrdinalIgnoreCase) ||
                           c.WBS == parent.WBS);

                        // Fall back to any level 2 child if no embedded child found
                        var anyChild = level2Tasks.FirstOrDefault(c =>
                            c.WBS.StartsWith(parent.WBS + ".", StringComparison.OrdinalIgnoreCase) ||
                            c.WBS == parent.WBS);

                        var dateSource = embeddedChild ?? anyChild;

                        return new MainScheduleGridView
                        {
                            MSProjectGuid = parent.GUID,
                            ProjectName = parent.Name,           // Level 1 name
                            StartDate = dateSource?.Start,          // Level 2 date
                            CurrentFinishDate = dateSource?.Finish,        // Level 2 date
                            CurrentPercent = (int)(dateSource?.PercentageComplete)
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

                var modifications = LoadModificationFile();

                foreach (var row in rows)
                {
                    if (row.MSProjectGuid.HasValue &&
                        modifications.TryGetValue(
                            row.MSProjectGuid.Value,
                            out ProjectModification mod))
                    {
                        row.ProgrammersName = mod.ProgrammersName;
                        row.UpdatedFinishDate = mod.UpdatedFinishDate;
                        row.UpdatedPercent = mod.UpdatedPercent;
                        row.TestingPercent = mod.TestingPercent;
                        row.Notes = mod.Notes;
                    }
                }

                DateTime start = dtpStart.Value.Date;
                DateTime end = dtpEnd.Value.Date;

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
            var rows =
                await LoadProjectTasksAsync();

            // cache all rows for filtering
            _allRows = rows;

            // populate project list based on loaded rows
            PopulateProjectNames();

            // apply any active filters to the grid
            ApplyFilters();

            UpdateStatistics(rows);
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
                programmers = await frmSettings.LoadFromDesktopAsync<Programmers>();
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
                filtered = filtered.Where(r =>
                    !string.IsNullOrWhiteSpace(r.Notes) &&
                    checkedProgrammers.Any(prog =>
                        r.Notes.IndexOf(prog, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        r.Notes.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Any(tok => string.Equals(tok, prog, StringComparison.OrdinalIgnoreCase))));
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
            dt.Columns.Add("UpdatedFinishDate");
            dt.Columns.Add("CurrentPercent");
            dt.Columns.Add("UpdatedPercent");
            dt.Columns.Add("TestingPercent");
            dt.Columns.Add("ReleasedChecked");
            dt.Columns.Add("ReleasedDate");
            dt.Columns.Add("Notes");
            dt.Columns.Add("IsModified", typeof(bool));

            foreach (var row in rows)
            {
                dt.Rows.Add(
                    row.MSProjectGuid,
                    row.ProgrammersName ?? string.Empty,
                    row.ProjectName,
                    row.StartDate,
                    row.CurrentFinishDate,
                    row.UpdatedFinishDate,
                    row.CurrentPercent,
                    row.UpdatedPercent,
                    row.TestingPercent,
                    row.ReleasedChecked,
                    row.ReleasedDate,
                    row.Notes,
                    row.IsModified
                );
            }

            dt.RowChanged += (s, e) =>
            {
                if (e.Row["IsModified"] is bool b && !b)
                {
                    e.Row["IsModified"] = true;
                }
                ApplyRowStyles();
            };

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
                $"Modified: {rows.Count(r => r.IsModified)}";
        }

        private void ApplyRowStyles()
        {
            foreach (DataGridViewRow dgvr in dgvDetailView.Rows)
            {
                if (dgvr.DataBoundItem is not DataRowView drv) continue;

                bool isModified = drv.Row["IsModified"] != DBNull.Value && (bool)drv.Row["IsModified"];

                dgvr.DefaultCellStyle.BackColor = isModified ? Color.LightCoral : Color.White;
                dgvr.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void dgvDetailView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

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
            ApplyRowStyles();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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

                        TestingPercent = int.TryParse(
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
            }
            catch (Exception ex)
            {
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
        //-------------------------------------------------------
    }
}
