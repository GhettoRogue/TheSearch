namespace TheSearch.app;

public record Criminal
{
    public Guid Id;
    public string? FirstName;
    public string? LastName;
    public int Height;
    public int Weight;
    public string? Nationality;
    public bool IsArrested;
    
    // public string FullName => $"{FirstName} {LastName}";
}