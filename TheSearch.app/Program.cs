using System.Text.Json;
using System.Text.Json.Nodes;
using TheSearch.app.BLL;
using TheSearch.app.DAL;
using TheSearch.app.Models;
using TheSearch.app.VL;

namespace TheSearch.app;

public abstract class Program
{
    public static void Main()
    {
        var repository = new CriminalRepository();
        repository.Initialize();

        var detective = new Detective(repository);
        var detectiveView = new DetectiveView(detective, repository);

        detectiveView.ShowDetectiveMenu();

        #region JsonTestingSerialize

        repository.SerializeAllCriminals();

        repository.SerializeArrestedCriminals();

        repository.SerializeNotArrestedCriminals();

        #endregion

        #region JsonTestingDeserialize

        repository.DeserializeAllCriminals();
        
        repository.DeserializeOnlyArrested();

        repository.DeserializeNotArrested();

        #endregion
        
    }
}