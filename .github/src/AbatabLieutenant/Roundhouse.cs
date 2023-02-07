namespace AbatabLieutenant
{
    internal class Roundhouse
    {
        public static void ParseRequest(string branchUrl, string deploymentDirectory, string requestedBranch, string logFileName)
        {
            // Build session details
            //var ltntSession              = Session.SessionData.Build(requestedBranch);



            switch (requestedBranch)
            {
                case "development":
                    Branch.Download.FromUrl(branchUrl, deploymentDirectory, requestedBranch, logFileName);
                    break;

                case "experimental":
                    //DownloadExperimentalBranch(requestedBranch);
                    break;

                case "main":
                    //DownloadMainBranch(requestedBranch);
                    break;

                case "testing":
                    //DownloadTestingBranch(requestedBranch);
                    break;

                default: // Technically this shouldn't be reached.
                    //Stareter.Finisher(1, $"Invalid branch: {requestedBranch}");
                    break;
            }

            //DeployBranch(ltntSession);

            //Logger.LogEventToFile(ltntSession.LogFileContents, ltntSession.LogFileName);

        }
    }
}
