// b---

namespace AbatabLieutenant.Framework
{
    /// <summary>TBD</summary>
    internal static class Components
    {
        ///// <summary>TBD</summary>
        ///// <param name="ltntDirectories"></param>
        public static void VerifyDirectories(Dictionary<string, string> directories, string logFilePath)
        {
            foreach (var directory in directories)
            {
                OpSys.Maintenance.ConfirmDirectoryExists(directory.Value, logFilePath);
            }
        }
    }
}