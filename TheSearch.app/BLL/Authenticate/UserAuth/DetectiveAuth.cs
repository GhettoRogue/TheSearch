using TheSearch.app.IL.Interfaces.Auth;
using TheSearch.app.Models.User;

namespace TheSearch.app.BLL.Authenticate.UserAuth;

public class DetectiveAuth : IAuth
{
    public bool IsUserIn(User? user) => user != null;
    //unused class & interface
}