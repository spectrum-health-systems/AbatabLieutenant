// Abatab Lieutenant 2.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221208.0843

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

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
            Starter(args);
            DeployService();
            Finisher(1);
        }

        internal static void Starter(string[] args)
        {
            Console.Clear();
            PassedArgument = SetBranch(args);

            if (PassedArgument == "help")
            {
                Console.WriteLine(HelpMsg(Properties.Settings.Default.LtntVersion));
                Finisher(0);
            }
            else if (PassedArgument != "undefined")
            {
                BuildConfig();
                LogEvent(LogHeader());
                VerifyDirs();
            }
            else
            {
                Finisher(2, $"Invalid command: \"{args[0]}\". Exiting...");
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
            LogFile        = VerifyLogfile($@"{Properties.Settings.Default.LtntRoot}\Logs\Lieutenant");

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
                Console.WriteLine(DebugMsg());
        }

        internal static void VerifyDirs()
        {
            LogEvent("Verifying directories...", true);

            foreach (var dir in LtntDirs)
            {
                if (string.Equals(dir.Key, "logs", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (string.Equals(dir.Key, "root", StringComparison.OrdinalIgnoreCase))
                {
                    LogEvent($@"  {dir.Value}\", true);
                    RemoveFiles(dir.Value, ServiceFiles());
                    continue;
                }

                RefreshDir(dir.Value);
            }
        }

        internal static void DeployService()
        {
            DownloadArchive();
            ExtractArchive();
            CopyBin();
            CopyService();
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
            LogEvent("Copying bin/...");
            CopyDir($@"{LtntDirs["Temp"]}\Abatab-{PassedArgument}\src\bin\", $"{LtntDirs["bin"]}");
        }

        internal static void CopyDir(string source, string target)
        {
            RefreshDir(target);

            DirectoryInfo dirToCopy       = new DirectoryInfo(source);
            DirectoryInfo[] subDirsToCopy = GetSubDirs(source, target);

            foreach (FileInfo file in dirToCopy.GetFiles())
            {
                string targetPath = Path.Combine(target, file.Name);

                _=file.CopyTo(targetPath);
                LogEvent($"  {targetPath} copied.");
            }

            foreach (var (subDir, newTargetDir) in from DirectoryInfo subDir in subDirsToCopy
                                                   let newTargetDir = Path.Combine(target, subDir.Name)
                                                   select (subDir, newTargetDir))
            {
                CopyDir(subDir.FullName, newTargetDir);
            }
        }

        internal static void CopyService()
        {
            string source = $@"{LtntDirs["Temp"]}\Abatab-{TargetBranch}\src";
            string target = $"{LtntDirs["Root"]}";

            LogEvent($"{Environment.NewLine}Copying web service files...");

            foreach (string file in ServiceFiles())
            {
                if (File.Exists($@"{target}\{file}"))
                    File.Delete($@"{target}\{file}");

                File.Copy($@"{source}\{file}", $@"{target}\{file}");
                LogEvent($@"  {source}\{file} copied.");
            }
        }
        private static DirectoryInfo[] GetSubDirs(string source, string target)
        {
            DirectoryInfo dir = new DirectoryInfo(source);

            if (!dir.Exists)
            {
                _=Directory.CreateDirectory(target);
                LogEvent($"Directory {target} created.", true);
            }

            return dir.GetDirectories();
        }

        private static void RemoveFiles(string root, List<string> files)
        {
            foreach (var file in from file in files
                                 where File.Exists($"{root}/{file}")
                                 select file)
            {
                File.Delete($"{root}/{file}");
            }
        }
        internal static string SetBranch(string[] args) =>
            args.Length == 0
                ? Properties.Settings.Default.DefaultBranch
                : VerifyArg(args[0])
                    ? args[0]
                    : "undefined";

        internal static bool VerifyArg(string arg) =>
            ValidArgs().Contains($"{arg}");

        private static void RefreshDir(string dir)
        {
            if (Directory.Exists(dir))
                Directory.Delete(dir, true);

            _=Directory.CreateDirectory(dir);
            LogEvent($"  {dir}", true);
        }

        internal static void LogEvent(string msg, bool newline = false)
        {
            Console.WriteLine(msg);
            File.AppendAllText(LogFile, FormatLogContent(msg, newline));
        }

        internal static void Finisher(int code, string msg = "Exiting Abatab Lieutenant.")
        {
            switch (code)
            {
                case 1:
                    LogEvent(LogFooter(), true);
                    Environment.Exit(1);
                    break;

                case 2:
                    Console.WriteLine(msg);
                    Environment.Exit(2);
                    break;

                case 0:
                default:
                    Console.WriteLine(msg);
                    Environment.Exit(0);
                    break;
            }
        }

        private static List<string> ServiceFiles() =>
            new List<string>
            {
                "Abatab.asmx",
                "Abatab.asmx.cs",
                "packages.config",
                "Web.config",
                "Web.Debug.config",
                "Web.Release.config"
            };

        private static List<string> ValidArgs() =>
            new List<string>
            {
                "development",
                "experimental",
                "help",
                "main",
                "testbuild"
            };

        internal static string BuildUrl(string baseUrl, string branch) =>
            $"{baseUrl}{branch}.zip";

        internal static string VerifyLogfile(string dir)
        {
            if (!Directory.Exists(dir))
                _=Directory.CreateDirectory(dir);

            return $@"{dir}\{DateTime.Now.ToString("yyMMdd.HHmmss")}.ltnt";
        }

        private static string LogHeader() =>
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}==========================" +
            $"{Environment.NewLine}Starting Abatab Lieutenant v{LtntVersion}{Environment.NewLine}" +
            $"=========================={Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Deploying branch: {TargetBranch}{Environment.NewLine}";

        private static string LogFooter() =>
            $"{Environment.NewLine}" +
            $"Process complete!{Environment.NewLine}" +
            $"{Environment.NewLine}";

        private static string DownloadMsg(string url) =>
            $"{Environment.NewLine}" +
            $"Downloading Abatab repository from:{Environment.NewLine}" +
            $"  {url}";

        private static string ExtractMsg(string source, string target) =>
            $"{Environment.NewLine}" +
            $"Extracting {source} to {target}...{Environment.NewLine}";

        internal static string FormatLogContent(string msg, bool newline) =>
            newline
                ? $"{Environment.NewLine}{msg}"
                : $"{msg}{Environment.NewLine}";

        private static string HelpMsg(string ver) =>
            $"{Environment.NewLine}" +
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
            $"       testbuild - Deploy the Abatab testbuild branch (default){Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Example:{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"    AbatabLieutenant.exe help" +
            $"{Environment.NewLine}";

        internal static string DebugMsg() =>
            $"**************{Environment.NewLine}" +
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