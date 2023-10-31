namespace TheSearch.app.Models;

public record Criminal
{
    public Guid Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public int Height { get; init; }
    public int Weight { get; init; }
    public string? Nationality { get; init; }
    public bool IsArrested { get; init; }
}