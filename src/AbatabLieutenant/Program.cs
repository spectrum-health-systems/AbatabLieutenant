/*************************************************************************
 * Abatab Lieutenant v4.0.0+230308.0939
 * A command line deployment utility for Abatab.
 * https://github.com/spectrum-health-systems/AbatabLieutenant
 ************************************************************************/

// AbatabLieutenant.Program.cs
// b230308.0939
// (c) A Pretty Cool Program

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

            var ltSession = LtSession.LoadLocalSettings("AbatabLieutenant.json");

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