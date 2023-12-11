using TheSearch.app.Models;

namespace TheSearch.app.BLL.Detective;

public interface IDetective
{
    IEnumerable<Criminal> FindCriminalByParameters(int height, int weight, string? nationality);
    IEnumerable<Criminal> GetArrestedCriminals(IEnumerable<Criminal> criminal);
    
}