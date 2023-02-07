// AbatabLieutenant.Data.Catalog.Log.cs
// Catalog for logging.
// b---

using AbatabLieutenant.Session;

namespace AbatabLieutenant.Data.Catalog
{
    public class Log
    {
        public static string LtntStartMessage(string ltntVersion) =>
            $"{Environment.NewLine}" +
            $"=========================={Environment.NewLine}" +
            $"Starting Abatab Lieutenant{Environment.NewLine}" +
            $"========= v{ltntVersion} ========={Environment.NewLine}";

        public static string LtntSessionDetails(SessionData ltntSession)
        {
            var sessionDetails = $"---------------{Environment.NewLine}" +
                                 $"Session details{Environment.NewLine}" +
                                 $"---------------{Environment.NewLine}" +
                                 $"Debug mode:         {ltntSession.DebugMode}{Environment.NewLine}" +
                                 $"LtntVersion:            {ltntSession.LtntVersion}{Environment.NewLine}" +
                                 $"LtntRoot:               {ltntSession.LtntRoot}{Environment.NewLine}" +
                                 $"Abatab deployment root:               {ltntSession.AbatabDeploymentRoot}{Environment.NewLine}" +
                                 $"Repository URL:     {ltntSession.RepositoryUrl}{Environment.NewLine}" +
                                 $"Requested branch:   {ltntSession.RequestedBranch}{Environment.NewLine}" +
                                 $"Log file name:      {ltntSession.LogFileName}{Environment.NewLine}" +
                                 $"Session timestamp:  {ltntSession.TimeStamp}{Environment.NewLine}" +
                                 $"{Environment.NewLine}" +
                                 $"Session directories {SessionLtntDirectories(ltntSession.LtntDirectories)}{Environment.NewLine}" +
                                 $"Repository details  {SessionRepositoryInformation(ltntSession.RepositoryDetails)}{Environment.NewLine}" +
                                 $"Valid arguments     {SessionValidArguments(ltntSession.ValidArguments)}{Environment.NewLine}" +
                                 $"Service files       {SessionServiceFiles(ltntSession.ServiceFiles)}";

            return sessionDetails;
        }

        /// <summary>TBD</summary>
        /// <param name="sessionDirectories"></param>
        /// <returns></returns>
        private static string SessionLtntDirectories(Dictionary<string, string> sessionDirectories)
        {
            var directoryList = $"  {Environment.NewLine}";

            foreach (var sessionDirectory in sessionDirectories)
            {
                directoryList += $@"  {sessionDirectory.Key}: {sessionDirectory.Value}{Environment.NewLine}";
            }

            return directoryList;

        }

        /// <summary>TBD</summary>
        /// <param name="sessionRepositoryDetails"></param>
        /// <returns></returns>
        private static string SessionRepositoryInformation(Dictionary<string, string> sessionRepositoryDetails)
        {
            var detailsList = $"  {Environment.NewLine}";

            foreach (var sessionRepositoryDetail in sessionRepositoryDetails)
            {
                detailsList += $@"  {sessionRepositoryDetail.Key}: {sessionRepositoryDetail.Value}{Environment.NewLine}";
            }

            return detailsList;

        }

        /// <summary>TBD</summary>
        /// <param name="sessionValidArguments"></param>
        /// <returns></returns>
        private static string SessionValidArguments(List<string> sessionValidArguments)
        {
            var validArgumentsList = $"  {Environment.NewLine}";

            foreach (var sessionValidArgument in sessionValidArguments)
            {
                validArgumentsList += $"  {sessionValidArgument}{Environment.NewLine}";
            }

            return validArgumentsList;

        }

        private static string SessionServiceFiles(List<string> sessionServiceFiles)
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