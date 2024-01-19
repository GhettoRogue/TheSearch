using AutoFixture;

namespace UnitTestTheSearch.app.BLL;

public class ValidatorTest
{
    #region Height

    [Fact]
    public void ShouldValidateHeight_True()
    {
        var fixture = new Fixture();
        var height = fixture.Create<int>();

        var result = height is > 0 and >= 100 and <= 290;

        Assert.True(result);
    }

    [Fact]
    public void ShouldValidateHeight_Negative_False()
    {
        const int invalidHeight = -1;

        var result = invalidHeight is > 0 and >= 100 and <= 290;

        Assert.False(result);
    }

    #endregion

    #region Weight

    [Fact]
    public void ShouldValidateWeight_True()
    {
        var fixture = new Fixture();
        var weight = fixture.Create<int>();

        var result = weight is > 0 and >= 40 and <= 180;

        Assert.True(result);
    }

    #endregion

    #region Weight

    [Fact]
    public void ShouldValidateNationality_True()
    {
        const string nationality = "Russian";

        var result = !string.IsNullOrEmpty(nationality) && nationality.All(char.IsLetter);
               
        Assert.True(result);
    }

    #endregion
}