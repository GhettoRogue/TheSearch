namespace TheSearch.app.IL.Interfaces.Criminal;

public interface ICriminalSerializer
{
    void SerializeAllCriminals();

    void SerializeArrestedCriminals();

    void SerializeNotArrestedCriminals();

    IEnumerable<Models.Criminal>? DeserializeAllCriminals();

    IEnumerable<Models.Criminal>? DeserializeOnlyArrested();

    IEnumerable<Models.Criminal>? DeserializeNotArrested();
}