/* ========================================================================================================
 * AbatabLieutenant v1.0.1
 * https://github.com/spectrum-health-systems/AbatabLieutenant
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * AbatabLieutenant.csproj v1.0.1
 * Program.cs b220929.103358
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
        public static string LieutenantVer = "1.0.1";
        public static string AbatabUatRoot = @"C:\AvatoolWebService\Abatab_UAT";
        public static string RepoUrl       = "https://github.com/spectrum-health-systems/Abatab/archive/refs/heads/development.zip";
        public static string Timestamp     = DateTime.Now.ToString("yyMMddHHmmss");
        public static string RepoZip       = "Abatab-repo.zip";

        private static void Main(string[] args)
        {
            var logName = $@"{AbatabUatRoot}\logs\lieutenant\{Timestamp}.lieutenant";

            WriteAndDisplayLog($"{Environment.NewLine}Starting Abatab Lieutenant (v{LieutenantVer}) - logfile: {logName}", logName, true);

            var requiredDirs = new Dictionary<string, string>
            {
                { "logDir",  $@"{AbatabUatRoot}\logs\lieutenant" },
                { "tempDir", $@"{AbatabUatRoot}\temp" },
                { "binDir",  $@"{AbatabUatRoot}\bin" }
            };

            VerifyRequiredDirectories(requiredDirs, logName);
            RefreshDirectory(requiredDirs["tempDir"], logName);
            RefreshDirectory(requiredDirs["binDir"], logName);

            var repoZipName = $@"{requiredDirs["tempDir"]}\{RepoZip}";
            DownloadZipFromUrl(RepoUrl, repoZipName, logName);

            ExtractArchive(repoZipName, requiredDirs["tempDir"], logName);

            CopyBinDir(requiredDirs["tempDir"], requiredDirs["binDir"], logName);

            CopyWebServiceFiles(requiredDirs["tempDir"], logName);

            WriteAndDisplayLog("Process complete!", logName, true);
        }

        private static void WriteAndDisplayLog(string msg, string logName, bool newLine = false)
        {
            var formattedMsg = FormatMsg(msg, newLine);
            Console.WriteLine(msg);

            if (File.Exists(logName))
            {
                File.AppendAllText(logName, formattedMsg);
            }
        }

        private static string FormatMsg(string msg, bool newLine)
        {
            return newLine
                ? $"{Environment.NewLine}{msg}"
                : $"{msg}{Environment.NewLine}";
        }

        private static void VerifyRequiredDirectories(Dictionary<string, string> dirs, string logName)
        {
            WriteAndDisplayLog("Verifying directories...", logName, true);

            foreach (var dir in dirs)
            {
                if (Directory.Exists(dir.Value))
                {
                    WriteAndDisplayLog($"Directory {dir.Value} exists.", logName);
                }
                else
                {
                    _=Directory.CreateDirectory(dir.Value);

                    WriteAndDisplayLog($"Directory {dir}  did not exist, and was created.", logName);
                }

                if (dir.Key == "logDir")
                {
                    File.AppendAllText(logName, $"{logName} created.");
                    //File.WriteAllText(logName, "Logfile created");
                }
            }
        }

        private static void ExtractArchive(string repoZipName, string tempDir, string logName)
        {
            WriteAndDisplayLog($"Extracting {repoZipName}...", logName, true);

            ZipFile.ExtractToDirectory(repoZipName, tempDir);

            WriteAndDisplayLog($"{repoZipName} extracted.", logName);
        }

        private static void CopyBinDir(string tempDir, string binDir, string logName)
        {
            WriteAndDisplayLog($@"Copying {tempDir}\Abatab-development\src\bin\ to {binDir}...", logName, true);

            CopyDir($@"{tempDir}\Abatab-development\src\bin\", $"{binDir}", logName);

            WriteAndDisplayLog($@"{tempDir}\Abatab-development\src\bin\ copied to {binDir}.", logName);
        }

        private static void CopyWebServiceFiles(string tempDir, string logName)
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

            WriteAndDisplayLog($"Copying web service files...", logName, true);

            foreach (string file in filesToCopy)
            {
                WriteAndDisplayLog($@"Web service file: {targetPath}\{file}...", logName);

                if (File.Exists($@"{targetPath}\{file}"))
                {
                    WriteAndDisplayLog($@"{targetPath}\{file} exists, removing...", logName);

                    File.Delete($@"{targetPath}\{file}");

                    WriteAndDisplayLog($@"{targetPath}\{file} removed.", logName);
                }

                WriteAndDisplayLog($@"Copying {sourcePath}\{file}...", logName);

                File.Copy($@"{sourcePath}\{file}", $@"{targetPath}\{file}");

                WriteAndDisplayLog($@"{sourcePath}\{file} copied.", logName);
            }

            WriteAndDisplayLog($"Web service files copied.", logName);
        }

        private static void RefreshDirectory(string dir, string logName)
        {
            WriteAndDisplayLog($"Refreshing {dir} directory....", logName, true);

            if (Directory.Exists(dir))
            {
                WriteAndDisplayLog($"{dir} exists, removing...", logName);

                Directory.Delete(dir, true);
            }

            WriteAndDisplayLog($"Creating {dir} directory...", logName);

            _=Directory.CreateDirectory(dir);

            WriteAndDisplayLog($"Directory {dir} refreshed.", logName);
        }

        public static void DownloadZipFromUrl(string sourceUrl, string targetPath, string logName)
        {
            WriteAndDisplayLog($"Downloading Abatab repository from {sourceUrl}...", logName, true);

            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.DownloadFile(sourceUrl, targetPath);

            WriteAndDisplayLog($"Abatab repository downloaded.", logName);
        }

        public static void CopyDir(string sourceDir, string targetDir, string logName)
        {
            RefreshDirectory(targetDir, logName);

            DirectoryInfo dirToCopy       = new DirectoryInfo(sourceDir);
            DirectoryInfo[] subDirsToCopy = GetSubDirs(sourceDir, targetDir, logName);

            foreach (FileInfo file in dirToCopy.GetFiles())
            {
                string targetFilePath = Path.Combine(targetDir, file.Name);

                WriteAndDisplayLog($"Copying file: {targetFilePath}...", logName);

                _=file.CopyTo(targetFilePath);

                WriteAndDisplayLog($"File copied.", logName);
            }

            foreach (DirectoryInfo subDir in subDirsToCopy)
            {
                string newTargetDir = Path.Combine(targetDir, subDir.Name);
                WriteAndDisplayLog($"Subdirectory: {newTargetDir} found...", logName);
                CopyDir(subDir.FullName, newTargetDir, logName);
            }
        }

        private static DirectoryInfo[] GetSubDirs(string sourceDir, string targetDir, string logName)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
            {
                WriteAndDisplayLog($"Directory {targetDir} does not exist, creating...", logName, true);

                _=Directory.CreateDirectory(targetDir);

                WriteAndDisplayLog($"Directory {targetDir} created.", logName, true);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            return dirs;
        }
    }
}