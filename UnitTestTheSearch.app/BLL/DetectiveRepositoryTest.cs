using FakeItEasy;
using TheSearch.app.BLL.Detective;
using TheSearch.app.IL.Interfaces.Criminal;
using TheSearch.app.Models;

namespace UnitTestTheSearch.app.BLL;

public class DetectiveRepositoryTest
{
    [Fact]
    public void FindCriminalByParameters_Return_Good()
    {
        var fakeRepository = A.Fake<ICriminalRepository>();
        var detective = new DetectiveRepository(fakeRepository);

        A.CallTo(() => fakeRepository
                .GetAll())
            .Returns(new List<Criminal>()
            {
                new()
                {
                    Height = 220,
                    Weight = 190,
                    Nationality = "Russian",
                    FirstName = null,
                    IsArrested = false,
                    Id = default
                }
            });

        var result = detective.FindCriminalByParameters(220, 190, "Russian");

        Assert.Single(result);
    }

    [Fact]
    public void FindCriminalByParameters_Return_Negative()
    {
        var fakeRepository = A.Fake<ICriminalRepository>();
        var detective = new DetectiveRepository(fakeRepository);

        A.CallTo(() => fakeRepository
                .GetAll())
            .Returns(new List<Criminal>());

        var result = detective.FindCriminalByParameters(-220, -190, "");

        Assert.Empty(result);
    }
}