using ProjectTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectTracker
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            // Skip loading at design time to avoid designer issues
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                _ = LoadProgrammersAsync();
            }
        }

        private const string LocalFileName = "Programmers.json";
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions { WriteIndented = true };
        public static string GetDesktopFilePath(string fileName = "Programmers.json")
           => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

        public static async Task<string> SaveToDesktopAsync<T>(IEnumerable<T> programmers, string fileName = "Programmers.json")
        {
            string path = GetDesktopFilePath(fileName);
            string json = JsonSerializer.Serialize(programmers, JsonOptions);
            await File.WriteAllTextAsync(path, json, Encoding.UTF8);
            return path;
        }

        public static string SaveToDesktop<T>(IEnumerable<T> programmers, string fileName = "Programmers.json")
        {
            string path = GetDesktopFilePath(fileName);
            string json = JsonSerializer.Serialize(programmers, JsonOptions);
            File.WriteAllText(path, json, Encoding.UTF8);
            return path;
        }

        public static async Task<List<T>> LoadFromDesktopAsync<T>(string fileName = "Programmers.json")
        {
            string path = GetDesktopFilePath(fileName);
            if (!File.Exists(path))
                return new List<T>();

            string json = await File.ReadAllTextAsync(path, Encoding.UTF8);
            return JsonSerializer.Deserialize<List<T>>(json, JsonOptions) ?? new List<T>();
        }
        public static async Task SaveLocalAsync(IEnumerable<Programmers> programmers)
        {
            string json = JsonSerializer.Serialize(programmers, JsonOptions);
            await File.WriteAllTextAsync(LocalFileName, json, Encoding.UTF8);
        }

        public static async Task<List<Programmers>> LoadLocalAsync()
        {
            if (!File.Exists(LocalFileName))
                return new List<Programmers>();

            string json = await File.ReadAllTextAsync(LocalFileName, Encoding.UTF8);
            return JsonSerializer.Deserialize<List<Programmers>>(json, JsonOptions) ?? new List<Programmers>();
        }

        // Upload (create or update) the file to the repository via GitHub Contents API
        public static async Task UploadToGitHubAsync(IEnumerable<Programmers> programmers, string commitMessage)
        {
            string path = "Programmers.json";
            string apiUrl = $"https://api.github.com/repos/{GitHubConfig.GitHubOwner}/{GitHubConfig.GitHubRepo}/contents/{Uri.EscapeDataString(path)}?branch={GitHubConfig.GitHubBranch}";

            using HttpClient client = new();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("ProjectTracker");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", GitHubConfig.GitHubToken);

            // check for existing file to get sha
            string sha = null;
            var getResp = await client.GetAsync(apiUrl);
            if (getResp.IsSuccessStatusCode)
            {
                using var doc = JsonDocument.Parse(await getResp.Content.ReadAsStringAsync());
                if (doc.RootElement.TryGetProperty("sha", out var shaProp))
                    sha = shaProp.GetString();
            }

            string fileContent = JsonSerializer.Serialize(programmers, JsonOptions);
            string b64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(fileContent));

            var payload = new
            {
                message = commitMessage,
                content = b64,
                sha = sha,
                branch = GitHubConfig.GitHubBranch
            };

            var putContent = new StringContent(JsonSerializer.Serialize(payload, JsonOptions), Encoding.UTF8, "application/json");
            var putResp = await client.PutAsync(apiUrl, putContent);
            putResp.EnsureSuccessStatusCode();
        }

        // Download and decode file from GitHub contents API; falls back to local if not found
        public static async Task<List<Programmers>> DownloadFromGitHubAsync()
        {
            string path = "Programmers.json";
            string apiUrl = $"https://api.github.com/repos/{GitHubConfig.GitHubOwner}/{GitHubConfig.GitHubRepo}/contents/{Uri.EscapeDataString(path)}?ref={GitHubConfig.GitHubBranch}";

            using HttpClient client = new();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("ProjectTracker");
            // token is optional for public repos; for private repos include it:
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", GitHubConfig.GitHubToken);

            var resp = await client.GetAsync(apiUrl);
            if (!resp.IsSuccessStatusCode)
            {
                // fallback to local file
                return await LoadLocalAsync();
            }

            string json = await resp.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            if (!doc.RootElement.TryGetProperty("content", out var contentProp))
                return await LoadLocalAsync();

            string encoding = doc.RootElement.TryGetProperty("encoding", out var encProp) ? encProp.GetString() : "base64";
            string content = contentProp.GetString() ?? string.Empty;

            string fileText;
            if (encoding.Equals("base64", StringComparison.OrdinalIgnoreCase))
            {
                var bytes = Convert.FromBase64String(content);
                fileText = Encoding.UTF8.GetString(bytes);
            }
            else
            {
                fileText = content;
            }

            var list = JsonSerializer.Deserialize<List<Programmers>>(fileText, JsonOptions);
            return list ?? new List<Programmers>();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            //// Build list from ListBox items (support both Programmers objects and strings)
            //var list = new List<Programmers>();
            //foreach (var item in lbxProgrammers.Items)
            //{
            //    if (item is Programmers p)
            //    {
            //        list.Add(p);
            //    }
            //    else if (item is string s)
            //    {
            //        var parts = s.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
            //        if (parts.Length == 1)
            //            list.Add(new Programmers { FirstName = parts[0], LastName = string.Empty });
            //        else
            //            list.Add(new Programmers { FirstName = parts[0], LastName = parts[1] });
            //    }
            //}

            //try
            //{
            //    // Save local file and also to Desktop for quick testing
            //    await SaveLocalAsync(list);
            //    await SaveToDesktopAsync(list);

            //    MessageBox.Show("Programmers saved locally and to Desktop.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Failed to save programmers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUser addUser = new frmAddUser();
            var result = addUser.ShowDialog();
            // If a new user was added, reload the list so the UI updates
            if (result == DialogResult.OK)
            {
                await LoadProgrammersAsync();
            }
        }

        private async Task LoadProgrammersAsync()
        {
            List<Programmers> list;

            // prefer desktop file for quick dev testing; fallback to local file
            try
            {
                list = await LoadFromDesktopAsync<Programmers>();
                if (list == null || list.Count == 0)
                {
                    list = await LoadLocalAsync();
                }
            }
            catch
            {
                list = await LoadLocalAsync();
            }

            lbxProgrammers.BeginUpdate();
            lbxProgrammers.Items.Clear();
            foreach (var p in list)
            {
                // store the object so saving can re-create the JSON easily; ToString() will display nicely
                lbxProgrammers.Items.Add(p);
            }
            lbxProgrammers.EndUpdate();
        }
    }
}