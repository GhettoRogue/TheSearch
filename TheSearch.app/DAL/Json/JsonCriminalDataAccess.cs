using System.Text.Json;
using TheSearch.app.IL.Interfaces.Criminal;
using TheSearch.app.Models;
using TheSearch.app.VL;

namespace TheSearch.app.DAL.Json;

public class JsonCriminalDataAccess : IUseSerializer
{
    private readonly ICriminalRepository _criminalRepository;

    public JsonCriminalDataAccess(ICriminalRepository criminalRepository)
    {
        _criminalRepository = criminalRepository;
    }


    #region Criminal

    public void SerializeAllCriminals()
    {
        var json = JsonSerializer.Serialize(_criminalRepository.GetAll());
        File.WriteAllText(JsonContext.CriminalsPath, json);
    }

    public void SerializeArrestedCriminals()
    {
        var json = JsonSerializer.Serialize(_criminalRepository.GetOnlyArrested());
        File.WriteAllText(JsonContext.ArrestedPath, json);
    }

    public void SerializeNotArrestedCriminals()
    {
        var json = JsonSerializer.Serialize(_criminalRepository.GetNotArrested());
        File.WriteAllText(JsonContext.NotArrestedPath, json);
    }

    public IEnumerable<Criminal>? DeserializeAllCriminals()
    {
        try
        {
            var json = File.ReadAllText(JsonContext.CriminalsPath);
            return JsonSerializer.Deserialize<IEnumerable<Criminal>>(json);
        }
        catch (ArgumentNullException ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            throw;
        }
    }

    public IEnumerable<Criminal>? DeserializeOnlyArrested()
    {
        try
        {
            var json = File.ReadAllText(JsonContext.ArrestedPath);
            return JsonSerializer.Deserialize<IEnumerable<Criminal>>(json);
        }
        catch (ArgumentNullException ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            throw;
        }
    }

    public IEnumerable<Criminal>? DeserializeNotArrested()
    {
        try
        {
            var json = File.ReadAllText(JsonContext.NotArrestedPath);
            return JsonSerializer.Deserialize<IEnumerable<Criminal>>(json);
        }
        catch (ArgumentNullException ex)
        {
            ConsoleHelper.PrintError(ex.Message);
            throw;
        }
    }

    #endregion
}