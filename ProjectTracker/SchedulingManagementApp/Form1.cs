using com.sun.tools.javadoc;
using Microsoft.Win32;
using MPXJ.Net;
using ProjectTracker.Models;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text.Json;
using Task = System.Threading.Tasks.Task;
using System.Linq;

namespace ProjectTracker
{
    public partial class Form1 : Form
    {
        private readonly System.Windows.Forms.Timer refreshTimer = new();
        private List<MainScheduleGridView> _allRows = new();

        public Form1()
        {
            InitializeComponent();
            Load += (_, _) => ThemeManager.ApplyTheme(this);

            // wire listbox events so selection filters the grid
            lbxProjectNames.SelectedIndexChanged += LbxProjectNames_SelectedIndexChanged;
            lbxProgrammerNames.SelectedIndexChanged += LbxProgrammerNames_SelectedIndexChanged;

            refreshTimer.Interval = 5 * 60 * 1000;

            refreshTimer.Tick += async (s, e) =>
            {
                await RefreshProjectData();
            };

            refreshTimer.Start();
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                await RefreshProjectData();
                refreshTimer.Start();

                dgvDetailView.AutoGenerateColumns = false;
                dgvDetailView.DataSource =
                    await LoadProjectTasksAsync();

                ApplyRowStyles();
                await LoadAndShowProgrammersAsync();
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

                List<MainScheduleGridView> rows =
                    project.Tasks
                        .Where(t => !string.IsNullOrWhiteSpace(t.Name))
                        .Select(t => new MainScheduleGridView
                        {
                            MSProjectGuid = t.GUID,
                            ProjectName = t.Name,
                            StartDate = t.Start,
                            CurrentFinishDate = t.Finish,
                            CurrentPercent = (int)(t.PercentageComplete ?? 0)
                        })
                        .ToList();

                var modifications = LoadModificationFile();

                foreach (var row in rows)
                {
                    if (row.MSProjectGuid.HasValue &&
                        modifications.TryGetValue(
                            row.MSProjectGuid.Value,
                            out ProjectModification mod))
                    {
                        row.UpdatedFinishDate = mod.UpdatedFinishDate;
                        row.UpdatedPercent = mod.UpdatedPercent;
                        row.Notes = mod.Notes;
                    }
                }

                DateTime start = dtpStart.Value.Date;
                DateTime end = dtpEnd.Value.Date;

                var filteredRows =
                    rows
                        .Where(r =>
                            r.StartDate >= start &&
                            r.StartDate <= end)
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
            lbxProjectNames.BeginUpdate();
            lbxProjectNames.Items.Clear();

            var names = _allRows
                .Select(r => r.ProjectName)
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Distinct()
                .OrderBy(n => n, StringComparer.OrdinalIgnoreCase);

            foreach (var name in names)
                lbxProjectNames.Items.Add(name);

            lbxProjectNames.EndUpdate();
        }

        private async Task LoadAndShowProgrammersAsync()
        {
            //try GitHub first(falls back to local if not available)
            //List<Programmers> programmers = await frmSettings.DownloadFromGitHubAsync();

            //lbxProgrammerNames.Items.Clear();
            //foreach (var p in programmers)
            //{
            //    var display = string.IsNullOrWhiteSpace(p.LastName) ? p.FirstName : $"{p.FirstName} {p.LastName}";
            //    lbxProgrammerNames.Items.Add(display);
            //}

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

            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    lbxProgrammerNames.BeginUpdate();
                    lbxProgrammerNames.Items.Clear();
                    foreach (var p in programmers)
                    {
                        var display = string.IsNullOrWhiteSpace(p.LastName) ? p.FirstName : $"{p.FirstName} {p.LastName}";
                        lbxProgrammerNames.Items.Add(display);
                    }
                    lbxProgrammerNames.EndUpdate();
                });
            }
            else
            {
                lbxProgrammerNames.BeginUpdate();
                lbxProgrammerNames.Items.Clear();
                foreach (var p in programmers)
                {
                    var display = string.IsNullOrWhiteSpace(p.LastName) ? p.FirstName : $"{p.FirstName} {p.LastName}";
                    lbxProgrammerNames.Items.Add(display);
                }
                lbxProgrammerNames.EndUpdate();
            }
        }

        private void ApplyFilters()
        {
            if (_allRows == null)
                return;

            string selectedProject = lbxProjectNames.SelectedItem as string;
            string selectedProgrammer = lbxProgrammerNames.SelectedItem as string;

            var filtered = _allRows.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(selectedProject))
            {
                filtered = filtered.Where(r => string.Equals(r.ProjectName, selectedProject, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(selectedProgrammer))
            {
                // match by Notes containing the programmer name (first or first+last)
                string prog = selectedProgrammer;
                filtered = filtered.Where(r =>
                    !string.IsNullOrWhiteSpace(r.Notes) &&
                    (r.Notes.IndexOf(prog, StringComparison.OrdinalIgnoreCase) >= 0 ||
                     r.Notes.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Any(tok => string.Equals(tok, prog, StringComparison.OrdinalIgnoreCase))));
            }

            var list = filtered.ToList();
            dgvDetailView.DataSource = list;
            ApplyRowStyles();
            UpdateStatistics(list);
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
            if (dgvDetailView.Rows == null || dgvDetailView.Rows.Count == 0)
                return;

            foreach (DataGridViewRow dgvr in dgvDetailView.Rows)
            {
                if (dgvr.DataBoundItem is MainScheduleGridView item && item.IsModified)
                {
                    dgvr.DefaultCellStyle.BackColor = Color.LightCoral;
                    dgvr.DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    dgvr.DefaultCellStyle.BackColor = Color.White;
                    dgvr.DefaultCellStyle.ForeColor = Color.Black;
                }
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
    }
}
