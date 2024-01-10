namespace TheSearch.app.Models.User;

public static class UserFactory
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