namespace TheSearch.app.Models.User;

public abstract class UserFactory
{
    public static User CreateUser(string login, string password)
    {
        return new User
        {
            Login = login,
            Password = password
        };
    }
}