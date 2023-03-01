using System.Text.Json;

namespace AbatabLieutenant
{
    public class LtntSession
    {
        public string AbatabLieutenantVersion { get; set; }
        public string AbatabLieutenantBuild { get; set; }
        public string AbatabLieutenantRoot { get; set; }
        public string AbatabWebServiceRoot { get; set; }
        public string AbatabRepositoryUrl { get; set; }
        public string RequestedBranch { get; set; }
        public string RepositoryBranchUrl { get; set; }
        public string Datestamp { get; set; }
        public string Timestamp { get; set; }
        public string LogFileRoot { get; set; }
        public string LogFilePath { get; set; }
        public List<string> AbatabDataRequiredDirectories { get; set; }
        public List<string> ValidBranches { get; set; }
        public List<string> WebServiceFiles { get; set; }
        public List<string> WebServiceFolders { get; set; }

        public static LtntSession Load()
        {
            string settingsString = File.ReadAllText("AbatabLieutenantSettings.json");

            return JsonSerializer.Deserialize<LtntSession>(settingsString);
        }

        public static void Update(LtntSession ltntSession, string requestedBranch)
        {
            ltntSession.Datestamp           = $"{DateTime.Now:yyMMdd}";
            ltntSession.Timestamp           = $"{DateTime.Now:HHmmss}";
            ltntSession.RequestedBranch     = requestedBranch;
            ltntSession.RepositoryBranchUrl = $"{ltntSession.AbatabRepositoryUrl}{requestedBranch}";
            ltntSession.LogFilePath         = $@"{ltntSession.LogFileRoot}\{ltntSession.Datestamp}.{ltntSession.Datestamp}.ltnt";
        }

        public static void ForceDefaultSettings()
        {
            LtntSession defaultSettings = new LtntSession
            {
                AbatabLieutenantVersion = "4.0",
                AbatabLieutenantBuild   = "230228.1142",
                AbatabLieutenantRoot    = @"C:\AbatabData\Lieutenant",
                AbatabWebServiceRoot    = @"C:\AvatoolWebService\Abatab_UAT",
                AbatabRepositoryUrl     = "https://github.com/spectrum-health-systems/Abatab/archive/refs/heads/",
                RequestedBranch         = "defined-at-runtime",
                RepositoryBranchUrl     = "defined-at-runtime",
                Datestamp               = "defined-at-runtime",
                Timestamp               = "defined-at-runtime",
                LogFileRoot             = @"C:\AbatabData\Lieutenant\Logs",
                LogFilePath             = "defined-at-runtime",
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

            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string settingsString = JsonSerializer.Serialize(defaultSettings, jsonOptions);

            File.WriteAllText("AbatabLieutenantSettings.json", settingsString);
        }

        public static void VerifySettingFile()
        {
            if (!File.Exists("AbatabLieutenantSettings.json"))
            {
                ForceDefaultSettings();
            }
        }

        public static void VerifyAbatabRequirements(LtntSession ltntSession)
        {
            foreach (var directory in ltntSession.AbatabDataRequiredDirectories)
            {
                Utility.VerifyDirectoryExists(directory, ltntSession.LogFilePath);
            }
        }
    }
}