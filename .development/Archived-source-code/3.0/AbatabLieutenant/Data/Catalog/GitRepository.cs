// AbatabLieutenant.Data.Catalog.GitRepository.cs
// Catalog for the git source code repository.
// b---

namespace AbatabLieutenant.Data.Catalog
{
    public class GitRepository
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
