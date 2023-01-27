//
//
//

using Abacab;

namespace AbatabLieutenant
{
    /// <summary>TBD</summary>
    public class Framework
    {
        /// <summary>TBD</summary>
        /// <param name="ltntDirectories"></param>
        /// <param name="sessionDateTimeStamp"></param>
        public static void InitializeDeploymentTarget(Dictionary<string, string> ltntDirectories, string sessionDateTimeStamp)
        {
            ValidateRequiredDirectories(ltntDirectories);
            PrepareDeploymentTarget(ltntDirectories, sessionDateTimeStamp);
        }

        /// <summary>TBD</summary>
        /// <param name="ltntDirectories"></param>
        private static void ValidateRequiredDirectories(Dictionary<string, string> ltntDirectories)
        {
            SystemMaintenance.ConfirmDirectoryExists(ltntDirectories["Root"]);
            SystemMaintenance.ConfirmDirectoryExists(ltntDirectories["Logs"]);
        }

        /// <summary>TBD</summary>
        /// <param name="ltntDirectories"></param>
        /// <param name="sessionDateTimeStamp"></param>
        private static void PrepareDeploymentTarget(Dictionary<string, string> ltntDirectories, string sessionDateTimeStamp)
        {
            SystemMaintenance.ConfirmDirectoryExists($@"{ltntDirectories["Deployment"]}");
            SystemMaintenance.ConfirmDirectoryExists($@"{ltntDirectories["Deployment"]}\bin");
        }
    }
}
