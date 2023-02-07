// b---
using AbatabLieutenant.Logger;
namespace AbatabLieutenant.Session
{
    /// <summary>TBD</summary>
    internal class SessionData
    {
        public string AbatabDeploymentRoot { get; set; }
        public string DebugMode { get; set; }
        public string LtntVersion { get; set; }
        public string LtntRoot { get; set; }
        public string RepositoryUrl { get; set; }
        public string RequestedBranch { get; set; }
        public string RepositoryBranchUrl { get; set; }
        public string DateTimeStamp { get; set; }
        public string LogFilePath { get; set; }
        public Dictionary<string, string> LtntDirectories { get; set; }
        public Dictionary<string, string> SessionDirectories { get; set; }
        public Dictionary<string, string> RepositoryDetails { get; set; }
        public List<string> ValidArguments { get; set; }
        public List<string> ServiceFiles { get; set; }

        /// <summary>Get the local settings from the AbatabLieutenant.exe.config file.</summary>
        /// <returns></returns>
        public static SessionData Build(string requestedBranch)
        {
            SessionData ltntSession = new SessionData()
            {
                AbatabDeploymentRoot = Properties.Resources.AbatabDeploymentRoot,
                DebugMode            = Properties.Resources.DebugMode,
                LtntVersion          = Properties.Resources.LtntVersion,
                LtntRoot             = Properties.Resources.LtntRoot,
                RepositoryUrl        = Properties.Resources.RepositoryUrl
            };

            GetRuntimeSettings(ltntSession, requestedBranch);

            LogEvent.ToFile(Catalog.LogMessages.LogStart(ltntSession.LtntVersion), ltntSession.LogFilePath);

            return ltntSession;
        }

        /// <summary>TBD</summary>
        /// <param name="ltntSession"></param>
        /// <param name="requestedBranch"></param>
        private static void GetRuntimeSettings(SessionData ltntSession, string requestedBranch)
        {
            ltntSession.RequestedBranch       = requestedBranch;
            ltntSession.DateTimeStamp         = $"{DateTime.Now.ToString("yyMMdd-HHmm")}";
            ltntSession.LtntDirectories       = Catalog.FrameworkCollections.LtntDirectories(ltntSession.LtntRoot);
            ltntSession.SessionDirectories    = Catalog.FrameworkCollections.SessionDirectories(ltntSession.LtntRoot, ltntSession.AbatabDeploymentRoot);
            ltntSession.RepositoryBranchUrl   = $"{ltntSession.RepositoryUrl}{requestedBranch}.zip";
            ltntSession.ServiceFiles          = Catalog.FrameworkCollections.ServiceFiles();
            ltntSession.LogFilePath           = $"{ltntSession.LtntDirectories["Logs"]}/{ltntSession.DateTimeStamp}.ltnt";
        }
    }
}