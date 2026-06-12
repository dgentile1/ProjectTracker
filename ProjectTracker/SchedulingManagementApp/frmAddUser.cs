using ProjectTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ProjectTracker
{
    public partial class frmAddUser : Form
    {
        //private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };
        public frmAddUser()
        {
            InitializeComponent();
            Load += (_, _) => ThemeManager.ApplyTheme(this);
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
                var list = await JsonFileHelper.LoadListAsync<Programmers>("Programmers.json");
                list.Add(newUser);
                await JsonFileHelper.SaveListAsync("Programmers.json", list);

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
            this.Close();
        }

    }
}
