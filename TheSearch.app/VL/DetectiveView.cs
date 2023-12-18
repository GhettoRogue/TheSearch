using TheSearch.app.BLL;
using TheSearch.app.IL.Interfaces.Criminal;
using TheSearch.app.IL.Interfaces.Detective;
using TheSearch.app.Models;

namespace TheSearch.app.VL;

public class DetectiveView
{
    private readonly IDetective _detective;
    private readonly ICriminalRepository _repository;

    public DetectiveView(IDetective detective, ICriminalRepository repository)
    {
        _detective = detective;
        _repository = repository;
    }
    
    private static class DetectiveConstMessage
    {
        public const int ExitFromMenu = 0;
        
        public const string EnterChoice = "Enter your choice detective: ";
        public const string ErrorChoice = "Invalid choice. Please try again.";
        public const string ExitMessage = "Good hunting, detective.";
        public const string Arrested = "List of arrested people:";
        public const string CriminalsNotFound = "No criminal found by using these data. What would you like to do next?";
        public const string CriminalsWasFound = "The criminal was found using this data: ";
        public const string Search = "Search for a criminal:";
        public const string ButtonToReturn = "(or press 0 to return to the menu)";
        public const string EnterHeight = "Enter height: ";
        public const string ErrorHeight = "Error: invalid height. Please try again.";
        public const string EnterWeight = "Enter weight: ";
        public const string ErrorWeight = "Error: invalid weight. Please try again.";
        public const string EnterNationality = "Enter nationality: ";
        public const string ErrorNationality = "Error: invalid nationality. Please try again.";
    }

    public void ShowDetectiveMenu()
    {
        ConsoleHelper.ClearConsole();
        var exit = true;
        do
        {
            TheSearchView.ShowMenu();
            switch (ConsoleHelper.UserInput(DetectiveConstMessage.EnterChoice))
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
        ConsoleHelper.PrintSuccess(DetectiveConstMessage.ExitMessage);
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
        if (findCriminal.Count == DetectiveConstMessage.ExitFromMenu)
        {
            ConsoleHelper.ClearConsole();
            ConsoleHelper.PrintWarning(DetectiveConstMessage.CriminalsNotFound);
        }
        else
        {
            ConsoleHelper.ClearConsole();
            ConsoleHelper.PrintSuccess(DetectiveConstMessage.CriminalsWasFound);
            foreach (var c in findCriminal)
            {
                ConsoleHelper.PrintCriminal(
                    $"[Height: {c.Height}," +
                    $" Weight: {c.Weight}," +
                    $" Nationality: {c.Nationality}]" +
                    $" - [{c.FirstName} {c.LastName}] - |IsArrested:{c.IsArrested}| " );
            }
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
            
            if (nationality == "0")
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