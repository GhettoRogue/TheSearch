namespace TheSearch.app.VL;

public static class TheSearchView
{
    public static void ShowMenu()
    {
        Console.WriteLine("--------< Menu >--------");
        Console.WriteLine("1. Show arrested people.");
        Console.WriteLine("2. Search for a criminal.");
        Console.WriteLine("0. Exit");
        Console.WriteLine("------------------------");
    }

    public static void ShowMenuLogin()
    {
        Console.Clear();
        Console.WriteLine("-Welcome-");
        Console.WriteLine("1. Login");
        Console.WriteLine("0. Exit");
    }
    
}

   