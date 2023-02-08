// b230208.0924

namespace AbatabLieutenant.InterWeb
{
    /// <summary>TBD</summary>
    internal static class Downloader
    {
        /// <summary>TBD</summary>
        /// <param name="sourceUrl"></param>
        /// <param name="destination"></param>
        public static void FromUrl(string sourceUrl, string destination)
        {
            System.Net.WebClient webClient = new();
            webClient.DownloadFile(sourceUrl, destination);
        }
    }
}