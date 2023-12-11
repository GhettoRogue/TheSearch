using TheSearch.app.DAL.Repository;
using TheSearch.app.Models;

namespace TheSearch.app.BLL.Detective;

public class Detective : IDetective
{
    private readonly ICriminalRepository _repository;

    public Detective(ICriminalRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Criminal> FindCriminalByParameters(int height, int weight, string? nationality) => _repository
        .GetAll()
        .Where(c => 
        c.Height == height &&
        c.Weight == weight &&
        c.Nationality == nationality);

    public IEnumerable<Criminal> GetArrestedCriminals(IEnumerable<Criminal> criminal) => criminal.Where(c => c.IsArrested);
    
}