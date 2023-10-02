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
        repository.Add(CriminalFactory.CreateCriminal("John", "Smith", 160, 50, "Indian", false));
        repository.Add(CriminalFactory.CreateCriminal("Jane", "Johnson", 168, 56, "Canadian", true));
        repository.Add(CriminalFactory.CreateCriminal("Michael", "Brown", 183, 60, "Australian", true));
        repository.Add(CriminalFactory.CreateCriminal("William", "Wilson", 190, 90, "Scottish", true));
        repository.Add(CriminalFactory.CreateCriminal("Sophia", "Clark", 160, 51, "South African", false));

        var detective = new Detective(repository);
        var detectiveView = new DetectiveView(detective);


        ShowDetectiveMenu(detectiveView, repository);

        return;

        static void ShowDetectiveMenu(DetectiveView detectiveView, ICriminalRepository repository)
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