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

var searchCriminal =
    from c
        in criminals
    select new { c.Height, c.Weight, c.Nationality };

return;


/*Задача:
У нас есть список всех преступников.
Вашей программой будут пользоваться детективы.
У детектива запрашиваются данные (рост, вес, национальность)
и детективу выводятся все преступники которые подходят под эти параметры,
но уже заключенные под стражу выводиться не должны.*/


var exit = false;

while (!exit)
{
    ShowMenu();

    Console.Write("Enter your choice: ");
    var choice = Console.ReadLine();

    switch (choice)
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
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }

    Console.WriteLine();
}

void ShowMenu()
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Show arrested people");
    Console.WriteLine("2. Search for a criminal");
    Console.WriteLine("3. Exit");
}

int UserInput(string message)
{
    Console.Write(message);
    var input = Console.ReadLine();
    return int.Parse(input!);
}

List<Criminal> ArrestedPeople (criminals)
{
    var arrestedPeople = new List<Criminal>();
    foreach (var person in criminals)
    {
        if ()
        {
            arrestedPeople.Add(person);
        }
    }
}return  


void ShowArrestedPeople()
{
    Console.WriteLine("List of arrested people:");
    // var arrestedPeople = new List<Criminal>();
    // foreach (var person in criminals!)
    // {
    //     if ()
    //     {
    //         
    //     }
    // }

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
    
}
