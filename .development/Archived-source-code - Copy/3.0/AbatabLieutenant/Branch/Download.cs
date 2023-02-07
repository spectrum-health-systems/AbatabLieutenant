namespace AbatabLieutenant.Branch
{
    public class Download
    {
        /// <summary>TBD</summary>
        /// <param name="ltntSession"></param>
        public static void FromUrl(string branchUrl, string stagingDirectory, string requestedBranch, string logFileName)
        {
            var logMsg = $"{Environment.NewLine}" +
                         $"Downloading {branchUrl}..." +
                         $"{Environment.NewLine}";

            Logger.LogEvent(logMsg, logFileName);

            InterWeb.DownloadFromUrl(branchUrl, $@"{stagingDirectory}\Abatab-{requestedBranch}.zip");
        }
    }
}