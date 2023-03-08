// AbatabLieutenant.LtSession.cs
// b230308.0939
// (c) A Pretty Cool Program

using System.Text.Json;

namespace AbatabLieutenant
{
    /// <summary>Summary</summary>
    public class LtSession
    {
        /// <summary>The Abatab Lieutenant version.</summary>
        public string LtVer { get; set; }

        /// <summary>The Abatab Lieutenant build.</summary>
        public string LtBld { get; set; }

        /// <summary>The Abatab Lieutenant root directory.</summary>
        public string LtRoot { get; set; }

        /// <summary>The Abatab Lieutenant staging root directory</summary>
        public string StagingRoot { get; set; }

        /// <summary>The Abatab Lieutenant log root directory.</summary>
        public string LogRoot { get; set; }

        /// <summary>The Abatab Lieutenant log file path.</summary>
        public string LogPath { get; set; }

        /// <summary>Optional parameter.</summary>
        public string Option { get; set; }

        /// <summary>The Abatab web service root directory.</summary>
        public string AbServiceRoot { get; set; }

        /// <summary>The base Abatab repository URL.</summary>
        public string AbRepoUrl { get; set; }

        /// <summary>The URL to the Abatab branch .zip archive.</summary>
        public string AbRepoZipUrl { get; set; }

        /// <summary>The URL to the Abatab branch raw data.</summary>
        public string AbRepoRawUrl { get; set; }

        /// <summary>The requested branch repository.</summary>
        public string RequestedBranch { get; set; }

        /// <summary>The requested branch URL.</summary>
        public string RequestedBranchUrl { get; set; }

        /// <summary>The URL to the Abatab branch .zip archive.</summary>
        public string RequestedBranchZipUrl { get; set; }

        /// <summary>The URL to the Abatab branch raw data.</summary>
        public string RequestedBranchRawUrl { get; set; }

        /// <summary>The current date.</summary>
        public string Datestamp { get; set; }

        /// <summary>The current time.</summary>
        public string Timestamp { get; set; }

        /// <summary>The list of Abatab date folders.</summary>
        public List<string> AbatabDataFolders { get; set; }

        /// <summary>The list of valid Abatab branches.</summary>
        public List<string> ValidBranches { get; set; }

        /// <summary>The list of required Abatab web service files.</summary>
        public List<string> ServiceFiles { get; set; }

        /// <summary>The list of required Abatab web service bin\ files.</summary>
        public List<string> ServiceBinFiles { get; set; }

        /// <summary>The list of required Abatab web service bin\roslyn\ files.</summary>
        public List<string> ServiceRoslynFiles { get; set; }

        /// <summary>The list of required Abatab web service folders.</summary>
        public List<string> ServiceFolders { get; set; }

        /// <summary>Load the local settings from the local settings file.</summary>
        /// <param name="settingsFile">The name of the local settings file.</param>
        /// <returns></returns>
        public static LtSession LoadLocalSettings(string settingsFile)
        {
            VerifySettingsFile(settingsFile);

            return JsonSerializer.Deserialize<LtSession>(File.ReadAllText(settingsFile));
        }

        /// <summary>Verify the local settings file exists, and create one if it doesn't.</summary>
        /// <param name="settingsFile">The name of the local settings file.</param>
        public static void VerifySettingsFile(string settingsFile)
        {
            if (!File.Exists(settingsFile))
            {
                CreateLocalFile(settingsFile);
            }
        }

        /// <summary>Create a default local settings file.</summary>
        /// <param name="settingsFile">The name of the local settings file.</param>
        public static void CreateLocalFile(string settingsFile)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            File.WriteAllText(settingsFile, JsonSerializer.Serialize(CreateDefaultSettings(), jsonOptions));
        }

