// b230208.0924

using AbatabLieutenant.Session;

namespace AbatabLieutenant.Flightpath
{
    /// <summary>Abatab Lieutenant startup processes.</summary>
    internal static class Starter
    {
        /// <summary>Initial launch of Abatab Lieutenant.</summary>
        /// <param name="args">The arguments passed via the command line.</param>
        /// <remarks>
        /// If the user doesn't pass a valid argument, the help information is displayed.
        /// </remarks>
        public static void Launch(string[] args)
        {
            if ((args.Length > 0) && Catalog.CommandLine.ValidArguments().Contains(args[0]))
            {
                RunLtnt(args[0]);
            }
            else
            {
                Console.WriteLine(Helper.Catalog.HelpMsg(Properties.Resources.LtntVersion));
            }
        }

        /// <summary>Starts the actual work.</summary>
        /// <param name="requestedBranch">The requested branch passed via the command line.</param>
        private static void RunLtnt(string requestedBranch)
        {
            SessionData ltntSession = SessionData.Build(requestedBranch);

            Framework.Components.Initialize(ltntSession.LtntDirectories, ltntSession.LogFilePath);

            Deployment.Deploy.RequestedBranch(ltntSession);
        }
    }
}