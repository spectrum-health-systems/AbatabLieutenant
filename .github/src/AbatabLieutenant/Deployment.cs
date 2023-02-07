// AbatabLieutenant.Deploy.cs
// Abatab branch deployment logic.
// b---

namespace AbatabLieutenant
{
    /// <summary>TBD</summary>
    internal class Deployment
    {
        public static void PrepareTarget(string abatabDeploymentRoot, string logFileName)
        {
            var logMsg = $"{Environment.NewLine}" +
                         $"Preparing for deployment...Removing dir..." +
                         $"{Environment.NewLine}";

            Logger.LogEvent(logMsg, logFileName);

            Maintenance.OS.RefreshDirectory(abatabDeploymentRoot);
        }



















        /// <summary>TBD</summary>
        /// <param name="ltntSession"></param>
        private static void DownloadExperimentalBranch(string requestedBranch)
        {
            Console.WriteLine("Ex");
        }

        /// <summary>TBD</summary>
        /// <param name="ltntSession"></param>
        private static void DownloadMainBranch(string requestedBranch)
        {
            Console.WriteLine("M");
        }

        /// <summary>TBD</summary>
        /// <param name="ltntSession"></param>
        private static void DownloadTestingBranch(string requestedBranch)
        {
            Console.WriteLine("Test");
        }



    }
}
