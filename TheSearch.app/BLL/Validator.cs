namespace TheSearch.app.BLL;

public static class Validator
{
    #region ValidateCriminals

    public static bool ValidateHeight(int height) => height is > 0 and >= 100 and <= 290;

    public static bool ValidateWeight(int weight) => weight is > 0 and >= 40 and <= 180;

    public static bool ValidateNationality(string? nationality) =>
        !string.IsNullOrEmpty(nationality) && nationality.All(char.IsLetter);

    #endregion
}