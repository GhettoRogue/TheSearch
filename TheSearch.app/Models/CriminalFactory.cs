namespace TheSearch.app.Models;

public static class CriminalFactory
{
    public static Criminal CreateCriminal(string firstName, string lastName, int height, int weight,
        string nationality, bool isArrested)
    {
        return new Criminal
        {
            Id = new Guid(),
            FirstName = firstName,
            LastName = lastName,
            Height = height,
            Weight = weight,
            Nationality = nationality,
            IsArrested = isArrested
        };
    }
}