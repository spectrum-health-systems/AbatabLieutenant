//
//
//

namespace AbatabLieutenant
{
    /// <summary>TBD</summary>
    public class Logger
    {
        //public static void LogStart(SessionData ltntSession)
        //{
        //    LogEvent(Data.Catalog.Log.LtntStartMessage(ltntSession.LtntVersion), ltntSession.LogFileName);
        //}

        //public static void LogSessionDetails(SessionData ltntSession)
        //{
        //    LogEvent(Data.Catalog.Log.LtntSessionDetails(ltntSession), ltntSession.LogFileName);
        //}

        public static void LogEventToConsole(string logMessage)
        {
            Console.WriteLine(logMessage);
        }

        //public static void LogEventToFile(string logMessage, string logFilePath)
        //{
        //    File.AppendAllText(logFilePath, logMessage);
        //}

        public static void LogEvent(string logMessage, string logFilePath)
        {
            Console.WriteLine(logMessage);
            File.AppendAllText(logFilePath, logMessage);
        }
    }
}