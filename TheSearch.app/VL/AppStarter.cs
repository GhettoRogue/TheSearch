using TheSearch.app.BLL.Detective;
using TheSearch.app.DAL.Json;
using TheSearch.app.DAL.Logger;
using TheSearch.app.DAL.Repository.Criminal;
using TheSearch.app.DAL.Repository.User;

namespace TheSearch.app.VL;

public static class AppStarter
{
    public static void InitProject()
    {
        var exit = false;
        do
        {
            TheSearchView.ShowMenuLogin();

            switch (ConsoleHelper.UserInput(DetectiveMessages.EnterChoiceUser))
            {
                case "1":
                    ConsoleHelper.ClearConsole();

                    var jsonCriminalData = new JsonCriminalDataAccess(new CriminalRepository());
                    var jsonUserData = new JsonUserDataAccess(new UserRepository());

                    var users = jsonUserData.DeserializeUser();
                    if (users is null)
                    {
                        ConsoleHelper.PrintError(DetectiveMessages.InvalidUserData);
                        return;
                    }

                    var inputLogin = ConsoleHelper.UserInput(DetectiveMessages.UserLogin);
                    var inputPassword = ConsoleHelper.UserInput(DetectiveMessages.UserPass);

                    var authUser =
                        users.FirstOrDefault(u => u.Login == inputLogin && u.Password == inputPassword);
                    var auth = new DetectiveLog(new LogToFile());
                    if (auth.IsAuth(authUser))
                    {
                        var repository = new CriminalRepository();
                        var detectiveTools = new DetectiveTools(repository, jsonCriminalData);
                        var detectiveView = new DetectiveView(detectiveTools);

                        detectiveView.ShowDetectiveMenu();
                    }
                    else
                    {
                        ConsoleHelper.PrintError(DetectiveMessages.InvalidUserData);
                    }

                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    ConsoleHelper.PrintError(DetectiveMessages.InvalidUserData);
                    break;
            }

            ConsoleHelper.ClearConsole();
            ConsoleHelper.PrintSuccess(DetectiveMessages.ExitMessageUser);
        } while (!exit);
    }
}