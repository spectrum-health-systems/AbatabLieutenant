// AbatabLieutenant.Flightpath.Starter.cs
// Handles Abatab Lieutenant startup processes.
// b---


using AbatabLieutenant.Session;

using System.IO.Compression;

namespace AbatabLieutenant.Flightpath
{
    /// <summary>Abatab Lieutenant startup processes.</summary>
    internal class Starter
    {
        /// <summary></summary>
        /// <param name="args"></param>
        public static void ParseArguments(string[] args)
        {
            if ((args.Length > 0) && Data.Catalog.CommandLine.ValidArguments().Contains(args[0]))
            {
                Logger.LogEvent.ToConsole(Data.Catalog.Log.LtntStartMessage(Properties.Resources.LtntVersion));

                SessionData ltntSession = SessionData.Build(args[0]);

                Framework.Verify.Components(ltntSession);

                Backup.Deployment.Current(ltntSession);

                Deployment.PrepareTarget(ltntSession.AbatabDeploymentRoot, ltntSession.LogFileName);

                Roundhouse.ParseRequest("", "", "", "");

            }
            else
            {
                DisplayHelp.ToConsole(Data.Catalog.Help.HelpMsg(Properties.Resources.LtntVersion));
            }
        }

        public static void DeployBranch(SessionData ltntSession)
        {
            ZipFile.ExtractToDirectory($@"{ltntSession.LtntDirectories["Temp"]}\Abatab-{ltntSession.RequestedBranch}.zip", ltntSession.LtntDirectories["Temp"]);
        }
    }
}
