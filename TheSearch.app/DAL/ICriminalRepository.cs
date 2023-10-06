using TheSearch.app.Models;

namespace TheSearch.app.DAL;

public interface ICriminalRepository
{
    IEnumerable<Criminal> GetAll();

    IEnumerable<Criminal> GetOnlyArrested();

    IEnumerable<Criminal> GetNotArrested();

    void SerializeAllCriminals(string file);
    void SerializeArrestedCriminals(string file);
    void SerializeNotArrestedCriminals(string file);
}