using TheSearch.app;

var criminals = new List<Criminal>
{
    new()
    {
        FirstName = "John",
        Lastname = "Smith",
        Height = 160,
        Weight = 50,
        Nationality = "Indian",
        IsArrested = false
    },
    new()
    {
        FirstName = "Jane",
        Lastname = "Johnson",
        Height = 168,
        Weight = 56,
        Nationality = "Canadian",
        IsArrested = true
    },
    new()
    {
        FirstName = "Michael",
        Lastname = "Brown",
        Height = 183,
        Weight = 60,
        Nationality = "Australian",
        IsArrested = true
    },
    new()
    {
        FirstName = "William",
        Lastname = "Wilson",
        Height = 190,
        Weight = 90,
        Nationality = "Scottish",
        IsArrested = true
    },
    new()
    {
        FirstName = "Sophia",
        Lastname = "Clark",
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

    /*Console.Write("Enter your choice detective: ");
    var choice = Console.ReadLine();*/
    
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
    return (input!);
}

List<Criminal> ArrestedPeople(IEnumerable<Criminal> criminal)
{
    var arrestedPeople = new List<Criminal>();
    foreach (var person in criminal)
    {
        if (person.IsArrested)
        {
            arrestedPeople.Add(person);
        }
    }
    return arrestedPeople;
}
void ShowArrestedPeople()
{
    Console.WriteLine("List of arrested people:");
    ArrestedPeople(criminals!);
}

List<Criminal> FindCriminal(IEnumerable<Criminal> criminal, int height, int weight, string nationality)
{
    var findCriminal =
        from c in criminals
        where c.Height == height && c.Weight == weight && c.Nationality == nationality
        select c;

    return findCriminal.ToList();
}
void SearchCriminal()
{
    Console.WriteLine("Search for a criminal:");
    Console.Write("Enter height: ");
    var height = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Invalid height."));

    Console.Write("Enter weight: ");
    var weight = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Invalid weight."));

    Console.Write("Enter nationality: ");
    var nationality = Console.ReadLine() ?? throw new InvalidOperationException("Invalid nationality.");

    FindCriminal(criminals!, height, weight, nationality);
}