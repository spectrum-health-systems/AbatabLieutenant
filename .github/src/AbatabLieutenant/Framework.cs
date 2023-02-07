// AbatabLieutenant.Framework.cs
// Catalog for logging.
// b---

namespace AbatabLieutenant
{
    /// <summary>TBD</summary>
    public class Framework
    {
        /// <summary>TBD</summary>
        /// <param name="ltntDirectories"></param>
        /// <param name="sessionDateTimeStamp"></param>
        public static void Initialize(Dictionary<string, string> ltntDirectories, string abatabDeploymentRoot, Dictionary<string, string> deploymentDirectories, string logFileName)
        {
            VerifyLtntDirectories(ltntDirectories, logFileName);
            VerifyDeploymentDirectory(abatabDeploymentRoot, logFileName);
            PrepareDeploymentTarget(deploymentDirectories, logFileName);
        }

        /// <summary>TBD</summary>
        /// <param name="ltntDirectories"></param>
        public static void VerifyLtntDirectories(Dictionary<string, string> ltntDirectories, string logFileName)
        {
            Logger.LogEvent($"Verifying Abatab Lieutenant directories...", logFileName);

            foreach (var ltntDirectory in ltntDirectories)
            {
                Logger.LogEvent($@"  Verifying {ltntDirectory.Key} directory: {ltntDirectory.Value}\...", logFileName);

                Maintenance.OS.ConfirmDirectoryExists(ltntDirectory.Value);
            }
        }

        public static void VerifyDeploymentDirectory(string abatabDeploymentRoot, string logFileName)
        {
            //var logMsg = $"{Environment.NewLine}Verifying Abatab deployment root: {abatabDeploymentRoot}...";
            //ltntSession.LogFileContents += $"{logMsg}{Environment.NewLine}";
            Logger.LogEvent($"{Environment.NewLine}Verifying Abatab deployment root: {abatabDeploymentRoot}...", logFileName);

            Maintenance.OS.ConfirmDirectoryExists(abatabDeploymentRoot);
        }


        /// <summary>TBD</summary>
        /// <param name="ltntDirectories"></param>
        public static void PrepareDeploymentTarget(Dictionary<string, string> deploymentDirectories, string logFileName)
        {
            var logMsgStart = $"{Environment.NewLine}Preparing deployment target...";

            Logger.LogEvent($"{Environment.NewLine}Preparing deployment target...", logFileName);

            foreach (var deploymentDirectory in deploymentDirectories)
            {
                var logMsg = $@"  Verifying {deploymentDirectory.Key} directory: {deploymentDirectory.Value}\...";
                Logger.LogEvent($@"  Verifying {deploymentDirectory.Key} directory: {deploymentDirectory.Value}\...", logFileName);

                Maintenance.OS.ConfirmDirectoryExists(deploymentDirectory.Value);
            }
        }
    }
}