/* Abatab Lieutenant 3.0.0+230207.1144
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
    /// <summary>Main entry point for Abatab Lieutenant.</summary>
    internal class Program
    {
        /// <summary>The Abatab Lieutenant entry point.</summary>
        /// <param name="args">Arguments passed via the command line.</param>
        public static void Main(string[] args)
        {
            Console.Clear();

            Flightpath.Starter.ParseArguments(args);

            Flightpath.Finisher.Cleanup(0);
        }
    }
}