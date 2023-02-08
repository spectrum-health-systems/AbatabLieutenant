// b230208.0924

using AbatabLieutenant.Session;

namespace AbatabLieutenant.Deployment
{
    internal class Deploy
    {
        public static void RequestedBranch(SessionData ltntSession)
        {
            Deployment.Prepare.RefreshDirectories(ltntSession.SessionDirectories, ltntSession.LogFilePath);

            Deployment.Download.FromUrl(ltntSession.RequestedBranch, ltntSession.RepositoryBranchUrl, ltntSession.SessionDirectories["Temp"], ltntSession.LogFilePath);

            Compressioner.Extractor.BranchArchive($@"{ltntSession.SessionDirectories["Temp"]}\Abatab-{ltntSession.RequestedBranch}.zip", ltntSession.SessionDirectories["Staging"], ltntSession.LogFilePath);

            SysOp.Copier.CopyDir($@"{ltntSession.SessionDirectories["Staging"]}\Abatab-{ltntSession.RequestedBranch}\src\bin", $@"{ltntSession.SessionDirectories["Deployment"]}\bin", ltntSession.LogFilePath);

            SysOp.Copier.CopyService($@"{ltntSession.SessionDirectories["Staging"]}\Abatab-{ltntSession.RequestedBranch}\src", ltntSession.SessionDirectories["Deployment"], ltntSession.ServiceFiles, ltntSession.LogFilePath);
        }


    }
}
