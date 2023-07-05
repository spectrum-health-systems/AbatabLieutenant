// b230516.0955

using System.Text.Json;

namespace AbatabLieutenant
{
    /// <summary>The Session object for AbatabLieutenant.</summary>
    public class LtSession
    {
        /// <summary>The Abatab Lieutenant version.</summary>
        public string LtVer { get; set; }

        /// <summary>The Abatab Lieutenant build.</summary>
        public string LtBld { get; set; }

        /// <summary>The Abatab Lieutenant root directory.</summary>
        public string LtRoot { get; set; }

        /// <summary>The Abatab Lieutenant staging root directory</summary>
        public string StagingRoot { get; set; }

        /// <summary>The Abatab Lieutenant log root directory.</summary>
        public string LogRoot { get; set; }

        /// <summary>The Abatab Lieutenant log file path.</summary>
        public string LogPath { get; set; }

        /// <summary>Optional parameter.</summary>
        public string Option { get; set; }

        /// <summary>The Abatab web service root directory.</summary>
        public string AbServiceRoot { get; set; }

        /// <summary>The base Abatab repository URL.</summary>
        public string AbRepoUrl { get; set; }

        /// <summary>The URL to the Abatab branch .zip archive.</summary>
        public string AbRepoZipUrl { get; set; }

        /// <summary>The URL to the Abatab branch raw data.</summary>
        public string AbRepoRawUrl { get; set; }

        /// <summary>The requested branch repository.</summary>
        public string RequestedBranch { get; set; }

        /// <summary>The requested branch URL.</summary>
        public string RequestedBranchUrl { get; set; }

        /// <summary>The URL to the Abatab branch .zip archive.</summary>
        public string RequestedBranchZipUrl { get; set; }

        /// <summary>The URL to the Abatab branch raw data.</summary>
        public string RequestedBranchRawUrl { get; set; }

        /// <summary>The current date.</summary>
        public string Datestamp { get; set; }

        /// <summary>The current time.</summary>
        public string Timestamp { get; set; }

        /// <summary>The list of Abatab date folders.</summary>
        public List<string> AbatabDataFolders { get; set; }

        /// <summary>The list of valid Abatab branches.</summary>
        public List<string> ValidBranches { get; set; }

        /// <summary>The list of required Abatab web service files.</summary>
        public List<string> ServiceFiles { get; set; }

        /// <summary>The list of required Abatab web service folders.</summary>
        public List<string> ServiceFolders { get; set; }

        /// <summary>Load the local settings from the local settings file.</summary>
        /// <remarks>
        /// * If the local settings file does not exist, a local settings file
        ///   will be created with default values.
        /// </remarks>
        /// <returns></returns>
        public static LtSession LoadLocalSettings()
        {
            var settingsFile = "AbatabLieutenant.json";

            if (!File.Exists(settingsFile))
            {
                CreateLocalFile(settingsFile);
            }

            return JsonSerializer.Deserialize<LtSession>(File.ReadAllText(settingsFile));
        }

        /// <summary>Create a default local settings file.</summary>
        /// <param name="settingsFile">The name of the local settings file.</param>
        public static void CreateLocalFile(string settingsFile)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            LtSession defaultSettings = CreateDefaultSettings();

            File.WriteAllText(settingsFile, JsonSerializer.Serialize(defaultSettings, jsonOptions));
        }

        /// <summary>Creates the default settings values.</summary>
        /// <returns>The default setting values.</returns>
        private static LtSession CreateDefaultSettings()
        {
            return new LtSession
            {
                LtVer = "4.2",
                LtBld = "230705.1114",
                StagingRoot = @"C:\AbatabData\Lieutenant\Staging",
                LogRoot = @"C:\AbatabData\Lieutenant\Logs",
                LogPath = "defined-at-runtime",
                AbServiceRoot = @"C:\AbatabWebService\UAT",
                AbRepoUrl = "https://github.com/spectrum-health-systems/Abatab/",
                AbRepoZipUrl = "https://github.com/spectrum-health-systems/Abatab/archive/refs/heads/",
                AbRepoRawUrl = "https://raw.githubusercontent.com/spectrum-health-systems/Abatab/",
                RequestedBranch = "defined-at-runtime",
                RequestedBranchUrl = "defined-at-runtime",
                RequestedBranchZipUrl = "defined-at-runtime",
                RequestedBranchRawUrl = "defined-at-runtime",
                Datestamp = "defined-at-runtime",
                Timestamp = "defined-at-runtime",
                AbatabDataFolders = new List<string>
                {
                    @"C:\AbatabData\",
                    @"C:\AbatabData\Debuggler\",
                    @"C:\AbatabData\Lieutenant\",
                    @"C:\AbatabData\Lieutenant\Logs\",
                    @"C:\AbatabData\Lieutenant\Staging\",
                    @"C:\AbatabData\Primeval\",
                    @"C:\AbatabData\Public\",
                    @"C:\AbatabData\Public\Alerts\",
                    @"C:\AbatabData\Public\Warnings\",
                    @"C:\AbatabData\SBOX\",
                    @"C:\AbatabData\SBOX\Warnings\",
                    @"C:\AbatabData\UAT\",
                    @"C:\AbatabData\UAT\Warnings\"
                },
                ValidBranches = new List<string>
                {
                    "main",
                    "testing"
                },
                ServiceFiles = new List<string>
                {
                    "Abatab.asmx",
                    "Abatab.asmx.cs",
                    "packages.config",
                    "Web.config",
                    "Web.Debug.config",
                    "Web.Release.config"
                },
                ServiceFolders = new List<string>
                {
                    "bin"
                }
            };
        }

        /// <summary>Create various setting values at runtime.</summary>
        /// <param name="ltSession">The session object.</param>
        /// <param name="commandArguments">The arguments passed via the command line.</param>
        public static void CreateRuntimeSettings(LtSession ltSession, string[] commandArguments)
        {
            ltSession.Datestamp = $"{DateTime.Now:yyMMdd}";
            ltSession.Timestamp = $"{DateTime.Now:HHmm}";
            ltSession.RequestedBranch = commandArguments[0];
            ltSession.RequestedBranchUrl = $"https://github.com/spectrum-health-systems/Abatab/tree/development/{ltSession.RequestedBranch}";
            ltSession.RequestedBranchZipUrl = $"{ltSession.AbRepoZipUrl}{ltSession.RequestedBranch}.zip";
            ltSession.RequestedBranchRawUrl = $@"{ltSession.AbRepoRawUrl}{ltSession.RequestedBranch}/src/";
            ltSession.LogPath = $@"{ltSession.LogRoot}\{ltSession.Datestamp}.{ltSession.Timestamp}.ltnt";

            if (commandArguments.Length == 2)
            {
                ltSession.Option = commandArguments[1];
            }

            Utilities.WriteLog(Catalog.SessionDetail(ltSession), ltSession.LogPath);
        }
    }
}