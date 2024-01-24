namespace TheSearch.app.Models;

public abstract class CriminalFactory
{
    public static Criminal CreateCriminal(string? firstName, string? lastName, int height, int weight,
        string? nationality, bool isArrested)
    {
        return new Criminal
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Height = height,
            Weight = weight,
            Nationality = nationality,
            IsArrested = isArrested
        };
    }
}