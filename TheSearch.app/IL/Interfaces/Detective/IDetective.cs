namespace TheSearch.app.IL.Interfaces.Detective;

public interface IDetective
{
    IEnumerable<Models.Criminal> FindCriminalByParameters(int height, int weight, string? nationality);
    IEnumerable<Models.Criminal> GetArrestedCriminals(IEnumerable<Models.Criminal> criminal);

    void GetArrestedPeople();

    void FindCriminal(int height, int weight, string? nationality);

    internal void SearchCriminal();
}