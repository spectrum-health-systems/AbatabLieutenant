// AbatabLieutenant.Catalog.cs
// The Catalog class contains pre-created data lists/strings.
// b---

namespace AbatabLieutenant.Data
{
    public partial class Catalog_old
    {
        /// <summary>TBD</summary>
        /// <returns></returns>
        public static List<string> ValidArguments() => new()
        {
            "development",
            "experimental",
            "main",
            "testing"
        };

        /// <summary>TBD</summary>
        /// <returns></returns>
        public static Dictionary<string, string> DeploymentDirectories(string ltntRoot, string dateTimeStamp) => new Dictionary<string, string>
        {
            { "Root",       $@"{ltntRoot}" },
            { "Logs",       $@"{ltntRoot}\Logs" },
            { "Deployment", $@"{ltntRoot}\Deployment\{dateTimeStamp}" },
            //{ "bin",        $@"{ltntRoot}\{dateTimeStamp}\bin" },
        };

        /// <summary>TBD</summary>
        /// <returns></returns>
        public static List<string> ServiceFiles() => new List<string>
        {
            "Abatab.asmx",
            "Abatab.asmx.cs",
            "packages.config",
            "Web.config",
            "Web.Debug.config",
            "Web.Release.config"
        };

        /// <summary>TBD</summary>
        /// <param name="requestedBranch"></param>
        /// <returns></returns>
        public static Dictionary<string, string> RepositoryInformation(string requestedBranch, string ltntRoot, string repositoryUrl) => new Dictionary<string, string>
        {
                { "Branch", $"{requestedBranch}.zip" },
                { "Source", $@"{Properties.Resources.LtntRoot}\temp\{requestedBranch}.zip" },
                { "Url",    $"{Properties.Resources.RepositoryUrl}{requestedBranch}.zip" }
        };


        //public static string HelpMsg(string ltntVersion) =>
        //    $"{System.Environment.NewLine}" +
        //    $"======================{System.Environment.NewLine}" +
        //    $"Abatab Lieutenant Help{System.Environment.NewLine}" +
        //    $"======= v{ltntVersion} =======Environment.NewLine}}" +
        //    $"{System.Environment.NewLine}" +
        //    $"Syntax:{System.Environment.NewLine}" +
        //    $"{System.Environment.NewLine}" +
        //    $"{System.Environment.NewLine}" +
        //    $"    $ AbatabLieutenant <command>{System.Environment.NewLine}" +
        //    $"{System.Environment.NewLine}" +
        //    $"{System.Environment.NewLine}" +
        //    $"Valid commands:{System.Environment.NewLine}" +
        //    $"{System.Environment.NewLine}" +
        //    $"     development - Deploy the Abatab development branch{System.Environment.NewLine}" +
        //    $"    experimental - Deploy the Abatab experimental branch{System.Environment.NewLine}" +
        //    $"            main - Deploy the Abatab main branch{System.Environment.NewLine}" +
        //    $"         testing - Deploy the Abatab testing branch{System.Environment.NewLine}" +
        //    $"{System.Environment.NewLine}" +
        //    $"{System.Environment.NewLine}" +
        //    $"Example:{System.Environment.NewLine}" +
        //    $"{System.Environment.NewLine}" +
        //    $"{System.Environment.NewLine}" +
        //    $"    $ AbatabLieutenant.exe development  <- Deploys the development branch of Abatab{System.Environment.NewLine}" +
        //    $"{System.Environment.NewLine}" +
        //    $"    $ AbatabLieutenant.exe experimental <- Deploys the experimental branch of Abatab{System.Environment.NewLine}" +
        //    $"{System.Environment.NewLine}";
    }
}
