// b---

namespace AbatabLieutenant.GitRepository
{
    /// <summary>TBD</summary>
    internal static class Catalog
    {
        /// <summary>TBD</summary>
        /// <param name="requestedBranch"></param>
        /// <returns></returns>
        public static Dictionary<string, string> RepositoryInformation(string timeStamp, string deploymentDirectory, string requestedBranch, string repositoryUrl) => new Dictionary<string, string>
        {
            { "Branch",      requestedBranch },
            { "BranchUrl",   $"{repositoryUrl}{requestedBranch}.zip" },
            { "DownloadTo",  $@"{deploymentDirectory}\{requestedBranch}.zip" }
        };
    }
}