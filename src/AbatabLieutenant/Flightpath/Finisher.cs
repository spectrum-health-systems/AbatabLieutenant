// b---

namespace AbatabLieutenant.Flightpath
{
    /// <summary>TBD</summary>
    internal static class Finisher
    {
        /// <summary>TBD</summary>
        /// <param name="exitCode"></param>
        /// <param name="exitMsg"></param>
        public static void ExitLtnt(int exitCode, string exitMsg = "Exiting Abatab Lieutenant....")
        {
            Cleanup();
            ExitApp(exitCode, exitMsg);
        }

        /// <summary>TBD</summary>
        /// <param name="exitCode"></param>
        /// <param name="exitMsg"></param>
        public static void Cleanup()
        {
            // TODO - cleanup code goes here.
        }

        /// <summary>TBD</summary>
        /// <param name="exitCode"></param>
        /// <param name="exitMsg"></param>
        public static void ExitApp(int exitCode, string exitMsg)
        {
            switch (exitCode)
            {
                case 1: // Write a message to both the console and a logfile, then exit gracefully.
                    Console.WriteLine($"{Environment.NewLine}{exitMsg}{Environment.NewLine}");
                    // Logging logic
                    System.Environment.Exit(2);
                    break;

                case 0: // Write a message to the console, then exit gracefully.
                default:
                    Console.WriteLine($"{Environment.NewLine}{exitMsg}{Environment.NewLine}");
                    System.Environment.Exit(0);
                    break;
            }
        }
    }
}
