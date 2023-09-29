using System.Collections;
using TheSearch.app.Models;

namespace TheSearch.app.BLL;

public class Detective : IDetective
{
    private readonly List<Criminal> _criminals;

    public Detective(List<Criminal> criminals)
    {
        _criminals = criminals;
    }

    public IEnumerable<Criminal> FindCriminalByParameters(int height, int weight, string? nationality)
    {
        var find =
            from c in _criminals
            where c.Height == height && c.Weight == weight && c.Nationality == nationality
            select c;

        return find;
    }

    public IEnumerable<Criminal> GetArrestedCriminals(IEnumerable<Criminal> criminal)
    {
        return criminal.Where(c => c.IsArrested);
        /*var arrested =
            from person in criminal
            where person.IsArrested
            select person;

        return arrested;*/
    }
}