//
//
//

namespace AbatabLieutenant.Framework
{
    internal class Catalog
    {
        /// <summary>TBD</summary>
        /// <returns></returns>
        public static Dictionary<string, string> LtntDirectories(string ltntRoot, string dateTimeStamp) => new Dictionary<string, string>
        {
            { "Root",       $@"{ltntRoot}" },
            { "Logs",       $@"{ltntRoot}\Logs" },
            { "Current",    $@"{ltntRoot}\Deployment\{dateTimeStamp}\Current" },
            //{ "CurrentBin", $@"{ltntRoot}\Deployment\{dateTimeStamp}\Current\Bin" }, // TODO - Need?
            { "Archive",   $@"{ltntRoot}\Deployment\{dateTimeStamp}\Archive" },
            { "Temp",    $@"{ltntRoot}\Deployment\{dateTimeStamp}\Temp" },
        };

        ///// <summary>TBD</summary>
        ///// <returns></returns>
        //public static Dictionary<string, string> DeploymentDirectories(string ltntRoot, string dateTimeStamp) => new Dictionary<string, string>
        //{
        //    { "Current",    $@"{ltntRoot}\Deployment\{dateTimeStamp}\Current" },
        //    { "CurrentBin", $@"{ltntRoot}\Deployment\{dateTimeStamp}\Current\Bin" },
        //    { "Previous",   $@"{ltntRoot}\Deployment\{dateTimeStamp}\Previous" },
        //    { "Staging",    $@"{ltntRoot}\Deployment\{dateTimeStamp}\Staging" },
        //};
    }
}
