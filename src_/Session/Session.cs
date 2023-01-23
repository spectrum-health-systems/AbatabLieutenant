using System.Collections.Generic;

namespace AbatabLieutenant.Session
{
    public class Session
    {
        public static string DebugMode { get; set; }
        public static string LtntVersion { get; set; }
        public static string LtntRoot { get; set; }
        public static string PassedArgument { get; set; }
        public static string LogFile { get; set; }
        public static string RepoUrl { get; set; }
        public static string DefaultBranch { get; set; }
        public static string TargetBranch { get; set; }
        public static Dictionary<string, string> LtntDirs { get; set; }
        public static Dictionary<string, string> RepoInfo { get; set; }
    }
}
