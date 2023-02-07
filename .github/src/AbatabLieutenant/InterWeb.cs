namespace AbatabLieutenant
{
    public class InterWeb
    {
        public static void DownloadFromUrl(string sourceUrl, string destination)
        {
            System.Net.WebClient webClient = new();
            webClient.DownloadFile(sourceUrl, destination);
        }
    }
}
