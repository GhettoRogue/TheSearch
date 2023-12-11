using TheSearch.app.BLL;
using TheSearch.app.BLL.Detective;
using TheSearch.app.DAL.Repository;
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
    
    private static class ConsoleConstMessages
    {
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
        var exit = false;
        do
        {
            TheSearchView.ShowMenu();
            switch (ConsoleHelper.UserInput(ConsoleConstMessages.EnterChoice))
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
                    ConsoleHelper.PrintError(ConsoleConstMessages.ErrorChoice);
                    break;
            }
        } while (!exit);
        ConsoleHelper.ClearConsole();
        ConsoleHelper.PrintSuccess(ConsoleConstMessages.ExitMessage);
    }

    private void ShowArrestedPeople(IEnumerable<Criminal> criminals)
    {
        ConsoleHelper.ClearConsole();
        ConsoleHelper.Print(ConsoleConstMessages.Arrested);
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
            ConsoleHelper.PrintWarning(ConsoleConstMessages.CriminalsNotFound);
        }
        else
        {
            ConsoleHelper.ClearConsole();
            ConsoleHelper.PrintSuccess(ConsoleConstMessages.CriminalsWasFound);
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
        ConsoleHelper.PrintSuccess(ConsoleConstMessages.Search);
        ConsoleHelper.PrintWarning(ConsoleConstMessages.ButtonToReturn);

        int height;
        while (true)
        {
            ConsoleHelper.PrintLine(ConsoleConstMessages.EnterHeight);
            int.TryParse(Console.ReadLine(), out height);
            
            if (height == 0)
            {
                ConsoleHelper.ClearConsole();
                return;
            }

            if (!Validator.ValidateHeight(height))
            {
                ConsoleHelper.PrintError(ConsoleConstMessages.ErrorHeight);
                continue;
            }
            
            break;
            
        }

        int weight;
        while (true)
        {
            Console.Write(ConsoleConstMessages.EnterWeight);
            int.TryParse(Console.ReadLine(), out weight);

            if (weight == 0)
            {
                ConsoleHelper.ClearConsole();
                return;
            }
            
            if (!Validator.ValidateWeight(weight))
            {
                ConsoleHelper.PrintError(ConsoleConstMessages.ErrorWeight);
                continue;
            }

            break;
        }

        string? nationality;
        while (true)
        {
            Console.Write(ConsoleConstMessages.EnterNationality);
            nationality = Console.ReadLine();
            
            
            if (nationality == "0")
            {
                ConsoleHelper.ClearConsole();
                return;
            }
            
            if (!Validator.ValidateNationality(nationality))
            {
                ConsoleHelper.PrintError(ConsoleConstMessages.ErrorNationality);
                continue;
            }
        
            break;
        }
        
        FindCriminal(height, weight, nationality);
    }
    
}