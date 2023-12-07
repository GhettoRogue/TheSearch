namespace TheSearch.app.Models;

public static class CriminalFactory
{
    public static Criminal CreateCriminal(uint id,string firstName, string lastName, int height, int weight,
        string nationality, bool isArrested)
    {
        return new Criminal
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Height = height,
            Weight = weight,
            Nationality = nationality,
            IsArrested = isArrested
        };
    }
}