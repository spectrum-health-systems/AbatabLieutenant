/* Abatab Lieutenant 3.0.0-rc1+230209.0737
 * Abatab deployment utility.
 *
 * For details on how to use Abatab Lieutenant in your environments, please see the README.md
 *   https://github.com/spectrum-health-systems/AbatabLieutenant#readme
 *
 * ---------------------------------------------
 * Copyright (c) A Pretty Cool Program 2023
 * See the LICENSE.md file for more information.
 * ---------------------------------------------
 */

// b230209.0737

namespace AbatabLieutenant
{
    /// <summary>Main entry point for Abatab Lieutenant.</summary>
    internal static class Program
    {
        /// <summary>Starts the Abatab Lieutenant processes.</summary>
        /// <param name="args">The argument(s) passed via the command line.</param>
        static void Main(string[] args)
        {
            Console.Clear();

            Flightpath.Starter.Launch(args);

            Flightpath.Finisher.ExitLtnt(0, $"Exiting Abatab Lieutenant...{Environment.NewLine}");
        }
    }
}