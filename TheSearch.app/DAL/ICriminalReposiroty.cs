using TheSearch.app.Models;

namespace TheSearch.app.DAL;

public interface ICriminalRepository
{
    IEnumerable<Criminal> GetAll();
}