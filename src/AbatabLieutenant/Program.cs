/* =============================================================================
 * Abatab Lieutenant: A command line deployment utility for Abatab.
 * v4.2.0.0
 * https://github.com/spectrum-health-systems/AbatabLieutenant)
 * -----------------------------------------------------------------------------
 * Developed by A Pretty Cool Program (https://github.com/APrettyCoolProgram)
 * Apache 2.0 (https://www.apache.org/licenses/LICENSE-2.0.html)
 * =============================================================================
 */

// b230705.1029

namespace AbatabLieutenant
{
    /// <summary>Entry point for Abatab Lieutenant</summary>
    internal static class Program
    {
        /// <summary>The magic starts here!</summary>
        /// <param name="commandArguments"></param>
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