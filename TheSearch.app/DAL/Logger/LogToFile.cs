using TheSearch.app.IL.Interfaces.Logger;

namespace TheSearch.app.DAL.Logger;

public class LogToFile : ILoggerMessage
{
    private const string DetectiveLogPath = "authLog.txt";

    private static void Write(string message)
    {
        using var file = new StreamWriter(DetectiveLogPath, true);
        file.WriteLine($"{DateTime.Now:g} {message}");
    }

    public void LoggerError(string message)
    {
        Write($"[{nameof(LoggerError).ToUpper()}] {message}");
    }

    public void LoggerSuccess(string message)
    {
        Write($"[{nameof(LoggerSuccess).ToUpper()}] {message}");
    }
}