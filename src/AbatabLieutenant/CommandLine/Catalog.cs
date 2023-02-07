// b---

namespace AbatabLieutenant.CommandLine
{
    /// <summary>TBD</summary>
    internal static class Catalog
    {
        /// <summary>TBD</summary>
        /// <returns></returns>
        public static List<string> ValidArguments() => new()
        {
            "development",
            "experimental",
            "main",
            "testing"
        };
    }
}