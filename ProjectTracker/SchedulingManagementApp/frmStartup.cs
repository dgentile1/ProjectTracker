using ProjectTracker;
using ProjectTracker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTracker
{
    public partial class frmStartup : Form
    {
        // ── Constants ──────────────────────────────────────────────────────────
        private const string ConfigFileName = "UserConfig.json";
        private const string ProgrammersFileName = "Programmers.json";

        //private static readonly JsonSerializerOptions JsonOptions = new()
        //{
        //    WriteIndented = true,
        //    PropertyNameCaseInsensitive = true
        //};

        // ── State ──────────────────────────────────────────────────────────────
        private List<Programmers> _programmers = new();

        // ── Constructor ────────────────────────────────────────────────────────
        public frmStartup()
        {
            InitializeComponent();
            Load += (_, _) => ThemeManager.ApplyTheme(this);
        }

        // ── Form Load ──────────────────────────────────────────────────────────
        private async void frmStartup_Load(object sender, EventArgs e)
        {
            var config = JsonFileHelper.LoadObject<UserConfig>("UserConfig.json");

            System.Diagnostics.Debug.WriteLine(
                $"[frmStartup] Config username: '{config?.Username}' | " +
                $"Windows username: '{Environment.UserName}'");

            if (config != null &&
                string.Equals(config.Username, Environment.UserName,
                    StringComparison.OrdinalIgnoreCase))
            {
                // Windows username matches saved config — bypass the form
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            // No config or username mismatch — show the selection UI
            await PopulateDropdownAsync();
        }

        // ── UI Event Handlers ─────────────────────────────────────────────────

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (cmbProgrammer.SelectedItem is not ProgrammerItem selected)
            {
                MessageBox.Show("Please select your name before continuing.",
                    "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Build config from the selected programmer + current Windows username.
            var config = new UserConfig
            {
                UserGuid = selected.Programmer.UserGuid,
                FirstName = selected.Programmer.FirstName,
                LastName = selected.Programmer.LastName,
                Username = Environment.UserName          // Windows login name
            };

            JsonFileHelper.SaveObject("UserConfig.json", config);
            OpenForm1AndClose();
        }

        // ── Helpers ────────────────────────────────────────────────────────────

        /// <summary>Loads the programmer list from the Desktop (same path as Form1 uses).</summary>
        private static async Task<List<Programmers>> LoadProgrammersAsync()
        {
            try
            {
                return await JsonFileHelper.LoadListAsync<Programmers>(ProgrammersFileName);                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[frmStartup] Failed to load programmers: {ex}");
                return new List<Programmers>();
            }
        }

        /// <summary>Fills the combo box with programmer names.</summary>
        private async Task PopulateDropdownAsync()
        {
            if (_programmers.Count == 0)
                _programmers = await LoadProgrammersAsync();

            cmbProgrammer.Items.Clear();

            foreach (var p in _programmers.OrderBy(p => p.LastName).ThenBy(p => p.FirstName))
            {
                var display = string.IsNullOrWhiteSpace(p.LastName)
                    ? p.FirstName
                    : $"{p.FirstName} {p.LastName}";

                cmbProgrammer.Items.Add(new ProgrammerItem(display, p));
            }

            if (cmbProgrammer.Items.Count > 0)
                cmbProgrammer.SelectedIndex = 0;

            // Show the panel now that data is ready.
            pnlSelectUser.Visible = true;
        }


        /// <summary>Opens Form1 and closes this startup form.</summary>
        private void OpenForm1AndClose()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ── Inner helper class ─────────────────────────────────────────────────

        /// <summary>Wraps a Programmers object so the ComboBox displays a friendly name.</summary>
        private sealed class ProgrammerItem
        {
            public string Display { get; }
            public Programmers Programmer { get; }

            public ProgrammerItem(string display, Programmers programmer)
            {
                Display = display;
                Programmer = programmer;
            }

            public override string ToString() => Display;
        }
    }
}