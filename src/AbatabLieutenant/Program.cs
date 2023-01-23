/* Abatab Lieutenant 3.0
 * Abatab Lieutenant is a simple utility to help manage your Abatab deployments.
 *
 * For details on how to use Abatab Lieutenant in your environments, please see the README.md
 *   https://github.com/spectrum-health-systems/AbatabLieutenant#readme
 *
 * ---------------------------------------------
 * Copyright (c) A Pretty Cool Program
 * See the LICENSE.md file for more information.
 * ---------------------------------------------
 */

// Program.cs b230123.1333
// The main entry point for Abatab Lieutenant.

using AbatabLieutenant.LtntData;

namespace AbatabLieutenant
{
    internal class Program
    {
        public static Session LtntSession { get; set; }

        public static void Main(string[] args)
        {
            Console.Clear();
            Session lntnSession = new Session();

            if (args[0].Length != 0)
            {
                if (string.Equals(args[0], "help", StringComparison.OrdinalIgnoreCase))
                {
                    Help.ConsoleDisplay(Properties.Resources.LtntVersion);
                }
                else
                {
                    Go();
                }
            }
            else
            {

            }
        }

        private static void Go()
        {
            LtntSession = Session.InitializeSessionDetails();
            //UpdateSessionDetails();
        }


    }
}