        /// <summary>Creates the default settings values.</summary>
        /// <returns>The default setting values.</returns>
        private static LtSession CreateDefaultSettings()
        {
            return new LtSession
            {
                LtVer                 = "4.0",
                LtBld                 = "230308.0939",
                StagingRoot           = @"C:\AbatabData\Lieutenant\Staging",
                LogRoot               = @"C:\AbatabData\Lieutenant\Logs",
                LogPath               = "defined-at-runtime",
                AbServiceRoot         = @"C:\AbatabWebService\UAT",
                AbRepoUrl             = "https://github.com/spectrum-health-systems/Abatab/",
                AbRepoZipUrl          = "https://github.com/spectrum-health-systems/Abatab/archive/refs/heads/",
                AbRepoRawUrl          = "https://raw.githubusercontent.com/spectrum-health-systems/Abatab/",
                RequestedBranch       = "defined-at-runtime",
                RequestedBranchUrl    = "defined-at-runtime",
                RequestedBranchZipUrl = "defined-at-runtime",
                RequestedBranchRawUrl = "defined-at-runtime",
                Datestamp             = "defined-at-runtime",
                Timestamp             = "defined-at-runtime",
                AbatabDataFolders     = new List<string>
                {
                    @"C:\AbatabData\",
                    @"C:\AbatabData\Debuggler\",
                    @"C:\AbatabData\Lieutenant\",
                    @"C:\AbatabData\Lieutenant\Logs\",
                    @"C:\AbatabData\Lieutenant\Staging\",
                    @"C:\AbatabData\Primeval\",
                    @"C:\AbatabData\Public\",
                    @"C:\AbatabData\Public\Warnings\",
                    @"C:\AbatabData\SBOX\",
                    @"C:\AbatabData\SBOX\Warnings\",
                    @"C:\AbatabData\UAT\",
                    @"C:\AbatabData\UAT\Warnings\"
                },
                ValidBranches = new List<string>
                {
                    "development",
                    "main",
                    "testing",
                    "23.2"
                },
                ServiceFiles = new List<string>
                {
                    "Abatab.asmx",
                    "Abatab.asmx.cs",
                    "packages.config",
                    "Web.config",
                    "Web.Debug.config",
                    "Web.Release.config"
                },
                ServiceBinFiles = new List<string>
                {
                    "bin/Abatab.dll",
                    "bin/Abatab.Core.Catalog.dll",
                    "bin/Abatab.Core.DataExport.dll",
                    "bin/Abatab.Core.Framework.dll",
                    "bin/Abatab.Core.Logger.dll",
                    //"bin/Abatab.Core.OptionObject.dll",
                    //"bin/Abatab.Core.OS.dll",
                    "bin/Abatab.Core.Session.dll",
                    "bin/Abatab.Core.Utilities.dll",
                    "bin/Abatab.Module.ProgressNote.dll",
                    "bin/Abatab.Module.Prototype.dll",
                    "bin/Abatab.Module.QuickMedicationOrder.dll",
                    "bin/Abatab.Module.Testing.dll",
                    "bin/Microsoft.CodeDom.Providers.DotNetCompilerPlatform.dll",
                    "bin/Newtonsoft.Json.dll",
                    "bin/ScriptLinkStandard.dll",
                },
                ServiceRoslynFiles = new List<string>
                {
                    "bin/roslyn/csc.exe",
                    "bin/roslyn/csc.exe.config",
                    "bin/roslyn/csc.rsp",
                    "bin/roslyn/csi.exe",
                    "bin/roslyn/csi.exe.config",
                    "bin/roslyn/csi.rsp",
                    "bin/roslyn/Microsoft.Build.Tasks.CodeAnalysis.dll",
                    "bin/roslyn/Microsoft.CodeAnalysis.CSharp.dll",
                    "bin/roslyn/Microsoft.CodeAnalysis.CSharp.Scripting.dll",
                    "bin/roslyn/Microsoft.CodeAnalysis.dll",
                    "bin/roslyn/Microsoft.CodeAnalysis.Scripting.dll",
                    "bin/roslyn/Microsoft.CodeAnalysis.VisualBasic.dll",
                    "bin/roslyn/Microsoft.CSharp.Core.targets",
                    "bin/roslyn/Microsoft.DiaSymReader.Native.amd64.dll",
                    "bin/roslyn/Microsoft.DiaSymReader.Native.x86.dll",
                    "bin/roslyn/Microsoft.Managed.Core.targets",
                    "bin/roslyn/Microsoft.VisualBasic.Core.targets",
                    "bin/roslyn/Microsoft.Win32.Primitives.dll",
                    "bin/roslyn/System.AppContext.dll",
                    "bin/roslyn/System.Collections.Immutable.dll",
                    "bin/roslyn/System.Console.dll",
                    "bin/roslyn/System.Diagnostics.DiagnosticSource.dll",
                    "bin/roslyn/System.Diagnostics.FileVersionInfo.dll",
                    "bin/roslyn/System.Diagnostics.StackTrace.dll",
                    "bin/roslyn/System.Globalization.Calendars.dll",
                    "bin/roslyn/System.IO.Compression.dll",
                    "bin/roslyn/System.IO.Compression.ZipFile.dll",
                    "bin/roslyn/System.IO.FileSystem.dll",
                    "bin/roslyn/System.IO.FileSystem.Primitives.dll",
                    "bin/roslyn/System.Net.Http.dll",
                    "bin/roslyn/System.Net.Sockets.dll",
                    "bin/roslyn/System.Reflection.Metadata.dll",
                    "bin/roslyn/System.Runtime.InteropServices.RuntimeInformation.dll",
                    "bin/roslyn/System.Security.Cryptography.Algorithms.dll",
                    "bin/roslyn/System.Security.Cryptography.Encoding.dll",
                    "bin/roslyn/System.Security.Cryptography.Primitives.dll",
                    "bin/roslyn/System.Security.Cryptography.X509Certificates.dll",
                    "bin/roslyn/System.Text.Encoding.CodePages.dll",
                    "bin/roslyn/System.Threading.Tasks.Extensions.dll",
                    "bin/roslyn/System.ValueTuple.dll",
                    "bin/roslyn/System.Xml.ReaderWriter.dll",
                    "bin/roslyn/System.Xml.XmlDocument.dll",
                    "bin/roslyn/System.Xml.XPath.dll",
                    "bin/roslyn/System.Xml.XPath.XDocument.dll",
                    "bin/roslyn/vbc.exe",
                    "bin/roslyn/vbc.exe.config",
                    "bin/roslyn/vbc.rsp",
                    "bin/roslyn/VBCSCompiler.exe",
                    "bin/roslyn/VBCSCompiler.exe.config"
                },
                ServiceFolders = new List<string>
                {
                    "bin"
                }
            };
        }

