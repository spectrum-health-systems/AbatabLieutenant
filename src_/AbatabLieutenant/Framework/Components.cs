// b230209.0737

namespace AbatabLieutenant.Framework
{
    /// <summary>Various logic dealing with the Abatab framework.</summary>
    internal static class Components
    {
        /// <summary>Initialize the Abatab framework.</summary>
        /// <param name="directories">The list of directories to initialize.</param>
        /// <param name="logFile">The log file.</param>
        public static void Initialize(Dictionary<string, string> directories, string logFile)
        {
            VerifyDirectories(directories, logFile);
        }

        /// <summary>Verify the required directories exist.</summary>
        /// <param name="ltntDirectories">The list of required directories.</param>
        public static void VerifyDirectories(Dictionary<string, string> directories, string logFile)
        {
            foreach (var directory in directories)
            {
                SysOp.Maintenance.ConfirmDirectoryExists(directory.Value, logFile);
            }
        }
    }
}