using System;

namespace AbatabLieutenant.StockData
{
    public class StockMessage
    {
        /// <summary>TBD</summary>
        /// <param name="ltntVersion"></param>
        /// <param name="targetBranch"></param>
        /// <returns></returns>
        public static string LogHeader(string ltntVersion, string targetBranch) =>
           $"{Environment.NewLine}" +
           $"{Environment.NewLine}==========================" +
           $"{Environment.NewLine}Starting Abatab Lieutenant v{ltntVersion}{Environment.NewLine}" +
           $"=========================={Environment.NewLine}" +
           $"{Environment.NewLine}" +
           $"Deploying branch: {targetBranch}{Environment.NewLine}";

        /// <summary></summary>
        /// <returns></returns>
        public static string LogFooter() =>
            $"{Environment.NewLine}" +
            $"Process complete!{Environment.NewLine}" +
            $"{Environment.NewLine}";

        /// <summary>TBD</summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DownloadMsg(string url) =>
            $"{Environment.NewLine}" +
            $"Downloading Abatab repository from:{Environment.NewLine}" +
            $"  {url}";

        /// <summary>TBD</summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string ExtractMsg(string source, string target) =>
            $"{Environment.NewLine}" +
            $"Extracting {source} to {target}...{Environment.NewLine}";

        /// <summary>TBD</summary>
        /// <param name="msg"></param>
        /// <param name="newline"></param>
        /// <returns></returns>
        public static string FormatLogContent(string msg, bool newline) =>
            newline
                ? $"{Environment.NewLine}{msg}"
                : $"{msg}{Environment.NewLine}";

        /// <summary>TBD</summary>
        /// <param name="ltntVersion"></param>
        /// <returns></returns>
        public static string HelpMsg(string ltntVersion) =>
            $"{Environment.NewLine}" +
            $"==========================={Environment.NewLine}" +
            $"Abatab Lieutenant v{ltntVersion} Help{Environment.NewLine}" +
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
            $"         testing - Deploy the Abatab testing branch (default){Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Example:{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"    AbatabLieutenant.exe help" +
            $"{Environment.NewLine}";

        ///// <summary>TBD</summary>
        ///// <returns></returns>
        //public static string DebugMsg() =>
        //    $"**************{Environment.NewLine}" +
        //    $"  DEBUG INFO{Environment.NewLine}" +
        //    $"**************{Environment.NewLine}" +
        //    $"      Version: {LtntVersion}{Environment.NewLine}" +
        //    $"         Root: {LtntRoot}{Environment.NewLine}" +
        //    $"      BaseUrl: {RepoUrl}{Environment.NewLine}" +
        //    $"DefaultBranch: {DefaultBranch}{Environment.NewLine}" +
        //    $" TargetBranch: {TargetBranch}{Environment.NewLine}" +
        //    $"      LogFile: {LogFile}{Environment.NewLine}" +
        //    $"         Root: {LtntDirs["Root"]}{Environment.NewLine}" +
        //    $"         Logs: {LtntDirs["Logs"]}{Environment.NewLine}" +
        //    $"         Temp: {LtntDirs["Temp"]}{Environment.NewLine}" +
        //    $"          Bin: {LtntDirs["bin"]}{Environment.NewLine}" +
        //    $"       Branch: {RepoInfo["Branch"]}{Environment.NewLine}" +
        //    $"       Source: {RepoInfo["Source"]}{Environment.NewLine}" +
        //    $"          Url: {RepoInfo["Url"]}{Environment.NewLine}";


    }
}
