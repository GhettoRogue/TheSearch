using TheSearch.app.BLL;
using TheSearch.app.DAL.Repository;
using TheSearch.app.VL;

namespace TheSearch.app;

public abstract class Program
{
    public static void Main()
    {
        var repository = new CriminalRepository();
        var detective = new Detective(repository);
        repository.Initialize();
        
        var detectiveView = new DetectiveView(detective, repository);
        detectiveView.ShowDetectiveMenu();

        #region JsonTestingSerialize

        /*repository.SerializeAllCriminals();

        repository.SerializeArrestedCriminals();

        repository.SerializeNotArrestedCriminals();*/

        #endregion
        
        #region JsonTestingDeserialize

        /*repository.DeserializeAllCriminals();
        
        repository.DeserializeOnlyArrested();

        repository.DeserializeNotArrested();*/

        #endregion
        
    }
}