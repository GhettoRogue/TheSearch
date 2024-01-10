namespace TheSearch.app.IL.Interfaces.Logger;

public interface ILoggerMessage
{
    public void LoggerSuccess(string message);
    
    public void LoggerError(string message);
}