// AbatabLieutenant.Data.Catalog.CommandLine.cs
// Catalog for Command Line.
// b---

namespace AbatabLieutenant.Data.Catalog
{
    public class CommandLine
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
