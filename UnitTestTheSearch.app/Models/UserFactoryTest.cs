using AutoFixture;

namespace UnitTestTheSearch.app.Models;

public class UserFactoryTest
{
    [Fact]
    public void Should_CreateUser_Good()
    {
        var fixture = new Fixture();

        var login = fixture.Create<string>();
        var password = fixture.Create<string>();

        var result = TheSearch.app.Models.User.UserFactory.CreateUser(login, password);

        Assert.Equal(login, result.Login);
        Assert.Equal(password, result.Password);
    }
}