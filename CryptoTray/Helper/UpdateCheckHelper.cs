using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Threading.Tasks;

namespace CryptoTray.Helper
{
    public class UpdateCheckHelper
    {
        private string Owner { get; set; }
        private string Repo { get; set; }

        public string LatestVersionUrl
        {
            get
            {
                return $"https://github.com/{Owner}/{Repo}/releases/latest";
            }
        }

        public UpdateCheckHelper(string owner, string repo)
        {
            Owner = owner;
            Repo = repo;         
        }

        public async Task<string> UpdateAvailable()
        {
            try
            {
                var latest = await GetLatestVersionFromGithub();
                var current = GetCurrentVersion();

                if (latest > current)
                {
                    return latest.ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //Logger.Error("Update check failed", ex);
                return null;
            }
        }

        private async Task<Version> GetLatestVersionFromGithub()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var latestRelease = await client.GetFromJsonAsync<GitHubRelease>($"https://api.github.com/repos/{Owner}/{Repo}/releases/latest");

            var latestVersion = new Version(latestRelease.tag_name.Replace("v", ""));

            return latestVersion;
        }

        public Version GetCurrentVersion()
        {
            var currentVersion = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>().Version;

            return new Version(currentVersion);
        }
    }

    public class GitHubRelease
    {
        public string url { get; set; }
        public int id { get; set; }
        public string tag_name { get; set; }
        public string name { get; set; }
        public bool prerelease { get; set; }
        public string published_at { get; set; }
    }
}
