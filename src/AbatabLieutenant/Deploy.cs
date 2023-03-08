// AbatabLieutenant.Deploy.cs
// b230308.0939
// (c) A Pretty Cool Program

namespace AbatabLieutenant
{
    /// <summary>Abatab branch deployment logic.</summary>
    internal class Deploy
    {
        /// <summary>Logic to deploy an Abatab branch starts here.</summary>
        /// <param name="ltSession">The session object.</param>
        public static void WebService(LtSession ltSession)
        {
            RefeshDirectories(ltSession.StagingRoot, ltSession.AbServiceRoot, ltSession.LogPath);

            if (ltSession.Option == "min")
            {
                MinimalDeployment(ltSession);
            }
            else
            {
                FullDeployment(ltSession.AbRepoZipUrl, ltSession.StagingRoot, ltSession.RequestedBranch, ltSession.AbServiceRoot, ltSession.ServiceFiles, ltSession.LogPath);
            }
        }

        /// <summary>Refreshes directories used during deployment.</summary>
        /// <param name="stagingRoot">The location of Abatab branch staging files.</param>
        /// <param name="serviceRoot">The location of Abatab web service.</param>
        /// <param name="logPath">The path to the log file.</param>
        private static void RefeshDirectories(string stagingRoot, string serviceRoot, string logPath)
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
        private static void FullDeployment(string url, string stagingDir, string branch, string serviceDir, List<string> serviceFiles, string logPath)
        {
            Utilities.DownloadZip($@"{url}{branch}.zip", $@"{stagingDir}\Abatab-{branch}.zip", logPath);

            Utilities.ExtractBranch($@"{stagingDir}\Abatab-{branch}.zip", stagingDir, logPath);

            Utilities.CopyDir($@"{stagingDir}\Abatab-{branch}\src\bin", $@"{serviceDir}\bin", logPath);

            Utilities.CopyService($@"{stagingDir}\Abatab-{branch}\src\", serviceDir, serviceFiles, logPath);
        }

        /// <summary>Completes a minimal deployment of an Abatab branch (EXPERIMENTAL!)</summary>
        /// <param name="ltSession">The session object.</param>
        /// <remarks>This is experimental functionality, and shouldn't be used!</remarks>
        private static void MinimalDeployment(LtSession ltSession)
        {
            /* THIS FUNCTIONALITY IS EXPERIMENTAL! DON'T USE IT!
            *
            * I'm only leaving it here so I can test it, and maybe make it part of Abatab Lieutenant v4.1
            */
            foreach (var item in ltSession.ServiceFiles)
            {
                Utilities.DownloadFile($"{ltSession.RequestedBranchRawUrl}{item}", $@"{ltSession.AbServiceRoot}\{item}", ltSession.LogPath);
            }

            Directory.CreateDirectory($@"{ltSession.AbServiceRoot}\bin\roslyn");

            foreach (var item in ltSession.ServiceBinFiles)
            {
                Utilities.DownloadFile($"{ltSession.RequestedBranchRawUrl}{item}", $@"{ltSession.AbServiceRoot}\{item}", ltSession.LogPath);
            }

            foreach (var item in ltSession.ServiceRoslynFiles)
            {
                Utilities.DownloadFile($"{ltSession.RequestedBranchRawUrl}{item}", $@"{ltSession.AbServiceRoot}\{item}", ltSession.LogPath);
            }
        }
    }
}