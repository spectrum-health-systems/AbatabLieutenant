

using AbatabLieutenant.Logger;

using System.IO.Compression;

namespace AbatabLieutenant.Compressioner
{
    internal class Extractor
    {
        /// <summary>TBD</summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="logFilePath"></param>
        public static void BranchArchive(string source, string target, string logFilePath)
        {
            var logMsg = $"{Environment.NewLine}" +
                         $"Extracting archive..." +
                         $"{Environment.NewLine}";

            LogEvent.ToFile(logMsg, logFilePath);

            ZipFile.ExtractToDirectory(source, $@"{target}\");
        }
    }
}
