namespace AbatabLieutenant.LtntData.Static
{
    public static class Messages
    {
        public static string HelpMsg(string ltntVersion) =>
            $"{Environment.NewLine}" +
            $"==========================={Environment.NewLine}" +
            $"Abatab Lieutenant v{ltntVersion} Help{Environment.NewLine}" +
            $"===========================" +
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
            $"         testing - Deploy the Abatab testing branch (default){Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Example:{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"    AbatabLieutenant.exe help" +
            $"{Environment.NewLine}";
    }
}
