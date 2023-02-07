// b---

namespace AbatabLieutenant.Deployment
{
    /// <summary>TBD</summary>
    internal static class Prepare
    {
        /// <summary>TBD</summary>
        /// <param name="directories"></param>
        /// <param name="logFilePath"></param>
        public static void RefreshDirectories(Dictionary<string, string> directories, string logFilePath)
        {
            foreach (var directory in directories)
            {
                OpSys.Maintenance.RefreshDirectory(directory.Value, logFilePath);
            }
        }
    }
}