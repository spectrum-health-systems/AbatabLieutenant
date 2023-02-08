// b230208.0924

namespace AbatabLieutenant.Deployment
{
    /// <summary>TBD</summary>
    internal static class Download
    {
        /// <summary>TBD</summary>
        /// <param name="ltntSession"></param>
        public static void FromUrl(string requestedBranch, string branchUrl, string tempDirectory, string logFileName)
        {
            var logMsg = $"{Environment.NewLine}" +
                         $"Downloading {requestedBranch} branch from{Environment.NewLine} +" +
                         $"  {branchUrl}..." +
                         $"{Environment.NewLine}";

            Logger.LogEvent.ToFile(logMsg, logFileName);

            InterWeb.Downloader.FromUrl(branchUrl, $"{tempDirectory}/Abatab-{requestedBranch}.zip");
        }
    }
}