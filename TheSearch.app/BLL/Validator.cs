namespace TheSearch.app.BLL;

public static class Validator
{
    public static bool ValidateHeight(int height)
    {
        return height is > 0 and >= 100 and <= 290;
    }

    public static bool ValidateWeight(int weight)
    {
        return weight is > 0 and >= 40 and <= 180;
    }

    public static bool ValidateNationality(string? nationality)
    {
        return !string.IsNullOrEmpty(nationality) && nationality.All(char.IsLetter);
    }
}
