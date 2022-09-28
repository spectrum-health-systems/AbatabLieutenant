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
 */

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
            var webServiceDir = $@"{AbatabUatRoot}\Webservice";
            RefreshDirectory(webServiceDir);

            var tempDir = $@"{AbatabUatRoot}\Temp";
            RefreshDirectory(tempDir);

            var repoZipName = $@"{AbatabUatRoot}\Abatab-repo.zip";
            DownloadZipFromUrl(RepoUrl, repoZipName);
            ZipFile.ExtractToDirectory(repoZipName, tempDir);

            CopyDir($@"{tempDir}\Abatab-development\src\bin\", $@"{webServiceDir}\bin");

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
            string targetPath = $@"{webServiceDir}";

            foreach (var file in filesToCopy)
            {
                File.Copy($@"{sourcePath}\{file}", $@"{targetPath}\{file}");
            }
        }

        private static void RefreshDirectory(string dir)
        {
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
            }

            Directory.CreateDirectory(dir);
        }

        public static void DownloadZipFromUrl(string sourceUrl, string targetFilePath)
        {
            var webClient = new System.Net.WebClient();
            webClient.DownloadFile(sourceUrl, targetFilePath);
        }

        public static void CopyDir(string sourceDir, string targetDir)
        {
            RefreshDirectory(targetDir);

            var dirToCopy                 = new DirectoryInfo(sourceDir);
            DirectoryInfo[] subDirsToCopy = GetSubDirs(sourceDir, targetDir);

            foreach (FileInfo file in dirToCopy.GetFiles())
            {
                string targetFilePath = Path.Combine(targetDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            foreach (DirectoryInfo subDir in subDirsToCopy)
            {
                string newTargetDir = Path.Combine(targetDir, subDir.Name);
            }
        }

        private static DirectoryInfo[] GetSubDirs(string sourceDir, string targetDir)
        {
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
            {
                Directory.CreateDirectory(targetDir);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            return dirs;
        }
    }
}
