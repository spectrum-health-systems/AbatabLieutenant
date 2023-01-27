namespace AbatabLieutenant.Data.Catalog
{
    public partial class Log
    {
        public static string LtntStartMessage(string ltntVersion) =>
            $"{Environment.NewLine}" +
            $"=========================={Environment.NewLine}" +
            $"Starting Abatab Lieutenant{Environment.NewLine}" +
            $"========= v{ltntVersion} ========={Environment.NewLine}" +
            $"{Environment.NewLine}";
    }
}
