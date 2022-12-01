// Abatab Lieutenant 2.0.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221201.0852

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace AbatabLieutenant
{
    internal static class Program
    {
        public static string Ver = "2.0.0";

        internal static void Main(string[] args)
        {
            Dictionary<string,string> localSettings = GetLocalSettings();
            string branch                           = SetBranch(args, localSettings["DefaultBranch"]);
            string logfile                          = SetLogfile(localSettings["AbatabUatRoot"]);
            Dictionary<string, string> requiredDirs = SetRequiredDirs(localSettings["AbatabUatRoot"]);

            WriteAndDisplayLog($"{Environment.NewLine}Starting Abatab Lieutenant (v{Ver}) - logfile: {logfile}", logfile, true);

            VerifyRequiredDirectories(requiredDirs, logfile);

            RefreshDirectory(requiredDirs["tempDir"], logfile);
            RefreshDirectory(requiredDirs["binDir"], logfile);

            var repoZipName = $@"{requiredDirs["tempDir"]}\{branch}.zip";
            var repoZipUrl = SetRepoZipUrl(localSettings["RepoZipBaseUrl"], branch);

            DownloadZipFromUrl(repoZipUrl, repoZipName, logfile);

            ExtractArchive(repoZipName, requiredDirs["tempDir"], logfile);

            CopyBinDir(requiredDirs["tempDir"], requiredDirs["binDir"], branch, logfile);

            CopyWebServiceFiles(requiredDirs["tempDir"], localSettings["AbatabUatRoot"], branch, logfile);

            WriteAndDisplayLog("Process complete!", logfile, true);

        }

        private static void ExtractArchive(string repoZipName, string tempDir, string logName)
        {
            WriteAndDisplayLog($"Extracting {repoZipName}...", logName, true);

            ZipFile.ExtractToDirectory(repoZipName, tempDir);

            WriteAndDisplayLog($"{repoZipName} extracted.", logName);
        }


        private static void CopyBinDir(string tempDir, string binDir, string branch, string logName)
        {
            WriteAndDisplayLog($@"Copying {tempDir}\Abatab-{branch}\src\bin\ to {binDir}...", logName, true);

            CopyDir($@"{tempDir}\Abatab-{branch}\src\bin\", $"{binDir}", logName);

            WriteAndDisplayLog($@"{tempDir}\Abatab-{branch}\src\bin\ copied to {binDir}.", logName);
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

        private static void CopyWebServiceFiles(string tempDir, string abatabUatRoot, string branch, string logName)
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

            string sourcePath = $@"{tempDir}\Abatab-{branch}\src";
            string targetPath = $@"{abatabUatRoot}";

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


        internal static string SetRepoZipUrl(string repoZipBaseUrl, string branch)
        {


            return $"{repoZipBaseUrl}{branch}.zip";
        }


        internal static void DownloadZipFromUrl(string source, string target, string logfile)
        {
            WriteAndDisplayLog($"Downloading Abatab repository from {source}...", logfile, true);

            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.DownloadFile(source, target);

            WriteAndDisplayLog($"Abatab repository downloaded.", logfile);
        }

        internal static Dictionary<string, string> SetRequiredDirs(string abatabRoot)
        {
            return new Dictionary<string, string>
            {
                { "logDir",  $@"{abatabRoot}\logs\lieutenant" },
                { "tempDir", $@"{abatabRoot}\temp" },
                { "binDir",  $@"{abatabRoot}\bin" }
            };
        }

        internal static Dictionary<string, string> GetLocalSettings()
        {
            return new Dictionary<string, string>
            {
                { "RepoZipBaseUrl", Properties.Settings.Default.RepoZipBaseUrl},
                { "AbatabUatRoot",  Properties.Settings.Default.AbatabUatRoot},
                { "DefaultBranch",  Properties.Settings.Default.DefaultBranch}
            };
        }

        internal static string SetLogfile(string abatabRoot) => $@"{abatabRoot}\logs\lieutenant\{DateTime.Now.ToString("yyMMddHHmmss")}.ltnt";

        internal static void VerifyRequiredDirectories(Dictionary<string, string> dirs, string logfile)
        {
            WriteAndDisplayLog("Verifying directories...", logfile, true);

            foreach (var dir in dirs)
            {
                if (Directory.Exists(dir.Value))
                {
                    WriteAndDisplayLog($"Directory {dir.Value} exists.", logfile);
                }
                else
                {
                    _=Directory.CreateDirectory(dir.Value);

                    WriteAndDisplayLog($"Directory {dir}  did not exist, and was created.", logfile);
                }

                if (dir.Key == "logDir")
                {
                    File.AppendAllText(logfile, $"{logfile} created.");
                }
            }
        }

        internal static void RefreshDirectory(string dir, string logfile)
        {
            WriteAndDisplayLog($"Refreshing {dir} directory....", logfile, true);

            if (Directory.Exists(dir))
            {
                WriteAndDisplayLog($"{dir} exists, removing...", logfile);

                Directory.Delete(dir, true);
            }

            WriteAndDisplayLog($"Creating {dir} directory...", logfile);

            _=Directory.CreateDirectory(dir);

            WriteAndDisplayLog($"Directory {dir} refreshed.", logfile);
        }

        internal static void WriteAndDisplayLog(string msg, string logfile, bool newline = false)
        {
            Console.WriteLine(msg);

            if (File.Exists(logfile))
            {
                File.AppendAllText(logfile, FormatMsg(msg, newline));
            }
        }

        internal static string FormatMsg(string msg, bool newline)
        {
            return newline
                ? $"{Environment.NewLine}{msg}"
                : $"{msg}{Environment.NewLine}";
        }

        //internal static string SetBranch(string[] passedArgs)
        //{
        //    var requestedBranch = "";

        //    if (passedArgs.Length == 1)
        //    {
        //        requestedBranch = GetRequestedBranch(passedArgs[0]);
        //    }

        //    return requestedBranch;
        //}

        internal static string SetBranch(string[] passedArgs, string defaultBranch)
        {
            if (passedArgs.Length == 1 && VerifyRequestedBranch(passedArgs[0]))
            {
                return passedArgs[0];
            }
            else
            {
                return defaultBranch;
            }
        }

        internal static bool VerifyRequestedBranch(string requestedBranch)
        {
            var validBranches = new List<string>
            {
                "development",
                "main",
                "testbuild",
                "experimental"
            };

            return validBranches.Contains(requestedBranch);
        }
    }
}