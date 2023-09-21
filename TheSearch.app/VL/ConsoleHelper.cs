using System.Drawing;

namespace TheSearch.app.VL;

public static class ConsoleHelper
{
    private static void PrintLine(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ReadKey();
    }
    
}