        /// <summary>Create various setting values at runtime.</summary>
        /// <param name="ltSession">The session object.</param>
        /// <param name="commandArguments">The arguments passed via the command line.</param>
        public static void CreateRuntimeSettings(LtSession ltSession, string[] commandArguments)
        {
            ltSession.Datestamp             = $"{DateTime.Now:yyMMdd}";
            ltSession.Timestamp             = $"{DateTime.Now:HHmm}";
            ltSession.RequestedBranch       = commandArguments[0];
            ltSession.RequestedBranchUrl    = $"https://github.com/spectrum-health-systems/Abatab/tree/development/{ltSession.RequestedBranch}";
            ltSession.RequestedBranchZipUrl = $"{ltSession.AbRepoZipUrl}{ltSession.RequestedBranch}.zip";
            ltSession.RequestedBranchRawUrl = $@"{ltSession.AbRepoRawUrl}{ltSession.RequestedBranch}/src/";
            ltSession.LogPath               = $@"{ltSession.LogRoot}\{ltSession.Datestamp}.{ltSession.Timestamp}.ltnt";

            if (commandArguments.Length == 2)
            {
                ltSession.Option = commandArguments[1];
            }

            Utilities.WriteLog(Catalog.SessionDetail(ltSession), ltSession.LogPath);
        }
    }
}