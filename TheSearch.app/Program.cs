using TheSearch.app.BLL;
using TheSearch.app.Models;
using TheSearch.app.VL;

namespace TheSearch.app;

//TODO: Add BLL support

public static class Program
{
    public static void Main()
    {
        var validator = new Validator();
        var criminals = new List<Criminal>
        {
            CriminalFactory.CreateCriminal("John", "Smith", 160, 50, "Indian", false),
            CriminalFactory.CreateCriminal("Jane", "Johnson", 168, 56, "Canadian", true),
            CriminalFactory.CreateCriminal("Michael", "Brown", 183, 60, "Australian", true),
            CriminalFactory.CreateCriminal("William", "Wilson", 190, 90, "Scottish", true),
            CriminalFactory.CreateCriminal("Sophia", "Clark", 160, 51, "South African", false)
        };

        ShowDetectiveMenu();

        return;

        #region ShowInfo

        void ShowDetectiveMenu()
        {
            var exit = false;
            do
            {
                TheSearchView.ShowMenu();
                
                switch (ConsoleHelper.UserInput("Enter your choice detective: "))
                {
                    case "1":
                        ShowArrestedPeople();
                        break;
                    case "2":
                        SearchCriminal();
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

        void ShowArrestedPeople()
        {
            ConsoleHelper.Print("List of arrested people:");
            var arrestedPeople = ArrestedPeople(criminals);
            foreach (var criminal in arrestedPeople)
            {
                ConsoleHelper.PrintSuccess($"ID criminal: {criminal.Id}" +
                             $"First Name: {criminal.FirstName}" +
                             $",Last Name: {criminal.LastName}," +
                             $" Height: {criminal.Height}," +
                             $" Weight: {criminal.Weight}," +
                             $" Nationality: {criminal.Nationality}");
            }
        }

        void SearchCriminal()
        {  
            ConsoleHelper.Print("Search for a criminal:");
            int height;
            while (true)
            {
                ConsoleHelper.PrintLine("Enter height: ");
                int.TryParse(Console.ReadLine(), out height);

                if (!Validator.ValidateHeight(height))
                {
                    ConsoleHelper.PrintError("Error: invalid height. Please try again.");
                    continue;
                }

                break;
            }

            int weight;
            while (true)
            {
                Console.Write("Enter weight: ");
                int.TryParse(Console.ReadLine(), out weight);

                if (!Validator.ValidateWeight(weight))
                {
                    ConsoleHelper.PrintError("Error: invalid weight. Please try again.");
                    continue;
                }

                break;
            } 
            string? nationality;
            while(true) {

                Console.Write("Enter nationality: ");
                nationality = Console.ReadLine();

                if(!Validator.ValidateNationality(nationality)) {
                    Console.WriteLine("Invalid nationality!");
                    continue;
                }

                break;
            }

            FindCriminal(height, weight, nationality);
        }
        

        #endregion

        #region FindInfo

        void FindCriminal(int height, int weight, string? nationality)
        {
            var findCriminal = FindCriminalByParameters(criminals, height, weight, nationality).ToList();
            if (findCriminal.Count == 0)
            {
                ConsoleHelper.PrintWarning("No criminal found by using these data. What would you like to do next?");
            }
            else if (findCriminal.Count != 0)
            {
                ConsoleHelper.PrintSuccess("The criminal was found using this data: ");
                foreach (var c in findCriminal)
                {
                    ConsoleHelper.PrintCriminal($"Height: {c.Height}," + $" Weight: {c.Weight}," + $" Nationality: {c.Nationality}");
                }
            }
        }

        IEnumerable<Criminal> ArrestedPeople(IEnumerable<Criminal> criminal)
        {
            var arrested =
                from person in criminal
                where person.IsArrested
                select person;

            return arrested;
        }

        IEnumerable<Criminal> FindCriminalByParameters(IEnumerable<Criminal> criminal, int height, int weight,
            string? nationality)
        {
            var find =
                from c in criminal
                where c.Height == height && c.Weight == weight && c.Nationality == nationality
                select c;

            return find;
        }

        #endregion
    }
}