using System.Text.Json;
using TheSearch.app.IL.Interfaces.Criminal;
using TheSearch.app.Models;

namespace TheSearch.app.DAL.Json;

public class JsonDataAccess
{
    private readonly ICriminalRepository _criminalRepository;

    public JsonDataAccess(ICriminalRepository criminalRepository)
    {
        _criminalRepository = criminalRepository;
    }

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
}