// b230516.0955

using System.IO.Compression;

namespace AbatabLieutenant
{
    /// <summary>Various Abatab Lieutenant utilities.</summary>
    public static class Utilities
    {
        /// <summary>Download a .zip archive.</summary>
        /// <param name="url">The URL of the .zip archive.</param>
        /// <param name="target">The target download location.</param>
        /// <param name="logPath">The path to the log file.</param>
        public static void DownloadZip(string url, string target, string logPath)
        {
            WriteLog($"{Environment.NewLine}Downloading .ZIP: {url} = TO => {target}", logPath);

            System.Net.WebClient webClient = new();
            webClient.DownloadFile(url, target);
        }

        /// <summary>Download a file.</summary>
        /// <param name="url">The URL of the file.</param>
        /// <param name="target">The target download location.</param>
        /// <param name="logPath">The path to the log file.</param>
        public static void DownloadFile(string url, string target, string logPath)
        {
            WriteLog($"Downloading file: {url} - TO -> {target}", logPath);

            System.Net.WebClient webClient = new();
            webClient.DownloadFile(url, target);
        }

        /// <summary>Extract a .zip archive.</summary>
        /// <param name="source">The path to the .zip archive</param>
        /// <param name="target">The target extraction location.</param>
        /// <param name="logPath">The path to the log file.</param>
        public static void ExtractBranch(string source, string target, string logPath)
        {
            WriteLog($"{Environment.NewLine}Extracting archive...", logPath);

            ZipFile.ExtractToDirectory(source, target);
        }

        /// <summary>Verify Abatab Lieutenant framework components</summary>
        /// <param name="requiredDirectories">The list of Abatab Lieutenant required directories."</param>
        /// <param name="logPath">The path to the log file.</param>
        public static void VerifyFramework(List<string> requiredDirectories, string logPath)
        {
            foreach (var requiredDirectory in requiredDirectories)
            {
                WriteLog($@"Verifying: {requiredDirectory}\...", logPath);

                if (!Directory.Exists(requiredDirectory))
                {
                    _=Directory.CreateDirectory(requiredDirectory);
                }
            }
        }

        /// <summary>Refresh a directory.</summary>
        /// <param name="directory">The directory to refresh.</param>
        /// <param name="logPath">The path to the log file.</param>
        public static void RefreshDirectory(string directory, string logPath)
        {
            WriteLog($@"Refreshing: {directory}\...", logPath);

            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
            }

            _=Directory.CreateDirectory(directory);
        }

        /// <summary>Write a log file, and display the contents on screen.</summary>
        /// <param name="content">The content to write/display.</param>
        /// <param name="logPath">The path to the log file.</param>
        public static void WriteLog(string content, string filePath)
        {
            Console.WriteLine(content);
            File.AppendAllText(filePath, $"{content}{Environment.NewLine}");
        }

        /// <summary>Copy a directory.</summary>
        /// <param name="source">The directory to copy from.</param>
        /// <param name="target">The directory to copy to. </param>
        /// <param name="logPath">The path to the log file.</param>
        public static void CopyDir(string source, string target, string logPath)
        {
            WriteLog(Environment.NewLine, logPath);
            RefreshDirectory(target, logPath);

            DirectoryInfo dirToCopy       = new DirectoryInfo(source);
            DirectoryInfo[] subDirsToCopy = GetSubDirs(source, target);

            foreach (FileInfo file in dirToCopy.GetFiles())
            {
                WriteLog($"Copying {file.FullName}...", logPath);
                _=file.CopyTo(Path.Combine(target, file.Name));
            }

            foreach (var (subDir, newTargetDir) in from DirectoryInfo subDir in subDirsToCopy
                                                   let newTargetDir = Path.Combine(target, subDir.Name)
                                                   select (subDir, newTargetDir))
            {
                WriteLog($@"Copying {subDir}\...", logPath);
                CopyDir(subDir.FullName, newTargetDir, logPath);
            }
        }

        /// <summary>Copy required Abatab web service files.</summary>
        /// <param name="source">The file to copy.</param>
        /// <param name="target">The location to copy to.</param>
        /// <param name="serviceFiles">The list of required Abatab web service files.</param>
        /// <param name="logPath">The path to the log file.</param>
        public static void CopyService(string source, string target, List<string> serviceFiles, string logPath)
        {
            foreach (string file in serviceFiles)
            {
                WriteLog($"Copying service file: {file}...", logPath);
                File.Copy($@"{source}\{file}", $@"{target}\{file}");
            }
        }

        /// <summary>Get the sub-directories of a directory.</summary>v
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        /// <returns>I'm tired of commenting stuff.</returns>
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