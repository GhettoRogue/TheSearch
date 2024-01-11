using TheSearch.app.BLL;
using TheSearch.app.BLL.Authenticate.UserAuth;
using TheSearch.app.BLL.Detective;
using TheSearch.app.DAL.Logger;
using TheSearch.app.DAL.Repository.Criminal;
using TheSearch.app.IL.Interfaces.Criminal;
using TheSearch.app.IL.Interfaces.Detective;
using TheSearch.app.Models;
using TheSearch.app.Models.User;

namespace TheSearch.app.VL;

public class DetectiveView
{
    private readonly IDetective _detective;
    private readonly ICriminalRepository _repository;

    private DetectiveView(IDetective detective, ICriminalRepository repository)
    {
        _detective = detective;
        _repository = repository;
    }

    private static class DetectiveConstMessage
    {
        public const int ExitFromMenu = 0;

        public const string EnterChoiceDetective = "Enter your choice detective: ";
        public const string EnterChoiceUser = "Enter your choice user: ";
        public const string ErrorChoice = "Invalid choice. Please try again.";
        public const string ExitMessageDetective = "Good hunting, detective.";
        public const string ExitMessageUser = "Goodbuye, detective.";
        public const string Arrested = "List of arrested people:";

        public const string CriminalsNotFound =
            "No criminal found by using these data. What would you like to do next?";

        public const string CriminalsWasFound = "The criminal was found using this data: ";
        public const string Search = "Search for a criminal:";
        public const string ButtonToReturn = "(or press 0 to return to the menu)";
        public const string EnterHeight = "Enter height: ";
        public const string ErrorHeight = "Error: invalid height. Please try again.";
        public const string EnterWeight = "Enter weight: ";
        public const string ErrorWeight = "Error: invalid weight. Please try again.";
        public const string EnterNationality = "Enter nationality: ";
        public const string ErrorNationality = "Error: invalid nationality. Please try again.";
        public const string UserLogin = "Enter login: ";
        public const string UserPass = "Enter password: ";
        public const string InvalidUserData = "Invalid credentials!";
    }


    public static void InitProject()
    {
        var exit = false;
        do
        {
            TheSearchView.ShowMenuLogin();

            switch (ConsoleHelper.UserInput(DetectiveConstMessage.EnterChoiceUser))
            {
                case "1":
                    ConsoleHelper.ClearConsole();
                    var authUser = new User()
                    {
                        Login = ConsoleHelper.UserInput(DetectiveConstMessage.UserLogin),
                        Password = ConsoleHelper.UserInput(DetectiveConstMessage.UserPass)
                    };

                    var auth = new DetectiveLog(new DetectiveAuth(authUser), new LogToFile());
                    if (auth.IsAuth(authUser))
                    {
                        var repository = new CriminalRepository();
                        var detective = new Detective(repository);
                        repository.Initialize();

                        var detectiveView = new DetectiveView(detective, repository);
                        detectiveView.ShowDetectiveMenu();
                    }

                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    ConsoleHelper.PrintError(DetectiveConstMessage.InvalidUserData);
                    break;
            }

            ConsoleHelper.ClearConsole();
            ConsoleHelper.PrintSuccess(DetectiveConstMessage.ExitMessageUser);
        } while (!exit);
    }

    private void ShowDetectiveMenu()
    {
        ConsoleHelper.ClearConsole();
        var exit = false;
        do
        {
            TheSearchView.ShowMenu();
            switch (ConsoleHelper.UserInput(DetectiveConstMessage.EnterChoiceDetective))
            {
                case "1":
                    ShowArrestedPeople(_repository.GetAll());
                    break;
                case "2":
                    SearchCriminal();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    ConsoleHelper.PrintError(DetectiveConstMessage.ErrorChoice);
                    break;
            }
        } while (!exit);

        ConsoleHelper.ClearConsole();
        ConsoleHelper.PrintSuccess(DetectiveConstMessage.ExitMessageDetective);
    }

    private void ShowArrestedPeople(IEnumerable<Criminal> criminals)
    {
        ConsoleHelper.ClearConsole();
        ConsoleHelper.Print(DetectiveConstMessage.Arrested);
        var arrestedPeople = _detective.GetArrestedCriminals(criminals);
        foreach (var criminal in arrestedPeople)
        {
            ConsoleHelper.PrintSuccess(
                $"ID criminal: [{criminal.Id}]," +
                $" First Name: {criminal.FirstName}," +
                $" Last Name: {criminal.LastName}," +
                $" Height: {criminal.Height}," +
                $" Weight: {criminal.Weight}," +
                $" Nationality: {criminal.Nationality}");
        }
    }

    private void FindCriminal(int height, int weight, string? nationality)
    {
        var findCriminal = _detective.FindCriminalByParameters(height, weight, nationality).ToList();
        if (findCriminal.Count == 0)
        {
            ConsoleHelper.ClearConsole();
            ConsoleHelper.PrintWarning(DetectiveConstMessage.CriminalsNotFound);
        }
        else
        {
            ConsoleHelper.ClearConsole();
            ConsoleHelper.PrintSuccess(DetectiveConstMessage.CriminalsWasFound);
            findCriminal.ForEach(c => ConsoleHelper.PrintCriminal
            ($"[Height: {c.Height}," + $" Weight: {c.Weight}," + $" Nationality: {c.Nationality}]" +
             $" - [{c.FirstName} {c.LastName}] - |IsArrested:{c.IsArrested}| "));
        }
    }
    
    private void SearchCriminal()
    {
        ConsoleHelper.ClearConsole();
        ConsoleHelper.PrintSuccess(DetectiveConstMessage.Search);
        ConsoleHelper.PrintWarning(DetectiveConstMessage.ButtonToReturn);

        int height;
       
        while (true)
        {
            ConsoleHelper.PrintLine(DetectiveConstMessage.EnterHeight);
            int.TryParse(Console.ReadLine(), out height);

            if (height == DetectiveConstMessage.ExitFromMenu)
            {
                ConsoleHelper.ClearConsole();
                return;
            }

            if (!Validator.ValidateHeight(height))
            {
                ConsoleHelper.PrintError(DetectiveConstMessage.ErrorHeight);
                continue;
            }

            break;
        }
        

        int weight;
        while (true)
        {
            Console.Write(DetectiveConstMessage.EnterWeight);
            int.TryParse(Console.ReadLine(), out weight);

            if (weight == DetectiveConstMessage.ExitFromMenu)
            {
                ConsoleHelper.ClearConsole();
                return;
            }

            if (!Validator.ValidateWeight(weight))
            {
                ConsoleHelper.PrintError(DetectiveConstMessage.ErrorWeight);
                continue;
            }

            break;
        }

        string? nationality;
        while (true)
        {
            Console.Write(DetectiveConstMessage.EnterNationality);
            nationality = Console.ReadLine();

            if (nationality == DetectiveConstMessage.ExitFromMenu.ToString())
            {
                ConsoleHelper.ClearConsole();
                return;
            }

            if (!Validator.ValidateNationality(nationality))
            {
                ConsoleHelper.PrintError(DetectiveConstMessage.ErrorNationality);
                continue;
            }

            break;
        }

        FindCriminal(height, weight, nationality);
    }
}