// =============================== Version 4.3.0 ===============================
// Abatab Lieutenant: A command line deployment utility for Abatab.
// https://github.com/spectrum-health-systems/AbatabLieutenant
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
//
// For details about this release, please see the local Source Code README.md:
//   Abatab/README.md
// =============================================================================

// b240319.0913

namespace AbatabLieutenant
{
    /// <summary>Entry point for Abatab Lieutenant</summary>
    internal static class Program
    {
        /// <summary>The magic starts here!</summary>
        /// <param name="commandArguments">The arguments sent via the command line.</param>
        static void Main(string[] commandArguments)
        {
            Console.Clear();

            var ltSession = LtSession.LoadLocalSettings();

            if (commandArguments.Length > 0 && ltSession.ValidBranches.Contains(commandArguments[0]))
            {
                LtSession.CreateRuntimeSettings(ltSession, commandArguments);

                Utilities.VerifyFramework(ltSession.AbatabDataFolders, ltSession.LogPath);

                Deploy.WebService(ltSession);

                Utilities.WriteLog($"{Environment.NewLine}Deployment complete!", ltSession.LogPath);
            }
            else
            {
                Console.WriteLine(Catalog.HelpDetail(ltSession.LtVer, string.Join(", ", ltSession.ValidBranches)));
            }
        }
    }
}