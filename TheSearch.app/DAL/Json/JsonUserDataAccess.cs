using System.Text.Json;
using TheSearch.app.IL.Interfaces.User;
using TheSearch.app.Models.User;
using TheSearch.app.VL;

namespace TheSearch.app.DAL.Json;

public class JsonUserDataAccess : IUserSerializer
{
    private readonly IUserRepository _userRepository;

    public JsonUserDataAccess(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    #region User

    public void SerializeUser()
    {
        var json = JsonSerializer.Serialize(_userRepository.GetAll());
        File.WriteAllText(JsonContext.UserAuthDataPath, json);
    }

    public IEnumerable<User>? DeserializeUser()
    {
        try
        {
            var json = File.ReadAllText(JsonContext.UserAuthDataPath);
            return JsonSerializer.Deserialize<IEnumerable<User>>(json);
        }
        catch (ArgumentNullException ex)
        {
            ConsoleHelper.PrintError(ex.Message);
        }

        throw new InvalidOperationException();
    }

    #endregion
}