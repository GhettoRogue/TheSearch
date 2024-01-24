using AutoFixture;
using TheSearch.app.Models;

namespace UnitTestTheSearch.app.Models;

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

        var expCriminal = CriminalFactory.CreateCriminal(firstName, lastName, height, weight, nationality, isArrested);

        Assert.Equal(firstName, expCriminal.FirstName);
    }
}