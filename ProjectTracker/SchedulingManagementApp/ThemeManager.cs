using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace ProjectTracker
{
    public static class ThemeManager
    {
        #region Colors

        public static readonly Color DarkBackColor = Color.FromArgb(32, 32, 32);
        public static readonly Color DarkControlColor = Color.FromArgb(45, 45, 48);
        public static readonly Color DarkForeColor = Color.White;

        public static readonly Color LightBackColor = SystemColors.Control;
        public static readonly Color LightControlColor = Color.White;
        public static readonly Color LightForeColor = SystemColors.ControlText;

        #endregion

        #region Public Methods

        public static void ApplyTheme(Form form)
        {
            bool darkMode = IsWindowsDarkMode();

            if (darkMode)
            {
                EnableDarkTitleBar(form);
                ApplyDarkTheme(form);
            }
            else
            {
                ApplyLightTheme(form);
            }
        }

        #endregion

        #region Windows Theme Detection

        public static bool IsWindowsDarkMode()
        {
            using RegistryKey key =
                Registry.CurrentUser.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");

            object value = key?.GetValue("AppsUseLightTheme");

            return value is int theme && theme == 0;
        }

        #endregion

        #region Dark Theme

        private static void ApplyDarkTheme(Control control)
        {
            control.BackColor = DarkBackColor;
            control.ForeColor = DarkForeColor;

            switch (control)
            {
                case Button btn:
                    btn.BackColor = DarkControlColor;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.DimGray;
                    break;

                case TextBox txt:
                    txt.BackColor = DarkControlColor;
                    txt.ForeColor = DarkForeColor;
                    break;

                case RichTextBox rtb:
                    rtb.BackColor = DarkControlColor;
                    rtb.ForeColor = DarkForeColor;
                    break;

                case ComboBox cbo:
                    cbo.BackColor = DarkControlColor;
                    cbo.ForeColor = DarkForeColor;
                    break;

                case CheckedListBox clb:
                    clb.BackColor = DarkControlColor;
                    clb.ForeColor = DarkForeColor;
                    break;

                case ListBox lb:
                    lb.BackColor = DarkControlColor;
                    lb.ForeColor = DarkForeColor;
                    break;

                case DataGridView dgv:
                    ApplyDarkGridTheme(dgv);
                    break;

                case TabControl tab:
                    tab.BackColor = DarkBackColor;
                    tab.ForeColor = DarkForeColor;
                    break;

                case MenuStrip menu:
                    menu.BackColor = DarkControlColor;
                    menu.ForeColor = DarkForeColor;
                    break;

                case StatusStrip status:
                    status.BackColor = DarkControlColor;
                    status.ForeColor = DarkForeColor;
                    break;
            }

            foreach (Control child in control.Controls)
            {
                ApplyDarkTheme(child);
            }
        }

        private static void ApplyDarkGridTheme(DataGridView dgv)
        {
            dgv.BackgroundColor = DarkBackColor;
            dgv.GridColor = Color.DimGray;

            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = DarkControlColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = DarkForeColor;

            dgv.RowHeadersDefaultCellStyle.BackColor = DarkControlColor;
            dgv.RowHeadersDefaultCellStyle.ForeColor = DarkForeColor;

            dgv.DefaultCellStyle.BackColor = DarkBackColor;
            dgv.DefaultCellStyle.ForeColor = DarkForeColor;

            dgv.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        #endregion

        #region Light Theme

        private static void ApplyLightTheme(Control control)
        {
            control.BackColor = LightBackColor;
            control.ForeColor = LightForeColor;

            foreach (Control child in control.Controls)
            {
                ApplyLightTheme(child);
            }
        }

        #endregion

        #region Dark Title Bar

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(
            IntPtr hwnd,
            int attribute,
            ref int value,
            int size);

        private static void EnableDarkTitleBar(Form form)
        {
            if (!OperatingSystem.IsWindows())
                return;

            int useDark = 1;

            DwmSetWindowAttribute(
                form.Handle,
                20,
                ref useDark,
                sizeof(int));
        }

        #endregion
    }
}