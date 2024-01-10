namespace TheSearch.app.IL.Interfaces.Criminal;

public interface ICriminalSerializer
{
    void SerializeAllCriminals();

    void SerializeArrestedCriminals();

    void SerializeNotArrestedCriminals();

    void DeserializeAllCriminals();

    void DeserializeOnlyArrested();

    void DeserializeNotArrested();
}