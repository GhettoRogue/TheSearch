namespace TheSearch.app.IL.Interfaces.Criminal;

public interface ICriminalRepository
{
    IEnumerable<Models.Criminal> GetAll();

    IEnumerable<Models.Criminal> GetOnlyArrested();

    IEnumerable<Models.Criminal> GetNotArrested();
    
}