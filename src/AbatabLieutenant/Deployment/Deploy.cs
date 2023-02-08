// b230208.1510

using AbatabLieutenant.Session;

namespace AbatabLieutenant.Deployment
{
    internal class Deploy
    {
        public static void RequestedBranch(SessionData ltntSession)
        {
            Prepare.Refresh(ltntSession.LtntDirectories["Staging"], ltntSession.AbatabDeploymentRoot, ltntSession.LogFilePath);

            Download.FromUrl(ltntSession.RequestedBranch, ltntSession.RepositoryBranchUrl, ltntSession.LtntDirectories["Staging"], ltntSession.LogFilePath);

            Compressioner.Extractor.BranchArchive($@"{ltntSession.LtntDirectories["Staging"]}", ltntSession.RequestedBranch, ltntSession.LogFilePath);

            SysOp.Copier.CopyDir($@"{ltntSession.LtntDirectories["Staging"]}\Abatab-{ltntSession.RequestedBranch}\src\bin", $@"{ltntSession.AbatabDeploymentRoot}\bin", ltntSession.LogFilePath);

            SysOp.Copier.CopyService($@"{ltntSession.LtntDirectories["Staging"]}\Abatab-{ltntSession.RequestedBranch}\src", ltntSession.AbatabDeploymentRoot, ltntSession.ServiceFiles, ltntSession.LogFilePath);
        }


    }
}
