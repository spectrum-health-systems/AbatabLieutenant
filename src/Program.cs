/* ========================================================================================================
 * AbatabLieutenant v1.0.0
 * https://github.com/spectrum-health-systems/AbatabLieutenant
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * AbatabLieutenant.csproj v1.0.0
 * Program.cs b220929.081149
 * ===================================================================================================== */

/* AbatabLieutenant is a simple command line application that fetches the current development branch of
 * Abatab, and copies it to the web server where it is hosted.
 *
 * For more information:
 *   https://github.com/spectrum-health-systems/AbatabLieutenant/blob/main/README.md
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace AbatabLieutenant
{
    internal static class Program
    {
        public static string AbatabUatRoot = @"C:\AvatoolWebService\Abatab_UAT";
        public static string RepoUrl       = "https://github.com/spectrum-health-systems/Abatab/archive/refs/heads/development.zip";
        public static string Timestamp     = DateTime.Now.ToString("yy-MM-dd_HH-mm-ss");

        private static void Main(string[] args)
        {
            Console.WriteLine("Starting Abatab Lieutenant...");

            var logFileName = $@"{AbatabUatRoot}\Logs\AbatabLieutenant\{Timestamp}.log";
            File.WriteAllText(logFileName, $"Log file start...{Environment.NewLine}{Environment.NewLine}");

            var tempDir = $@"{AbatabUatRoot}\Temp";
            RefreshDirectory(tempDir, logFileName);

            var webServiceBinDir = $@"{AbatabUatRoot}\bin";
            RefreshDirectory(webServiceBinDir, logFileName);

            var repoZipName = $@"{tempDir}\Abatab-repo.zip";
            DownloadZipFromUrl(RepoUrl, repoZipName, logFileName);

            ExtractArchive(repoZipName, tempDir, logFileName);

            CopyBinDirectory(tempDir, webServiceBinDir, logFileName);

            CopyWebServiceFiles(tempDir, logFileName);

            File.AppendAllText(logFileName, $"{Environment.NewLine}Process complete!{Environment.NewLine}");
            Console.WriteLine("Abatab Lieutenant process complete!");
        }

        private static void ExtractArchive(string repoZipName, string tempDir, string logFileName)
        {
            File.AppendAllText(logFileName, $"{Environment.NewLine}Extracting {repoZipName}...{Environment.NewLine}");
            ZipFile.ExtractToDirectory(repoZipName, tempDir);
            File.AppendAllText(logFileName, $@"{repoZipName} extracted.{Environment.NewLine}");
        }

        private static void CopyBinDirectory(string tempDir, string webServiceBinDir, string logFileName)
        {
            File.AppendAllText(logFileName, $@"{Environment.NewLine}Copying {tempDir}\Abatab-development\src\bin\ to {webServiceBinDir}...{Environment.NewLine}");
            CopyDir($@"{tempDir}\Abatab-development\src\bin\", $"{webServiceBinDir}", logFileName);
            File.AppendAllText(logFileName, $@"{tempDir}\Abatab-development\src\bin\ copied to {webServiceBinDir}.{Environment.NewLine}");
        }

        private static void CopyWebServiceFiles(string tempDir, string logFileName)
        {
            List<string> filesToCopy = new List<string>
            {
                "Abatab.asmx",
                "Abatab.asmx.cs",
                "packages.config",
                "Web.config",
                "Web.Debug.config",
                "Web.Release.config"
            };

            string sourcePath = $@"{tempDir}\Abatab-development\src";
            string targetPath = $@"{AbatabUatRoot}";

            foreach (string file in filesToCopy)
            {
                File.AppendAllText(logFileName, $@"{Environment.NewLine}Checking file: {targetPath}\{file}...{Environment.NewLine}");

                if (File.Exists($@"{targetPath}\{file}"))
                {
                    File.AppendAllText(logFileName, $@"File: {targetPath}\{file} exists...{Environment.NewLine}");
                    File.Delete($@"{targetPath}\{file}");
                    File.AppendAllText(logFileName, $@"File: {targetPath}\{file} deleted.{Environment.NewLine}");
                }

                File.AppendAllText(logFileName, $@"Copying {sourcePath}\{file}...{Environment.NewLine}");
                File.Copy($@"{sourcePath}\{file}", $@"{targetPath}\{file}");
                File.AppendAllText(logFileName, $@"File: {sourcePath}\{file} copied.{Environment.NewLine}");
            }
            File.AppendAllText(logFileName, $"Web service files copied.{Environment.NewLine}");

        }

        private static void RefreshDirectory(string dir, string logFileName)
        {
            File.AppendAllText(logFileName, $"{Environment.NewLine}Checking to see if {dir}/ exists...{Environment.NewLine}");

            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
                File.AppendAllText(logFileName, $"{dir}/ exists...{Environment.NewLine}");
            }

            _=Directory.CreateDirectory(dir);

            File.AppendAllText(logFileName, $"{dir}/ refreshed.{Environment.NewLine}");
        }

        public static void DownloadZipFromUrl(string sourceUrl, string targetPath, string logFileName)
        {
            File.AppendAllText(logFileName, $"{Environment.NewLine}Downloading Abatab repository from {sourceUrl}...{Environment.NewLine}");

            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.DownloadFile(sourceUrl, targetPath);

            File.AppendAllText(logFileName, $"Abatab repository downloaded.{Environment.NewLine}");
        }

        public static void CopyDir(string sourceDir, string targetDir, string logFileName)
        {
            RefreshDirectory(targetDir, logFileName);

            DirectoryInfo dirToCopy       = new DirectoryInfo(sourceDir);
            DirectoryInfo[] subDirsToCopy = GetSubDirs(sourceDir, targetDir, logFileName);

            foreach (FileInfo file in dirToCopy.GetFiles())
            {
                string targetFilePath = Path.Combine(targetDir, file.Name);
                File.AppendAllText(logFileName, $"{Environment.NewLine}Copying file: {targetFilePath}...{Environment.NewLine}");
                _=file.CopyTo(targetFilePath);
                File.AppendAllText(logFileName, $"File: {targetFilePath} copied.{Environment.NewLine}");
            }

            foreach (DirectoryInfo subDir in subDirsToCopy)
            {
                string newTargetDir = Path.Combine(targetDir, subDir.Name);
                File.AppendAllText(logFileName, $"{Environment.NewLine}Subdirectory: {newTargetDir} found.{Environment.NewLine}");
                CopyDir(subDir.FullName, newTargetDir, logFileName);
            }
        }

        private static DirectoryInfo[] GetSubDirs(string sourceDir, string targetDir, string logFileName)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
            {
                File.AppendAllText(logFileName, $"{Environment.NewLine}Directory {targetDir} does not exist...{Environment.NewLine}");
                _=Directory.CreateDirectory(targetDir);
                File.AppendAllText(logFileName, $"Directory: {targetDir} created.{Environment.NewLine}");
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            return dirs;
        }
    }
}