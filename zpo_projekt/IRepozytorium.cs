namespace zpo_projekt;

public interface IRepozytorium<T> where T : Encja
{
    IEnumerable<T> PobierzWszystkie();
    T Dodaj(T encja);
    void Usun(int id);
}
