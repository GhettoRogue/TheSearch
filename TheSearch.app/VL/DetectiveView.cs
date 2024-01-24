using TheSearch.app.BLL.Detective;
using TheSearch.app.IL.Interfaces.Detective;

namespace TheSearch.app.VL;

public class DetectiveView
{
    private readonly IDetective _detective;
    
    public DetectiveView(IDetective detective)
    {
        _detective = detective;
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
                    _detective.GetArrestedPeople();
                    break;
                case "2":
                    _detective.SearchCriminal();
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