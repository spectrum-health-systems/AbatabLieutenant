namespace AbatabLieutenant.Framework
{
    internal class Prepare
    {

        /// <summary>TBD</summary>
        /// <param name="ltntDirectories"></param>
        public static void PrepareDeploymentTarget(Dictionary<string, string> deploymentDirectories, string logFileName)
        {
            var logMsgStart = $"{Environment.NewLine}Preparing deployment target...";

            Logger.LogEvent.ToConsoleAndFile($"{Environment.NewLine}Preparing deployment target...", logFileName);

            foreach (var deploymentDirectory in deploymentDirectories)
            {
                var logMsg = $@"  Verifying {deploymentDirectory.Key} directory: {deploymentDirectory.Value}\...";
                Logger.LogEvent.ToConsoleAndFile($@"  Verifying {deploymentDirectory.Key} directory: {deploymentDirectory.Value}\...", logFileName);

                Maintenance.OS.ConfirmDirectoryExists(deploymentDirectory.Value);
            }
        }
    }
}
