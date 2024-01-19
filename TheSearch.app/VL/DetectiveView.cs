using TheSearch.app.BLL;
using TheSearch.app.BLL.Criminal;
using TheSearch.app.BLL.Detective;
using TheSearch.app.IL.Interfaces.Criminal;

namespace TheSearch.app.VL;

public class DetectiveView
{
    private readonly DetectiveTools _detectiveTools;

    public DetectiveView(DetectiveTools detectiveTools)
    {
        _detectiveTools = detectiveTools;
    }

    internal void ShowDetectiveMenu()
    {
        ConsoleHelper.ClearConsole();
        var exit = false;
        do
        {
            TheSearchView.ShowMenu();
            switch (ConsoleHelper.UserInput(DetectiveMessages.EnterChoiceDetective))
            {
                case "1":
                    _detectiveTools.GetArrestedPeople();
                    break;
                case "2":
                    _detectiveTools.SearchCriminal();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    ConsoleHelper.ClearConsole();
                    ConsoleHelper.PrintError(DetectiveMessages.ErrorChoice);
                    ConsoleHelper.PrintWarning(DetectiveMessages.BackToTheMenu);
                    Console.ReadKey();
                    ConsoleHelper.ClearConsole();
                    break;
            }
        } while (!exit);

        ConsoleHelper.ClearConsole();
        ConsoleHelper.PrintSuccess(DetectiveMessages.ExitMessageDetective);
    }
}