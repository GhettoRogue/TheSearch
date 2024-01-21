using TheSearch.app.BLL.Detective;
using TheSearch.app.IL.Interfaces.Logger;
using TheSearch.app.IL.Interfaces.User;

namespace TheSearch.app.DAL.Logger;

public class DetectiveLog
{
    private readonly ILoggerMessage _loggerMessage;
    private readonly IUserSerializer _userSerializer;

    public DetectiveLog(ILoggerMessage loggerMessage, IUserSerializer userSerializer)
    {
        _loggerMessage = loggerMessage;
        _userSerializer = userSerializer;
    }

    public void IsAuth(string inputLogin, string inputPassword)
    {
        var users = (_userSerializer.DeserializeUser() ??
                     throw new InvalidOperationException(DetectiveMessages.UserIsNotExist)).FirstOrDefault();

        if (inputLogin == users?.Login && inputPassword == users.Password)
        {
            _loggerMessage.LoggerSuccess(users.Login + LoggerMessages.SuccessMessage);
            return;
        }

        _loggerMessage.LoggerError(inputLogin + LoggerMessages.FailureMessage);
    }
}