// AbatabLieutenant.Flightpath.cs
// Logic workflow for Abatab Lieutenant.
// b---

using Abacab;

using AbatabLieutenant.Data;


namespace AbatabLieutenant
{
    /// <summary>TBD</summary>
    public class Flightpath
    {
        /// <summary>TBD</summary>
        /// <param name="args"></param>
        public static void Starter(string[] args)
        {
            if ((args.Length > 0) && (Catalog_old.ValidArguments().Contains(args[0])))
            {
                Logger.LogEvent(Data.Catalog.Log.LtntStartMessage(Properties.Resources.LtntVersion));
                Deploy.Roundhouse(args[0]);
            }
            else
            {
                DisplayHelp.ToConsole(Data.Catalog.Help.HelpMsg(Properties.Resources.LtntVersion));
            }
        }

        /// <summary>TBD</summary>
        /// <param name="exitCode"></param>
        /// <param name="exitMsg"></param>
        public static void Finisher(int exitCode, string exitMsg = "Exiting Abatab Lieutenant....")
        {
            switch (exitCode)
            {
                case 1: // Write a message to the command line, then exit gracefully.
                    Console.WriteLine(exitMsg);
                    System.Environment.Exit(1);
                    break;

                case 2: // Write a message to a logfile, then exit gracefully.
                    // Logging logic
                    System.Environment.Exit(2);
                    break;

                case 0: // Standard graceful exit.
                default:
                    Console.WriteLine(exitMsg);
                    System.Environment.Exit(0);
                    break;
            }
        }
    }
}