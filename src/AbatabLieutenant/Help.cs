// Help.cs b230123.1333
// Application help documentation.

namespace AbatabLieutenant
{
    public class Help
    {
        public static void ConsoleDisplay(string ltntVersion)
        {
            Console.WriteLine(HelpMsg(ltntVersion));
        }

        private static string HelpMsg(string ltntVersion) =>
            $"{Environment.NewLine}" +
            $"======================{Environment.NewLine}" +
            $"Abatab Lieutenant Help{Environment.NewLine}" +
            $"======= v{ltntVersion} ======={Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Syntax:{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"    $ AbatabLieutenant <command>{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Valid commands:{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"            help - Abatab Lieutenant help (this screen){Environment.NewLine}" +
            $"     development - Deploy the Abatab development branch{Environment.NewLine}" +
            $"    experimental - Deploy the Abatab experimental branch{Environment.NewLine}" +
            $"            main - Deploy the Abatab main branch{Environment.NewLine}" +
            $"       testbuild - Deploy the Abatab testbuild branch (default){Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Example:{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"    AbatabLieutenant.exe help" +
            $"{Environment.NewLine}";
    }
}
