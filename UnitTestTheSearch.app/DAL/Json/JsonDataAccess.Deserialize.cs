using FakeItEasy;
using TheSearch.app.IL.Interfaces.Criminal;
using TheSearch.app.Models.User;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace UnitTestTheSearch.app.Json;

public class JsonDataAccessDeserialize
{
    [Fact]
    public void SerializeAllCriminals_ExceptionTest()
    {
        var fakeRepository = A.Fake<ICriminalRepository>();
        var json = JsonSerializer.Serialize(fakeRepository.GetAll());
        
        Assert.Throws<ArgumentNullException>(() =>
        {
            File.WriteAllText(PathTestClass.Path, json);
        });
    }


    [Fact]
    public void DeserializeUser()
    {
        const string pathTest = @"C:\Programming C#\TheSearch\TheSearch.app\bin\Debug\net7.0\userAuthData.json";
        var usersJson = File.ReadAllText(pathTest);
        var result = JsonSerializer.Deserialize<IEnumerable<User>>(usersJson)!.ToList();
        
        Assert.NotEmpty(result);
        Assert.True(result.Count >= 1);
        Assert.Contains(result, u => u.Login == "sherlock");
        
    }
}