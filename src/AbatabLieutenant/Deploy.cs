namespace AbatabLieutenant
{
    internal class Deploy
    {
        public static void WebService(LtntSession ltntSession)
        {
            Utilities.WriteLog(Catalog.SessionDetail(ltntSession), @"C:\AbatabData\Lieutenant\Logs\debug-6.log");

            RefeshDeploymentDirectories(ltntSession.LtntStagingDirectory, ltntSession.AbatabWebServiceRoot, ltntSession.LtntLogFilePath);
            //Utilities.DownloadData(ltntSession.RepositoryBranchUrl, ltntSession.LtntStagingDirectory, ltntSession.LtntLogFilePath);

            Utilities.WriteLog(Catalog.SessionDetail(ltntSession), @"C:\AbatabData\Lieutenant\Logs\debug-7.log");

            var burl = "https://raw.githubusercontent.com/user/repository/branch/filename";

            foreach (var item in ltntSession.WebServiceFiles)
            {
                Utilities.WriteLog($"{ltntSession.RequestedBranchRawUrl}{item}", $@"C:\AbatabData\Lieutenant\Logs\debug-8-{item}.log");

                Utilities.DownloadData($"{ltntSession.RequestedBranchRawUrl}{item}", ltntSession.LtntStagingDirectory, ltntSession.LtntLogFilePath);
                Utilities.WriteLog(Catalog.SessionDetail(ltntSession), @"C:\AbatabData\Lieutenant\Logs\debug-100.log");
            }

            Utilities.WriteLog(Catalog.SessionDetail(ltntSession), @"C:\AbatabData\Lieutenant\Logs\debug-9.log");

            //Utilities.ExtractBranch(ltntSession.LtntStagingDirectory, ltntSession.RequestedBranch, ltntSession.LtntLogFilePath);
        }

        private static void RefeshDeploymentDirectories(string stagingDirectory, string webServiceRoot, string logFilePath)
        {
            Utilities.WriteLog("Debug-10", @"C:\AbatabData\Lieutenant\Logs\debug-10.log");
            Utilities.RefreshDirectory(stagingDirectory, logFilePath);
            Utilities.WriteLog("Debug-20", @"C:\AbatabData\Lieutenant\Logs\debug-20.log");
            Utilities.RefreshDirectory(webServiceRoot, logFilePath);

            Utilities.WriteLog("Debug-11", @"C:\AbatabData\Lieutenant\Logs\debug-11.log");
        }
    }
}


//public static void ExtractBranch(string source, string requestedBranch, string logFilePath)
//{
//    WriteLog("Extracting archive...", logFilePath);

//    ZipFile.ExtractToDirectory($@"{source}\Abatab-{requestedBranch}.zip", $@"{source}");
//}