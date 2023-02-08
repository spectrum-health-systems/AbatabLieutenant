// b230208.0924

namespace AbatabLieutenant.Catalog
{
    /// <summary>TBD</summary>
    internal static class CommandLine
    {
        /// <summary>TBD</summary>
        /// <returns></returns>
        public static List<string> ValidArguments()
        {
            var validArguments = new List<string>()
            {
                "development",
                "experimental",
                "main",
                "testing",
            };

            if (!string.IsNullOrWhiteSpace(Properties.Resources.CustomRepository))
            {
                validArguments.Add(Properties.Resources.CustomRepository);
            }

            return validArguments;
        }
    }
}