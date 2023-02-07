// AbatabLieutenant.Logger.LogEvent.cs
// Stuff for command line stuff.
// b---

namespace AbatabLieutenant.Logger
{
    /// <summary>TBD</summary>
    public class LogEvent
    {
        /// <summary>Display a message on the console.</summary>
        /// <param name="logMessage">The message to display.</param>
        public static void ToConsole(string logMessage)
        {
            Console.WriteLine(logMessage);
        }

        /// <summary>Display a message on the console, and write it to a local file.</summary>
        /// <param name="logMessage">The message to display/write.</param>
        /// <param name="logFilePath">The file path to write to.</param>
        public static void ToConsoleAndFile(string logMessage, string logFilePath)
        {
            Console.WriteLine(logMessage);
            File.AppendAllText(logFilePath, logMessage);
        }
    }
}
