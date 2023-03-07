// b230209.0737

using AbatabLieutenant.Session;

namespace AbatabLieutenant.Catalog
{
    /// <summary>Data related to logging functionality.</summary>
    internal static class Logger
    {
        /// <summary>Build the log start message.</summary>
        /// <param name="ltntSession">The Session data</param>
        /// <returns>A startup message for the log.</returns>
        public static string MsgLogStart(SessionData ltntSession) =>
            $"{Environment.NewLine}" +
            $"================={Environment.NewLine}" +
            $"Abatab Lieutenant{Environment.NewLine}" +
            $"==== v{ltntSession.LtntVersion} ====={Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{MsgSessionDetails(ltntSession)}{Environment.NewLine}" +
            $"Building session data...";

        /// <summary>Build session details.</summary>
        /// <param name="ltntSession">The Session data</param>
        /// <returns>Session details for the logfile.</returns>
        private static string MsgSessionDetails(SessionData ltntSession)
        {
            var sessionDetails = $"---------------{Environment.NewLine}" +
                                 $"Session details{Environment.NewLine}" +
                                 $"---------------{Environment.NewLine}" +
                                 $"LtntVersion:            {ltntSession.LtntVersion}{Environment.NewLine}" +
                                 $"LtntRoot:               {ltntSession.LtntRoot}{Environment.NewLine}" +
                                 $"Abatab deployment root: {ltntSession.AbatabDeploymentRoot}{Environment.NewLine}" +
                                 $"Repository URL:         {ltntSession.RepositoryUrl}{Environment.NewLine}" +
                                 $"Requested branch:       {ltntSession.RequestedBranch}{Environment.NewLine}" +
                                 $"Log file name:          {ltntSession.LogFilePath}{Environment.NewLine}" +
                                 $"Session timestamp:      {ltntSession.DateTimeStamp}{Environment.NewLine}" +
                                 $"{Environment.NewLine}" +
                                 $"Required directories {MsgSessionDirectories(ltntSession.LtntDirectories)}{Environment.NewLine}" +
                                 //$"Repository details  {MsgRepositoryInformation(ltntSession.RepositoryDetails)}{Environment.NewLine}" +
                                 $"Valid arguments     {MsgValidArguments(ltntSession.ValidArguments)}{Environment.NewLine}" +
                                 $"Service files       {ServiceFiles(ltntSession.ServiceFiles)}";

            return sessionDetails;
        }

        /// <summary>Abatab Lieutenant directory information for the logfile.</summary>
        /// <param name="sessionDirectories"></param>
        /// <returns></returns>
        private static string MsgSessionDirectories(Dictionary<string, string> sessionDirectories)
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
        private static string MsgRepositoryInformation(Dictionary<string, string> sessionRepositoryDetails)
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
        private static string MsgValidArguments(List<string> sessionValidArguments)
        {
            var validArgumentsList = $"  {Environment.NewLine}";

            Console.WriteLine("TEST");

            foreach (var sessionValidArgument in sessionValidArguments)
            {
                Console.WriteLine(sessionValidArgument);
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