namespace TheSearch.app.Models;

public record Criminal
{
    public required Guid Id { get; init; }
    public required string? FirstName { get; init; }
    public string? LastName { get; init; }
    public int Height { get; init; }
    public int Weight { get; init; }
    public string? Nationality { get; init; }
    public required bool IsArrested { get; init; }
}