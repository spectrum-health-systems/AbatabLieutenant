using AbatabLieutenant.Session;

using System.IO.Compression;

namespace AbatabLieutenant.Flightpath
{
    internal class Starter
    {
        /// <summary>TBD</summary>
        /// <param name="args"></param>
        public static void InitialContact(string[] args)
        {
            if ((args.Length > 0) && Data.Catalog.CommandLine.ValidArguments().Contains(args[0]))
            {
                Logger.LogEventToConsole(Data.Catalog.Log.LtntStartMessage(Properties.Resources.LtntVersion));

                SessionData ltntSession = SessionData.Build(args[0]);

                Framework.Initialize(ltntSession.LtntDirectories, ltntSession.AbatabDeploymentRoot, ltntSession.DeploymentDirectories, ltntSession.LogFileName);

                Backup.CurrentDeployment(ltntSession.AbatabDeploymentRoot, ltntSession.DeploymentDirectories["Previous"], ltntSession.LogFileName);

                Deployment.PrepareTarget(ltntSession.AbatabDeploymentRoot, ltntSession.LogFileName);

                Roundhouse.ParseRequest("", "", "", "");

            }
            else
            {
                DisplayHelp.ToConsole(Data.Catalog.Help.HelpMsg(Properties.Resources.LtntVersion));

            }

            // TODO - Might want to give both branches their own exit.
            Flightpath.Finisher.ExitApp(0);
        }

        public static void DeployBranch(SessionData ltntSession)
        {
            ZipFile.ExtractToDirectory($@"{ltntSession.DeploymentDirectories["Staging"]}\Abatab-{ltntSession.RequestedBranch}.zip", ltntSession.DeploymentDirectories["Staging"]);
        }
    }
}
