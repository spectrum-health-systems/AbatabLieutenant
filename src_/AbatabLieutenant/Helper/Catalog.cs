// b230213.0854

namespace AbatabLieutenant.Helper
{
    /// <summary>TBD</summary>
    internal class Catalog
    {
        /// <summary>TBD</summary>
        /// <param name="ltntVersion"></param>
        /// <returns></returns>
        public static string HelpMsg(string ltntVersion) =>
            $"{Environment.NewLine}" +
            $"======================{Environment.NewLine}" +
            $"Abatab Lieutenant Help{Environment.NewLine}" +
            $"======= v{ltntVersion} ======={Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Syntax:{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"    $ AbatabLieutenant <command>{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Valid commands:{System.Environment.NewLine}" +
            $"{System.Environment.NewLine}" +
            $"     development - Deploy the Abatab development branch{Environment.NewLine}" +
            $"            main - Deploy the Abatab main branch{Environment.NewLine}" +
            $"         testing - Deploy the Abatab testing branch{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Example:{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"    $ AbatabLieutenant.exe testing     <- Deploys the testing branch of Abatab{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"    $ AbatabLieutenant.exe development <- Deploys the development branch of Abatab{Environment.NewLine}" +
            $"{Environment.NewLine}";
    }
}