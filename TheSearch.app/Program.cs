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

void ShowMenu()
{
    Console.WriteLine("--------< Menu >--------");
    Console.WriteLine("1. Show arrested people.");
    Console.WriteLine("2. Search for a criminal.");
    Console.WriteLine("3. Exit");
    Console.WriteLine("------------------------");
}

string UserInput(string message)
{
    Console.Write(message);
    var input = Console.ReadLine();
    return input!;
}

IEnumerable<Criminal> ArrestedPeople(IEnumerable<Criminal> criminal)
{
    var arrested =
        from person in criminal
        where person.IsArrested
        select person;

    return arrested;
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

IEnumerable<Criminal> Find(IEnumerable<Criminal> criminal, int height, int weight, string nationality)
{
    var find =
        from c in criminal
        where c.Height == height && c.Weight == weight && c.Nationality == nationality
        select c;
    return find;
}

void FindCriminal(IEnumerable<Criminal> criminal, int height, int weight, string nationality)
{
    Find(criminals,height,weight,nationality);
    var findCriminal = Find(criminals,height,weight,nationality).ToList();
    
    Console.WriteLine("The criminal was found using this data: ");
    foreach (var c in findCriminal)
    {
        Console.WriteLine($" Height: {c.Height}," +
                          $" Weight: {c.Weight}," +
                          $" Nationality: {c.Nationality}");
    }
}

void SearchCriminal()
{
    Console.WriteLine("Search for a criminal:");
    Console.Write("Enter height: ");
    int height;
    while (!int.TryParse(Console.ReadLine(), out height))
    {
        Console.WriteLine("Invalid height. Please try again.");
        Console.Write("Enter height: ");
    }

    Console.Write("Enter weight: ");
    int weight;
    while (!int.TryParse(Console.ReadLine(), out weight))
    {
        Console.WriteLine("Invalid weight. Please try again.");
        Console.Write("Enter weight: ");
    }

    Console.Write("Enter nationality: ");
    var nationality = Console.ReadLine() ?? throw new InvalidOperationException("Invalid nationality.");

    FindCriminal(criminals, height, weight, nationality);
}