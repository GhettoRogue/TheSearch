using TheSearch.app.BLL;
using TheSearch.app.BLL.Authenticate.UserAuth;
using TheSearch.app.BLL.Detective;
using TheSearch.app.DAL.Logger;
using TheSearch.app.DAL.Repository.Criminal;
using TheSearch.app.DAL.Repository.User;
using TheSearch.app.IL.Interfaces.Criminal;
using TheSearch.app.IL.Interfaces.Detective;
using TheSearch.app.Models;

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

                    var userRepository = new UserRepository();
                    userRepository.Initialize();

                    var registeredUser = userRepository.GetAll().ToList();

                    var inputLogin = ConsoleHelper.UserInput(DetectiveMessages.UserLogin);
                    var inputPass = ConsoleHelper.UserInput(DetectiveMessages.UserPass);
                    var authUser = registeredUser.FirstOrDefault(u => u.Login == inputLogin && u.Password == inputPass);
                    if (authUser != null)
                    {
                        var auth = new DetectiveLog(new DetectiveAuth(authUser), new LogToFile());
                        if (auth.IsAuth(authUser))
                        {
                            var repository = new CriminalRepository();
                            var detective = new Detective(repository);
                            repository.Initialize();

                            var detectiveView = new DetectiveView(detective, repository);
                            detectiveView.ShowDetectiveMenu();
                        }
                        else
                        {
                            auth.IsAuth(authUser);
                            Console.WriteLine("Invalid login or password");
                            Environment.Exit(1);
                        }
                    }
                    else
                    {
    
                        Console.WriteLine("Invalid login or password");
                        Environment.Exit(1);
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

    private void ShowDetectiveMenu()
    {
        ConsoleHelper.ClearConsole();
        var exit = false;
        do
        {
            TheSearchView.ShowMenu();
            switch (ConsoleHelper.UserInput(DetectiveMessages.EnterChoiceDetective))
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
                    ConsoleHelper.PrintError(DetectiveMessages.ErrorChoice);
                    break;
            }
        } while (!exit);

        ConsoleHelper.ClearConsole();
        ConsoleHelper.PrintSuccess(DetectiveMessages.ExitMessageDetective);
    }

    private void ShowArrestedPeople(IEnumerable<Criminal> criminals)
    {
        ConsoleHelper.ClearConsole();
        ConsoleHelper.Print(DetectiveMessages.Arrested);
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
            ConsoleHelper.PrintWarning(DetectiveMessages.CriminalsNotFound);
        }
        else
        {
            ConsoleHelper.ClearConsole();
            ConsoleHelper.PrintSuccess(DetectiveMessages.CriminalsWasFound);
            findCriminal.ForEach(c => ConsoleHelper.PrintCriminal
            ($"[Height: {c.Height}," + $" Weight: {c.Weight}," + $" Nationality: {c.Nationality}]" +
             $" - [{c.FirstName} {c.LastName}] - |IsArrested:{c.IsArrested}| "));
        }
    }
    
    private void SearchCriminal()
    {
        ConsoleHelper.ClearConsole();
        ConsoleHelper.PrintSuccess(DetectiveMessages.Search);
        ConsoleHelper.PrintWarning(DetectiveMessages.ButtonToReturn);

        int height;
       
        while (true)
        {
            ConsoleHelper.PrintLine(DetectiveMessages.EnterHeight);
            int.TryParse(Console.ReadLine(), out height);

            if (height == DetectiveMessages.ExitFromMenu)
            {
                ConsoleHelper.ClearConsole();
                return;
            }

            if (!Validator.ValidateHeight(height))
            {
                ConsoleHelper.PrintError(DetectiveMessages.ErrorHeight);
                continue;
            }

            break;
        }
        

        int weight;
        while (true)
        {
            Console.Write(DetectiveMessages.EnterWeight);
            int.TryParse(Console.ReadLine(), out weight);

            if (weight == DetectiveMessages.ExitFromMenu)
            {
                ConsoleHelper.ClearConsole();
                return;
            }

            if (!Validator.ValidateWeight(weight))
            {
                ConsoleHelper.PrintError(DetectiveMessages.ErrorWeight);
                continue;
            }

            break;
        }

        string? nationality;
        while (true)
        {
            Console.Write(DetectiveMessages.EnterNationality);
            nationality = Console.ReadLine();

            if (nationality == DetectiveMessages.ExitFromMenu.ToString())
            {
                ConsoleHelper.ClearConsole();
                return;
            }

            if (!Validator.ValidateNationality(nationality))
            {
                ConsoleHelper.PrintError(DetectiveMessages.ErrorNationality);
                continue;
            }

            break;
        }

        FindCriminal(height, weight, nationality);
    }
}