// b230208.1510

using AbatabLieutenant.Session;

namespace AbatabLieutenant.Catalog
{
    /// <summary>Data related to the command line.</summary>
    internal static class CommandLine
    {
        /// <summary>Builds a list of valid command line arguments.</summary>
        /// <returns>A list of valid command line arguments.</returns>
        public static List<string> ValidArguments()
        {
            var validArguments = new List<string>()
            {
                "development",
                "main",
                "testing",
                SessionData.AddCustomBranch()
            };

            return validArguments;
        }
    }
}