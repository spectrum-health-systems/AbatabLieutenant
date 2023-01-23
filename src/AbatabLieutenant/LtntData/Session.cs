// LtntData.Session.cs b230123.1333
// Session details.

namespace AbatabLieutenant.LtntData
{
    public class Session
    {
        public string DebugMode { get; set; }
        public string LtntVersion { get; set; }
        public string LtntRoot { get; set; }
        public string RequestedBranch { get; set; }
        public string LogFileName { get; set; }
        public string RepositoryUrl { get; set; }
        public string DefaultBranch { get; set; }
        public string TargetBranch { get; set; }
        public Dictionary<string, string> LtntDirs { get; set; }
        public Dictionary<string, string> RepoInfo { get; set; }
        public List<string> ValidArguments { get; set; }
        public List<string> ServiceFiles { get; set; }

        ///// <summary>TBD</summary>
        ///// <returns></returns>
        //public static Session BuildSession()
        //{
        //    Session ltntSession = InitializeDetails();




        //    UpdateDetails(ltntSession.RequestedBranch);

        //    return ltntSession;
        //}

        /// <summary>TBD</summary>
        /// <returns></returns>
        public static Session InitializeSessionDetails() => new Session()
        {
            DebugMode       = Properties.Resources.DebugMode,
            LtntVersion     = Properties.Resources.LtntVersion,
            LtntRoot        = Properties.Resources.LtntRoot,
            RequestedBranch = Properties.Resources.RequestedBranch,
            LogFileName     = $"{DateTime.Now.ToString("yyMMdd_HHmmss")}.ltnt",
            RepositoryUrl   = Properties.Resources.RepositoryUrl,
            DefaultBranch   = Properties.Resources.DefaultBranch,
            LtntDirs        = BuildDirectories(),
            //RepoInfo       = BuildRepoInfo(Properties.Resources.DefaultBranch),
            ValidArguments  = CommandLineArguments(),
            ServiceFiles    = BuildServiceFiles()
        };

        /// <summary>TBD</summary>
        /// <param name="ltntSession"></param>
        /// <returns></returns>
        public static void UpdateSessionDetails(Session ltntSession)
        {
            ltntSession.RequestedBranch = VerifyPassedArgument(ltntSession.RequestedBranch);


        }

        private static string VerifyPassedArgument(string passedArgument)
        {


            return "";
        }


        /// <summary>TBD</summary>
        /// <returns></returns>
        private static Dictionary<string, string> BuildDirectories() => new Dictionary<string, string>
        {
            { "Root", Properties.Resources.LtntRoot },
            { "Logs", $@"{Properties.Resources.LtntRoot}\Logs" },
            { "Temp", $@"{Properties.Resources.LtntRoot}\Temp" },
            { "bin",  $@"{Properties.Resources.LtntRoot}\bin" },
        };

        /// <summary>TBD</summary>
        /// <param name="targetBranch"></param>
        /// <returns></returns>
        private static Dictionary<string, string> BuildRepoInfo(string targetBranch) => new Dictionary<string, string>
        {
                { "Branch", $"{targetBranch}.zip" },
                { "Source", $@"{Properties.Resources.LtntRoot}\temp\{targetBranch}.zip" },
                { "Url",    $"{Properties.Resources.RepositoryUrl}{targetBranch}.zip" }
        };

        /// <summary>TBD</summary>
        /// <returns></returns>
        private static List<string> BuildServiceFiles() => new List<string>
        {
            "Abatab.asmx",
            "Abatab.asmx.cs",
            "packages.config",
            "Web.config",
            "Web.Debug.config",
            "Web.Release.config"
        };

        /// <summary>TBD</summary>
        /// <returns></returns>
        public static List<string> CommandLineArguments() => new List<string>
        {
            "development",
            "experimental",
            "help",
            "main",
            "testing"
        };
    }
}
