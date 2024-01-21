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

                    var inputLogin = ConsoleHelper.UserInput(DetectiveMessages.UserLogin);
                    var inputPassword = ConsoleHelper.UserInput(DetectiveMessages.UserPass);

                    var jsonUserData = new JsonUserDataAccess(new UserRepository());
                    var auth = new DetectiveLog(new LogToFile(), jsonUserData);
                    
                    auth.IsAuth(inputLogin, inputPassword);
                    
                    var repository = new CriminalRepository();
                    var jsonCriminalData = new JsonCriminalDataAccess(repository);
                    var detectiveTools = new DetectiveTools(repository, jsonCriminalData);
                    var detectiveView = new DetectiveView(detectiveTools);

                    detectiveView.ShowDetectiveMenu();
                    
                    break;
                case "0":
                    exit = true;
                    break;
            }

            ConsoleHelper.ClearConsole();
            ConsoleHelper.PrintSuccess(DetectiveMessages.ExitMessageUser);
        } while (!exit);
    }
}