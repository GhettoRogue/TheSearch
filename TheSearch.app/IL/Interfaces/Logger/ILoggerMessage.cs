namespace TheSearch.app.IL.Interfaces.Logger;

public interface ILoggerMessage
{
    void LoggerSuccess(string message);
    
    void LoggerError(string message);
}