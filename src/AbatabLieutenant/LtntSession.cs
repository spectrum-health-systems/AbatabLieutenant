// AbatabLieutenant.LtntSession.cs
// b---------x
// (c) A Pretty Cool Program

using System.Text.Json;

namespace AbatabLieutenant
{
    public class LtntSession
    {
        public string LtntVersion { get; set; }
        public string LtntBuild { get; set; }
        public string LtntRoot { get; set; }
        public string LtntStagingDirectory { get; set; }
        public string LtntLogRoot { get; set; }
        public string LtntLogFilePath { get; set; }
        public string AbatabWebServiceRoot { get; set; }
        public string AbatabRepositoryUrl { get; set; }
        public string AbatabRepositoryZipUrl { get; set; }
        public string AbatabRepositoryRawUrl { get; set; }
        public string RequestedBranch { get; set; }
        public string RequestedBranchUrl { get; set; }
        public string RequestedBranchZipUrl { get; set; }
        public string RequestedBranchRawUrl { get; set; }
        public string Datestamp { get; set; }
        public string Timestamp { get; set; }
        public List<string> AbatabDataRequiredDirectories { get; set; }
        public List<string> ValidBranches { get; set; }
        public List<string> WebServiceFiles { get; set; }
        public List<string> WebServiceFolders { get; set; }

        public static LtntSession LoadLocalFile(string settingsFile)
        {
            VerifySettingsFile(settingsFile);

            return JsonSerializer.Deserialize<LtntSession>(File.ReadAllText(settingsFile));
        }

        public static void VerifySettingsFile(string settingsFile)
        {
            if (!File.Exists(settingsFile))
            {
                RefreshLocalFile(settingsFile);
            }
        }

        public static void RefreshLocalFile(string settingsFile)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            File.WriteAllText(settingsFile, JsonSerializer.Serialize(CreateDefaultSettings(), jsonOptions));
        }

        private static LtntSession CreateDefaultSettings()
        {
            return new LtntSession
            {
                LtntVersion             = "4.0",
                LtntBuild               = "230307.1034",
                LtntRoot                = @"C:\AbatabData\Lieutenant",
                LtntStagingDirectory    = @"C:\AbatabData\Lieutenant\Staging",
                LtntLogRoot             = @"C:\AbatabData\Lieutenant\Logs",
                LtntLogFilePath         = "defined-at-runtime",
                AbatabWebServiceRoot    = @"C:\AvatoolWebService\Abatab_UAT",
                AbatabRepositoryUrl     = "https://github.com/spectrum-health-systems/Abatab/",
                AbatabRepositoryZipUrl  = "https://github.com/spectrum-health-systems/Abatab/archive/refs/heads/",
                AbatabRepositoryRawUrl  = "https://raw.githubusercontent.com/spectrum-health-systems/Abatab/",
                RequestedBranch         = "defined-at-runtime",
                RequestedBranchUrl      = "defined-at-runtime",
                RequestedBranchZipUrl   = "defined-at-runtime",
                RequestedBranchRawUrl   = "defined-at-runtime",
                Datestamp               = "defined-at-runtime",
                Timestamp               = "defined-at-runtime",
                AbatabDataRequiredDirectories = new List<string>
                {
                    @"C:\AbatabData\",
                    @"C:\AbatabData\Debuggler\",
                    @"C:\AbatabData\Lieutenant\",
                    @"C:\AbatabData\Lieutenant\Logs\",
                    @"C:\AbatabData\Lieutenant\Staging\",
                    @"C:\AbatabData\Primeval\",
                    @"C:\AbatabData\Public\",
                    @"C:\AbatabData\Public\Warnings\",
                    @"C:\AbatabData\SBOX\",
                    @"C:\AbatabData\SBOX\Warnings\",
                    @"C:\AbatabData\UAT\",
                    @"C:\AbatabData\UAT\Warnings\"
                },
                ValidBranches = new List<string>
                {
                    "development",
                    "main",
                    "testing",
                    "23.2"
                },
                WebServiceFiles = new List<string>
                {
                    "Abatab.asmx",
                    "Abatab.asmx.cs",
                    "packages.config",
                    "Web.config",
                    "Web.Debug.config",
                    "Web.Release.config"
                },
                WebServiceFolders = new List<string>
                {
                    "bin"
                }
            };
        }

        public static void CreateRuntimeSettings(LtntSession ltntSession, string requestedBranch)
        {
            ltntSession.Datestamp             = $"{DateTime.Now:yyMMdd}";
            ltntSession.Timestamp             = $"{DateTime.Now:HHmmss}";
            ltntSession.RequestedBranch       = requestedBranch;
            ltntSession.RequestedBranchZipUrl = $"{ltntSession.AbatabRepositoryZipUrl}{requestedBranch}";
            ltntSession.RequestedBranchRawUrl = $@"{ltntSession.AbatabRepositoryRawUrl}{requestedBranch}/";
            ltntSession.LtntLogFilePath       = $@"{ltntSession.LtntLogRoot}\{ltntSession.Datestamp}.{ltntSession.Datestamp}.ltnt";
        }
    }
}