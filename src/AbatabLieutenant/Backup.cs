//
//
//

using System.IO.Compression;

namespace AbatabLieutenant
{
    public class Backup
    {
        public static void CurrentDeployment(string source, string target, string logFilePath)
        {
            var logMsg = $"{Environment.NewLine}" +
                         $"Backing up current Abatab deployment..." +
                         $"{Environment.NewLine}";

            Logger.LogEvent(logMsg, logFilePath);

            ZipFile.CreateFromDirectory(source, $@"{target}\previous-deployment.zip");
        }
    }
}
