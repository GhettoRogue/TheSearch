using TheSearch.app.BLL;
using TheSearch.app.Models;

namespace TheSearch.app.VL;

public abstract class DetectiveView
    {
        private readonly IDetective _detective;

        protected DetectiveView(IDetective detective)
        {
            _detective = detective;
        }

        public void ShowArrestedPeople(IEnumerable<Criminal> criminals)
        {
            ConsoleHelper.Print("List of arrested people:");
            var arrestedPeople = _detective.GetArrestedCriminals(criminals);
            foreach (var criminal in arrestedPeople)
            {
                ConsoleHelper.PrintSuccess(
                    $"ID criminal: {criminal.Id}," +
                    $" First Name: {criminal.FirstName}," +
                    $" Last Name: {criminal.LastName}," +
                    $" Height: {criminal.Height}," +
                    $" Weight: {criminal.Weight}," +
                    $" Nationality: {criminal.Nationality}");
            }
        }

        private void FindCriminal(int height, int weight, string? nationality)
        {
            var findCriminal = _detective.FindCriminalByParameters(height, weight, nationality).ToList();
            if (findCriminal.Count == 0)
            {
                ConsoleHelper.PrintWarning("No criminal found by using these data. What would you like to do next?");
            }
            else
            {
                ConsoleHelper.PrintSuccess("The criminal was found using this data: ");
                foreach (var c in findCriminal)
                {
                    ConsoleHelper.PrintCriminal(
                        $"Height: {c.Height}, Weight: {c.Weight}, Nationality: {c.Nationality}");
                }
            }
        }

        public void SearchCriminal()
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
            while (true)
            {
                Console.Write("Enter nationality: ");
                nationality = Console.ReadLine();
                if (!Validator.ValidateNationality(nationality))
                {
                    ConsoleHelper.PrintError("Error: invalid nationality. Please try again.");
                    continue;
                }

                break;
            }

            FindCriminal(height, weight, nationality);
        }
    }