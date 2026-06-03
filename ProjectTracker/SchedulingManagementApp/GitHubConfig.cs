using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTracker
{
    public static class GitHubConfig
    {
        public const string GitHubOwner = "Firefly-Integrations";
        public const string GitHubRepo = "production-schedule";
        public const string GitHubBranch = "main";
        public const string GitHubMppPath = "2026 Forecast.mpp";

        // GitHub Personal Access Token
        public static string GitHubToken => Environment.GetEnvironmentVariable("GITHUB_TOKEN")
            ?? throw new InvalidOperationException("GITHUB_TOKEN environment variable is not set.");


        public static readonly string EncodedMppPath = Uri.EscapeDataString(GitHubMppPath);

        public static readonly string GitHubApiUrl = 
            $"https://api.github.com/repos/" + 
            $"{GitHubOwner}/{GitHubRepo}/contents/{EncodedMppPath}" + 
            $"?ref={GitHubBranch}";
    }
}
