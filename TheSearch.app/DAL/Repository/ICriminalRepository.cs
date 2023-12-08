using TheSearch.app.Models;

namespace TheSearch.app.DAL.Repository;

public interface ICriminalRepository
{
    IEnumerable<Criminal> GetAll();

    IEnumerable<Criminal> GetOnlyArrested();

    IEnumerable<Criminal> GetNotArrested();
    
}