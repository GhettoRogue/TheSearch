﻿using TheSearch.app.DAL.Logger;

namespace TheSearch.app.VL;

internal abstract class ConsoleHelper : ILogger
{
    #region Print

    private static void PrintColorLine(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    internal static void ClearConsole()
    {
        Console.Clear();
    }

    internal static void PrintLine(string message)
    {
        Console.Write(message);
    }

    internal static void Print(string message)
    {
        Console.WriteLine(message);
    }

    public static string UserInput(string message)
    {
        PrintLine(message);
        var input = Console.ReadLine();
        return input!;
    }

    public static void PrintError(string message)
    {
        PrintColorLine(message, ConsoleColor.Red);
    }

    public static void PrintSuccess(string message)
    {
        PrintColorLine(message, ConsoleColor.Green);
    }

    public static void PrintCriminal(string message)
    {
        PrintColorLine(message, ConsoleColor.Blue);
    }

    public static void PrintWarning(string message)
    {
        PrintColorLine(message, ConsoleColor.Yellow);
    }

    public static int InputNumber(string message)
    {
        Print(message);
        return Convert.ToInt32(Console.ReadLine());
    }

    #endregion

    #region Logger

    public void LoggerInfo(string message)
    {
        PrintColorLine($"{DateTime.Now:g} - [{nameof(LoggerInfo).ToUpper()}] ", ConsoleColor.Blue);
    }

    public void LoggerSuccess(string message)
    {
        PrintColorLine($"{DateTime.Now:g} - [{nameof(LoggerSuccess).ToUpper()}] ", ConsoleColor.Green);
    }

    public void LoggerError(string message)
    {
        PrintColorLine($"{DateTime.Now:g} - [{nameof(LoggerError).ToUpper()}] ", ConsoleColor.Red);
    }

    #endregion

    
}