using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace ProjectTracker
{
    public partial class frmTrelloURL : Form
    {
        private Guid _projectGuid;
        private const string ModFile = "ProjectModifications.json";

        // ── Public result – read this after ShowDialog() returns OK ───────
        public string? SavedUrl { get; private set; }

        public frmTrelloURL()
        {
            InitializeComponent();
            Load += (_, _) => ThemeManager.ApplyTheme(this);
        }

        // ─────────────────────────────────────────────────────────────────
        //  Public loader – call before ShowDialog()
        // ─────────────────────────────────────────────────────────────────
        public void LoadForProject(Guid projectGuid, string projectName)
        {
            _projectGuid = projectGuid;
            this.Text = $"Trello URL — {projectName}";

            // Pre-fill with any existing saved URL
            var mods = LoadModifications();
            if (mods.TryGetValue(projectGuid, out var mod) &&
                !string.IsNullOrWhiteSpace(mod.TrelloUrl))
            {
                tbxTrelloURL.Text = mod.TrelloUrl;
            }
        }

        // ─────────────────────────────────────────────────────────────────
        //  Event handlers
        // ─────────────────────────────────────────────────────────────────
        private void btnSave_Click(object sender, EventArgs e)
        {
            string url = tbxTrelloURL.Text.Trim();

            if (!string.IsNullOrWhiteSpace(url) &&
                !Uri.TryCreate(url, UriKind.Absolute, out _))
            {
                MessageBox.Show(
                    "Please enter a valid URL (e.g. https://trello.com/c/...)",
                    "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var mods = LoadModifications();

                if (!mods.TryGetValue(_projectGuid, out var mod))
                {
                    mod = new ProjectModification { MSProjectGuid = _projectGuid };
                    mods[_projectGuid] = mod;
                }

                mod.TrelloUrl = string.IsNullOrWhiteSpace(url) ? null : url;

                string json = JsonSerializer.Serialize(
                    mods,
                    new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(ModFile, json);

                SavedUrl = mod.TrelloUrl;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Save failed: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ─────────────────────────────────────────────────────────────────
        //  JSON helper
        // ─────────────────────────────────────────────────────────────────
        private static Dictionary<Guid, ProjectModification> LoadModifications()
        {
            if (!File.Exists(ModFile))
                return new Dictionary<Guid, ProjectModification>();

            try
            {
                string json = File.ReadAllText(ModFile);
                return JsonSerializer.Deserialize<Dictionary<Guid, ProjectModification>>(
                           json, JsonFileHelper.JsonOptions)
                       ?? new Dictionary<Guid, ProjectModification>();
            }
            catch
            {
                return new Dictionary<Guid, ProjectModification>();
            }
        }
    }
}