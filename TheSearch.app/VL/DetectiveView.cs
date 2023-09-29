using TheSearch.app.BLL;
using TheSearch.app.Models;

namespace TheSearch.app.VL;

public abstract class DetectiveView
{
    private IDetective _detective;

    public DetectiveView(IDetective detective)
    {
        _detective = detective;
    }

    public void ShowArrestedPeople(IEnumerable<Criminal> criminals)
    {
        ConsoleHelper.Print("List of arrested people:");
        var arrestedPeople = _detective?.GetArrestedCriminals(criminals);
        foreach (var criminal in arrestedPeople!)
        {
            ConsoleHelper.PrintSuccess($"ID criminal: {criminal.Id}" +
                                       $"First Name: {criminal.FirstName}" +
                                       $",Last Name: {criminal.LastName}," +
                                       $" Height: {criminal.Height}," +
                                       $" Weight: {criminal.Weight}," +
                                       $" Nationality: {criminal.Nationality}");
        }
    }

    public void FindCriminal(int height, int weight, string? nationality)
    {
        var findCriminal = _detective?.FindCriminalByParameters(height, weight, nationality).ToList();
        if (findCriminal!.Count == 0)
        {
            ConsoleHelper.PrintWarning("No criminal found by using these data. What would you like to do next?");
        }
        else if (findCriminal.Count != 0)
        {
            ConsoleHelper.PrintSuccess("The criminal was found using this data: ");
            foreach (var c in findCriminal)
            {
                ConsoleHelper.PrintCriminal($"Height: {c.Height}," + $" Weight: {c.Weight}," +
                                            $" Nationality: {c.Nationality}");
            }
        }
    }
    
}