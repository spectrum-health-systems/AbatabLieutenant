// b230209.0737

namespace AbatabLieutenant.Catalog
{
    /// <summary>Data related to the Abatab Lieutenant framework.</summary>
    internal static class Framework
    {
        /// <summary>Builds a list of required by Abatab Lieutenant directories.</summary>
        /// <returns>A list of required Abatab Lieutenant directories.</returns>
        public static Dictionary<string, string> LtntDirectories(string ltntRoot) => new()
        {
            { "Root",             $"{ltntRoot}" },
            { "Logs",             $@"{ltntRoot}\Logs" },
            { "Staging",          $@"{ltntRoot}\Staging" },
        };

        /// <summary>Builds a list of the required Abatab web service files.</summary>
        /// <returns>A list of the required web service files.</returns>
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