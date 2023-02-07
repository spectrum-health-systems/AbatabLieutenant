namespace AbatabLieutenant.Flightpath
{
    internal class Finisher
    {
        public static void Cleanup(int exitCode, string exitMsg = "Exiting Abatab Lieutenant....")
        {
            ExitApp(exitCode, exitMsg);
        }


        /// <summary>TBD</summary>
        /// <param name="exitCode"></param>
        /// <param name="exitMsg"></param>
        private static void ExitApp(int exitCode, string exitMsg = "Exiting Abatab Lieutenant....")
        {
            switch (exitCode)
            {
                case 1: // Write a message to both the console and a logfile, then exit gracefully.
                    Console.WriteLine(exitMsg);
                    // Logging logic
                    System.Environment.Exit(2);
                    break;

                case 0: // Write a message to the console, then exit gracefully.
                default:
                    Console.WriteLine(exitMsg);
                    System.Environment.Exit(0);
                    break;
            }
        }
    }
}
