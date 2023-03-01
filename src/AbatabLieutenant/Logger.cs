namespace AbatabLieutenant
{
    public class Logger
    {
        public static void WriteToConsole(string content)
        {
            Console.WriteLine(content);

        }

        public static void WriteToFile(string content, string filePath)
        {
            File.AppendAllText(filePath, $"{content}{Environment.NewLine}");
        }

        public static void WriteToConsoleAndFile(string content, string filePath)
        {
            WriteToConsole(content);
            WriteToFile(content, filePath);
        }
    }
}
