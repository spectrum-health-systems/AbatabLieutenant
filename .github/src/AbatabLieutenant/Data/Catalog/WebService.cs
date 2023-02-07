// AbatabLieutenant.Data.Catalog.WebService.cs
// Catalog for the web service.
// b---

namespace AbatabLieutenant.Data.Catalog
{
    public class WebService
    {
        /// <summary>TBD</summary>
        /// <returns></returns>
        public static List<string> ServiceFiles() => new List<string>
        {
            "Abatab.asmx",
            "Abatab.asmx.cs",
            "packages.config",
            "Web.config",
            "Web.Debug.config",
            "Web.Release.config"
        };
    }
}
