// AbatabLieutenant.Catalog.cs
// b---------x
// (c) A Pretty Cool Program

namespace AbatabLieutenant
{
    public static class Catalog
    {
        public static string HelpDetail(string ltntVersion, string validBranches) =>
            $"{HelpHeader(ltntVersion)}"+
            $"{HelpBody(validBranches)}";

        public static string SessionDetail(LtntSession ltntSession) =>
            $"{LogHeader()}" +
            $"{SessionBody(ltntSession)}";

        private static string HelpHeader(string ltntVersion) =>
            $"{Environment.NewLine}" +
            $"======================{Environment.NewLine}" +
            $"Abatab Lieutenant Help{Environment.NewLine}" +
            $"======== v{ltntVersion} ========{Environment.NewLine}";

        private static string HelpBody(string validBranches) =>
            $"{Environment.NewLine}" +
            $"Syntax:           $ AbatabLieutenant <branch>{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Valid branches:   {validBranches}{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Example:          $ AbatabLieutenant testing{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"More information: https://github.com/spectrum-health-systems/AbatabLieutenant{Environment.NewLine}" +
            $"{Environment.NewLine}";

        private static string LogHeader() =>
            $"{Environment.NewLine}" +
            $"================={Environment.NewLine}" +
            $"Abatab Lieutenant{Environment.NewLine}" +
            $"================={Environment.NewLine}";

        private static string SessionBody(LtntSession ltntSession) =>
            $"Version:             {ltntSession.LtntVersion}.{ltntSession.LtntBuild}{Environment.NewLine}" +
            $"Root:                {ltntSession.LtntRoot}{Environment.NewLine}" +
            $"Staging:             {ltntSession.LtntStagingDirectory}{Environment.NewLine}" +
            $"Log root:            {ltntSession.LtntLogRoot}{Environment.NewLine}" +
            $"Log path:            {ltntSession.LtntLogFilePath}{Environment.NewLine}" +
            $"Web service root:    {ltntSession.AbatabWebServiceRoot}{Environment.NewLine}" +
            $"Repository URL:      {ltntSession.AbatabRepositoryUrl}{Environment.NewLine}" +
            $"RepositoryZIP URL:   {ltntSession.AbatabRepositoryZipUrl}{Environment.NewLine}" +
            $"RepositoryRAW URL:   {ltntSession.AbatabRepositoryRawUrl}{Environment.NewLine}" +
            $"Branch:              {ltntSession.RequestedBranch}{Environment.NewLine}" +
            $"Branch URL:          {ltntSession.RequestedBranchUrl}{Environment.NewLine}" +
            $"BranchZIP URL:       {ltntSession.RequestedBranchZipUrl}{Environment.NewLine}" +
            $"BranchRaw URL:       {ltntSession.RequestedBranchRawUrl}{Environment.NewLine}" +
            $"Date/Time:           {ltntSession.Datestamp}-{ltntSession.Timestamp}{Environment.NewLine}" +
            $"Valid branches:      {string.Join($", ", ltntSession.ValidBranches)}{Environment.NewLine}" +
            $"Web service files:   {string.Join($", ", ltntSession.WebServiceFiles)}{Environment.NewLine}" +
            $"Web service folders: {string.Join($", ", ltntSession.WebServiceFolders)}{Environment.NewLine}" +
            $"{Environment.NewLine}";

        private static string LogFooter(string ltntVersion, string ltntBuild) =>
           $"[ Abatab Lieutentant v{ltntVersion}.{ltntBuild} ]{Environment.NewLine}";
    }
}