// AbatabLieutenant.Validate.cs
// Logic for command line arguments.
// b---

namespace Abacab
{
    public static class Validate
    {
        //public static void LtntFramework(Dictionary<string, string> ltntDirectories, string ltntLogFileContents)
        //{
        //    foreach (var ltntDirectory in ltntDirectories)
        //    {
        //        var logMsgPre = $@"Verifying directory: {ltntDirectory.Value}...";
        //        ltntLogFileContents += logMsgPre;
        //        Logger.LogEventToConsole(logMsgPre);

        //        SystemMaintenance.ConfirmDirectoryExists(ltntDirectory.Value);
        //    }

        //    //SystemMaintenance.ConfirmDirectoryExists(ltntDirectories["Root"]);
        //    //SystemMaintenance.ConfirmDirectoryExists(ltntDirectories["Logs"]);
        //}


        /// <summary>Checks to see if an item exists in two lists.</summary>
        /// <param name="firstList">The first list of items.</param>
        /// <param name="secondList">The second list of items.</param>
        /// <returns>True/false.</returns>
        public static bool PassedArguments(string item, List<string> list)
        {
            return list.Contains(item);
        }
    }
}
