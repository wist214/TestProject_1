using Serilog;

namespace GameTipsShop.SharedLibrary.Logs
{
    public static class LogException
    {
        public static void LogExceptions(Exception ex, string message = null)
        {
            LogToFile($"{message} {ex.Message}");
            LogToConsole($"{message} {ex.Message}");
            LogToDebug($"{message} {ex.Message}");
        }

        private static void LogToFile(string message) => Log.Information(message);
        private static void LogToConsole(string message) => Log.Warning(message);
        private static void LogToDebug(string message) => Log.Debug(message);
    }
}
