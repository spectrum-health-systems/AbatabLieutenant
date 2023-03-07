// AbatabLieutenant.Utilities.cs
// b230307.1753
// (c) A Pretty Cool Program

using System.IO.Compression;

namespace AbatabLieutenant
{
    /// <summary>Summary</summary>
    public static class Utilities
    {
        /// <summary>Summary</summary>
        /// <param name="url"></param>
        /// <param name="target"></param>
        /// <param name="logPath"></param>
        public static void DownloadZip(string url, string target, string logPath)
        {
            WriteLog($"{Environment.NewLine}Downloading .ZIP: {url} = TO => {target}", logPath);

            System.Net.WebClient webClient = new();
            webClient.DownloadFile(url, target);
        }

        /// <summary>Summary</summary>
        /// <param name="url"></param>
        /// <param name="target"></param>
        /// <param name="logPath"></param>
        public static void DownloadFile(string url, string target, string logPath)
        {
            WriteLog($"Downloading file: {url} - TO -> {target}", logPath);

            System.Net.WebClient webClient = new();
            webClient.DownloadFile(url, target);
        }

        /// <summary>Summary</summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="logPath"></param>
        public static void ExtractBranch(string source, string target, string logPath)
        {
            WriteLog($"{Environment.NewLine}Extracting archive...", logPath);

            ZipFile.ExtractToDirectory(source, target);
        }

        /// <summary>Summary</summary>
        /// <param name="requiredDirectories"></param>
        /// <param name="logPath"></param>
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

        /// <summary>Summary</summary>
        /// <param name="directory"></param>
        /// <param name="logPath"></param>
        public static void RefreshDirectory(string directory, string logPath)
        {
            WriteLog($@"Refreshing: {directory}\...", logPath);

            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
            }

            _=Directory.CreateDirectory(directory);
        }

        /// <summary>Summary</summary>
        /// <param name="content"></param>
        /// <param name="filePath"></param>
        public static void WriteLog(string content, string filePath)
        {
            Console.WriteLine(content);
            File.AppendAllText(filePath, $"{content}{Environment.NewLine}");
        }

        /// <summary>Summary</summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="logPath"></param>
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

        /// <summary>Summary</summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="serviceFiles"></param>
        /// <param name="logFilePath"></param>
        public static void CopyService(string source, string target, List<string> serviceFiles, string logFilePath)
        {
            foreach (string file in serviceFiles)
            {
                WriteLog($"Copying service file: {file}...", logFilePath);
                File.Copy($@"{source}\{file}", $@"{target}\{file}");
            }
        }

        /// <summary>Summary</summary>v
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
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