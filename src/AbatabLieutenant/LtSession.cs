// AbatabLieutenant.LtSession.cs
// b230307.1753
// (c) A Pretty Cool Program

using System.Text.Json;

namespace AbatabLieutenant
{
    /// <summary>Summary</summary>
    public class LtSession
    {
        /// <summary>Summary</summary>
        public string LtVer { get; set; }

        /// <summary>Summary</summary>
        public string LtBld { get; set; }

        /// <summary>Summary</summary>
        public string LtRoot { get; set; }

        /// <summary>Summary</summary>
        public string StagingRoot { get; set; }

        /// <summary>Summary</summary>
        public string LogRoot { get; set; }

        /// <summary>Summary</summary>
        public string LogPath { get; set; }

        /// <summary>Summary</summary>
        public string Option { get; set; }

        /// <summary>Summary</summary>
        public string AbServiceRoot { get; set; }

        /// <summary>Summary</summary>
        public string AbRepoUrl { get; set; }

        /// <summary>Summary</summary>
        public string AbRepoZipUrl { get; set; }

        /// <summary>Summary</summary>
        public string AbRepoRawUrl { get; set; }

        /// <summary>Summary</summary>
        public string RequestedBranch { get; set; }

        /// <summary>Summary</summary>
        public string RequestedBranchUrl { get; set; }

        /// <summary>Summary</summary>
        public string RequestedBranchZipUrl { get; set; }

        /// <summary>Summary</summary>
        public string RequestedBranchRawUrl { get; set; }

        /// <summary>Summary</summary>
        public string Datestamp { get; set; }

        /// <summary>Summary</summary>
        public string Timestamp { get; set; }

        /// <summary>Summary</summary>
        public List<string> AbatabDataFolders { get; set; }

        /// <summary>Summary</summary>
        public List<string> ValidBranches { get; set; }

        /// <summary>Summary</summary>
        public List<string> ServiceFiles { get; set; }

        /// <summary>Summary</summary>
        public List<string> ServiceBinFiles { get; set; }

        /// <summary>Summary</summary>
        public List<string> ServiceRoslynFiles { get; set; }

        /// <summary>Summary</summary>
        public List<string> ServiceFolders { get; set; }

        /// <summary>Summary</summary>
        /// <param name="settingsFile"></param>
        /// <returns></returns>
        public static LtSession LoadLocalSettings(string settingsFile)
        {
            VerifySettingsFile(settingsFile);

            return JsonSerializer.Deserialize<LtSession>(File.ReadAllText(settingsFile));
        }

        /// <summary>Summary</summary>
        /// <param name="settingsFile"></param>
        public static void VerifySettingsFile(string settingsFile)
        {
            if (!File.Exists(settingsFile))
            {
                RefreshLocalFile(settingsFile);
            }
        }

        /// <summary>Summary</summary>
        /// <param name="settingsFile"></param>
        public static void RefreshLocalFile(string settingsFile)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            File.WriteAllText(settingsFile, JsonSerializer.Serialize(CreateDefaultSettings(), jsonOptions));
        }

        /// <summary>Summary</summary>
        /// <returns></returns>
        private static LtSession CreateDefaultSettings()
        {
            return new LtSession
            {
                LtVer                 = "4.0",
                LtBld                 = "230307.1034",
                StagingRoot           = @"C:\AbatabData\Lieutenant\Staging",
                LogRoot               = @"C:\AbatabData\Lieutenant\Logs",
                LogPath               = "defined-at-runtime",
                AbServiceRoot         = @"C:\AvatoolWebService\Abatab_UAT",
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

        /// <summary>Summary</summary>
        /// <param name="ltntSession"></param>
        /// <param name="args"></param>
        public static void CreateRuntimeSettings(LtSession ltntSession, string[] args)
        {
            ltntSession.Datestamp             = $"{DateTime.Now:yyMMdd}";
            ltntSession.Timestamp             = $"{DateTime.Now:HHmm}";
            ltntSession.RequestedBranch       = args[0];
            ltntSession.RequestedBranchUrl    = $"https://github.com/spectrum-health-systems/Abatab/tree/development/{ltntSession.RequestedBranch}";
            ltntSession.RequestedBranchZipUrl = $"{ltntSession.AbRepoZipUrl}{ltntSession.RequestedBranch}.zip";
            ltntSession.RequestedBranchRawUrl = $@"{ltntSession.AbRepoRawUrl}{ltntSession.RequestedBranch}/src/";
            ltntSession.LogPath               = $@"{ltntSession.LogRoot}\{ltntSession.Datestamp}.{ltntSession.Timestamp}.ltnt";

            if (args.Length == 2)
            {
                ltntSession.Option = args[1];
            }

            Utilities.WriteLog(Catalog.SessionDetail(ltntSession), ltntSession.LogPath);
        }
    }
}