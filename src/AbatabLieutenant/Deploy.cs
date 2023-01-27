// AbatabLieutenant.Deploy.cs
// Abatab branch deployment logic.
// b---

namespace AbatabLieutenant
{
    /// <summary>TBD</summary>
    internal class Deploy
    {
        /// <summary>TBD</summary>
        /// <param name="passedArguments"></param>
        public static void Roundhouse(string requestedBranch)
        {
            //Logger.LogEvent(AbatabLieutenant.Data.Catalog.Logger.LogStartMessage());


            var ltntSession = Session.BuildSessionData(requestedBranch);
            Framework.InitializeDeploymentTarget(ltntSession.LtntDirectories, ltntSession.DateTimeStamp);



            switch (requestedBranch)
            {
                case "development":
                    DevelopmentBranch(requestedBranch);
                    break;

                case "experimental":
                    ExperimentalBranch(requestedBranch);
                    break;

                case "main":
                    MainBranch(requestedBranch);
                    break;

                case "testing":
                    TestingBranch(requestedBranch);
                    break;

                default: // Technically this shouldn't be reached.
                    Flightpath.Finisher(1, $"Invalid branch: {requestedBranch}");
                    break;

            }
        }

        /// <summary>TBD</summary>
        /// <param name="ltntSession"></param>
        private static void DevelopmentBranch(string requestedBranch)
        {
            Console.WriteLine("Dev"); // Debugging - remove for release.
            //var ltntSession = Session.BuildSessionData(requestedBranch);
            //Verify.Framework(ltntSession.LtntDirectories);
        }

        /// <summary>TBD</summary>
        /// <param name="ltntSession"></param>
        private static void ExperimentalBranch(string requestedBranch)
        {
            Console.WriteLine("Ex");
        }

        /// <summary>TBD</summary>
        /// <param name="ltntSession"></param>
        private static void MainBranch(string requestedBranch)
        {
            Console.WriteLine("M");
        }

        /// <summary>TBD</summary>
        /// <param name="ltntSession"></param>
        private static void TestingBranch(string requestedBranch)
        {
            Console.WriteLine("Test");
        }
    }
}
