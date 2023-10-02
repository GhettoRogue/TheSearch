using System.Collections;
using TheSearch.app.DAL;
using TheSearch.app.Models;

namespace TheSearch.app.BLL;

public class Detective : IDetective
{
    private readonly ICriminalRepository _repository;

    public Detective(ICriminalRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Criminal> FindCriminalByParameters(int height, int weight, string? nationality)
    {
        return _repository.GetAll().Where(c =>
            c.Height == height
            && c.Weight == weight
            && c.Nationality == nationality);
    }

    public IEnumerable<Criminal> GetArrestedCriminals(IEnumerable<Criminal> criminal)
    {
        return criminal.Where(c => c.IsArrested);
    }
}