using TheSearch.app.BLL;
using TheSearch.app.BLL.Criminal;
using TheSearch.app.BLL.Detective;
using TheSearch.app.IL.Interfaces.Criminal;

namespace TheSearch.app.VL;

public class DetectiveView
{
    private readonly ICriminalSerializer _serializer;

    internal DetectiveView(ICriminalSerializer serializer)
    {
        _serializer = serializer;
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
                    ShowArrestedPeople();
                    break;
                case "2":
                    SearchCriminal();
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

    private void ShowArrestedPeople()
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
            throw;
        }
    }

    private void FindCriminal(int height, int weight, string? nationality)
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