﻿using System.Text.Json;
using System.Text.Json.Nodes;
using TheSearch.app.BLL;
using TheSearch.app.DAL;
using TheSearch.app.Models;
using TheSearch.app.VL;

namespace TheSearch.app;

public abstract class Program
{
    public static void Main()
    {
        var repository = new CriminalRepository();
        repository.Initialize();

        var detective = new Detective(repository);
        var detectiveView = new DetectiveView(detective);

        //ShowDetectiveMenu();

        /*#region JsonTestingSerialize

        var criminalJson = JsonSerializer.Serialize(repository.GetAll());
        File.WriteAllText("criminal.json", criminalJson);

        var arrestedJson = JsonSerializer.Serialize(repository.GetOnlyArrested());
        File.WriteAllText("arrested.json", arrestedJson);

        var notArrestedJson = JsonSerializer.Serialize(repository.GetNotArrested());
        File.WriteAllText("notArrested.json", notArrestedJson);

        #endregion*/

        #region JsonTestingDeserialize

        /*var criminalsJson = File.ReadAllText("criminal.json");
        var criminals = JsonSerializer.Deserialize<List<Criminal>>(criminalsJson);

        foreach (var c in criminals)
        {
            Console.WriteLine($"{c.Id}, {c.IsArrested}: {c.Nationality}, {c.FirstName}, {c.LastName}, {c.Height}, {c.Weight}");
        }*/
        
        var arrestedJson = File.ReadAllText("arrested.json");
        var criminals = JsonSerializer.Deserialize<List<Criminal>>(arrestedJson);

        foreach (var c in criminals)
        {
            Console.WriteLine($"{c.Id}, {c.IsArrested}: {c.Nationality}, {c.FirstName}, {c.LastName}, {c.Height}, {c.Weight}");
        }

        #endregion

        return;

        void ShowDetectiveMenu()
        {
            var exit = false;
            do
            {
                TheSearchView.ShowMenu();
                switch (ConsoleHelper.UserInput("Enter your choice detective: "))
                {
                    case "1":
                        detectiveView.ShowArrestedPeople(repository.GetAll());
                        break;
                    case "2":
                        detectiveView.SearchCriminal();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        ConsoleHelper.PrintError("Invalid choice. Please try again.");
                        break;
                }
            } while (!exit);

            ConsoleHelper.PrintSuccess("Good hunting, detective.");
        }
    }
}