using TheSearch.app;
using TheSearch.app.Models;

var criminals = new List<Criminal>
{
    CriminalFactory.CreateCriminal("John", "Smith", 160, 50, "Indian", false),
    CriminalFactory.CreateCriminal("Jane", "Johnson", 168, 56, "Canadian", true),
    CriminalFactory.CreateCriminal("Michael", "Brown", 183, 60, "Australian", true),
    CriminalFactory.CreateCriminal("William", "Wilson", 190, 90, "Scottish", true),
    CriminalFactory.CreateCriminal("Sophia", "Clark", 160, 51, "South African", false)
};

ShowDetectiveMenu();

return;

#region ConsoleHelper


#endregion


#region Input

string UserInput(string message)
{
    Console.Write(message);
    var input = Console.ReadLine();
    return input!;
}

#endregion

#region ShowInfo

void ShowDetectiveMenu()
{
    
    var exit = false;
    do
    {
        ShowMenu();

        switch (UserInput("Enter your choice detective:"))
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice. Please try again.");
                Console.ResetColor();
                break;
        }
    } while (!exit);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Good hunting, detective.");
    Console.ResetColor(); 
}

void ShowMenu()
{
    Console.WriteLine("--------< Menu >--------");
    Console.WriteLine("1. Show arrested people.");
    Console.WriteLine("2. Search for a criminal.");
    Console.WriteLine("0. Exit");
    Console.WriteLine("------------------------");
}

void ShowArrestedPeople()
{
    Console.WriteLine("List of arrested people:");
    var arrestedPeople = ArrestedPeople(criminals);
    foreach (var criminal in arrestedPeople)
    {
        Console.WriteLine($"ID criminal: {criminal.Id}" +
                          $"First Name: {criminal.FirstName}" +
                          $",Last Name: {criminal.LastName}," +
                          $" Height: {criminal.Height}," +
                          $" Weight: {criminal.Weight}," +
                          $" Nationality: {criminal.Nationality}");
    }
}

void SearchCriminal()
{
    Console.WriteLine("Search for a criminal:");
    int height;
    while (true)
    {
        Console.Write("Enter height: ");
        if (int.TryParse(Console.ReadLine(), out height))
        {
            switch (height)
            {
                case <= 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: height must be more than 0. Please try again.");
                    Console.ResetColor();
                    continue;
                case < 100:
                case > 300:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: height must be between 100 or 300 cm");
                    Console.ResetColor();
                    continue;
            }

            break;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error: invalid height. Please try again.");
        Console.ResetColor();
    }

    int weight;
    while (true)
    {
        Console.Write("Enter weight: ");
        if (int.TryParse(Console.ReadLine(), out weight))
        {
            switch (weight)
            {
                case <= 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: weight must be more than 0. Please try again.");
                    Console.ResetColor();
                    continue;
                case < 100:
                case > 300:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: weight must be between 100 or 300 cm");
                    Console.ResetColor();
                    continue;
            }

            break;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error: invalid weight. Please try again.");
        Console.ResetColor();
    }

    string? nationality;
    while (true)
    {
        Console.Write("Enter nationality: ");
        nationality = Console.ReadLine();

        /*if (!string.IsNullOrEmpty(nationality) && nationality.All(char.IsLetter))
        {
            break;
        }*/
        
        if (nationality != null && nationality.All(char.IsLetter))
        {
            break;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid nationality. Please try again.");
        Console.ResetColor();
        
        // throw new FormatException("Invalid nationality. Please try again.");
        // Console.WriteLine("Invalid nationality. Please try again.");
    }

    FindCriminal(height, weight, nationality);
}

#endregion

#region FindInfo

void FindCriminal(int height, int weight, string? nationality)
{
    var findCriminal = FindCriminalByParameters(criminals, height, weight, nationality).ToList();
    Console.WriteLine("The criminal was found using this data: ");
    foreach (var c in findCriminal)
    {
        Console.WriteLine($"Height: {c.Height}," +
                          $" Weight: {c.Weight}," +
                          $" Nationality: {c.Nationality}");
    }
}

IEnumerable<Criminal> ArrestedPeople(IEnumerable<Criminal> criminal)
{
    var arrested =
        from person in criminal
        where person.IsArrested
        select person;

    return arrested;
}

IEnumerable<Criminal> FindCriminalByParameters(IEnumerable<Criminal> criminal, int height, int weight,
    string? nationality)
{
    var find =
        from c in criminal
        where c.Height == height && c.Weight == weight && c.Nationality == nationality
        select c;

    return find;
}
#endregion
    



