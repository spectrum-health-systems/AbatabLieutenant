// b230516.0955

namespace AbatabLieutenant
{
    /// <summary>Abatab branch deployment logic.</summary>
    internal class Deploy
    {
        /// <summary>Logic to deploy an Abatab branch starts here.</summary>
        /// <param name="ltSession">The session object.</param>
        public static void WebService(LtSession ltSession)
        {
            RefreshDirectories(ltSession.StagingRoot, ltSession.AbServiceRoot, ltSession.LogPath);

            DeployService(ltSession.AbRepoZipUrl, ltSession.StagingRoot, ltSession.RequestedBranch, ltSession.AbServiceRoot, ltSession.ServiceFiles, ltSession.LogPath);

        }

        /// <summary>Refreshes directories used during deployment.</summary>
        /// <param name="stagingRoot">The location of Abatab branch staging files.</param>
        /// <param name="serviceRoot">The location of Abatab web service.</param>
        /// <param name="logPath">The path to the log file.</param>
        private static void RefreshDirectories(string stagingRoot, string serviceRoot, string logPath)
        {
            Utilities.RefreshDirectory(stagingRoot, logPath);

            Utilities.RefreshDirectory(serviceRoot, logPath);
        }

        /// <summary>Completes a full deployment of an Abatab branch.</summary>
        /// <param name="url">The base repository URL for the Abatab branch.</param>
        /// <param name="stagingDir">The location of Abatab branch staging files.</param>
        /// <param name="branch">The requested branch<param>
        /// <param name="serviceDir">The location of Abatab web service.</param>
        /// <param name="serviceFiles">The list of required web service files.</param>
        /// <param name="logPath">The path to the log file.</param>
        private static void DeployService(string url, string stagingDir, string branch, string serviceDir, List<string> serviceFiles, string logPath)
        {
            Utilities.DownloadZip($@"{url}{branch}.zip", $@"{stagingDir}\Abatab-{branch}.zip", logPath);

            Utilities.ExtractBranch($@"{stagingDir}\Abatab-{branch}.zip", stagingDir, logPath);

            Utilities.CopyDir($@"{stagingDir}\Abatab-{branch}\src\bin", $@"{serviceDir}\bin", logPath);

            Utilities.CopyService($@"{stagingDir}\Abatab-{branch}\src\", serviceDir, serviceFiles, logPath);
        }
    }
}