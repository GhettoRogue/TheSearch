using System.Text.Json;
using TheSearch.app.Models;

namespace TheSearch.app.DAL.Repository;

public class CriminalRepository : ICriminalRepository
{
    private readonly List<Criminal> _criminals = new();

    public IEnumerable<Criminal> GetAll() => _criminals;
    
    public IEnumerable<Criminal> GetOnlyArrested() => _criminals.Where(c => c.IsArrested);
    
    public IEnumerable<Criminal> GetNotArrested() => _criminals.Where(c => !c.IsArrested);
    
    private void Add(Criminal criminal) => _criminals.Add(criminal);
    
    public void Initialize()
    {
        Add(CriminalFactory.CreateCriminal("John", "Smith", 160, 50, "Indian", false));
        Add(CriminalFactory.CreateCriminal("Jane", "Johnson", 168, 56, "Canadian", true));
        Add(CriminalFactory.CreateCriminal("Michael", "Brown", 183, 60, "Australian", true));
        Add(CriminalFactory.CreateCriminal("William", "Wilson", 190, 90, "Scottish", true));
        Add(CriminalFactory.CreateCriminal("Sophia", "Clark", 160, 51, "South African", false));
        Add(CriminalFactory.CreateCriminal("Ivan", "Ivanov", 220, 190, "Russian", false));
    }

    #region JsonMethods

    public void SerializeAllCriminals()
    {
        var json = JsonSerializer.Serialize(GetAll());
        File.WriteAllText(JsonContext.Criminals, json);
    }

    public void SerializeArrestedCriminals()
    {
        var json = JsonSerializer.Serialize(GetOnlyArrested());
        File.WriteAllText(JsonContext.Arrested, json);
    }

    public void SerializeNotArrestedCriminals()
    {
        var json = JsonSerializer.Serialize(GetNotArrested());
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
}