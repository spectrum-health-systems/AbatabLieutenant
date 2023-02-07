using System.Collections.Generic;

namespace AbatabLieutenant.StockData
{
    public class VerificationList
    {
        /// <summary>Create a list of valid web service files.</summary>
        /// <returns>A list of files that should be copied when deploying Abatab.</returns>
        public static List<string> ServiceFiles() =>
            new List<string>
            {
                "Abatab.asmx",
                "Abatab.asmx.cs",
                "packages.config",
                "Web.config",
                "Web.Debug.config",
                "Web.Release.config"
            };

        /// <summary>Create a list of valid command line arguments.</summary>
        /// <returns>A list of valid arguments the user can send via the command line.</returns>
        public static List<string> CommandLineArguments() =>
            new List<string>
            {
                "development",
                "experimental",
                "help",
                "main",
                "testing"
            };
    }
}
