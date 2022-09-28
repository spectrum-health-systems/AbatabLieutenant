/* ========================================================================================================
 * AbatabLieutenant v1.0.0
 * https://github.com/spectrum-health-systems/AbatabLieutenant
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * AbatabLieutenant.csproj v1.0.0
 * Program.cs b220928.164707
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
    internal class Program
    {
        public static string AbatabUatRoot = @"C:\AvatoolWebService\Abatab_UAT";
        public static string RepoUrl       = "https://github.com/spectrum-health-systems/Abatab/archive/refs/heads/development.zip";

        static void Main(string[] args)
        {

            var logFileName = $@"{AbatabUatRoot}\Logs\AbatabLieutenant.{DateTime.Now.ToString("yy-MM-dd_HH-mm-ss")}";
            File.WriteAllText(logFileName, "Log file start...");

            var tempDir = $@"{AbatabUatRoot}\Temp";
            RefreshDirectory(tempDir);
            File.AppendAllText(logFileName, $@"{AbatabUatRoot}\Temp refreshed.");

            var repoZipName = $@"{tempDir}\Abatab-repo.zip";
            DownloadZipFromUrl(RepoUrl, repoZipName);
            File.AppendAllText(logFileName, $@"{repoZipName} downloaded.");

            ZipFile.ExtractToDirectory(repoZipName, tempDir);
            File.AppendAllText(logFileName, $@"{repoZipName} extracted.");

            var webServiceBinDir = $@"{AbatabUatRoot}\bin";
            RefreshDirectory(webServiceBinDir);
            File.AppendAllText(logFileName, $@"{AbatabUatRoot}\bin refreshed.");

            CopyDir($@"{tempDir}\Abatab-development\src\bin\", $@"{webServiceBinDir}", logFileName);
            File.AppendAllText(logFileName, $@"{tempDir}\Abatab-development\src\bin\ copied.");

            var filesToCopy = new List<string>
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

            foreach (var file in filesToCopy)
            {
                File.Copy($@"{sourcePath}\{file}", $@"{targetPath}\{file}");
            }
            File.AppendAllText(logFileName, "Web service files copied.");
        }

        private static void RefreshDirectory(string dir)
        {
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
            }

            Directory.CreateDirectory(dir);
        }

        public static void DownloadZipFromUrl(string sourceUrl, string targetPath)
        {
            var webClient = new System.Net.WebClient();
            webClient.DownloadFile(sourceUrl, targetPath);
        }

        public static void CopyDir(string sourceDir, string targetDir, string logFileName)
        {
            RefreshDirectory(targetDir);
            File.AppendAllText(logFileName, $@"{targetDir} refreshed.");

            var dirToCopy                 = new DirectoryInfo(sourceDir);
            DirectoryInfo[] subDirsToCopy = GetSubDirs(sourceDir, targetDir, logFileName);

            foreach (FileInfo file in dirToCopy.GetFiles())
            {
                string targetFilePath = Path.Combine(targetDir, file.Name);
                file.CopyTo(targetFilePath);

                File.AppendAllText(logFileName, $@"File: {targetFilePath} copied.");
            }

            foreach (DirectoryInfo subDir in subDirsToCopy)
            {
                string newTargetDir = Path.Combine(targetDir, subDir.Name);
                File.AppendAllText(logFileName, $@"Subdirectory: {newTargetDir} found.");
            }
        }

        private static DirectoryInfo[] GetSubDirs(string sourceDir, string targetDir, string logFileName)
        {
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
            {
                Directory.CreateDirectory(targetDir);
                File.AppendAllText(logFileName, $@"Directory: {targetDir} created.");
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            return dirs;
        }
    }
}
