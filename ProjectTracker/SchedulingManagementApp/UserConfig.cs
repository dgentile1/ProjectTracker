using System;

namespace ProjectTracker
{
    /// <summary>
    /// Represents the saved config file for the current user.
    /// Saved as UserConfig.json on the Desktop.
    /// </summary>
    public class UserConfig
    {
        public Guid UserGuid { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}