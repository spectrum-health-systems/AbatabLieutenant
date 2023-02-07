// b---

using AbatabLieutenant.Session;

namespace AbatabLieutenant.Deployment
{
    /// <summary>TBD</summary>
    internal class Backup
    {
        /// <summary>TBD</summary>
        /// <param name="ltntSession"></param>
        public static void Current(SessionData ltntSession)
        {
            //var logMsg = $"{Environment.NewLine}" +
            //             $"Backing up current Abatab deployment..." +
            //             $"{Environment.NewLine}";

            //Logger.LogEvent.ToConsoleAndFile(logMsg, ltntSession.LogFilePath);

            //ZipFile.CreateFromDirectory(ltntSession.LtntDirectories["Deployment"], $@"{ltntSession.LtntDirectories["Archive"]}\{ltntSession.DateTimeStamp}.zip");
        }

    }
}
