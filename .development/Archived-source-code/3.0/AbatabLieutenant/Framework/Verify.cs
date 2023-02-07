using AbatabLieutenant.Session;

namespace AbatabLieutenant.Framework
{
    internal class Verify
    {

        public static void Components(SessionData ltntSession)
        {
            Directories(ltntSession.LtntDirectories, ltntSession.LogFileName);
            Directories(ltntSession.DeploymentDirectories, ltntSession.LogFileName);
        }

        /// <summary>TBD</summary>
        /// <param name="ltntDirectories"></param>
        private static void Directories(Dictionary<string, string> directories, string logFileName)
        {
            Logger.LogEvent.ToConsoleAndFile($"Verifying directories...", logFileName);

            foreach (var directory in directories)
            {
                Logger.LogEvent.ToConsoleAndFile($@"  Verifying {directory.Key} directory: {directory.Value}\...", logFileName);

                Maintenance.OS.ConfirmDirectoryExists(directory.Value);
            }
        }

        private static void DeploymentDirectory(string abatabDeploymentRoot, string logFileName)
        {
            //var logMsg = $"{Environment.NewLine}Verifying Abatab deployment root: {abatabDeploymentRoot}...";
            //ltntSession.LogFileContents += $"{logMsg}{Environment.NewLine}";
            Logger.LogEvent.ToConsoleAndFile($"{Environment.NewLine}Verifying Abatab deployment root: {abatabDeploymentRoot}...", logFileName);

            Maintenance.OS.ConfirmDirectoryExists(abatabDeploymentRoot);
        }
    }
}
