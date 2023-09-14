using TheSearch.app;

var criminals = new List<Criminal>
{
    new()
    {
        FirstName = "John",
        LastName = "Smith",
        Height = 160,
        Weight = 50,
        Nationality = "Indian",
        IsArrested = false
    },
    new()
    {
        FirstName = "Jane",
        LastName = "Johnson",
        Height = 168,
        Weight = 56,
        Nationality = "Canadian",
        IsArrested = true
    },
    new()
    {
        FirstName = "Michael",
        LastName = "Brown",
        Height = 183,
        Weight = 60,
        Nationality = "Australian",
        IsArrested = true
    },
    new()
    {
        FirstName = "William",
        LastName = "Wilson",
        Height = 190,
        Weight = 90,
        Nationality = "Scottish",
        IsArrested = true
    },
    new()
    {
        FirstName = "Sophia",
        LastName = "Clark",
        Height = 160,
        Weight = 51,
        Nationality = "South African",
        IsArrested = false
    }
};

var exit = false;
while (!exit)
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
        case "3":
            exit = true;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid choice. Please try again.");
            Console.ResetColor();
            break;
    }
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Good hunting, detective.");
Console.ResetColor();

return;

string UserInput(string message)
{
    Console.Write(message);
    var input = Console.ReadLine();
    return input!;
}

void ShowMenu()
{
    Console.WriteLine("--------< Menu >--------");
    Console.WriteLine("1. Show arrested people.");
    Console.WriteLine("2. Search for a criminal.");
    Console.WriteLine("3. Exit");
    Console.WriteLine("------------------------");
}

void ShowArrestedPeople()
{
    Console.WriteLine("List of arrested people:");
    var arrestedPeople = ArrestedPeople(criminals);
    foreach (var criminal in arrestedPeople)
    {
        Console.WriteLine($"First Name: {criminal.FirstName}" +
                          $",Last Name: {criminal.LastName}," +
                          $" Height: {criminal.Height}," +
                          $" Weight: {criminal.Weight}," +
                          $" Nationality: {criminal.Nationality}");
    }
}

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

void SearchCriminal()
{
    Console.WriteLine("Search for a criminal:");
    Console.Write("Enter height: ");
    int height;
    while (true)
    {
        Console.Write("Enter height: ");
        if (int.TryParse(Console.ReadLine(), out height))
        {
            break;
        }
        Console.WriteLine("Invalid height. Please try again.");
    }

    int weight;
    while (true)
    {
        Console.Write("Enter weight: ");
        if (int.TryParse(Console.ReadLine(), out weight))
        {
            break;
        }
        Console.WriteLine("Invalid weight. Please try again.");
    }

    string? nationality;
    while (true) // TODO
    {
        Console.Write("Enter nationality: ");
        nationality = Console.ReadLine();
        if (!string.IsNullOrEmpty(nationality))
        {
            break;
        }
/*
        Console.WriteLine("Invalid nationality.. Please try again.");
*/
    }
    
    FindCriminal(height, weight, nationality);
}

IEnumerable<Criminal> ArrestedPeople(IEnumerable<Criminal> criminal)
{
    var arrested =
        from person in criminal
        where person.IsArrested
        select person;

    return arrested;
}

IEnumerable<Criminal> FindCriminalByParameters(IEnumerable<Criminal> criminal, int height, int weight, string? nationality)
{
    var find =
        from c in criminal
        where c.Height == height && c.Weight == weight && c.Nationality == nationality
        select c;
    
    return find;
}