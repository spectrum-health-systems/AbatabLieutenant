// b---

using AbatabLieutenant.Session;

namespace AbatabLieutenant.Catalog
{
    /// <summary>TBD</summary>
    internal static class LogMessages
    {
        /// <summary>TBD</summary>
        /// <param name="ltntVersion"></param>
        /// <returns></returns>
        public static string LogStart(string ltntVersion) =>
            $"{Environment.NewLine}" +
            $"================={Environment.NewLine}" +
            $"Abatab Lieutenant{Environment.NewLine}" +
            $"==== v{ltntVersion} ====={Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Building session data...";

        /// <summary>TBD</summary>
        /// <param name="ltntSession"></param>
        /// <returns></returns>
        public static string SessionDetails(SessionData ltntSession)
        {
            var sessionDetails = $"---------------{Environment.NewLine}" +
                                 $"Session details{Environment.NewLine}" +
                                 $"---------------{Environment.NewLine}" +
                                 $"Debug mode:             {ltntSession.DebugMode}{Environment.NewLine}" +
                                 $"LtntVersion:            {ltntSession.LtntVersion}{Environment.NewLine}" +
                                 $"LtntRoot:               {ltntSession.LtntRoot}{Environment.NewLine}" +
                                 $"Abatab deployment root: {ltntSession.AbatabDeploymentRoot}{Environment.NewLine}" +
                                 $"Repository URL:         {ltntSession.RepositoryUrl}{Environment.NewLine}" +
                                 $"Requested branch:       {ltntSession.RequestedBranch}{Environment.NewLine}" +
                                 $"Log file name:          {ltntSession.LogFilePath}{Environment.NewLine}" +
                                 $"Session timestamp:      {ltntSession.DateTimeStamp}{Environment.NewLine}" +
                                 $"{Environment.NewLine}" +
                                 $"Session directories {SessionDirectories(ltntSession.LtntDirectories)}{Environment.NewLine}" +
                                 $"Repository details  {RepositoryInformation(ltntSession.RepositoryDetails)}{Environment.NewLine}" +
                                 $"Valid arguments     {ValidArguments(ltntSession.ValidArguments)}{Environment.NewLine}" +
                                 $"Service files       {ServiceFiles(ltntSession.ServiceFiles)}";

            return sessionDetails;
        }

        /// <summary>TBD</summary>
        /// <param name="sessionDirectories"></param>
        /// <returns></returns>
        private static string SessionDirectories(Dictionary<string, string> sessionDirectories)
        {
            var directoryList = $"  {Environment.NewLine}";

            foreach (var sessionDirectory in sessionDirectories)
            {
                directoryList += $"  {sessionDirectory.Key}: {sessionDirectory.Value}{Environment.NewLine}";
            }

            return directoryList;
        }

        /// <summary>TBD</summary>
        /// <param name="sessionRepositoryDetails"></param>
        /// <returns></returns>
        private static string RepositoryInformation(Dictionary<string, string> sessionRepositoryDetails)
        {
            var detailsList = $"  {Environment.NewLine}";

            foreach (var sessionRepositoryDetail in sessionRepositoryDetails)
            {
                detailsList += $"  {sessionRepositoryDetail.Key}: {sessionRepositoryDetail.Value}{Environment.NewLine}";
            }

            return detailsList;
        }

        /// <summary>TBD</summary>
        /// <param name="sessionValidArguments"></param>
        /// <returns></returns>
        private static string ValidArguments(List<string> sessionValidArguments)
        {
            var validArgumentsList = $"  {Environment.NewLine}";

            foreach (var sessionValidArgument in sessionValidArguments)
            {
                validArgumentsList += $"  {sessionValidArgument}{Environment.NewLine}";
            }

            return validArgumentsList;
        }

        /// <summary>TBD</summary>
        /// <param name="sessionServiceFiles"></param>
        /// <returns></returns>
        private static string ServiceFiles(List<string> sessionServiceFiles)
        {
            var SessionServiceFilesList = $"  {Environment.NewLine}";

            foreach (var sessionServiceFile in sessionServiceFiles)
            {
                SessionServiceFilesList += $"  {sessionServiceFile}{Environment.NewLine}";
            }

            return SessionServiceFilesList;
        }
    }
}