using FakeItEasy;
using TheSearch.app.IL.Interfaces.Criminal;
using TheSearch.app.Models.User;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace UnitTestTheSearch.app.Json;

public class JsonDataAccessDeserialize
{
    private const string Path = null;

    [Fact]
    public void SerializeAllCriminals_ThrowExceptionTest_Good()
    {
        var fakeRepository = A.Fake<ICriminalRepository>();
        var json = JsonSerializer.Serialize(fakeRepository.GetAll());

        Assert.Throws<ArgumentNullException>(() => { File.WriteAllText(Path, json); });
    }


    [Fact]
    public void DeserializeUser_Good()
    {
        const string pathTest = @"C:\Programming C#\TheSearch\TheSearch.app\bin\Debug\net7.0\userAuthData.json";
        const string userLoginTest = "sherlock";

        var usersJson = File.ReadAllText(pathTest);
        var result = JsonSerializer.Deserialize<IEnumerable<User>>(usersJson)!.ToList();

        Assert.NotEmpty(result);
        Assert.True(result.Count >= 1);
        Assert.Contains(result, u => u.Login == userLoginTest);
    }
}