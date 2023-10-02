using TheSearch.app.BLL;
using TheSearch.app.Models;

namespace TheSearch.app.DAL;

public class CriminalRepository : ICriminalRepository
{
    private readonly List<Criminal> _criminals = new();

    public IEnumerable<Criminal> GetAll()
    {
        return _criminals;
    }

    public void Add(Criminal criminal)
    {
        _criminals.Add(criminal);
    }
        
}