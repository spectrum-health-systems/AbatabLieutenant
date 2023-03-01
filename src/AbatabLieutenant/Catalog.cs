namespace AbatabLieutenant
{
    public class Catalog
    {
        public static string HelpDetail(string ltntVersion, string validBranches) =>
            $"{Environment.NewLine}" +
            $"======================{Environment.NewLine}" +
            $"Abatab Lieutenant Help{Environment.NewLine}" +
            $"======== v{ltntVersion} ========{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Syntax:{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"    $ AbatabLieutenant <branch>{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Valid branches:{Environment.NewLine}" +
            $"{validBranches}{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Example:{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"    $ AbatabLieutenant.exe testing     <- Deploys the testing branch of Abatab{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"    $ AbatabLieutenant.exe development <- Deploys the development branch of Abatab{Environment.NewLine}" +
            $"{Environment.NewLine}";

        public static string LogHeader(LtntSession ltntSession) =>
            $"{Environment.NewLine}" +
            $"================={Environment.NewLine}" +
            $"Abatab Lieutenant{Environment.NewLine}" +
            $"================={Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{LogDetail(ltntSession)}{Environment.NewLine}";

        private static string LogDetail(LtntSession ltntSession) =>
            $"Abatab Lieutenant root:  {ltntSession.AbatabLieutenantRoot}{Environment.NewLine}" +
            $"Abatab web service root: {ltntSession.AbatabWebServiceRoot}{Environment.NewLine}" +
            $"Abatab Repository URL:   {ltntSession.AbatabRepositoryUrl}{Environment.NewLine}" +
            $"Requested branch:        {ltntSession.RequestedBranch}{Environment.NewLine}" +
            $"Requested branch URL:    {ltntSession.RepositoryBranchUrl}{Environment.NewLine}" +
            $"Valid branches:          {Utility.ListToString(ltntSession.ValidBranches)}{Environment.NewLine}" +
            $"Web service files:       {Utility.ListToString(ltntSession.WebServiceFiles)}{Environment.NewLine}" +
            $"Web service folders:     {Utility.ListToString(ltntSession.WebServiceFolders)}{Environment.NewLine}" +
            $"{Environment.NewLine}";

        private static string LogFooter(LtntSession ltntSession) =>
           $"[{ltntSession.AbatabLieutenantVersion}.{ltntSession.AbatabLieutenantBuild} | {ltntSession.Datestamp}.{ltntSession.Timestamp}]{Environment.NewLine}";
    }
}