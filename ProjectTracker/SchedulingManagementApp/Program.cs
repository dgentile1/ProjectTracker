namespace ProjectTracker
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Show the startup form as a dialog, not as the app's main form
            using var startup = new frmStartup();
            if (startup.ShowDialog() != DialogResult.OK)
                return; // user closed without selecting — exit app

            // Now run Form1 as the true main form
            Application.Run(new Form1());
        }
    }
}