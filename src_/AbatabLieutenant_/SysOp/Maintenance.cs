// b230209.0737

using AbatabLieutenant.Logger;
namespace AbatabLieutenant.SysOp
{
    internal static class Maintenance
    {
        /// <summary>TBD</summary>
        /// <param name="directory"></param>
        public static void ConfirmDirectoryExists(string directory, string logFilePath)
        {
            if (!Directory.Exists(directory))
            {
                _=Directory.CreateDirectory(directory);
            }

            LogEvent.ToFile($@"Verifying: {directory}\...", logFilePath);
        }

        /// <summary>TBD</summary>
        /// <param name="directory"></param>
        public static void RefreshDirectory(string directory, string logFilePath)
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
            }

            _=Directory.CreateDirectory(directory);

            LogEvent.ToFile($@"Refreshing: {directory}\...", logFilePath);
        }
    }
}