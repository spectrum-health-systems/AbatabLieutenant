//
//
//

using AbatabLieutenant.Session;

using System.IO.Compression;

namespace AbatabLieutenant.Backup
{
    /// <summary>TBD</summary>
    internal class Deployment
    {
        /// <summary>TBD</summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="logFilePath"></param>
        public static void Current(SessionData ltntSession)
        {
            var logMsg = $"{Environment.NewLine}" +
                         $"Backing up current Abatab deployment..." +
                         $"{Environment.NewLine}";

            Logger.LogEvent.ToConsoleAndFile(logMsg, ltntSession.LogFileName);

            ZipFile.CreateFromDirectory(ltntSession.LtntDirectories["Current"], $@"{ltntSession.LtntDirectories["Archive"]}\{ltntSession.DateTimeStamp}.zip");
        }
    }
}
