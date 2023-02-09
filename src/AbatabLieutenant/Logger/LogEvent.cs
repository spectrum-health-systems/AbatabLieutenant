// b230209.0737

namespace AbatabLieutenant.Logger
{
    /// <summary>TBD</summary>
    internal static class LogEvent
    {
        /// <summary>Display a message on the console, and write it to a local file.</summary>
        /// <param name="logMsg">The message to display/write.</param>
        /// <param name="logFilePath">The file path to write to.</param>
        public static void ToFile(string logMsg, string logFilePath)
        {
            Console.WriteLine(logMsg);
            File.AppendAllText(logFilePath, $"{logMsg}{Environment.NewLine}");
        }
    }
}