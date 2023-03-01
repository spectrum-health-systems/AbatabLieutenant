using System.IO.Compression;

namespace AbatabLieutenant
{
    public static class Compressor
    {
        public static void ExtractBranch(string source, string requestedBranch, string logFilePath)
        {
            var logMsg = $"{Environment.NewLine}" +
                         $"Extracting archive..." +
                         $"{Environment.NewLine}";

            //LogEvent.ToFile(logMsg, logFilePath);

            ZipFile.ExtractToDirectory($@"{source}\Abatab-{requestedBranch}.zip", $@"{source}");
        }
    }
}
