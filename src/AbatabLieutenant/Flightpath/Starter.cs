// b---

using AbatabLieutenant.Session;

namespace AbatabLieutenant.Flightpath
{
    /// <summary>Abatab Lieutenant startup processes.</summary>
    internal static class Starter
    {
        /// <summary>TBD</summary>
        /// <param name="args"></param>
        public static void Launch(string[] args)
        {
            if ((args.Length > 0) && CommandLine.Catalog.ValidArguments().Contains(args[0]))
            {
                Run(args[0]);
            }
            else
            {
                Console.WriteLine(Helper.Catalog.HelpMsg(Properties.Resources.LtntVersion));
            }
        }

        /// <summary>TBD</summary>
        /// <param name="requestedBranch"></param>
        private static void Run(string requestedBranch)
        {
            SessionData ltntSession = SessionData.Build(requestedBranch);

            Framework.Components.VerifyDirectories(ltntSession.LtntDirectories, ltntSession.LogFilePath);

            Deployment.Prepare.RefreshDirectories(ltntSession.SessionDirectories, ltntSession.LogFilePath);

            Deployment.Download.FromUrl(requestedBranch, ltntSession.RepositoryBranchUrl, ltntSession.SessionDirectories["Temp"], ltntSession.LogFilePath);

            Compressioner.Extractor.BranchArchive($@"{ltntSession.SessionDirectories["Temp"]}\Abatab-{requestedBranch}.zip", ltntSession.SessionDirectories["Staging"], ltntSession.LogFilePath);

            OpSys.Copier.CopyDir($@"{ltntSession.SessionDirectories["Staging"]}\Abatab-{requestedBranch}\src\bin", $@"{ltntSession.SessionDirectories["Deployment"]}\bin", ltntSession.LogFilePath);

            OpSys.Copier.CopyService($@"{ltntSession.SessionDirectories["Staging"]}\Abatab-{requestedBranch}\src", ltntSession.SessionDirectories["Deployment"], ltntSession.ServiceFiles, ltntSession.LogFilePath);
        }
    }
}