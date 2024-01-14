namespace TheSearch.app.IL.Interfaces.User;

public interface IUserSerializer
{
    void SerializeUser();

    IEnumerable<Models.User.User>? DeserializeUser();
}