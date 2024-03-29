using TheSearch.app.BLL.Criminal;
using TheSearch.app.IL.Interfaces.Criminal;
using TheSearch.app.IL.Interfaces.Detective;
using TheSearch.app.VL;

namespace TheSearch.app.BLL.Detective;

public class DetectiveTools : IDetective
{
    private readonly ICriminalRepository _repository;

    private readonly ICriminalSerializer _serializer;

    public DetectiveTools(ICriminalRepository repository, ICriminalSerializer serializer)
    {
        _repository = repository;
        _serializer = serializer;
    }

    public IEnumerable<Models.Criminal> FindCriminalByParameters(int height, int weight, string? nationality) =>
        _repository
            .GetAll()
            .Where(c =>
                c.Height == height &&
                c.Weight == weight &&
                c.Nationality == nationality);

    public IEnumerable<Models.Criminal> GetArrestedCriminals(IEnumerable<Models.Criminal> criminal) =>
        criminal.Where(c => c.IsArrested);

    public void GetArrestedPeople()
    {
        ConsoleHelper.ClearConsole();
        ConsoleHelper.Print(DetectiveMessages.Arrested);
        try
        {
            var arrestedPeople =
                (_serializer.DeserializeOnlyArrested() ?? throw new InvalidOperationException()).ToList();
            arrestedPeople.ForEach(criminal => ConsoleHelper.PrintSuccess(
                $"{CriminalMessages.Id} [{criminal.Id}]," +
                $" {CriminalMessages.FirstName} {criminal.FirstName}," +
                $" {CriminalMessages.LastName} {criminal.LastName}," +
                $" {CriminalMessages.Height} {criminal.Height}," +
                $" {CriminalMessages.Weight} {criminal.Weight}," +
                $" {CriminalMessages.Nationality} {criminal.Nationality}"));

            ConsoleHelper.PrintWarning(DetectiveMessages.BackToTheMenu);

            Console.ReadKey();
            ConsoleHelper.ClearConsole();
        }
        catch (ArgumentNullException ex)
        {
            ConsoleHelper.PrintError(ex.Message);
        }
    }

    public void FindCriminal(int height, int weight, string? nationality)
    {
        var findCriminal = (_serializer
                .DeserializeAllCriminals() ?? throw new InvalidOperationException())
            .Where(c => c.Height == height && c.Weight == weight && c.Nationality == nationality)
            .ToList();
        if (!findCriminal.Any())
        {
            ConsoleHelper.ClearConsole();
            ConsoleHelper.PrintWarning(DetectiveMessages.CriminalsNotFound);
            Console.ReadKey();
            ConsoleHelper.ClearConsole();
        }
        else
        {
            ConsoleHelper.ClearConsole();
            ConsoleHelper.PrintSuccess(DetectiveMessages.CriminalsWasFound);
            findCriminal.ForEach(c => ConsoleHelper.PrintCriminal
            ($"[{CriminalMessages.Height} {c.Height}," +
             $" {CriminalMessages.Weight} {c.Weight}," +
             $" {CriminalMessages.Nationality} {c.Nationality}]" +
             $" - [{c.FirstName} {c.LastName}] - |{CriminalMessages.IsArrested}{c.IsArrested}| "));
            ConsoleHelper.PrintWarning(DetectiveMessages.BackToTheMenu);
            Console.ReadKey();
            ConsoleHelper.ClearConsole();
        }
    }

    public void SearchCriminal()
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