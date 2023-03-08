// AbatabLieutenant.Catalog.cs
// b230308.0939
// (c) A Pretty Cool Program

namespace AbatabLieutenant
{
    /// <summary>Contains pre-defined data/information.</summary>
    public static class Catalog
    {
        /// <summary>The help detail that is displayed to the user.</summary>
        /// <param name="ltVer">The Abatab Lieutenant version.</param>
        /// <param name="validBranches">The list of valid Abatab branches.</param>
        /// <returns>The help detail for display.</returns>
        public static string HelpDetail(string ltVer, string validBranches) =>
            $"{HelpHeader(ltVer)}"+
            $"{HelpBody(validBranches)}";

        /// <summary>Create the help detail body.</summary>
        /// <param name="validBranches">The list of valid Abatab branches.</param>
        /// <returns>The help detail body.</returns>
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

        /// <summary>Create the help detail header.</summary>
        /// <param name="ltVer">The Abatab Lieutenant version.</param>
        /// <returns>The help detail header.</returns>
        private static string HelpHeader(string ltVer) =>
            $"{Environment.NewLine}" +
            $"======================{Environment.NewLine}" +
            $"Abatab Lieutenant Help{Environment.NewLine}" +
            $"======== v{ltVer} ========{Environment.NewLine}";

        /// <summary>All of the details for this session.</summary>
        /// <param name="ltSession">The session object.</param>
        /// <returns>The session details, for display and logging.</returns>
        public static string SessionDetail(LtSession ltSession) =>
            $"{LogHeader()}" +
            $"{SessionBody(ltSession)}";

        /// <summary>Create the header for log files.</summary>
        /// <returns>The header for log files.</returns>
        private static string LogHeader() =>
            $"{Environment.NewLine}" +
            $"================={Environment.NewLine}" +
            $"Abatab Lieutenant{Environment.NewLine}" +
            $"================={Environment.NewLine}";

        /// <summary>Create the session detail body.</summary>
        /// <param name="ltSession">The session object.</param>
        /// <returns>The session detail body.</returns>
        private static string SessionBody(LtSession ltSession) =>
            $"Version:                 {ltSession.LtVer}.{ltSession.LtBld}{Environment.NewLine}" +
            $"Staging:                 {ltSession.StagingRoot}{Environment.NewLine}" +
            $"Log root:                {ltSession.LogRoot}{Environment.NewLine}" +
            $"Log path:                {ltSession.LogPath}{Environment.NewLine}" +
            $"Option:                  {ltSession.Option}{Environment.NewLine}" +
            $"Web service root:        {ltSession.AbServiceRoot}{Environment.NewLine}" +
            $"Repository URL:          {ltSession.AbRepoUrl}{Environment.NewLine}" +
            $"Repository .ZIP URL:     {ltSession.AbRepoZipUrl}{Environment.NewLine}" +
            $"Repository Raw data URL: {ltSession.AbRepoRawUrl}{Environment.NewLine}" +
            $"Branch:                  {ltSession.RequestedBranch}{Environment.NewLine}" +
            $"Branch URL:              {ltSession.RequestedBranchUrl}{Environment.NewLine}" +
            $"Branch .ZIP URL:         {ltSession.RequestedBranchZipUrl}{Environment.NewLine}" +
            $"Branch raw data URL:     {ltSession.RequestedBranchRawUrl}{Environment.NewLine}" +
            $"Date/Time:               {ltSession.Datestamp}-{ltSession.Timestamp}{Environment.NewLine}" +
            $"Valid branches:          {string.Join(", ", ltSession.ValidBranches)}{Environment.NewLine}" +
            $"Web service files:       {string.Join(", ", ltSession.ServiceFiles)}{Environment.NewLine}" +
            $"Web service folders:     {string.Join(", ", ltSession.ServiceFolders)}{Environment.NewLine}";
    }
}