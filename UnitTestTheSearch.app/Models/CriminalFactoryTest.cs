namespace UnitTestTheSearch.app.Models;

using AutoFixture;

public class CriminalFactoryTest
{
    [Fact]
    public void Should_CreateCriminal_Good()
    {
        var fixture = new Fixture();
        
        var firstName = fixture.Create<string>();
        var lastName = fixture.Create<string>();
        var height = fixture.Create<int>();
        var weight = fixture.Create<int>();
        var nationality = fixture.Create<string>();
        var isArrested = fixture.Create<bool>();

        var result = TheSearch.app.Models.CriminalFactory.CreateCriminal(firstName, lastName, height, weight, nationality, isArrested);
        
        Assert.Equal(firstName, result.FirstName);
        Assert.Equal(lastName, result.LastName);
        Assert.Equal(height, result.Height);
        Assert.Equal(weight, result.Weight);
        Assert.Equal(nationality, result.Nationality);
        Assert.Equal(isArrested, result.IsArrested);

    }
}