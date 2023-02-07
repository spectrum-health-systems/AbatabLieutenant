// AbatabLieutenant.Session.cs
// Abatab Lieutenant session details.
// b---

namespace AbatabLieutenant.Session
{
    /// <summary>TBD</summary>
    public class SessionData
    {
        public string DebugMode { get; set; }
        public string LtntVersion { get; set; }
        public string LtntRoot { get; set; }
        public string AbatabDeploymentRoot { get; set; }
        public string RepositoryUrl { get; set; }
        public string RequestedBranch { get; set; }
        public string TimeStamp { get; set; }
        public string LogFileName { get; set; }
        public Dictionary<string, string> LtntDirectories { get; set; }
        public Dictionary<string, string> DeploymentDirectories { get; set; }
        public Dictionary<string, string> RepositoryDetails { get; set; }
        public List<string> ValidArguments { get; set; }
        public List<string> ServiceFiles { get; set; }
        //public string LogFileContents { get; set; }

        /// <summary>TBD</summary>
        /// <param name="requestedBranch"></param>
        /// <returns></returns>
        public static SessionData Build(string requestedBranch)
        {
            SessionData ltntSession = GetLocalSettings();
            ltntSession.RequestedBranch = requestedBranch;
            ltntSession.TimeStamp = $"{DateTime.Now.ToString("yyMMdd_HHmm")}";
            ltntSession.LtntDirectories = Data.Catalog.Framework.LtntDirectories(ltntSession.LtntRoot, ltntSession.TimeStamp);
            ltntSession.DeploymentDirectories = Data.Catalog.Framework.DeploymentDirectories(ltntSession.LtntRoot, ltntSession.TimeStamp);
            ltntSession.RepositoryDetails = Data.Catalog.GitRepository.RepositoryInformation(ltntSession.TimeStamp, ltntSession.DeploymentDirectories["Staging"], ltntSession.RequestedBranch, ltntSession.RepositoryUrl);
            ltntSession.ValidArguments = Data.Catalog.CommandLine.ValidArguments();
            ltntSession.ServiceFiles = Data.Catalog.WebService.ServiceFiles();
            ltntSession.LogFileName = $@"{ltntSession.LtntDirectories["Logs"]}\{ltntSession.TimeStamp}.ltnt";
            //ltntSession.LogFileContents = "";

            return ltntSession;
        }

        /// <summary>TBD</summary>
        /// <returns></returns>
        private static SessionData GetLocalSettings() => new SessionData
        {
            DebugMode = Properties.Resources.DebugMode,
            LtntVersion = Properties.Resources.LtntVersion,
            LtntRoot = Properties.Resources.LtntRoot,
            AbatabDeploymentRoot = Properties.Resources.AbatabDeploymentRoot,
            RepositoryUrl = Properties.Resources.RepositoryUrl,
        };
    }
}
