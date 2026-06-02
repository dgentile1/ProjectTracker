using com.sun.tools.javadoc;
using MPXJ.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using Task = System.Threading.Tasks.Task;

namespace ProjectTracker
{
    public partial class Form1 : Form
    {
        private readonly System.Windows.Forms.Timer refreshTimer = new();
        public Form1()
        {
            InitializeComponent();
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

                dgvDetailView.AutoGenerateColumns = true;
                dgvDetailView.DataSource =
                    await LoadProjectTasksAsync();


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
                    });

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

            dgvDetailView.DataSource = rows;

            UpdateStatistics(rows);
        }

        private void UpdateStatistics(List<MainScheduleGridView> rows)
        {
            lblProjectCount.Text =
                $"Projects: {rows.Count}";

            lblModifiedCount.Text =
                $"Modified: {rows.Count(r => r.IsModified)}";
        }
    }
}


