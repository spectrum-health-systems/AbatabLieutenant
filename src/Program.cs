// Abatab Lieutenant 2.0.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221201.1224

/* This code is designed to do a very specific thing for Spectrum Health
 * Systems, and is not intended for use at other organizations.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace AbatabLieutenant
{
    internal static class Program
    {
        public static string Ver = "2.0";

        internal static void Main(string[] args)
        {
            Console.Clear();



            Dictionary<string,string> config = SetConfig();
            string arg                       = SetArg(args, config["DefaultBranch"]);

            if (arg == "help")
            {
                DisplayHelp(Ver);
            }

            string logfile                          = SetLogfile(config["AbatabUatRoot"]);
            Dictionary<string, string> requiredDirs = SetRequiredDirs(config["AbatabUatRoot"]);

            //File.AppendAllText(logfile, $"{logfile} created.");
            VerifyDirs(requiredDirs, logfile);
            LogEvent(SetLogHeader(Ver, arg, logfile), logfile);

            VerifyDirs(requiredDirs, logfile);

            //var repoZipName = SetRepoZipName(requiredDirs["temp"], arg);
            //var repoZipUrl  = SetRepoZipUrl(config["RepoZipBaseUrl"], arg);

            Dictionary<string, string> repoInfo = SetRepoInfo(requiredDirs["temp"],config["RepoZipBaseUrl"], arg);

            DownloadZip(repoInfo, logfile);
            ExtractArchive(repoInfo["name"], requiredDirs["temp"], logfile);
            CopyBin(requiredDirs["temp"], requiredDirs["bin"], arg, logfile);
            CopyWebService(requiredDirs["temp"], config["AbatabUatRoot"], arg, logfile);

            LogEvent(MsgLogFooter(), logfile, true);
        }


        /* EXTRACT
         */

        private static void ExtractArchive(string repoZipName, string temp, string logName)
        {
            LogEvent(SetExtractMsg(repoZipName), logName, true);
            ZipFile.ExtractToDirectory(repoZipName, temp);

        }

        internal static Dictionary<string, string> SetRepoInfo(string dir, string baseUrl, string name)
        {
            return new Dictionary<string, string>
           {
               { "name", $"{name}.zip" },
               { "path", $@"{dir}\{name}.zip" },
               { "url",  $@"{baseUrl}{name}.zip" }
           };


        }


        private static string MsgLogFooter()
        {
            return $"{Environment.NewLine}" +
                   $"Process complete!{Environment.NewLine}" +
                   $"{Environment.NewLine}";
        }





        /* COPY
         */

        private static void CopyBin(string temp, string bin, string branch, string logName)
        {
            LogEvent($"Copying bin/...", logName);
            CopyDir($@"{temp}\Abatab-{branch}\src\bin\", $"{bin}", logName);
        }

        public static void CopyDir(string sourceDir, string targetDir, string logName)
        {
            RefreshDir(targetDir, logName);

            DirectoryInfo dirToCopy       = new DirectoryInfo(sourceDir);
            DirectoryInfo[] subDirsToCopy = GetSubDirs(sourceDir, targetDir, logName);

            foreach (FileInfo file in dirToCopy.GetFiles())
            {
                string targetFilePath = Path.Combine(targetDir, file.Name);

                _=file.CopyTo(targetFilePath);
                LogEvent($"  {targetFilePath} copied.", logName);
            }

            foreach (DirectoryInfo subDir in subDirsToCopy)
            {
                string newTargetDir = Path.Combine(targetDir, subDir.Name);
                CopyDir(subDir.FullName, newTargetDir, logName);
            }
        }

        private static void CopyWebService(string temp, string abatabUatRoot, string branch, string logName)
        {
            var serviceFiles = SetServiceFiles();

            string sourcePath = $@"{temp}\Abatab-{branch}\src";
            string targetPath = $@"{abatabUatRoot}";

            LogEvent($"{Environment.NewLine}Copying web service files...", logName);

            foreach (string file in serviceFiles)
            {
                if (File.Exists($@"{targetPath}\{file}"))
                {
                    File.Delete($@"{targetPath}\{file}");
                }

                File.Copy($@"{sourcePath}\{file}", $@"{targetPath}\{file}");
                LogEvent($@"  {sourcePath}\{file} copied.", logName);
            }
        }


        /* GET
         */

        private static DirectoryInfo[] GetSubDirs(string sourceDir, string targetDir, string logName)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
            {
                _=Directory.CreateDirectory(targetDir);
                LogEvent($"Directory {targetDir} created.", logName, true);
            }

            return dir.GetDirectories();
        }


        /* DISPLAY
         */

        private static void DisplayHelp(string ver)
        {
            Console.WriteLine(SetHelpMsg(ver));
            Environment.Exit(0);
        }


        /* REMOVE
         */

        private static void RemoveFiles(string root, List<string> files)
        {
            foreach (var file in files)
            {
                if (File.Exists($@"{root}/{file}"))
                {
                    File.Delete($@"{root}/{file}");
                }
            }
        }


        /* REFRESH
 */

        internal static void VerifyDirs(Dictionary<string, string> dirs, string logfile)
        {
            LogEvent("Verifying directories...", logfile, true);

            foreach (var dir in dirs)
            {
                if (dir.Key == "logs")
                {
                    //File.AppendAllText(logfile, $"{logfile} created.");
                    continue;
                }

                if (dir.Key == "root")
                {
                    LogEvent($@"  {dir.Value}\", logfile, true);
                    RemoveFiles(dir.Value, SetServiceFiles());
                    continue;
                }

                RefreshDir(dir.Value, logfile);

                //if (Directory.Exists(dir.Value))
                //{
                //    Directory.Delete(dir.Value, true);
                //}

                //_=Directory.CreateDirectory(dir.Value);
                //LogEvent($"  {dir.Value}", logfile, true);
            }


        }

        internal static bool VerifyArg(string arg) => SetValidArgs().Contains(arg);



        /* VERIFY
         */

        private static void RefreshDir(string dir, string logfile)
        {
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
            }

            _=Directory.CreateDirectory(dir);
            LogEvent($"  {dir}", logfile, true);
        }


        /* SET
        */

        internal static Dictionary<string, string> SetRequiredDirs(string abatabRoot) => new Dictionary<string, string>
            {
                { "root", abatabRoot },
                { "logs", $@"{abatabRoot}\logs\lieutenant" },
                { "temp", $@"{abatabRoot}\temp" },
                { "bin",  $@"{abatabRoot}\bin" }
            };

        internal static Dictionary<string, string> SetConfig() => new Dictionary<string, string>
            {
                { "RepoZipBaseUrl", Properties.Settings.Default.RepoZipBaseUrl},
                { "AbatabUatRoot",  Properties.Settings.Default.AbatabUatRoot},
                { "DefaultBranch",  Properties.Settings.Default.DefaultBranch}
            };

        internal static string SetLogfile(string abatabRoot)
        {
            var logfile = $@"{abatabRoot}\logs\lieutenant\{DateTime.Now.ToString("yyMMdd.HHmmss")}.ltnt";

            File.AppendAllText(logfile, $"{logfile} created.");

            return logfile;
        }

        private static List<string> SetServiceFiles() => new List<string>
            {
                "Abatab.asmx",
                "Abatab.asmx.cs",
                "packages.config",
                "Web.config",
                "Web.Debug.config",
                "Web.Release.config"
            };

        private static List<string> SetValidArgs() => new List<string>
                                                      {
                                                          "development",
                                                          "experimental",
                                                          "help",
                                                          "main",
                                                          "testbuild"
                                                      };

        private static string SetHelpMsg(string ver) => $"{Environment.NewLine}" +
                                                        $"==========================={Environment.NewLine}" +
                                                        $"Abatab Lieutenant v{ver} Help{Environment.NewLine}" +
                                                        $"===========================" +
                                                        $"{Environment.NewLine}" +
                                                        $"{Environment.NewLine}" +
                                                        $"Syntax:{Environment.NewLine}" +
                                                        $"{Environment.NewLine}" +
                                                        $"{Environment.NewLine}" +
                                                        $"    $ AbatabLieutenant <command>{Environment.NewLine}" +
                                                        $"{Environment.NewLine}" +
                                                        $"{Environment.NewLine}" +
                                                        $"Valid commands:{Environment.NewLine}" +
                                                        $"{Environment.NewLine}" +
                                                        $"            help - Abatab Lieutenant help (this screen){Environment.NewLine}" +
                                                        $"     development - Deploy the Abatab development branch{Environment.NewLine}" +
                                                        $"    experimental - Deploy the Abatab experimental branch{Environment.NewLine}" +
                                                        $"            main - Deploy the Abatab main branch{Environment.NewLine}" +
                                                        $"       testbuild - Deploy the Abatab tesbuild branch (default){Environment.NewLine}" +
                                                        $"{Environment.NewLine}" +
                                                        $"{Environment.NewLine}" +
                                                        $"Example:{Environment.NewLine}" +
                                                        $"{Environment.NewLine}" +
                                                        $"{Environment.NewLine}" +
                                                        $"    AbatabLieutenant.exe help" +
                                                        $"{Environment.NewLine}";

        internal static string SetArg(string[] args, string defaultBranch) => args.Length == 1 && VerifyArg(args[0])
            ? args[0]
            : defaultBranch;

        internal static string SetRepoZipUrl(string repoZipBaseUrl, string branch) => $"{repoZipBaseUrl}{branch}.zip";


        private static string SetLogHeader(string ver, string branch, string logfile) => $"{Environment.NewLine}" +
                                                                                         $"{Environment.NewLine}===============================" +
                                                                                         $"{Environment.NewLine}Starting Abatab Lieutenant v{ver}{Environment.NewLine}" +
                                                                                         $"==============================={Environment.NewLine}" +
                                                                                         $"{Environment.NewLine}" +
                                                                                         $"Deploying branch: {branch}{Environment.NewLine}";




        private static string SetDownloadMsg(string src)
        {
            return $"{Environment.NewLine}" +
                   $"Downloading Abatab repository from:{Environment.NewLine}" +
                   $"  {src}";
        }

        private static string SetExtractMsg(string repoZip)
        {
            return $"{Environment.NewLine}" +
                   $"Extracting {repoZip}...{Environment.NewLine}";
        }











        internal static void DownloadZip(Dictionary<string, string> repoInfo, string logfile)
        {
            LogEvent(SetDownloadMsg(repoInfo["url"]), logfile, true);

            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.DownloadFile(repoInfo["url"], repoInfo["path"]);
        }

        internal static void LogEvent(string msg, string logfile, bool newline = false)
        {
            Console.WriteLine(msg);
            File.AppendAllText(logfile, FormatLogMsg(msg, newline));
        }

        internal static string FormatLogMsg(string msg, bool newline) => newline
            ? $"{Environment.NewLine}{msg}"
            : $"{msg}{Environment.NewLine}";
    }
}