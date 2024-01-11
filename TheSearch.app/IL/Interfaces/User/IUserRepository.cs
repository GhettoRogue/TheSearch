namespace TheSearch.app.IL.Interfaces.User;

public interface IUserRepository
{
    IEnumerable<Models.User.User> GetAll();
    
}