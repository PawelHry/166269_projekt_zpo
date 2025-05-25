namespace zpo_projekt;

public abstract class Encja
{
    public int Id { get; set; }
}

public class Kategoria : Encja
{
    public string Nazwa { get; set; } = string.Empty;
    public override string ToString() => Nazwa;
}

public class Wydatek : Encja
{
    public decimal Kwota { get; set; }
    public DateTime Data { get; set; }
    public int KategoriaId { get; set; }
    public Kategoria? Kategoria { get; set; }

    public override string ToString() =>
        $"{Data:d} | {Kwota:C} | {Kategoria?.Nazwa ?? "-"}";
}
