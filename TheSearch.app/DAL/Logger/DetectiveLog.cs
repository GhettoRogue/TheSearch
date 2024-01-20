using TheSearch.app.IL.Interfaces.Logger;
using TheSearch.app.Models.User;

namespace TheSearch.app.DAL.Logger;

public class DetectiveLog
{
    private readonly ILoggerMessage _loggerMessage;

    public DetectiveLog(ILoggerMessage loggerMessage)
    {
        _loggerMessage = loggerMessage;
    }

    public bool IsAuth(User? user)
    {
        if (user == null)
        {
            _loggerMessage.LoggerError(user?.Login + LoggerMessages.FailureMessage);
            return false;
        }

        _loggerMessage.LoggerSuccess(user.Login + LoggerMessages.SuccessMessage);
        return true;
    }
}