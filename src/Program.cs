﻿using System.IO;
using System.IO.Compression;

namespace AbatabLieutenant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var abatabWebServiceDir = @"C:\AvatoolWebService\Abatab\";

            //if (Directory.Exists(abatabWebServiceDir))
            //{
            //    Directory.Delete(abatabWebServiceDir, true);
            //    Directory.CreateDirectory(abatabWebServiceDir);
            //}

            var abatabTempDir = @"C:\AvatoolWebService\Abatab_Temp\";

            if (Directory.Exists(abatabTempDir))
            {
                Directory.Delete(abatabTempDir, true);
                Directory.CreateDirectory(abatabTempDir);
            }


            var repoUrl     = "https://github.com/spectrum-health-systems/Abatab/tree/development";
            var repoZipfile = @"C:\AvatoolWebService\Abatab_Temp\Abatab-repo.zip";
            //var repoZipfile = $@"{abatabTempDir}abatab-repo.zip";

            DownloadZipFromUrl(repoUrl, repoZipfile);

            ZipFile.ExtractToDirectory(repoZipfile, abatabTempDir);

            //CopyDir(@"C:\AvatoolWebService\abatab_Temp\bin\", @"C:\AvatoolWebService\abatab\bin\");

            //var filesToCopy = new List<string>
            //{
            //    "Abatab.asmx",
            //    "Abatab.asmx.cs",
            //    "packages.config",
            //    "Web.config",
            //    "Web.Debug.config",
            //    "Web.Release.config"
            //};

            //string sourceFilePath = @"C:\AvatoolWebService\abatab\";
            //string targetFilePath = @"C:\AvatoolWebService\abatab\";

            //foreach (var file in filesToCopy)
            //{
            //    File.Copy($"{sourceFilePath}{file}", $"{targetFilePath}{file}");
            //}

        }

        public static void DownloadZipFromUrl(string sourceUrl, string targetFilePath)
        {
            var webClient = new System.Net.WebClient();
            webClient.DownloadFile(sourceUrl, targetFilePath);
        }

        public static void CopyDir(string sourceDir, string targetDir)
        {
            if (Directory.Exists(sourceDir))
            {
                Directory.Delete(sourceDir, true);
                Directory.CreateDirectory(sourceDir);
            }

            if (Directory.Exists(targetDir))
            {
                Directory.Delete(targetDir, true);
                Directory.CreateDirectory(targetDir);
            }

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
