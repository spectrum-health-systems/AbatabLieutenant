// b230209.0737

namespace AbatabLieutenant.Deployment
{
    /// <summary>TBD</summary>
    internal static class Prepare
    {
        /// <summary>TBD</summary>
        /// <param name="directories"></param>
        /// <param name="logFilePath"></param>
        public static void Refresh(string stagingDirectory, string abatabDeploymentDirectory, string logFilePath)
        {
            SysOp.Maintenance.RefreshDirectory(stagingDirectory, logFilePath);
            SysOp.Maintenance.RefreshDirectory(abatabDeploymentDirectory, logFilePath);
        }
    }
}