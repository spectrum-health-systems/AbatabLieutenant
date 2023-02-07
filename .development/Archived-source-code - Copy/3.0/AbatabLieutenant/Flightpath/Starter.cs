// AbatabLieutenant.Flightpath.Starter.cs
// Handles Abatab Lieutenant startup processes.
// b---


using AbatabLieutenant.Session;

using System.IO.Compression;

namespace AbatabLieutenant.Flightpath
{
    /// <summary>Abatab Lieutenant startup processes.</summary>
    internal class Starter
    {


        public static void DeployBranch(SessionData ltntSession)
        {
            ZipFile.ExtractToDirectory($@"{ltntSession.LtntDirectories["Temp"]}\Abatab-{ltntSession.RequestedBranch}.zip", ltntSession.LtntDirectories["Temp"]);
        }
    }
}
