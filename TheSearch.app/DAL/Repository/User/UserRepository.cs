using TheSearch.app.IL.Interfaces.User;
using TheSearch.app.Models.User;

namespace TheSearch.app.DAL.Repository.User;

public class UserRepository : IUserRepository
{
    private readonly List<Models.User.User> _users = new();

    public IEnumerable<Models.User.User> GetAll() => _users;
    
    private void Add(Models.User.User user) => _users.Add(user);
    
    public void Initialize()
    {
        Add(UserFactory.CreateUser("sherlock", "holmes"));
        Add(UserFactory.CreateUser("doctor", "watson"));
    }

}