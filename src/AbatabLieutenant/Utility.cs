namespace AbatabLieutenant
{
    public static class Utility
    {
        public static string ListToString(List<string> listString)
        {
            var str = "";

            foreach (var argument in listString)
            {
                str += $"    {argument.ToString()}{Environment.NewLine}";
            }

            return str;
        }

        public static void VerifyDirectoryExists(string directory, string logFilePath)
        {
            if (!Directory.Exists(directory))
            {
                _=Directory.CreateDirectory(directory);
            }

            Logger.WriteToFile($@"Verifying: {directory}\...", logFilePath);
        }
    }
}
