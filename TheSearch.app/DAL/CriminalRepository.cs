using System.Text.Json;
using TheSearch.app.Models;
using TheSearch.app.DAL;

namespace TheSearch.app.DAL;

public class CriminalRepository : ICriminalRepository
{
    private readonly List<Criminal> _criminals = new();

    public IEnumerable<Criminal> GetAll()
    {
        return _criminals;
    }

    public IEnumerable<Criminal> GetOnlyArrested()
    {
        return _criminals.Where(c => c.IsArrested);
    }

    public IEnumerable<Criminal> GetNotArrested()
    {
        return _criminals.Where(c => !c.IsArrested);
    }

    public void SerializeAllCriminals()
    {
        var json = JsonSerializer.Serialize(GetAll());
        File.WriteAllText(FileContext.Criminals, json);
    }

    public void SerializeArrestedCriminals()
    {
        var json = JsonSerializer.Serialize(GetOnlyArrested());
        File.WriteAllText(FileContext.Arrested, json);
    }

    public void SerializeNotArrestedCriminals()
    {
        var json = JsonSerializer.Serialize(GetNotArrested());
        File.WriteAllText(FileContext.NotArrested, json);
    }

    public void DeserializeAllCriminals()
    {
        var json = File.ReadAllText(FileContext.Criminals);
        JsonSerializer.Deserialize<List<Criminal>>(json);
    }

    public void DeserializeOnlyArrested()
    {
        throw new NotImplementedException();
    }

    public void DeserializeNotArrested()
    {
        throw new NotImplementedException();
    }


    public void Initialize()
    {
        Add(CriminalFactory.CreateCriminal("John", "Smith", 160, 50, "Indian", false));
        Add(CriminalFactory.CreateCriminal("Jane", "Johnson", 168, 56, "Canadian", true));
        Add(CriminalFactory.CreateCriminal("Michael", "Brown", 183, 60, "Australian", true));
        Add(CriminalFactory.CreateCriminal("William", "Wilson", 190, 90, "Scottish", true));
        Add(CriminalFactory.CreateCriminal("Sophia", "Clark", 160, 51, "South African", false));
        Add(CriminalFactory.CreateCriminal("Ivan", "Ivanov", 220, 150, "Russian", false));
    }

    private void Add(Criminal criminal)
    {
        _criminals.Add(criminal);
    }
}