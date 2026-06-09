using ProjectTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace ProjectTracker
{
    public partial class frmAddUser : Form
    {
        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };
        public frmAddUser()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Update control names if your designer uses different ones
            string first = tbxFirstName.Text.Trim();
            string last = (Controls["tbxLastName"] as TextBox)?.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(first))
            {
                MessageBox.Show("Please enter a first name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newUser = new Programmers
            {
                FirstName = first,
                LastName = last
            };

            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string filePath = Path.Combine(desktopPath, "Programmers.json");

                List<Programmers> list = new();

                if (File.Exists(filePath))
                {
                    string existing = await File.ReadAllTextAsync(filePath);
                    list = JsonSerializer.Deserialize<List<Programmers>>(existing, JsonOptions) ?? new List<Programmers>();
                }

                list.Add(newUser);

                string outJson = JsonSerializer.Serialize(list, JsonOptions);
                await File.WriteAllTextAsync(filePath, outJson);

                //MessageBox.Show($"User saved to {filePath}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.DialogResult = DialogResult.OK;

                if (ckbxKeepOpen.Checked)
                {
                    tbxFirstName.Text = "";
                    tbxLastName.Text = "";
                    tbxFirstName.Focus();
                }
                else
                {
                    
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
