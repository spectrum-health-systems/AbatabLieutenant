// AbatabLieutenant.Utilities.cs
// b---------x
// (c) A Pretty Cool Program

using System.IO.Compression;

namespace AbatabLieutenant
{
    public static class Utilities
    {
        public static void DownloadData(string sourceUrl, string destination, string logFilePath)
        {
            WriteLog($@"Downloading: {sourceUrl}", logFilePath);
            System.Net.WebClient webClient = new();
            webClient.DownloadFile(sourceUrl, destination);
        }

        public static void ExtractBranch(string source, string requestedBranch, string logFilePath)
        {
            WriteLog("Extracting archive...", logFilePath);

            ZipFile.ExtractToDirectory($@"{source}\Abatab-{requestedBranch}.zip", $@"{source}");
        }

        public static void VerifyRequirements(List<string> requiredDirectories, string logFilePath)
        {
            foreach (var requiredDirectory in requiredDirectories)
            {
                WriteLog($@"Verifying: {requiredDirectory}\...", logFilePath);

                if (!Directory.Exists(requiredDirectory))
                {
                    _=Directory.CreateDirectory(requiredDirectory);
                }
            }
        }

        public static void RefreshDirectory(string directory, string logFilePath)
        {
            Utilities.WriteLog("Debug-12", @"C:\AbatabData\Lieutenant\Logs\debug-12.log");

            WriteLog($@"Refreshing: {directory}\...", logFilePath);

            Utilities.WriteLog("Debug-13", @"C:\AbatabData\Lieutenant\Logs\debug-13.log");

            if (Directory.Exists(directory))
            {
                Utilities.WriteLog("Debug-14", @"C:\AbatabData\Lieutenant\Logs\debug-14.log");
                Directory.Delete(directory, true);
            }

            Utilities.WriteLog($"{directory}", @"C:\AbatabData\Lieutenant\Logs\debug-15.log");
            _=Directory.CreateDirectory(directory);
            Utilities.WriteLog("Debug-16", @"C:\AbatabData\Lieutenant\Logs\debug-16.log");
        }

        public static void WriteLog(string content, string filePath)
        {
            Console.WriteLine(content);
            File.AppendAllText(filePath, $"{content}{Environment.NewLine}");
        }

        public static void CopyDir(string source, string target, string logFilePath)
        {
            RefreshDirectory(target, logFilePath);

            DirectoryInfo dirToCopy       = new DirectoryInfo(source);
            DirectoryInfo[] subDirsToCopy = GetSubDirs(source, target);

            foreach (FileInfo file in dirToCopy.GetFiles())
            {
                WriteLog($"Copying {file.FullName}...", logFilePath);

                string targetPath = Path.Combine(target, file.Name);

                _=file.CopyTo(targetPath);
            }

            foreach (var (subDir, newTargetDir) in from DirectoryInfo subDir in subDirsToCopy
                                                   let newTargetDir = Path.Combine(target, subDir.Name)
                                                   select (subDir, newTargetDir))
            {
                CopyDir(subDir.FullName, newTargetDir, logFilePath);
            }
        }

        public static void CopyService(string source, string target, List<string> serviceFiles, string logFilePath)
        {
            foreach (string file in serviceFiles)
            {
                //if (File.Exists($@"{target}\{file}"))
                //    File.Delete($@"{target}\{file}");

                //Logger.LogEvent.ToFile($@"Copying {source} to {target}...", logFilePath);

                File.Copy($@"{source}\{file}", $@"{target}\{file}");
            }
        }

        private static DirectoryInfo[] GetSubDirs(string source, string target)
        {
            DirectoryInfo dir = new DirectoryInfo(source);

            if (!dir.Exists)
            {
                _=Directory.CreateDirectory(target);

            }

            return dir.GetDirectories();
        }
    }
}
