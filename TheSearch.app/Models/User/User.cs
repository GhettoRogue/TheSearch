namespace TheSearch.app.Models.User;

public record User
{
    public required string Login { get; init; }

    public required string Password { get; init; }
}