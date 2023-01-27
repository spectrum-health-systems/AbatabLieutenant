// AbatabLieutenant.Session.cs
// Abatab Lieutenant session details.
// b---

using AbatabLieutenant.Data;

namespace AbatabLieutenant
{
    /// <summary>TBD</summary>
    public class Session
    {
        public string DebugMode { get; set; }
        public string LtntVersion { get; set; }
        public string LtntRoot { get; set; }
        public string RepositoryUrl { get; set; }
        public string RequestedBranch { get; set; }
        public string DateTimeStamp { get; set; }
        //public string LogFileName { get; set; }
        public Dictionary<string, string> LtntDirectories { get; set; }
        public Dictionary<string, string> RepositoryInformation { get; set; }
        public List<string> ValidArguments { get; set; }
        public List<string> ServiceFiles { get; set; }

        /// <summary>TBD</summary>
        /// <param name="requestedBranch"></param>
        /// <returns></returns>
        public static Session BuildSessionData(string requestedBranch)
        {
            Session ltntSession               = InitializeWithLocalSettings();
            ltntSession.RequestedBranch       = requestedBranch;
            ltntSession.DateTimeStamp         = $"{DateTime.Now.ToString("yyMMdd_HHmm")}";
            //ltntSession.LogFileName           = $"{DateTime.Now.ToString("yyMMdd_HHmm")}.ltnt";
            ltntSession.LtntDirectories       = Catalog_old.DeploymentDirectories(ltntSession.LtntRoot, ltntSession.DateTimeStamp);
            ltntSession.RepositoryInformation = Catalog_old.RepositoryInformation(ltntSession.RequestedBranch, ltntSession.LtntRoot, ltntSession.RepositoryUrl);
            ltntSession.ValidArguments        = Catalog_old.ValidArguments();
            ltntSession.ServiceFiles          = Catalog_old.ServiceFiles();

            return ltntSession;
        }

        /// <summary>TBD</summary>
        /// <returns></returns>
        private static Session InitializeWithLocalSettings() => new Session
        {
            DebugMode       = Properties.Resources.DebugMode,
            LtntVersion     = Properties.Resources.LtntVersion,
            LtntRoot        = Properties.Resources.LtntRoot,
            RepositoryUrl   = Properties.Resources.RepositoryUrl,
        };
    }
}
