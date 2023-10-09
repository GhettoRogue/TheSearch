using System.Text.Json;
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

        repository.SerializeAllCriminals();

        repository.SerializeArrestedCriminals();

        repository.SerializeNotArrestedCriminals();

        #endregion*/

        #region JsonTestingDeserialize

        repository.DeserializeAllCriminals();

        foreach (var item in repository.GetAll())
        {
            Console.WriteLine($"{item.Id}, {item.FirstName}, {item.LastName}, {item.IsArrested}, {item.Nationality}, {item.Height}, {item.Weight}");
        }
        
        /*repository.DeserializeOnlyArrested();

        repository.DeserializeNotArrested();*/

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