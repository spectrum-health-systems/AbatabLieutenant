// AbatabLieutenant.Deploy.cs
// b230307.1753
// (c) A Pretty Cool Program

namespace AbatabLieutenant
{
    /// <summary>Summary</summary>
    internal class Deploy
    {
        /// <summary>Summary</summary>
        /// <param name="ltSession"></param>
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

        /// <summary>Summary</summary>
        /// <param name="stagingRoot"></param>
        /// <param name="serviceRoot"></param>
        /// <param name="logPath"></param>
        private static void RefeshDirectories(string stagingRoot, string serviceRoot, string logPath)
        {
            Utilities.RefreshDirectory(stagingRoot, logPath);
            Utilities.RefreshDirectory(serviceRoot, logPath);
        }

        /// <summary>Summary</summary>
        /// <param name="url"></param>
        /// <param name="staging"></param>
        /// <param name="branch"></param>
        /// <param name="target"></param>
        /// <param name="serviceFiles"></param>
        /// <param name="logPath"></param>
        private static void FullDeployment(string url, string staging, string branch, string target, List<string> serviceFiles, string logPath)
        {
            Utilities.DownloadZip($@"{url}{branch}.zip", $@"{staging}\Abatab-{branch}.zip", logPath);

            Utilities.ExtractBranch($@"{staging}\Abatab-{branch}.zip", staging, logPath);

            Utilities.CopyDir($@"{staging}\Abatab-{branch}\src\bin", $@"{target}\bin", logPath);

            Utilities.CopyService($@"{staging}\Abatab-{branch}\src\", target, serviceFiles, logPath);
        }

        /// <summary>Summary</summary>
        /// <param name="ltSession"></param>
        private static void MinimalDeployment(LtSession ltSession)
        {
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