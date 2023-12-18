using TheSearch.app.IL.Interfaces.Criminal;
using TheSearch.app.Models;

namespace TheSearch.app.DAL.Repository.Criminal;

public class CriminalRepository : ICriminalRepository
{
    private readonly List<Models.Criminal> _criminals = new();

    public IEnumerable<Models.Criminal> GetAll() => _criminals;
    
    public IEnumerable<Models.Criminal> GetOnlyArrested() => _criminals.Where(c => c.IsArrested);
    
    public IEnumerable<Models.Criminal> GetNotArrested() => _criminals.Where(c => !c.IsArrested);
    
    private void Add(Models.Criminal criminal) => _criminals.Add(criminal);
    
    public void Initialize()
    {
        Add(CriminalFactory.CreateCriminal("John", "Smith", 160, 50, "Indian", false));
        Add(CriminalFactory.CreateCriminal("Jane", "Johnson", 168, 56, "Canadian", true));
        Add(CriminalFactory.CreateCriminal("Michael", "Brown", 183, 60, "Australian", true));
        Add(CriminalFactory.CreateCriminal("William", "Wilson", 190, 90, "Scottish", true));
        Add(CriminalFactory.CreateCriminal("Sophia", "Clark", 160, 51, "South African", false));
        Add(CriminalFactory.CreateCriminal("Ivan", "Ivanov", 220, 190, "Russian", false));
    }
    
}