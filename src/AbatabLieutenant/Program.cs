/* Abatab Lieutenant 3.0
 * Abatab Lieutenant is a simple utility to help manage your Abatab deployments.
 *
 * For details on how to use Abatab Lieutenant in your environments, please see the README.md
 *   https://github.com/spectrum-health-systems/AbatabLieutenant#readme
 *
 * ---------------------------------------------
 * Copyright (c) A Pretty Cool Program 2023
 * See the LICENSE.md file for more information.
 * ---------------------------------------------
 */

// AbatabLieutentant.Program.cs
// The main entry point for Abatab Lieutenant.
// b---

namespace AbatabLieutenant
{
    /// <summary>TBD</summary>
    internal class Program
    {
        /// <summary>TBD</summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.Clear();

            Flightpath.Starter(args);

            Flightpath.Finisher(0);
        }
    }
}