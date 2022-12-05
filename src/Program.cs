// Abatab Lieutenant 2.0.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221205.1145

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
        public static string DebugMode { get; set; }
        public static string LtntVersion { get; set; }
        public static string LtntRoot { get; set; }
        public static string PassedArgument { get; set; }
        public static string LogFile { get; set; }
        public static string RepoUrl { get; set; }
        public static string DefaultBranch { get; set; }
        public static string TargetBranch { get; set; }
        public static Dictionary<string, string> LtntDirs { get; set; }
        public static Dictionary<string, string> RepoInfo { get; set; }

        internal static void Main(string[] args)
        {
            Startuper(args);

            DeployWebService();

            Finisher(1);
        }

        internal static void Startuper(string[] passedArgs)
        {
            Console.Clear();

            PassedArgument = VerifyArg(passedArgs);

            if (PassedArgument == "help")
            {
                Console.WriteLine(HelpMsg(Properties.Settings.Default.LtntVersion));
                Finisher(0);
            }
            else
            {
                BuildConfig();
                LogEvent(LogHeaderMsg());
                VerifyDirs();
            }
        }

        internal static void BuildConfig()
        {
            DebugMode      = Properties.Settings.Default.DebugMode;
            LtntVersion    = Properties.Settings.Default.LtntVersion;
            LtntRoot       = Properties.Settings.Default.LtntRoot;
            RepoUrl        = Properties.Settings.Default.RepoUrl;
            DefaultBranch  = Properties.Settings.Default.DefaultBranch;
            TargetBranch   = PassedArgument;
            LogFile        = SetLogfile($@"{Properties.Settings.Default.LtntRoot}\Logs\Lieutenant");

            LtntDirs = new Dictionary<string, string>
            {
                { "Root", Properties.Settings.Default.LtntRoot },
                { "Logs", $@"{Properties.Settings.Default.LtntRoot}\Logs\Lieutenant" },
                { "Temp", $@"{Properties.Settings.Default.LtntRoot}\Temp" },
                { "bin",  $@"{Properties.Settings.Default.LtntRoot}\bin" },
            };

            RepoInfo = new Dictionary<string, string>
            {
               { "Branch", $"{TargetBranch}.zip" },
               { "Source", $@"{Properties.Settings.Default.LtntRoot}\temp\{TargetBranch}.zip" },
               { "Url",    $"{Properties.Settings.Default.RepoUrl}{TargetBranch}.zip" }
            };

            if (string.Equals(DebugMode, "enabled", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(DebugMsg());
            }
        }

        internal static void VerifyDirs()
        {
            LogEvent("Verifying directories...", true);

            foreach (var dir in LtntDirs)
            {
                if (string.Equals(dir.Key, "logs", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (string.Equals(dir.Key, "root", StringComparison.OrdinalIgnoreCase))
                {
                    LogEvent($@"  {dir.Value}\", true);
                    RemoveFiles(dir.Value, ServiceFiles());
                    continue;
                }

                RefreshDir(dir.Value);
            }
        }

        internal static void DeployWebService()
        {
            DownloadArchive();
            ExtractArchive();
            CopyBin();
            CopyWebService();
        }

        internal static void DownloadArchive()
        {
            LogEvent(DownloadMsg(RepoInfo["Url"]), true);

            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.DownloadFile(RepoInfo["Url"], RepoInfo["Source"]);
        }

        internal static void ExtractArchive()
        {
            LogEvent(ExtractMsg(RepoInfo["Source"], RepoInfo["Source"]), true);
            ZipFile.ExtractToDirectory(RepoInfo["Source"], LtntDirs["Temp"]);
        }

        internal static void CopyBin()
        {
            LogEvent($"Copying bin/...");
            CopyDir($@"{LtntDirs["Temp"]}\Abatab-{PassedArgument}\src\bin\", $"{LtntDirs["bin"]}");
        }

        internal static void CopyDir(string source, string target)
        {
            RefreshDir(target);

            DirectoryInfo dirToCopy       = new DirectoryInfo(source);
            DirectoryInfo[] subDirsToCopy = GetSubDirs(source, target);

            foreach (FileInfo file in dirToCopy.GetFiles())
            {
                string targetFilePath = Path.Combine(target, file.Name);

                _=file.CopyTo(targetFilePath);
                LogEvent($"  {targetFilePath} copied.");
            }

            foreach (DirectoryInfo subDir in subDirsToCopy)
            {
                string newTargetDir = Path.Combine(target, subDir.Name);
                CopyDir(subDir.FullName, newTargetDir);
            }
        }

        internal static void CopyWebService()
        {
            //var serviceFiles = ServiceFiles();

            string source = $@"{LtntDirs["Temp"]}\Abatab-{TargetBranch}\src";
            string target = $@"{LtntDirs["Root"]}";

            LogEvent($"{Environment.NewLine}Copying web service files...");

            //foreach (string file in serviceFiles)
            foreach (string file in ServiceFiles())
            {
                if (File.Exists($@"{target}\{file}"))
                {
                    File.Delete($@"{target}\{file}");
                }

                File.Copy($@"{source}\{file}", $@"{target}\{file}");
                LogEvent($@"  {source}\{file} copied.");
            }
        }

        internal static void LogEvent(string msg, bool newline = false)
        {
            Console.WriteLine(msg);
            File.AppendAllText(LogFile, FormatLogMsg(msg, newline));
        }

        internal static void Finisher(int exitCode, string exitMsg = "Exiting Abatab Lieutenant.")
        {
            switch (exitCode)
            {
                case 1:
                    LogEvent(LogFooterMsg(), true);
                    Environment.Exit(1);
                    break;

                case 2:
                    Console.WriteLine(exitMsg);
                    Environment.Exit(2);
                    break;

                case 0:
                default:
                    Console.WriteLine(exitMsg);
                    Environment.Exit(0);
                    break;
            }
        }

        private static DirectoryInfo[] GetSubDirs(string sourceDir, string targetDir)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
            {
                _=Directory.CreateDirectory(targetDir);
                LogEvent($"Directory {targetDir} created.", true);
            }

            return dir.GetDirectories();
        }

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

        internal static string VerifyArg(string[] passedArgs)
        {
            var passedArg = "";

            if (passedArgs.Length == 0)
            {
                passedArg = Properties.Settings.Default.DefaultBranch;
            }
            else
            {
                if (ValidArgs().Contains($"{passedArgs[0]}"))
                {
                    passedArg = $"{passedArgs[0]}";
                }
                else
                {
                    Finisher(0);
                }
            }

            return passedArg;
        }

        private static void RefreshDir(string dir)
        {
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
            }

            _=Directory.CreateDirectory(dir);
            LogEvent($"  {dir}", true);
        }

        private static List<string> ServiceFiles() => new List<string>
            {
                "Abatab.asmx",
                "Abatab.asmx.cs",
                "packages.config",
                "Web.config",
                "Web.Debug.config",
                "Web.Release.config"
            };

        private static List<string> ValidArgs() => new List<string>
            {
                "development",
                "experimental",
                "help",
                "main",
                "testbuild"
            };

        internal static string ArchiveUrl(string repoZipBaseUrl, string branch) => $"{repoZipBaseUrl}{branch}.zip";

        internal static string SetLogfile(string Logs)
        {
            if (!Directory.Exists(Logs))
            {
                _=Directory.CreateDirectory(Logs);
            }

            return $@"{Logs}\{DateTime.Now.ToString("yyMMdd.HHmmss")}.ltnt";
        }

        internal static string FormatLogMsg(string msg, bool newline) => newline
            ? $"{Environment.NewLine}{msg}"
            : $"{msg}{Environment.NewLine}";

        private static string LogHeaderMsg() => $"{Environment.NewLine}" +
                                                $"{Environment.NewLine}==========================" +
                                                $"{Environment.NewLine}Starting Abatab Lieutenant v{LtntVersion}{Environment.NewLine}" +
                                                $"=========================={Environment.NewLine}" +
                                                $"{Environment.NewLine}" +
                                                $"Deploying branch: {TargetBranch}{Environment.NewLine}";

        private static string LogFooterMsg() => $"{Environment.NewLine}" +
                                                $"Process complete!{Environment.NewLine}" +
                                                $"{Environment.NewLine}";

        private static string HelpMsg(string version) => $"{Environment.NewLine}" +
                                                         $"==========================={Environment.NewLine}" +
                                                         $"Abatab Lieutenant v{version} Help{Environment.NewLine}" +
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

        private static string DownloadMsg(string src) => $"{Environment.NewLine}" +
                                                         $"Downloading Abatab repository from:{Environment.NewLine}" +
                                                         $"  {src}";

        private static string ExtractMsg(string repoZip, string dir) => $"{Environment.NewLine}" +
                                                                        $"Extracting {repoZip} to {dir}...{Environment.NewLine}";
        internal static string DebugMsg() => $"**************{Environment.NewLine}" +
                                             $"  DEBUG INFO{Environment.NewLine}" +
                                             $"**************{Environment.NewLine}" +
                                             $"      Version: {LtntVersion}{Environment.NewLine}" +
                                             $"         Root: {LtntRoot}{Environment.NewLine}" +
                                             $"      BaseUrl: {RepoUrl}{Environment.NewLine}" +
                                             $"DefaultBranch: {DefaultBranch}{Environment.NewLine}" +
                                             $" TargetBranch: {TargetBranch}{Environment.NewLine}" +
                                             $"      LogFile: {LogFile}{Environment.NewLine}" +
                                             $"         Root: {LtntDirs["Root"]}{Environment.NewLine}" +
                                             $"         Logs: {LtntDirs["Logs"]}{Environment.NewLine}" +
                                             $"         Temp: {LtntDirs["Temp"]}{Environment.NewLine}" +
                                             $"          Bin: {LtntDirs["bin"]}{Environment.NewLine}" +
                                             $"       Branch: {RepoInfo["Branch"]}{Environment.NewLine}" +
                                             $"       Source: {RepoInfo["Source"]}{Environment.NewLine}" +
                                             $"          Url: {RepoInfo["Url"]}{Environment.NewLine}";
    }
}