using System.Text.Json;
using TheSearch.app.IL.Interfaces.Criminal;
using TheSearch.app.IL.Interfaces.User;
using TheSearch.app.Models;
using TheSearch.app.Models.User;
using TheSearch.app.VL;

namespace TheSearch.app.DAL.Json;

public class JsonDataAccess : ICriminalSerializer, IUserSerializer
{
    private readonly ICriminalRepository _criminalRepository;

    private readonly IUserRepository _userRepository;

    public JsonDataAccess(ICriminalRepository criminalRepository, IUserRepository userRepository)
    {
        _criminalRepository = criminalRepository;
        _userRepository = userRepository;
    }

    #region Criminal

    public void SerializeAllCriminals()
    {
        var json = JsonSerializer.Serialize(_criminalRepository.GetAll());
        File.WriteAllText(JsonContext.Criminals, json);
    }

    public void SerializeArrestedCriminals()
    {
        var json = JsonSerializer.Serialize(_criminalRepository.GetOnlyArrested());
        File.WriteAllText(JsonContext.Arrested, json);
    }

    public void SerializeNotArrestedCriminals()
    {
        var json = JsonSerializer.Serialize(_criminalRepository.GetNotArrested());
        File.WriteAllText(JsonContext.NotArrested, json);
    }

    public void DeserializeAllCriminals()
    {
        var json = File.ReadAllText(JsonContext.Criminals);
        JsonSerializer.Deserialize<List<Criminal>>(json);
    }

    public void DeserializeOnlyArrested()
    {
        var json = File.ReadAllText(JsonContext.Arrested);
        JsonSerializer.Deserialize<List<Criminal>>(json);
    }

    public void DeserializeNotArrested()
    {
        var json = File.ReadAllText(JsonContext.NotArrested);
        JsonSerializer.Deserialize<List<Criminal>>(json);
    }

    #endregion


    #region User

    public void SerializeUser()
    {
        var json = JsonSerializer.Serialize(_userRepository.GetAll());
        File.WriteAllText(JsonContext.UserAuthData, json);
    }

    public IEnumerable<User>? DeserializeUser()
    {
        try
        {
            var json = File.ReadAllText(JsonContext.UserAuthData);
            return JsonSerializer.Deserialize<IEnumerable<User>>(json);
        }
        catch (ArgumentNullException ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            throw;
        }
    }

    #endregion
}