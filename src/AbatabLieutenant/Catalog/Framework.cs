// b230208.0924

namespace AbatabLieutenant.Catalog
{
    internal static class Framework
    {
        /// <summary>TBD</summary>
        /// <returns></returns>
        public static Dictionary<string, string> LtntDirectories(string ltntRoot) => new()
        {
            { "Root",       $"{ltntRoot}" },
            { "Logs",       $@"{ltntRoot}\Logs" },
        };

        /// <summary>TBD</summary>
        /// <returns></returns>
        public static Dictionary<string, string> SessionDirectories(string ltntRoot, string abatabDeploymentRoot) => new()
        {
            { "Deployment", $"{abatabDeploymentRoot}" },
            { "Staging",    $@"{ltntRoot}\Staging" },
            { "Temp",       $@"{ltntRoot}\Temp" },
        };

        /// <summary>TBD</summary>
        /// <returns></returns>
        public static List<string> ServiceFiles() => new()
        {
            "Abatab.asmx",
            "Abatab.asmx.cs",
            "packages.config",
            "Web.config",
            "Web.Debug.config",
            "Web.Release.config"
        };
    }
}
