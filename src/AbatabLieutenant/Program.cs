/*************************************************************************
 * Abatab Lieutenant v4.0.0-development+230307.0850
 * A command line deployment utility for Abatab
 * https://github.com/spectrum-health-systems/AbatabLieutenant
 ************************************************************************/

// AbatabLieutenant.Program.cs
// b---------x
// (c) A Pretty Cool Program

namespace AbatabLieutenant
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Utilities.WriteLog("Debug-1...", @"C:\AbatabData\Lieutenant\Logs\debug-1.log");
            Console.Clear();

            var ltntSession = LtntSession.LoadLocalFile("AbatabLieutenantSettings.json");

            Utilities.WriteLog("Debug-2...", @"C:\AbatabData\Lieutenant\Logs\debug-2.log");

            if (args.Length > 0 && ltntSession.ValidBranches.Contains(args[0]))
            {
                LtntSession.CreateRuntimeSettings(ltntSession, args[0]);
                Utilities.WriteLog(Catalog.SessionDetail(ltntSession), @"C:\AbatabData\Lieutenant\Logs\debug-3.log");

                Utilities.VerifyRequirements(ltntSession.AbatabDataRequiredDirectories, ltntSession.LtntLogFilePath);

                Utilities.WriteLog(Catalog.SessionDetail(ltntSession), @"C:\AbatabData\Lieutenant\Logs\debug-4.log");

                Deploy.WebService(ltntSession);

                Utilities.WriteLog(Catalog.SessionDetail(ltntSession), @"C:\AbatabData\Lieutenant\Logs\debug-5.log");
            }
            else
            {
                Console.WriteLine(Catalog.HelpDetail(ltntSession.LtntVersion, string.Join(", ", ltntSession.ValidBranches)));
            }
        }
    }
}