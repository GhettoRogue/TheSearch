namespace TheSearch.app.Models.User;

public abstract class User
{
    public required string? Login { get; init; }
    
    public required string? Password { get; init; }
}