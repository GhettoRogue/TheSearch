namespace TheSearch.app;

public record Criminal
{
    public string FirstName { get; init; }
    public string Lastname { get; init; }
    public int Height { get; init; }
    public int Weight { get; init; }
    public string Nationality { get; init; }
    public bool IsArrested { get; init; }
    
}