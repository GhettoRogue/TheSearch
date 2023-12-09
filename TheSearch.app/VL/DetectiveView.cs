using TheSearch.app.BLL;
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

    public void ShowDetectiveMenu()
    {
        ConsoleHelper.ClearConsole();
        var exit = false;
        do
        {
            TheSearchView.ShowMenu();
            switch (ConsoleHelper.UserInput("Enter your choice detective: "))
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
                    ConsoleHelper.PrintError("Invalid choice. Please try again.");
                    break;
            }
        } while (!exit);
        ConsoleHelper.ClearConsole();
        ConsoleHelper.PrintSuccess("Good hunting, detective.");
    }

    private void ShowArrestedPeople(IEnumerable<Criminal> criminals)
    {
        ConsoleHelper.ClearConsole();
        ConsoleHelper.Print("List of arrested people:");
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
            ConsoleHelper.PrintWarning("No criminal found by using these data. What would you like to do next?");
        }
        else
        {
            ConsoleHelper.ClearConsole();
            ConsoleHelper.PrintSuccess("The criminal was found using this data: ");
            foreach (var c in findCriminal)
            {
                ConsoleHelper.PrintCriminal(
                    $"[Height: {c.Height}, Weight: {c.Weight}, Nationality: {c.Nationality}]" +
                    $" - [{c.FirstName} {c.LastName}] - |IsArrested:{c.IsArrested}| " );
            }
        }
    }

    private void SearchCriminal()
    {
        ConsoleHelper.ClearConsole();
        ConsoleHelper.PrintSuccess("Search for a criminal:");
        ConsoleHelper.PrintWarning("(or press 0 to return to the menu)");

        int height;
        while (true)
        {
            ConsoleHelper.PrintLine("Enter height: ");
            int.TryParse(Console.ReadLine(), out height);
            
            if (height == 0)
            {
                ConsoleHelper.ClearConsole();
                return;
            }

            if (!Validator.ValidateHeight(height))
            {
                ConsoleHelper.PrintError("Error: invalid height. Please try again.");
                continue;
            }
            
            break;
            
        }

        int weight;
        while (true)
        {
            Console.Write("Enter weight: ");
            int.TryParse(Console.ReadLine(), out weight);

            if (weight == 0)
            {
                ConsoleHelper.ClearConsole();
                return;
            }
            
            if (!Validator.ValidateWeight(weight))
            {
                ConsoleHelper.PrintError("Error: invalid weight. Please try again.");
                continue;
            }

            break;
        }

        string? nationality;
        while (true)
        {
            Console.Write("Enter nationality: ");
            nationality = Console.ReadLine();
            
            
            if (nationality == "0")
            {
                ConsoleHelper.ClearConsole();
                return;
            }
            
            if (!Validator.ValidateNationality(nationality))
            {
                ConsoleHelper.PrintError("Error: invalid nationality. Please try again.");
                continue;
            }
        
            break;
        }
        
        FindCriminal(height, weight, nationality);
    }
    
}