using AutoFixture;
using AutoFixture.Kernel;
using TheSearch.app.Models.User;

namespace UnitTestTheSearch.app.Models;

public class UserFactoryTest
{
    private static User CreateTestUser(ISpecimenBuilder fixture)
    {
        return new User
        {
            Login = fixture.Create<string>(),
            Password = fixture.Create<string>()
        };
    }

    [Fact]
    public void Should_CreateUser_Good()
    {
        var fixture = new Fixture();

        var expUser = CreateTestUser(fixture);

        var actualUser = UserFactory.CreateUser(expUser.Login, expUser.Password);


        Assert.StrictEqual(expUser, actualUser);
    }
}