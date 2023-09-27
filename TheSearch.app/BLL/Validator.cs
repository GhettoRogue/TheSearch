namespace TheSearch.app.BLL;

public class Validator {

    public bool ValidateHeight(int height)
    {
        switch (height)
        {
            case <= 0:
            case < 100:
            case > 300:
                return false;
            default:
                return true;
        }
    }  

    public bool ValidateWeight(int weight)
    {
        switch (weight)
        {
            case <= 0:
            case < 40:
            case > 180:
                return false;
            default:
                return true;
        }
    }

    public bool ValidateNationality(string nationality)
    {
        return !string.IsNullOrEmpty(nationality) && nationality.All(char.IsLetter);
    }
}